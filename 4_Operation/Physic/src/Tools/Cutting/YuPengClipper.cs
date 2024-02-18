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

using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools.Cutting.Simple;
using Alis.Core.Physic.Tools.PolygonManipulation;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.Cutting
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
        public static List<Vertices> Union(Vertices polygon1, Vertices polygon2, out PolyClipError error) =>
            Execute(polygon1, polygon2, PolyClipType.Union, out error);

        /// <summary>
        ///     Differences the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Difference(Vertices polygon1, Vertices polygon2, out PolyClipError error) =>
            Execute(polygon1, polygon2, PolyClipType.Difference, out error);

        /// <summary>
        ///     Intersects the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Intersect(Vertices polygon1, Vertices polygon2, out PolyClipError error) =>
            Execute(polygon1, polygon2, PolyClipType.Intersect, out error);

        /// <summary>
        ///     Implements "A new algorithm for Boolean operations on general polygons" available here:
        ///     http://liama.ia.ac.cn/wiki/_media/user:dong:dong_cg_05.pdf Merges two polygons, a subject and a clip with the
        ///     specified
        ///     operation. Polygons may not be self-intersecting. Warning: May yield incorrect results or even crash if polygons
        ///     contain collinear points.
        /// </summary>
        /// <param name="subject">The subject polygon.</param>
        /// <param name="clip">The clip polygon, which is added, substracted or intersected with the subject</param>
        /// <param name="clipType">The operation to be performed. Either Union, Difference or Intersection.</param>
        /// <param name="error">The error generated (if any)</param>
        /// <returns>
        ///     A list of closed polygons, which make up the result of the clipping operation. Outer contours are ordered
        ///     counter clockwise, holes are ordered clockwise.
        /// </returns>
        private static List<Vertices> Execute(Vertices subject, Vertices clip, PolyClipType clipType,
            out PolyClipError error)
        {
            Debug.Assert(subject.IsSimple() && clip.IsSimple(), "Non simple input!",
                "Input polygons must be simple (cannot intersect themselves).");

            // Copy polygons

            // Calculate the intersection and touch points between
            // subject and clip and add them to both
            CalculateIntersections(subject, clip, out Vertices slicedSubject, out Vertices slicedClip);

            // Translate polygons into upper right quadrant
            // as the algorithm depends on it
            Vector2 lbSubject = subject.GetAabb().LowerBound;
            Vector2 lbClip = clip.GetAabb().LowerBound;
            Vector2 translate = Vector2.Min(lbSubject, lbClip);
            translate = Vector2.One - translate;
            if (translate != Vector2.Zero)
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
        /// Calculates the intersections using the specified polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="slicedPoly1">The sliced poly</param>
        /// <param name="slicedPoly2">The sliced poly</param>
        private static void CalculateIntersections(Vertices polygon1, Vertices polygon2, out Vertices slicedPoly1,
            out Vertices slicedPoly2)
        {
            slicedPoly1 = new Vertices(polygon1);
            slicedPoly2 = new Vertices(polygon2);

            // Iterate through polygon1's edges
            for (int i = 0; i < polygon1.Count; i++)
            {
                // Get edge vertices
                Vector2 a = polygon1[i];
                Vector2 b = polygon1[polygon1.NextIndex(i)];

                // Get intersections between this edge and polygon2
                for (int j = 0; j < polygon2.Count; j++)
                {
                    Vector2 c = polygon2[j];
                    Vector2 d = polygon2[polygon2.NextIndex(j)];

                    CalculateIntersectionsBetweenEdges(a, b, c, d, ref slicedPoly1, ref slicedPoly2);
                }
            }

            RemoveSmallEdges(ref slicedPoly1);
            RemoveSmallEdges(ref slicedPoly2);
        }

        /// <summary>
        /// Calculates the intersections between edges using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="slicedPoly1">The sliced poly</param>
        /// <param name="slicedPoly2">The sliced poly</param>
        private static void CalculateIntersectionsBetweenEdges(Vector2 a, Vector2 b, Vector2 c, Vector2 d, ref Vertices slicedPoly1, ref Vertices slicedPoly2)
        {
            // Check if the edges intersect
            if (Line.LineIntersect(a, b, c, d, true, true, out Vector2 intersectionPoint))
            {
                // calculate alpha values for sorting multiple intersections points on a edge
                float alpha = GetAlpha(a, b, intersectionPoint);

                // Insert intersection point into first polygon
                if ((alpha > 0f) && (alpha < 1f))
                {
                    InsertIntersectionPointIntoPolygon(a, b, intersectionPoint, ref slicedPoly1);
                }

                // Insert intersection point into second polygon
                alpha = GetAlpha(c, d, intersectionPoint);
                if ((alpha > 0f) && (alpha < 1f))
                {
                    InsertIntersectionPointIntoPolygon(c, d, intersectionPoint, ref slicedPoly2);
                }
            }
        }

        /// <summary>
        /// Inserts the intersection point into polygon using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="intersectionPoint">The intersection point</param>
        /// <param name="slicedPoly">The sliced poly</param>
        private static void InsertIntersectionPointIntoPolygon(Vector2 a, Vector2 b, Vector2 intersectionPoint, ref Vertices slicedPoly)
        {
            int index = slicedPoly.IndexOf(a) + 1;
            while ((index < slicedPoly.Count) &&
                   (GetAlpha(a, b, slicedPoly[index]) <= GetAlpha(a, b, intersectionPoint)))
            {
                ++index;
            }

            slicedPoly.Insert(index, intersectionPoint);
        }

        /// <summary>
        /// Removes the small edges using the specified sliced poly
        /// </summary>
        /// <param name="slicedPoly">The sliced poly</param>
        private static void RemoveSmallEdges(ref Vertices slicedPoly)
        {
            // Check for very small edges
            for (int i = 0; i < slicedPoly.Count; ++i)
            {
                int iNext = slicedPoly.NextIndex(i);

                //If they are closer than the distance remove vertex
                if ((slicedPoly[iNext] - slicedPoly[i]).LengthSquared() <= ClipperEpsilonSquared)
                {
                    slicedPoly.RemoveAt(i);
                    --i;
                }
            }
        }

        /// <summary>Calculates the simplical chain corresponding to the input polygon.</summary>
        /// <remarks>Used by method <c>Execute()</c>.</remarks>
        private static void CalculateSimplicalChain(Vertices poly, out List<float> coeff, out List<Edge> simplicies)
        {
            simplicies = new List<Edge>();
            coeff = new List<float>();
            for (int i = 0; i < poly.Count; ++i)
            {
                simplicies.Add(new Edge(poly[i], poly[poly.NextIndex(i)]));
                coeff.Add(CalculateSimplexCoefficient(Vector2.Zero, poly[i], poly[poly.NextIndex(i)]));
            }
        }

        /// <summary>
        /// Calculates the result chain using the specified poly 1 coeff
        /// </summary>
        /// <param name="poly1Coeff">The poly coeff</param>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="poly2Coeff">The poly coeff</param>
        /// <param name="poly2Simplicies">The poly simplicies</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="resultSimplices">The result simplices</param>
        private static void CalculateResultChain(List<float> poly1Coeff, List<Edge> poly1Simplicies,
            List<float> poly2Coeff, List<Edge> poly2Simplicies, PolyClipType clipType, out List<Edge> resultSimplices)
        {
            resultSimplices = new List<Edge>();

            CalculateEdgeCharacterForPoly1(poly1Coeff, poly1Simplicies, poly2Simplicies, clipType, resultSimplices);
            CalculateEdgeCharacterForPoly2(poly1Simplicies, poly2Coeff, poly2Simplicies, clipType, resultSimplices);
        }

        /// <summary>
        /// Calculates the edge character for poly 1 using the specified poly 1 coeff
        /// </summary>
        /// <param name="poly1Coeff">The poly coeff</param>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="poly2Simplicies">The poly simplicies</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="resultSimplices">The result simplices</param>
        private static void CalculateEdgeCharacterForPoly1(List<float> poly1Coeff, List<Edge> poly1Simplicies,
            List<Edge> poly2Simplicies, PolyClipType clipType, List<Edge> resultSimplices)
        {
            for (int i = 0; i < poly1Simplicies.Count; ++i)
            {
                float edgeCharacter = CalculateEdgeCharacter(i, poly1Simplicies, poly2Simplicies, clipType, poly1Coeff);
                AddEdgeToResult(edgeCharacter, clipType, poly1Simplicies[i], resultSimplices);
            }
        }

        /// <summary>
        /// Calculates the edge character using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="poly2Simplicies">The poly simplicies</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="poly1Coeff">The poly coeff</param>
        /// <returns>The edge character</returns>
        private static float CalculateEdgeCharacter(int i, List<Edge> poly1Simplicies, List<Edge> poly2Simplicies, PolyClipType clipType, List<float> poly1Coeff)
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
                edgeCharacter = CalculateEdgeCharacterForNonContainedEdges(i, poly1Simplicies, poly2Simplicies, poly1Coeff);
            }

            return edgeCharacter;
        }

        /// <summary>
        /// Calculates the edge character for non contained edges using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="poly2Simplicies">The poly simplicies</param>
        /// <param name="poly1Coeff">The poly coeff</param>
        /// <returns>The edge character</returns>
        private static float CalculateEdgeCharacterForNonContainedEdges(int i, List<Edge> poly1Simplicies, List<Edge> poly2Simplicies, List<float> poly1Coeff)
        {
            float edgeCharacter = 0;
            for (int j = 0; j < poly2Simplicies.Count; ++j)
            {
                if (!poly2Simplicies.Contains(-poly1Simplicies[i]))
                {
                    edgeCharacter += CalculateBeta(poly1Simplicies[i].GetCenter(),
                        poly2Simplicies[j], poly1Coeff[j]);
                }
            }

            return edgeCharacter;
        }

        /// <summary>
        /// Adds the edge to result using the specified edge character
        /// </summary>
        /// <param name="edgeCharacter">The edge character</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="edge">The edge</param>
        /// <param name="resultSimplices">The result simplices</param>
        private static void AddEdgeToResult(float edgeCharacter, PolyClipType clipType, Edge edge, List<Edge> resultSimplices)
        {
            if (clipType == PolyClipType.Intersect)
            {
                if (edgeCharacter == 1f)
                {
                    resultSimplices.Add(edge);
                }
            }
            else
            {
                if (edgeCharacter == 0f)
                {
                    resultSimplices.Add(edge);
                }
            }
        }

        /// <summary>
        /// Calculates the edge character for poly 2 using the specified poly 1 simplicies
        /// </summary>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="poly2Coeff">The poly coeff</param>
        /// <param name="poly2Simplicies">The poly simplicies</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="resultSimplices">The result simplices</param>
        private static void CalculateEdgeCharacterForPoly2(List<Edge> poly1Simplicies, List<float> poly2Coeff,
            List<Edge> poly2Simplicies, PolyClipType clipType, List<Edge> resultSimplices)
        {
            for (int i = 0; i < poly2Simplicies.Count; ++i)
            {
                if (!IsContainedInResultSimplices(resultSimplices, poly2Simplicies[i]))
                {
                    float edgeCharacter = CalculateEdgeCharacter(poly1Simplicies, poly2Simplicies[i], clipType);
                    edgeCharacter += CalculateEdgeCharacterForNonContainedEdges(poly1Simplicies, poly2Simplicies[i], poly2Coeff);
                    AddEdgeToResultSimplices(edgeCharacter, clipType, poly2Simplicies[i], resultSimplices);
                }
            }
        }

        /// <summary>
        /// Describes whether is contained in result simplices
        /// </summary>
        /// <param name="resultSimplices">The result simplices</param>
        /// <param name="edge">The edge</param>
        /// <returns>The bool</returns>
        private static bool IsContainedInResultSimplices(List<Edge> resultSimplices, Edge edge)
        {
            return resultSimplices.Contains(edge) || resultSimplices.Contains(-edge);
        }

        /// <summary>
        /// Calculates the edge character using the specified poly 1 simplicies
        /// </summary>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="edge">The edge</param>
        /// <param name="clipType">The clip type</param>
        /// <returns>The float</returns>
        private static float CalculateEdgeCharacter(List<Edge> poly1Simplicies, Edge edge, PolyClipType clipType)
        {
            return poly1Simplicies.Contains(-edge) && (clipType == PolyClipType.Union) ? 1f : 0f;
        }

        /// <summary>
        /// Calculates the edge character for non contained edges using the specified poly 1 simplicies
        /// </summary>
        /// <param name="poly1Simplicies">The poly simplicies</param>
        /// <param name="edge">The edge</param>
        /// <param name="poly2Coeff">The poly coeff</param>
        /// <returns>The edge character</returns>
        private static float CalculateEdgeCharacterForNonContainedEdges(List<Edge> poly1Simplicies, Edge edge, List<float> poly2Coeff)
        {
            float edgeCharacter = 0f;
            for (int j = 0; j < poly1Simplicies.Count; ++j)
            {
                if (!poly1Simplicies.Contains(edge) && !poly1Simplicies.Contains(-edge))
                {
                    edgeCharacter += CalculateBeta(edge.GetCenter(), poly1Simplicies[j], poly2Coeff[j]);
                }
            }

            return edgeCharacter;
        }

        /// <summary>
        /// Adds the edge to result simplices using the specified edge character
        /// </summary>
        /// <param name="edgeCharacter">The edge character</param>
        /// <param name="clipType">The clip type</param>
        /// <param name="edge">The edge</param>
        /// <param name="resultSimplices">The result simplices</param>
        private static void AddEdgeToResultSimplices(float edgeCharacter, PolyClipType clipType, Edge edge, List<Edge> resultSimplices)
        {
            if (clipType == PolyClipType.Intersect || clipType == PolyClipType.Difference)
            {
                if (edgeCharacter == 1f)
                {
                    resultSimplices.Add(-edge);
                }
            }
            else
            {
                if (edgeCharacter == 0f)
                {
                    resultSimplices.Add(edge);
                }
            }
        }

        /// <summary>
        /// Builds the polygons from chain using the specified simplicies
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="result">The result</param>
        /// <returns>The err val</returns>
        private static PolyClipError BuildPolygonsFromChain(List<Edge> simplicies, out List<Vertices> result)
        {
            result = new List<Vertices>();
            PolyClipError errVal = PolyClipError.None;

            while (simplicies.Count > 0)
            {
                Vertices output = CreateOutputVertices(simplicies);
                bool closed = false;
                int index = 0;
                int count = simplicies.Count; // Needed to catch infinite loops

                closed = ProcessSimplicies(simplicies, output, closed, ref index, count);

                errVal = AddOutputToResult(output, result, errVal);
            }

            return errVal;
        }

        /// <summary>
        /// Creates the output vertices using the specified simplicies
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <returns>The vertices</returns>
        private static Vertices CreateOutputVertices(List<Edge> simplicies)
        {
            return new Vertices
            {
                simplicies[0].EdgeStart,
                simplicies[0].EdgeEnd
            };
        }

        /// <summary>
        /// Describes whether process simplicies
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="output">The output</param>
        /// <param name="closed">The closed</param>
        /// <param name="index">The index</param>
        /// <param name="count">The count</param>
        /// <returns>The closed</returns>
        private static bool ProcessSimplicies(List<Edge> simplicies, Vertices output, bool closed, ref int index, int count)
        {
            while (!closed && (simplicies.Count > 0))
            {
                closed = ProcessEdgeStart(simplicies, output, closed, ref index);
                if (!closed)
                {
                    closed = ProcessEdgeEnd(simplicies, output, closed, ref index);
                }

                if (!closed)
                {
                    index = UpdateIndex(simplicies, index, count);
                }
            }

            return closed;
        }

        /// <summary>
        /// Describes whether process edge start
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="output">The output</param>
        /// <param name="closed">The closed</param>
        /// <param name="index">The index</param>
        /// <returns>The closed</returns>
        private static bool ProcessEdgeStart(List<Edge> simplicies, Vertices output, bool closed, ref int index)
        {
            if (VectorEqual(output[output.Count - 1], simplicies[index].EdgeStart))
            {
                closed = CheckAndAddEdgeEnd(simplicies, output, index);
                simplicies.RemoveAt(index);
                --index;
            }

            return closed;
        }

        /// <summary>
        /// Describes whether process edge end
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="output">The output</param>
        /// <param name="closed">The closed</param>
        /// <param name="index">The index</param>
        /// <returns>The closed</returns>
        private static bool ProcessEdgeEnd(List<Edge> simplicies, Vertices output, bool closed, ref int index)
        {
            if (VectorEqual(output[output.Count - 1], simplicies[index].EdgeEnd))
            {
                closed = CheckAndAddEdgeStart(simplicies, output, index);
                simplicies.RemoveAt(index);
                --index;
            }

            return closed;
        }

        /// <summary>
        /// Describes whether check and add edge end
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="output">The output</param>
        /// <param name="index">The index</param>
        /// <returns>The bool</returns>
        private static bool CheckAndAddEdgeEnd(List<Edge> simplicies, Vertices output, int index)
        {
            if (VectorEqual(simplicies[index].EdgeEnd, output[0]))
            {
                return true;
            }
            else
            {
                output.Add(simplicies[index].EdgeEnd);
                return false;
            }
        }

        /// <summary>
        /// Describes whether check and add edge start
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="output">The output</param>
        /// <param name="index">The index</param>
        /// <returns>The bool</returns>
        private static bool CheckAndAddEdgeStart(List<Edge> simplicies, Vertices output, int index)
        {
            if (VectorEqual(simplicies[index].EdgeStart, output[0]))
            {
                return true;
            }
            else
            {
                output.Add(simplicies[index].EdgeStart);
                return false;
            }
        }

        /// <summary>
        /// Updates the index using the specified simplicies
        /// </summary>
        /// <param name="simplicies">The simplicies</param>
        /// <param name="index">The index</param>
        /// <param name="count">The count</param>
        /// <returns>The index</returns>
        private static int UpdateIndex(List<Edge> simplicies, int index, int count)
        {
            if (++index == simplicies.Count)
            {
                if (count == simplicies.Count)
                {
                    return 0;
                }

                index = 0;
            }

            return index;
        }

        /// <summary>
        /// Adds the output to result using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="result">The result</param>
        /// <param name="errVal">The err val</param>
        /// <returns>The err val</returns>
        private static PolyClipError AddOutputToResult(Vertices output, List<Vertices> result, PolyClipError errVal)
        {
            if (output.Count < 3)
            {
                errVal = PolyClipError.DegeneratedOutput;
                Logger.Log("Degenerated output polygon produced (vertices < 3).");
            }

            result.Add(output);

            return errVal;
        }

        /// <summary>Needed to calculate the characteristics function of a simplex.</summary>
        /// <remarks>Used by method <c>CalculateEdgeCharacter()</c>.</remarks>
        private static float CalculateBeta(Vector2 point, Edge e, float coefficient)
        {
            float result = 0f;
            if (PointInSimplex(point, e))
            {
                result = coefficient;
            }

            if (PointOnLineSegment(Vector2.Zero, e.EdgeStart, point) ||
                PointOnLineSegment(Vector2.Zero, e.EdgeEnd, point))
            {
                result = .5f * coefficient;
            }

            return result;
        }

        /// <summary>Needed for sorting multiple intersections points on the same edge.</summary>
        /// <remarks>Used by method <c>CalculateIntersections()</c>.</remarks>
        private static float GetAlpha(Vector2 start, Vector2 end, Vector2 point) =>
            (point - start).LengthSquared() / (end - start).LengthSquared();

        /// <summary>Returns the coefficient of a simplex.</summary>
        /// <remarks>Used by method <c>CalculateSimplicalChain()</c>.</remarks>
        private static float CalculateSimplexCoefficient(Vector2 a, Vector2 b, Vector2 c)
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

        /// <summary>Winding number test for a point in a simplex.</summary>
        /// <param name="point">The point to be tested.</param>
        /// <param name="edge">The edge that the point is tested against.</param>
        /// <returns>False if the winding number is even and the point is outside the simplex and True otherwise.</returns>
        private static bool PointInSimplex(Vector2 point, Edge edge)
        {
            Vertices polygon = new Vertices
            {
                Vector2.Zero,
                edge.EdgeStart,
                edge.EdgeEnd
            };
            return polygon.PointInPolygon(ref point) == 1;
        }

        /// <summary>Tests if a point lies on a line segment.</summary>
        /// <remarks>Used by method <c>CalculateBeta()</c>.</remarks>
        private static bool PointOnLineSegment(Vector2 start, Vector2 end, Vector2 point)
        {
            Vector2 segment = end - start;
            return (MathUtils.Area(ref start, ref end, ref point) == 0f) &&
                   (Vector2.Dot(point - start, segment) >= 0f) &&
                   (Vector2.Dot(point - end, segment) <= 0f);
        }

        /// <summary>
        ///     Describes whether vector equal
        /// </summary>
        /// <param name="vec1">The vec</param>
        /// <param name="vec2">The vec</param>
        /// <returns>The bool</returns>
        private static bool VectorEqual(Vector2 vec1, Vector2 vec2) =>
            (vec2 - vec1).LengthSquared() <= ClipperEpsilonSquared;

        /// <summary>Specifies an Edge. Edges are used to represent simplicies in simplical chains</summary>
        private sealed class Edge
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Edge" /> class
            /// </summary>
            /// <param name="edgeStart">The edge start</param>
            /// <param name="edgeEnd">The edge end</param>
            public Edge(Vector2 edgeStart, Vector2 edgeEnd)
            {
                EdgeStart = edgeStart;
                EdgeEnd = edgeEnd;
            }

            /// <summary>
            ///     Gets or sets the value of the edge start
            /// </summary>
            public Vector2 EdgeStart { get; }

            /// <summary>
            ///     Gets or sets the value of the edge end
            /// </summary>
            public Vector2 EdgeEnd { get; }

            /// <summary>
            ///     Gets the center
            /// </summary>
            /// <returns>The vector</returns>
            public Vector2 GetCenter() => (EdgeStart + EdgeEnd) / 2f;

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