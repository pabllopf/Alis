// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TOI.cs
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
using Alis.Core.Physics2D.Contacts;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The toi class
    /// </summary>
    public static class TOI
    {
        /// <summary>
        ///     Times the of impact using the specified output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        internal static void TimeOfImpact(out TOIOutput output, in TOIInput input)
        {
            //++_toiCalls;
            output.t = input.tMax;
            output.state = TOIOutputState.Unknown;

            DistanceProxy proxyA = input.proxyA;
            DistanceProxy proxyB = input.proxyB;

            Sweep sweepA = input.sweepA;
            Sweep sweepB = input.sweepB;

            // Large rotations can make the root finder fail, so we normalize the
            // sweep angles.
            sweepA.Normalize();
            sweepB.Normalize();

            float tMax = input.tMax;

            float totalRadius = proxyA._radius + proxyB._radius;
            float target = MathF.Max(Settings.LinearSlop, totalRadius - 3.0f * Settings.LinearSlop);
            float tolerance = 0.25f * Settings.LinearSlop;
            //Debug.Assert(target > tolerance);

            float t1 = 0.0f;
            int iter = 0;

            // Prepare input for distance query.
            SimplexCache cache = new SimplexCache();
            DistanceInput distanceInput;
            distanceInput.proxyA = input.proxyA;
            distanceInput.proxyB = input.proxyB;
            distanceInput.useRadii = false;

            // The outer loop progressively attempts to compute new separating axes.
            // This loop terminates when an axis is repeated (no progress is made).
            SeparationFunction fcn = default(SeparationFunction);
            for (;;)
            {
                sweepA.GetTransform(out Transform xfA, t1);
                sweepB.GetTransform(out Transform xfB, t1);

                // Get the distance between shapes. We can also use the results
                // to get a separating axis.
                distanceInput.transformA = xfA;
                distanceInput.transformB = xfB;
                Contact.Distance(out DistanceOutput distanceOutput, cache, in distanceInput);

                // If the shapes are overlapped, we give up on continuous collision.
                if (distanceOutput.distance <= 0.0f)
                {
                    // Failure!
                    output.state = TOIOutputState.Overlapped;
                    output.t = 0.0f;
                    break;
                }

                if (distanceOutput.distance < target + tolerance)
                {
                    // Victory!
                    output.state = TOIOutputState.Touching;
                    output.t = t1;
                    break;
                }

                // Initialize the separating axis.

                fcn.Initialize(cache, proxyA, sweepA, proxyB, sweepB, t1);

                // Compute the TOI on the separating axis. We do this by successively
                // resolving the deepest point. This loop is bounded by the number of vertices.
                bool done = false;
                float t2 = tMax;
                int pushBackIter = 0;
                for (;;)
                {
                    // Find the deepest point at t2. Store the witness point indices.
                    float s2 = fcn.FindMinSeparation(out int indexA, out int indexB, t2);

                    // Is the final configuration separated?
                    if (s2 > target + tolerance)
                    {
                        // Victory!
                        output.state = TOIOutputState.Separated;
                        output.t = tMax;
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
                    float s1 = fcn.Evaluate(indexA, indexB, t1);

                    // Check for initial overlap. This might happen if the root finder
                    // runs out of iterations.
                    if (s1 < target - tolerance)
                    {
                        output.state = TOIOutputState.Failed;
                        output.t = t1;
                        done = true;
                        break;
                    }

                    // Check for touching
                    if (s1 <= target + tolerance)
                    {
                        // Victory! t1 should hold the TOI (could be 0.0).
                        output.state = TOIOutputState.Touching;
                        output.t = t1;
                        done = true;
                        break;
                    }

                    // Compute 1D root of: f(x) - target = 0
                    //int   rootIterCount = 0;
                    float a1 = t1, a2 = t2;
                    for (int rootIterCount = 0; rootIterCount < 50; ++rootIterCount)
                    {
                        // Use a mix of the secant rule and bisection.
                        float t;
                        if ((rootIterCount & 1) > 0)
                            // Secant rule to improve convergence.
                        {
                            t = a1 + (target - s1) * (a2 - a1) / (s2 - s1);
                        }
                        else
                            // Bisection to guarantee progress.
                        {
                            t = 0.5f * (a1 + a2);
                        }

                        //++rootIterCount;
                        //++b2_toiRootIters;

                        float s = fcn.Evaluate(indexA, indexB, t);

                        if (MathF.Abs(s - target) < tolerance)
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

                        // if (rootIterCount == 50) {
                        //   break;
                        // }
                    }

                    //b2_toiMaxRootIters = b2Max(b2_toiMaxRootIters, rootIterCount);

                    ++pushBackIter;

                    if (pushBackIter == Settings.MaxPolygonVertices)
                    {
                        break;
                    }
                }

                ++iter;
                //++b2_toiIters;

                if (done)
                {
                    break;
                }

                if (iter == Settings.MaxTOIIterations)
                {
                    // Root finder got stuck. Semi-victory.
                    output.state = TOIOutputState.Failed;
                    output.t = t1;
                    break;
                }
            }

            //_toiMaxIters = b2Max(b2_toiMaxIters, iter);

            // float time = timer.GetMilliseconds();
            // b2_toiMaxTime = b2Max(b2_toiMaxTime, time);
            // b2_toiTime += time;
        }
    }
}