using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace app.Auth
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }

            if (IsLoginBypassEnabled())
            {
                btnClientLogin.CausesValidation = false;
                btnAdminLogin.CausesValidation = false;
                rfvClientEmail.Enabled = false;
                rfvClientPassword.Enabled = false;
                rfvAdminUser.Enabled = false;
                rfvAdminPassword.Enabled = false;
                rfvAdminCode.Enabled = false;
            }
        }

        protected async void btnClientLogin_Click(object sender, EventArgs e)
        {
            if (IsAdminLoginRequest())
            {
                await LoginAsAdminAsync();
                return;
            }

            await LoginAsClientAsync();
        }

        protected async void btnAdminLogin_Click(object sender, EventArgs e)
        {
            await LoginAsAdminAsync();
        }

        private async Task LoginAsClientAsync()
        {
            if (IsLoginBypassEnabled())
            {
                RedirectToMainDashboard("Cliente", txtClientEmail.Text.Trim());
                return;
            }

            if (!Page.IsValid)
            {
                return;
            }

            var request = new LoginRequest
            {
                Role = "Cliente",
                Email = txtClientEmail.Text.Trim(),
                Username = txtClientEmail.Text.Trim(),
                Password = txtClientPassword.Text
            };

            await TryLoginAsync(request, "Cliente");
        }

        private async Task LoginAsAdminAsync()
        {
            if (IsLoginBypassEnabled())
            {
                RedirectToMainDashboard("Administrador", txtAdminUser.Text.Trim());
                return;
            }

            if (!Page.IsValid)
            {
                return;
            }

            var request = new LoginRequest
            {
                Role = "Administrador",
                Username = txtAdminUser.Text.Trim(),
                Password = txtAdminPassword.Text,
                SecurityCode = txtAdminCode.Text.Trim()
            };

            await TryLoginAsync(request, "Administrador");
        }

        private bool IsAdminLoginRequest()
        {
            return string.Equals(Request.Form["selectedRole"], "Administrador", StringComparison.OrdinalIgnoreCase)
                || Request.Form[btnAdminLogin.UniqueID] != null;
        }

        private async Task TryLoginAsync(LoginRequest request, string expectedRole)
        {
            HideLoginMessage();

            var authApiUrl = ConfigurationManager.AppSettings["AuthApiUrl"];
            if (string.IsNullOrWhiteSpace(authApiUrl))
            {
                ShowLoginMessage("Configura AuthApiUrl en Web.config antes de iniciar sesion.");
                return;
            }

            LoginResponse loginResponse;
            try
            {
                loginResponse = await SendLoginRequestAsync(authApiUrl, request);
            }
            catch (HttpRequestException)
            {
                ShowLoginMessage("No se pudo conectar con el servicio de autenticacion. Revisa que el endpoint este publicado.");
                return;
            }
            catch (TaskCanceledException)
            {
                ShowLoginMessage("El servicio de autenticacion tardo demasiado en responder. Intenta de nuevo.");
                return;
            }
            catch (JsonException)
            {
                ShowLoginMessage("El servicio respondio con un formato inesperado. Revisa el JSON del endpoint.");
                return;
            }

            if (!loginResponse.Success)
            {
                ShowLoginMessage(loginResponse.Message ?? "Credenciales invalidas. Verifica tus datos e intenta de nuevo.");
                return;
            }

            var responseRole = string.IsNullOrWhiteSpace(loginResponse.Role) ? expectedRole : loginResponse.Role;
            Session["AuthToken"] = loginResponse.Token;
            Session["UserId"] = loginResponse.UserId;
            Session["UserName"] = loginResponse.Name ?? request.Username ?? request.Email;
            Session["UserRole"] = responseRole;

            Response.Redirect(GetDashboardUrl(responseRole), false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private static async Task<LoginResponse> SendLoginRequestAsync(string authApiUrl, LoginRequest request)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(15);

                var json = JsonConvert.SerializeObject(request);
                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                using (var response = await httpClient.PostAsync(authApiUrl, content))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        return BuildFailedResponse(responseBody, response.StatusCode);
                    }

                    if (string.IsNullOrWhiteSpace(responseBody))
                    {
                        return new LoginResponse
                        {
                            Success = true,
                            Role = request.Role,
                            Name = request.Username ?? request.Email
                        };
                    }

                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
                    if (loginResponse == null)
                    {
                        return new LoginResponse
                        {
                            Success = false,
                            Message = "El servicio no devolvio informacion de autenticacion."
                        };
                    }

                    loginResponse.Success = loginResponse.Success || !string.IsNullOrWhiteSpace(loginResponse.Token);
                    return loginResponse;
                }
            }
        }

        private static LoginResponse BuildFailedResponse(string responseBody, HttpStatusCode statusCode)
        {
            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                try
                {
                    var apiError = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
                    if (apiError != null && !string.IsNullOrWhiteSpace(apiError.Message))
                    {
                        apiError.Success = false;
                        return apiError;
                    }
                }
                catch (JsonException)
                {
                }
            }

            return new LoginResponse
            {
                Success = false,
                Message = statusCode == HttpStatusCode.Unauthorized
                    ? "Credenciales invalidas. Verifica tus datos e intenta de nuevo."
                    : "No fue posible iniciar sesion. Codigo del servicio: " + (int)statusCode + "."
            };
        }

        private static string GetDashboardUrl(string role)
        {
            var isAdmin = AuthGuard.IsAdminRole(role);

            var key = isAdmin ? "AdminDashboardUrl" : "ClientDashboardUrl";
            var configuredUrl = ConfigurationManager.AppSettings[key];

            return string.IsNullOrWhiteSpace(configuredUrl) ? "~/" : configuredUrl;
        }

        private static bool IsLoginBypassEnabled()
        {
            bool enabled;
            return bool.TryParse(ConfigurationManager.AppSettings["EnableLoginBypass"], out enabled) && enabled;
        }

        private void RedirectToMainDashboard(string role, string userName)
        {
            HideLoginMessage();

            Session["AuthToken"] = "test-session";
            Session["UserId"] = role == "Cliente" ? "1" : "admin-test";
            Session["UserName"] = string.IsNullOrWhiteSpace(userName) ? "Usuario de prueba" : userName;
            Session["UserRole"] = role;

            Response.Redirect(GetDashboardUrl(role), false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void ShowLoginMessage(string message)
        {
            litLoginMessage.Text = HttpUtility.HtmlEncode(message);
            pnlLoginMessage.Visible = true;
        }

        private void HideLoginMessage()
        {
            litLoginMessage.Text = string.Empty;
            pnlLoginMessage.Visible = false;
        }

        private class LoginRequest
        {
            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("securityCode")]
            public string SecurityCode { get; set; }
        }

        private class LoginResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
