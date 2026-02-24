using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with enum properties
    /// </summary>
    public class EntityWithEnums : IJsonSerializable, IJsonDesSerializable<EntityWithEnums>
    {
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Gets or sets the value of the priority
        /// </summary>
        public PriorityEnum Priority { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Status), Status.ToString());
            yield return (nameof(Priority), Priority.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public EntityWithEnums CreateFromProperties(Dictionary<string, string> properties)
        {
            EntityWithEnums obj = new EntityWithEnums();
            if (properties.TryGetValue(nameof(Name), out string name)) obj.Name = name;
            if (properties.TryGetValue(nameof(Status), out string status) && Enum.TryParse<StatusEnum>(status, out StatusEnum statusVal)) obj.Status = statusVal;
            if (properties.TryGetValue(nameof(Priority), out string priority) && Enum.TryParse<PriorityEnum>(priority, out PriorityEnum priorityVal)) obj.Priority = priorityVal;
            return obj;
        }
    }
}