// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConfigStruct.cs
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
    ///     Struct with enum properties
    /// </summary>
    public struct ConfigStruct : IJsonSerializable, IJsonDesSerializable<ConfigStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the status
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        ///     Gets or sets the value of the priority
        /// </summary>
        public PriorityEnum Priority { get; set; }

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Status), Status.ToString());
            yield return (nameof(Priority), Priority.ToString());
            yield return (nameof(Value), Value.ToString());
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public ConfigStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            ConfigStruct obj = new ConfigStruct();
            if (properties.TryGetValue(nameof(Status), out string status) && Enum.TryParse(status, out StatusEnum statusVal))
            {
                obj.Status = statusVal;
            }

            if (properties.TryGetValue(nameof(Priority), out string priority) && Enum.TryParse(priority, out PriorityEnum priorityVal))
            {
                obj.Priority = priorityVal;
            }

            if (properties.TryGetValue(nameof(Value), out string value) && int.TryParse(value, out int intVal))
            {
                obj.Value = intVal;
            }

            return obj;
        }
    }
}