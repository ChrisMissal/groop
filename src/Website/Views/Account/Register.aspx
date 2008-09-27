<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="mainContent" runat="server">
    <h2>Account Creation</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%
        IList<string> errors = ViewData["errors"] as IList<string>;
        if (errors != null) {
            %>
                <ul class="error">
                <% foreach (string error in errors) { %>
                    <li><%= Html.Encode(error) %></li>
                <% } %>
                </ul>
            <%
        }
         %>
    <form method="post" action="<%= Html.AttributeEncode(Url.Action("ProcessRegistration")) %>">
        <div>
            <table>
                
                <tr>
                    <td>Username:</td>
                    <td><%= Html.TextBox("username") %></td>
                </tr>
                <tr>
                    <td>First:</td>
                    <td><%= Html.TextBox("first") %></td>
                </tr>
                <tr>
                    <td>Last:</td>
                    <td><%= Html.TextBox("last") %></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><%= Html.TextBox("email") %></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><%= Html.Password("password") %></td>
                </tr>
                <tr>
                    <td>Confirm password:</td>
                    <td><%= Html.Password("passwordConfirm") %></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Register" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
