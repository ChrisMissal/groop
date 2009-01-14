<%@ Import Namespace="System.Web.Mvc.Html"%>
<%@ Import Namespace="CRIneta.Website.Controllers"%>
<%@ Import Namespace="CRIneta.Model"%>
<%@ Import Namespace="MvcContrib" %>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>

<% var userData = ViewData.Get<UserData>();  %>
<% if (userData.IsAuthenticated)
   {
%>
        <p id="signedIn">
            Signed in as <strong><%= userData.Username %></strong>&nbsp;(<%=Html.ActionLink("My Account", "Index", "Account") %> / <%=Html.ActionLink("Sign Out", "Logout", "Account") %>)
        </p>
        <!-- end p signedIn -->
<%
    }
   else
   {
%>
        <p id="signedIn">
            You are <strong>not signed in</strong> (
            <%= Html.ActionLink("Sign In", "Login", "Account") %>
            or
            <%= Html.ActionLink("Register", "Register", "Account") %>
            )
        </p>
<!-- end p signedIn -->
<%
    }
%>