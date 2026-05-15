<%@ Page Title="Equipaje" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_EQUIPAJE</span><h1>Equipaje</h1><p>Equipaje registrado por cliente y peso.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Registrar equipaje</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Registros</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Peso base</span><strong>20.50 kg</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_EQUIPAJE</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID equipaje</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Peso minimo</label><input class="ops-input" placeholder="0.00" /></div><div class="ops-field"><label>Peso maximo</label><input class="ops-input" placeholder="25.00" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID equipaje</th><th>ID cliente</th><th>Peso</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>20.50 kg</td></tr><tr><td>2</td><td>2</td><td>20.50 kg</td></tr><tr><td>3</td><td>3</td><td>20.50 kg</td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
