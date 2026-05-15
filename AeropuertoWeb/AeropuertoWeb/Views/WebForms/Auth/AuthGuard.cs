using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace app.Auth
{
    public static class AuthGuard
    {
        private static readonly HashSet<string> ClientModulePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "/Modules/Dashboard.aspx",
            "/Modules/Dashboard",
            "/Modules/Vuelos/Index.aspx",
            "/Modules/Vuelos/Index",
            "/Modules/Asientos/Index.aspx",
            "/Modules/Asientos/Index",
            "/Modules/Equipaje/Index.aspx",
            "/Modules/Equipaje/Index",
            "/Modules/Migracion/Index.aspx",
            "/Modules/Migracion/Index",
            "/Modules/Factura/Index.aspx",
            "/Modules/Factura/Index",
            "/Modules/ObjetosPerdidos/Index.aspx",
            "/Modules/ObjetosPerdidos/Index"
        };

        public static bool IsAdmin(HttpSessionState session)
        {
            return IsAdminRole(GetRole(session));
        }

        public static bool IsClient(HttpSessionState session)
        {
            return string.Equals(GetRole(session), "Cliente", StringComparison.OrdinalIgnoreCase);
        }

        public static string GetRole(HttpSessionState session)
        {
            if (session == null)
            {
                return string.Empty;
            }

            return Convert.ToString(session["UserRole"]);
        }

        public static string GetUserId(HttpSessionState session)
        {
            if (session == null)
            {
                return string.Empty;
            }

            return Convert.ToString(session["UserId"]);
        }

        public static bool IsAdminRole(string role)
        {
            return string.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase)
                || string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsProtectedPath(string appRelativePath)
        {
            appRelativePath = NormalizePath(appRelativePath);

            return StartsWith(appRelativePath, "/Modules/")
                || StartsWith(appRelativePath, "/Admin/")
                || StartsWith(appRelativePath, "/Cliente/");
        }

        public static bool CanAccessPath(string appRelativePath, string role)
        {
            appRelativePath = NormalizePath(appRelativePath);

            if (IsAdminRole(role))
            {
                return true;
            }

            if (string.Equals(role, "Cliente", StringComparison.OrdinalIgnoreCase))
            {
                return StartsWith(appRelativePath, "/Cliente/") || ClientModulePaths.Contains(appRelativePath);
            }

            return false;
        }

        public static string GetDashboardUrl(string role)
        {
            return IsAdminRole(role) ? "~/Admin/Dashboard.aspx" : "~/Cliente/Dashboard.aspx";
        }

        private static bool StartsWith(string value, string prefix)
        {
            return value != null && value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
        }

        private static string NormalizePath(string appRelativePath)
        {
            if (string.IsNullOrWhiteSpace(appRelativePath))
            {
                return string.Empty;
            }

            return appRelativePath.TrimEnd('/');
        }
    }
}
