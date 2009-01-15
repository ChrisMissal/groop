<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Website.Controllers" %>
<%@ Import Namespace="CRIneta.Website.Helpers" %>

<asp:Content ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="<%= AppHelper.CssUrl("account.css") %>" />
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <script type="text/javascript">
        $(function(){
            ($("#lusername").val() == "") ? $("#lusername").focus() : $("#lpassword").focus().select();
        });
    </script>
    <div id="loginContainer" class="centered">
        <h1>Login</h1>
        <% using (Html.BeginForm()) { %>
            <fieldset>
                <label for="lusername"><span class="sectionHeader"> Login ID: </span></label>            
                <%= Html.TextBox("Username", null, new { @class="input required" } )%><%= Html.ValidationMessage("Username","*") %>

                <label for="lpassword">Password:</label>
                <%= Html.Password("Password", null, new { @class="input required" } )%><%= Html.ValidationMessage("Password", "*")%>

                <div style="text-align:right">
                    <input type="submit" class="submit" value="Login" />
                </div>
            </fieldset>
        <% } %>
    </div>
    
    
</asp:Content>
