<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Website.Helpers"%>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
	<div class="post">
		<h1 class="title">CRineta Sponsors</h1>
         <dl id="sponsors" class="fullpage">
         
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/tlc_logo.jpg") %>" alt="Thomas L Cardella" /></dt>
            <dd>We offer clients a unique combination of talent, experience, and expertise in the sales and service environment, including inbound, outbound, email and web chat capabilities.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/devexpress_logo.jpg") %>" alt="Developer Express" /></dt>
            <dd>Developer Express.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/scootersoftware.png") %>" alt="Scooter Software" /></dt>
            <dd>Scooter Software, the makers of Beyond Compare.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/redgate.gif") %>" alt="Red Gate" /></dt>
            <dd>Red Gate Software produces ingeniously simple tools for over 500,000 Microsoft technology professionals worldwide. We currently specialize in MS SQL Server, .NET and email archiving tools.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/logo_jetbrains_small.gif") %>" alt="Jet Brains" /></dt>
            <dd>At JetBrains, we have a passion for making people more productive through smart software solutions that help them focus more on what they really want to accomplish, and less on mundane, repetitive "computer busy work".</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/oreilly.gif") %>" alt="O'Reilly" /></dt>
            <dd>O’Reilly Media spreads the knowledge of innovators through its books, online services, magazines, research, and conferences.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/infralogo.gif") %>" alt="Infragistics" /></dt>
            <dd>We understand that it is not enough to make great products. For that reason, we supply a wide range of value-added services that help developers build high-quality applications including user interface testing tools, support, training and consulting services.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/rht_logo.gif") %>" alt="Robert Half" /></dt>
            <dd>Founded in 1948, Robert Half International Inc. (NYSE symbol: RHI), the world's first and largest specialized staffing firm, is a member of the S&P 500 index and the Forbes Global 2000.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/microsoft.gif") %>" alt="Microsoft" /></dt>
            <dd>Do you really not know what Microsoft does?</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/godaddy_logo.jpg") %>" alt="Go Daddy" /></dt>
            <dd>GoDaddy.com is the world's No. 1 ICANN-accredited domain name registrar for .COM, .NET, .ORG, .INFO, .BIZ and .US domain extensions.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/ineta_box.gif") %>" alt="Ineta" /></dt>
            <dd>Provides structured, peer-based organizational, educational, and promotional support to the growing worldwide community of Microsoft .NET user groups.</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/c1logo.gif") %>" alt="Component One" /></dt>
            <dd>Offering the industry's most complete suite of dev tools for Windows, Web and Mobile: Studio Enterprise.</dd>
            
            <!--<dt><img src="<%= AppHelper.ImageUrl("sponsors/awlogo.gif") %>" alt="Addison Wesley" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/sams.gif") %>" alt="Sams" /></dt>
            <dd>... we need some text here ...</dd>
            
            <dt><img src="<%= AppHelper.ImageUrl("sponsors/apress.gif") %>" alt="Apress" /></dt>
            <dd>... we need some text here ...</dd>-->
        </dl>
    </div>
</asp:Content>
