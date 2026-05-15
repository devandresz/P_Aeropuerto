<%@ Page Title="Migracion" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_MIGRACION</span><h1>Migracion</h1><p>Registro migratorio por cliente, destino, fecha y hora de salida.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Nuevo registro</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Registros</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Destinos</span><strong>30</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_MIGRACION</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID migracion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Destino</label><input class="ops-input" placeholder="Des1" /></div><div class="ops-field"><label>Fecha salida</label><input class="ops-input" type="date" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID migracion</th><th>ID cliente</th><th>Destino</th><th>Fecha salida</th><th>Hora salida</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>Des1</td><td>2026-05-15</td><td>10:00</td></tr><tr><td>2</td><td>2</td><td>Des2</td><td>2026-05-15</td><td>10:00</td></tr><tr><td>3</td><td>3</td><td>Des3</td><td>2026-05-15</td><td>10:00</td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
