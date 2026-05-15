<%@ Page Title="Migracion" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_MIGRACION</span><h1>Migracion</h1><p>Registro migratorio por cliente, destino, fecha y hora de salida.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><% if (AuthGuard.IsAdmin(Session)) { %><a class="ops-button" href="#migracionForm">Nuevo registro</a><% } %></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Registros</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Destinos</span><strong>30</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_MIGRACION</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID migracion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Destino</label><input class="ops-input" placeholder="Des1" /></div><div class="ops-field"><label>Fecha salida</label><input class="ops-input" type="date" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID migracion</th><th>ID cliente</th><th>Destino</th><th>Fecha salida</th><th>Hora salida</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>Des1</td><td>2026-05-15</td><td>10:00</td></tr><tr><td>2</td><td>2</td><td>Des2</td><td>2026-05-15</td><td>10:00</td></tr><tr><td>3</td><td>3</td><td>Des3</td><td>2026-05-15</td><td>10:00</td></tr></tbody></table></div></section>
        <% if (AuthGuard.IsAdmin(Session)) { %>
        <section id="migracionForm" class="ops-panel ops-form-panel">
            <h2>Nuevo registro migratorio</h2>
            <p>Formulario preparado para AER_MIGRACION.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID migracion</label><input class="ops-input" name="ID_migracion" placeholder="31" /></div>
                <div class="ops-field"><label>ID cliente</label><input class="ops-input" name="ID_cliente" placeholder="1" /></div>
                <div class="ops-field"><label>Destino</label><input class="ops-input" name="Destino" placeholder="Des31" /></div>
                <div class="ops-field"><label>Fecha salida</label><input class="ops-input" name="fecha_salida" type="date" /></div>
                <div class="ops-field"><label>Hora salida</label><input class="ops-input" name="hora_salida" type="time" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
        <% } %>
    </section></main>
</asp:Content>
