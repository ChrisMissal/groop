<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/TwoCol.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Model.Domain" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
<h2>Welcome to the Cedar Rapids .NET User Group!</h2>

<div class="entry">
    <h3>Next Meeting : Writing Your First Azure Service - Presented by Greg Sohl</h3>
    <p>Greg Sohl will be presenting on Windows Azure, Microsoft's new services platform.</p>
    <p>He'll show us the new bits and how to write our first Azure service.</p>
</div>
<div class="entry">
    <h3>Meeting Agenda</h3>
    <dl>
        <dt>5:30 - 5:45</dt>
        <dd>Welcome and Social time. Food provided by Red Gate</dd>
        
        <dt>5:45 - 6:00</dt>
        <dd>Announcements, Member .NET Issues and Open .NET Discussion</dd>
        
        <dt>6:00 - 7:15</dt>
        <dd>Topic Presentation/Discussion</dd>
        
        <dt>7:15 - 7:30</dt>
        <dd>Door Prizes, Wrap Up</dd>
    </dl>
    <p><em>Door prize winners are drawn from the list of attendees. You must be present to win.</em></p>
</div>
<div class="entry">
    <h3>Unscheduled topics: </h3>
    <ul>
        <li>.NET Performance</li>
        <li>ASP.NET Webparts</li>
        <li>.NET Diagnostics</li>
    </ul>
    <p>If you are interested in speaking on any of these topics, or other .NET topics, please contact us.</p>
</div>


</asp:Content>

<asp:Content ID="sideContent" ContentPlaceHolderID="rightColumnContent" runat="server">
<%  IList<Meeting> meetings = (IList<Meeting>)ViewData["upcomingMeetings"];
    if (meetings.Count > 0)
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