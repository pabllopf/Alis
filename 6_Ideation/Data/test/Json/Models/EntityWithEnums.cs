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
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Status), Status.ToString());
            yield return (nameof(Priority), Priority.ToString());
        }

        public EntityWithEnums CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new EntityWithEnums();
            if (properties.TryGetValue(nameof(Name), out var name)) obj.Name = name;
            if (properties.TryGetValue(nameof(Status), out var status) && Enum.TryParse<StatusEnum>(status, out var statusVal)) obj.Status = statusVal;
            if (properties.TryGetValue(nameof(Priority), out var priority) && Enum.TryParse<PriorityEnum>(priority, out var priorityVal)) obj.Priority = priorityVal;
            return obj;
        }
    }
}