// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipper.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    //Clipper contributed by Helge Backhaus

    /// <summary>
    ///     The yu peng clipper class
    /// </summary>
    public static class YuPengClipper
    {
        /// <summary>
        ///     The clipper epsilon squared
        /// </summary>
        private const float ClipperEpsilonSquared = 1.192092896e-07f;

        /// <summary>
        ///     Unions the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Union(Vertices polygon1, Vertices polygon2, out PolyClipError error) => Execute(polygon1, polygon2, PolyClipType.Union, out error);

        /// <summary>
        ///     Differences the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Difference(Vertices polygon1, Vertices polygon2, out PolyClipError error) => Execute(polygon1, polygon2, PolyClipType.Difference, out error);

        /// <summary>
        ///     Intersects the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Intersect(Vertices polygon1, Vertices polygon2, out PolyClipError error) => Execute(polygon1, polygon2, PolyClipType.Intersect, out error);

        /// <summary>
        ///     Implements "A new algorithm for Boolean operations on general polygons"
        ///     available here: http://liama.ia.ac.cn/wiki/_media/user:dong:dong_cg_05.pdf
        ///     Merges two polygons, a subject and a clip with the specified operation. Polygons may not be
        ///     self-intersecting.
        ///     Warning: May yield incorrect results or even crash if polygons contain collinear points.
        /// </summary>
        /// <param name="subject">The subject polygon.</param>
        /// <param name="clip">
        ///     The clip polygon, which is added,
        ///     substracted or intersected with the subject
        /// </param>
        /// <param name="clipType">
        ///     The operation to be performed. Either
        ///     Union, Difference or Intersection.
        /// </param>
        /// <param name="error">The error generated (if any)</param>
        /// <returns>
        ///     A list of closed polygons, which make up the result of the clipping operation.
        ///     Outer contours are ordered counter clockwise, holes are ordered clockwise.
        /// </returns>
        private static List<Vertices> Execute(Vertices subject, Vertices clip, PolyClipType clipType, out PolyClipError error)
        {
            Debug.Assert(subject.IsSimple() && clip.IsSimple(), "Non simple input! Input polygons must be simple (cannot intersect themselves).");

            // Copy polygons
            // Calculate the intersection and touch points between
            // subject and clip and add them to both
            CalculateIntersections(subject, clip, out Vertices slicedSubject, out Vertices slicedClip);

            // Translate polygons into upper right quadrant
            // as the algorithm depends on it
            Vector2F lbSubject = subject.GetAabb().LowerBound;
            Vector2F lbClip = clip.GetAabb().LowerBound;
            Vector2F.Min(ref lbSubject, ref lbClip, out Vector2F translate);
            translate = Vector2F.One - translate;
            if (translate != Vector2F.Zero)
            {
                slicedSubject.Translate(ref translate);
                slicedClip.Translate(ref translate);
            }

            // Enforce counterclockwise contours
            slicedSubject.ForceCounterClockWise();
            slicedClip.ForceCounterClockWise();

            // Build simplical chains from the polygons and calculate the
            // the corresponding coefficients
            CalculateSimplicalChain(slicedSubject, out List<float> subjectCoeff, out List<Edge> subjectSimplices);
            CalculateSimplicalChain(slicedClip, out List<float> clipCoeff, out List<Edge> clipSimplices);

            // Determine the characteristics function for all non-original edges
            // in subject and clip simplical chain and combine the edges contributing
            // to the result, depending on the clipType
            CalculateResultChain(subjectCoeff, subjectSimplices, clipCoeff, clipSimplices, clipType,
                out List<Edge> resultSimplices);

            // Convert result chain back to polygon(s)
            error = BuildPolygonsFromChain(resultSimplices, out List<Vertices> result);

            // Reverse the polygon translation from the beginning
            // and remove collinear points from output
            translate *= -1f;
            for (int i = 0; i < result.Count; ++i)
            {
                result[i].Translate(ref translate);
                SimplifyTools.CollinearSimplify(result[i]);
            }

            return result;
        }

        /// <summary>
        ///     Calculates all intersections between two polygons.
        /// </summary>
        /// <param name="polygon1">The first polygon.</param>
        /// <param name="polygon2">The second polygon.</param>
        /// <param name="slicedPoly1">Returns the first polygon with added intersection points.</param>
        /// <param name="slicedPoly2">Returns the second polygon with added intersection points.</param>
        private static void CalculateIntersections(Vertices polygon1, Vertices polygon2,
            out Vertices slicedPoly1, out Vertices slicedPoly2)
        {
            slicedPoly1 = new Vertices(polygon1);
            slicedPoly2 = new Vertices(polygon2);

            // Iterate through polygon1's edges
            for (int i = 0; i < polygon1.Count; i++)
            {
                // Get edge vertices
                Vector2F a = polygon1[i];
                Vector2F b = polygon1[polygon1.NextIndex(i)];

                // Get intersections between this edge and polygon2
                for (int j = 0; j < polygon2.Count; j++)
                {
                    Vector2F c = polygon2[j];
                    Vector2F d = polygon2[polygon2.NextIndex(j)];

                    // Check if the edges intersect
                    if (LineTools.LineIntersect(a, b, c, d, out Vector2F intersectionPoint))
                    {
                        // calculate alpha values for sorting multiple intersections points on a edge
                        float alpha;
                        // Insert intersection point into first polygon
                        alpha = GetAlpha(a, b, intersectionPoint);
                        if ((alpha > 0f) && (alpha < 1f))
                        {
                            int index = slicedPoly1.IndexOf(a) + 1;
                            while ((index < slicedPoly1.Count) &&
                                   (GetAlpha(a, b, slicedPoly1[index]) <= alpha))
                            {
                                ++index;
                            }

                            slicedPoly1.Insert(index, intersectionPoint);
                        }

                        // Insert intersection point into second polygon
                        alpha = GetAlpha(c, d, intersectionPoint);
                        if ((alpha > 0f) && (alpha < 1f))
                        {
                            int index = slicedPoly2.IndexOf(c) + 1;
                            while ((index < slicedPoly2.Count) &&
                                   (GetAlpha(c, d, slicedPoly2[index]) <= alpha))
                            {
                                ++index;
                            }

                            slicedPoly2.Insert(index, intersectionPoint);
                        }
                    }
                }
            }

            // Check for very small edges
            for (int i = 0; i < slicedPoly1.Count; ++i)
            {
                int iNext = slicedPoly1.NextIndex(i);
                //If they are closer than the distance remove vertex
                if ((slicedPoly1[iNext] - slicedPoly1[i]).LengthSquared() <= ClipperEpsilonSquared)
                {
                    slicedPoly1.RemoveAt(i);
                    --i;
                }
            }

            for (int i = 0; i < slicedPoly2.Count; ++i)
            {
                int iNext = slicedPoly2.NextIndex(i);
                //If they are closer than the distance remove vertex
                if ((slicedPoly2[iNext] - slicedPoly2[i]).LengthSquared() <= ClipperEpsilonSquared)
                {
                    slicedPoly2.RemoveAt(i);
                    --i;
                }
            }
        }

        /// <summary>
        ///     Calculates the simplical chain corresponding to the input polygon.
        /// </summary>
        /// <remarks>Used by method <c>Execute()</c>.</remarks>
        private static void CalculateSimplicalChain(Vertices poly, out List<float> coeff,
            out List<Edge> simplicies)
        {
            simplicies = new List<Edge>();
            coeff = new List<float>();
            for (int i = 0; i < poly.Count; ++i)
            {
                simplicies.Add(new Edge(poly[i], poly[poly.NextIndex(i)]));
                coeff.Add(CalculateSimplexCoefficient(Vector2F.Zero, poly[i], poly[poly.NextIndex(i)]));
            }
        }

        /// <summary>
        ///     Calculates the characteristics function for all edges of
        ///     the given simplical chains and builds the result chain.
        /// </summary>
        /// <remarks>Used by method <c>Execute()</c>.</remarks>
        private static void CalculateResultChain(List<float> poly1Coeff, List<Edge> poly1Simplicies,
            List<float> poly2Coeff, List<Edge> poly2Simplicies,
            PolyClipType clipType, out List<Edge> resultSimplices)
        {
            resultSimplices = new List<Edge>();

            for (int i = 0; i < poly1Simplicies.Count; ++i)
            {
                float edgeCharacter = 0;
                if (poly2Simplicies.Contains(poly1Simplicies[i]))
                {
                    edgeCharacter = 1f;
                }
                else if (poly2Simplicies.Contains(-poly1Simplicies[i]) && (clipType == PolyClipType.Union))
                {
                    edgeCharacter = 1f;
                }
                else
                {
                    for (int j = 0; j < poly2Simplicies.Count; ++j)
                    {
                        if (!poly2Simplicies.Contains(-poly1Simplicies[i]))
                        {
                            edgeCharacter += CalculateBeta(poly1Simplicies[i].GetCenter(),
                                poly2Simplicies[j], poly2Coeff[j]);
                        }
                    }
                }

                if (clipType == PolyClipType.Intersect)
                {
                    if (Math.Abs(edgeCharacter - 1f) < float.Epsilon)
                    {
                        resultSimplices.Add(poly1Simplicies[i]);
                    }
                }
                else
                {
                    if (Math.Abs(edgeCharacter) < float.Epsilon)
                    {
                        resultSimplices.Add(poly1Simplicies[i]);
                    }
                }
            }

            for (int i = 0; i < poly2Simplicies.Count; ++i)
            {
                float edgeCharacter = 0f;
                if (!resultSimplices.Contains(poly2Simplicies[i]) &&
                    !resultSimplices.Contains(-poly2Simplicies[i]))
                {
                    if (poly1Simplicies.Contains(-poly2Simplicies[i]) && (clipType == PolyClipType.Union))
                    {
                        edgeCharacter = 1f;
                    }
                    else
                    {
                        edgeCharacter = 0f;
                        for (int j = 0; j < poly1Simplicies.Count; ++j)
                        {
                            if (!poly1Simplicies.Contains(poly2Simplicies[i]) && !poly1Simplicies.Contains(-poly2Simplicies[i]))
                            {
                                edgeCharacter += CalculateBeta(poly2Simplicies[i].GetCenter(),
                                    poly1Simplicies[j], poly1Coeff[j]);
                            }
                        }

                        if (clipType == PolyClipType.Intersect || clipType == PolyClipType.Difference)
                        {
                            if (Math.Abs(edgeCharacter - 1f) < float.Epsilon)
                            {
                                resultSimplices.Add(-poly2Simplicies[i]);
                            }
                        }
                        else
                        {
                            if (Math.Abs(edgeCharacter) < float.Epsilon)
                            {
                                resultSimplices.Add(poly2Simplicies[i]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Calculates the polygon(s) from the result simplical chain.
        /// </summary>
        /// <remarks>Used by method <c>Execute()</c>.</remarks>
        private static PolyClipError BuildPolygonsFromChain(List<Edge> simplicies, out List<Vertices> result)
        {
            result = new List<Vertices>();
            PolyClipError errVal = PolyClipError.None;

            while (simplicies.Count > 0)
            {
                Vertices output = new Vertices();
                output.Add(simplicies[0].EdgeStart);
                output.Add(simplicies[0].EdgeEnd);
                simplicies.RemoveAt(0);
                bool closed = false;
                int index = 0;
                int count = simplicies.Count; // Needed to catch infinite loops
                while (!closed && (simplicies.Count > 0))
                {
                    if (VectorEqual(output[output.Count - 1], simplicies[index].EdgeStart))
                    {
                        if (VectorEqual(simplicies[index].EdgeEnd, output[0]))
                        {
                            closed = true;
                        }
                        else
                        {
                            output.Add(simplicies[index].EdgeEnd);
                        }

                        simplicies.RemoveAt(index);
                        --index;
                    }
                    else if (VectorEqual(output[output.Count - 1], simplicies[index].EdgeEnd))
                    {
                        if (VectorEqual(simplicies[index].EdgeStart, output[0]))
                        {
                            closed = true;
                        }
                        else
                        {
                            output.Add(simplicies[index].EdgeStart);
                        }

                        simplicies.RemoveAt(index);
                        --index;
                    }

                    if (!closed)
                    {
                        if (++index == simplicies.Count)
                        {
                            if (count == simplicies.Count)
                            {
                                result = new List<Vertices>();
                                Logger.Log("Undefined error while building result polygon(s).");
                                return PolyClipError.BrokenResult;
                            }

                            index = 0;
                            count = simplicies.Count;
                        }
                    }
                }

                if (output.Count < 3)
                {
                    errVal = PolyClipError.DegeneratedOutput;
                    Logger.Log("Degenerated output polygon produced (vertices < 3).");
                }

                result.Add(output);
            }

            return errVal;
        }

        /// <summary>
        ///     Needed to calculate the characteristics function of a simplex.
        /// </summary>
        /// <remarks>Used by method <c>CalculateEdgeCharacter()</c>.</remarks>
        private static float CalculateBeta(Vector2F point, Edge e, float coefficient)
        {
            float result = 0f;
            if (PointInSimplex(point, e))
            {
                result = coefficient;
            }

            if (PointOnLineSegment(Vector2F.Zero, e.EdgeStart, point) ||
                PointOnLineSegment(Vector2F.Zero, e.EdgeEnd, point))
            {
                result = .5f * coefficient;
            }

            return result;
        }

        /// <summary>
        ///     Needed for sorting multiple intersections points on the same edge.
        /// </summary>
        /// <remarks>Used by method <c>CalculateIntersections()</c>.</remarks>
        private static float GetAlpha(Vector2F start, Vector2F end, Vector2F point) => (point - start).LengthSquared() / (end - start).LengthSquared();

        /// <summary>
        ///     Returns the coefficient of a simplex.
        /// </summary>
        /// <remarks>Used by method <c>CalculateSimplicalChain()</c>.</remarks>
        private static float CalculateSimplexCoefficient(Vector2F a, Vector2F b, Vector2F c)
        {
            float isLeft = MathUtils.Area(ref a, ref b, ref c);
            if (isLeft < 0f)
            {
                return -1f;
            }

            if (isLeft > 0f)
            {
                return 1f;
            }

            return 0f;
        }

        /// <summary>
        ///     Winding number test for a point in a simplex.
        /// </summary>
        /// <param name="point">The point to be tested.</param>
        /// <param name="edge">The edge that the point is tested against.</param>
        /// <returns>
        ///     False if the winding number is even and the point is outside
        ///     the simplex and True otherwise.
        /// </returns>
        private static bool PointInSimplex(Vector2F point, Edge edge)
        {
            Vertices polygon = new Vertices();
            polygon.Add(Vector2F.Zero);
            polygon.Add(edge.EdgeStart);
            polygon.Add(edge.EdgeEnd);
            return polygon.PointInPolygon(ref point) == 1;
        }

        /// <summary>
        ///     Tests if a point lies on a line segment.
        /// </summary>
        /// <remarks>Used by method <c>CalculateBeta()</c>.</remarks>
        private static bool PointOnLineSegment(Vector2F start, Vector2F end, Vector2F point)
        {
            Vector2F segment = end - start;
            return (Math.Abs(MathUtils.Area(ref start, ref end, ref point)) < float.Epsilon) &&
                   (Vector2F.Dot(point - start, segment) >= 0f) &&
                   (Vector2F.Dot(point - end, segment) <= 0f);
        }

        /// <summary>
        ///     Describes whether vector equal
        /// </summary>
        /// <param name="vec1">The vec</param>
        /// <param name="vec2">The vec</param>
        /// <returns>The bool</returns>
        private static bool VectorEqual(Vector2F vec1, Vector2F vec2) => (vec2 - vec1).LengthSquared() <= ClipperEpsilonSquared;


        /// <summary>Specifies an Edge. Edges are used to represent simplicies in simplical chains</summary>
        private sealed class Edge
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Edge" /> class
            /// </summary>
            /// <param name="edgeStart">The edge start</param>
            /// <param name="edgeEnd">The edge end</param>
            public Edge(Vector2F edgeStart, Vector2F edgeEnd)
            {
                EdgeStart = edgeStart;
                EdgeEnd = edgeEnd;
            }

            /// <summary>
            ///     Gets the value of the edge start
            /// </summary>
            public Vector2F EdgeStart { get; }

            /// <summary>
            ///     Gets the value of the edge end
            /// </summary>
            public Vector2F EdgeEnd { get; }

            /// <summary>
            ///     Gets the center
            /// </summary>
            /// <returns>The vector</returns>
            public Vector2F GetCenter() => (EdgeStart + EdgeEnd) / 2f;

            public static Edge operator -(Edge e) => new Edge(e.EdgeEnd, e.EdgeStart);

            /// <summary>
            ///     Describes whether this instance equals
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The bool</returns>
            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                return Equals(obj as Edge);
            }

            /// <summary>
            ///     Describes whether this instance equals
            /// </summary>
            /// <param name="e">The </param>
            /// <returns>The bool</returns>
            public bool Equals(Edge e)
            {
                // If parameter is null return false:
                if (e == null)
                {
                    return false;
                }

                // Return true if the fields match
                return VectorEqual(EdgeStart, e.EdgeStart) && VectorEqual(EdgeEnd, e.EdgeEnd);
            }

            /// <summary>
            ///     Gets the hash code
            /// </summary>
            /// <returns>The int</returns>
            public override int GetHashCode() => EdgeStart.GetHashCode() ^ EdgeEnd.GetHashCode();
        }
    }
}