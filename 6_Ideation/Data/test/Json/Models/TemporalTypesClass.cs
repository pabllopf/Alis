using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with DateTime and Guid properties
    /// </summary>
    public class TemporalTypesClass : IJsonSerializable, IJsonDesSerializable<TemporalTypesClass>
    {
        /// <summary>
        /// Gets or sets the value of the created at
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the value of the updated at
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the correlation id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(CreatedAt), CreatedAt.ToString("O"));
            yield return (nameof(UpdatedAt), UpdatedAt.ToString("O"));
            yield return (nameof(Id), Id.ToString());
            yield return (nameof(CorrelationId), CorrelationId.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TemporalTypesClass CreateFromProperties(Dictionary<string, string> properties)
        {
            TemporalTypesClass obj = new TemporalTypesClass();
            if (properties.TryGetValue(nameof(CreatedAt), out string v) && DateTime.TryParse(v, out DateTime val)) obj.CreatedAt = val;
            if (properties.TryGetValue(nameof(UpdatedAt), out v) && DateTime.TryParse(v, out DateTime val2)) obj.UpdatedAt = val2;
            if (properties.TryGetValue(nameof(Id), out v) && Guid.TryParse(v, out Guid val3)) obj.Id = val3;
            if (properties.TryGetValue(nameof(CorrelationId), out v) && Guid.TryParse(v, out Guid val4)) obj.CorrelationId = val4;
            return obj;
        }
    }
}