<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Groop.Core.Domain"%>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-twophones.jpg" alt="" /></div>
    <%  var contactMessage = ViewData["ContactMessage"] as ContactMessage; %>
    <div class="post">
        <h2 class="title">Message Sent</h2>
        <div class="entry">
            <p>Thank you <%= contactMessage.Name %>, your message has been sent.</p>
        </div>
    </div>
</asp:Content>
