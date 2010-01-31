<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Meeting>" %>

	<%-- <div style="margin-bottom: 10px;"><img src="/Content/images/supliment-clouds.jpg" alt="" /></div> --%>
	<div id="featuredtopic" class="post">
		<h1 class="title"><%= Model.Title %></h1>
		<div class="entry">
			<p class="jq-presenter"><strong>Featured Topic: Presented By <%= Model.Presenter %></strong></p>
			<%= Model.Description %>
	    </div>
	    <div class="rsvp" style="border:solid 1px black">
	        This is the RSVP area
	        <% Html.RenderPartial("~/views/shared/controls/rsvp.ascx"); %>
	    </div>
		<div class="meta">
<!--			<p class="links"><a href="#" class="comments">Comments (32)</a> &nbsp;&bull;&nbsp;&nbsp; <a href="#" class="more">Read full post &raquo;</a></p>-->
		</div>
	</div>
