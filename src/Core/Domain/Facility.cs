namespace Groop.Core.Domain
{
    public class Facility
    {
        public virtual int FacilityId { get; set; }
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string Description { get; set; }
    }
}