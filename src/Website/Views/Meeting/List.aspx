<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/TwoCol.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="CRIneta.Model.Domain" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
    <% var allMeetings = (IList<Meeting>)ViewData["allMeetings"];
       if (allMeetings.Count > 0)
       { %>
       <h1 class="title">Upcoming Meetings</h1>
       <% foreach (var meeting in allMeetings)
          { %>
	    <h2><%=meeting.Title%></h2>
	    <p class="meta"><small><strong>Location:&nbsp;</strong><%=meeting.Facility.Name%><br /><strong>Time:&nbsp;</strong><%=meeting.StartTime.ToString("MMM, d yyyy h:mm tt")%> - <%=meeting.EndTime.ToString("MMM, d yyyy h:mm tt")%></small></p>
	    <div class="entry">
	        <h2></h2>
	        <p><%=meeting.Description%></p>
	    </div>
    	<% }
       }
       else
       { %>
       <h1 class="title">There are no upcoming meetings</h1>
       <% } %>
</asp:Content>