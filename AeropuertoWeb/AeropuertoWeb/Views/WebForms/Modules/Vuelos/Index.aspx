<%@ Page Title="Vuelos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_VUELO</span><h1>Vuelos</h1><p>Programacion de vuelos con origen, destino, salida, llegada, estado, usuario y avion.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#vueloForm"><%: AuthGuard.IsAdmin(Session) ? "Nuevo vuelo" : "Registrarme en vuelo" %></a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Vuelos</span><strong>30</strong></div><div class="ops-metric"><span>Activos</span><strong>30</strong></div><div class="ops-metric"><span>Aviones</span><strong>30</strong></div><div class="ops-metric"><span>Usuarios vinculados</span><strong>30</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID vuelo</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Origen</label><input class="ops-input" placeholder="Ori 1" /></div><div class="ops-field"><label>Destino</label><input class="ops-input" placeholder="Des 1" /></div><div class="ops-field"><label>Estado</label><select class="ops-select"><option>Todos</option><option>Activo</option></select></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Ruta</th><th>Salida</th><th>Llegada</th><th>Estado</th><th>Usuario</th><th>Avion</th></tr></thead><tbody><tr><td>1</td><td>Ori 1 - Des 1</td><td>2026-05-15 10:00</td><td>2026-05-15 12:00</td><td><span class="status-pill">Activo</span></td><td>1</td><td>1</td></tr><tr><td>2</td><td>Ori 2 - Des 2</td><td>2026-05-15 10:00</td><td>2026-05-15 12:00</td><td><span class="status-pill">Activo</span></td><td>2</td><td>2</td></tr><tr><td>3</td><td>Ori 3 - Des 3</td><td>2026-05-15 10:00</td><td>2026-05-15 12:00</td><td><span class="status-pill">Activo</span></td><td>3</td><td>3</td></tr></tbody></table></div></section>
        <section id="vueloForm" class="ops-panel ops-form-panel">
            <% if (AuthGuard.IsAdmin(Session)) { %>
            <h2>Nuevo vuelo</h2>
            <p>Formulario preparado para enviar al endpoint de AER_VUELO cuando el API este listo.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID vuelo</label><input class="ops-input" name="ID_vuelo" placeholder="31" /></div>
                <div class="ops-field"><label>Origen</label><input class="ops-input" name="Origen" placeholder="Ori 31" /></div>
                <div class="ops-field"><label>Destino</label><input class="ops-input" name="Destino" placeholder="Des 31" /></div>
                <div class="ops-field"><label>Estado</label><input class="ops-input" name="estado" placeholder="Activo" /></div>
                <div class="ops-field"><label>Fecha salida</label><input class="ops-input" name="fecha_salida" type="date" /></div>
                <div class="ops-field"><label>Hora salida</label><input class="ops-input" name="hora_salida" type="time" /></div>
                <div class="ops-field"><label>Fecha llegada</label><input class="ops-input" name="fecha_llegada" type="date" /></div>
                <div class="ops-field"><label>Hora llegada</label><input class="ops-input" name="hora_llegada" type="time" /></div>
                <div class="ops-field"><label>ID usuario</label><input class="ops-input" name="ID_Usuario" placeholder="1" /></div>
                <div class="ops-field"><label>ID avion</label><input class="ops-input" name="ID_avion" placeholder="1" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
            <% } else { %>
            <h2>Registrarme en vuelo</h2>
            <p>Solicitud preparada para que el API vincule tu usuario autenticado con el vuelo elegido.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID vuelo</label><input class="ops-input" name="ID_vuelo" placeholder="1" /></div>
                <div class="ops-field"><label>ID usuario</label><input class="ops-input" name="ID_Usuario" value="<%: AuthGuard.GetUserId(Session) %>" readonly="readonly" /></div>
                <div class="ops-field span-2"><label>Estado solicitado</label><input class="ops-input" name="estado" value="Activo" readonly="readonly" /><span class="ops-help-text">El API validara disponibilidad y guardara la relacion real.</span></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Enviar solicitud cuando exista API</button></div>
            <% } %>
        </section>
    </section></main>
</asp:Content>
