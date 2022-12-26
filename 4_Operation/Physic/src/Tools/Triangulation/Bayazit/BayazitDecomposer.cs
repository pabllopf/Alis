// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BayazitDecomposer.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;
using Vector2 = System.Numerics.Vector2;

namespace Alis.Core.Physic.Tools.Triangulation.Bayazit
{
    //From phed rev 36: http://code.google.com/p/phed/source/browse/trunk/Polygon.cpp

    /// <summary>
    ///     Convex decomposition algorithm created by Mark Bayazit (http://mnbayazit.com/)
    ///     Properties:
    ///     - Tries to decompose using polygons instead of triangles.
    ///     - Tends to produce optimal results with low processing time.
    ///     - Running time is O(nr), n = number of vertices, r = reflex vertices.
    ///     - Does not support holes.
    ///     For more information about this algorithm, see http://mnbayazit.com/406/bayazit
    /// </summary>
    internal static class BayazitDecomposer
    {
        /// <summary>
        ///     Decompose the polygon into several smaller non-concave polygon. If the polygon is already convex, it will
        ///     return the original polygon, unless it is over Settings.MaxPolygonVertices.
        /// </summary>
        public static List<Vertices> ConvexPartition(Vertices vertices)
        {
            Debug.Assert(vertices.Count > 3);
            Debug.Assert(vertices.IsCounterClockWise());

            return TriangulatePolygon(vertices);
        }

        /// <summary>
        ///     Triangulates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The list</returns>
        private static List<Vertices> TriangulatePolygon(Vertices vertices)
        {
            List<Vertices> list = new List<Vertices>();
            Vector2 lowerInt = new Vector2();
            Vector2 upperInt = new Vector2(); // intersection points
            int lowerIndex = 0, upperIndex = 0;
            Vertices lowerPoly, upperPoly;

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (Reflex(i, vertices))
                {
                    float upperDist;
                    float lowerDist = upperDist = float.MaxValue;
                    for (int j = 0; j < vertices.Count; ++j)
                    {
                        // if line intersects with an edge
                        float d;
                        Vector2 p;
                        if (Left(At(i - 1, vertices), At(i, vertices), At(j, vertices)) &&
                            RightOn(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices)))
                        {
                            // find the point of intersection
                            p = LineUtils.LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices),
                                At(j - 1, vertices));

                            if (Right(At(i + 1, vertices), At(i, vertices), p))
                            {
                                // make sure it's inside the poly
                                d = SquareDist(At(i, vertices), p);
                                if (d < lowerDist)
                                {
                                    // keep only the closest intersection
                                    lowerDist = d;
                                    lowerInt = p;
                                    lowerIndex = j;
                                }
                            }
                        }

                        if (Left(At(i + 1, vertices), At(i, vertices), At(j + 1, vertices)) &&
                            RightOn(At(i + 1, vertices), At(i, vertices), At(j, vertices)))
                        {
                            p = LineUtils.LineIntersect(At(i + 1, vertices), At(i, vertices), At(j, vertices),
                                At(j + 1, vertices));

                            if (Left(At(i - 1, vertices), At(i, vertices), p))
                            {
                                d = SquareDist(At(i, vertices), p);
                                if (d < upperDist)
                                {
                                    upperDist = d;
                                    upperIndex = j;
                                    upperInt = p;
                                }
                            }
                        }
                    }

                    // if there are no vertices to connect to, choose a point in the middle
                    if (lowerIndex == (upperIndex + 1) % vertices.Count)
                    {
                        Vector2 p = (lowerInt + upperInt) / 2;

                        lowerPoly = Copy(i, upperIndex, vertices);
                        lowerPoly.Add(p);
                        upperPoly = Copy(lowerIndex, i, vertices);
                        upperPoly.Add(p);
                    }
                    else
                    {
                        double highestScore = 0, bestIndex = lowerIndex;
                        while (upperIndex < lowerIndex)
                        {
                            upperIndex += vertices.Count;
                        }

                        for (int j = lowerIndex; j <= upperIndex; ++j)
                        {
                            if (CanSee(i, j, vertices))
                            {
                                double score = 1 / (SquareDist(At(i, vertices), At(j, vertices)) + 1);
                                if (Reflex(j, vertices))
                                {
                                    if (RightOn(At(j - 1, vertices), At(j, vertices), At(i, vertices)) &&
                                        LeftOn(At(j + 1, vertices), At(j, vertices), At(i, vertices)))
                                    {
                                        score += 3;
                                    }
                                    else
                                    {
                                        score += 2;
                                    }
                                }
                                else
                                {
                                    score += 1;
                                }

                                if (score > highestScore)
                                {
                                    bestIndex = j;
                                    highestScore = score;
                                }
                            }
                        }

                        lowerPoly = Copy(i, (int) bestIndex, vertices);
                        upperPoly = Copy((int) bestIndex, i, vertices);
                    }

                    list.AddRange(TriangulatePolygon(lowerPoly));
                    list.AddRange(TriangulatePolygon(upperPoly));
                    return list;
                }
            }

            // polygon is already convex
            if (vertices.Count > Settings.MaxPolygonVertices)
            {
                lowerPoly = Copy(0, vertices.Count / 2, vertices);
                upperPoly = Copy(vertices.Count / 2, 0, vertices);
                list.AddRange(TriangulatePolygon(lowerPoly));
                list.AddRange(TriangulatePolygon(upperPoly));
            }
            else
            {
                list.Add(vertices);
            }

            return list;
        }

        /// <summary>
        ///     Ats the i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The vector</returns>
        private static Vector2 At(int i, Vertices vertices)
        {
            int s = vertices.Count;
            return vertices[i < 0 ? s - 1 - (-i - 1) % s : i % s];
        }

        /// <summary>
        ///     Copies the i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="j">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The </returns>
        private static Vertices Copy(int i, int j, Vertices vertices)
        {
            while (j < i)
            {
                j += vertices.Count;
            }

            Vertices p = new Vertices(j);

            for (; i <= j; ++i)
            {
                p.Add(At(i, vertices));
            }

            return p;
        }

        /// <summary>
        ///     Describes whether can see
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="j">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool CanSee(int i, int j, Vertices vertices)
        {
            if (Reflex(i, vertices))
            {
                if (LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)) &&
                    RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)))
                {
                    return false;
                }
            }
            else
            {
                if (RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)) ||
                    LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)))
                {
                    return false;
                }
            }

            if (Reflex(j, vertices))
            {
                if (LeftOn(At(j, vertices), At(j - 1, vertices), At(i, vertices)) &&
                    RightOn(At(j, vertices), At(j + 1, vertices), At(i, vertices)))
                {
                    return false;
                }
            }
            else
            {
                if (RightOn(At(j, vertices), At(j + 1, vertices), At(i, vertices)) ||
                    LeftOn(At(j, vertices), At(j - 1, vertices), At(i, vertices)))
                {
                    return false;
                }
            }

            for (int k = 0; k < vertices.Count; ++k)
            {
                if ((k + 1) % vertices.Count == i || k == i || (k + 1) % vertices.Count == j || k == j)
                {
                    continue; // ignore incident edges
                }

                if (LineUtils.LineIntersect(At(i, vertices), At(j, vertices), At(k, vertices), At(k + 1, vertices),
                        out _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Describes whether reflex
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool Reflex(int i, Vertices vertices) => Right(i, vertices);

        /// <summary>
        ///     Describes whether right
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool Right(int i, Vertices vertices) =>
            Right(At(i - 1, vertices), At(i, vertices), At(i + 1, vertices));

        /// <summary>
        ///     Describes whether left
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private static bool Left(Vector2 a, Vector2 b, Vector2 c) => MathUtils.Area(ref a, ref b, ref c) > 0;

        /// <summary>
        ///     Describes whether left on
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private static bool LeftOn(Vector2 a, Vector2 b, Vector2 c) => MathUtils.Area(ref a, ref b, ref c) >= 0;

        /// <summary>
        ///     Describes whether right
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private static bool Right(Vector2 a, Vector2 b, Vector2 c) => MathUtils.Area(ref a, ref b, ref c) < 0;

        /// <summary>
        ///     Describes whether right on
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private static bool RightOn(Vector2 a, Vector2 b, Vector2 c) => MathUtils.Area(ref a, ref b, ref c) <= 0;

        /// <summary>
        ///     Squares the dist using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        private static float SquareDist(Vector2 a, Vector2 b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            return dx * dx + dy * dy;
        }
    }
}