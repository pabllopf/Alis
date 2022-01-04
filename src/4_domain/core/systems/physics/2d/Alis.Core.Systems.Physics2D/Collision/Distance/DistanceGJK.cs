// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DistanceGJK.cs
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

using System;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Narrowphase;
using Alis.Core.Systems.Physics2D.Config;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Shared.Optimization;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Collision.Distance
{
    /// <summary>
    ///     The Gilbert–Johnson–Keerthi distance algorithm that provides the distance between shapes. Using Voronoi
    ///     regions (Christer Ericson) and Barycentric coordinates.
    /// </summary>
    public static class DistanceGjk
    {
        /// <summary>
        ///     The number of calls made to the ComputeDistance() function. Note: This is only activated when
        ///     Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkCalls;

        /// <summary>
        ///     The number of iterations that was made on the last call to ComputeDistance(). Note: This is only activated
        ///     when Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkIters;

        /// <summary>
        ///     The maximum number of iterations calls to the CompteDistance() function. Note: This is only activated when
        ///     Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkMaxIters;

        /// <summary>
        ///     Computes the distance using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        /// <param name="cache">The cache</param>
        public static void ComputeDistance(ref DistanceInput input, out DistanceOutput output, out SimplexCache cache)
        {
            cache = new SimplexCache();

            ++GjkCalls;

            // Initialize the simplex.
            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref input.ProxyA, ref input.TransformA, ref input.ProxyB,
                ref input.TransformB);

            // These store the vertices of the last simplex so that we
            // can check for duplicates and prevent cycling.
            FixedArray3<int> saveA = new FixedArray3<int>();
            FixedArray3<int> saveB = new FixedArray3<int>();

            // Main iteration loop.
            int iter = 0;

            //Velcro: Moved the max iterations to settings
            while (iter < Settings.MaxGjkIterations)
            {
                // Copy simplex so we can identify duplicates.
                int saveCount = simplex.Count;
                for (int i = 0; i < saveCount; ++i)
                {
                    saveA[i] = simplex.V[i].IndexA;
                    saveB[i] = simplex.V[i].IndexB;
                }

                switch (simplex.Count)
                {
                    case 1:
                        break;
                    case 2:
                        simplex.Solve2();
                        break;
                    case 3:
                        simplex.Solve3();
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }

                // If we have 3 points, then the origin is in the corresponding triangle.
                if (simplex.Count == 3)
                {
                    break;
                }

                // Get search direction.
                Vector2 d = simplex.GetSearchDirection();

                // Ensure the search direction is numerically fit.
                if (d.LengthSquared() < MathConstants.Epsilon * MathConstants.Epsilon)
                {
                    // The origin is probably contained by a line segment
                    // or triangle. Thus the shapes are overlapped.

                    // We can't return zero here even though there may be overlap.
                    // In case the simplex is a point, segment, or triangle it is difficult
                    // to determine if the origin is contained in the CSO or very close to it.
                    break;
                }

                // Compute a tentative new simplex vertex using support points.
                SimplexVertex vertex = simplex.V[simplex.Count];
                vertex.IndexA = input.ProxyA.GetSupport(MathUtils.MulT(input.TransformA.Q, -d));
                vertex.Wa = MathUtils.Mul(ref input.TransformA, input.ProxyA.Vertices[vertex.IndexA]);

                vertex.IndexB = input.ProxyB.GetSupport(MathUtils.MulT(input.TransformB.Q, d));
                vertex.Wb = MathUtils.Mul(ref input.TransformB, input.ProxyB.Vertices[vertex.IndexB]);
                vertex.W = vertex.Wb - vertex.Wa;
                simplex.V[simplex.Count] = vertex;

                // Iteration count is equated to the number of support point calls.
                ++iter;

                ++GjkIters;

                // Check for duplicate support points. This is the main termination criteria.
                bool duplicate = false;
                for (int i = 0; i < saveCount; ++i)
                {
                    if (vertex.IndexA == saveA[i] && vertex.IndexB == saveB[i])
                    {
                        duplicate = true;
                        break;
                    }
                }

                // If we found a duplicate support point we must exit to avoid cycling.
                if (duplicate)
                {
                    break;
                }

                // New vertex is OK and needed.
                ++simplex.Count;
            }

            GjkMaxIters = Math.Max(GjkMaxIters, iter);

            // Prepare output.
            simplex.GetWitnessPoints(out output.PointA, out output.PointB);
            output.Distance = (output.PointA - output.PointB).Length();
            output.Iterations = iter;

            // Cache the simplex.
            simplex.WriteCache(ref cache);

            // Apply radii if requested.
            if (input.UseRadii)
            {
                float rA = input.ProxyA.Radius;
                float rB = input.ProxyB.Radius;

                if (output.Distance > rA + rB && output.Distance > MathConstants.Epsilon)
                {
                    // Shapes are still no overlapped.
                    // Move the witness points to the outer surface.
                    output.Distance -= rA + rB;
                    Vector2 normal = output.PointB - output.PointA;
                    normal = Vector2.Normalize(normal);
                    output.PointA += rA * normal;
                    output.PointB -= rB * normal;
                }
                else
                {
                    // Shapes are overlapped when radii are considered.
                    // Move the witness points to the middle.
                    Vector2 p = 0.5f * (output.PointA + output.PointB);
                    output.PointA = p;
                    output.PointB = p;
                    output.Distance = 0.0f;
                }
            }
        }

        // GJK-raycast
        // Algorithm by Gino van den Bergen.
        // "Smooth Mesh Contacts with GJK" in Game Physics Pearls. 2010

        /// <summary>
        ///     Perform a linear shape cast of shape B moving and shape A fixed. Determines the hit point, normal, and
        ///     translation fraction.
        /// </summary>
        /// <returns>true if hit, false if there is no hit or an initial overlap</returns>
        public static bool ShapeCast(ref ShapeCastInput input, out ShapeCastOutput output)
        {
            output = new ShapeCastOutput
            {
                Iterations = 0,
                Lambda = 1.0f,
                Normal = Vector2.Zero,
                Point = Vector2.Zero
            };

            DistanceProxy proxyA = input.ProxyA;
            DistanceProxy proxyB = input.ProxyB;

            float radiusA = MathUtils.Max(proxyA.Radius, Settings.PolygonRadius);
            float radiusB = MathUtils.Max(proxyB.Radius, Settings.PolygonRadius);
            float radius = radiusA + radiusB;

            Transform xfA = input.TransformA;
            Transform xfB = input.TransformB;

            Vector2 r = input.TranslationB;
            Vector2 n = new Vector2(0.0f, 0.0f);
            float lambda = 0.0f;

            // Initial simplex
            Simplex simplex = new Simplex
            {
                Count = 0
            };

            // Get simplex vertices as an array.
            //SimplexVertex vertices = simplex.V.Value0; //Velcro: we don't need this as we have an indexer instead

            // Get support point in -r direction
            int indexA = proxyA.GetSupport(MathUtils.MulT(xfA.Q, -r));
            Vector2 wA = MathUtils.Mul(ref xfA, proxyA.GetVertex(indexA));
            int indexB = proxyB.GetSupport(MathUtils.MulT(xfB.Q, r));
            Vector2 wB = MathUtils.Mul(ref xfB, proxyB.GetVertex(indexB));
            Vector2 v = wA - wB;

            // Sigma is the target distance between polygons
            float sigma = MathUtils.Max(Settings.PolygonRadius, radius - Settings.PolygonRadius);
            float tolerance = 0.5f * Settings.LinearSlop;

            // Main iteration loop.
            int iter = 0;

            //Velcro: We have moved the max iterations into settings
            while (iter < Settings.MaxGjkIterations && v.Length() - sigma > tolerance)
            {
                Debug.Assert(simplex.Count < 3);

                output.Iterations += 1;

                // Support in direction -v (A - B)
                indexA = proxyA.GetSupport(MathUtils.MulT(xfA.Q, -v));
                wA = MathUtils.Mul(ref xfA, proxyA.GetVertex(indexA));
                indexB = proxyB.GetSupport(MathUtils.MulT(xfB.Q, v));
                wB = MathUtils.Mul(ref xfB, proxyB.GetVertex(indexB));
                Vector2 p = wA - wB;

                // -v is a normal at p
                v = Vector2.Normalize(v);

                // Intersect ray with plane
                float vp = MathUtils.Dot(ref v, ref p);
                float vr = MathUtils.Dot(ref v, ref r);
                if (vp - sigma > lambda * vr)
                {
                    if (vr <= 0.0f)
                    {
                        return false;
                    }

                    lambda = (vp - sigma) / vr;
                    if (lambda > 1.0f)
                    {
                        return false;
                    }

                    n = -v;
                    simplex.Count = 0;
                }

                // Reverse simplex since it works with B - A.
                // Shift by lambda * r because we want the closest point to the current clip point.
                // Note that the support point p is not shifted because we want the plane equation
                // to be formed in unshifted space.
                SimplexVertex vertex = simplex.V[simplex.Count];
                vertex.IndexA = indexB;
                vertex.Wa = wB + lambda * r;
                vertex.IndexB = indexA;
                vertex.Wb = wA;
                vertex.W = vertex.Wb - vertex.Wa;
                vertex.A = 1.0f;
                simplex.V[simplex.Count] = vertex; //Velcro: we have to copy the value back
                simplex.Count += 1;

                switch (simplex.Count)
                {
                    case 1:
                        break;

                    case 2:
                        simplex.Solve2();
                        break;

                    case 3:
                        simplex.Solve3();
                        break;

                    default:
                        Debug.Assert(false);
                        break;
                }

                // If we have 3 points, then the origin is in the corresponding triangle.
                if (simplex.Count == 3)
                {
                    // Overlap
                    return false;
                }

                // Get search direction.
                v = simplex.GetClosestPoint();

                // Iteration count is equated to the number of support point calls.
                ++iter;
            }

            if (iter == 0)
            {
                // Initial overlap
                return false;
            }

            // Prepare output.
            simplex.GetWitnessPoints(out _, out Vector2 pointB);

            if (v.LengthSquared() > 0.0f)
            {
                n = -v;
                n = Vector2.Normalize(n);
            }

            output.Point = pointB + radiusA * n;
            output.Normal = n;
            output.Lambda = lambda;
            output.Iterations = iter;
            return true;
        }
    }
}