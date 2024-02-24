// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceGJK.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared.Optimization;

namespace Alis.Core.Physic.Collision.Distance
{
    /// <summary>
    ///     The Gilbert distance algorithm that provides the distance between shapes. Using Voronoi
    ///     regions and Barycentric coordinates.
    /// </summary>
    public static class DistanceGjk
    {
        /// <summary>
        ///     The number of calls made to the ComputeDistance() function. Note: This is only activated when
        ///     Settings.EnableDiagnostics = true
        /// </summary>
        [field: ThreadStatic]
        public static int GjkCalls { get; set; }

        /// <summary>
        ///     The number of iterations that was made on the last call to ComputeDistance(). Note: This is only activated
        ///     when Settings.EnableDiagnostics = true
        /// </summary>
        [field: ThreadStatic]
        public static int GjkIter { get; set; }

        /// <summary>
        ///     The maximum number of iterations calls to the Distance() function. Note: This is only activated when
        ///     Settings.EnableDiagnostics = true
        /// </summary>
        [field: ThreadStatic]
        public static int GjkMaxIter { get; private set; }

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
            Simplex simplex = InitializeSimplex(ref cache, ref input);

            // These store the vertices of the last simplex so that we
            // can check for duplicates and prevent cycling.
            FixedArray3<int> saveA = new FixedArray3<int>();
            FixedArray3<int> saveB = new FixedArray3<int>();

            // Main iteration loop.
            int iter = 0;

            //Velcro: Moved the max iterations to settings
            while (iter < Settings.GjkIterations)
            {
                // Copy simplex so we can identify duplicates.
                int saveCount = simplex.Count;

                SaveSimplexVertices(simplex, ref saveA, ref saveB);
                SolveSimplex(ref simplex);

                // If we have 3 points, then the origin is in the corresponding triangle.
                if (simplex.Count == 3)
                {
                    break;
                }

                // Get search direction.
                Vector2 d = simplex.GetSearchDirection();

                // Ensure the search direction is numerically fit.
                if (d.LengthSquared() < Constant.Epsilon * Constant.Epsilon)
                {
                    // The origin is probably contained by a line segment
                    // or triangle. Thus the shapes are overlapped.

                    // We can't return zero here even though there may be overlap.
                    // In case the simplex is a point, segment, or triangle it is difficult
                    // to determine if the origin is contained in the CSO or very close to it.
                    break;
                }

                // Compute a tentative new simplex vertex using support points.
                SimplexVertex vertex = AddNewVertexToSimplex(ref simplex, ref input);

                // Iteration count is equated to the number of support point calls.
                ++iter;
                ++GjkIter;

                // Check for duplicate support points. This is the main termination criteria.
                if (IsDuplicateSupportPoint(saveA, saveB, vertex, saveCount))
                {
                    break;
                }

                // New vertex is OK and needed.
                ++simplex.Count;
            }

            GjkMaxIter = Math.Max(GjkMaxIter, iter);

            // Prepare output.
            PrepareOutput(out output, ref simplex, ref cache, ref input);
        }

        /// <summary>
        /// Saves the simplex vertices using the specified simplex
        /// </summary>
        /// <param name="simplex">The simplex</param>
        /// <param name="saveA">The save</param>
        /// <param name="saveB">The save</param>
        private static void SaveSimplexVertices(Simplex simplex, ref FixedArray3<int> saveA, ref FixedArray3<int> saveB)
        {
            int saveCount = simplex.Count;
            for (int i = 0; i < saveCount; ++i)
            {
                saveA[i] = simplex.V[i].IndexA;
                saveB[i] = simplex.V[i].IndexB;
            }
        }

        /// <summary>
        /// Initializes the simplex using the specified cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="input">The input</param>
        /// <returns>The simplex</returns>
        private static Simplex InitializeSimplex(ref SimplexCache cache, ref DistanceInput input)
        {
            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref input.ProxyA, ref input.TransformA, ref input.ProxyB, ref input.TransformB);
            return simplex;
        }


        /// <summary>
        /// Adds the new vertex to simplex using the specified simplex
        /// </summary>
        /// <param name="simplex">The simplex</param>
        /// <param name="input">The input</param>
        /// <returns>The vertex</returns>
        private static SimplexVertex AddNewVertexToSimplex(ref Simplex simplex, ref DistanceInput input)
        {
            Vector2 d = simplex.GetSearchDirection();
            SimplexVertex vertex = simplex.V[simplex.Count];
            vertex.IndexA = input.ProxyA.GetSupport(MathUtils.MulT(input.TransformA.Rotation, -d));
            vertex.Wa = MathUtils.Mul(ref input.TransformA, input.ProxyA.Vertices[vertex.IndexA]);
            vertex.IndexB = input.ProxyB.GetSupport(MathUtils.MulT(input.TransformB.Rotation, d));
            vertex.Wb = MathUtils.Mul(ref input.TransformB, input.ProxyB.Vertices[vertex.IndexB]);
            vertex.W = vertex.Wb - vertex.Wa;
            simplex.V[simplex.Count] = vertex;
            return vertex;
        }


        /// <summary>
        /// Solves the simplex using the specified simplex
        /// </summary>
        /// <param name="simplex">The simplex</param>
        private static void SolveSimplex(ref Simplex simplex)
        {
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
        }

        /// <summary>
        /// Describes whether is duplicate support point
        /// </summary>
        /// <param name="saveA">The save</param>
        /// <param name="saveB">The save</param>
        /// <param name="vertex">The vertex</param>
        /// <param name="saveCount">The save count</param>
        /// <returns>The bool</returns>
        private static bool IsDuplicateSupportPoint(FixedArray3<int> saveA, FixedArray3<int> saveB, SimplexVertex vertex, int saveCount)
        {
            for (int i = 0; i < saveCount; ++i)
            {
                if ((vertex.IndexA == saveA[i]) && (vertex.IndexB == saveB[i]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Prepares the output using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="simplex">The simplex</param>
        /// <param name="cache">The cache</param>
        /// <param name="input">The input</param>
        private static void PrepareOutput(out DistanceOutput output, ref Simplex simplex, ref SimplexCache cache, ref DistanceInput input)
        {
            simplex.GetWitnessPoints(out output.PointA, out output.PointB);
            output.Distance = (output.PointA - output.PointB).Length();
            output.Iterations = simplex.Count;

            simplex.WriteCache(ref cache);

            if (input.UseRadii)
            {
                ApplyRadii(ref output, ref input);
            }
        }

        /// <summary>
        /// Applies the radii using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        private static void ApplyRadii(ref DistanceOutput output, ref DistanceInput input)
        {
            float rA = input.ProxyA.Radius;
            float rB = input.ProxyB.Radius;

            if ((output.Distance > rA + rB) && (output.Distance > Constant.Epsilon))
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

        /// <summary>
        ///     Perform a linear shape cast of shape B moving and shape A fixed. Determines the hit point, normal, and
        ///     translation fraction.
        /// </summary>
        /// <returns>true if hit, false if there is no hit or an initial overlap</returns>
        public static bool ShapeCast(ref ShapeCastInput input, out ShapeCastOutput output)
        {
            InitializeOutput(out output);

            DistanceProxy proxyA = input.ProxyA;
            DistanceProxy proxyB = input.ProxyB;

            float radiusA = CalculateRadius(proxyA);
            float radiusB = CalculateRadius(proxyB);
            float radius = radiusA + radiusB;

            Transform xfA = input.TransformA;
            Transform xfB = input.TransformB;

            Vector2 r = input.TranslationB;
            Vector2 n = Vector2.Zero;
            float lambda = 0.0f;

            Simplex simplex = InitializeSimplex();

            int iter = 0;

            while (IterateUntilConverged(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref n, ref lambda, ref simplex, radius))
            {
                // Iteration count is equated to the number of support point calls.
                ++iter;
            }

            if (iter == 0)
            {
                // Initial overlap
                return false;
            }

            CalculateOutput(ref output, ref simplex, ref r, ref lambda, ref n, radiusA);
            return true;
        }

        /// <summary>
        ///     Initializes the output using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        private static void InitializeOutput(out ShapeCastOutput output)
        {
            output = new ShapeCastOutput
            {
                Iterations = 0,
                Lambda = 1.0f,
                Normal = Vector2.Zero,
                Point = Vector2.Zero
            };
        }

        /// <summary>
        ///     Calculates the radius using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The float</returns>
        private static float CalculateRadius(DistanceProxy proxy) => MathUtils.Max(proxy.Radius, Settings.PolygonRadius);

        /// <summary>
        ///     Initializes the simplex
        /// </summary>
        /// <returns>The simplex</returns>
        private static Simplex InitializeSimplex() => new Simplex
        {
            Count = 0
        };

        /// <summary>
        ///     Describes whether iterate until converged
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="r">The </param>
        /// <param name="n">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="simplex">The simplex</param>
        /// <param name="radius">The radius</param>
        /// <returns>The bool</returns>
        private static bool IterateUntilConverged(ref DistanceProxy proxyA, ref DistanceProxy proxyB,
            ref Transform xfA, ref Transform xfB, ref Vector2 r, ref Vector2 n, ref float lambda, ref Simplex simplex, float radius)
        {
            Vector2 v = ComputeV(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref n, ref lambda, ref simplex, radius);

            if (IsConverged(v, ref lambda, radius))
            {
                return false;
            }

            UpdateSimplex(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref v, ref n, ref lambda, ref simplex, radius);
            return true;
        }

        /// <summary>
        ///     Computes the v using the specified input
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="r">The </param>
        /// <param name="n">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="simplex">The simplex</param>
        /// <param name="radius">The radius</param>
        /// <returns>The </returns>
        private static Vector2 ComputeV(ref DistanceProxy proxyA, ref DistanceProxy proxyB,
            ref Transform xfA, ref Transform xfB, ref Vector2 r, ref Vector2 n, ref float lambda, ref Simplex simplex, float radius)
        {
            Vector2 v = ComputeSupport(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r);

            if (IsNewDirectionNeeded(ref n, ref r, ref lambda, radius))
            {
                n = -v;
                n = Vector2.Normalize(n);
                simplex.Count = 0;
            }

            return v;
        }

        /// <summary>
        ///     Computes the support using the specified proxy a
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="r">The </param>
        /// <returns>The </returns>
        private static Vector2 ComputeSupport(ref DistanceProxy proxyA, ref DistanceProxy proxyB, ref Transform xfA, ref Transform xfB,
            ref Vector2 r)
        {
            int indexA = proxyA.GetSupport(MathUtils.MulT(xfA.Rotation, -r));
            Vector2 wA = MathUtils.Mul(ref xfA, proxyA.GetVertex(indexA));
            int indexB = proxyB.GetSupport(MathUtils.MulT(xfB.Rotation, r));
            Vector2 wB = MathUtils.Mul(ref xfB, proxyB.GetVertex(indexB));
            Vector2 v = wA - wB;

            return v;
        }

        /// <summary>
        ///     Describes whether is converged
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="radius">The radius</param>
        /// <returns>The bool</returns>
        private static bool IsConverged(Vector2 v, ref float lambda, float radius)
        {
            float sigma = MathUtils.Max(Settings.PolygonRadius, 2 * radius - Settings.PolygonRadius);
            float tolerance = 0.5f * Settings.LinearSlop;

            return v.Length() - sigma <= tolerance || lambda > 1.0f;
        }

        /// <summary>
        ///     Describes whether is new direction needed
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="r">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="radius">The radius</param>
        /// <returns>The bool</returns>
        private static bool IsNewDirectionNeeded(ref Vector2 n, ref Vector2 r, ref float lambda, float radius)
        {
            float vp = MathUtils.Dot(ref n, ref r);
            return vp - (2 * radius - Settings.PolygonRadius) > lambda * MathUtils.Dot(ref n, ref r);
        }

        /// <summary>
        ///     Updates the simplex using the specified input
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="r">The </param>
        /// <param name="v">The </param>
        /// <param name="n">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="simplex">The simplex</param>
        /// <param name="radius">The radius</param>
        private static void UpdateSimplex(ref DistanceProxy proxyA, ref DistanceProxy proxyB,
            ref Transform xfA, ref Transform xfB, ref Vector2 r, ref Vector2 v, ref Vector2 n, ref float lambda, ref Simplex simplex, float radius)
        {
            int indexA = proxyA.GetSupport(MathUtils.MulT(xfA.Rotation, -v));
            Vector2 wA = MathUtils.Mul(ref xfA, proxyA.GetVertex(indexA));
            int indexB = proxyB.GetSupport(MathUtils.MulT(xfB.Rotation, v));
            Vector2 wB = MathUtils.Mul(ref xfB, proxyB.GetVertex(indexB));
            Vector2 p = wA - wB;

            v = Vector2.Normalize(v);

            float vp = MathUtils.Dot(ref v, ref p);
            float vr = MathUtils.Dot(ref v, ref r);

            if (vp - (2 * radius - Settings.PolygonRadius) > lambda * vr)
            {
                if (vr <= 0.0f)
                {
                    return;
                }

                lambda = (vp - (2 * radius - Settings.PolygonRadius)) / vr;

                if (lambda > 1.0f)
                {
                    return;
                }

                n = -v;
                simplex.Count = 0;
            }

            SimplexVertex vertex = simplex.V[simplex.Count];
            vertex.IndexA = indexB;
            vertex.Wa = wB + lambda * r;
            vertex.IndexB = indexA;
            vertex.Wb = wA;
            vertex.W = vertex.Wb - vertex.Wa;
            vertex.A = 1.0f;
            simplex.V[simplex.Count] = vertex;
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
        }

        /// <summary>
        ///     Calculates the output using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="simplex">The simplex</param>
        /// <param name="r">The </param>
        /// <param name="lambda">The lambda</param>
        /// <param name="n">The </param>
        /// <param name="radiusA">The radius</param>
        private static void CalculateOutput(ref ShapeCastOutput output, ref Simplex simplex, ref Vector2 r, ref float lambda, ref Vector2 n, float radiusA)
        {
            simplex.GetWitnessPoints(out _, out Vector2 pointB);

            if (r.LengthSquared() > 0.0f)
            {
                n = -r;
                n = Vector2.Normalize(n);
            }

            output.Point = pointB + radiusA * n;
            output.Normal = n;
            output.Lambda = lambda;
            output.Iterations = simplex.Count;
        }
    }
}