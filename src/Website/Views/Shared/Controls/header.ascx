<%@ Import Namespace="System.Web.Mvc.Html"%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Groop.Website.Controllers"%>
<div id="header">
	<div id="logo">
		<h1><%=Html.ActionLink<HomeController>(x=>x.Index(),"Cedar Rapids .NET User Group")%></h1>
		<p>Design by <a href="http://www.freecsstemplates.org/">Free CSS Templates</a></p>
	</div>
	<div id="menu">
        <ul>
            <li><%= Html.ActionLink<HomeController>(x=>x.Index(),"Home") %></li>
            <li><%= Html.ActionLink<MeetingController>(x => x.Show(), "Meetings")%></li>
            <li><%= Html.ActionLink<SponsorController>(x => x.Index(), "Sponsors")%></li>
            <li><%= Html.ActionLink<HomeController>(x => x.About(), "About")%></li>
            <li><%= Html.ActionLink<ContactController>(x=>x.Index(),"Contact") %></li>
        </ul>
	</div>
</div>

