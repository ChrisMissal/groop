﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" Inherits="System.Web.Mvc.ViewPage`1[[System.Collections.Generic.IList`1[[CRIneta.Web.Core.Domain.Meeting, CRIneta.Web.Core]], mscorlib]]" %>
<%@ Import Namespace="CRIneta.Web.Core.Domain"%>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
<%  var model = ViewData.Model as IEnumerable<Meeting>; %>
<%  if(model != null && model.Count() > 0) { %>
    <dl>
<%      foreach (var meeting in model) { %>
    
    <dt><%= meeting.StartTime.ToShortDateString() %><br />
        <a href="/Admin/EditMeeting/<%= meeting.MeetingId %>">Edit</a></dt>
    <dd><%= meeting.Title %> - by <%= meeting.Presenter %></dd>
    
        <% } %>
        </dl>
    <% } %>
</asp:Content>

<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <% Html.RenderPartial("~/views/shared/controls/admin/links.ascx"); %>
</asp:Content>
