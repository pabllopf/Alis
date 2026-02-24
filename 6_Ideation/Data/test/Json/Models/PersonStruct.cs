using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Person as struct for value type testing
    /// </summary>
    public struct PersonStruct : IJsonSerializable, IJsonDesSerializable<PersonStruct>
    {
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Age), Age.ToString());
            yield return (nameof(IsActive), IsActive.ToString());
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The person</returns>
        public PersonStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            PersonStruct person = new PersonStruct();
            if (properties.TryGetValue(nameof(Name), out string name))
                person.Name = name;
            if (properties.TryGetValue(nameof(Age), out string age) && int.TryParse(age, out int ageValue))
                person.Age = ageValue;
            if (properties.TryGetValue(nameof(IsActive), out string active) && bool.TryParse(active, out bool activeValue))
                person.IsActive = activeValue;
            return person;
        }
    }
}