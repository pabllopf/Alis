using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Person as struct for value type testing
    /// </summary>
    public struct PersonStruct : IJsonSerializable, IJsonDesSerializable<PersonStruct>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Age), Age.ToString());
            yield return (nameof(IsActive), IsActive.ToString());
        }

        public PersonStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            var person = new PersonStruct();
            if (properties.TryGetValue(nameof(Name), out var name))
                person.Name = name;
            if (properties.TryGetValue(nameof(Age), out var age) && int.TryParse(age, out var ageValue))
                person.Age = ageValue;
            if (properties.TryGetValue(nameof(IsActive), out var active) && bool.TryParse(active, out var activeValue))
                person.IsActive = activeValue;
            return person;
        }
    }
}