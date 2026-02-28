// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserWithAddress.cs
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
    ///     User class with nested address
    /// </summary>
    public class UserWithAddress : IJsonSerializable, IJsonDesSerializable<UserWithAddress>
    {
        /// <summary>
        ///     Gets or sets the value of the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the address
        /// </summary>
        public AddressClass Address { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public UserWithAddress CreateFromProperties(Dictionary<string, string> properties)
        {
            UserWithAddress obj = new UserWithAddress();
            if (properties.TryGetValue(nameof(Username), out string v))
            {
                obj.Username = v;
            }

            if (properties.TryGetValue(nameof(UserId), out v) && int.TryParse(v, out int val))
            {
                obj.UserId = val;
            }

            if (properties.TryGetValue(nameof(Address), out v) && !string.IsNullOrEmpty(v))
            {
                obj.Address = JsonNativeAot.Deserialize<AddressClass>(v);
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Username), Username);
            yield return (nameof(UserId), UserId.ToString());
            yield return (nameof(Address), Address != null ? JsonNativeAot.Serialize(Address) : null);
        }
    }
}