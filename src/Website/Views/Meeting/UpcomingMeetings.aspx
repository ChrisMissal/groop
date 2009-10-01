<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Meeting[]>" %>

<%  
    var meetings = ViewData.Model;
    if (meetings != null && meetings.Count() > 0)
    {   
    %>
        <h2>Upcoming Meetings</h2>
    <%  foreach (var meeting in meetings)
        { 
    %>
            <p><strong><%=meeting.Title%></strong><br /><small>
                <strong>Location:&nbsp;</strong><%=meeting.Facility.Name%><br />
                <strong>Time:&nbsp;</strong><%=meeting.StartTime.ToString("h:mm tt")%> - <%=meeting.EndTime.ToString("MMM, d yyyy h:mm tt")%>
            </small></p>
            <div class="entry">
                <p><%=meeting.Description%></p>
                <p><a href="/meeting/<%=meeting.MeetingId %>" class="more">Read More</a></p>
            </div>
    <% }
    }
    else
    { 
    %>
            <h2>No Upcoming Meetings</h2>
            <p>There are no meetings currently scheduled in advance. Try back later to check for any updates.</p>
    <% }
    %>