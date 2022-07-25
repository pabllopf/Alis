// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Simplex.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The simplex
    /// </summary>
    internal struct Simplex
    {
        /// <summary>
        ///     The
        /// </summary>
        internal SimplexVertex V1;

        /// <summary>
        ///     The
        /// </summary>
        internal SimplexVertex V2;

        /// <summary>
        ///     The
        /// </summary>
        internal SimplexVertex V3;

        /// <summary>
        ///     The count
        /// </summary>
        internal int Count;

        /// <summary>
        ///     Reads the cache using the specified cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="shapeA">The shape</param>
        /// <param name="transformA">The transform</param>
        /// <param name="shapeB">The shape</param>
        /// <param name="transformB">The transform</param>
        internal unsafe void ReadCache(SimplexCache* cache, Shape shapeA, XForm transformA, Shape shapeB,
            XForm transformB)
        {
            Box2DxDebug.Assert(0 <= cache->Count && cache->Count <= 3);

            // Copy data from cache.
            Count = cache->Count;
            SimplexVertex** vertices = stackalloc SimplexVertex*[3];
            fixed (SimplexVertex* v1Ptr = &V1, v2Ptr = &V2, v3Ptr = &V3)
            {
                vertices[0] = v1Ptr;
                vertices[1] = v2Ptr;
                vertices[2] = v3Ptr;
                for (int i = 0; i < Count; ++i)
                {
                    SimplexVertex* v = vertices[i];
                    v->IndexA = cache->IndexA[i];
                    v->IndexB = cache->IndexB[i];
                    Vector2 wALocal = shapeA.GetVertex(v->IndexA);
                    Vector2 wBLocal = shapeB.GetVertex(v->IndexB);
                    v->Wa = Math.Mul(transformA, wALocal);
                    v->Wb = Math.Mul(transformB, wBLocal);
                    v->W = v->Wb - v->Wa;
                    v->A = 0.0f;
                }

                // Compute the new simplex metric, if it is substantially different than
                // old metric then flush the simplex.
                if (Count > 1)
                {
                    float metric1 = cache->Metric;
                    float metric2 = GetMetric();
                    if (metric2 < 0.5f * metric1 || 2.0f * metric1 < metric2 || metric2 < Settings.FltEpsilon)
                    {
                        // Reset the simplex.
                        Count = 0;
                    }
                }

                // If the cache is empty or invalid ...
                if (Count == 0)
                {
                    SimplexVertex* v = vertices[0];
                    v->IndexA = 0;
                    v->IndexB = 0;
                    Vector2 wALocal = shapeA.GetVertex(0);
                    Vector2 wBLocal = shapeB.GetVertex(0);
                    v->Wa = Math.Mul(transformA, wALocal);
                    v->Wb = Math.Mul(transformB, wBLocal);
                    v->W = v->Wb - v->Wa;
                    Count = 1;
                }
            }
        }

        /// <summary>
        ///     Writes the cache using the specified cache
        /// </summary>
        /// <param name="cache">The cache</param>
        internal unsafe void WriteCache(SimplexCache* cache)
        {
            cache->Metric = GetMetric();
            cache->Count = (ushort) Count;
            SimplexVertex** vertices = stackalloc SimplexVertex*[3];
            fixed (SimplexVertex* v1Ptr = &V1, v2Ptr = &V2, v3Ptr = &V3)
            {
                vertices[0] = v1Ptr;
                vertices[1] = v2Ptr;
                vertices[2] = v3Ptr;
                for (int i = 0; i < Count; ++i)
                {
                    cache->IndexA[i] = (byte) vertices[i]->IndexA;
                    cache->IndexB[i] = (byte) vertices[i]->IndexB;
                }
            }
        }

        /// <summary>
        ///     Gets the closest point
        /// </summary>
        /// <returns>The vec</returns>
        internal Vector2 GetClosestPoint()
        {
            switch (Count)
            {
                case 0:
#if DEBUG
                    Box2DxDebug.Assert(false);
#endif
                    return Vector2.Zero;
                case 1:
                    return V1.W;
                case 2:
                    return V1.A * V1.W + V2.A * V2.W;
                case 3:
                    return Vector2.Zero;
                default:
#if DEBUG
                    Box2DxDebug.Assert(false);
#endif
                    return Vector2.Zero;
            }
        }

        /// <summary>
        ///     Gets the witness points using the specified p a
        /// </summary>
        /// <param name="pA">The </param>
        /// <param name="pB">The </param>
        internal unsafe void GetWitnessPoints(Vector2* pA, Vector2* pB)
        {
            switch (Count)
            {
                case 0:
                    Box2DxDebug.Assert(false);
                    break;

                case 1:
                    *pA = V1.Wa;
                    *pB = V1.Wb;
                    break;

                case 2:
                    *pA = V1.A * V1.Wa + V2.A * V2.Wa;
                    *pB = V1.A * V1.Wb + V2.A * V2.Wb;
                    break;

                case 3:
                    *pA = V1.A * V1.Wa + V2.A * V2.Wa + V3.A * V3.Wa;
                    *pB = *pA;
                    break;

                default:
                    Box2DxDebug.Assert(false);
                    break;
            }
        }

        /// <summary>
        ///     Gets the metric
        /// </summary>
        /// <returns>The float</returns>
        internal float GetMetric()
        {
            switch (Count)
            {
                case 0:
#if DEBUG
                    Box2DxDebug.Assert(false);
#endif
                    return 0.0f;

                case 1:
                    return 0.0f;

                case 2:
                    return Vector2.Distance(V1.W, V2.W);

                case 3:
                    return Vector2.Cross(V2.W - V1.W, V3.W - V1.W);

                default:
#if DEBUG
                    Box2DxDebug.Assert(false);
#endif
                    return 0.0f;
            }
        }

        // Solve a line segment using barycentric coordinates.
        //
        // p = a1 * w1 + a2 * w2
        // a1 + a2 = 1
        //
        // The vector from the origin to the closest point on the line is
        // perpendicular to the line.
        // e12 = w2 - w1
        // dot(p, e) = 0
        // a1 * dot(w1, e) + a2 * dot(w2, e) = 0
        //
        // 2-by-2 linear system
        // [1      1     ][a1] = [1]
        // [w1.e12 w2.e12][a2] = [0]
        //
        // Define
        // d12_1 =  dot(w2, e12)
        // d12_2 = -dot(w1, e12)
        // d12 = d12_1 + d12_2
        //
        // Solution
        // a1 = d12_1 / d12
        // a2 = d12_2 / d12
        /// <summary>
        ///     Solves the 2
        /// </summary>
        internal void Solve2()
        {
            Vector2 w1 = V1.W;
            Vector2 w2 = V2.W;
            Vector2 e12 = w2 - w1;

            // w1 region
            float d122 = -Vector2.Dot(w1, e12);
            if (d122 <= 0.0f)
            {
                // a2 <= 0, so we clamp it to 0
                V1.A = 1.0f;
                Count = 1;
                return;
            }

            // w2 region
            float d121 = Vector2.Dot(w2, e12);
            if (d121 <= 0.0f)
            {
                // a1 <= 0, so we clamp it to 0
                V2.A = 1.0f;
                Count = 1;
                V1 = V2;
                return;
            }

            // Must be in e12 region.
            float invD12 = 1.0f / (d121 + d122);
            V1.A = d121 * invD12;
            V2.A = d122 * invD12;
            Count = 2;
        }

        // Possible regions:
        // - points[2]
        // - edge points[0]-points[2]
        // - edge points[1]-points[2]
        // - inside the triangle
        /// <summary>
        ///     Solves the 3
        /// </summary>
        internal void Solve3()
        {
            Vector2 w1 = V1.W;
            Vector2 w2 = V2.W;
            Vector2 w3 = V3.W;

            // Edge12
            // [1      1     ][a1] = [1]
            // [w1.e12 w2.e12][a2] = [0]
            // a3 = 0
            Vector2 e12 = w2 - w1;
            float w1E12 = Vector2.Dot(w1, e12);
            float w2E12 = Vector2.Dot(w2, e12);
            float d121 = w2E12;
            float d122 = -w1E12;

            // Edge13
            // [1      1     ][a1] = [1]
            // [w1.e13 w3.e13][a3] = [0]
            // a2 = 0
            Vector2 e13 = w3 - w1;
            float w1E13 = Vector2.Dot(w1, e13);
            float w3E13 = Vector2.Dot(w3, e13);
            float d131 = w3E13;
            float d132 = -w1E13;

            // Edge23
            // [1      1     ][a2] = [1]
            // [w2.e23 w3.e23][a3] = [0]
            // a1 = 0
            Vector2 e23 = w3 - w2;
            float w2E23 = Vector2.Dot(w2, e23);
            float w3E23 = Vector2.Dot(w3, e23);
            float d231 = w3E23;
            float d232 = -w2E23;

            // Triangle123
            float n123 = Vector2.Cross(e12, e13);

            float d1231 = n123 * Vector2.Cross(w2, w3);
            float d1232 = n123 * Vector2.Cross(w3, w1);
            float d1233 = n123 * Vector2.Cross(w1, w2);

            // w1 region
            if (d122 <= 0.0f && d132 <= 0.0f)
            {
                V1.A = 1.0f;
                Count = 1;
                return;
            }

            // e12
            if (d121 > 0.0f && d122 > 0.0f && d1233 <= 0.0f)
            {
                float invD12 = 1.0f / (d121 + d122);
                V1.A = d121 * invD12;
                V2.A = d121 * invD12;
                Count = 2;
                return;
            }

            // e13
            if (d131 > 0.0f && d132 > 0.0f && d1232 <= 0.0f)
            {
                float invD13 = 1.0f / (d131 + d132);
                V1.A = d131 * invD13;
                V3.A = d132 * invD13;
                Count = 2;
                V2 = V3;
                return;
            }

            // w2 region
            if (d121 <= 0.0f && d232 <= 0.0f)
            {
                V2.A = 1.0f;
                Count = 1;
                V1 = V2;
                return;
            }

            // w3 region
            if (d131 <= 0.0f && d231 <= 0.0f)
            {
                V3.A = 1.0f;
                Count = 1;
                V1 = V3;
                return;
            }

            // e23
            if (d231 > 0.0f && d232 > 0.0f && d1231 <= 0.0f)
            {
                float invD23 = 1.0f / (d231 + d232);
                V2.A = d231 * invD23;
                V3.A = d232 * invD23;
                Count = 2;
                V1 = V3;
                return;
            }

            // Must be in triangle123
            float invD123 = 1.0f / (d1231 + d1232 + d1233);
            V1.A = d1231 * invD123;
            V2.A = d1232 * invD123;
            V3.A = d1233 * invD123;
            Count = 3;
        }
    }
}