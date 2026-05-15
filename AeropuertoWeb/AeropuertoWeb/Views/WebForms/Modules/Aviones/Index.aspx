<%@ Page Title="Aviones" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_AVION</span><h1>Aviones</h1><p>Inventario de aviones con modelo, capacidad y aeropuerto asociado.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Registrar avion</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Aviones</span><strong>30</strong></div><div class="ops-metric"><span>Capacidad base</span><strong>150</strong></div><div class="ops-metric"><span>Aeropuertos</span><strong>30</strong></div><div class="ops-metric"><span>Asociados</span><strong>30</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID avion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Modelo</label><input class="ops-input" placeholder="Modelo 1" /></div><div class="ops-field"><label>Capacidad</label><input class="ops-input" placeholder="150" /></div><div class="ops-field"><label>ID aeropuerto</label><input class="ops-input" placeholder="1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Modelo</th><th>Capacidad</th><th>ID aeropuerto</th></tr></thead><tbody><tr><td>1</td><td>Modelo 1</td><td>150</td><td>1</td></tr><tr><td>2</td><td>Modelo 2</td><td>150</td><td>2</td></tr><tr><td>3</td><td>Modelo 3</td><td>150</td><td>3</td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
