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
	<div class="post">
		<h2 class="title">Meeting Agenda</h2>
		<div class="entry">
            <dl>
                <dt>5:30 - 5:45</dt>
                <dd>Welcome and Social time. Food provided by Red Gate</dd>
                
                <dt>5:45 - 6:00</dt>
                <dd>Announcements, Member .NET Issues and Open .NET Discussion</dd>
                
                <dt>6:00 - 7:15</dt>
                <dd>Topic Presentation/Discussion</dd>
                
                <dt>7:15 - 7:30</dt>
                <dd>Door Prizes, Wrap Up</dd>
            </dl>
		</div>
		<div class="meta">
            <p>Door prize winners are drawn from the list of attendees. You must be present to win.</p>
<!--			<p class="links"><a href="#" class="comments">Comments (32)</a> &nbsp;&bull;&nbsp;&nbsp; <a href="#" class="more">Read full post &raquo;</a></p>-->
		</div>
	</div>
</asp:Content>
