<%@ Page Title="Tarifas" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_TARIFA / AER_CLASE</span><h1>Tarifas</h1><p>Precios de tarifa y clases asociadas a vuelos.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#tarifaForm">Nueva tarifa</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Tarifas</span><strong>30</strong></div><div class="ops-metric"><span>Clases</span><strong>30</strong></div><div class="ops-metric"><span>Vuelos vinculados</span><strong>30</strong></div><div class="ops-metric"><span>Precio base</span><strong>100.00</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID tarifa</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Precio</label><input class="ops-input" placeholder="100.00" /></div><div class="ops-field"><label>Clase</label><input class="ops-input" placeholder="Clase 1" /></div><div class="ops-field"><label>ID vuelo</label><input class="ops-input" placeholder="1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID tarifa</th><th>Precio</th><th>ID clase</th><th>Clase</th><th>ID vuelo</th></tr></thead><tbody><tr><td>1</td><td>100.00</td><td>1</td><td>Clase 1</td><td>1</td></tr><tr><td>2</td><td>105.00</td><td>2</td><td>Clase 2</td><td>2</td></tr><tr><td>3</td><td>110.00</td><td>3</td><td>Clase 3</td><td>3</td></tr></tbody></table></div></section>
        <section id="tarifaForm" class="ops-panel ops-form-panel">
            <h2>Nueva tarifa y clase</h2>
            <p>Formulario preparado para AER_TARIFA y AER_CLASE.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID tarifa</label><input class="ops-input" name="ID_tarifa" placeholder="31" /></div>
                <div class="ops-field"><label>Precio</label><input class="ops-input" name="Precio" type="number" step="0.01" placeholder="250.00" /></div>
                <div class="ops-field"><label>ID clase</label><input class="ops-input" name="ID_clase" placeholder="31" /></div>
                <div class="ops-field"><label>Clase</label><input class="ops-input" name="Clase" placeholder="Clase 31" /></div>
                <div class="ops-field"><label>ID vuelo</label><input class="ops-input" name="ID_vuelo" placeholder="1" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
    </section></main>
</asp:Content>
