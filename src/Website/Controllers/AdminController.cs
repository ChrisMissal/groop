using System.Collections.Generic;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Data;
using Groop.Core.Domain;
using Groop.Website.Models;

namespace Groop.Website.Controllers
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
            if (meetings == null || meetings.Count <= 0)
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

            ViewData.Model = meeting.ToMeetingData();

            AddFacilitiesToViewData("facilities");

            return View("EditMeeting");
        }

        /// <summary>
        /// Saves the meeting.
        /// </summary>
        /// <param name="meetingData">The meeting data.</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveMeeting(MeetingData meetingData)
        {
            var meeting = meetingRepository.GetById(meetingData.MeetingId) ?? new Meeting();
            meeting.Facility = facilityRepository.GetById(meetingData.FacilityId);

            if(meeting.Facility == null)
            {
                AddErrorMessage("You must pick a facility from the list. Try Again.");
                return RedirectToAction("ViewMeetings");
            }

            meeting.Title = meetingData.Title;
            meeting.Presenter = meetingData.Presenter;
            meeting.Description = meetingData.Description;
            meeting.StartTime = meetingData.StartTime;
            meeting.EndTime = meetingData.EndTime;

            meetingRepository.Add(meeting);

            AddInformationalMessage(string.Format("Meeting {0} successfully updated.", meetingData.MeetingId));

            return RedirectToAction("ViewMeetings");
        }

        /// <summary>
        /// Adds a meeting.
        /// </summary>
        /// <param name="meetingData">The meeting data.</param>
        /// <returns></returns>
        public ActionResult AddMeeting(MeetingData meetingData)
        {
            AddFacilitiesToViewData("facilities");
            return View("AddMeeting");
        }

        private void AddFacilitiesToViewData(string viewDataKey)
        {
            var facilities = facilityRepository.GetAll();
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Selected = true });
            foreach (var facility in facilities)
            {
                selectListItems.Add(new SelectListItem { Text = facility.Name, Value = facility.FacilityId.ToString() });
            }
            ViewData.Add(viewDataKey, selectListItems);
        }
    }
}