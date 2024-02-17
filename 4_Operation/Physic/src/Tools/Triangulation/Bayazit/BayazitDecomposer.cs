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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.Triangulation.Bayazit
{

    /// <summary>
    /// The bayazit decomposer class
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
        /// Triangulates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The list</returns>
        private static List<Vertices> TriangulatePolygon(Vertices vertices)
        {
            List<Vertices> list = new List<Vertices>();
            Vector2 lowerInt = new Vector2();
            Vector2 upperInt = new Vector2(); // intersection points
            int lowerIndex = 0, upperIndex = 0;

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (Reflex(i, vertices))
                {
                    float upperDist;
                    float lowerDist = upperDist = float.MaxValue;
                    for (int j = 0; j < vertices.Count; ++j)
                    {
                        ProcessEdgeIntersection(i, j, vertices, ref lowerDist, ref lowerInt, ref lowerIndex);
                        ProcessEdgeIntersection(i, j, vertices, ref upperDist, ref upperInt, ref upperIndex);
                    }

                    if (lowerIndex == (upperIndex + 1) % vertices.Count)
                    {
                        HandleNoVerticesToConnect(i, lowerIndex, upperIndex, lowerInt, upperInt, vertices, list);
                    }
                    else
                    {
                        HandleVerticesToConnect(i, lowerIndex, upperIndex, vertices, list);
                    }

                    return list;
                }
            }

            HandleConvexPolygon(vertices, list);

            return list;
        }

        /// <summary>

        /// Processes the edge intersection using the specified i

        /// </summary>

        /// <param name="i">The </param>

        /// <param name="j">The </param>

        /// <param name="vertices">The vertices</param>

        /// <param name="dist">The dist</param>

        /// <param name="intersection">The intersection</param>

        /// <param name="index">The index</param>

        private static void ProcessEdgeIntersection(int i, int j, Vertices vertices, ref float dist, ref Vector2 intersection, ref int index)
        {
            float d;
            Vector2 p;
            if (Left(At(i - 1, vertices), At(i, vertices), At(j, vertices)) &&
                RightOn(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices)))
            {
                p = Line.LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices),
                    At(j - 1, vertices));

                if (Right(At(i + 1, vertices), At(i, vertices), p))
                {
                    d = SquareDist(At(i, vertices), p);
                    if (d < dist)
                    {
                        dist = d;
                        intersection = p;
                        index = j;
                    }
                }
            }
        }

        /// <summary>

        /// Handles the no vertices to connect using the specified i

        /// </summary>

        /// <param name="i">The </param>

        /// <param name="lowerIndex">The lower index</param>

        /// <param name="upperIndex">The upper index</param>

        /// <param name="lowerInt">The lower int</param>

        /// <param name="upperInt">The upper int</param>

        /// <param name="vertices">The vertices</param>

        /// <param name="list">The list</param>

        private static void HandleNoVerticesToConnect(int i, int lowerIndex, int upperIndex, Vector2 lowerInt, Vector2 upperInt, Vertices vertices, List<Vertices> list)
        {
            Vector2 p = (lowerInt + upperInt) / 2;

            Vertices lowerPoly = Copy(i, upperIndex, vertices);
            lowerPoly.Add(p);
            Vertices upperPoly = Copy(lowerIndex, i, vertices);
            upperPoly.Add(p);

            list.AddRange(TriangulatePolygon(lowerPoly));
            list.AddRange(TriangulatePolygon(upperPoly));
        }

        /// <summary>

        /// Handles the vertices to connect using the specified i

        /// </summary>

        /// <param name="i">The </param>

        /// <param name="lowerIndex">The lower index</param>

        /// <param name="upperIndex">The upper index</param>

        /// <param name="vertices">The vertices</param>

        /// <param name="list">The list</param>

        private static void HandleVerticesToConnect(int i, int lowerIndex, int upperIndex, Vertices vertices, List<Vertices> list)
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

            Vertices lowerPoly = Copy(i, (int) bestIndex, vertices);
            Vertices upperPoly = Copy((int) bestIndex, i, vertices);

            list.AddRange(TriangulatePolygon(lowerPoly));
            list.AddRange(TriangulatePolygon(upperPoly));
        }

        /// <summary>

        /// Handles the convex polygon using the specified vertices

        /// </summary>

        /// <param name="vertices">The vertices</param>

        /// <param name="list">The list</param>

        private static void HandleConvexPolygon(Vertices vertices, List<Vertices> list)
        {
            if (vertices.Count > Settings.PolygonVertices)
            {
                Vertices lowerPoly = Copy(0, vertices.Count / 2, vertices);
                Vertices upperPoly = Copy(vertices.Count / 2, 0, vertices);
                list.AddRange(TriangulatePolygon(lowerPoly));
                list.AddRange(TriangulatePolygon(upperPoly));
            }
            else
            {
                list.Add(vertices);
            }
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
        /// Describes whether can see
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="j">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool CanSee(int i, int j, Vertices vertices)
        {
            if (!IsValidVisibility(i, vertices) || !IsValidVisibility(j, vertices))
            {
                return false;
            }

            return !HasIntersectingLines(i, j, vertices);
        }

        /// <summary>
        /// Describes whether is valid visibility
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool IsValidVisibility(int index, Vertices vertices)
        {
            return !(Reflex(index, vertices)
                ? LeftOn(At(index, vertices), At(index - 1, vertices), At(index + 1, vertices)) && RightOn(At(index, vertices), At(index + 1, vertices), At(index - 1, vertices))
                : RightOn(At(index, vertices), At(index + 1, vertices), At(index - 1, vertices)) || LeftOn(At(index, vertices), At(index - 1, vertices), At(index + 1, vertices)));
        }

        /// <summary>
        /// Describes whether has intersecting lines
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="j">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The bool</returns>
        private static bool HasIntersectingLines(int i, int j, Vertices vertices)
        {
            for (int k = 0; k < vertices.Count; ++k)
            {
                if ((k + 1) % vertices.Count == i || k == i || (k + 1) % vertices.Count == j || k == j)
                {
                    continue; // ignore incident edges
                }

                if (Line.LineIntersect(At(i, vertices), At(j, vertices), At(k, vertices), At(k + 1, vertices), true, true, out _))
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