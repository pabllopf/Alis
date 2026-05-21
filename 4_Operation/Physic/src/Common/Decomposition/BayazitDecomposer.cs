

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
            Vector2F lowerInt = new Vector2F();
            Vector2F upperInt = new Vector2F(); // intersection points
            int lowerIndex = 0, upperIndex = 0;

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (Reflex(i, vertices))
                {
                    FindIntersectionPoints(i, vertices, ref lowerInt, ref upperInt, ref lowerIndex, ref upperIndex);

                    if (lowerIndex == (upperIndex + 1) % vertices.Count)
                    {
                        SplitAtMidpoint(lowerInt, upperInt, i, upperIndex, lowerIndex, vertices, list);
                    }
                    else
                    {
                        SplitAtBestVertex(i, vertices, lowerIndex, upperIndex, list);
                    }

                    return list;
                }
            }

            SplitConvexPolygon(vertices, list);

            return list;
        }

        private static void FindIntersectionPoints(int i, Vertices vertices, ref Vector2F lowerInt, ref Vector2F upperInt, ref int lowerIndex, ref int upperIndex)
        {
            float upperDist;
            float lowerDist = upperDist = float.MaxValue;

            for (int j = 0; j < vertices.Count; ++j)
            {
                UpdateLowerIntersection(i, vertices, j, ref lowerDist, ref lowerInt, ref lowerIndex);
                UpdateUpperIntersection(i, vertices, j, ref upperDist, ref upperInt, ref upperIndex);
            }
        }

        private static void UpdateLowerIntersection(int i, Vertices vertices, int j, ref float lowerDist, ref Vector2F lowerInt, ref int lowerIndex)
        {
            if (!Left(At(i - 1, vertices), At(i, vertices), At(j, vertices)) || !RightOn(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices)))
            {
                return;
            }

            Vector2F p = LineTools.LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices), At(j - 1, vertices));
            if (!Right(At(i + 1, vertices), At(i, vertices), p))
            {
                return;
            }

            float d = SquareDist(At(i, vertices), p);
            if (d >= lowerDist)
            {
                return;
            }

            lowerDist = d;
            lowerInt = p;
            lowerIndex = j;
        }

        private static void UpdateUpperIntersection(int i, Vertices vertices, int j, ref float upperDist, ref Vector2F upperInt, ref int upperIndex)
        {
            if (!Left(At(i + 1, vertices), At(i, vertices), At(j + 1, vertices)) || !RightOn(At(i + 1, vertices), At(i, vertices), At(j, vertices)))
            {
                return;
            }

            Vector2F p = LineTools.LineIntersect(At(i + 1, vertices), At(i, vertices), At(j, vertices), At(j + 1, vertices));
            if (!Left(At(i - 1, vertices), At(i, vertices), p))
            {
                return;
            }

            float d = SquareDist(At(i, vertices), p);
            if (d >= upperDist)
            {
                return;
            }

            upperDist = d;
            upperIndex = j;
            upperInt = p;
        }

        private static void SplitAtMidpoint(Vector2F lowerInt, Vector2F upperInt, int i, int upperIndex, int lowerIndex, Vertices vertices, List<Vertices> list)
        {
            Vector2F p = (lowerInt + upperInt) / 2;

            Vertices lowerPoly = Copy(i, upperIndex, vertices);
            lowerPoly.Add(p);
            Vertices upperPoly = Copy(lowerIndex, i, vertices);
            upperPoly.Add(p);

            list.AddRange(TriangulatePolygon(lowerPoly));
            list.AddRange(TriangulatePolygon(upperPoly));
        }

        private static void SplitAtBestVertex(int i, Vertices vertices, int lowerIndex, int upperIndex, List<Vertices> list)
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
                    double score = CalculateVertexScore(i, j, vertices);
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

        private static double CalculateVertexScore(int i, int j, Vertices vertices)
        {
            double score = 1 / (SquareDist(At(i, vertices), At(j, vertices)) + 1);
            if (Reflex(j, vertices))
            {
                if (RightOn(At(j - 1, vertices), At(j, vertices), At(i, vertices)) && LeftOn(At(j + 1, vertices), At(j, vertices), At(i, vertices)))
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

        private static void SplitConvexPolygon(Vertices vertices, List<Vertices> list)
        {
            if (vertices.Count > SettingEnv.MaxPolygonVertices)
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
            if (!IsVertexVisibleFrom(i, j, vertices))
            {
                return false;
            }

            if (!IsVertexVisibleFrom(j, i, vertices))
            {
                return false;
            }

            return !IntersectsAnyEdge(i, j, vertices);
        }

        private static bool IsVertexVisibleFrom(int i, int j, Vertices vertices)
        {
            if (Reflex(i, vertices))
            {
                return !(LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)) && RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)));
            }
            else
            {
                return !(RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)) || LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)));
            }
        }

        private static bool IntersectsAnyEdge(int i, int j, Vertices vertices)
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
        ///     Describes whether right
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool Right(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(ref a, ref b, ref c) < 0;

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