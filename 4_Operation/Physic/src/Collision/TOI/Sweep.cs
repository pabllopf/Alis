// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sweep.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.TOI
{
    /// <summary>
    ///     This describes the motion of a body/shape for TOI computation. Shapes are defined with respect to the body
    ///     origin, which may no coincide with the center of mass. However, to support dynamics we must interpolate the center
    ///     of
    ///     mass position.
    /// </summary>
    public class Sweep
    {
        /// <summary>World angles</summary>
        public float A;

        /// <summary>
        ///     The
        /// </summary>
        public float A0;

        /// <summary>Fraction of the current time step in the range [0,1] c0 and a0 are the positions at alpha0.</summary>
        public float Alpha0;

        /// <summary>Center world positions</summary>
        public Vector2F C;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F C0;

        /// <summary>Local center of mass position</summary>
        public Vector2F LocalCenter;

        /// <summary>Get the interpolated transform at a specific time.</summary>
        /// <param name="xfb">The transform.</param>
        /// <param name="beta">beta is a factor in [0,1], where 0 indicates alpha0.</param>
        public void GetTransform(out Transform xfb, float beta)
        {
            xfb = new Transform();
            xfb.Position.X = (1.0f - beta) * C0.X + beta * C.X;
            xfb.Position.Y = (1.0f - beta) * C0.Y + beta * C.Y;
            float angle = (1.0f - beta) * A0 + beta * A;
            xfb.Rotation.Set(angle);

            // Shift to origin
            xfb.Position -= MathUtils.Mul(xfb.Rotation, LocalCenter);
        }

        /// <summary>Advance the sweep forward, yielding a new initial state.</summary>
        /// <param name="alpha">new initial time</param>
        public void Advance(float alpha)
        {
            Debug.Assert(Alpha0 < 1.0f);
            float beta = (alpha - Alpha0) / (1.0f - Alpha0);
            C0 += beta * (C - C0);
            A0 += beta * (A - A0);
            Alpha0 = alpha;
        }

        /// <summary>Normalize the angles.</summary>
        public void Normalize()
        {
            float d = Constant.TwoPi * (float) Math.Floor(A0 / Constant.TwoPi);
            A0 -= d;
            A -= d;
        }
    }
}