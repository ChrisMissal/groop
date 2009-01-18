<%@ Import Namespace="System.Web.Mvc.Html"%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="header">
	<div id="logo">
		<h1><%=Html.ActionLink("Cedar Rapids .NET User Group", "index", "home")%></h1>
		<p>Design by <a href="http://www.freecsstemplates.org/">Free CSS Templates</a></p>
	</div>
	<div id="menu">
        <ul>
            <li><%=Html.ActionLink("Home", "index", "home") %></li>
            <li><%=Html.ActionLink("Meetings", "show", "meeting") %></li>
            <li><%=Html.ActionLink("Sponsors", "index", "sponsor") %></li>
            <li><%=Html.ActionLink("About", "about", "home") %></li>
            <li><%=Html.ActionLink("Contact", "index", "contact") %></li>
        </ul>
	</div>
</div>

