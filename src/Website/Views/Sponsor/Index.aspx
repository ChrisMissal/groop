<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Website.Helpers"%>


<asp:Content runat="server" ContentPlaceHolderID="mainContent">
     <dl id="sponsors">
        <dt><img src="<%= AppHelper.ImageUrl("sponsors/apress.gif") %>" alt="Apress" /></dt>
        <dd>Apress writes lots of neat books</dd>
        <dt><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" alt="Addison Wesley" /></dt>
        <dd>Addison Wesley has books too, a lot of math books.</dd>
        <dt><img src="<%= AppHelper.ImageUrl("sponsors/c1logo.gif") %>" alt="Component One" /></dt>
        <dd>The component before component two</dd>
        <dt><img src="<%= AppHelper.ImageUrl("sponsors/ddj.gif") %>" alt="Apress" /></dt>
        <dd>Doctor Dobb's Journal has lots of journal like stuff</dd>
        <dt><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" alt="Apress" /></dt>
        <dd>Apress writes lots of neat books</dd>
    </dl>
    <ul>
        <li><h3>Robert Half</h3><img src="<%= AppHelper.ImageUrl("sponsors/rht_logo.gif") %>" /></li>
        <li><h3>Red Gate</h3><img src="<%= AppHelper.ImageUrl("sponsors/redgate.gif") %>" alt="Red Gate" /></li>
        <li><h3>Jet Brains</h3><img src="" alt="Jet Brains" /></li>
        <li><h3>O'Reilly</h3><img src="<%= AppHelper.ImageUrl("sponsors/oreilly.gif") %>" /></li>
        <li><h3>Microsoft</h3><img src="<%= AppHelper.ImageUrl("sponsors/microsoft.gif") %>" /></li>
        <li><h3>Go Daddy</h3><img src="<%= AppHelper.ImageUrl("sponsors/godaddy_logo.jpg") %>" /></li>
        <li><h3>Apress</h3><img src="<%= AppHelper.ImageUrl("sponsors/apress.gif") %>" /></li>
        <li><h3>Addison Wesley</h3><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" /></li>
        <li><h3>ComponentOne</h3><img src="<%= AppHelper.ImageUrl("sponsors/c1logo.gif") %>" /></li>
        <li><h3>Dr. Dobb's</h3><img src="<%= AppHelper.ImageUrl("sponsors/ddj.gif") %>" /></li>
        
        <li><h3>Ineta</h3><img src="<%= AppHelper.ImageUrl("sponsors/ineta_box.gif") %>" /></li>
        <li><h3>Infragistics</h3><img src="<%= AppHelper.ImageUrl("sponsors/infralogo.gif") %>" /></li>
        
        
        
        
        <li><h3>Sams</h3><img src="<%= AppHelper.ImageUrl("sponsors/sams.gif") %>" /></li>
    </ul>
</asp:Content>
