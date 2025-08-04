using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    public interface IJsonDesSerializable<out T>
    {
        T CreateFromProperties(Dictionary<string, string> properties);
    }
}