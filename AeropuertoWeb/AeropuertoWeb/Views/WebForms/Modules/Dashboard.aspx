<%@ Page Title="Modulos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page">
        <section class="ops-shell">
            <div class="ops-hero">
                <div>
                    <span class="eyebrow"><%: AuthGuard.IsAdmin(Session) ? "Centro operativo" : "Mi informacion" %></span>
                    <h1>Modulos aeroportuarios</h1>
                    <p><%: AuthGuard.IsAdmin(Session) ? "Acceso a las tablas operativas definidas en el esquema AER_*." : "Acceso a vuelos, equipaje, reservas, migracion, facturas y objetos perdidos ligados a tu usuario." %></p>
                </div>
                <div class="ops-actions">
                    <a class="ops-button secondary" runat="server" href="~/Auth/Login.aspx">Cerrar sesion</a>
                    <a class="ops-button" runat="server" href="~/Modules/Vuelos/Index.aspx">Ver vuelos</a>
                </div>
            </div>

            <div class="module-grid">
                <% if (AuthGuard.IsAdmin(Session)) { %>
                <a class="module-card" runat="server" href="~/Modules/Tripulacion/Index.aspx"><span>Operaciones</span><strong>Tripulacion</strong><p>Asignacion de tripulantes por nombre, apellido y rol.</p></a>
                <a class="module-card" runat="server" href="~/Modules/HistorialVuelos/Index.aspx"><span>Bitacora</span><strong>Historial de vuelos</strong><p>Registro por tripulacion, avion y fecha de salida.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Aviones/Index.aspx"><span>Flota</span><strong>Aviones</strong><p>Modelo, capacidad y aeropuerto asociado.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Aerolineas/Index.aspx"><span>Socios</span><strong>Aerolineas</strong><p>Codigo AITA, ciudad y pais.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Aeropuertos/Index.aspx"><span>Red</span><strong>Aeropuertos</strong><p>Nombre, ciudad, pais y aerolinea relacionada.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Tarifas/Index.aspx"><span>Comercial</span><strong>Tarifas</strong><p>Precios y clases asociadas a vuelos.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Usuarios/Index.aspx"><span>Acceso</span><strong>Usuarios</strong><p>Nombre, apellido, correo, contrasena y rol.</p></a>
                <% } %>
                <a class="module-card" runat="server" href="~/Modules/Vuelos/Index.aspx"><span>Programacion</span><strong>Vuelos</strong><p>Origen, destino, salida, llegada, estado, usuario y avion.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Asientos/Index.aspx"><span>Reservas</span><strong>Asientos</strong><p>Reservas por cliente, fecha y estado.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Equipaje/Index.aspx"><span>Equipaje</span><strong>Equipaje</strong><p>Equipaje por cliente y peso registrado.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Migracion/Index.aspx"><span>Control</span><strong>Migracion</strong><p>Destino, fecha y hora de salida por cliente.</p></a>
                <a class="module-card" runat="server" href="~/Modules/Factura/Index.aspx"><span>Finanzas</span><strong>Factura</strong><p>Total, numero, serie, fecha y hora de facturacion.</p></a>
                <a class="module-card" runat="server" href="~/Modules/ObjetosPerdidos/Index.aspx"><span>Atencion</span><strong>Objetos perdidos</strong><p>Descripcion, lugar de perdida, fecha, hora y estado.</p></a>
            </div>
        </section>
    </main>
</asp:Content>
