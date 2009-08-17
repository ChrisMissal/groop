using CRIneta.Web.Core.Domain;

namespace CRIneta.Website.Models
{
    public static class ModelExtensions
    {
        public static MeetingData ToMeetingData(this Meeting @this)
        {
            return new MeetingData
                   {
                           Description = @this.Description,
                           EndTime = @this.EndTime,
                           FacilityId = (@this.Facility != null) ? @this.Facility.FacilityId : 0,
                           MeetingId = @this.MeetingId,
                           Presenter = @this.Presenter,
                           StartTime = @this.StartTime,
                           Title = @this.Title
                   };
        }
    }
}