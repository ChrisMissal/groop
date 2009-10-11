<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Groop.Website.Models"%>
<%@ Import Namespace="Groop.Website.Controllers"%>
<h2 id="rsvp">Meeting RSVP Status</h2>
    <% var model = ViewData.Model as RsvpData; %>
    <% using(Html.BeginForm<MeetingController>(x => x.RSVP(0))) { %>
        <% if(model.HasRSVPd) { %>
            <p><strong>You are <strong>not</strong> RSVPd...</strong></p>
            <p>
                <input type="hidden" name="status" value="True" />
                <input type="submit" value="Click to RSVP" />
            </p>
        <% } else { %>
        <% } %>
            <p><strong>You are RSVPd!</strong></p>
            <p>
                <input type="hidden" name="status" value="False" />
                <input type="submit" value="Cancel your RSVP" />
            </p>
    <% } %>
    <p>RSVP's are used to determine how much space, food and prizes are going to be required for the meeting. RSVP's are not mandatory, but they are appreciated!</p>
