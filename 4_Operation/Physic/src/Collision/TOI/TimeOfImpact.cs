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
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.Narrowphase;
using Alis.Core.Physic.Config;

namespace Alis.Core.Physic.Collision.TOI
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
        [ThreadStatic] public static int ToiCalls,
            ToiIters,
            ToiMaxIters;

        /// <summary>
        ///     The toi max root iters
        /// </summary>
        [ThreadStatic] public static int ToiRootIters,
            ToiMaxRootIters;

        /// <summary>
        ///     Compute the upper bound on time before two shapes penetrate. Time is represented as a fraction between
        ///     [0,tMax]. This uses a swept separating axis and may miss some intermediate, non-tunneling collision. If you change
        ///     the
        ///     time interval, you should call this function again. Note: use Distance() to compute the contact point and normal at
        ///     the
        ///     time of impact.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public static void CalculateTimeOfImpact(ref ToiInput input, out ToiOutput output)
        {
            ++ToiCalls;

            output = new ToiOutput
            {
                State = ToiOutputState.Unknown,
                T = input.Max
            };

            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;

            // Large rotations can make the root finder fail, so we normalize the
            // sweep angles.
            sweepA.Normalize();
            sweepB.Normalize();

            float tMax = input.Max;

            float totalRadius = input.ProxyA.Radius + input.ProxyB.Radius;
            float target = Math.Max(Settings.LinearSlop, totalRadius - 3.0f * Settings.LinearSlop);
            float tolerance = 0.25f * Settings.LinearSlop;
            Debug.Assert(target > tolerance);

            float t1 = 0.0f;
            const int kMaxIterations = 20;
            int iter = 0;

            // Prepare input for distance query.
            DistanceInput distanceInput = new DistanceInput
            {
                ProxyA = input.ProxyA,
                ProxyB = input.ProxyB,
                UseRadii = false
            };

            // The outer loop progressively attempts to compute new separating axes.
            // This loop terminates when an axis is repeated (no progress is made).
            for (;;)
            {
                sweepA.GetTransform(out Transform xfA, t1);
                sweepB.GetTransform(out Transform xfB, t1);

                // Get the distance between shapes. We can also use the results
                // to get a separating axis.
                distanceInput.TransformA = xfA;
                distanceInput.TransformB = xfB;
                DistanceGjk.ComputeDistance(ref distanceInput, out DistanceOutput distanceOutput,
                    out SimplexCache cache);

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

                SeparationFunction.Initialize(ref cache, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, t1,
                    out Vector2F axis, out Vector2F localPoint, out SeparationFunctionType type);

                // Compute the TOI on the separating axis. We do this by successively
                // resolving the deepest point. This loop is bounded by the number of vertices.
                bool done = false;
                float t2 = tMax;
                int pushBackIter = 0;
                for (;;)
                {
                    // Find the deepest point at t2. Store the witness point indices.
                    float s2 = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, t2, input.ProxyA,
                        ref sweepA, input.ProxyB, ref sweepB, ref axis, ref localPoint, type);

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
                    float s1 = SeparationFunction.Evaluate(indexA, indexB, t1, input.ProxyA, ref sweepA, input.ProxyB,
                        ref sweepB, ref axis, ref localPoint, type);

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
                        ++ToiRootIters;

                        float s = SeparationFunction.Evaluate(indexA, indexB, t, input.ProxyA, ref sweepA, input.ProxyB,
                            ref sweepB, ref axis, ref localPoint, type);

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

                    ToiMaxRootIters = Math.Max(ToiMaxRootIters, rootIterCount);

                    ++pushBackIter;

                    if (pushBackIter == Settings.PolygonVertices)
                    {
                        break;
                    }
                }

                ++iter;
                ++ToiIters;

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

            ToiMaxIters = Math.Max(ToiMaxIters, iter);
        }
    }
}