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
        <form method="post" action="<%= Html.BuildUrlFromExpression<AccountController>(c=>c.ProcessLogin(null,null,null)) %>" id="loginActionForm">
           <fieldset>
            <label for="lusername"><span class="sectionHeader"> Login ID: </span></label>            
            <input type="text" id="lusername" name="username" maxlength="100" value="" class="input required" />
            
            <label for="lpassword">Password:</label>
            <input type="password" id="lpassword" name="password" maxlength="256" class="input required" />
            
            <div style="text-align:right">
                <input type="submit" class="submit" value="Login" />
            </div>
           </fieldset>
        </form>
    </div>
    
    
</asp:Content>
