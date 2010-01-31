<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IList<Meeting>>" %>
<%@ Import Namespace="Groop.Core.Domain"%>

<%  
    var meetings = ViewData.Model;
    if (meetings != null && meetings.Count() > 0)
    {   
    %>
        <h2>Upcoming Meetings</h2>
    <%  foreach (var meeting in meetings)
        { 
    %>
        <%
            Html.RenderPartial("~/views/meeting/meeting-summary.ascx", meeting); %>
    <% }
    }
    else
    { 
    %>
            <h2>No Upcoming Meetings</h2>
            <p>There are no meetings currently scheduled in advance. Try back later to check for any updates.</p>
    <% }
    %>