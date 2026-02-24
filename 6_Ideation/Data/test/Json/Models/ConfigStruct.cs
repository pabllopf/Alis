using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Struct with enum properties
    /// </summary>
    public struct ConfigStruct : IJsonSerializable, IJsonDesSerializable<ConfigStruct>
    {
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public int Value { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Status), Status.ToString());
            yield return (nameof(Priority), Priority.ToString());
            yield return (nameof(Value), Value.ToString());
        }

        public ConfigStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            ConfigStruct obj = new ConfigStruct();
            if (properties.TryGetValue(nameof(Status), out string status) && Enum.TryParse<StatusEnum>(status, out StatusEnum statusVal)) obj.Status = statusVal;
            if (properties.TryGetValue(nameof(Priority), out string priority) && Enum.TryParse<PriorityEnum>(priority, out PriorityEnum priorityVal)) obj.Priority = priorityVal;
            if (properties.TryGetValue(nameof(Value), out string value) && int.TryParse(value, out int intVal)) obj.Value = intVal;
            return obj;
        }
    }
}