// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AuditTrailStruct.cs
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
    ///     Audit trail struct
    /// </summary>
    public struct AuditTrailStruct : IJsonSerializable, IJsonDesSerializable<AuditTrailStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        ///     Gets or sets the value of the user
        /// </summary>
        public string User { get; set; }

        /// <summary>
        ///     Gets or sets the value of the when
        /// </summary>
        public DateTime When { get; set; }

        /// <summary>
        ///     Gets or sets the value of the success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Action), Action);
            yield return (nameof(User), User);
            yield return (nameof(When), When.ToString("O"));
            yield return (nameof(Success), Success.ToString());
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public AuditTrailStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            AuditTrailStruct obj = new AuditTrailStruct();
            if (properties.TryGetValue(nameof(Action), out string v))
            {
                obj.Action = v;
            }

            if (properties.TryGetValue(nameof(User), out v))
            {
                obj.User = v;
            }

            if (properties.TryGetValue(nameof(When), out v) && DateTime.TryParse(v, out DateTime val))
            {
                obj.When = val;
            }

            if (properties.TryGetValue(nameof(Success), out v) && bool.TryParse(v, out bool val2))
            {
                obj.Success = val2;
            }

            return obj;
        }
    }
}