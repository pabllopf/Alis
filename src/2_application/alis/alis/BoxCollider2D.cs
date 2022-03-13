// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BoxCollider2D.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.ComponentModel.Design.Serialization;
using System.Numerics;
using Alis.Builders;

namespace Alis
{
    /// <summary>
    /// The box collider class
    /// </summary>
    /// <seealso cref="Alis.Core.Components.BoxCollider2D"/>
    public class BoxCollider2D : Alis.Core.Components.BoxCollider2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxCollider2D"/> class
        /// </summary>
        public BoxCollider2D() : base()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxCollider2D"/> class
        /// </summary>
        /// <param name="autoTiling">The auto tiling</param>
        public BoxCollider2D(bool autoTiling) : base(autoTiling)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider2D" /> class
        /// </summary>
        /// <param name="autoTiling">The auto tiling</param>
        /// <param name="size">The size</param>
        /// <param name="relativePosition">The relative position</param>
        public BoxCollider2D(bool autoTiling, Vector2 size, Vector2 relativePosition): base(autoTiling, size, relativePosition)
        {
        }
        
        
        /// <summary>
        /// Builders
        /// </summary>
        /// <returns>The box collider builder</returns>
        public static BoxCollider2DBuilder Builder()
        {
            return new BoxCollider2DBuilder();
        }
    }
}