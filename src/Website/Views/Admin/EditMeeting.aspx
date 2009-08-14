<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage`1[[CRIneta.Web.Core.Domain.Meeting, CRIneta.Web.Core]]" %>
<%@ Import Namespace="CRIneta.Website.Helpers"%>
<%@ Import Namespace="CRIneta.Web.Core.Domain"%>
<asp:Content ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="<%= AppHelper.CssUrl("smoothness/jquery-ui-1.7.1.custom.css") %>" />
    <script src='<%= AppHelper.JsUrl("jquery-ui-1.7.1.custom.min.js") %>' type="text/javascript"></script>
    <script src='<%= AppHelper.JsUrl("crineta.datepicker.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
<%  var meeting = ViewData.Model; %>
<fieldset>
    <legend>Edit Meeting [ID: <%= meeting.MeetingId %>]</legend>
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
        <%= Html.Select("FacilityId", ViewData["facilities"], "Name", meeting.Facility.FacilityId.ToString()) %>
    </div>
    <div>
        <label>Start Time</label>
        <%= Html.TextBox("StartTime", meeting.StartTime, new { Class = "datepicker", rel = meeting.StartTime.ToShortTimeString() })%>
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
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <% Html.RenderPartial("~/views/shared/controls/admin/links.ascx"); %>
</asp:Content>
