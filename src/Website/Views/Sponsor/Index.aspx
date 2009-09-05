<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Website.Helpers"%>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
	<div class="post">
		<h1 class="title">CRineta Sponsors</h1>
         <dl id="sponsors" class="fullpage">
         
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/tlc_logo.jpg") %>" alt="Thomas L Cardella" /></dt>
            <dd>Thomas L Cardella.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/devexpress_logo.jpg") %>" alt="Developer Express" /></dt>
            <dd>Developer Express.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/scootersoftware.png") %>" alt="Scooter Software" /></dt>
            <dd>Scooter Software, the makers of Beyond Compare, are allowing us to give away one license per meeting.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/redgate.gif") %>" alt="Red Gate" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/logo_jetbrains_small.gif") %>" alt="Jet Brains" /></dt>
            <dd>Jet Brains makes a variety of excellent products and gives one license away to our attendees each month.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/oreilly.gif") %>" alt="O'Reilly" /></dt>
            <dd>O'Reilly provides us with books to give our attendees at our monthly meetings.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/infralogo.gif") %>" alt="Infragistics" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/rht_logo.gif") %>" alt="Robert Half" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/microsoft.gif") %>" alt="Microsoft" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/godaddy_logo.jpg") %>" alt="Go Daddy" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/ineta_box.gif") %>" alt="Ineta" /></dt>
            <dd>Our Ineta partnership gives us two Ineta speakers each year to present at our group meetings.</dd>
            
            <dt>Inactive sponsors below</dt>
            <dd>These should be put on the back burner</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/c1logo.gif") %>" alt="Component One" /></dt>
            <dd>The component before component two</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/ddj.gif") %>" alt="Doctor Dobb's Journal" /></dt>
            <dd>Doctor Dobb's Journal has lots of journal like stuff</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" alt="Addison Wesley" /></dt>
            <dd>Addison Wesley has books too, a lot of math books.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/sams.gif") %>" alt="Sams" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/apress.gif") %>" alt="Apress" /></dt>
            <dd>Apress writes lots of neat books</dd>
        </dl>
    </div>
</asp:Content>
