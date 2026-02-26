using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Minimal struct with single property
    /// </summary>
    public struct MinimalStruct : IJsonSerializable, IJsonDesSerializable<MinimalStruct>
    {
        public int Value { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Value), Value.ToString());
        }

        public MinimalStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            MinimalStruct obj = new MinimalStruct();
            if (properties.TryGetValue(nameof(Value), out string v) && int.TryParse(v, out int val)) obj.Value = val;
            return obj;
        }
    }
}