using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     User class with nested address
    /// </summary>
    public class UserWithAddress : IJsonSerializable, IJsonDesSerializable<UserWithAddress>
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public AddressClass Address { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Username), Username);
            yield return (nameof(UserId), UserId.ToString());
            yield return (nameof(Address), Address != null ? JsonNativeAot.Serialize(Address) : null);
        }

        public UserWithAddress CreateFromProperties(Dictionary<string, string> properties)
        {
            UserWithAddress obj = new UserWithAddress();
            if (properties.TryGetValue(nameof(Username), out string v)) obj.Username = v;
            if (properties.TryGetValue(nameof(UserId), out v) && int.TryParse(v, out int val)) obj.UserId = val;
            if (properties.TryGetValue(nameof(Address), out v) && !string.IsNullOrEmpty(v))
                obj.Address = JsonNativeAot.Deserialize<AddressClass>(v);
            return obj;
        }
    }
}