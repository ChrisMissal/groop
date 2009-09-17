<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-busipeople.jpg" alt="" /></div>
    <% var meeting = ViewData.Model as Meeting;
       if (meeting == null)
       { %>
	<div class="post">
		<h1 class="title">No Meeting Scheduled at This Time</h1>
		<div class="entry">
			<p>There are no meetings currently scheduled in advance. Try back later to check for any updates. In the meantime, <%= Html.ActionLink<AccountController>(x => x.Register(), "register for an account") %> so you're up to date when new meetings are added.</p>
		</div>
	</div>
       <% }
       else
       { %>
	<div class="post">
		<h1 class="title"><%=meeting.Title%></h1>
		<div class="entry">
			<p class="meta"><small><strong>Location:&nbsp;</strong><%=meeting.Facility.Name%><br /><strong>Time:&nbsp;</strong><%=meeting.StartTime.ToString("MMM, d yyyy h:mm tt")%> - <%=meeting.EndTime.ToString("MMM, d yyyy h:mm tt")%></small></p>
			<p><strong>Featured Topic: Presented By <%= meeting.Presenter %></strong></p>
			<p><%=meeting.Description%></p>
		</div>
	</div>
	<% } %>
	
	
</asp:Content>
