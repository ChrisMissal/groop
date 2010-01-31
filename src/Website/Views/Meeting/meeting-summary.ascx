<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Meeting>" %>
<%@ Import Namespace="Groop.Core.Domain"%>

<p><strong><%= Model.Title%></strong><br /><small>
    <strong>Location:&nbsp;</strong><%= Model.Facility.Name%><br />
    <strong>Time:&nbsp;</strong><%= Model.StartTime.ToString("h:mm tt")%> - <%=Model.EndTime.ToString("MMM, d yyyy h:mm tt")%>
</small></p>
<div class="entry">
    <p><%=Model.Description%></p>
    <p><a href="/Model/<%=Model.MeetingId %>" class="more">Read More</a></p>
</div>