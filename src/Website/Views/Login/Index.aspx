<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<LoginInput>"%>
<%@ Import Namespace="Groop.Website"%>
<%@ Import Namespace="MvcContrib.UI.InputBuilder"%>
<%@ Import Namespace="Groop.Website.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">  

<%= Html.ValidationSummary("Unable to log in, check your username and password.") %>
<% using (Html.BeginForm()) {%>    
    <fieldset>
      <legend>Please log in</legend>
      <%= Html.EditorForModel() %>
        <input type="submit" value="Save" />            
      <%= Html.ActionLink<HomeController>(x=>x.Index(),"Cancel") %>
    </fieldset>
<% } %>

</asp:Content>