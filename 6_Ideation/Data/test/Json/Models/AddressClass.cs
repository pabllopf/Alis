using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Address class for nested objects
    /// </summary>
    public class AddressClass : IJsonSerializable, IJsonDesSerializable<AddressClass>
    {
        /// <summary>
        /// Gets or sets the value of the street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the value of the city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the value of the country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the value of the zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Street), Street);
            yield return (nameof(City), City);
            yield return (nameof(Country), Country);
            yield return (nameof(ZipCode), ZipCode);
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public AddressClass CreateFromProperties(Dictionary<string, string> properties)
        {
            AddressClass obj = new AddressClass();
            if (properties.TryGetValue(nameof(Street), out string v)) obj.Street = v;
            if (properties.TryGetValue(nameof(City), out v)) obj.City = v;
            if (properties.TryGetValue(nameof(Country), out v)) obj.Country = v;
            if (properties.TryGetValue(nameof(ZipCode), out v)) obj.ZipCode = v;
            return obj;
        }
    }
}