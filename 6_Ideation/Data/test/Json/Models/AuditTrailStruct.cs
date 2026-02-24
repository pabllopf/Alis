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
        public string Action { get; set; }
        public string User { get; set; }
        public DateTime When { get; set; }
        public bool Success { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Action), Action);
            yield return (nameof(User), User);
            yield return (nameof(When), When.ToString("O"));
            yield return (nameof(Success), Success.ToString());
        }

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