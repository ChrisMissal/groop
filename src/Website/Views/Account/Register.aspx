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
         
    <%  var registrationData = ViewData.Model as RegistrationData;
        using (Html.BeginForm())
        { %>
        <fieldset>
        <div>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><%= Html.TextBox("UserName", registrationData.UserName)%></td>
                </tr>
                <tr>
                    <td>First:</td>
                    <td><%= Html.TextBox("FirstName", registrationData.FirstName)%></td>
                </tr>
                <tr>
                    <td>Last:</td>
                    <td><%= Html.TextBox("LastName", registrationData.LastName)%></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><%= Html.TextBox("Email", registrationData.Email)%></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><%= Html.Password("Password")%></td>
                </tr>
                <tr>
                    <td>Confirm password:</td>
                    <td><%= Html.Password("PasswordConfirm")%></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Register" /></td>
                </tr>
            </table>
        </div>
        </fieldset>
    <% } %>
    </div>
</div>
</asp:Content>
