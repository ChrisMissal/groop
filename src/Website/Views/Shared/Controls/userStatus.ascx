<%@ Import Namespace="System.Web.Mvc.Html"%>

<%@ Import Namespace="MvcContrib" %>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Groop.Core"%>

<% var userData = ViewData.Get<UserData>();  %>
<% if (userData.IsAuthenticated)
   {
%>
    <h2>Welcome <%= userData.Username %>!</h2>
        <ul><% if(userData.IsInRole(role => role.Name == "Administrators")) { %>
            <li><%=Html.ActionLink("Admin", "Index", "Admin") %></li>
            <% } %>
            <li><%=Html.ActionLink("My Account", "Index", "Account") %></li>
            <li><%=Html.ActionLink("Sign Out", "Logout", "Account") %></li>
        </ul>
    
    <% } else { %>
        
<h2>Sign In / Register</h2>
<form method="post" action="/Account/Login">
	<fieldset>
	    <p><label for="Login-Username">Username:</label><input type="text" id="Login-Username" name="Username" value="" class="field" /></p>
	    <p><label for="Login-Password">Password:</label><input type="password" id="Login-Password" name="Password" value="" class="field" />
	        <input type="submit" id="Login-Login" value="Login" /></p>
        <p style="text-align:right;">
        Don't have an Account? <%= Html.ActionLink("Register", "Register", "Account") %> for free!
        </p>
	</fieldset>
</form>
<%
    }
%>