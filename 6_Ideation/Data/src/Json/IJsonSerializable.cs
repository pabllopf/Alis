using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    public interface IJsonSerializable
    {
        IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
    }
}