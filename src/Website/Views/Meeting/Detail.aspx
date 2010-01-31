<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Meeting>" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContent">

    <%= Html.DisplayForModel() %>
    
</asp:Content>