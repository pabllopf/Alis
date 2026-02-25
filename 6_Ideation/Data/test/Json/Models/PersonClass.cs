// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: TestDataModels.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Test data models for JSON serialization testing.
    ///     Includes structs, classes, and various implementations.
    /// </summary>

    #region Simple Value Types

    /// <summary>
    ///     Simple person class for basic testing
    /// </summary>
    public class PersonClass : IJsonSerializable, IJsonDesSerializable<PersonClass>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            yield return (nameof(Age), Age.ToString());
            yield return (nameof(Email), Email);
        }

        public PersonClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var person = new PersonClass();
            if (properties.TryGetValue(nameof(Name), out var name))
                person.Name = name;
            if (properties.TryGetValue(nameof(Age), out var age) && int.TryParse(age, out var ageValue))
                person.Age = ageValue;
            if (properties.TryGetValue(nameof(Email), out var email))
                person.Email = email;
            return person;
        }
    }

    #endregion

    #region Numeric Types

    #endregion

    #region DateTime and Guid Types

    #endregion

    #region Enum Types

    #endregion

    #region Complex Nested Types

    #endregion

    #region Collection Types

    #endregion

    #region Point Types (Structs for coordinates)

    #endregion

    #region Product and Inventory Models

    #endregion

    #region Configuration Models

    #endregion

    #region Logging and Audit Models

    #endregion

    #region Minimal Types

    #endregion
}

