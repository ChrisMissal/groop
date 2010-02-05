<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Meeting>" %>
<%@ Import Namespace="Groop.Website.Helpers.Extensions"%>
<%@ Import Namespace="Groop.Core.Domain"%>

<p><strong><%= Model.Title%></strong><br /><small>
    <strong>Location:&nbsp;</strong><%= Model.Facility.Name%><br />
    <strong>Time:&nbsp;</strong><%= Model.StartTime.ToString("h:mm tt")%> - <%=Model.EndTime.ToString("MMM, d yyyy h:mm tt")%>
</small></p>
<div class="entry">
    <p><%= Html.Text(Model.Description)%></p>
    <p><%= Html.ActionLink<MeetingController>(x=>x.Detail(Model.MeetingId),"Read More...", new { @class = "more"}) %>
</div>