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

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

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
        internal SimplexVertex _v1, _v2, _v3;

        /// <summary>
        ///     The count
        /// </summary>
        internal int _count;

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
            Box2DXDebug.Assert(0 <= cache->Count && cache->Count <= 3);

            // Copy data from cache.
            _count = cache->Count;
            SimplexVertex** vertices = stackalloc SimplexVertex*[3];
            fixed (SimplexVertex* v1Ptr = &_v1, v2Ptr = &_v2, v3Ptr = &_v3)
            {
                vertices[0] = v1Ptr;
                vertices[1] = v2Ptr;
                vertices[2] = v3Ptr;
                for (int i = 0; i < _count; ++i)
                {
                    SimplexVertex* v = vertices[i];
                    v->IndexA = cache->IndexA[i];
                    v->IndexB = cache->IndexB[i];
                    Vec2 wALocal = shapeA.GetVertex(v->IndexA);
                    Vec2 wBLocal = shapeB.GetVertex(v->IndexB);
                    v->Wa = Math.Mul(transformA, wALocal);
                    v->Wb = Math.Mul(transformB, wBLocal);
                    v->W = v->Wb - v->Wa;
                    v->A = 0.0f;
                }

                // Compute the new simplex metric, if it is substantially different than
                // old metric then flush the simplex.
                if (_count > 1)
                {
                    float metric1 = cache->Metric;
                    float metric2 = GetMetric();
                    if (metric2 < 0.5f * metric1 || 2.0f * metric1 < metric2 || metric2 < Settings.FltEpsilon)
                    {
                        // Reset the simplex.
                        _count = 0;
                    }
                }

                // If the cache is empty or invalid ...
                if (_count == 0)
                {
                    SimplexVertex* v = vertices[0];
                    v->IndexA = 0;
                    v->IndexB = 0;
                    Vec2 wALocal = shapeA.GetVertex(0);
                    Vec2 wBLocal = shapeB.GetVertex(0);
                    v->Wa = Math.Mul(transformA, wALocal);
                    v->Wb = Math.Mul(transformB, wBLocal);
                    v->W = v->Wb - v->Wa;
                    _count = 1;
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
            cache->Count = (ushort) _count;
            SimplexVertex** vertices = stackalloc SimplexVertex*[3];
            fixed (SimplexVertex* v1Ptr = &_v1, v2Ptr = &_v2, v3Ptr = &_v3)
            {
                vertices[0] = v1Ptr;
                vertices[1] = v2Ptr;
                vertices[2] = v3Ptr;
                for (int i = 0; i < _count; ++i)
                {
                    cache->IndexA[i] = (byte) (vertices[i]->IndexA);
                    cache->IndexB[i] = (byte) (vertices[i]->IndexB);
                }
            }
        }

        /// <summary>
        ///     Gets the closest point
        /// </summary>
        /// <returns>The vec</returns>
        internal Vec2 GetClosestPoint()
        {
            switch (_count)
            {
                case 0:
#if DEBUG
                    Box2DXDebug.Assert(false);
#endif
                    return Vec2.Zero;
                case 1:
                    return _v1.W;
                case 2:
                    return _v1.A * _v1.W + _v2.A * _v2.W;
                case 3:
                    return Vec2.Zero;
                default:
#if DEBUG
                    Box2DXDebug.Assert(false);
#endif
                    return Vec2.Zero;
            }
        }

        /// <summary>
        ///     Gets the witness points using the specified p a
        /// </summary>
        /// <param name="pA">The </param>
        /// <param name="pB">The </param>
        internal unsafe void GetWitnessPoints(Vec2* pA, Vec2* pB)
        {
            switch (_count)
            {
                case 0:
                    Box2DXDebug.Assert(false);
                    break;

                case 1:
                    *pA = _v1.Wa;
                    *pB = _v1.Wb;
                    break;

                case 2:
                    *pA = _v1.A * _v1.Wa + _v2.A * _v2.Wa;
                    *pB = _v1.A * _v1.Wb + _v2.A * _v2.Wb;
                    break;

                case 3:
                    *pA = _v1.A * _v1.Wa + _v2.A * _v2.Wa + _v3.A * _v3.Wa;
                    *pB = *pA;
                    break;

                default:
                    Box2DXDebug.Assert(false);
                    break;
            }
        }

        /// <summary>
        ///     Gets the metric
        /// </summary>
        /// <returns>The float</returns>
        internal float GetMetric()
        {
            switch (_count)
            {
                case 0:
#if DEBUG
                    Box2DXDebug.Assert(false);
#endif
                    return 0.0f;

                case 1:
                    return 0.0f;

                case 2:
                    return Vec2.Distance(_v1.W, _v2.W);

                case 3:
                    return Vec2.Cross(_v2.W - _v1.W, _v3.W - _v1.W);

                default:
#if DEBUG
                    Box2DXDebug.Assert(false);
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
            Vec2 w1 = _v1.W;
            Vec2 w2 = _v2.W;
            Vec2 e12 = w2 - w1;

            // w1 region
            float d12_2 = -Vec2.Dot(w1, e12);
            if (d12_2 <= 0.0f)
            {
                // a2 <= 0, so we clamp it to 0
                _v1.A = 1.0f;
                _count = 1;
                return;
            }

            // w2 region
            float d12_1 = Vec2.Dot(w2, e12);
            if (d12_1 <= 0.0f)
            {
                // a1 <= 0, so we clamp it to 0
                _v2.A = 1.0f;
                _count = 1;
                _v1 = _v2;
                return;
            }

            // Must be in e12 region.
            float inv_d12 = 1.0f / (d12_1 + d12_2);
            _v1.A = d12_1 * inv_d12;
            _v2.A = d12_2 * inv_d12;
            _count = 2;
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
            Vec2 w1 = _v1.W;
            Vec2 w2 = _v2.W;
            Vec2 w3 = _v3.W;

            // Edge12
            // [1      1     ][a1] = [1]
            // [w1.e12 w2.e12][a2] = [0]
            // a3 = 0
            Vec2 e12 = w2 - w1;
            float w1e12 = Vec2.Dot(w1, e12);
            float w2e12 = Vec2.Dot(w2, e12);
            float d12_1 = w2e12;
            float d12_2 = -w1e12;

            // Edge13
            // [1      1     ][a1] = [1]
            // [w1.e13 w3.e13][a3] = [0]
            // a2 = 0
            Vec2 e13 = w3 - w1;
            float w1e13 = Vec2.Dot(w1, e13);
            float w3e13 = Vec2.Dot(w3, e13);
            float d13_1 = w3e13;
            float d13_2 = -w1e13;

            // Edge23
            // [1      1     ][a2] = [1]
            // [w2.e23 w3.e23][a3] = [0]
            // a1 = 0
            Vec2 e23 = w3 - w2;
            float w2e23 = Vec2.Dot(w2, e23);
            float w3e23 = Vec2.Dot(w3, e23);
            float d23_1 = w3e23;
            float d23_2 = -w2e23;

            // Triangle123
            float n123 = Vec2.Cross(e12, e13);

            float d123_1 = n123 * Vec2.Cross(w2, w3);
            float d123_2 = n123 * Vec2.Cross(w3, w1);
            float d123_3 = n123 * Vec2.Cross(w1, w2);

            // w1 region
            if (d12_2 <= 0.0f && d13_2 <= 0.0f)
            {
                _v1.A = 1.0f;
                _count = 1;
                return;
            }

            // e12
            if (d12_1 > 0.0f && d12_2 > 0.0f && d123_3 <= 0.0f)
            {
                float inv_d12 = 1.0f / (d12_1 + d12_2);
                _v1.A = d12_1 * inv_d12;
                _v2.A = d12_1 * inv_d12;
                _count = 2;
                return;
            }

            // e13
            if (d13_1 > 0.0f && d13_2 > 0.0f && d123_2 <= 0.0f)
            {
                float inv_d13 = 1.0f / (d13_1 + d13_2);
                _v1.A = d13_1 * inv_d13;
                _v3.A = d13_2 * inv_d13;
                _count = 2;
                _v2 = _v3;
                return;
            }

            // w2 region
            if (d12_1 <= 0.0f && d23_2 <= 0.0f)
            {
                _v2.A = 1.0f;
                _count = 1;
                _v1 = _v2;
                return;
            }

            // w3 region
            if (d13_1 <= 0.0f && d23_1 <= 0.0f)
            {
                _v3.A = 1.0f;
                _count = 1;
                _v1 = _v3;
                return;
            }

            // e23
            if (d23_1 > 0.0f && d23_2 > 0.0f && d123_1 <= 0.0f)
            {
                float inv_d23 = 1.0f / (d23_1 + d23_2);
                _v2.A = d23_1 * inv_d23;
                _v3.A = d23_2 * inv_d23;
                _count = 2;
                _v1 = _v3;
                return;
            }

            // Must be in triangle123
            float inv_d123 = 1.0f / (d123_1 + d123_2 + d123_3);
            _v1.A = d123_1 * inv_d123;
            _v2.A = d123_2 * inv_d123;
            _v3.A = d123_3 * inv_d123;
            _count = 3;
        }
    }
}