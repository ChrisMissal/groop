<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

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
		<h1 class="title">ASP.NET MVC in Action</h1>
		<div class="entry">
			<p class="jq-presenter"><strong>Featured Topic: Presented By Jeffrey Palermo </strong></p>
			<p>
                With the new version of ASP.NET, developers can easily leverage the 
                Model-View-Controller pattern in ASP.NET applications. Pulling logic 
                away from the UI and the views has been difficult for a long time. 
                The Model-View-Presenter pattern helps a little bit, but the fact 
                that the view has to delegate to the presenter makes the UI pattern 
                difficult to work with. This session is a detailed overview of the 
                ASP.NET MVC Framework. It is meant for developers already building 
                systems with ASP.NET 3.5 SP1.
			</p>
			
			<p>
                JEFFREY PALERMO is the CTO of Headspring Systems. Jeffrey specializes 
                in Agile management coaching and helps companies double the productivity 
                of software teams. He is instrumental in the Austin software community 
                as a member of AgileAustin and a director of the Austin .NET User Group. 
                Jeffrey has been recognized by Microsoft as a “Microsoft Most Valuable 
                Professional” (MVP) in Solutions Architecture for five years and 
                participates in the ASPInsiders group, which advises the ASP. NET 
                team on future releases. He is also certified as a MCSD.NET and 
                ScrumMaster. Jeffrey has spoken and facilitated at industry conferences 
                such as VSLive, DevTeach, the Microsoft MVP Summit, various ALT.NET 
                conferences, and Microsoft Tech Ed. He also speaks to user groups 
                around the country as part of the INETA Speakers’ Bureau. His web 
                sites are headspringsystems.com and jeffreypalermo.com. He is a graduate 
                of Texas A&amp;M University, an Eagle Scout, and an Iraq war veteran. Jeffrey 
                is the founder of the CodeCampServer open-source project and a cofounder 
                of the MvcContrib project.
			</p>
			
			<p>
			    Jeffrey Palermo is responsible for the popular Party with Palermo 
			    events that precede major Microsoft-focused conferences. Started in 
			    June of 2005, Party with Palermo has grown in popularity and size. 
			    Typical events host hundreds of people for free drinks and food and 
			    door prizes. It is the perfect way to hook up with friends and 
			    colleagues before the conference week begins. You can see past and 
			    upcoming parties at http://partywithpalermo.com where the website 
			    has run on ASP.NET MVC since October 2007.
			</p>
			
			<p>
			    Jeffrey is an author of a recent book, ASP.NET MVC in Action. 
			    You can obtain the book at http://bit.ly/mvcinaction.
			</p>
		
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