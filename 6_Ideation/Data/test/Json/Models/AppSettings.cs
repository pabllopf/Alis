using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Application settings class
    /// </summary>
    public class AppSettings : IJsonSerializable, IJsonDesSerializable<AppSettings>
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public int Port { get; set; }
        public bool EnableLogging { get; set; }
        public bool EnableDebug { get; set; }
        public string LogLevel { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(AppName), AppName);
            yield return (nameof(Version), Version);
            yield return (nameof(Port), Port.ToString());
            yield return (nameof(EnableLogging), EnableLogging.ToString());
            yield return (nameof(EnableDebug), EnableDebug.ToString());
            yield return (nameof(LogLevel), LogLevel);
        }

        public AppSettings CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new AppSettings();
            if (properties.TryGetValue(nameof(AppName), out var v)) obj.AppName = v;
            if (properties.TryGetValue(nameof(Version), out v)) obj.Version = v;
            if (properties.TryGetValue(nameof(Port), out v) && int.TryParse(v, out var val)) obj.Port = val;
            if (properties.TryGetValue(nameof(EnableLogging), out v) && bool.TryParse(v, out var val2)) obj.EnableLogging = val2;
            if (properties.TryGetValue(nameof(EnableDebug), out v) && bool.TryParse(v, out var val3)) obj.EnableDebug = val3;
            if (properties.TryGetValue(nameof(LogLevel), out v)) obj.LogLevel = v;
            return obj;
        }
    }
}