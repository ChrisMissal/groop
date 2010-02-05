using System.Collections.Generic;

namespace Groop.Data
{
    public class SerializationProvider : ISerializationProvider
    {
        private readonly TypeSerializer[] serializers = new TypeSerializer[]
                                                            {
                                                                new MeetingSerializer(), 
                                                                new SponsorSerializer(), 
                                                                new MemberSerializer(), 
                                                                new FacilitySerializer()
                                                            };

        public IEnumerable<TypeSerializer> XmlSerializers
        {
            get { return serializers; }
        }
    }
}