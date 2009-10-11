<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Groop.Website.Helpers"%>
<%@ Import Namespace="Groop.Core.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="<%= AppHelper.CssUrl("ui-darkness/jquery-ui-1.7.2.custom.css") %>" />
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js" type="text/javascript"></script>
    <script src='<%= AppHelper.JsUrl("crineta.datepicker.js") %>' type="text/javascript"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
	<div class="post">
		<h1 class="title">Add Meeting</h1>
		<div class="entry">
            <p>Use the following form to add a new meeting.</p>
		</div>
        <fieldset><% var meeting = new Meeting { StartTime = DateTime.Now.Date.AddHours(17).AddMinutes(30), EndTime = DateTime.Now.Date.AddHours(19).AddMinutes(30) }; %>
            <legend>Add New Meeting</legend>
        <% using(Html.BeginForm("SaveMeeting", "Admin")) { %>
            <div>
                <label>Title</label>
                <%= Html.TextBox("Title", meeting.Title, new { style = "width:400px;"}) %>
            </div>
            <div>
                <label>Presenter</label>
                <%= Html.TextBox("Presenter", meeting.Presenter, new { style = "width:400px;"}) %>
            </div>
            <div>
                <label>Description</label>
                <%= Html.TextArea("Description", meeting.Description, new { rows = 6, style = "width:400px;"}) %>
            </div>
            <div>
                <label>Facility</label>
                <%= Html.DropDownList("FacilityId", ViewData["facilities"] as IEnumerable<SelectListItem>) %>
            </div>
            <div>
                <label>Start Time</label>
                <%= Html.TextBox("StartTime", meeting.StartTime, new { Class = "datepicker", rel = meeting.EndTime.ToShortTimeString() })%>
            </div>
            <div>
                <label>End Time</label>
                <%= Html.TextBox("EndTime", meeting.EndTime, new { Class = "datepicker", rel = meeting.EndTime.ToShortTimeString() })%>
            </div>
            <div style="margin:1ex 6em;">
                <%= Html.SubmitButton("Submit", "Save/Update") %>
            </div>
        <% } %>
        </fieldset>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <% Html.RenderPartial("~/views/shared/controls/admin/links.ascx"); %>
</asp:Content>