// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TemporalTypesStruct.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Temporal types as struct
    /// </summary>
    public struct TemporalTypesStruct : IJsonSerializable, IJsonDesSerializable<TemporalTypesStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Gets or sets the value of the identifier
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString("O"));
            yield return (nameof(Identifier), Identifier.ToString());
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TemporalTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            TemporalTypesStruct obj = new TemporalTypesStruct();
            if (properties.TryGetValue(nameof(Timestamp), out string v) && DateTime.TryParse(v, out DateTime val))
            {
                obj.Timestamp = val;
            }

            if (properties.TryGetValue(nameof(Identifier), out v) && Guid.TryParse(v, out Guid val2))
            {
                obj.Identifier = val2;
            }

            return obj;
        }
    }
}