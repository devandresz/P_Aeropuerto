using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using app.Auth;

namespace app
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (Context == null || Context.Session == null)
            {
                return;
            }

            var relativePath = VirtualPathUtility.ToAppRelative(Context.Request.AppRelativeCurrentExecutionFilePath)
                .Replace("~/", "/");

            if (!AuthGuard.IsProtectedPath(relativePath))
            {
                return;
            }

            var role = Convert.ToString(Session["UserRole"]);
            if (string.IsNullOrWhiteSpace(role))
            {
                Response.Redirect("~/Auth/Login.aspx", false);
                CompleteAppRequest();
                return;
            }

            if (!AuthGuard.CanAccessPath(relativePath, role))
            {
                Response.Redirect(AuthGuard.GetDashboardUrl(role), false);
                CompleteAppRequest();
            }
        }

        private void CompleteAppRequest()
        {
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
