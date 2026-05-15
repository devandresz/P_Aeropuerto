<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Shared/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ops-page"><section class="ops-shell">
        <div class="ops-hero"><div><span class="eyebrow">AER_USUARIO</span><h1>Usuarios</h1><p>Catalogo de usuarios con nombre, apellido, correo, contrasena y rol.</p></div><div class="ops-actions"><a class="ops-button secondary" runat="server" href="~/Modules/Dashboard.aspx">Modulos</a><a class="ops-button" href="#usuarioForm">Nuevo usuario</a></div></div>
        <div class="ops-metrics"><div class="ops-metric"><span>Usuarios</span><strong>30</strong></div><div class="ops-metric"><span>Admins</span><strong>1</strong></div><div class="ops-metric"><span>Roles de prueba</span><strong>29</strong></div><div class="ops-metric"><span>Clientes vinculables</span><strong>30</strong></div></div>
        <section class="ops-panel"><div class="ops-toolbar"><div class="ops-field"><label>Buscar</label><input class="ops-input" placeholder="Nombre, apellido o correo" /></div><div class="ops-field"><label>Rol</label><select class="ops-select"><option>Todos</option><option>Admin</option><option>Cliente</option></select></div><div class="ops-field"><label>ID usuario</label><input class="ops-input" placeholder="1" /></div><div class="ops-field"><label>Correo</label><input class="ops-input" placeholder="mcano@mail.com" /></div></div>
        <div class="ops-table-wrap"><table class="ops-table"><thead><tr><th>ID</th><th>Nombre</th><th>Apellido</th><th>Correo</th><th>Rol</th></tr></thead><tbody><tr><td>1</td><td>Maria Fernanda</td><td>Cano Gonzalez</td><td>mcano@mail.com</td><td><span class="status-pill">Admin</span></td></tr><tr><td>2</td><td>Nom2</td><td>Ape2</td><td>c2@mail.com</td><td><span class="status-pill neutral">Rol 2</span></td></tr><tr><td>3</td><td>Nom3</td><td>Ape3</td><td>c3@mail.com</td><td><span class="status-pill neutral">Rol 3</span></td></tr></tbody></table></div></section>
        <section id="usuarioForm" class="ops-panel ops-form-panel">
            <h2>Nuevo usuario</h2>
            <p>Formulario preparado para AER_USUARIO.</p>
            <div class="ops-form-grid">
                <div class="ops-field"><label>ID usuario</label><input class="ops-input" name="ID_Usuario" placeholder="31" /></div>
                <div class="ops-field"><label>Nombre</label><input class="ops-input" name="Nombre" placeholder="Nombre" /></div>
                <div class="ops-field"><label>Apellido</label><input class="ops-input" name="Apellido" placeholder="Apellido" /></div>
                <div class="ops-field"><label>Correo</label><input class="ops-input" name="Correo" type="email" placeholder="correo@mail.com" /></div>
                <div class="ops-field"><label>Contrasena</label><input class="ops-input" name="Contrasena" type="password" placeholder="Contrasena" /></div>
                <div class="ops-field"><label>Rol</label><input class="ops-input" name="Rol" placeholder="Cliente o Admin" /></div>
            </div>
            <div class="ops-form-actions"><button type="button" class="ops-button">Guardar cuando exista API</button></div>
        </section>
    </section></main>
</asp:Content>
