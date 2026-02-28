// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DbConnectionStruct.cs
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
    ///     Database connection struct
    /// </summary>
    public struct DbConnectionStruct : IJsonSerializable, IJsonDesSerializable<DbConnectionStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///     Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        ///     Gets or sets the value of the database
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        ///     Gets or sets the value of the timeout
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Host), Host);
            yield return (nameof(Port), Port.ToString());
            yield return (nameof(Database), Database);
            yield return (nameof(Timeout), Timeout.ToString());
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public DbConnectionStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            DbConnectionStruct obj = new DbConnectionStruct();
            if (properties.TryGetValue(nameof(Host), out string v))
            {
                obj.Host = v;
            }

            if (properties.TryGetValue(nameof(Port), out v) && int.TryParse(v, out int val))
            {
                obj.Port = val;
            }

            if (properties.TryGetValue(nameof(Database), out v))
            {
                obj.Database = v;
            }

            if (properties.TryGetValue(nameof(Timeout), out v) && int.TryParse(v, out int val2))
            {
                obj.Timeout = val2;
            }

            return obj;
        }
    }
}