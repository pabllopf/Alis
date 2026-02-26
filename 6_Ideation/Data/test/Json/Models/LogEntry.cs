using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Log entry class
    /// </summary>
    public class LogEntry : IJsonSerializable, IJsonDesSerializable<LogEntry>
    {
        public Guid LogId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(LogId), LogId.ToString());
            yield return (nameof(Timestamp), Timestamp.ToString("O"));
            yield return (nameof(Level), Level);
            yield return (nameof(Message), Message);
            yield return (nameof(Source), Source);
        }

        public LogEntry CreateFromProperties(Dictionary<string, string> properties)
        {
            LogEntry obj = new LogEntry();
            if (properties.TryGetValue(nameof(LogId), out string v) && Guid.TryParse(v, out Guid val)) obj.LogId = val;
            if (properties.TryGetValue(nameof(Timestamp), out v) && DateTime.TryParse(v, out DateTime val2)) obj.Timestamp = val2;
            if (properties.TryGetValue(nameof(Level), out v)) obj.Level = v;
            if (properties.TryGetValue(nameof(Message), out v)) obj.Message = v;
            if (properties.TryGetValue(nameof(Source), out v)) obj.Source = v;
            return obj;
        }
    }
}