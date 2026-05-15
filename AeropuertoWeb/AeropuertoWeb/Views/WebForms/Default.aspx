<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Login.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
</script>
