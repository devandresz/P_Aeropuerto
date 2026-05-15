<%@ Page Title="Historial de vuelos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_HISTORIALVUELO</span><h1>Historial de vuelos</h1><p>Historial por tripulacion, avion y fecha de salida.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Exportar</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Registros</span><strong>30</strong></div><div class="ops-metric"><span>Tripulacion</span><strong>30</strong></div><div class="ops-metric"><span>Aviones</span><strong>30</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_HISTORIALVUELO</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID historial</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID tripulacion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID avion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Fecha salida</label><input class="ops-input" type="date" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID historial</th><th>ID tripulacion</th><th>ID avion</th><th>Fecha salida</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>1</td><td>2026-05-15</td></tr><tr><td>2</td><td>2</td><td>2</td><td>2026-05-15</td></tr><tr><td>3</td><td>3</td><td>3</td><td>2026-05-15</td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
