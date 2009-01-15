<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/TwoCol.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Model.Domain" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
    <% var meeting = (Meeting)ViewData["nextMeeting"];
       if (meeting == null)
       { %>
       <h1 class="title">Upcoming Meetings</h1>
       <div class="entry"><h2>There are no upcoming meetings</h2></div>
       <% }
       else
       { %>
	<h1 class="title"><%=meeting.Title%></h1>
	<p class="meta"><small><strong>Location:&nbsp;</strong><%=meeting.Facility.Name%><br /><strong>Time:&nbsp;</strong><%=meeting.StartTime.ToString("MMM, d yyyy h:mm tt")%> - <%=meeting.EndTime.ToString("MMM, d yyyy h:mm tt")%></small></p>
	<div class="entry">
	    <h2></h2>
	    <p><%=meeting.Description%></p>
	</div>
	<% } %>
</asp:Content>

<asp:Content ID="sideContent" ContentPlaceHolderID="rightColumnContent" runat="server">
<%  IList<Meeting> meetings = (IList<Meeting>)ViewData["upcomingMeetings"];
    if (meetings != null && meetings.Count > 0)
    {
        foreach (var meeting in meetings)
        { %>

	    <div class="post">
		    <h2 class="title"><%=meeting.Title%></h2>
		    <p class="meta"><small><strong>Location:&nbsp;</strong><%=meeting.Facility.Name%><br /><strong>Time:&nbsp;</strong><%=meeting.StartTime.ToString("h:mm tt")%> - <%=meeting.EndTime.ToString("MMM, d yyyy h:mm tt")%></small></p>
		    <div class="entry">
		        <p><%=meeting.Description%></p>
		        <p><a href="/meeting/<%=meeting.MeetingId %>" class="more">Read More</a></p>
		    </div>
	    </div>

    <% }
    }
    else
    { %>
        <div class="post">
            <h2 class="title">No Upcoming Meetings</h2>
            <div class="entry">
                <p>There are no meetings currently scheduled in advance. Try back later to check for any updates.</p>
            </div>
        </div>
    <% }%>
</asp:Content>