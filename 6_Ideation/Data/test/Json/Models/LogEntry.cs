// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogEntry.cs
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
    ///     Log entry class
    /// </summary>
    public class LogEntry : IJsonSerializable, IJsonDesSerializable<LogEntry>
    {
        /// <summary>
        ///     Gets or sets the value of the log id
        /// </summary>
        public Guid LogId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Gets or sets the value of the level
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        ///     Gets or sets the value of the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the value of the source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public LogEntry CreateFromProperties(Dictionary<string, string> properties)
        {
            LogEntry obj = new LogEntry();
            if (properties.TryGetValue(nameof(LogId), out string v) && Guid.TryParse(v, out Guid val))
            {
                obj.LogId = val;
            }

            if (properties.TryGetValue(nameof(Timestamp), out v) && DateTime.TryParse(v, out DateTime val2))
            {
                obj.Timestamp = val2;
            }

            if (properties.TryGetValue(nameof(Level), out v))
            {
                obj.Level = v;
            }

            if (properties.TryGetValue(nameof(Message), out v))
            {
                obj.Message = v;
            }

            if (properties.TryGetValue(nameof(Source), out v))
            {
                obj.Source = v;
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(LogId), LogId.ToString());
            yield return (nameof(Timestamp), Timestamp.ToString("O"));
            yield return (nameof(Level), Level);
            yield return (nameof(Message), Message);
            yield return (nameof(Source), Source);
        }
    }
}