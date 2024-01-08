// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonAttribute.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Provides options for JSON.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class JsonAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonAttribute" /> class.
        /// </summary>
        public JsonAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonAttribute" /> class.
        /// </summary>
        /// <param name="name">The name to use for JSON serialization and deserialization.</param>
        public JsonAttribute(string name) => Name = name;

        /// <summary>
        ///     Gets or sets the name to use for JSON serialization and deserialization.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to ignore this instance's owner when serializing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance's owner must be ignored when serializing; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreWhenSerializing { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to ignore this instance's owner when deserializing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance's owner must be ignored when deserializing; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreWhenDeserializing { get; set; }

        /// <summary>
        ///     Gets or sets the default value.
        /// </summary>
        /// <value>
        ///     The default value.
        /// </value>
        public object DefaultValue { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has a default value. In this case, it's defined by the
        ///     DefaultValue property.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has default value; otherwise, <c>false</c>.
        /// </value>
        public bool HasDefaultValue { get; set; }
    }
}