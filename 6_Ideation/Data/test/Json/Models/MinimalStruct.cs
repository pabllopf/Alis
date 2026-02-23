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
            var obj = new MinimalStruct();
            if (properties.TryGetValue(nameof(Value), out var v) && int.TryParse(v, out var val)) obj.Value = val;
            return obj;
        }
    }
}