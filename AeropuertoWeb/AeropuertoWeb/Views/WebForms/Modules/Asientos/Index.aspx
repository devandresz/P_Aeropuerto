<%@ Page Title="Asientos" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_ASIENTO</span><h1>Asientos</h1><p>Reservas de asiento por cliente, fecha y estado.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#">Asignar asiento</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Reservas</span><strong>30</strong></div><div class="ops-metric"><span>Clientes</span><strong>30</strong></div><div class="ops-metric"><span>Campo estado</span><strong>estado_reserva</strong></div><div class="ops-metric"><span>Tabla</span><strong>AER_ASIENTO</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>ID asiento</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>ID cliente</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Fecha reserva</label><input class="ops-input" type="date" /></div><div class="ops-field"><label>Estado reserva</label><input class="ops-input" placeholder="Reservado" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID asiento</th><th>ID cliente</th><th>Fecha reserva</th><th>Estado reserva</th></tr></thead><tbody><tr><td>1</td><td>1</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr><tr><td>2</td><td>2</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr><tr><td>3</td><td>3</td><td>2026-05-15</td><td><span class="status-pill">Reservado</span></td></tr></tbody></table></div></section>
    </section></main>
</asp:Content>
