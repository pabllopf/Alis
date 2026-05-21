// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddressClass.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        ///     Gets or sets the value of the street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the value of the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the value of the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the value of the zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public AddressClass CreateFromProperties(Dictionary<string, string> properties)
        {
            AddressClass obj = new AddressClass();
            if (properties.TryGetValue(nameof(Street), out string v))
            {
                obj.Street = v;
            }

            if (properties.TryGetValue(nameof(City), out v))
            {
                obj.City = v;
            }

            if (properties.TryGetValue(nameof(Country), out v))
            {
                obj.Country = v;
            }

            if (properties.TryGetValue(nameof(ZipCode), out v))
            {
                obj.ZipCode = v;
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Street), Street);
            yield return (nameof(City), City);
            yield return (nameof(Country), Country);
            yield return (nameof(ZipCode), ZipCode);
        }
    }
}