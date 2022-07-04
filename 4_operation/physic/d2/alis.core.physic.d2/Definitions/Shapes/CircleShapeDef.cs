// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CircleShapeDef.cs
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

using System.Numerics;
using Alis.Core.Physic.D2.Collision.Shapes;

namespace Alis.Core.Physic.D2.Definitions.Shapes
{
    /// <summary>
    ///     The circle shape def class
    /// </summary>
    /// <seealso cref="ShapeDef" />
    public sealed class CircleShapeDef : ShapeDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShapeDef" /> class
        /// </summary>
        public CircleShapeDef() : base(ShapeType.Circle)
        {
            SetDefaults();
        }

        /// <summary>Get or set the position of the circle</summary>
        public Vector2 Position { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            Position = Vector2.Zero;
            base.SetDefaults();
        }
    }
}