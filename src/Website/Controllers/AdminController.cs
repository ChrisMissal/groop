using System.Collections.Generic;
using System.Web.Mvc;
using Castle.MicroKernel;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Website.Models;

namespace CRIneta.Website.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private readonly IMeetingRepository meetingRepository;
        private readonly IFacilityRepository facilityRepository;

        public AdminController(IUserSession userSession, IMeetingRepository meetingRepository, IFacilityRepository facilityRepository) : base (userSession)
        {
            this.meetingRepository = meetingRepository;
            this.facilityRepository = facilityRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Views all the meetings.
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewMeetings()
        {
            var meetings = meetingRepository.GetAllMeetings();
            if (meetings == null)
            {
                AddErrorMessage("No meetings found.");
                return View("Index");
            }
            ViewData.Model = meetings;
            return View("ViewMeetings");
        }

        /// <summary>
        /// Edits the meeting.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult EditMeeting(int id)
        {
            var meeting = meetingRepository.GetById(id);
            if(meeting == null)
            {
                AddErrorMessage("Meeting not found.");
                return View("ViewMeetings");
            }

            ViewData.Model = meeting;

            var facilities = facilityRepository.GetFacilities();
            ViewData.Add("facilities", facilities);

            return View("EditMeeting");
        }

        /// <summary>
        /// Saves the meeting.
        /// </summary>
        /// <param name="meetingData">The meeting data.</param>
        /// <returns></returns>
        public ActionResult SaveMeeting([Bind(Prefix = "")] MeetingData meetingData)
        {
            var meeting = meetingRepository.GetById(meetingData.MeetingId) ?? new Meeting();

            meeting.Title = meetingData.Title;
            meeting.Presenter = meetingData.Presenter;
            meeting.Description = meetingData.Description;
            meeting.StartTime = meetingData.StartTime;
            meeting.EndTime = meetingData.EndTime;
            meeting.Facility = facilityRepository.GetById(meetingData.FacilityId);

            meetingRepository.SaveOrUpdateMeeting(meeting);

            AddInformationalMessage(string.Format("Meeting {0} successfully updated.", meetingData.MeetingId));
            return View("ViewMeetings");
        }

        /// <summary>
        /// Adds a meeting.
        /// </summary>
        /// <param name="meetingData">The meeting data.</param>
        /// <returns></returns>
        public ActionResult AddMeeting([Bind(Prefix = "")] MeetingData meetingData)
        {
            return RedirectToAction("ViewMeetings");
        }
    }
}