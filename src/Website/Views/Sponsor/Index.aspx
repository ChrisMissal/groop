<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Website.Helpers"%>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
	<div class="post">
		<h1 class="title">CRineta Sponsors</h1>
         <dl id="sponsors" class="fullpage">
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
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/rht_logo.gif") %>" alt="Robert Half" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/redgate.gif") %>" alt="Red Gate" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="" alt="Jet Brains" /></dt>
            <dd><em>... we need some text here &amp; we need an image here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/oreilly.gif") %>" alt="O'Reilly" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/microsoft.gif") %>" alt="Microsoft" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/godaddy_logo.jpg") %>" alt="Go Daddy" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" alt="Addison Wesley" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/c1logo.gif") %>" alt="ComponentOne" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/ddj.gif") %>" alt="Dr. Dobb's" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/ineta_box.gif") %>" alt="Ineta" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/infralogo.gif") %>" alt="Infragistics" /></dt>
            <dd><em>... we need some text here ...</em></dd>
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/sams.gif") %>" alt="Sams" /></dt>
            <dd><em>... we need some text here ...</em></dd>
        </dl>
    </div>
</asp:Content>
