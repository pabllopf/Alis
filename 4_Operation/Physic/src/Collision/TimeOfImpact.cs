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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
#if XNAAPI
using Complex = nkast.Aether.Physics2D.Common.Complex;
using Vector2 = Microsoft.Xna.Framework.Vector2;
#endif

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Input parameters for CalculateTimeOfImpact
    /// </summary>
    public class TOIInput
    {
        /// <summary>
        /// The proxy
        /// </summary>
        public DistanceProxy ProxyA;
        /// <summary>
        /// The proxy
        /// </summary>
        public DistanceProxy ProxyB;
        /// <summary>
        /// The sweep
        /// </summary>
        public Sweep SweepA;
        /// <summary>
        /// The sweep
        /// </summary>
        public Sweep SweepB;
        /// <summary>
        /// The max
        /// </summary>
        public float TMax; // defines sweep interval [0, tMax]
    }

    /// <summary>
    /// The toi output state enum
    /// </summary>
    public enum TOIOutputState
    {
        /// <summary>
        /// The unknown toi output state
        /// </summary>
        Unknown,
        /// <summary>
        /// The failed toi output state
        /// </summary>
        Failed,
        /// <summary>
        /// The overlapped toi output state
        /// </summary>
        Overlapped,
        /// <summary>
        /// The touching toi output state
        /// </summary>
        Touching,
        /// <summary>
        /// The seperated toi output state
        /// </summary>
        Seperated
    }

    /// <summary>
    /// The toi output
    /// </summary>
    public struct TOIOutput
    {
        /// <summary>
        /// The state
        /// </summary>
        public TOIOutputState State;
        /// <summary>
        /// The 
        /// </summary>
        public float T;
    }

    /// <summary>
    /// The separation function type enum
    /// </summary>
    public enum SeparationFunctionType
    {
        /// <summary>
        /// The points separation function type
        /// </summary>
        Points,
        /// <summary>
        /// The face separation function type
        /// </summary>
        FaceA,
        /// <summary>
        /// The face separation function type
        /// </summary>
        FaceB
    }

    /// <summary>
    /// The separation function class
    /// </summary>
    public static class SeparationFunction
    {
        /// <summary>
        /// The axis
        /// </summary>
        [ThreadStatic] private static Vector2 _axis;

        /// <summary>
        /// The local point
        /// </summary>
        [ThreadStatic] private static Vector2 _localPoint;

        /// <summary>
        /// The proxy
        /// </summary>
        [ThreadStatic] private static DistanceProxy _proxyA;

        /// <summary>
        /// The proxy
        /// </summary>
        [ThreadStatic] private static DistanceProxy _proxyB;

        /// <summary>
        /// The sweep
        /// </summary>
        [ThreadStatic] private static Sweep _sweepA, _sweepB;

        /// <summary>
        /// The type
        /// </summary>
        [ThreadStatic] private static SeparationFunctionType _type;

        /// <summary>
        /// Sets the cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="t1">The </param>
        public static void Set(ref SimplexCache cache, ref DistanceProxy proxyA, ref Sweep sweepA, ref DistanceProxy proxyB, ref Sweep sweepB, float t1)
        {
            _localPoint = Vector2.Zero;
            _proxyA = proxyA;
            _proxyB = proxyB;
            int count = cache.Count;
            Debug.Assert((0 < count) && (count < 3));

            _sweepA = sweepA;
            _sweepB = sweepB;

            Transform xfA, xfB;
            _sweepA.GetTransform(out xfA, t1);
            _sweepB.GetTransform(out xfB, t1);

            if (count == 1)
            {
                _type = SeparationFunctionType.Points;
                Vector2 localPointA = _proxyA.Vertices[cache.IndexA[0]];
                Vector2 localPointB = _proxyB.Vertices[cache.IndexB[0]];
                Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);
                Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);
                _axis = pointB - pointA;
                _axis.Normalize();
            }
            else if (cache.IndexA[0] == cache.IndexA[1])
            {
                // Two points on B and one on A.
                _type = SeparationFunctionType.FaceB;
                Vector2 localPointB1 = proxyB.Vertices[cache.IndexB[0]];
                Vector2 localPointB2 = proxyB.Vertices[cache.IndexB[1]];

                Vector2 a = localPointB2 - localPointB1;
                _axis = new Vector2(a.Y, -a.X);
                _axis.Normalize();
                Vector2 normal = Complex.Multiply(ref _axis, ref xfB.q);

                _localPoint = 0.5f * (localPointB1 + localPointB2);
                Vector2 pointB = Transform.Multiply(ref _localPoint, ref xfB);

                Vector2 localPointA = proxyA.Vertices[cache.IndexA[0]];
                Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);

                float s = Vector2.Dot(pointA - pointB, normal);
                if (s < 0.0f)
                {
                    _axis = -_axis;
                }
            }
            else
            {
                // Two points on A and one or two points on B.
                _type = SeparationFunctionType.FaceA;
                Vector2 localPointA1 = _proxyA.Vertices[cache.IndexA[0]];
                Vector2 localPointA2 = _proxyA.Vertices[cache.IndexA[1]];

                Vector2 a = localPointA2 - localPointA1;
                _axis = new Vector2(a.Y, -a.X);
                _axis.Normalize();
                Vector2 normal = Complex.Multiply(ref _axis, ref xfA.q);

                _localPoint = 0.5f * (localPointA1 + localPointA2);
                Vector2 pointA = Transform.Multiply(ref _localPoint, ref xfA);

                Vector2 localPointB = _proxyB.Vertices[cache.IndexB[0]];
                Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);

                float s = Vector2.Dot(pointB - pointA, normal);
                if (s < 0.0f)
                {
                    _axis = -_axis;
                }
            }
        }

        /// <summary>
        /// Finds the min separation using the specified index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <returns>The float</returns>
        public static float FindMinSeparation(out int indexA, out int indexB, float t)
        {
            Transform xfA, xfB;
            _sweepA.GetTransform(out xfA, t);
            _sweepB.GetTransform(out xfB, t);

            switch (_type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2 axisA = Complex.Divide(ref _axis, ref xfA.q);
                    Vector2 axisB = -Complex.Divide(ref _axis, ref xfB.q);

                    indexA = _proxyA.GetSupport(axisA);
                    indexB = _proxyB.GetSupport(axisB);

                    Vector2 localPointA = _proxyA.Vertices[indexA];
                    Vector2 localPointB = _proxyB.Vertices[indexB];

                    Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);
                    Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2.Dot(pointB - pointA, _axis);
                    return separation;
                }

                case SeparationFunctionType.FaceA:
                {
                    Vector2 normal = Complex.Multiply(ref _axis, ref xfA.q);
                    Vector2 pointA = Transform.Multiply(ref _localPoint, ref xfA);

                    Vector2 axisB = -Complex.Divide(ref normal, ref xfB.q);

                    indexA = -1;
                    indexB = _proxyB.GetSupport(axisB);

                    Vector2 localPointB = _proxyB.Vertices[indexB];
                    Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2.Dot(pointB - pointA, normal);
                    return separation;
                }

                case SeparationFunctionType.FaceB:
                {
                    Vector2 normal = Complex.Multiply(ref _axis, ref xfB.q);
                    Vector2 pointB = Transform.Multiply(ref _localPoint, ref xfB);

                    Vector2 axisA = -Complex.Divide(ref normal, ref xfA.q);

                    indexB = -1;
                    indexA = _proxyA.GetSupport(axisA);

                    Vector2 localPointA = _proxyA.Vertices[indexA];
                    Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);

                    float separation = Vector2.Dot(pointA - pointB, normal);
                    return separation;
                }

                default:
                    Debug.Assert(false);
                    indexA = -1;
                    indexB = -1;
                    return 0.0f;
            }
        }

        /// <summary>
        /// Evaluates the index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <returns>The float</returns>
        public static float Evaluate(int indexA, int indexB, float t)
        {
            Transform xfA, xfB;
            _sweepA.GetTransform(out xfA, t);
            _sweepB.GetTransform(out xfB, t);

            switch (_type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2 localPointA = _proxyA.Vertices[indexA];
                    Vector2 localPointB = _proxyB.Vertices[indexB];

                    Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);
                    Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);
                    float separation = Vector2.Dot(pointB - pointA, _axis);

                    return separation;
                }
                case SeparationFunctionType.FaceA:
                {
                    Vector2 normal = Complex.Multiply(ref _axis, ref xfA.q);
                    Vector2 pointA = Transform.Multiply(ref _localPoint, ref xfA);

                    Vector2 localPointB = _proxyB.Vertices[indexB];
                    Vector2 pointB = Transform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2.Dot(pointB - pointA, normal);
                    return separation;
                }
                case SeparationFunctionType.FaceB:
                {
                    Vector2 normal = Complex.Multiply(ref _axis, ref xfB.q);
                    Vector2 pointB = Transform.Multiply(ref _localPoint, ref xfB);

                    Vector2 localPointA = _proxyA.Vertices[indexA];
                    Vector2 pointA = Transform.Multiply(ref localPointA, ref xfA);

                    float separation = Vector2.Dot(pointA - pointB, normal);
                    return separation;
                }
                default:
                    Debug.Assert(false);
                    return 0.0f;
            }
        }
    }

    /// <summary>
    /// The time of impact class
    /// </summary>
    public static class TimeOfImpact
    {
        // CCD via the local separating axis method. This seeks progression
        // by computing the largest time at which separation is maintained.

        /// <summary>
        /// The toi max iters
        /// </summary>
        [ThreadStatic] public static int TOICalls, TOIIters, TOIMaxIters;

        /// <summary>
        /// The toi max root iters
        /// </summary>
        [ThreadStatic] public static int TOIRootIters, TOIMaxRootIters;

        /// <summary>
        ///     Compute the upper bound on time before two shapes penetrate. Time is represented as
        ///     a fraction between [0,tMax]. This uses a swept separating axis and may miss some intermediate,
        ///     non-tunneling collision. If you change the time interval, you should call this function
        ///     again.
        ///     Note: use Distance() to compute the contact point and normal at the time of impact.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="input">The input.</param>
        public static void CalculateTimeOfImpact(out TOIOutput output, ref TOIInput input)
        {
            if (Settings.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                ++TOICalls;

            output = new TOIOutput();
            output.State = TOIOutputState.Unknown;
            output.T = input.TMax;

            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;

            // Large rotations can make the root finder fail, so we normalize the
            // sweep angles.
            sweepA.Normalize();
            sweepB.Normalize();

            float tMax = input.TMax;

            float totalRadius = input.ProxyA.Radius + input.ProxyB.Radius;
            float target = Math.Max(Settings.LinearSlop, totalRadius - 3.0f * Settings.LinearSlop);
            const float tolerance = 0.25f * Settings.LinearSlop;
            Debug.Assert(target > tolerance);

            float t1 = 0.0f;
            const int k_maxIterations = 20;
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
                Transform xfA, xfB;
                sweepA.GetTransform(out xfA, t1);
                sweepB.GetTransform(out xfB, t1);

                // Get the distance between shapes. We can also use the results
                // to get a separating axis.
                distanceInput.TransformA = xfA;
                distanceInput.TransformB = xfB;
                DistanceOutput distanceOutput;
                SimplexCache cache;
                Distance.ComputeDistance(out distanceOutput, out cache, distanceInput);

                // If the shapes are overlapped, we give up on continuous collision.
                if (distanceOutput.Distance <= 0.0f)
                {
                    // Failure!
                    output.State = TOIOutputState.Overlapped;
                    output.T = 0.0f;
                    break;
                }

                if (distanceOutput.Distance < target + tolerance)
                {
                    // Victory!
                    output.State = TOIOutputState.Touching;
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
                    int indexA, indexB;
                    float s2 = SeparationFunction.FindMinSeparation(out indexA, out indexB, t2);

                    // Is the final configuration separated?
                    if (s2 > target + tolerance)
                    {
                        // Victory!
                        output.State = TOIOutputState.Seperated;
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
                        output.State = TOIOutputState.Failed;
                        output.T = t1;
                        done = true;
                        break;
                    }

                    // Check for touching
                    if (s1 <= target + tolerance)
                    {
                        // Victory! t1 should hold the TOI (could be 0.0).
                        output.State = TOIOutputState.Touching;
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

                        if (Settings.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                            ++TOIRootIters;

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

                    if (Settings.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                        TOIMaxRootIters = Math.Max(TOIMaxRootIters, rootIterCount);

                    ++pushBackIter;

                    if (pushBackIter == Settings.MaxPolygonVertices)
                    {
                        break;
                    }
                }

                ++iter;

                if (Settings.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                    ++TOIIters;

                if (done)
                {
                    break;
                }

                if (iter == k_maxIterations)
                {
                    // Root finder got stuck. Semi-victory.
                    output.State = TOIOutputState.Failed;
                    output.T = t1;
                    break;
                }
            }

            if (Settings.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                TOIMaxIters = Math.Max(TOIMaxIters, iter);
        }
    }
}