// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ShapeDef.cs
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

using Alis.Core.Systems.Physics2D.Collision.Shapes;

namespace Alis.Core.Systems.Physics2D.Definitions.Shapes
{
    /// <summary>
    ///     The shape def class
    /// </summary>
    /// <seealso cref="IDef" />
    public abstract class ShapeDef : IDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ShapeDef" /> class
        /// </summary>
        /// <param name="type">The type</param>
        protected ShapeDef(ShapeType type)
        {
            ShapeType = type;
        }

        /// <summary>Gets or sets the density.</summary>
        public float Density { get; set; }

        /// <summary>Radius of the Shape</summary>
        public float Radius { get; set; }

        /// <summary>Get the type of this shape.</summary>
        public ShapeType ShapeType { get; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public virtual void SetDefaults()
        {
            Density = 0;
            Radius = 0;
        }
    }
}