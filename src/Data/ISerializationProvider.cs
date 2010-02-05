using System.Collections.Generic;

namespace Groop.Data
{
    public interface ISerializationProvider
    {
        IEnumerable<TypeSerializer> XmlSerializers { get; }
    }
}