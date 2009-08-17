<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage`1[[CRIneta.Website.Models.MeetingData, CRIneta.Website]]" %>
<%@ Import Namespace="CRIneta.Website.Controllers"%>
<%@ Import Namespace="CRIneta.Website.Helpers"%>
<%@ Import Namespace="CRIneta.Web.Core.Domain"%>

<asp:Content ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="<%= AppHelper.CssUrl("ui-darkness/jquery-ui-1.7.2.custom.css") %>" />
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js" type="text/javascript"></script>
    <script src='<%= AppHelper.JsUrl("crineta.datepicker.js") %>' type="text/javascript"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
<%  var meeting = ViewData.Model; %>
<fieldset>
    <legend>Edit Meeting [ID: <%= meeting.MeetingId %>]</legend>
<% using(Html.BeginForm<AdminController>(x => x.SaveMeeting(null))) { %>
    <div>
        <label>Title</label>
        <%= Html.TextBoxFor(x => x.Title, new { style = "width:400px;" })%>
    </div>
    <div>
        <label>Presenter</label>
        <%= Html.TextBoxFor(x => x.Presenter, new { style = "width:400px;" })%>
    </div>
    <div>
        <label>Description</label>
        <%= Html.TextAreaFor(x => x.Description, new { rows = 6, style = "width:400px;"}) %>
    </div>
    <div>
        <label>Facility</label>
        <%= Html.DropDownListFor(x => x.FacilityId, ViewData["facilities"] as IEnumerable<SelectListItem>) %>
    </div>
    <div>
        <label>Start Time</label>
        <%= Html.TextBoxFor(x => x.StartTime, new { Class = "datepicker", rel = meeting.StartTime.ToShortTimeString() })%>
    </div>
    <div>
        <label>End Time</label>
        <%= Html.TextBoxFor(x => x.EndTime, new { Class = "datepicker", rel = meeting.EndTime.ToShortTimeString() })%>
    </div>
    <div style="margin:1ex 6em;">
        <%= Html.HiddenFor(x => x.MeetingId) %>
        <%= Html.SubmitButton("Submit", "Save/Update") %>
    </div>
<% } %>
    </fieldset>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <% Html.RenderPartial("~/views/shared/controls/admin/links.ascx"); %>
</asp:Content>
