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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Computes the Time of Impact (TOI) between two moving convex shapes using continuous collision detection (CCD).
    /// </summary>
    /// <remarks>
    ///     This class implements the local separating axis method for CCD. It seeks progression
    ///     by computing the largest time at which separation is maintained between two shapes.
    ///     
    ///     The algorithm uses a swept separating axis and may miss some intermediate, non-tunneling collisions.
    ///     For contact point and normal information at the time of impact, use <see cref="Distance"/> after calling this method.
    ///     
    ///     Diagnostics can be enabled via <see cref="SettingEnv.EnableDiagnostics"/> to track TOI computation statistics.
    /// </remarks>
    public static class TimeOfImpact
    {
        // by computing the largest time at which separation is maintained.

        /// <summary>
        ///     Gets or sets the total number of TOI computation calls made (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiCalls;

        /// <summary>
        ///     Gets or sets the number of iterations in the current TOI computation (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiIters;

        /// <summary>
        ///     Gets or sets the maximum number of iterations allowed in TOI computation (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiMaxIters;

        /// <summary>
        ///     Gets or sets the number of root-finding iterations in the current TOI computation (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiRootIters;

        /// <summary>
        ///     Gets or sets the maximum number of root-finding iterations allowed in TOI computation (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiMaxRootIters;

        /// <summary>
        ///     Computes the upper bound on time before two shapes penetrate. Time is represented as
        ///     a fraction between [0, tMax]. This uses a swept separating axis and may miss some intermediate,
        ///     non-tunneling collision. If you change the time interval, you should call this method
        ///     again.
        /// </summary>
        /// <param name="output">When this method returns, contains the TOI output with state and fraction.</param>
        /// <param name="input">The input parameters defining the shapes, sweeps, and time interval.</param>
        /// <remarks>
        ///     Note: use <see cref="Distance"/> to compute the contact point and normal at the time of impact.
        /// </remarks>
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

            sweepA.Normalize();
            sweepB.Normalize();

            float tMax = input.TMax;

            float totalRadius = input.ProxyA.Radius + input.ProxyB.Radius;
            float target = Math.Max(SettingEnv.LinearSlop, totalRadius - 3.0f * SettingEnv.LinearSlop);
            const float tolerance = 0.25f * SettingEnv.LinearSlop;
            float t1 = 0.0f;
            const int kMaxIterations = 20;
            int iter = 0;

            DistanceInput distanceInput = new DistanceInput();
            distanceInput.ProxyA = input.ProxyA;
            distanceInput.ProxyB = input.ProxyB;
            distanceInput.UseRadii = false;

            while (true)
            {
                sweepA.GetTransform(out ControllerTransform xfA, t1);
                sweepB.GetTransform(out ControllerTransform xfB, t1);

                distanceInput.ControllerTransformA = xfA;
                distanceInput.ControllerTransformB = xfB;
                Distance.ComputeDistance(out DistanceOutput distanceOutput, out SimplexCache cache, distanceInput);

                if (distanceOutput.Distance <= 0.0f)
                {
                    output.State = ToiOutputState.Overlapped;
                    output.T = 0.0f;
                    break;
                }

                if (distanceOutput.Distance < target + tolerance)
                {
                    output.State = ToiOutputState.Touching;
                    output.T = t1;
                    break;
                }

                SeparationFunction.Set(ref cache, ref input.ProxyA, ref sweepA, ref input.ProxyB, ref sweepB, t1);

                bool done = false;
                float t2 = tMax;
                int pushBackIter = 0;
                while (true)
                {
                    float s2 = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, t2);

                    if (s2 > target + tolerance)
                    {
                        output.State = ToiOutputState.Seperated;
                        output.T = tMax;
                        done = true;
                        break;
                    }

                    if (s2 > target - tolerance)
                    {
                        t1 = t2;
                        break;
                    }

                    float s1 = SeparationFunction.Evaluate(indexA, indexB, t1);

                    if (s1 < target - tolerance)
                    {
                        output.State = ToiOutputState.Failed;
                        output.T = t1;
                        done = true;
                        break;
                    }

                    if (s1 <= target + tolerance)
                    {
                        output.State = ToiOutputState.Touching;
                        output.T = t1;
                        done = true;
                        break;
                    }

                    int rootIterCount = 0;
                    float a1 = t1, a2 = t2;
                    for (;;)
                    {
                        float t;
                        if ((rootIterCount & 1) != 0)
                        {
                            t = a1 + (target - s1) * (a2 - a1) / (s2 - s1);
                        }
                        else
                        {
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
                            t2 = t;
                            break;
                        }

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