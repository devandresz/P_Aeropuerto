<%@ Page Title="Aviones" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_AVION</span><h1>Aviones</h1><p>Inventario de aviones con modelo, capacidad y aeropuerto asociado.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#avionForm">Registrar avion</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Aviones</span><strong>30</strong></div><div class="ops-metric"><span>Capacidad base</span><strong>150</strong></div><div class="ops-metric"><span>Aeropuertos</span><strong>30</strong></div><div class="ops-metric"><span>Asociados</span><strong>30</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID avion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Modelo</label><input class="ops-input" placeholder="Modelo 1" /></div><div class="ops-field"><label>Capacidad</label><input class="ops-input" placeholder="150" /></div><div class="ops-field"><label>ID aeropuerto</label><input class="ops-input" placeholder="1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Modelo</th><th>Capacidad</th><th>ID aeropuerto</th></tr></thead><tbody><tr><td>1</td><td>Modelo 1</td><td>150</td><td>1</td></tr><tr><td>2</td><td>Modelo 2</td><td>150</td><td>2</td></tr><tr><td>3</td><td>Modelo 3</td><td>150</td><td>3</td></tr></tbody></table></div></section>
        <section id="avionForm" class="ops-panel ops-form-panel">
            <h2>Registrar avion</h2>
            <p>Formulario preparado para AER_AVION.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID avion</label><input class="ops-input" name="ID_avion" placeholder="31" /></div>
                <div class="ops-field"><label>Modelo</label><input class="ops-input" name="Modelo" placeholder="Modelo 31" /></div>
                <div class="ops-field"><label>Capacidad</label><input class="ops-input" name="Capacidad" type="number" placeholder="150" /></div>
                <div class="ops-field"><label>ID aeropuerto</label><input class="ops-input" name="AER_aeropuerto" placeholder="1" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
    </section></main>
</asp:Content>
