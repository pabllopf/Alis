// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestClass.cs
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

using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Sample
{
    /// <summary>
    ///     The test class
    /// </summary>
    public class TestClass
    {
        /// <summary>
        ///     Gets or sets the value of the property with ignore when serializing
        /// </summary>
        [JsonPropertyName("test")]
        public string PropertyWithIgnoreWhenSerializing { get; set; }

        /// <summary>
        ///     Gets or sets the value of the property with ignore when deserializing
        /// </summary>
        [JsonPropertyName("test")]
        public string PropertyWithIgnoreWhenDeserializing { get; set; }

        /// <summary>
        ///     Gets or sets the value of the property without ignore when serializing
        /// </summary>
        [JsonPropertyName("test")]
        public string PropertyWithoutIgnoreWhenSerializing { get; set; }

        /// <summary>
        ///     Gets or sets the value of the property without ignore when deserializing
        /// </summary>
        [JsonPropertyName("test")]
        public string PropertyWithoutIgnoreWhenDeserializing { get; set; }
    }
}