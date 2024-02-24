// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Simplex.cs
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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Shared.Optimization;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>
    ///     The simplex
    /// </summary>
    internal struct Simplex
    {
        /// <summary>
        ///     Gets or sets the value of the count
        /// </summary>
        internal int Count { get; set; }


        /// <summary>
        ///     The
        /// </summary>
        internal FixedArray3<SimplexVertex> V;


        /// <summary>
        ///     Reads the cache using the specified cache
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="proxyA">The proxy</param>
        /// <param name="transformA">The transform</param>
        /// <param name="proxyB">The proxy</param>
        /// <param name="transformB">The transform</param>
        internal void ReadCache(ref SimplexCache cache, ref DistanceProxy proxyA, ref Transform transformA,
            ref DistanceProxy proxyB, ref Transform transformB)
        {
            Debug.Assert(cache.Count <= 3);


            Count = cache.Count;
            for (int i = 0; i < Count; ++i)
            {
                SimplexVertex v = V[i];
                v.IndexA = cache.IndexA[i];
                v.IndexB = cache.IndexB[i];
                Vector2 wALocal = proxyA.Vertices[v.IndexA];
                Vector2 wBLocal = proxyB.Vertices[v.IndexB];
                v.Wa = MathUtils.Mul(ref transformA, wALocal);
                v.Wb = MathUtils.Mul(ref transformB, wBLocal);
                v.W = v.Wb - v.Wa;
                v.A = 0.0f;
                V[i] = v;
            }


            if (Count > 1)
            {
                float metric1 = cache.Metric;
                float metric2 = GetMetric();
                if (metric2 < 0.5f * metric1 || 2.0f * metric1 < metric2 || metric2 < Constant.Epsilon)
                {
                    Count = 0;
                }
            }


            if (Count == 0)
            {
                SimplexVertex v = V[0];
                v.IndexA = 0;
                v.IndexB = 0;
                Vector2 wALocal = proxyA.Vertices[0];
                Vector2 wBLocal = proxyB.Vertices[0];
                v.Wa = MathUtils.Mul(ref transformA, wALocal);
                v.Wb = MathUtils.Mul(ref transformB, wBLocal);
                v.W = v.Wb - v.Wa;
                v.A = 1.0f;
                V[0] = v;
                Count = 1;
            }
        }


        /// <summary>
        ///     Writes the cache using the specified cache
        /// </summary>
        /// <param name="cache">The cache</param>
        internal void WriteCache(ref SimplexCache cache)
        {
            cache.Metric = GetMetric();
            cache.Count = (ushort) Count;
            for (int i = 0; i < Count; ++i)
            {
                cache.IndexA[i] = (byte) V[i].IndexA;
                cache.IndexB[i] = (byte) V[i].IndexB;
            }
        }


        /// <summary>
        ///     Gets the search direction
        /// </summary>
        /// <returns>The vector</returns>
        internal Vector2 GetSearchDirection()
        {
            switch (Count)
            {
                case 1:
                    return -V[0].W;

                case 2:
                {
                    Vector2 e12 = V[1].W - V[0].W;
                    float sgn = MathUtils.Cross(e12, -V[0].W);
                    if (sgn > 0.0f)
                    {
                        return MathUtils.Cross(1.0f, e12);
                    }


                    return MathUtils.Cross(e12, 1.0f);
                }

                default:
                    Debug.Assert(false);
                    return Vector2.Zero;
            }
        }


        /// <summary>
        ///     Gets the closest point
        /// </summary>
        /// <returns>The vector</returns>
        internal Vector2 GetClosestPoint()
        {
            switch (Count)
            {
                case 0:
                    Debug.Assert(false);
                    return Vector2.Zero;

                case 1:
                    return V[0].W;

                case 2:
                    return V[0].A * V[0].W + V[1].A * V[1].W;

                case 3:
                    return Vector2.Zero;

                default:
                    Debug.Assert(false);
                    return Vector2.Zero;
            }
        }

        /// <summary>
        ///     Gets the witness points using the specified p a
        /// </summary>
        /// <param name="pA">The </param>
        /// <param name="pB">The </param>
        /// <exception cref="Exception"></exception>
        internal void GetWitnessPoints(out Vector2 pA, out Vector2 pB)
        {
            switch (Count)
            {
                case 0:
                    pA = Vector2.Zero;
                    pB = Vector2.Zero;
                    Debug.Assert(false);
                    break;

                case 1:
                    pA = V[0].Wa;
                    pB = V[0].Wb;
                    break;

                case 2:
                    pA = V[0].A * V[0].Wa + V[1].A * V[1].Wa;
                    pB = V[0].A * V[0].Wb + V[1].A * V[1].Wb;
                    break;

                case 3:
                    pA = V[0].A * V[0].Wa + V[1].A * V[1].Wa + V[2].A * V[2].Wa;
                    pB = pA;
                    break;

                default:
                    throw new Exception();
            }
        }

        /// <summary>
        ///     Gets the metric
        /// </summary>
        /// <returns>The float</returns>
        private float GetMetric()
        {
            switch (Count)
            {
                case 0:
                    Debug.Assert(false);
                    return 0.0f;
                case 1:
                    return 0.0f;

                case 2:
                    return MathUtils.Distance(V[0].W, V[1].W);

                case 3:
                    return MathUtils.Cross(V[1].W - V[0].W, V[2].W - V[0].W);

                default:
                    Debug.Assert(false);
                    return 0.0f;
            }
        }


        /// <summary>
        ///     Solves the 2
        /// </summary>
        internal void Solve2()
        {
            Vector2 w1 = V[0].W;
            Vector2 w2 = V[1].W;
            Vector2 e12 = w2 - w1;


            float d122 = -Vector2.Dot(w1, e12);
            if (d122 <= 0.0f)
            {
                V.Value0.A = 1.0f;
                Count = 1;
                return;
            }


            float d121 = Vector2.Dot(w2, e12);
            if (d121 <= 0.0f)
            {
                V.Value1.A = 1.0f;
                Count = 1;
                V.Value0 = V.Value1;
                return;
            }


            float invD12 = 1.0f / (d121 + d122);
            V.Value0.A = d121 * invD12;
            V.Value1.A = d122 * invD12;
            Count = 2;
        }


        /// <summary>
        ///     Solves the 3
        /// </summary>
        internal void Solve3()
        {
            Vector2 w1 = V[0].W;
            Vector2 w2 = V[1].W;
            Vector2 w3 = V[2].W;


            Vector2 e12 = w2 - w1;
            float w1E12 = Vector2.Dot(w1, e12);
            float w2E12 = Vector2.Dot(w2, e12);
            float d121 = w2E12;
            float d122 = -w1E12;


            Vector2 e13 = w3 - w1;
            float w1E13 = Vector2.Dot(w1, e13);
            float w3E13 = Vector2.Dot(w3, e13);
            float d131 = w3E13;
            float d132 = -w1E13;


            Vector2 e23 = w3 - w2;
            float w2E23 = Vector2.Dot(w2, e23);
            float w3E23 = Vector2.Dot(w3, e23);
            float d231 = w3E23;
            float d232 = -w2E23;


            float n123 = MathUtils.Cross(e12, e13);

            float d1231 = n123 * MathUtils.Cross(w2, w3);
            float d1232 = n123 * MathUtils.Cross(w3, w1);
            float d1233 = n123 * MathUtils.Cross(w1, w2);


            if ((d122 <= 0.0f) && (d132 <= 0.0f))
            {
                V.Value0.A = 1.0f;
                Count = 1;
                return;
            }


            if ((d121 > 0.0f) && (d122 > 0.0f) && (d1233 <= 0.0f))
            {
                float invD12 = 1.0f / (d121 + d122);
                V.Value0.A = d121 * invD12;
                V.Value1.A = d122 * invD12;
                Count = 2;
                return;
            }


            if ((d131 > 0.0f) && (d132 > 0.0f) && (d1232 <= 0.0f))
            {
                float invD13 = 1.0f / (d131 + d132);
                V.Value0.A = d131 * invD13;
                V.Value2.A = d132 * invD13;
                Count = 2;
                V.Value1 = V.Value2;
                return;
            }


            if ((d121 <= 0.0f) && (d232 <= 0.0f))
            {
                V.Value1.A = 1.0f;
                Count = 1;
                V.Value0 = V.Value1;
                return;
            }


            if ((d131 <= 0.0f) && (d231 <= 0.0f))
            {
                V.Value2.A = 1.0f;
                Count = 1;
                V.Value0 = V.Value2;
                return;
            }


            if ((d231 > 0.0f) && (d232 > 0.0f) && (d1231 <= 0.0f))
            {
                float invD23 = 1.0f / (d231 + d232);
                V.Value1.A = d231 * invD23;
                V.Value2.A = d232 * invD23;
                Count = 2;
                V.Value0 = V.Value2;
                return;
            }


            float invD123 = 1.0f / (d1231 + d1232 + d1233);
            V.Value0.A = d1231 * invD123;
            V.Value1.A = d1232 * invD123;
            V.Value2.A = d1233 * invD123;
            Count = 3;
        }
    }
}