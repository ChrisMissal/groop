<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="headerContent" runat="server">
<style type="text/css">
#Contact-Submit { margin-left: 80px; }
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-twophones.jpg" alt="" /></div>
	<div class="post">
		<h1 class="title">Contact Us</h1>
		<div class="entry">
            <p>Have a question or comment regarding CRINETA?  Please fill out the form below and then click the "Send" button.  Please note that ALL fields are required.</p>
		</div>
		<div class="entry">
		    <form method="post" action="">
		        <fieldset>
		            <p><label for="Contact-Email">Your Email:</label><input type="text" class="field" name="Email" id="Contact-Email" /></p>
		            <p><label for="Contact-Name">Your Name:</label><input type="text" class="field" name="Email" id="Contact-Name" /></p>
		            <p><label for="Contact-Subject">Subject:</label><input type="text" class="field" name="Email" id="Contact-Subject" /></p>
		            <p>
		                <label for="Contact-Message">Message:</label>
		                <textarea rows="6" cols="40" name="Message" id="Contact-Message"></textarea><br />
		                <input type="submit" value="Send Message" id="Contact-Submit" />
		            </p>
		        </fieldset>
		    </form>
		</div>
    </div>
</asp:Content>