<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="mainContent" runat="server">
    <h2>Account Creation</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    
    <%= Html.ValidationSummary() %>
         
    <% using (Html.BeginForm()) { %>
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
    <% } %>
</asp:Content>
