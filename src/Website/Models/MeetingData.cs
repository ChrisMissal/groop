using System;
using Castle.Components.Validator;

namespace Groop.Website.Models
{
    public class MeetingData
    {
        [ValidateInteger]
        public virtual int MeetingId { get; set; }

        [ValidateNonEmpty("A title is required.")]
        public virtual string Title { get; set; }

        [ValidateDateTime("A valid start date & time is required.")]
        public virtual DateTime StartTime { get; set; }

        [ValidateDateTime("A valid end date & time is required.")]
        public virtual DateTime EndTime { get; set; }

        [ValidateNonEmpty("A description is required.")]
        public virtual string Description { get; set; }

        [ValidateNonEmpty("Presenter name(s) required.")]
        public virtual string Presenter { get; set; }

        [ValidateInteger("A Facility ID is required.")]
        public virtual int FacilityId { get; set; }
    }
}