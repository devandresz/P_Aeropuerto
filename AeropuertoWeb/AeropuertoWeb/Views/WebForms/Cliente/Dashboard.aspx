<%@ Page Title="Panel Cliente" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page">
        <section class="ops-shell">
            <div class="ops-hero">
                <div>
                    <span class="eyebrow">Cliente</span>
                    <h1>Mi panel</h1>
                    <p>Consulta informacion vinculada a tu usuario y cliente: vuelos, reservas, equipaje, migracion, facturas y objetos perdidos.</p>
                </div>
                <div class="ops-actions">
                    <a class="ops-button secondary" runat="server" href="~/Auth/Login.aspx">Cerrar sesion</a>
                    <a class="ops-button" runat="server" href="~/Modules/Vuelos/Index.aspx">Mis vuelos</a>
                </div>
            </div>
            <div class="module-grid">
                <a class="module-card" runat="server" href="~/Modules/Vuelos/Index.aspx"><span>AER_VUELO</span><strong>Mis vuelos</strong><p>El API debe filtrar por ID_Usuario de sesion.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Asientos/Index.aspx"><span>AER_ASIENTO</span><strong>Mis reservas</strong><p>Reservas por ID_cliente asociado al usuario.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Equipaje/Index.aspx"><span>AER_EQUIPAJE</span><strong>Mi equipaje</strong><p>Peso y registros por ID_cliente.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Migracion/Index.aspx"><span>AER_MIGRACION</span><strong>Migracion</strong><p>Destino, fecha y hora de salida por ID_cliente.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Factura/Index.aspx"><span>AER_FACTURA</span><strong>Mis facturas</strong><p>Total, numero, serie, fecha y hora por ID_cliente.</p></a>
                <a class="module-card" runat="server" href="~/Modules/ObjetosPerdidos/Index.aspx"><span>AER_OBJETPERDIDOS</span><strong>Objetos perdidos</strong><p>Reportes vinculados a vuelos del cliente.</p></a>
            </div>
        </section>
    </main>
</asp:Content>
