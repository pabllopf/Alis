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
        /// <summary>
        /// Gets or sets the value of the timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the value of the identifier
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString("O"));
            yield return (nameof(Identifier), Identifier.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TemporalTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            TemporalTypesStruct obj = new TemporalTypesStruct();
            if (properties.TryGetValue(nameof(Timestamp), out string v) && DateTime.TryParse(v, out DateTime val)) obj.Timestamp = val;
            if (properties.TryGetValue(nameof(Identifier), out v) && Guid.TryParse(v, out Guid val2)) obj.Identifier = val2;
            return obj;
        }
    }
}