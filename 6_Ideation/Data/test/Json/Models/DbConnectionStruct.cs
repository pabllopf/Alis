using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Database connection struct
    /// </summary>
    public struct DbConnectionStruct : IJsonSerializable, IJsonDesSerializable<DbConnectionStruct>
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public int Timeout { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Host), Host);
            yield return (nameof(Port), Port.ToString());
            yield return (nameof(Database), Database);
            yield return (nameof(Timeout), Timeout.ToString());
        }

        public DbConnectionStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new DbConnectionStruct();
            if (properties.TryGetValue(nameof(Host), out var v)) obj.Host = v;
            if (properties.TryGetValue(nameof(Port), out v) && int.TryParse(v, out var val)) obj.Port = val;
            if (properties.TryGetValue(nameof(Database), out v)) obj.Database = v;
            if (properties.TryGetValue(nameof(Timeout), out v) && int.TryParse(v, out var val2)) obj.Timeout = val2;
            return obj;
        }
    }
}