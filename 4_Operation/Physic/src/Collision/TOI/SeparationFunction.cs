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

using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.TOI
{
    /// <summary>
    ///     The separation function class
    /// </summary>
    public static class SeparationFunction
    {
        /// <summary>
        ///     Initializes the cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="t1">The </param>
        /// <param name="axis">The axis</param>
        /// <param name="localPoint">The local point</param>
        /// <param name="type">The type</param>
        public static void Initialize(ref SimplexCache cache, DistanceProxy proxyA, ref Sweep sweepA,
            DistanceProxy proxyB, ref Sweep sweepB, float t1, out Vector2 axis, out Vector2 localPoint,
            out SeparationFunctionType type)
        {
            int count = cache.Count;
            Debug.Assert((0 < count) && (count < 3));

            sweepA.GetTransform(out Transform xfA, t1);
            sweepB.GetTransform(out Transform xfB, t1);

            if (count == 1)
            {
                localPoint = Vector2.Zero;
                type = SeparationFunctionType.Points;
                Vector2 localPointA = proxyA.Vertices[cache.IndexA[0]];
                Vector2 localPointB = proxyB.Vertices[cache.IndexB[0]];
                Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);
                Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);
                axis = pointB - pointA;
                axis = Vector2.Normalize(axis);
            }
            else if (cache.IndexA[0] == cache.IndexA[1])
            {
                // Two points on B and one on A.
                type = SeparationFunctionType.FaceB;
                Vector2 localPointB1 = proxyB.Vertices[cache.IndexB[0]];
                Vector2 localPointB2 = proxyB.Vertices[cache.IndexB[1]];

                Vector2 a = localPointB2 - localPointB1;
                axis = new Vector2(a.Y, -a.X);
                axis = Vector2.Normalize(axis);
                Vector2 normal = MathUtils.Mul(ref xfB.Rotation, axis);

                localPoint = 0.5f * (localPointB1 + localPointB2);
                Vector2 pointB = MathUtils.Mul(ref xfB, localPoint);

                Vector2 localPointA = proxyA.Vertices[cache.IndexA[0]];
                Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);

                float s = Vector2.Dot(pointA - pointB, normal);
                if (s < 0.0f)
                {
                    axis = -axis;
                }
            }
            else
            {
                // Two points on A and one or two points on B.
                type = SeparationFunctionType.FaceA;
                Vector2 localPointA1 = proxyA.Vertices[cache.IndexA[0]];
                Vector2 localPointA2 = proxyA.Vertices[cache.IndexA[1]];

                Vector2 a = localPointA2 - localPointA1;
                axis = new Vector2(a.Y, -a.X);
                axis = Vector2.Normalize(axis);
                Vector2 normal = MathUtils.Mul(ref xfA.Rotation, axis);

                localPoint = 0.5f * (localPointA1 + localPointA2);
                Vector2 pointA = MathUtils.Mul(ref xfA, localPoint);

                Vector2 localPointB = proxyB.Vertices[cache.IndexB[0]];
                Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);

                float s = Vector2.Dot(pointB - pointA, normal);
                if (s < 0.0f)
                {
                    axis = -axis;
                }
            }

            //Velcro note: the returned value that used to be here has been removed, as it was not used.
        }

        /// <summary>
        ///     Finds the min separation using the specified index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="axis">The axis</param>
        /// <param name="localPoint">The local point</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        public static float FindMinSeparation(out int indexA, out int indexB, float t, DistanceProxy proxyA,
            ref Sweep sweepA, DistanceProxy proxyB, ref Sweep sweepB, ref Vector2 axis, ref Vector2 localPoint,
            SeparationFunctionType type)
        {
            sweepA.GetTransform(out Transform xfA, t);
            sweepB.GetTransform(out Transform xfB, t);

            switch (type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2 axisA = MathUtils.MulT(ref xfA.Rotation, axis);
                    Vector2 axisB = MathUtils.MulT(ref xfB.Rotation, -axis);

                    indexA = proxyA.GetSupport(axisA);
                    indexB = proxyB.GetSupport(axisB);

                    Vector2 localPointA = proxyA.Vertices[indexA];
                    Vector2 localPointB = proxyB.Vertices[indexB];

                    Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);

                    float separation = Vector2.Dot(pointB - pointA, axis);
                    return separation;
                }

                case SeparationFunctionType.FaceA:
                {
                    Vector2 normal = MathUtils.Mul(ref xfA.Rotation, axis);
                    Vector2 pointA = MathUtils.Mul(ref xfA, localPoint);

                    Vector2 axisB = MathUtils.MulT(ref xfB.Rotation, -normal);

                    indexA = -1;
                    indexB = proxyB.GetSupport(axisB);

                    Vector2 localPointB = proxyB.Vertices[indexB];
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);

                    float separation = Vector2.Dot(pointB - pointA, normal);
                    return separation;
                }

                case SeparationFunctionType.FaceB:
                {
                    Vector2 normal = MathUtils.Mul(ref xfB.Rotation, axis);
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPoint);

                    Vector2 axisA = MathUtils.MulT(ref xfA.Rotation, -normal);

                    indexB = -1;
                    indexA = proxyA.GetSupport(axisA);

                    Vector2 localPointA = proxyA.Vertices[indexA];
                    Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);

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
        ///     Evaluates the index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="axis">The axis</param>
        /// <param name="localPoint">The local point</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        public static float Evaluate(int indexA, int indexB, float t, DistanceProxy proxyA, ref Sweep sweepA,
            DistanceProxy proxyB, ref Sweep sweepB, ref Vector2 axis, ref Vector2 localPoint,
            SeparationFunctionType type)
        {
            sweepA.GetTransform(out Transform xfA, t);
            sweepB.GetTransform(out Transform xfB, t);

            switch (type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2 localPointA = proxyA.Vertices[indexA];
                    Vector2 localPointB = proxyB.Vertices[indexB];

                    Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);
                    float separation = Vector2.Dot(pointB - pointA, axis);

                    return separation;
                }
                case SeparationFunctionType.FaceA:
                {
                    Vector2 normal = MathUtils.Mul(ref xfA.Rotation, axis);
                    Vector2 pointA = MathUtils.Mul(ref xfA, localPoint);

                    Vector2 localPointB = proxyB.Vertices[indexB];
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPointB);

                    float separation = Vector2.Dot(pointB - pointA, normal);
                    return separation;
                }
                case SeparationFunctionType.FaceB:
                {
                    Vector2 normal = MathUtils.Mul(ref xfB.Rotation, axis);
                    Vector2 pointB = MathUtils.Mul(ref xfB, localPoint);

                    Vector2 localPointA = proxyA.Vertices[indexA];
                    Vector2 pointA = MathUtils.Mul(ref xfA, localPointA);

                    float separation = Vector2.Dot(pointA - pointB, normal);
                    return separation;
                }
                default:
                    Debug.Assert(false);
                    return 0.0f;
            }
        }
    }
}