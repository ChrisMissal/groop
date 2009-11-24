<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Groop.Website.Controllers"%>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-openroad.jpg" alt="" /></div>
	<div class="post">
		<h1 class="title">Our Commitment</h1>
		<div class="entry">
            <p>CRineta is committed to providing Eastern Iowa professionals with free .NET education and building a network of .NET professionals. 
            Each month we target professionals with a presentation, demo and discussion on .NET and/or related topics. We discuss all languages 
            and facets of the .NET Framework. All meetings include free food and door prizes.</p>
		</div>
    </div>
    <div class="post">
        <h1 class="title">Want to learn more about the group?</h1>
        <ul>
            <li>For information about our meetings, visit our <%= Html.ActionLink<MeetingController>(x => x.Show(), "Meetings & Events") %> section.</li>
            <li>For information about the group's leadership, visit the Officers page.</li>
            <li>Interested in sponsoring CRineta?  Visit the Sponsorhip Information page.</li>
            <li>To interact with other CRineta members, visit our Discussion Forums.</li>
            <li>Still have questions or comments?   Email webmaster@crineta.org or use our "Contact Us" form.</li>
        </ul>
    </div>
</asp:Content>
