// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TemporalTypesClass.cs
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
    ///     Class with DateTime and Guid properties
    /// </summary>
    public class TemporalTypesClass : IJsonSerializable, IJsonDesSerializable<TemporalTypesClass>
    {
        /// <summary>
        ///     Gets or sets the value of the created at
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the updated at
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the value of the correlation id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TemporalTypesClass CreateFromProperties(Dictionary<string, string> properties)
        {
            TemporalTypesClass obj = new TemporalTypesClass();
            if (properties.TryGetValue(nameof(CreatedAt), out string v) && DateTime.TryParse(v, out DateTime val))
            {
                obj.CreatedAt = val;
            }

            if (properties.TryGetValue(nameof(UpdatedAt), out v) && DateTime.TryParse(v, out DateTime val2))
            {
                obj.UpdatedAt = val2;
            }

            if (properties.TryGetValue(nameof(Id), out v) && Guid.TryParse(v, out Guid val3))
            {
                obj.Id = val3;
            }

            if (properties.TryGetValue(nameof(CorrelationId), out v) && Guid.TryParse(v, out Guid val4))
            {
                obj.CorrelationId = val4;
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(CreatedAt), CreatedAt.ToString("O"));
            yield return (nameof(UpdatedAt), UpdatedAt.ToString("O"));
            yield return (nameof(Id), Id.ToString());
            yield return (nameof(CorrelationId), CorrelationId.ToString());
        }
    }
}