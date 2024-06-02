// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Depth.cs
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
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Definition
{
    /// <summary>
    ///     The depth
    /// </summary>
    [Serializable]
    public struct Depth : ISerializable
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Depth" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public Depth(int value) => Value = value;
        
        /// <summary>
        /// Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        [ExcludeFromCodeCoverage]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", Value);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Depth"/> class
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        [ExcludeFromCodeCoverage]
        public Depth(SerializationInfo info, StreamingContext context)
        {
            Value = info.GetInt32("Value");
        }
    }
}