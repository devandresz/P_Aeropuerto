<%@ Page Title="Objetos perdidos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_OBJETPERDIDOS</span><h1>Objetos perdidos</h1><p>Reportes ligados a vuelo con descripcion, lugar de perdida, fecha, hora y estado.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><% if (AuthGuard.IsAdmin(Session)) { %><a class="ops-button" href="#objetoForm">Nuevo reporte</a><% } %></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Reportes</span><strong>30</strong></div><div class="ops-metric"><span>Vuelos</span><strong>30</strong></div><div class="ops-metric"><span>Estados</span><strong>30</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_OBJETPERDIDOS</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID objeto</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID vuelo</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Lugar perdida</label><input class="ops-input" placeholder="Lugar 1" /></div><div class="ops-field"><label>Estado</label><input class="ops-input" placeholder="Perdido" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID objeto</th><th>ID vuelo</th><th>Descripcion</th><th>Lugar perdida</th><th>Fecha y hora</th><th>Estado</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>Objeto 1</td><td>Lugar 1</td><td>2026-05-15 11:00</td><td><span class="status-pill warning">Perdido</span></td></tr><tr><td>2</td><td>2</td><td>Objeto 2</td><td>Lugar 2</td><td>2026-05-15 11:00</td><td><span class="status-pill warning">Perdido</span></td></tr><tr><td>3</td><td>3</td><td>Objeto 3</td><td>Lugar 3</td><td>2026-05-15 11:00</td><td><span class="status-pill warning">Perdido</span></td></tr></tbody></table></div></section>
        <% if (AuthGuard.IsAdmin(Session)) { %>
        <section id="objetoForm" class="ops-panel ops-form-panel">
            <h2>Nuevo reporte</h2>
            <p>Formulario preparado para AER_OBJETPERDIDOS.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID objeto perdido</label><input class="ops-input" name="ID_objetperdidos" placeholder="31" /></div>
                <div class="ops-field"><label>ID vuelo</label><input class="ops-input" name="ID_vuelo" placeholder="1" /></div>
                <div class="ops-field span-2"><label>Descripcion</label><input class="ops-input" name="Descripcion" placeholder="Objeto 31" /></div>
                <div class="ops-field"><label>Lugar perdida</label><input class="ops-input" name="Lugar_perdida" placeholder="Lugar 31" /></div>
                <div class="ops-field"><label>Fecha</label><input class="ops-input" name="Fecha" type="date" /></div>
                <div class="ops-field"><label>Hora</label><input class="ops-input" name="Hora" type="time" /></div>
                <div class="ops-field"><label>Estado</label><input class="ops-input" name="Estado" placeholder="Perdido" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
        <% } %>
    </section></main>
</asp:Content>
