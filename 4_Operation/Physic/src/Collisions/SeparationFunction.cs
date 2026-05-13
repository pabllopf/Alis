// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunction.cs
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
    ///     Implements the separation function used for continuous collision detection (CCD) via the time of impact (TOI)
    ///     algorithm. Computes the minimum separation between two shapes at a given time and evaluates separation
    ///     along different function types (points, face A, face B) derived from the GJK simplex cache.
    /// </summary>
    public static class SeparationFunction
    {
        /// <summary>
        ///     The current separating axis direction used for computing distances.
        /// </summary>
        [ThreadStatic] private static Vector2F _axis;

        /// <summary>
        ///     The local point on the reference face used for face-type separation computations.
        /// </summary>
        [ThreadStatic] private static Vector2F _localPoint;

        /// <summary>
        ///     The distance proxy for the first shape (A), providing vertex access for support queries.
        /// </summary>
        [ThreadStatic] private static DistanceProxy _proxyA;

        /// <summary>
        ///     The distance proxy for the second shape (B), providing vertex access for support queries.
        /// </summary>
        [ThreadStatic] private static DistanceProxy _proxyB;

        /// <summary>
        ///     The sweep motion data for shape A and shape B, used to interpolate transforms over time.
        /// </summary>
        [ThreadStatic] private static Sweep _sweepA, _sweepB;

        /// <summary>
        ///     The type of separation function to use, determined by the simplex cache configuration.
        /// </summary>
        [ThreadStatic] private static SeparationFunctionType _type;

        /// <summary>
        ///     Initializes the separation function from a simplex cache and two shape proxies with their motion sweeps.
        ///     Determines whether the separation function operates on point-to-point, face A, or face B mode based
        ///     on the simplex cache vertex configuration.
        /// </summary>
        /// <param name="cache">The simplex cache from the GJK distance computation, containing vertex indices and count.</param>
        /// <param name="proxyA">The distance proxy for shape A.</param>
        /// <param name="sweepA">The motion sweep data for shape A.</param>
        /// <param name="proxyB">The distance proxy for shape B.</param>
        /// <param name="sweepB">The motion sweep data for shape B.</param>
        /// <param name="t1">The initial time parameter at which to evaluate the transforms.</param>
        public static void Set(ref SimplexCache cache, ref DistanceProxy proxyA, ref Sweep sweepA, ref DistanceProxy proxyB, ref Sweep sweepB, float t1)
        {
            _localPoint = Vector2F.Zero;
            _proxyA = proxyA;
            _proxyB = proxyB;
            int count = cache.Count;
            _sweepA = sweepA;
            _sweepB = sweepB;

            _sweepA.GetTransform(out ControllerTransform xfA, t1);
            _sweepB.GetTransform(out ControllerTransform xfB, t1);

            if (count == 1)
            {
                _type = SeparationFunctionType.Points;
                Vector2F localPointA = _proxyA.Vertices[cache.IndexA[0]];
                Vector2F localPointB = _proxyB.Vertices[cache.IndexB[0]];
                Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);
                Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);
                _axis = pointB - pointA;
                _axis.Normalize();
            }
            else if (cache.IndexA[0] == cache.IndexA[1])
            {
                // Two points on B and one on A.
                _type = SeparationFunctionType.FaceB;
                Vector2F localPointB1 = proxyB.Vertices[cache.IndexB[0]];
                Vector2F localPointB2 = proxyB.Vertices[cache.IndexB[1]];

                Vector2F a = localPointB2 - localPointB1;
                _axis = new Vector2F(a.Y, -a.X);
                _axis.Normalize();
                Vector2F normal = Complex.Multiply(ref _axis, ref xfB.Rotation);

                _localPoint = 0.5f * (localPointB1 + localPointB2);
                Vector2F pointB = ControllerTransform.Multiply(ref _localPoint, ref xfB);

                Vector2F localPointA = proxyA.Vertices[cache.IndexA[0]];
                Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);

                float s = Vector2F.Dot(pointA - pointB, normal);
                if (s < 0.0f)
                {
                    _axis = -_axis;
                }
            }
            else
            {
                // Two points on A and one or two points on B.
                _type = SeparationFunctionType.FaceA;
                Vector2F localPointA1 = _proxyA.Vertices[cache.IndexA[0]];
                Vector2F localPointA2 = _proxyA.Vertices[cache.IndexA[1]];

                Vector2F a = localPointA2 - localPointA1;
                _axis = new Vector2F(a.Y, -a.X);
                _axis.Normalize();
                Vector2F normal = Complex.Multiply(ref _axis, ref xfA.Rotation);

                _localPoint = 0.5f * (localPointA1 + localPointA2);
                Vector2F pointA = ControllerTransform.Multiply(ref _localPoint, ref xfA);

                Vector2F localPointB = _proxyB.Vertices[cache.IndexB[0]];
                Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);

                float s = Vector2F.Dot(pointB - pointA, normal);
                if (s < 0.0f)
                {
                    _axis = -_axis;
                }
            }
        }

        /// <summary>
        ///     Computes the minimum separation distance between the two shapes at the specified time parameter.
        ///     Determines the support vertices on each shape that achieve the minimum separation along the
        ///     current separation axis. The separation type (points, face A, face B) determines how the
        ///     axis and witness points are derived.
        /// </summary>
        /// <param name="indexA">When this method returns, contains the support vertex index on shape A.</param>
        /// <param name="indexB">When this method returns, contains the support vertex index on shape B.</param>
        /// <param name="t">The time parameter at which to evaluate the separation (used to interpolate transforms from the sweeps).</param>
        /// <returns>The minimum separation distance. Positive values indicate shapes are separated; negative or zero indicates overlap or contact.</returns>
        public static float FindMinSeparation(out int indexA, out int indexB, float t)
        {
            _sweepA.GetTransform(out ControllerTransform xfA, t);
            _sweepB.GetTransform(out ControllerTransform xfB, t);

            switch (_type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2F axisA = Complex.Divide(ref _axis, ref xfA.Rotation);
                    Vector2F axisB = -Complex.Divide(ref _axis, ref xfB.Rotation);

                    indexA = _proxyA.GetSupport(axisA);
                    indexB = _proxyB.GetSupport(axisB);

                    Vector2F localPointA = _proxyA.Vertices[indexA];
                    Vector2F localPointB = _proxyB.Vertices[indexB];

                    Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);
                    Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2F.Dot(pointB - pointA, _axis);
                    return separation;
                }

                case SeparationFunctionType.FaceA:
                {
                    Vector2F normal = Complex.Multiply(ref _axis, ref xfA.Rotation);
                    Vector2F pointA = ControllerTransform.Multiply(ref _localPoint, ref xfA);

                    Vector2F axisB = -Complex.Divide(ref normal, ref xfB.Rotation);

                    indexA = -1;
                    indexB = _proxyB.GetSupport(axisB);

                    Vector2F localPointB = _proxyB.Vertices[indexB];
                    Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2F.Dot(pointB - pointA, normal);
                    return separation;
                }

                case SeparationFunctionType.FaceB:
                {
                    Vector2F normal = Complex.Multiply(ref _axis, ref xfB.Rotation);
                    Vector2F pointB = ControllerTransform.Multiply(ref _localPoint, ref xfB);

                    Vector2F axisA = -Complex.Divide(ref normal, ref xfA.Rotation);

                    indexB = -1;
                    indexA = _proxyA.GetSupport(axisA);

                    Vector2F localPointA = _proxyA.Vertices[indexA];
                    Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);

                    float separation = Vector2F.Dot(pointA - pointB, normal);
                    return separation;
                }

                default:
                    indexA = -1;
                    indexB = -1;
                    return 0.0f;
            }
        }

        /// <summary>
        ///     Evaluates the separation distance at the specified time for given support vertex indices.
        ///     Unlike <see cref="FindMinSeparation"/>, this method uses pre-determined vertex indices
        ///     rather than finding the support vertices, making it suitable for binary search refinement
        ///     in the TOI algorithm.
        /// </summary>
        /// <param name="indexA">The support vertex index on shape A (use -1 for face-type where only one shape's vertex is needed).</param>
        /// <param name="indexB">The support vertex index on shape B (use -1 for face-type where only one shape's vertex is needed).</param>
        /// <param name="t">The time parameter at which to evaluate the separation.</param>
        /// <returns>The separation distance at the given time for the specified vertices.</returns>
        public static float Evaluate(int indexA, int indexB, float t)
        {
            _sweepA.GetTransform(out ControllerTransform xfA, t);
            _sweepB.GetTransform(out ControllerTransform xfB, t);

            switch (_type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2F localPointA = _proxyA.Vertices[indexA];
                    Vector2F localPointB = _proxyB.Vertices[indexB];

                    Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);
                    Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);
                    float separation = Vector2F.Dot(pointB - pointA, _axis);

                    return separation;
                }
                case SeparationFunctionType.FaceA:
                {
                    Vector2F normal = Complex.Multiply(ref _axis, ref xfA.Rotation);
                    Vector2F pointA = ControllerTransform.Multiply(ref _localPoint, ref xfA);

                    Vector2F localPointB = _proxyB.Vertices[indexB];
                    Vector2F pointB = ControllerTransform.Multiply(ref localPointB, ref xfB);

                    float separation = Vector2F.Dot(pointB - pointA, normal);
                    return separation;
                }
                case SeparationFunctionType.FaceB:
                {
                    Vector2F normal = Complex.Multiply(ref _axis, ref xfB.Rotation);
                    Vector2F pointB = ControllerTransform.Multiply(ref _localPoint, ref xfB);

                    Vector2F localPointA = _proxyA.Vertices[indexA];
                    Vector2F pointA = ControllerTransform.Multiply(ref localPointA, ref xfA);

                    float separation = Vector2F.Dot(pointA - pointB, normal);
                    return separation;
                }
                default:
                    return 0.0f;
            }
        }
    }
}