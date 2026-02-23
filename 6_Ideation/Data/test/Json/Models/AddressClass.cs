using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Address class for nested objects
    /// </summary>
    public class AddressClass : IJsonSerializable, IJsonDesSerializable<AddressClass>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Street), Street);
            yield return (nameof(City), City);
            yield return (nameof(Country), Country);
            yield return (nameof(ZipCode), ZipCode);
        }

        public AddressClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new AddressClass();
            if (properties.TryGetValue(nameof(Street), out var v)) obj.Street = v;
            if (properties.TryGetValue(nameof(City), out v)) obj.City = v;
            if (properties.TryGetValue(nameof(Country), out v)) obj.Country = v;
            if (properties.TryGetValue(nameof(ZipCode), out v)) obj.ZipCode = v;
            return obj;
        }
    }
}