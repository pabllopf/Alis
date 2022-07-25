// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EdgeDef.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This structure is used to build a chain of edges.
    /// </summary>
    public class EdgeDef : FixtureDef
    {
        /// <summary>
        ///     The start vertex.
        /// </summary>
        public Vector2 Vertex1;

        /// <summary>
        ///     The end vertex.
        /// </summary>
        public Vector2 Vertex2;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeDef" /> class
        /// </summary>
        public EdgeDef()
        {
            Type = ShapeType.EdgeShape;
        }
    }
}