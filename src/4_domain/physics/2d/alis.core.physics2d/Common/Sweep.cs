// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Sweep.cs
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

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The sweep
    /// </summary>
    public struct Sweep
    {
        /// <summary>
        ///     The local center
        /// </summary>
        public Vector2 localCenter; //local center of mass position

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 c0, c; //local center of mass position

        /// <summary>
        ///     The
        /// </summary>
        public float a0, a; //world angles

        /// <summary>
        ///     The alpha
        /// </summary>
        public float alpha0;

        /// <summary>
        ///     Get the interpolated transform at a specific time.
        /// </summary>
        /// <param name="alpha">Alpha is a factor in [0,1], where 0 indicates t0.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetTransform(out Transform xf, in float beta)
        {
            xf.p = c0 + beta * (c - c0);
            float angle = a0 + beta * (a - a0);
            xf.q = Matrex.CreateRotation(angle);
            xf.p -= Vector2.Transform(localCenter, xf.q); // Math.Mul(xf.q, localCenter);
        }

        /// <summary>
        ///     Advance the sweep forward, yielding a new initial state.
        /// </summary>
        /// <param name="t">The new initial time.</param>
        public void Advance(float alpha)
        {
            //Debug.Assert(alpha0 < 1.0f);
            float beta = (alpha - alpha0) / (1.0f - alpha0);
            c0 += beta * (c - c0);
            a0 += beta * (a - a0);
            alpha0 = alpha;
        }

        /// <summary>
        ///     Normalizes this instance
        /// </summary>
        public void Normalize()
        {
            float d = Settings.Tau * MathF.Floor(a0 / Settings.Tau);
            a0 -= d;
            a -= d;
        }
    }
}