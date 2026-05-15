<%@ Page Title="Tripulacion" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_TRIPULACION</span><h1>Tripulacion</h1><p>Personal de tripulacion con nombre, apellido y rol.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Nuevo tripulante</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Tripulantes</span><strong>30</strong></div><div class="ops-metric"><span>Roles</span><strong>30</strong></div><div class="ops-metric"><span>Historial</span><strong>30</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_TRIPULACION</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID tripulacion</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Nombre</label><input class="ops-input" placeholder="Trip1" /></div><div class="ops-field"><label>Apellido</label><input class="ops-input" placeholder="Ape1" /></div><div class="ops-field"><label>Rol</label><input class="ops-input" placeholder="Rol1" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Nombre</th><th>Apellido</th><th>Rol</th></tr></thead><tbody><tr><td>1</td><td>Trip1</td><td>Ape1</td><td>Rol1</td></tr><tr><td>2</td><td>Trip2</td><td>Ape2</td><td>Rol2</td></tr><tr><td>3</td><td>Trip3</td><td>Ape3</td><td>Rol3</td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
