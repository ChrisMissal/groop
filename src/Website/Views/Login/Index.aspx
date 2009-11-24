<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<LoginInput>"%>
<%@ Import Namespace="Groop.Website"%>
<%@ Import Namespace="MvcContrib.UI.InputBuilder"%>
<%@ Import Namespace="Groop.Website.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">  

<fieldset>
  <h3>Please log in</h3>
  <%=Html.InputForm() %>
  <%=Html.ActionLink1<HomeController>(x=>x.Index(),"Cancel") %>
</fieldset>	
                	
</asp:Content>