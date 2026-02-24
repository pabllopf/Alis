using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Application settings class
    /// </summary>
    public class AppSettings : IJsonSerializable, IJsonDesSerializable<AppSettings>
    {
        /// <summary>
        /// Gets or sets the value of the app name
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// Gets or sets the value of the version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the value of the enable logging
        /// </summary>
        public bool EnableLogging { get; set; }
        /// <summary>
        /// Gets or sets the value of the enable debug
        /// </summary>
        public bool EnableDebug { get; set; }
        /// <summary>
        /// Gets or sets the value of the log level
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(AppName), AppName);
            yield return (nameof(Version), Version);
            yield return (nameof(Port), Port.ToString());
            yield return (nameof(EnableLogging), EnableLogging.ToString());
            yield return (nameof(EnableDebug), EnableDebug.ToString());
            yield return (nameof(LogLevel), LogLevel);
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public AppSettings CreateFromProperties(Dictionary<string, string> properties)
        {
            AppSettings obj = new AppSettings();
            if (properties.TryGetValue(nameof(AppName), out string v)) obj.AppName = v;
            if (properties.TryGetValue(nameof(Version), out v)) obj.Version = v;
            if (properties.TryGetValue(nameof(Port), out v) && int.TryParse(v, out int val)) obj.Port = val;
            if (properties.TryGetValue(nameof(EnableLogging), out v) && bool.TryParse(v, out bool val2)) obj.EnableLogging = val2;
            if (properties.TryGetValue(nameof(EnableDebug), out v) && bool.TryParse(v, out bool val3)) obj.EnableDebug = val3;
            if (properties.TryGetValue(nameof(LogLevel), out v)) obj.LogLevel = v;
            return obj;
        }
    }
}