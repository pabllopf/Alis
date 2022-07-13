// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonDef.cs
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
    ///     Convex polygon. The vertices must be ordered so that the outside of
    ///     the polygon is on the right side of the edges (looking along the edge
    ///     from start to end).
    /// </summary>
    public class PolygonDef : FixtureDef
    {
        /// <summary>
        ///     The polygon vertices in local coordinates.
        /// </summary>
        public readonly Vector2[] Vertices = new Vector2[Settings.MaxPolygonVertices];

        /// <summary>
        ///     The number of polygon vertices.
        /// </summary>
        public int VertexCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonDef" /> class
        /// </summary>
        public PolygonDef()
        {
            Type = ShapeType.PolygonShape;
            VertexCount = 0;
        }

        /// <summary>
        ///     Build vertices to represent an axis-aligned box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        public void SetAsBox(float hx, float hy)
        {
            VertexCount = 4;
            Vertices[0].Set(-hx, -hy);
            Vertices[1].Set(hx, -hy);
            Vertices[2].Set(hx, hy);
            Vertices[3].Set(-hx, hy);
        }


        /// <summary>
        ///     Build vertices to represent an oriented box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        /// <param name="center">The center of the box in local coordinates.</param>
        /// <param name="angle">The rotation of the box in local coordinates.</param>
        public void SetAsBox(float hx, float hy, Vector2 center, float angle)
        {
            SetAsBox(hx, hy);

            XForm xf = new XForm();
            xf.Position = center;
            xf.R.Set(angle);

            for (int i = 0; i < VertexCount; ++i)
            {
                Vertices[i] = Math.Mul(xf, Vertices[i]);
            }
        }
    }
}