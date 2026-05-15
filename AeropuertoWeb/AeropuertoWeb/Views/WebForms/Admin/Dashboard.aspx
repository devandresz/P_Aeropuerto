<%@ Page Title="Panel Administrador" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page">
        <section class="ops-shell">
            <div class="ops-hero">
                <div>
                    <span class="eyebrow">Administrador</span>
                    <h1>Panel administrativo</h1>
                    <p>Acceso completo a todos los modulos definidos en el esquema de base de datos.</p>
                </div>
                <div class="ops-actions">
                    <a class="ops-button secondary" runat="server" href="~/Auth/Login.aspx">Cerrar sesion</a>
                    <a class="ops-button" runat="server" href="~/Modules/Dashboard.aspx">Ver modulos</a>
                </div>
            </div>
            <div class="ops-metrics"><div class="ops-metric"><span>Tablas base</span><strong>16</strong></div><div class="ops-metric"><span>Modulos</span><strong>13</strong></div><div class="ops-metric"><span>Rol</span><strong>Admin</strong></div><div class="ops-metric"><span>Acceso</span><strong>Total</strong></div></div>
        </section>
    </main>
</asp:Content>
