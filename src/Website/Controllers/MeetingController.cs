﻿using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Data;
using Groop.Core.Services;
using Groop.Website.Models;

namespace Groop.Website.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService meetingService;

        public MeetingController(IUserSession userSession, IMeetingService meetingService) : base(userSession)
        {
            this.meetingService = meetingService;
        }

        public ActionResult Show()
        {
            var nextMeeting = meetingService.GetNextMeeting(DateTime.Now);
            return View("Show", nextMeeting);
        }

        public ViewResult Detail(int id)
        {
            var meeting = meetingService.GetById(id);
            return View(meeting);
        }

        public ViewResult Archive()
        {
            var pastMeetings = meetingService.GetPastMeetings(DateTime.Now);
            return View(pastMeetings);
        }

        [Authorize(Roles = "Users")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RSVP()
        {
            var nextMeeting = meetingService.GetNextMeeting(DateTime.Now);
            if (nextMeeting == null)
                return new EmptyResult();

            var email = userSession.GetLoggedInUser().Email;
            var hasRsvpd = nextMeeting.ContainsAttendee(email);
            var model = new RsvpData(hasRsvpd, nextMeeting.MeetingId);
            return View("RSVP", model);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult RSVP(int id)
        //{
        //    var meeting = meetingRepository.GetById(id);
        //    if (meeting == null)
        //        return RedirectToAction("Index");

        //    var user = userSession.GetLoggedInUser();
        //    meeting.AddAttendee(user);
        //    meetingRepository.Update(meeting);

        //    ViewData.Model = meeting;
        //    return View("Show");
        //}

        public ActionResult UpcomingMeetings()
        {
            var upcomingMeetings = meetingService.GetUpcomingMeetings(DateTime.Now, 2);
            return View(upcomingMeetings);
        }

        public ActionResult UnscheduledTopics()
        {
            return View();
        }
    }
}

