// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SeparationFunction.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The separation function
    /// </summary>
    internal struct SeparationFunction
    {
        /// <summary>
        ///     The type enum
        /// </summary>
        internal enum Type
        {
            /// <summary>
            ///     The points type
            /// </summary>
            Points,

            /// <summary>
            ///     The face type
            /// </summary>
            FaceA,

            /// <summary>
            ///     The face type
            /// </summary>
            FaceB
        }

        /// <summary>
        ///     Initializes the cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="shapeA">The shape</param>
        /// <param name="transformA">The transform</param>
        /// <param name="shapeB">The shape</param>
        /// <param name="transformB">The transform</param>
        internal unsafe void Initialize(SimplexCache* cache,
            Shape shapeA, XForm transformA,
            Shape shapeB, XForm transformB)
        {
            ShapeA = shapeA;
            ShapeB = shapeB;
            int count = cache->Count;
            Box2DxDebug.Assert(0 < count && count < 3);

            if (count == 1)
            {
                FaceType = Type.Points;
                Vector2 localPointA = ShapeA.GetVertex(cache->IndexA[0]);
                Vector2 localPointB = ShapeB.GetVertex(cache->IndexB[0]);
                Vector2 pointA = Math.Mul(transformA, localPointA);
                Vector2 pointB = Math.Mul(transformB, localPointB);
                Axis = pointB - pointA;
                Axis.Normalize();
            }
            else if (cache->IndexB[0] == cache->IndexB[1])
            {
                // Two points on A and one on B
                FaceType = Type.FaceA;
                Vector2 localPointA1 = ShapeA.GetVertex(cache->IndexA[0]);
                Vector2 localPointA2 = ShapeA.GetVertex(cache->IndexA[1]);
                Vector2 localPointB = ShapeB.GetVertex(cache->IndexB[0]);
                LocalPoint = 0.5f * (localPointA1 + localPointA2);
                Axis = Vector2.Cross(localPointA2 - localPointA1, 1.0f);
                Axis.Normalize();

                Vector2 normal = Math.Mul(transformA.R, Axis);
                Vector2 pointA = Math.Mul(transformA, LocalPoint);
                Vector2 pointB = Math.Mul(transformB, localPointB);

                float s = Vector2.Dot(pointB - pointA, normal);
                if (s < 0.0f)
                {
                    Axis = -Axis;
                }
            }
            else
            {
                // Two points on B and one or two points on A.
                // We ignore the second point on A.
                FaceType = Type.FaceB;
                Vector2 localPointA = shapeA.GetVertex(cache->IndexA[0]);
                Vector2 localPointB1 = shapeB.GetVertex(cache->IndexB[0]);
                Vector2 localPointB2 = shapeB.GetVertex(cache->IndexB[1]);
                LocalPoint = 0.5f * (localPointB1 + localPointB2);
                Axis = Vector2.Cross(localPointB2 - localPointB1, 1.0f);
                Axis.Normalize();

                Vector2 normal = Math.Mul(transformB.R, Axis);
                Vector2 pointB = Math.Mul(transformB, LocalPoint);
                Vector2 pointA = Math.Mul(transformA, localPointA);

                float s = Vector2.Dot(pointA - pointB, normal);
                if (s < 0.0f)
                {
                    Axis = -Axis;
                }
            }
        }

        /// <summary>
        ///     Evaluates the transform a
        /// </summary>
        /// <param name="transformA">The transform</param>
        /// <param name="transformB">The transform</param>
        /// <returns>The float</returns>
        internal float Evaluate(XForm transformA, XForm transformB)
        {
            switch (FaceType)
            {
                case Type.Points:
                {
                    Vector2 axisA = Math.MulT(transformA.R, Axis);
                    Vector2 axisB = Math.MulT(transformB.R, -Axis);
                    Vector2 localPointA = ShapeA.GetSupportVertex(axisA);
                    Vector2 localPointB = ShapeB.GetSupportVertex(axisB);
                    Vector2 pointA = Math.Mul(transformA, localPointA);
                    Vector2 pointB = Math.Mul(transformB, localPointB);
                    float separation = Vector2.Dot(pointB - pointA, Axis);
                    return separation;
                }

                case Type.FaceA:
                {
                    Vector2 normal = Math.Mul(transformA.R, Axis);
                    Vector2 pointA = Math.Mul(transformA, LocalPoint);

                    Vector2 axisB = Math.MulT(transformB.R, -normal);

                    Vector2 localPointB = ShapeB.GetSupportVertex(axisB);
                    Vector2 pointB = Math.Mul(transformB, localPointB);

                    float separation = Vector2.Dot(pointB - pointA, normal);
                    return separation;
                }

                case Type.FaceB:
                {
                    Vector2 normal = Math.Mul(transformB.R, Axis);
                    Vector2 pointB = Math.Mul(transformB, LocalPoint);

                    Vector2 axisA = Math.MulT(transformA.R, -normal);

                    Vector2 localPointA = ShapeA.GetSupportVertex(axisA);
                    Vector2 pointA = Math.Mul(transformA, localPointA);

                    float separation = Vector2.Dot(pointA - pointB, normal);
                    return separation;
                }

                default:
                    Box2DxDebug.Assert(false);
                    return 0.0f;
            }
        }

        /// <summary>
        ///     The shape
        /// </summary>
        internal Shape ShapeA;

        /// <summary>
        ///     The shape
        /// </summary>
        internal Shape ShapeB;

        /// <summary>
        ///     The face type
        /// </summary>
        internal Type FaceType;

        /// <summary>
        ///     The local point
        /// </summary>
        internal Vector2 LocalPoint;

        /// <summary>
        ///     The axis
        /// </summary>
        internal Vector2 Axis;
    }
}