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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collision
{
    // Structures and functions used for computing contact points, distance
    // queries, and TOI queries.

    /// <summary>
    ///     The collision class
    /// </summary>
    public static partial class Collision
    {
        /// <summary>
        ///     The uchar max
        /// </summary>
        public static readonly byte NullFeature = Math.UcharMax;

        /// <summary>
        ///     Describes whether test overlap
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool TestOverlap(Aabb a, Aabb b)
        {
            Vector2 d1, d2;
            d1 = b.LowerBound - a.UpperBound;
            d2 = a.LowerBound - b.UpperBound;

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

        /// <summary>
        ///     Compute the point states given two manifolds. The states pertain to the transition from manifold1
        ///     to manifold2. So state1 is either persist or remove while state2 is either add or persist.
        /// </summary>
        public static void GetPointStates(PointState[ /*b2_maxManifoldPoints*/] state1,
            PointState[ /*b2_maxManifoldPoints*/] state2,
            Manifold manifold1, Manifold manifold2)
        {
            for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                state1[i] = PointState.NullState;
                state2[i] = PointState.NullState;
            }

            // Detect persists and removes.
            for (int i = 0; i < manifold1.PointCount; ++i)
            {
                ContactId id = manifold1.Points[i].Id;

                state1[i] = PointState.RemoveState;

                for (int j = 0; j < manifold2.PointCount; ++j)
                {
                    if (manifold2.Points[j].Id.Key == id.Key)
                    {
                        state1[i] = PointState.PersistState;
                        break;
                    }
                }
            }

            // Detect persists and adds.
            for (int i = 0; i < manifold2.PointCount; ++i)
            {
                ContactId id = manifold2.Points[i].Id;

                state2[i] = PointState.AddState;

                for (int j = 0; j < manifold1.PointCount; ++j)
                {
                    if (manifold1.Points[j].Id.Key == id.Key)
                    {
                        state2[i] = PointState.PersistState;
                        break;
                    }
                }
            }
        }

        // Sutherland-Hodgman clipping.
        /// <summary>
        ///     Clips the segment to line using the specified v out
        /// </summary>
        /// <param name="vOut">The out</param>
        /// <param name="vIn">The in</param>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <returns>The num out</returns>
        public static int ClipSegmentToLine(out ClipVertex[ /*2*/] vOut, ClipVertex[ /*2*/] vIn, Vector2 normal,
            float offset)
        {
            vOut = new ClipVertex[2];

            // Start with no output points
            int numOut = 0;

            // Calculate the distance of end points to the line
            float distance0 = Vector2.Dot(normal, vIn[0].V) - offset;
            float distance1 = Vector2.Dot(normal, vIn[1].V) - offset;

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
                vOut[numOut].V = vIn[0].V + interp * (vIn[1].V - vIn[0].V);
                if (distance0 > 0.0f)
                {
                    vOut[numOut].Id = vIn[0].Id;
                }
                else
                {
                    vOut[numOut].Id = vIn[1].Id;
                }

                ++numOut;
            }

            return numOut;
        }
    }
}