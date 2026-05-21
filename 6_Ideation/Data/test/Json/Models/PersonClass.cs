

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Test data models for JSON serialization testing.
    ///     Includes structs, classes, and various implementations.
    /// </summary>
    /// <summary>
    ///     Simple person class for basic testing
    /// </summary>
    public class PersonClass : IJsonSerializable, IJsonDesSerializable<PersonClass>
    {
        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///     Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The person</returns>
        public PersonClass CreateFromProperties(Dictionary<string, string> properties)
        {
            PersonClass person = new PersonClass();
            if (properties.TryGetValue(nameof(Name), out string name))
            {
                person.Name = name;
            }

            if (properties.TryGetValue(nameof(Age), out string age) && int.TryParse(age, out int ageValue))
            {
                person.Age = ageValue;
            }

            if (properties.TryGetValue(nameof(Email), out string email))
            {
                person.Email = email;
            }

            return person;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Age), Age.ToString());
            yield return (nameof(Email), Email);
        }
    }
}