<%@ Page Title="Acceso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="login-page">
        <section class="login-hero" aria-labelledby="loginTitle">
            <div class="login-copy">
                <span class="eyebrow">Sistema aeroportuario</span>
                <h1 id="loginTitle">Bienvenido a AeroPortal</h1>
                <p>
                    Accede como cliente para consultar tus vuelos y servicios, o como administrador para gestionar operaciones internas.
                </p>

                <div class="trust-strip" aria-label="Beneficios de acceso">
                    <div>
                        <strong>24/7</strong>
                        <span>Disponibilidad</span>
                    </div>
                    <div>
                        <strong>2 perfiles</strong>
                        <span>Cliente y admin</span>
                    </div>
                    <div>
                        <strong>Seguro</strong>
                        <span>Validacion inicial</span>
                    </div>
                </div>
            </div>

            <section class="login-card" aria-labelledby="accessTitle">
                <div class="login-card-header">
                    <span class="login-icon" aria-hidden="true">+</span>
                    <div>
                        <h2 id="accessTitle">Iniciar sesion</h2>
                        <p>Elige el tipo de usuario para continuar.</p>
                    </div>
                </div>

                <div class="role-switch" role="tablist" aria-label="Tipo de acceso">
                    <input type="radio" id="roleClient" name="role" checked="checked" />
                    <label for="roleClient">Cliente</label>
                    <input type="radio" id="roleAdmin" name="role" />
                    <label for="roleAdmin">Administrador</label>

                    <div class="role-panel client-panel">
                        <div class="field-group">
                            <label for="<%= txtClientEmail.ClientID %>">Correo electronico</label>
                            <asp:TextBox ID="txtClientEmail" runat="server" CssClass="form-control login-input" TextMode="Email" placeholder="cliente@correo.com" />
                            <asp:RequiredFieldValidator ID="rfvClientEmail" runat="server" ControlToValidate="txtClientEmail" ValidationGroup="ClientLogin" CssClass="validation-message" ErrorMessage="Ingresa tu correo." Display="Dynamic" />
                        </div>

                        <div class="field-group">
                            <label for="<%= txtClientPassword.ClientID %>">Contrasena</label>
                            <asp:TextBox ID="txtClientPassword" runat="server" CssClass="form-control login-input" TextMode="Password" placeholder="Tu contrasena" />
                            <asp:RequiredFieldValidator ID="rfvClientPassword" runat="server" ControlToValidate="txtClientPassword" ValidationGroup="ClientLogin" CssClass="validation-message" ErrorMessage="Ingresa tu contrasena." Display="Dynamic" />
                        </div>

                        <div class="form-row-options">
                            <label class="check-option">
                                <input type="checkbox" />
                                Recordarme
                            </label>
                            <a href="#">Recuperar acceso</a>
                        </div>

                        <asp:Button ID="btnClientLogin" runat="server" Text="Entrar como cliente" CssClass="btn btn-primary login-button" ValidationGroup="ClientLogin" />
                    </div>

                    <div class="role-panel admin-panel">
                        <div class="field-group">
                            <label for="<%= txtAdminUser.ClientID %>">Usuario administrativo</label>
                            <asp:TextBox ID="txtAdminUser" runat="server" CssClass="form-control login-input" placeholder="admin.usuario" />
                            <asp:RequiredFieldValidator ID="rfvAdminUser" runat="server" ControlToValidate="txtAdminUser" ValidationGroup="AdminLogin" CssClass="validation-message" ErrorMessage="Ingresa tu usuario." Display="Dynamic" />
                        </div>

                        <div class="field-group">
                            <label for="<%= txtAdminPassword.ClientID %>">Contrasena</label>
                            <asp:TextBox ID="txtAdminPassword" runat="server" CssClass="form-control login-input" TextMode="Password" placeholder="Contrasena administrativa" />
                            <asp:RequiredFieldValidator ID="rfvAdminPassword" runat="server" ControlToValidate="txtAdminPassword" ValidationGroup="AdminLogin" CssClass="validation-message" ErrorMessage="Ingresa tu contrasena." Display="Dynamic" />
                        </div>

                        <div class="field-group">
                            <label for="<%= txtAdminCode.ClientID %>">Codigo de seguridad</label>
                            <asp:TextBox ID="txtAdminCode" runat="server" CssClass="form-control login-input" placeholder="Codigo interno" />
                            <asp:RequiredFieldValidator ID="rfvAdminCode" runat="server" ControlToValidate="txtAdminCode" ValidationGroup="AdminLogin" CssClass="validation-message" ErrorMessage="Ingresa el codigo de seguridad." Display="Dynamic" />
                        </div>

                        <asp:Button ID="btnAdminLogin" runat="server" Text="Entrar como administrador" CssClass="btn btn-primary login-button admin-button" ValidationGroup="AdminLogin" />
                    </div>
                </div>
            </section>
        </section>
    </main>

</asp:Content>
