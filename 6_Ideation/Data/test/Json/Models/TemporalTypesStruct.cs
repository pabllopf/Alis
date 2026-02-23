using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Temporal types as struct
    /// </summary>
    public struct TemporalTypesStruct : IJsonSerializable, IJsonDesSerializable<TemporalTypesStruct>
    {
        public DateTime Timestamp { get; set; }
        public Guid Identifier { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString("O"));
            yield return (nameof(Identifier), Identifier.ToString());
        }

        public TemporalTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new TemporalTypesStruct();
            if (properties.TryGetValue(nameof(Timestamp), out var v) && DateTime.TryParse(v, out var val)) obj.Timestamp = val;
            if (properties.TryGetValue(nameof(Identifier), out v) && Guid.TryParse(v, out var val2)) obj.Identifier = val2;
            return obj;
        }
    }
}