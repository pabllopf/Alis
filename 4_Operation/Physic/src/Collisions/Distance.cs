// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Distance.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Provides distance computation between convex shapes using the GJK algorithm.
    /// </summary>
    /// <remarks>
    ///     This class implements the Gilbert-Johnson-Keerthi (GJK) algorithm for computing
    ///     the minimum distance between two convex shapes. The algorithm works by maintaining
    ///     a simplex (point, line segment, or triangle) in Minkowski space and iteratively
    ///     refining it until the closest point to the origin is found.
    ///     
    ///     The algorithm is used extensively in the physics engine for:
    ///     - Broad-phase collision detection
    ///     - Narrow-phase collision detection
    ///     - Contact point generation
    ///     
    ///     Performance is optimized by caching simplex state between frames and using
    ///     early termination criteria to avoid unnecessary iterations.
    /// </remarks>
    public static class Distance
    {
        /// <summary>
        ///     Gets the total number of calls made to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/> since last reset.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the cumulative call count.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for profiling and performance analysis.
        /// </remarks>
        [ThreadStatic] public static int GjkCalls;

        /// <summary>
        ///     Gets the number of iterations used in the most recent call to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/>.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the iteration count of the last call.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for identifying performance issues with specific collision pairs.
        /// </remarks>
        [ThreadStatic] public static int GjkIters;

        /// <summary>
        ///     Gets the maximum number of iterations ever used by any call to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/>.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the maximum iteration count observed.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for tuning <see cref="SettingEnv.MaxGjkIterations"/> to balance performance and accuracy.
        /// </remarks>
        [ThreadStatic] public static int GjkMaxIters;

        /// <summary>
        ///     Computes the minimum distance between two convex shapes using the GJK algorithm.
        /// </summary>
        /// <param name="output">The output parameter that receives the distance result and witness points.</param>
        /// <param name="cache">The cache parameter that stores simplex state for potential reuse in subsequent calls.</param>
        /// <param name="input">The input parameters specifying the shapes, their transforms, and calculation options.</param>
        /// <remarks>
        ///     The algorithm iteratively builds a simplex in the Minkowski difference of the two shapes.
        ///     It terminates when:
        ///     - The simplex contains 3 points (origin is inside the simplex = shapes overlap)
        ///     - A duplicate support point is found (cycling prevention)
        ///     - Maximum iterations reached
        ///     - Search direction becomes too small (degenerate case)
        ///     
        ///     The output contains the distance and two witness points (one on each shape)
        ///     that represent the closest points between the shapes.
        /// </remarks>
        public static void ComputeDistance(out DistanceOutput output, out SimplexCache cache, DistanceInput input)
        {
            cache = new SimplexCache();

            if (SettingEnv.EnableDiagnostics)
            {
                ++GjkCalls;
            }

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref input.ProxyA, ref input.ControllerTransformA, ref input.ProxyB, ref input.ControllerTransformB);

            FixedArray3<int> saveA = new FixedArray3<int>();
            FixedArray3<int> saveB = new FixedArray3<int>();

            int iter = 0;
            while (iter < SettingEnv.MaxGjkIterations)
            {
                int saveCount = simplex.Count;
                SaveSimplexIndices(simplex, saveA, saveB, saveCount);

                SolveSimplex(simplex);

                if (simplex.Count == 3)
                {
                    break;
                }

                Vector2F d = simplex.GetSearchDirection();

                if (d.LengthSquared() < SettingEnv.Epsilon * SettingEnv.Epsilon)
                {
                    break;
                }

                SimplexVertex vertex = simplex.V[simplex.Count];
                vertex.IndexA = input.ProxyA.GetSupport(-Complex.Divide(ref d, ref input.ControllerTransformA.Rotation));
                vertex.Wa = ControllerTransform.Multiply(input.ProxyA.Vertices[vertex.IndexA], ref input.ControllerTransformA);

                vertex.IndexB = input.ProxyB.GetSupport(Complex.Divide(ref d, ref input.ControllerTransformB.Rotation));
                vertex.Wb = ControllerTransform.Multiply(input.ProxyB.Vertices[vertex.IndexB], ref input.ControllerTransformB);
                vertex.W = vertex.Wb - vertex.Wa;
                simplex.V[simplex.Count] = vertex;

                ++iter;

                if (SettingEnv.EnableDiagnostics)
                {
                    ++GjkIters;
                }

                if (IsDuplicateVertex(vertex, saveA, saveB, saveCount))
                {
                    break;
                }

                ++simplex.Count;
            }

            if (SettingEnv.EnableDiagnostics)
            {
                GjkMaxIters = Math.Max(GjkMaxIters, iter);
            }

            simplex.GetWitnessPoints(out output.PointA, out output.PointB);
            output.Distance = (output.PointA - output.PointB).Length();
            output.Iterations = iter;

            simplex.WriteCache(ref cache);

            ApplyRadii(input, ref output);
        }

        private static void SaveSimplexIndices(Simplex simplex, FixedArray3<int> saveA, FixedArray3<int> saveB, int saveCount)
        {
            for (int i = 0; i < saveCount; ++i)
            {
                saveA[i] = simplex.V[i].IndexA;
                saveB[i] = simplex.V[i].IndexB;
            }
        }

        private static void SolveSimplex(Simplex simplex)
        {
            switch (simplex.Count)
            {
                case 2:
                    simplex.Solve2();
                    break;
                case 3:
                    simplex.Solve3();
                    break;
            }
        }

        private static bool IsDuplicateVertex(SimplexVertex vertex, FixedArray3<int> saveA, FixedArray3<int> saveB, int saveCount)
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

        private static void ApplyRadii(DistanceInput input, ref DistanceOutput output)
        {
            if (!input.UseRadii)
            {
                return;
            }

            float rA = input.ProxyA.Radius;
            float rB = input.ProxyB.Radius;

            if ((output.Distance > rA + rB) && (output.Distance > SettingEnv.Epsilon))
            {
                output.Distance -= rA + rB;
                Vector2F normal = output.PointB - output.PointA;
                normal.Normalize();
                output.PointA += rA * normal;
                output.PointB -= rB * normal;
            }
            else
            {
                Vector2F p = 0.5f * (output.PointA + output.PointB);
                output.PointA = p;
                output.PointB = p;
                output.Distance = 0.0f;
            }
        }
    }
}