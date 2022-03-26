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

using System.Numerics;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The separation function
    /// </summary>
    internal struct SeparationFunction
    {
        /// <summary>
        ///     The proxya
        /// </summary>
        private DistanceProxy m_proxyA;

        /// <summary>
        ///     The proxyb
        /// </summary>
        private DistanceProxy m_proxyB;

        /// <summary>
        ///     The sweepa
        /// </summary>
        private Sweep m_sweepA;

        /// <summary>
        ///     The sweepb
        /// </summary>
        private Sweep m_sweepB;

        /// <summary>
        ///     The type
        /// </summary>
        private SeparationFunctionType m_type;

        /// <summary>
        ///     The axis
        /// </summary>
        private Vector2 m_axis;

        /// <summary>
        ///     The localpoint
        /// </summary>
        private Vector2 m_localPoint;

        /// <summary>
        ///     The separation function type enum
        /// </summary>
        private enum SeparationFunctionType
        {
            /// <summary>
            ///     The points separation function type
            /// </summary>
            Points,

            /// <summary>
            ///     The face separation function type
            /// </summary>
            FaceA,

            /// <summary>
            ///     The face separation function type
            /// </summary>
            FaceB
        }

        /// <summary>
        ///     Initializes the cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="sweepA">The sweep</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="sweepB">The sweep</param>
        /// <param name="t1">The </param>
        /// <returns>The float</returns>
        internal float Initialize(
            SimplexCache cache,
            in DistanceProxy proxyA,
            in Sweep sweepA,
            in DistanceProxy proxyB,
            in Sweep sweepB,
            float t1)
        {
            m_proxyA = proxyA;
            m_proxyB = proxyB;
            int count = cache.count;
            //Debug.Assert(0 < count && count < 3);

            m_sweepA = sweepA;
            m_sweepB = sweepB;

            m_sweepA.GetTransform(out Transform xfA, t1);
            m_sweepB.GetTransform(out Transform xfB, t1);

            if (count == 1)
            {
                m_type = SeparationFunctionType.Points;
                Vector2 localPointA = m_proxyA._vertices[cache.indexA[0]];
                Vector2 localPointB = m_proxyB._vertices[cache.indexB[0]];
                Vector2 pointA = Math.Mul(xfA, localPointA);
                Vector2 pointB = Math.Mul(xfB, localPointB);
                m_axis = pointB - pointA;
                float s = m_axis.Length();
                m_axis = Vector2.Normalize(m_axis);
                return s;
            }

            if (cache.indexA[0] == cache.indexA[1])
            {
                // Two points on B and one on A.
                m_type = SeparationFunctionType.FaceB;
                Vector2 localPointB1 = proxyB._vertices[cache.indexB[0]];
                Vector2 localPointB2 = proxyB._vertices[cache.indexB[1]];

                m_axis = Vector2.Normalize(Vectex.Cross(localPointB2 - localPointB1, 1.0f));
                Vector2 normal = Vector2.Transform(m_axis, xfB.q); // Math.Mul(xfB.q, m_axis);

                m_localPoint = 0.5f * (localPointB1 + localPointB2);
                Vector2 pointB = Math.Mul(xfB, m_localPoint);

                Vector2 localPointA = proxyA._vertices[cache.indexA[0]];
                Vector2 pointA = Math.Mul(xfA, localPointA);

                float s = Vector2.Dot(pointA - pointB, normal);
                if (s < 0.0f)
                {
                    m_axis = -m_axis;
                    s = -s;
                }

                return s;
            }

            {
                // Two points on A and one or two points on B.
                m_type = SeparationFunctionType.FaceA;
                Vector2 localPointA1 = m_proxyA._vertices[cache.indexA[0]];
                Vector2 localPointA2 = m_proxyA._vertices[cache.indexA[1]];

                m_axis = Vector2.Normalize(Vectex.Cross(localPointA2 - localPointA1, 1.0f));
                Vector2 normal = Vector2.Transform(m_axis, xfA.q); // Math.Mul(xfA.q, m_axis);

                m_localPoint = 0.5f * (localPointA1 + localPointA2);
                Vector2 pointA = Math.Mul(xfA, m_localPoint);

                Vector2 localPointB = m_proxyB._vertices[cache.indexB[0]];
                Vector2 pointB = Math.Mul(xfB, localPointB);

                float s = Vector2.Dot(pointB - pointA, normal);
                if (s < 0.0f)
                {
                    m_axis = -m_axis;
                    s = -s;
                }

                return s;
            }
        }

        /// <summary>
        ///     Evaluates the index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <returns>The float</returns>
        internal float Evaluate(int indexA, int indexB, float t)
        {
            m_sweepA.GetTransform(out Transform xfA, t);
            m_sweepB.GetTransform(out Transform xfB, t);

            if (m_type == SeparationFunctionType.Points)
            {
                Vector2 localPointA = m_proxyA._vertices[indexA];
                Vector2 localPointB = m_proxyB._vertices[indexB];

                Vector2 pointA = Math.Mul(xfA, localPointA);
                Vector2 pointB = Math.Mul(xfB, localPointB);
                return Vector2.Dot(pointB - pointA, m_axis);
            }

            if (m_type == SeparationFunctionType.FaceA)
            {
                Vector2 normal = Vector2.Transform(m_axis, xfA.q); // Math.Mul(xfA.q, m_axis);
                Vector2 pointA = Math.Mul(xfA, m_localPoint);

                Vector2 localPointB = m_proxyB._vertices[indexB];
                Vector2 pointB = Math.Mul(xfB, localPointB);

                return Vector2.Dot(pointB - pointA, normal);
            }

            if (m_type == SeparationFunctionType.FaceB)
            {
                Vector2 normal = Vector2.Transform(m_axis, xfB.q); // Math.Mul(xfB.q, m_axis);
                Vector2 pointB = Math.Mul(xfB, m_localPoint);

                Vector2 localPointA = m_proxyA._vertices[indexA];
                Vector2 pointA = Math.Mul(xfA, localPointA);

                return Vector2.Dot(pointA - pointB, normal);
            }

            return 0.0f;

            //Debug.Assert(false);
        }

        /// <summary>
        ///     Finds the min separation using the specified index a
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="t">The </param>
        /// <returns>The float</returns>
        internal float FindMinSeparation(out int indexA, out int indexB, float t)
        {
            m_sweepA.GetTransform(out Transform xfA, t);
            m_sweepB.GetTransform(out Transform xfB, t);

            switch (m_type)
            {
                case SeparationFunctionType.Points:
                {
                    Vector2 axisA = Math.MulT(xfA.q, m_axis);
                    Vector2 axisB = Math.MulT(xfB.q, -m_axis);

                    indexA = m_proxyA.GetSupport(axisA);
                    indexB = m_proxyB.GetSupport(axisB);

                    Vector2 localPointA = m_proxyA.GetVertex(indexA);
                    Vector2 localPointB = m_proxyB.GetVertex(indexB);

                    Vector2 pointA = Math.Mul(xfA, localPointA);
                    Vector2 pointB = Math.Mul(xfB, localPointB);

                    return Vector2.Dot(pointB - pointA, m_axis);
                }
                case SeparationFunctionType.FaceA:
                {
                    Vector2 normal = Vector2.Transform(m_axis, xfA.q); // Math.Mul(xfA.q, m_axis);
                    Vector2 pointA = Math.Mul(xfA, m_localPoint);

                    Vector2 axisB = Math.MulT(xfB.q, -normal);

                    indexA = -1;
                    indexB = m_proxyB.GetSupport(axisB);

                    Vector2 localPointB = m_proxyB.GetVertex(indexB);
                    Vector2 pointB = Math.Mul(xfB, localPointB);

                    return Vector2.Dot(pointB - pointA, normal);
                }
                case SeparationFunctionType.FaceB:
                {
                    Vector2 normal = Vector2.Transform(m_axis, xfB.q); // Math.Mul(xfB.q, m_axis);
                    Vector2 pointB = Math.Mul(xfB, m_localPoint);

                    Vector2 axisA = Math.MulT(xfA.q, -normal);

                    indexB = -1;
                    indexA = m_proxyA.GetSupport(axisA);

                    Vector2 localPointA = m_proxyA.GetVertex(indexA);
                    Vector2 pointA = Math.Mul(xfA, localPointA);

                    return Vector2.Dot(pointA - pointB, normal);
                }
            }

            //Debug.Assert(false);
            indexA = -1;
            indexB = -1;
            return 0.0f;
        }
    }
}