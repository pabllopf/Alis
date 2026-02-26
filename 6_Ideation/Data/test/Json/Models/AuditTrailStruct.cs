using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Audit trail struct
    /// </summary>
    public struct AuditTrailStruct : IJsonSerializable, IJsonDesSerializable<AuditTrailStruct>
    {
        /// <summary>
        /// Gets or sets the value of the action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the value of the user
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Gets or sets the value of the when
        /// </summary>
        public DateTime When { get; set; }
        /// <summary>
        /// Gets or sets the value of the success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Action), Action);
            yield return (nameof(User), User);
            yield return (nameof(When), When.ToString("O"));
            yield return (nameof(Success), Success.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public AuditTrailStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            AuditTrailStruct obj = new AuditTrailStruct();
            if (properties.TryGetValue(nameof(Action), out string v)) obj.Action = v;
            if (properties.TryGetValue(nameof(User), out v)) obj.User = v;
            if (properties.TryGetValue(nameof(When), out v) && DateTime.TryParse(v, out DateTime val)) obj.When = val;
            if (properties.TryGetValue(nameof(Success), out v) && bool.TryParse(v, out bool val2)) obj.Success = val2;
            return obj;
        }
    }
}