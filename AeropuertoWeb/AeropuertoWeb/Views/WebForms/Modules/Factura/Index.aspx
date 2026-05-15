<%@ Page Title="Factura" Language="C#" MasterPageFile="~/Shared/Site.Master" %>
<%@ Import Namespace="app.Auth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_FACTURA</span><h1>Factura</h1><p>Facturas con total, numero, serie, cliente, fecha y hora.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><% if (AuthGuard.IsAdmin(Session)) { %><a class="ops-button" href="#facturaForm">Emitir factura</a><% } %></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Facturas</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Serie base</span><strong>S1</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_FACTURA</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID factura</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Numero</label><input class="ops-input" placeholder="N1" /></div><div class="ops-field"><label>Serie</label><input class="ops-input" placeholder="S1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID factura</th><th>Numero</th><th>Serie</th><th>ID cliente</th><th>Total</th><th>Fecha y hora</th></tr></thead><tbody><tr><td>1</td><td>N1</td><td>S1</td><td>1</td><td>150.00</td><td>2026-05-15 10:00</td></tr><tr><td>2</td><td>N2</td><td>S2</td><td>2</td><td>150.00</td><td>2026-05-15 10:00</td></tr><tr><td>3</td><td>N3</td><td>S3</td><td>3</td><td>150.00</td><td>2026-05-15 10:00</td></tr></tbody></table></div></section>
        <% if (AuthGuard.IsAdmin(Session)) { %>
        <section id="facturaForm" class="ops-panel ops-form-panel">
            <h2>Emitir factura</h2>
            <p>Formulario preparado para AER_FACTURA.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID factura</label><input class="ops-input" name="ID_Factura" placeholder="31" /></div>
                <div class="ops-field"><label>Total</label><input class="ops-input" name="Total" type="number" step="0.01" placeholder="150.00" /></div>
                <div class="ops-field"><label>Numero</label><input class="ops-input" name="Numero" placeholder="N31" /></div>
                <div class="ops-field"><label>Serie</label><input class="ops-input" name="Serie" placeholder="S31" /></div>
                <div class="ops-field"><label>ID cliente</label><input class="ops-input" name="ID_cliente" placeholder="1" /></div>
                <div class="ops-field"><label>Fecha</label><input class="ops-input" name="fecha" type="date" /></div>
                <div class="ops-field"><label>Hora</label><input class="ops-input" name="hora" type="time" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
        <% } %>
    </section></main>
</asp:Content>
