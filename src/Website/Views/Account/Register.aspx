<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Groop.Website.Controllers"%>
<%@ Import Namespace="Groop.Core.Presentation"%>

<asp:Content ID="registerContent" ContentPlaceHolderID="mainContent" runat="server">


	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-typewriter.jpg" alt="" /></div>
	<div class="post">
		<h1 class="title">Account Creation</h1>
		<div class="entry">
            <p>Use the form below to create a new account. Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.</p>
		</div>
		<div class="entry">
		
    <% Html.RenderAction<FlashMessageComponentController>(x => x.GetMessages()); %>
    <%= Html.ValidationSummary() %>
         
    <%  using (Html.BeginForm()) { %>
        <fieldset>
        <%= Html.EditorForModel() %>
            <input type="submit" value="Register" />
        </fieldset>
    <% } %>
    </div>
</div>
</asp:Content>
