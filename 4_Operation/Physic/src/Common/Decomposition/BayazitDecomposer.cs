// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BayazitDecomposer.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Decomposition
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
        ///     Decompose the polygon into several smaller non-concave polygon.
        ///     If the polygon is already convex, it will return the original polygon, unless it is over
        ///     Settings.MaxPolygonVertices.
        /// </summary>
        public static List<Vertices> ConvexPartition(Vertices vertices) => TriangulatePolygon(vertices);

        /// <summary>
        ///     Triangulates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The list</returns>
        internal static List<Vertices> TriangulatePolygon(Vertices vertices)
        {
            List<Vertices> list = new List<Vertices>();
            Vertices lowerPoly, upperPoly;

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (Reflex(i, vertices) && TryFindSplit(i, vertices, out Vector2F lowerInt, out int lowerIndex, out Vector2F upperInt, out int upperIndex))
                    {
                        if (lowerIndex == (upperIndex + 1) % vertices.Count)
                        {
                            Vector2F p = (lowerInt + upperInt) / 2;

                            lowerPoly = Copy(i, upperIndex, vertices);
                            lowerPoly.Add(p);
                            upperPoly = Copy(lowerIndex, i, vertices);
                            upperPoly.Add(p);
                        }
                        else
                        {
                            int bestIndex = FindBestSplitIndex(i, lowerIndex, upperIndex, vertices);

                            lowerPoly = Copy(i, bestIndex, vertices);
                            upperPoly = Copy(bestIndex, i, vertices);
                        }

                        list.AddRange(TriangulatePolygon(lowerPoly));
                        list.AddRange(TriangulatePolygon(upperPoly));
                        return list;
                    }
            }

            // polygon is already convex
            if (vertices.Count > SettingEnv.MaxPolygonVertices)
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
        ///     Tries to find a valid split line from a reflex vertex
        /// </summary>
        private static bool TryFindSplit(int i, Vertices vertices, out Vector2F lowerInt, out int lowerIndex, out Vector2F upperInt, out int upperIndex)
        {
            float upperDist;
            float lowerDist = upperDist = float.MaxValue;
            lowerInt = new Vector2F();
            upperInt = new Vector2F();
            lowerIndex = 0;
            upperIndex = 0;

            for (int j = 0; j < vertices.Count; ++j)
            {
                FindLowerIntersection(i, j, vertices, ref lowerDist, ref lowerInt, ref lowerIndex);
                FindUpperIntersection(i, j, vertices, ref upperDist, ref upperInt, ref upperIndex);
            }

            return lowerDist < float.MaxValue || upperDist < float.MaxValue;
        }

        /// <summary>
        ///     Finds the lower intersection point for a reflex vertex
        /// </summary>
        private static void FindLowerIntersection(int i, int j, Vertices vertices, ref float lowerDist, ref Vector2F lowerInt, ref int lowerIndex)
        {
            if (Left(At(i - 1, vertices), At(i, vertices), At(j, vertices)) && RightOn(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices)))
            {
                Vector2F p = LineTools.LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices), At(j - 1, vertices));

                if (Right(At(i + 1, vertices), At(i, vertices), p))
                {
                    float d = SquareDist(At(i, vertices), p);
                    if (d < lowerDist)
                    {
                        lowerDist = d;
                        lowerInt = p;
                        lowerIndex = j;
                    }
                }
            }
        }

        /// <summary>
        ///     Finds the upper intersection point for a reflex vertex
        /// </summary>
        private static void FindUpperIntersection(int i, int j, Vertices vertices, ref float upperDist, ref Vector2F upperInt, ref int upperIndex)
        {
            if (Left(At(i + 1, vertices), At(i, vertices), At(j + 1, vertices)) && RightOn(At(i + 1, vertices), At(i, vertices), At(j, vertices)))
            {
                Vector2F p = LineTools.LineIntersect(At(i + 1, vertices), At(i, vertices), At(j, vertices), At(j + 1, vertices));

                if (Left(At(i - 1, vertices), At(i, vertices), p))
                {
                    float d = SquareDist(At(i, vertices), p);
                    if (d < upperDist)
                    {
                        upperDist = d;
                        upperIndex = j;
                        upperInt = p;
                    }
                }
            }
        }

        /// <summary>
        ///     Finds the best index to split the polygon
        /// </summary>
        private static int FindBestSplitIndex(int reflexVertex, int lowerIndex, int upperIndex, Vertices vertices)
        {
            while (upperIndex < lowerIndex)
            {
                upperIndex += vertices.Count;
            }

            double highestScore = 0;
            int bestIndex = lowerIndex;

            for (int j = lowerIndex; j <= upperIndex; ++j)
            {
                if (CanSee(reflexVertex, j, vertices))
                {
                    double score = CalculateVertexScore(reflexVertex, j, vertices);
                    if (score > highestScore)
                    {
                        bestIndex = j;
                        highestScore = score;
                    }
                }
            }

            return bestIndex;
        }

        /// <summary>
        ///     Calculates the score for a potential split vertex
        /// </summary>
        private static double CalculateVertexScore(int reflexVertex, int candidate, Vertices vertices)
        {
            double score = 1 / (SquareDist(At(reflexVertex, vertices), At(candidate, vertices)) + 1);

            if (Reflex(candidate, vertices))
            {
                if (RightOn(At(candidate - 1, vertices), At(candidate, vertices), At(reflexVertex, vertices)) && LeftOn(At(candidate + 1, vertices), At(candidate, vertices), At(reflexVertex, vertices)))
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

            return score;
        }

        /// <summary>
        ///     Ats the i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The vector</returns>
        internal static Vector2F At(int i, Vertices vertices)
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
        internal static Vertices Copy(int i, int j, Vertices vertices)
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
        internal static bool CanSee(int i, int j, Vertices vertices)
        {
            if (!CanVertexSee(i, j, vertices))
                return false;

            if (!CanVertexSee(j, i, vertices))
                return false;

            return !LineIntersectsAnyEdge(i, j, vertices);
        }

        /// <summary>
        ///     Checks if a vertex can see another vertex based on its orientation
        /// </summary>
        private static bool CanVertexSee(int vertex, int target, Vertices vertices)
        {
            if (Reflex(vertex, vertices))
            {
                return !(LeftOn(At(vertex, vertices), At(vertex - 1, vertices), At(target, vertices)) && RightOn(At(vertex, vertices), At(vertex + 1, vertices), At(target, vertices)));
            }
            else
            {
                return !(RightOn(At(vertex, vertices), At(vertex + 1, vertices), At(target, vertices)) || LeftOn(At(vertex, vertices), At(vertex - 1, vertices), At(target, vertices)));
            }
        }

        /// <summary>
        ///     Checks if the line segment between two vertices intersects any edge
        /// </summary>
        private static bool LineIntersectsAnyEdge(int i, int j, Vertices vertices)
        {
            for (int k = 0; k < vertices.Count; ++k)
            {
                if ((k + 1) % vertices.Count == i || k == i || (k + 1) % vertices.Count == j || k == j)
                {
                    continue; // ignore incident edges
                }

                if (LineTools.LineIntersect(At(i, vertices), At(j, vertices), At(k, vertices), At(k + 1, vertices), out Vector2F _))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Describes whether reflex
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        internal static bool Reflex(int i, Vertices vertices) => Right(i, vertices);

        /// <summary>
        ///     Describes whether right
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        internal static bool Right(int i, Vertices vertices) => Right(At(i - 1, vertices), At(i, vertices), At(i + 1, vertices));

        /// <summary>
        ///     Describes whether left
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool Left(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(ref a, ref b, ref c) > 0;

        /// <summary>
        ///     Describes whether left on
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool LeftOn(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(ref a, ref b, ref c) >= 0;

        /// <summary>
        ///     Describes whether right
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool Right(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(ref a, ref b, ref c) < 0;

        /// <summary>
        ///     Describes whether right on
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool RightOn(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(ref a, ref b, ref c) <= 0;

        /// <summary>
        ///     Squares the dist using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        internal static float SquareDist(Vector2F a, Vector2F b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            return dx * dx + dy * dy;
        }
    }
}
