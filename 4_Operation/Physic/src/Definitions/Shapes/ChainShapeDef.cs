// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainShapeDef.cs
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

using System.Numerics;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Definitions.Shapes
{
    /// <summary>
    ///     A chain shape is a free form sequence of line segments. The chain has two-sided collision, so you can use
    ///     inside and outside collision. Therefore, you may use any winding order. Connectivity information is used to create
    ///     smooth collisions.
    ///     <remarks>WARNING: The chain will not collide properly if there are self-intersections.</remarks>
    /// </summary>
    public sealed class ChainShapeDef : ShapeDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChainShapeDef" /> class
        /// </summary>
        public ChainShapeDef() : base(ShapeType.Chain)
        {
            SetDefaults();
        }

        /// <summary>
        ///     Establish connectivity to a vertex that follows the last vertex.
        ///     <remarks>Don't call this for loops.</remarks>
        /// </summary>
        public Vector2 NextVertex { get; set; }

        /// <summary>
        ///     Establish connectivity to a vertex that precedes the first vertex.
        ///     <remarks>Don't call this for loops.</remarks>
        /// </summary>
        public Vector2 PrevVertex { get; set; }

        /// <summary>The vertices. These are not owned/freed by the chain Shape.</summary>
        public Vertices Vertices { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            NextVertex = Vector2.Zero;
            PrevVertex = Vector2.Zero;
            Vertices = null;

            base.SetDefaults();
        }
    }
}