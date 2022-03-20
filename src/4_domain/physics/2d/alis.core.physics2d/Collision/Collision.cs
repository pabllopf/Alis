// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.cs
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

namespace Alis.Core.Physics2D.Collision
{
    // Structures and functions used for computing contact points, distance
    // queries, and TOI queries.

    /// <summary>
    /// The collision class
    /// </summary>
    public class Collision
    {
        /// <summary>
        /// Describes whether test overlap
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool TestOverlap(in AABB a, in AABB b)
        {
            Vector2 d1, d2;
            d1 = b.lowerBound - a.upperBound;
            d2 = a.lowerBound - b.upperBound;

            if (d1.X > 0.0f || d1.Y > 0.0f)
            {
                return false;
            }

            if (d2.X > 0.0f || d2.Y > 0.0f)
            {
                return false;
            }

            return true;
        }

        // Sutherland-Hodgman clipping.
        /// <summary>
        /// Clips the segment to line using the specified v out
        /// </summary>
        /// <param name="vOut">The out</param>
        /// <param name="vIn">The in</param>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="vertexIndexA">The vertex index</param>
        /// <returns>The num out</returns>
        internal static int ClipSegmentToLine(
            out ClipVertex[ /*2*/] vOut,
            in ClipVertex[ /*2*/] vIn,
            in Vector2 normal,
            float offset,
            int vertexIndexA)
        {
            vOut = new ClipVertex[2];

            // Start with no output points
            int numOut = 0;

            // Calculate the distance of end points to the line
            float distance0 = Vector2.Dot(normal, vIn[0].v) - offset;
            float distance1 = Vector2.Dot(normal, vIn[1].v) - offset;

            // If the points are behind the plane
            if (distance0 <= 0.0f)
            {
                vOut[numOut++] = vIn[0];
            }

            if (distance1 <= 0.0f)
            {
                vOut[numOut++] = vIn[1];
            }

            // If the points are on different sides of the plane
            if (distance0 * distance1 < 0.0f)
            {
                // Find intersection point of edge and plane
                float interp = distance0 / (distance0 - distance1);
                vOut[numOut].v = vIn[0].v + interp * (vIn[1].v - vIn[0].v);

                // VertexA is hitting edgeB.
                vOut[numOut].id.cf.indexA = (byte) vertexIndexA;
                vOut[numOut].id.cf.indexB = vIn[0].id.cf.indexB;
                vOut[numOut].id.cf.typeA = (byte) ContactFeatureType.Vertex;
                vOut[numOut].id.cf.typeB = (byte) ContactFeatureType.Face;
                ++numOut;
            }

            return numOut;
        }
    }
}