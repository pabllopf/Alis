using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Minimal class with single property
    /// </summary>
    public class MinimalClass : IJsonSerializable, IJsonDesSerializable<MinimalClass>
    {
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Value), Value);
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public MinimalClass CreateFromProperties(Dictionary<string, string> properties)
        {
            MinimalClass obj = new MinimalClass();
            if (properties.TryGetValue(nameof(Value), out string v)) obj.Value = v;
            return obj;
        }
    }
}