using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Minimal class with single property
    /// </summary>
    public class MinimalClass : IJsonSerializable, IJsonDesSerializable<MinimalClass>
    {
        public string Value { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Value), Value);
        }

        public MinimalClass CreateFromProperties(Dictionary<string, string> properties)
        {
            MinimalClass obj = new MinimalClass();
            if (properties.TryGetValue(nameof(Value), out string v)) obj.Value = v;
            return obj;
        }
    }
}