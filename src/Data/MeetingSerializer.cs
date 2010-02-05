using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Groop.Core.Domain;

namespace Groop.Data
{
    public abstract class TypeSerializer : XmlSerializer
    {
        private readonly Type type;

        protected TypeSerializer(Type type, Type[] extraTypes) : base(type, extraTypes)
        {
            this.type = type;
        }

        public virtual Type Type { get { return type; } }
    }

    public abstract class TypeSerializer<T> : TypeSerializer
    {
        protected TypeSerializer(Type[] extraTypes) : base(typeof(T), extraTypes)
        {
        }
    }

    public class MeetingSerializer : TypeSerializer<Meeting>
    {
        public MeetingSerializer() : base(new[] { typeof(List<Attendee>), typeof(Attendee), typeof(MemberAttendee), typeof(GuestAttendee) })
        {
        }
    }

    public class SponsorSerializer : TypeSerializer<Sponsor>
    {
        public SponsorSerializer() : base(new Type[]{})
        {
        }
    }

    public class MemberSerializer : TypeSerializer<Member>
    {
        public MemberSerializer() : base(new Type[]{})
        {
        }
    }

    public class FacilitySerializer : TypeSerializer<Facility>
    {
        public FacilitySerializer() : base(new Type[]{})
        {
        }
    }
}