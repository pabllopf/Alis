// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EdgeShapeDef.cs
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

using Alis.Core.Physic.D2.Collision.Shapes;

namespace Alis.Core.Physic.D2.Definitions.Shapes
{
    /// <summary>
    ///     A line segment (edge) shape. These can be connected in chains or loops to other edge shapes. The connectivity
    ///     information is used to ensure correct contact normals.
    /// </summary>
    public sealed class EdgeShapeDef : ShapeDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShapeDef" /> class
        /// </summary>
        public EdgeShapeDef() : base(ShapeType.Edge)
        {
            SetDefaults();
        }

        /// <summary>Is true if the edge is connected to an adjacent vertex before vertex 1.</summary>
        public bool HasVertex0 { get; set; }

        /// <summary>Is true if the edge is connected to an adjacent vertex after vertex2.</summary>
        public bool HasVertex3 { get; set; }

        /// <summary>Optional adjacent vertices. These are used for smooth collision.</summary>
        public Vector2 Vertex0 { get; set; }

        /// <summary>These are the edge vertices</summary>
        public Vector2 Vertex1 { get; set; }

        /// <summary>These are the edge vertices</summary>
        public Vector2 Vertex2 { get; set; }

        /// <summary>Optional adjacent vertices. These are used for smooth collision.</summary>
        public Vector2 Vertex3 { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            HasVertex0 = false;
            HasVertex3 = false;
            Vertex0 = Vector2.Zero;
            Vertex1 = Vector2.Zero;
            Vertex2 = Vector2.Zero;
            Vertex3 = Vector2.Zero;

            base.SetDefaults();
        }
    }
}