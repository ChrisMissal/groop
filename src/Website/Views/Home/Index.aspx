<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Puzzled.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        
    </p>
</asp:Content>
