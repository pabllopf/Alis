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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The Gilbert–Johnson–Keerthi distance algorithm that provides the distance between shapes.
    /// </summary>
    public static class Distance
    {
        /// <summary>
        ///     The number of calls made to the ComputeDistance() function.
        ///     Note: This is only activated when Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkCalls;

        /// <summary>
        ///     The number of iterations that was made on the last call to ComputeDistance().
        ///     Note: This is only activated when Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkIters;

        /// <summary>
        ///     The maximum numer of iterations ever mae with calls to the CompteDistance() funtion.
        ///     Note: This is only activated when Settings.EnableDiagnostics = true
        /// </summary>
        [ThreadStatic] public static int GjkMaxIters;

        /// <summary>
        ///     Computes the distance using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="cache">The cache</param>
        /// <param name="input">The input</param>
        public static void ComputeDistance(out DistanceOutput output, out SimplexCache cache, DistanceInput input)
        {
            cache = new SimplexCache();

            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                ++GjkCalls;
            }

            // Initialize the simplex.
            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref input.ProxyA, ref input.TransformA, ref input.ProxyB, ref input.TransformB);

            // These store the vertices of the last simplex so that we
            // can check for duplicates and prevent cycling.
            FixedArray3<int> saveA = new FixedArray3<int>();
            FixedArray3<int> saveB = new FixedArray3<int>();

            //float distanceSqr1 = Settings.MaxFloat;

            // Main iteration loop.
            int iter = 0;
            while (iter < SettingEnv.MaxGjkIterations)
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

                //FPE: This code was not used anyway.
                // Compute closest point.
                //Vector2F p = simplex.GetClosestPoint();
                //float distanceSqr2 = p.LengthSquared();

                // Ensure progress
                //if (distanceSqr2 >= distanceSqr1)
                //{
                //break;
                //}
                //distanceSqr1 = distanceSqr2;

                // Get search direction.
                Vector2F d = simplex.GetSearchDirection();

                // Ensure the search direction is numerically fit.
                if (d.LengthSquared() < SettingEnv.Epsilon * SettingEnv.Epsilon)
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
                vertex.IndexA = input.ProxyA.GetSupport(-Complex.Divide(ref d, ref input.TransformA.q));
                vertex.Wa = Transform.Multiply(input.ProxyA.Vertices[vertex.IndexA], ref input.TransformA);

                vertex.IndexB = input.ProxyB.GetSupport(Complex.Divide(ref d, ref input.TransformB.q));
                vertex.Wb = Transform.Multiply(input.ProxyB.Vertices[vertex.IndexB], ref input.TransformB);
                vertex.W = vertex.Wb - vertex.Wa;
                simplex.V[simplex.Count] = vertex;

                // Iteration count is equated to the number of support point calls.
                ++iter;

                if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                {
                    ++GjkIters;
                }

                // Check for duplicate support points. This is the main termination criteria.
                bool duplicate = false;
                for (int i = 0; i < saveCount; ++i)
                {
                    if ((vertex.IndexA == saveA[i]) && (vertex.IndexB == saveB[i]))
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

                // New vertex is ok and needed.
                ++simplex.Count;
            }

            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                GjkMaxIters = Math.Max(GjkMaxIters, iter);
            }

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

                if ((output.Distance > rA + rB) && (output.Distance > SettingEnv.Epsilon))
                {
                    // Shapes are still no overlapped.
                    // Move the witness points to the outer surface.
                    output.Distance -= rA + rB;
                    Vector2F normal = output.PointB - output.PointA;
                    normal.Normalize();
                    output.PointA += rA * normal;
                    output.PointB -= rB * normal;
                }
                else
                {
                    // Shapes are overlapped when radii are considered.
                    // Move the witness points to the middle.
                    Vector2F p = 0.5f * (output.PointA + output.PointB);
                    output.PointA = p;
                    output.PointB = p;
                    output.Distance = 0.0f;
                }
            }
        }
    }
}