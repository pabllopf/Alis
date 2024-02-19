// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainHull.cs
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

using System;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Tools.ConvexHull
{
    /// <summary>
    ///     Andrew's Monotone Chain Convex Hull algorithm. Used to get the convex hull of a point cloud.
    /// </summary>
    public static class ChainHull
    {
        /// <summary>
        ///     The point comparer
        /// </summary>
        private static readonly PointComparer PointComparerPrivate = new PointComparer();

        /// <summary>
        ///     Returns the convex hull from the given vertices.
        /// </summary>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            Vertices sortedVertices = SortVerticesByX(vertices);
            Vector2[] lowerHull = ComputeHull(sortedVertices, true);
            Vector2[] upperHull = ComputeHull(sortedVertices, false);

            return CombineHulls(lowerHull, upperHull);
        }

        /// <summary>
        ///     Sorts the vertices by x using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The sorted</returns>
        private static Vertices SortVerticesByX(Vertices vertices)
        {
            Vertices sorted = new Vertices(vertices);
            sorted.Sort(PointComparerPrivate);
            return sorted;
        }

        /// <summary>
        ///     Computes the hull using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="lowerHull">The lower hull</param>
        /// <returns>The hull</returns>
        private static Vector2[] ComputeHull(Vertices vertices, bool lowerHull)
        {
            int count = vertices.Count;
            Vector2[] hull = new Vector2[count];
            int top = -1;
            int startIndex = lowerHull ? 0 : count - 1;
            int endIndex = lowerHull ? count : -1;
            int step = lowerHull ? 1 : -1;

            for (int i = startIndex; i != endIndex; i += step)
            {
                while ((top >= 1) && !IsLeftOfLine(hull[top - 1], hull[top], vertices[i]))
                {
                    top--;
                }

                top++;
                hull[top] = vertices[i];
            }

            Array.Resize(ref hull, top + 1);
            return hull;
        }

        /// <summary>
        ///     Describes whether is left of line
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        private static bool IsLeftOfLine(Vector2 a, Vector2 b, Vector2 point) => MathUtils.Area(a, b, point) > 0;

        /// <summary>
        ///     Combines the hulls using the specified lower hull
        /// </summary>
        /// <param name="lowerHull">The lower hull</param>
        /// <param name="upperHull">The upper hull</param>
        /// <returns>The result</returns>
        private static Vertices CombineHulls(Vector2[] lowerHull, Vector2[] upperHull)
        {
            int totalPoints = lowerHull.Length + upperHull.Length - 2; // Subtract 2 to account for duplicate endpoint
            Vertices result = new Vertices(totalPoints);
            result.AddRange(lowerHull);

            for (int i = 1; i < upperHull.Length - 1; i++) // Skip the duplicate endpoint
            {
                result.Add(upperHull[i]);
            }

            return result;
        }
    }
}