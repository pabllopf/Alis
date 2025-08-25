// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpact.cs
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

using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The time of impact class
    /// </summary>
    public static class TimeOfImpact
    {
        // CCD via the local separating axis method. This seeks progression
        // by computing the largest time at which separation is maintained.

        /// <summary>
        ///     The toi max iters
        /// </summary>
        [ThreadStatic] public static int ToiCalls;

        /// <summary>
        ///     The toi max iters
        /// </summary>
        [ThreadStatic] public static int ToiIters;

        /// <summary>
        ///     The toi max iters
        /// </summary>
        [ThreadStatic] public static int ToiMaxIters;

        /// <summary>
        ///     The toi max root iters
        /// </summary>
        [ThreadStatic] public static int ToiRootIters;

        /// <summary>
        ///     The toi max root iters
        /// </summary>
        [ThreadStatic] public static int ToiMaxRootIters;

        /// <summary>
        ///     Compute the upper bound on time before two shapes penetrate. Time is represented as
        ///     a fraction between [0,tMax]. This uses a swept separating axis and may miss some intermediate,
        ///     non-tunneling collision. If you change the time interval, you should call this function
        ///     again.
        ///     Note: use Distance() to compute the contact point and normal at the time of impact.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="input">The input.</param>
        public static void CalculateTimeOfImpact(out ToiOutput output, ref ToiInput input)
        {
            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                ++ToiCalls;
            }

            output = new ToiOutput();
            output.State = ToiOutputState.Unknown;
            output.T = input.TMax;

            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;

            // Large rotations can make the root finder fail, so we normalize the
            // sweep angles.
            sweepA.Normalize();
            sweepB.Normalize();

            float tMax = input.TMax;

            float totalRadius = input.ProxyA.Radius + input.ProxyB.Radius;
            float target = Math.Max(SettingEnv.LinearSlop, totalRadius - 3.0f * SettingEnv.LinearSlop);
            const float tolerance = 0.25f * SettingEnv.LinearSlop;
            float t1 = 0.0f;
            const int kMaxIterations = 20;
            int iter = 0;

            // Prepare input for distance query.
            DistanceInput distanceInput = new DistanceInput();
            distanceInput.ProxyA = input.ProxyA;
            distanceInput.ProxyB = input.ProxyB;
            distanceInput.UseRadii = false;

            // The outer loop progressively attempts to compute new separating axes.
            // This loop terminates when an axis is repeated (no progress is made).
            for (;;)
            {
                sweepA.GetTransform(out ControllerTransform xfA, t1);
                sweepB.GetTransform(out ControllerTransform xfB, t1);

                // Get the distance between shapes. We can also use the results
                // to get a separating axis.
                distanceInput.ControllerTransformA = xfA;
                distanceInput.ControllerTransformB = xfB;
                Distance.ComputeDistance(out DistanceOutput distanceOutput, out SimplexCache cache, distanceInput);

                // If the shapes are overlapped, we give up on continuous collision.
                if (distanceOutput.Distance <= 0.0f)
                {
                    // Failure!
                    output.State = ToiOutputState.Overlapped;
                    output.T = 0.0f;
                    break;
                }

                if (distanceOutput.Distance < target + tolerance)
                {
                    // Victory!
                    output.State = ToiOutputState.Touching;
                    output.T = t1;
                    break;
                }

                SeparationFunction.Set(ref cache, ref input.ProxyA, ref sweepA, ref input.ProxyB, ref sweepB, t1);

                // Compute the TOI on the separating axis. We do this by successively
                // resolving the deepest point. This loop is bounded by the number of vertices.
                bool done = false;
                float t2 = tMax;
                int pushBackIter = 0;
                for (;;)
                {
                    // Find the deepest point at t2. Store the witness point indices.
                    float s2 = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, t2);

                    // Is the final configuration separated?
                    if (s2 > target + tolerance)
                    {
                        // Victory!
                        output.State = ToiOutputState.Seperated;
                        output.T = tMax;
                        done = true;
                        break;
                    }

                    // Has the separation reached tolerance?
                    if (s2 > target - tolerance)
                    {
                        // Advance the sweeps
                        t1 = t2;
                        break;
                    }

                    // Compute the initial separation of the witness points.
                    float s1 = SeparationFunction.Evaluate(indexA, indexB, t1);

                    // Check for initial overlap. This might happen if the root finder
                    // runs out of iterations.
                    if (s1 < target - tolerance)
                    {
                        output.State = ToiOutputState.Failed;
                        output.T = t1;
                        done = true;
                        break;
                    }

                    // Check for touching
                    if (s1 <= target + tolerance)
                    {
                        // Victory! t1 should hold the TOI (could be 0.0).
                        output.State = ToiOutputState.Touching;
                        output.T = t1;
                        done = true;
                        break;
                    }

                    // Compute 1D root of: f(x) - target = 0
                    int rootIterCount = 0;
                    float a1 = t1, a2 = t2;
                    for (;;)
                    {
                        // Use a mix of the secant rule and bisection.
                        float t;
                        if ((rootIterCount & 1) != 0)
                        {
                            // Secant rule to improve convergence.
                            t = a1 + (target - s1) * (a2 - a1) / (s2 - s1);
                        }
                        else
                        {
                            // Bisection to guarantee progress.
                            t = 0.5f * (a1 + a2);
                        }

                        ++rootIterCount;

                        if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                        {
                            ++ToiRootIters;
                        }

                        float s = SeparationFunction.Evaluate(indexA, indexB, t);

                        if (Math.Abs(s - target) < tolerance)
                        {
                            // t2 holds a tentative value for t1
                            t2 = t;
                            break;
                        }

                        // Ensure we continue to bracket the root.
                        if (s > target)
                        {
                            a1 = t;
                            s1 = s;
                        }
                        else
                        {
                            a2 = t;
                            s2 = s;
                        }

                        if (rootIterCount == 50)
                        {
                            break;
                        }
                    }

                    if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                    {
                        ToiMaxRootIters = Math.Max(ToiMaxRootIters, rootIterCount);
                    }

                    ++pushBackIter;

                    if (pushBackIter == SettingEnv.MaxPolygonVertices)
                    {
                        break;
                    }
                }

                ++iter;

                if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                {
                    ++ToiIters;
                }

                if (done)
                {
                    break;
                }

                if (iter == kMaxIterations)
                {
                    // Root finder got stuck. Semi-victory.
                    output.State = ToiOutputState.Failed;
                    output.T = t1;
                    break;
                }
            }

            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                ToiMaxIters = Math.Max(ToiMaxIters, iter);
            }
        }
    }
}