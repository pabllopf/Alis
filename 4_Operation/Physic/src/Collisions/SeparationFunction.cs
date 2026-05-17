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
    ///     Computes the separation distance between two convex shapes at a given time fraction during continuous collision detection.
    /// </summary>
    /// <remarks>
    ///     This class is used by the TOI (Time of Impact) solver to evaluate how far apart two shapes are
    ///     at a specific point in time. It maintains thread-static state for the separation axis, local point,
    ///     proxies, and sweeps to avoid allocations during iterative distance evaluation.
    ///     
    ///     The separation function can operate in three modes:
    ///     <list type="bullet">
    ///         <item><term>Points</term><description>Both shapes contribute a single vertex.</description></item>
    ///         <item><term>FaceA</term><description>Shape A contributes a face, Shape B contributes a vertex.</description></item>
    ///         <item><term>FaceB</term><description>Shape B contributes a face, Shape A contributes a vertex.</description></item>
    ///     </list>
    /// </remarks>
    public static class SeparationFunction
    {
        /// <summary>
        ///     Gets or sets the separation axis in world space.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the direction along which separation is measured.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static Vector2F _axis;

        /// <summary>
        ///     Gets or sets the local point on the reference face.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> in local shape space representing the center of the reference face.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static Vector2F _localPoint;

        /// <summary>
        ///     Gets or sets the distance proxy for shape A.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to shape A's vertices and radius.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static DistanceProxy _proxyA;

        /// <summary>
        ///     Gets or sets the distance proxy for shape B.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to shape B's vertices and radius.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static DistanceProxy _proxyB;

        /// <summary>
        ///     Gets or sets the sweeps for both shapes.
        /// </summary>
        /// <value>
        ///     Two <see cref="Sweep"/> objects representing the continuous motion of each shape.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static Sweep _sweepA, _sweepB;

        /// <summary>
        ///     Gets or sets the type of separation function currently active.
        /// </summary>
        /// <value>
        ///     A <see cref="SeparationFunctionType"/> indicating whether the function evaluates points, FaceA, or FaceB.
        /// </value>
        /// <remarks>
        ///     Thread-static to avoid allocations during iterative TOI evaluation.
        /// </remarks>
        [ThreadStatic] private static SeparationFunctionType _type;

        /// <summary>
        ///     Initializes the separation function with proxy and sweep data from a simplex cache.
        /// </summary>
        /// <param name="cache">The simplex cache from the previous GJK iteration.</param>
        /// <param name="proxyA">The distance proxy for shape A.</param>
        /// <param name="sweepA">The sweep object for shape A's continuous motion.</param>
        /// <param name="proxyB">The distance proxy for shape B.</param>
        /// <param name="sweepB">The sweep object for shape B's continuous motion.</param>
        /// <param name="t1">The fractional time value (0.0 to 1.0) for initializing the transform.</param>
        /// <remarks>
        ///     Sets up the separation axis and type based on the simplex cache configuration.
        ///     The axis is oriented to point from shape A toward shape B.
        /// </remarks>
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
        ///     Finds the minimum separation distance between the two shapes at the given time fraction.
        /// </summary>
        /// <param name="indexA">When this method returns, contains the index of the support point on shape A. -1 if a face is used.</param>
        /// <param name="indexB">When this method returns, contains the index of the support point on shape B. -1 if a face is used.</param>
        /// <param name="t">The fractional time value (0.0 to 1.0) for evaluating the transforms.</param>
        /// <returns>
        ///     A <see cref="float"/> representing the minimum separation distance. Positive values indicate gap; negative indicates penetration.
        /// </returns>
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
        ///     Evaluates the separation distance at specific support point indices and time fraction.
        /// </summary>
        /// <param name="indexA">The index of the support point on shape A. -1 if a face is used.</param>
        /// <param name="indexB">The index of the support point on shape B. -1 if a face is used.</param>
        /// <param name="t">The fractional time value (0.0 to 1.0) for evaluating the transforms.</param>
        /// <returns>
        ///     A <see cref="float"/> representing the separation distance at the given indices and time. Positive indicates gap; negative indicates penetration.
        /// </returns>
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