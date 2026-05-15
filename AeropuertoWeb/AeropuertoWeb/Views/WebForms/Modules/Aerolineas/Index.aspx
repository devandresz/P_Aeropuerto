<%@ Page Title="Aerolineas" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_AEROLINEA</span><h1>Aerolineas</h1><p>Catalogo de aerolineas con codigo AITA, ciudad y pais.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#aerolineaForm">Nueva aerolinea</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Registros</span><strong>30</strong></div><div class="ops-metric"><span>Codigos AITA</span><strong>30</strong></div><div class="ops-metric"><span>Ciudades</span><strong>30</strong></div><div class="ops-metric"><span>Paises</span><strong>30</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID aerolinea</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Codigo AITA</label><input class="ops-input" placeholder="A1" /></div><div class="ops-field"><label>Ciudad</label><input class="ops-input" placeholder="Ciudad 1" /></div><div class="ops-field"><label>Pais</label><input class="ops-input" placeholder="Pais 1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Codigo AITA</th><th>Ciudad</th><th>Pais</th></tr></thead><tbody><tr><td>1</td><td>A1</td><td>Ciudad 1</td><td>Pais 1</td></tr><tr><td>2</td><td>A2</td><td>Ciudad 2</td><td>Pais 2</td></tr><tr><td>3</td><td>A3</td><td>Ciudad 3</td><td>Pais 3</td></tr></tbody></table></div></section>
        <section id="aerolineaForm" class="ops-panel ops-form-panel">
            <h2>Nueva aerolinea</h2>
            <p>Formulario preparado para AER_AEROLINEA.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID aerolinea</label><input class="ops-input" name="ID_AEROLINEA" placeholder="31" /></div>
                <div class="ops-field"><label>Codigo AITA</label><input class="ops-input" name="Codigo_AITA" placeholder="A31" /></div>
                <div class="ops-field"><label>Ciudad</label><input class="ops-input" name="Ciudad" placeholder="Ciudad 31" /></div>
                <div class="ops-field"><label>Pais</label><input class="ops-input" name="Pais" placeholder="Pais 31" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
    </section></main>
</asp:Content>
