<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="headerContent" runat="server">
<style type="text/css">
#Submit { margin-left: 80px; }
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
		    <% using(Html.BeginForm()) { %>
		        <fieldset>
		            <p><label for="Email">Your Email:</label><%= Html.TextBox("Email", "", new { Class = "field" })%></p>
		            <p><label for="Name">Your Name:</label><%= Html.TextBox("Name", "", new { Class = "field" })%></p>
		            <p><label for="Subject">Subject:</label><%= Html.TextBox("Subject", "", new { Class = "field" })%></p>
		            <p>
		                <label for="Contact-Message">Message:</label>
		                <textarea rows="6" cols="40" name="Message" id="Message"></textarea><br />
		                <input type="submit" value="Send Message" id="Submit" />
		            </p>
		        </fieldset>
		    <% } %>
		</div>
    </div>
</asp:Content>