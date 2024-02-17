// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplifyTools.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.PolygonManipulation
{
    /// <summary>Provides a set of tools to simplify polygons in various ways.</summary>
    public static class SimplifyTools
    {
        /// <summary>Removes all collinear points on the polygon.</summary>
        /// <param name="vertices">The polygon that needs simplification.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>A simplified polygon.</returns>
        public static void CollinearSimplify(Vertices vertices, float tolerance = 0)
        {
            if (vertices.Count <= 3)
            {
                return;
            }

            Vertices simplified = new Vertices(vertices.Count);

            for (int i = 0; i < vertices.Count; i++)
            {
                Vector2 prev = vertices.PreviousVertex(i);
                Vector2 current = vertices[i];
                Vector2 next = vertices.NextVertex(i);

                //If they collinear, continue
                if (MathUtils.IsCollinear(ref prev, ref current, ref next, tolerance))
                {
                    continue;
                }

                simplified.Add(current);
            }
        }

        /// <summary>
        ///     Douglas Peucker polygon simplification algorithm. This is the general recursive version that does not
        ///     use the speed-up technique by using the man convex hull. If you pass in 0, it will remove all collinear points.
        /// </summary>
        /// <returns>The simplified polygon</returns>
        public static Vertices DouglasPeuckerSimplify(Vertices vertices, float distanceTolerance)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            bool[] usePoint = new bool[vertices.Count];

            for (int i = 0; i < vertices.Count; i++)
            {
                usePoint[i] = true;
            }

            SimplifySection(vertices, 0, vertices.Count - 1, usePoint, distanceTolerance);

            Vertices simplified = new Vertices(vertices.Count);

            for (int i = 0; i < vertices.Count; i++)
            {
                if (usePoint[i])
                {
                    simplified.Add(vertices[i]);
                }
            }

            return simplified;
        }

        /// <summary>
        ///     Simplifies the section using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="i">The </param>
        /// <param name="j">The </param>
        /// <param name="usePoint">The use point</param>
        /// <param name="distanceTolerance">The distance tolerance</param>
        private static void SimplifySection(Vertices vertices, int i, int j, bool[] usePoint, float distanceTolerance)
        {
            if (i + 1 == j)
            {
                return;
            }

            Vector2 a = vertices[i];
            Vector2 b = vertices[j];

            double maxDistance = -1.0;
            int maxIndex = i;
            for (int k = i + 1; k < j; k++)
            {
                Vector2 point = vertices[k];

                double distance = Line.DistanceBetweenPointAndLineSegment(point, a, b);

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    maxIndex = k;
                }
            }

            if (maxDistance <= distanceTolerance)
            {
                for (int k = i + 1; k < j; k++)
                {
                    usePoint[k] = false;
                }
            }
            else
            {
                SimplifySection(vertices, i, maxIndex, usePoint, distanceTolerance);
                SimplifySection(vertices, maxIndex, j, usePoint, distanceTolerance);
            }
        }

        /// <summary>Merges all parallel edges in the list of vertices</summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="tolerance">The tolerance.</param>
        public static Vertices MergeParallelEdges(Vertices vertices, float tolerance)
        {
            if (vertices.Count <= 3)
            {
                return vertices; // Can't do anything useful here to a triangle
            }

            bool[] mergeMe = new bool[vertices.Count];
            int newNVertices = vertices.Count;

            CalculateEdgesToMerge(vertices, tolerance, mergeMe, ref newNVertices);

            if (newNVertices == vertices.Count || newNVertices == 0)
            {
                return vertices;
            }

            return CreateNewVerticesList(vertices, mergeMe, newNVertices);
        }

        /// <summary>
        ///     Calculates the edges to merge using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="mergeMe">The merge me</param>
        /// <param name="newNVertices">The new vertices</param>
        private static void CalculateEdgesToMerge(Vertices vertices, float tolerance, bool[] mergeMe, ref int newNVertices)
        {
            for (int i = 0; i < vertices.Count; ++i)
            {
                int lower = i == 0 ? vertices.Count - 1 : i - 1;
                int middle = i;
                int upper = i == vertices.Count - 1 ? 0 : i + 1;

                float dx0 = vertices[middle].X - vertices[lower].X;
                float dy0 = vertices[middle].Y - vertices[lower].Y;
                float dx1 = vertices[upper].X - vertices[middle].X;
                float dy1 = vertices[upper].Y - vertices[middle].Y;
                float norm0 = (float) Math.Sqrt(dx0 * dx0 + dy0 * dy0);
                float norm1 = (float) Math.Sqrt(dx1 * dx1 + dy1 * dy1);

                if (!((norm0 > 0.0f) && (norm1 > 0.0f)) && (newNVertices > 3))
                {
                    // Merge identical points
                    mergeMe[i] = true;
                    --newNVertices;
                }

                dx0 /= norm0;
                dy0 /= norm0;
                dx1 /= norm1;
                dy1 /= norm1;
                float cross = dx0 * dy1 - dx1 * dy0;
                float dot = dx0 * dx1 + dy0 * dy1;

                if ((Math.Abs(cross) < tolerance) && (dot > 0) && (newNVertices > 3))
                {
                    mergeMe[i] = true;
                    --newNVertices;
                }
                else
                {
                    mergeMe[i] = false;
                }
            }
        }

        /// <summary>
        ///     Creates the new vertices list using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="mergeMe">The merge me</param>
        /// <param name="newNVertices">The new vertices</param>
        /// <returns>The new vertices</returns>
        private static Vertices CreateNewVerticesList(Vertices vertices, bool[] mergeMe, int newNVertices)
        {
            int currIndex = 0;
            Vertices newVertices = new Vertices(newNVertices);

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (mergeMe[i] || currIndex == newNVertices)
                {
                    continue;
                }

                Debug.Assert(currIndex < newNVertices);

                newVertices.Add(vertices[i]);
                ++currIndex;
            }

            return newVertices;
        }


        /// <summary>Merges the identical points in the polygon.</summary>
        /// <param name="vertices">The vertices.</param>
        public static Vertices MergeIdenticalPoints(Vertices vertices)
        {
            HashSet<Vector2> unique = new HashSet<Vector2>();

            foreach (Vector2 vertex in vertices)
            {
                unique.Add(vertex);
            }

            return new Vertices(unique);
        }

        /// <summary>Reduces the polygon by distance.</summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="distance">The distance between points. Points closer than this will be removed.</param>
        public static Vertices ReduceByDistance(Vertices vertices, float distance)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            float distance2 = distance * distance;

            Vertices simplified = new Vertices(vertices.Count);

            for (int i = 0; i < vertices.Count; i++)
            {
                Vector2 current = vertices[i];
                Vector2 next = vertices.NextVertex(i);

                //If they are closer than the distance, continue
                if ((next - current).LengthSquared() <= distance2)
                {
                    continue;
                }

                simplified.Add(current);
            }

            return simplified;
        }

        /// <summary>Reduces the polygon by removing the Nth vertex in the vertices list.</summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="nth">The Nth point to remove. Example: 5.</param>
        /// <returns></returns>
        public static Vertices ReduceByNth(Vertices vertices, int nth)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            if (nth == 0)
            {
                return vertices;
            }

            Vertices simplified = new Vertices(vertices.Count);

            for (int i = 0; i < vertices.Count; i++)
            {
                if (i % nth == 0)
                {
                    continue;
                }

                simplified.Add(vertices[i]);
            }

            return simplified;
        }

        /// <summary>
        ///     Simplify the polygon by removing all points that in pairs of 3 have an area less than the tolerance. Pass in 0
        ///     as tolerance, and it will only remove collinear points.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="areaTolerance"></param>
        /// <returns></returns>
        public static Vertices ReduceByArea(Vertices vertices, float areaTolerance)
        {
            //From physics2d.net

            if (vertices.Count <= 3)
            {
                return vertices;
            }

            if (areaTolerance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(areaTolerance), "must be equal to or greater than zero.");
            }

            Vertices simplified = new Vertices(vertices.Count);
            Vector2 v3;
            Vector2 v1 = vertices[vertices.Count - 2];
            Vector2 v2 = vertices[vertices.Count - 1];
            areaTolerance *= 2;

            for (int i = 0; i < vertices.Count; ++i, v2 = v3)
            {
                v3 = i == vertices.Count - 1 ? simplified[0] : vertices[i];

                MathUtils.Cross(ref v1, ref v2, out float old1);

                MathUtils.Cross(ref v2, ref v3, out float old2);

                MathUtils.Cross(ref v1, ref v3, out float new1);

                if (Math.Abs(new1 - (old1 + old2)) > areaTolerance)
                {
                    simplified.Add(v2);
                    v1 = v2;
                }
            }

            return simplified;
        }
    }
}