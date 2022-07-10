// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CircleDef.cs
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

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This structure is used to build a fixture with a circle shape.
    /// </summary>
    public class CircleDef : FixtureDef
    {
        /// <summary>
        ///     The radius
        /// </summary>
        public readonly float Radius;

        /// <summary>
        ///     The local position
        /// </summary>
        public Vec2 LocalPosition;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleDef" /> class
        /// </summary>
        public CircleDef()
        {
            Type = ShapeType.CircleShape;
            LocalPosition = Vec2.Zero;
            Radius = 1.0f;
        }
    }
}