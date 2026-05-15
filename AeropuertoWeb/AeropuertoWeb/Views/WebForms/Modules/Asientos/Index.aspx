<%@ Page Title="Asientos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_ASIENTO</span><h1>Asientos</h1><p>Reservas de asiento por cliente, fecha y estado.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><% if (AuthGuard.IsAdmin(Session)) { %><a class="ops-button" href="#asientoForm">Asignar asiento</a><% } %></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Reservas</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Campo estado</span><strong>estado_reserva</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_ASIENTO</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID asiento</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Fecha reserva</label><input class="ops-input" type="date" /></div><div class="ops-field"><label>Estado reserva</label><input class="ops-input" placeholder="Reservado" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID asiento</th><th>ID cliente</th><th>Fecha reserva</th><th>Estado reserva</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr><tr><td>2</td><td>2</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr><tr><td>3</td><td>3</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr></tbody></table></div></section>
        <% if (AuthGuard.IsAdmin(Session)) { %>
        <section id="asientoForm" class="ops-panel ops-form-panel">
            <h2>Asignar asiento</h2>
            <p>Formulario preparado para AER_ASIENTO.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID asiento</label><input class="ops-input" name="ID_asiento" placeholder="31" /></div>
                <div class="ops-field"><label>ID cliente</label><input class="ops-input" name="ID_cliente" placeholder="1" /></div>
                <div class="ops-field"><label>Fecha reserva</label><input class="ops-input" name="fecha_reserva" type="date" /></div>
                <div class="ops-field"><label>Estado reserva</label><input class="ops-input" name="estado_reserva" placeholder="Reservado" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
        <% } %>
    </section></main>
</asp:Content>
