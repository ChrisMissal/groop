<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="mainContent" runat="server">

	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-typewriter.jpg" alt="" /></div>
	<div class="post">
		<h1 class="title">Account Creation</h1>
		<div class="entry">
            <p>Use the form below to create a new account. Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.</p>
		</div>
		<div class="entry">
    <%= Html.ValidationSummary() %>
         
    <% using (Html.BeginForm()) { %>
        <fieldset>
        <div>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><%= Html.TextBox("username")%><%= Html.ValidationMessage("username") %></td>
                </tr>
                <tr>
                    <td>First:</td>
                    <td><%= Html.TextBox("First")%><%= Html.ValidationMessage("First") %></td>
                </tr>
                <tr>
                    <td>Last:</td>
                    <td><%= Html.TextBox("Last")%><%= Html.ValidationMessage("Last") %></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><%= Html.TextBox("Email")%><%= Html.ValidationMessage("Email") %></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><%= Html.Password("Password")%><%= Html.ValidationMessage("Password")%></td>
                </tr>
                <tr>
                    <td>Confirm password:</td>
                    <td><%= Html.Password("PasswordConfirm")%><%= Html.ValidationMessage("PasswordConfirm") %></td>
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
