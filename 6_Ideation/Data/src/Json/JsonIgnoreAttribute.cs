// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonIgnore.cs
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
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    /// The json ignore attribute class
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Class)]
    [ExcludeFromCodeCoverage]
    public class JsonIgnoreAttribute : Attribute
    {
        /// <summary>
        ///     Gets or sets a value indicating whether to ignore this instance's owner when serializing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance's owner must be ignored when serializing; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreWhenSerializing { get; } = true;
        
        /// <summary>
        ///     Gets or sets a value indicating whether to ignore this instance's owner when deserializing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance's owner must be ignored when deserializing; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreWhenDeserializing { get;  } = true;
    }
}