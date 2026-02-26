using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Minimal struct with single property
    /// </summary>
    public struct MinimalStruct : IJsonSerializable, IJsonDesSerializable<MinimalStruct>
    {
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Value), Value.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public MinimalStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            MinimalStruct obj = new MinimalStruct();
            if (properties.TryGetValue(nameof(Value), out string v) && int.TryParse(v, out int val)) obj.Value = val;
            return obj;
        }
    }
}