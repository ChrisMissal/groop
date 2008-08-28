<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="logo">
    <h1><a href="#">Puzzled</a></h1>
    <p>&nbsp;&nbsp;by&nbsp; <a href="http://www.freecsstemplates.org/">Free CSS Templates</a></p>
</div>
<div id="menu">
    <ul>
        <li class="current_page_item"><%=Html.ActionLink("Home", "index", "home") %></li>
        <li><%=Html.ActionLink("Meetings", "show", "meeting") %></li>
        <li><%=Html.ActionLink("Sponsors", "list", "sponsor") %></li>
        <li><a href="#">About</a></li>
        <li><a href="#">Links</a></li>
        <li><a href="#">Contact</a></li>
    </ul>
</div>