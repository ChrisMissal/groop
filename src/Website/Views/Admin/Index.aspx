﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-openroad.jpg" alt="" /></div>
	<div class="post">
		<h1 class="title">Admin</h1>
		<div class="entry">
            <p>This is the admin page</p>
		</div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <% Html.RenderPartial("~/views/shared/controls/admin/links.ascx"); %>
</asp:Content>