<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Meeting>" %>


<asp:Content ContentPlaceHolderID="headerContent" runat="server">
<script type="text/javascript">
    /*
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
        */
</script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <%= Html.DisplayForModel() %>
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