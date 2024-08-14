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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Config;

namespace Alis.Core.Physic.Collision.TOI
{
    /// <summary>
    ///     The time of impact class
    /// </summary>
    public static class TimeOfImpact
    {
        /// <summary>
        ///     The toi max root iter
        /// </summary>
        [ThreadStatic] internal static int _toiMaxRootIter;
        
        /// <summary>
        ///     The toi max iter
        /// </summary>
        [field: ThreadStatic]
        internal static int ToiCalls { get; set; }
        
        /// <summary>
        ///     The toi max iter
        /// </summary>
        [field: ThreadStatic]
        internal static int ToiIter { get; set; }
        
        /// <summary>
        ///     The toi max iter
        /// </summary>
        [field: ThreadStatic]
        internal static int ToiMaxIter { get; set; }
        
        /// <summary>
        ///     The toi max root iter
        /// </summary>
        [field: ThreadStatic]
        internal static int ToiRootIter { get; set; }
        
        /// <summary>
        ///     Calculates the time of impact using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        public static void CalculateTimeOfImpact(ref ToiInput input, out ToiOutput output)
        {
            ++ToiCalls;
            
            output = InitializeOutput(input);
            
            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;
            
            NormalizeSweeps(ref sweepA, ref sweepB);
            
            float tMax = input.Max;
            
            float totalRadius = input.ProxyA.Radius + input.ProxyB.Radius;
            float target = Math.Max(Settings.LinearSlop, totalRadius - 3.0f * Settings.LinearSlop);
            float tolerance = 0.25f * Settings.LinearSlop;
            Debug.Assert(target > tolerance);
            
            float t1 = 0.0f;
            int iter = 0;
            
            DistanceInput distanceInput = PrepareDistanceInput(input);
            
            ComputeSeparatingAxes(ref input, ref output, ref distanceInput, ref sweepA, ref sweepB, target, tolerance, ref t1, ref iter, tMax);
            
            ToiMaxIter = Math.Max(ToiMaxIter, iter);
        }
        
        /// <summary>
        ///     Initializes the output using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The toi output</returns>
        internal static ToiOutput InitializeOutput(ToiInput input) => new ToiOutput
        {
            State = ToiOutputState.Unknown,
            Property = input.Max
        };
        
        /// <summary>
        ///     Normalizes the sweeps using the specified sweep a
        /// </summary>
        /// <param name="sweepA">The sweep</param>
        /// <param name="sweepB">The sweep</param>
        internal static void NormalizeSweeps(ref Sweep sweepA, ref Sweep sweepB)
        {
            sweepA.Normalize();
            sweepB.Normalize();
        }
        
        /// <summary>
        ///     Prepares the distance input using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The distance input</returns>
        internal static DistanceInput PrepareDistanceInput(ToiInput input) => new DistanceInput
        {
            ProxyA = input.ProxyA,
            ProxyB = input.ProxyB,
            UseRadii = false
        };
        
        /// <summary>
        ///     Computes the separating axes using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        /// <param name="distanceInput">The distance input</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="target">The target</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="t1">The </param>
        /// <param name="iter">The iter</param>
        /// <param name="tMax">The max</param>
        internal static void ComputeSeparatingAxes(ref ToiInput input, ref ToiOutput output, ref DistanceInput distanceInput, ref Sweep sweepA, ref Sweep sweepB, float target, float tolerance, ref float t1, ref int iter, float tMax)
        {
            for (;;)
            {
                sweepA.GetTransform(out Transform xfA, t1);
                sweepB.GetTransform(out Transform xfB, t1);
                
                distanceInput.TransformA = xfA;
                distanceInput.TransformB = xfB;
                DistanceGjk.ComputeDistance(ref distanceInput, out DistanceOutput distanceOutput, out SimplexCache cache);
                
                if (distanceOutput.Distance <= 0.0f)
                {
                    output.State = ToiOutputState.Overlapped;
                    output.Property = 0.0f;
                    break;
                }
                
                if (distanceOutput.Distance < target + tolerance)
                {
                    output.State = ToiOutputState.Touching;
                    output.Property = t1;
                    break;
                }
                
                SeparationFunction.Initialize(ref cache, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, t1, out Vector2 axis, out Vector2 localPoint, out SeparationFunctionType type);
                
                ResolveDeepestPoint(ref input, ref output, ref sweepA, ref sweepB, ref axis, ref localPoint, type, target, tolerance, ref t1, tMax);
                
                ++iter;
                ++ToiIter;
                
                if (output.State != ToiOutputState.Unknown)
                {
                    break;
                }
            }
        }
        
        /// <summary>
        ///     Resolves the deepest point using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="axis">The axis</param>
        /// <param name="localPoint">The local point</param>
        /// <param name="type">The type</param>
        /// <param name="target">The target</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="t1">The </param>
        /// <param name="tMax">The max</param>
        internal static void ResolveDeepestPoint(ref ToiInput input, ref ToiOutput output, ref Sweep sweepA, ref Sweep sweepB, ref Vector2 axis, ref Vector2 localPoint, SeparationFunctionType type, float target, float tolerance, ref float t1, float tMax)
        {
            float t2 = tMax;
            int pushBackIter = 0;
            for (;;)
            {
                float s2 = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, t2, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, ref axis, ref localPoint, type);
                
                if (s2 > target + tolerance)
                {
                    output.State = ToiOutputState.Seperated;
                    output.Property = tMax;
                    break;
                }
                
                if (s2 > target - tolerance)
                {
                    t1 = t2;
                    break;
                }
                
                float s1 = SeparationFunction.Evaluate(indexA, indexB, t1, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, ref axis, ref localPoint, type);
                
                if (s1 < target - tolerance)
                {
                    output.State = ToiOutputState.Failed;
                    output.Property = t1;
                    break;
                }
                
                if (s1 <= target + tolerance)
                {
                    output.State = ToiOutputState.Touching;
                    output.Property = t1;
                    break;
                }
                
                ComputeRoot(ref input, ref sweepA, ref sweepB, ref axis, ref localPoint, type, target, tolerance, ref t1, ref t2, s1, s2);
                
                ++pushBackIter;
                
                if (pushBackIter == Settings.PolygonVertices)
                {
                    break;
                }
            }
        }
        
        /// <summary>
        ///     Computes the root using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="axis">The axis</param>
        /// <param name="localPoint">The local point</param>
        /// <param name="type">The type</param>
        /// <param name="target">The target</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="t1">The </param>
        /// <param name="t2">The </param>
        /// <param name="s1">The </param>
        /// <param name="s2">The </param>
        internal static void ComputeRoot(ref ToiInput input, ref Sweep sweepA, ref Sweep sweepB, ref Vector2 axis, ref Vector2 localPoint, SeparationFunctionType type, float target, float tolerance, ref float t1, ref float t2, float s1, float s2)
        {
            int rootIterCount = 0;
            float a1 = t1, a2 = t2;
            SeparationFunction.FindMinSeparation(out int indexA, out int indexB, t1, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, ref axis, ref localPoint, type);
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
                ++ToiRootIter;
                
                float s = SeparationFunction.Evaluate(indexA, indexB, t, input.ProxyA, ref sweepA, input.ProxyB, ref sweepB, ref axis, ref localPoint, type);
                
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
            
            _toiMaxRootIter = Math.Max(_toiMaxRootIter, rootIterCount);
        }
    }
}