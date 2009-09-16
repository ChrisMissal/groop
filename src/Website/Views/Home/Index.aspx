<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Web.Core.Domain"%>

<asp:Content ContentPlaceHolderID="headerContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        var $div = $("#content div:first");
        $div.append(
            $("<div />").addClass("jq-featuredfade").append(
                $("<p>" + $("#featuredtopic h1").text() + "</p>").hide().fadeIn(1500, function() {
                    $div.find("div").append(
                        $("<p>" + $("#featuredtopic .entry .jq-presenter").text().replace(/Featured Topic: /, '') + "</p>")
                        .css("font-size", "150%").css("text-align","right")
                        .hide().fadeIn(1000)
                    );
                })
            ));
        });
</script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
	<div style="margin-bottom: 10px;"><img src="/Content/images/supliment-clouds.jpg" alt="" /></div>
	<div id="featuredtopic" class="post">
		<h1 class="title">Writing Your First Azure Service</h1>
		<div class="entry">
			<p class="jq-presenter"><strong>Featured Topic: Presented By Greg Sohl </strong></p>
			<p>Greg Sohl will be presenting on Windows Azure, Microsoft's new services platform. He'll show us the new bits and how to write our first Azure service.</p>
		</div>
		<div class="meta">
<!--			<p class="links"><a href="#" class="comments">Comments (32)</a> &nbsp;&bull;&nbsp;&nbsp; <a href="#" class="more">Read full post &raquo;</a></p>-->
		</div>
	</div>
	<%--
	<div class="post">
	    <h2 class="title">Sign Up for Email Reminders</h2>
	    <div class="entry">

            <!--[if IE]>
            <style>
            #mc_embed_signup fieldset {
            position: relative;
            }
            #mc_embed_signup legend {
            position: absolute;
            top: -1em;
            left: .2em;
            }
            </style>
            <![endif]--> 
            <!-- Begin MailChimp Signup Form -->
            <div id="mc_embed_signup">
            <form action="http://crineta.us1.list-manage.com/subscribe/post?u=a437e7f1b6d67e2ef2bfbe64e&amp;id=ffb1af7554" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank">
	            <fieldset>
	            <legend>join our mailing list</legend>
            <div class="indicate-required">* indicates required field</div>
            <div class="mc-field-group">
            <label for="mce-EMAIL">Email Address:<strong class="note-required">*</strong>
            </label>
            <input type="text" value="" name="EMAIL" class="required email" id="mce-EMAIL">
            </div>
            <div class="mc-field-group">
            <label for="mce-FNAME">First Name:</label>
            <input type="text" value="" name="FNAME" class="" id="mce-FNAME">
            </div>
            <div class="mc-field-group">
            <label for="mce-LNAME">Last Name:</label>
            <input type="text" value="" name="LNAME" class="" id="mce-LNAME">
            </div>
		            <div id="mce-responses">
			            <div class="response" id="mce-error-response" style="display:none"></div>
			            <div class="response" id="mce-success-response" style="display:none"></div>
		            </div>
		            <div><input type="submit" value="Subscribe" name="subscribe" id="mc-embedded-subscribe" class="btn"></div>
	            </fieldset>	
            </form>
            </div><!--mc_embed_signup-->

	    </div>
	</div>
	--%>
	<div class="post">
		<h2 class="title">Meeting Agenda</h2>
		<div class="entry">
            <dl>
                <dt>5:30 - 5:45</dt>
                <dd>Welcome and Social time. Food provided by Red Gate</dd>
                
                <dt>5:45 - 6:00</dt>
                <dd>Announcements, Member .NET Issues and Open .NET Discussion</dd>
                
                <dt>6:00 - 7:45</dt>
                <dd>Topic Presentation/Discussion</dd>
                
                <dt>7:45 - 8:00</dt>
                <dd>Door Prizes, Wrap Up</dd>
            </dl>
		</div>
		<div class="meta">
            <p>Door prize winners are drawn from the list of attendees. You must be present to win.</p>
<!--			<p class="links"><a href="#" class="comments">Comments (32)</a> &nbsp;&bull;&nbsp;&nbsp; <a href="#" class="more">Read full post &raquo;</a></p>-->
		</div>
	</div>
</asp:Content>

<asp:Content ContentPlaceHolderID="pageBottom" runat="server">
<script type="text/javascript" src="http://crineta.us1.list-manage.com/js/jquery-1.2.6.min.js"></script>
<script type="text/javascript" src="http://crineta.us1.list-manage.com/js/jquery.validate.js"></script>
<script type="text/javascript" src="http://crineta.us1.list-manage.com/js/jquery.form.js"></script>
<script type="text/javascript" src="http://crineta.us1.list-manage.com/subscribe/xs-js?u=a437e7f1b6d67e2ef2bfbe64e&amp;id=ffb1af7554"></script>
</asp:Content>