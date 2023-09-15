// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposer.cs
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

namespace Alis.Core.Physic.Tools.Triangulation.EarClip
{
    /// <summary>
    ///     Convex decomposition algorithm using ear clipping
    ///     Properties:
    ///     - Only works on simple polygons.
    ///     - Does not support holes.
    ///     - Running time is O(n^2), n = number of vertices.
    /// </summary>
    internal static class EarClipDecomposer
    {
        /// <summary>
        ///     Decompose the polygon into several smaller non-concave polygon. Each resulting polygon will have no more than
        ///     Settings.MaxPolygonVertices vertices.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="tolerance">The tolerance.</param>
        public static List<Vertices> ConvexPartition(Vertices vertices, float tolerance = 0.001f)
        {
            Debug.Assert(vertices.Count > 3);
            Debug.Assert(!vertices.IsCounterClockWise());

            return TriangulatePolygon(vertices, tolerance);
        }

        /// <summary>
        ///     Triangulates a polygon using simple ear-clipping algorithm. Returns size of Triangle array unless the polygon
        ///     can't be triangulated. This should only happen if the polygon self-intersects, though it will not _always_ return
        ///     null
        ///     for a bad polygon - it is the caller's responsibility to check for self-intersection, and if it doesn't, it should
        ///     at
        ///     least check that the return value is non-null before using. You're warned! Triangles may be degenerate, especially
        ///     if
        ///     you have identical points in the input to the algorithm.  Check this before you use them. This is totally
        ///     unoptimized,
        ///     so for large polygons it should not be part of the simulation loop.
        /// </summary>
        /// <remarks>Only works on simple polygons.</remarks>
        private static List<Vertices> TriangulatePolygon(Vertices vertices, float tolerance)
        {
            //Velcro note: Check is needed as invalid triangles can be returned in recursive calls.
            if (vertices.Count < 3)
            {
                return new List<Vertices>();
            }

            List<Vertices> results = new List<Vertices>();

            //Recurse and split on pinch points
            Vertices pin = new Vertices(vertices);
            if (ResolvePinchPoint(pin, out Vertices pA, out Vertices pB, tolerance))
            {
                List<Vertices> mergeA = TriangulatePolygon(pA, tolerance);
                List<Vertices> mergeB = TriangulatePolygon(pB, tolerance);

                if (mergeA.Count == 0 || mergeB.Count == 0)
                {
                    throw new Exception("Can't triangulate your polygon.");
                }

                for (int i = 0; i < mergeA.Count; ++i)
                {
                    results.Add(new Vertices(mergeA[i]));
                }

                for (int i = 0; i < mergeB.Count; ++i)
                {
                    results.Add(new Vertices(mergeB[i]));
                }

                return results;
            }

            Vertices[] buffer = new Vertices[vertices.Count - 2];
            int bufferSize = 0;
            float[] xRem = new float[vertices.Count];
            float[] yRem = new float[vertices.Count];
            for (int i = 0; i < vertices.Count; ++i)
            {
                xRem[i] = vertices[i].X;
                yRem[i] = vertices[i].Y;
            }

            int vNum = vertices.Count;

            while (vNum > 3)
            {
                // Find an ear
                int earIndex = -1;
                float earMaxMinCross = -10.0f;
                for (int i = 0; i < vNum; ++i)
                {
                    if (IsEar(i, xRem, yRem, vNum))
                    {
                        int lower = Remainder(i - 1, vNum);
                        int upper = Remainder(i + 1, vNum);
                        Vector2 d1 = new Vector2(xRem[upper] - xRem[i], yRem[upper] - yRem[i]);
                        Vector2 d2 = new Vector2(xRem[i] - xRem[lower], yRem[i] - yRem[lower]);
                        Vector2 d3 = new Vector2(xRem[lower] - xRem[upper], yRem[lower] - yRem[upper]);

                        d1 = Vector2.Normalize(d1);
                        d2 = Vector2.Normalize(d2);
                        d3 = Vector2.Normalize(d3);
                        MathUtils.Cross(ref d1, ref d2, out float cross12);
                        cross12 = Math.Abs(cross12);

                        MathUtils.Cross(ref d2, ref d3, out float cross23);
                        cross23 = Math.Abs(cross23);

                        MathUtils.Cross(ref d3, ref d1, out float cross31);
                        cross31 = Math.Abs(cross31);

                        //Find the maximum minimum angle
                        float minCross = Math.Min(cross12, Math.Min(cross23, cross31));
                        if (minCross > earMaxMinCross)
                        {
                            earIndex = i;
                            earMaxMinCross = minCross;
                        }
                    }
                }

                // If we still haven't found an ear, we're screwed.
                // Note: sometimes this is happening because the
                // remaining points are collinear.  Really these
                // should just be thrown out without halting triangulation.
                if (earIndex == -1)
                {
                    for (int i = 0; i < bufferSize; i++)
                    {
                        results.Add(buffer[i]);
                    }

                    return results;
                }

                // Clip off the ear:
                // - remove the ear tip from the list

                --vNum;
                float[] newX = new float[vNum];
                float[] newY = new float[vNum];
                int currDest = 0;
                for (int i = 0; i < vNum; ++i)
                {
                    if (currDest == earIndex)
                    {
                        ++currDest;
                    }

                    newX[i] = xRem[currDest];
                    newY[i] = yRem[currDest];
                    ++currDest;
                }

                // - add the clipped triangle to the triangle list
                int under = earIndex == 0 ? vNum : earIndex - 1;
                int over = earIndex == vNum ? 0 : earIndex + 1;
                Triangle toAdd = new Triangle(xRem[earIndex], yRem[earIndex], xRem[over], yRem[over], xRem[under],
                    yRem[under]);
                buffer[bufferSize] = toAdd;
                ++bufferSize;

                // - replace the old list with the new one
                xRem = newX;
                yRem = newY;
            }

            Triangle tooAdd = new Triangle(xRem[1], yRem[1], xRem[2], yRem[2], xRem[0], yRem[0]);
            buffer[bufferSize] = tooAdd;
            ++bufferSize;

            for (int i = 0; i < bufferSize; i++)
            {
                results.Add(new Vertices(buffer[i]));
            }

            return results;
        }

        /// <summary>
        /// Finds and fixes "pinch points," points where two polygon vertices are at the same point.
        /// </summary>
        /// <param name="pin">The pin.</param>
        /// <param name="poutA">The pout A.</param>
        /// <param name="poutB">The pout B.</param>
        /// <param name="tolerance">The tolerance for point comparison.</param>
        /// <returns>True if a pinch point is found and resolved, false otherwise.</returns>
        private static bool ResolvePinchPoint(Vertices pin, out Vertices poutA, out Vertices poutB, float tolerance)
        {
            poutA = new Vertices();
            poutB = new Vertices();

            if (pin.Count < 3)
            {
                return false;
            }

            if (FindPinchPoint(pin, tolerance, out int pinchIndexA, out int pinchIndexB))
            {
                if (SplitVertices(pin, pinchIndexA, pinchIndexB, poutA, poutB))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds a pinch point in the vertices.
        /// </summary>
        /// <param name="vertices">The vertices to search.</param>
        /// <param name="tolerance">The tolerance for point comparison.</param>
        /// <param name="pinchIndexA">The index of the first vertex in the pinch point.</param>
        /// <param name="pinchIndexB">The index of the second vertex in the pinch point.</param>
        /// <returns>True if a pinch point is found, false otherwise.</returns>
        private static bool FindPinchPoint(Vertices vertices, float tolerance, out int pinchIndexA, out int pinchIndexB)
        {
            pinchIndexA = -1;
            pinchIndexB = -1;

            for (int i = 0; i < vertices.Count; ++i)
            {
                for (int j = i + 1; j < vertices.Count; ++j)
                {
                    if (IsPinchPoint(vertices[i], vertices[j], tolerance))
                    {
                        pinchIndexA = i;
                        pinchIndexB = j;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines if two vertices form a pinch point within the given tolerance.
        /// </summary>
        /// <param name="vertexA">The first vertex.</param>
        /// <param name="vertexB">The second vertex.</param>
        /// <param name="tolerance">The tolerance for point comparison.</param>
        /// <returns>True if the vertices form a pinch point, false otherwise.</returns>
        private static bool IsPinchPoint(Vector2 vertexA, Vector2 vertexB, float tolerance)
        {
            return (Math.Abs(vertexA.X - vertexB.X) < tolerance) &&
                   (Math.Abs(vertexA.Y - vertexB.Y) < tolerance);
        }

        /// <summary>
        /// Splits the vertices at the pinch point.
        /// </summary>
        /// <param name="pin">The vertices to split.</param>
        /// <param name="pinchIndexA">The index of the first vertex in the pinch point.</param>
        /// <param name="pinchIndexB">The index of the second vertex in the pinch point.</param>
        /// <param name="poutA">The output vertices A.</param>
        /// <param name="poutB">The output vertices B.</param>
        /// <returns>True if the vertices are split successfully, false otherwise.</returns>
        private static bool SplitVertices(Vertices pin, int pinchIndexA, int pinchIndexB, Vertices poutA, Vertices poutB)
        {
            int sizeA = pinchIndexB - pinchIndexA;

            if (sizeA == pin.Count)
            {
                return false; // Duplicate points at wraparound, not a problem here
            }

            for (int i = 0; i < sizeA; ++i)
            {
                int ind = RemainderLocal(pinchIndexA + i, pin.Count);
                poutA.Add(pin[ind]);
            }

            int sizeB = pin.Count - sizeA;
            for (int i = 0; i < sizeB; ++i)
            {
                int ind = RemainderLocal(pinchIndexB + i, pin.Count);
                poutB.Add(pin[ind]);
            }

            return true;
        }

        /// <summary>
        /// Calculates the remainder of division, handling negative values correctly.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The remainder of the division.</returns>
        private static int RemainderLocal(int dividend, int divisor)
        {
            return (dividend % divisor + divisor) % divisor;
        }


        /// <summary>Fix for obnoxious behavior for the % operator for negative numbers...</summary>
        /// <param name="x">The x.</param>
        /// <param name="modulus">The modulus.</param>
        /// <returns></returns>
        private static int Remainder(int x, int modulus)
        {
            int rem = x % modulus;
            while (rem < 0)
            {
                rem += modulus;
            }

            return rem;
        }

        /// <summary>Checks if vertex i is the tip of an ear in polygon defined by xv[] and  yv[].</summary>
        /// <param name="i">The i.</param>
        /// <param name="xv">The xv.</param>
        /// <param name="yv">The yv.</param>
        /// <param name="xvLength">Length of the xv.</param>
        /// <remarks>Assumes clockwise orientation of polygon.</remarks>
        /// <returns><c>true</c> if the specified i is ear; otherwise, <c>false</c>.</returns>
        private static bool IsEar(int i, float[] xv, float[] yv, int xvLength)
        {
            float dx0, dy0, dx1, dy1;
            if (i >= xvLength || i < 0 || xvLength < 3)
            {
                return false;
            }

            int upper = i + 1;
            int lower = i - 1;
            if (i == 0)
            {
                dx0 = xv[0] - xv[xvLength - 1];
                dy0 = yv[0] - yv[xvLength - 1];
                dx1 = xv[1] - xv[0];
                dy1 = yv[1] - yv[0];
                lower = xvLength - 1;
            }
            else if (i == xvLength - 1)
            {
                dx0 = xv[i] - xv[i - 1];
                dy0 = yv[i] - yv[i - 1];
                dx1 = xv[0] - xv[i];
                dy1 = yv[0] - yv[i];
                upper = 0;
            }
            else
            {
                dx0 = xv[i] - xv[i - 1];
                dy0 = yv[i] - yv[i - 1];
                dx1 = xv[i + 1] - xv[i];
                dy1 = yv[i + 1] - yv[i];
            }

            float cross = dx0 * dy1 - dx1 * dy0;

            if (cross > 0)
            {
                return false;
            }

            Triangle myTri = new Triangle(xv[i], yv[i], xv[upper], yv[upper], xv[lower], yv[lower]);

            for (int j = 0; j < xvLength; ++j)
            {
                if (j == i || j == lower || j == upper)
                {
                    continue;
                }

                if (myTri.IsInside(xv[j], yv[j]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}