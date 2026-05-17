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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
/// <summary>
///     Describes the motion of a body/shape for time-of-impact (TOI) computation.
///     This structure stores information needed to interpolate the transform of a body
///     between time steps for continuous collision detection. Shapes are defined with
///     respect to the body origin, which may not coincide with the center of mass.
///     To support dynamics properly, we must interpolate the center of mass position.
///     The sweep uses alpha0 as a fractional time value in the range [0,1] to represent
///     temporal interpolation between frames.
///     
///     This structure is used in the physics engine for continuous collision detection
///     (CCD) to prevent tunneling of fast-moving objects. It represents the swept
///     motion of a body from its previous to current transform.
///     
///     Fields:
///     - LocalCenter: The local center of mass position
///     - C0, C: Center positions at previous and current time steps
///     - A0, A: Angles at previous and current time steps (in radians)
///     - Alpha0: Fraction of the current time step in [0,1] representing the 
///              start time for interpolation
/// </summary>
    public struct Sweep
    {
/// <summary>
///     Gets or sets the current world angle of the sweep in radians.
///     This represents the orientation of the body at the current time step.
/// </summary>
        public float A;

        /// <summary>
        ///     The
        /// </summary>
        public float A0;

        /// <summary>
        ///     Fraction of the current time step in the range [0,1]
        ///     c0 and a0 are the positions at alpha0.
        /// </summary>
        public float Alpha0;

        /// <summary>
        ///     Center world positions
        /// </summary>
        public Vector2F C;

        /// <summary>
        ///     The angle at the previous time step (alpha0), in radians.
        /// </summary>
        public float A0;

        /// <summary>
        ///     Fraction of the current time step in the range [0,1].
        ///     C0 and A0 represent the position and orientation at Alpha0.
        /// </summary>
        public float Alpha0;

        /// <summary>
        ///     The center of mass position at the previous time step (alpha0), in world coordinates.
        /// </summary>
        public Vector2F C0;

        /// <summary>
        ///     Local center of mass position
        /// </summary>
        public Vector2F LocalCenter;

        /// <summary>
        ///     Get the interpolated transform at a specific time.
        /// </summary>
        /// <param name="xfb">The transform.</param>
        /// <param name="beta">beta is a factor in [0,1], where 0 indicates alpha0.</param>
        public void GetTransform(out ControllerTransform xfb, float beta)
        {
            xfb.Position = new Vector2F((1.0f - beta) * C0.X + beta * C.X, (1.0f - beta) * C0.Y + beta * C.Y);
            float angle = (1.0f - beta) * A0 + beta * A;
            xfb.Rotation = Complex.FromAngle(angle);

            // Shift to origin
            xfb.Position -= Complex.Multiply(ref LocalCenter, ref xfb.Rotation);

            xfb.Scale = new Vector2F(1, 1);
        }

        /// <summary>
        ///     Advance the sweep forward, yielding a new initial state.
        /// </summary>
        /// <param name="alpha">new initial time..</param>
        public void Advance(float alpha)
        {
            float beta = (alpha - Alpha0) / (1.0f - Alpha0);
            C0 += beta * (C - C0);
            A0 += beta * (A - A0);
            Alpha0 = alpha;
        }

        /// <summary>
        ///     Computes the interpolated transform at a specific interpolation factor.
        /// </summary>
        /// <param name="xfb">When this method returns, contains the interpolated transform at the given beta value.</param>
        /// <param name="beta">A factor in [0,1], where 0 indicates alpha0 (previous state) and 1 indicates the current state.</param>
        /// <remarks>
        ///     The transform is interpolated linearly for position and angle.
        ///     The local center of mass is shifted to the body origin as required by the physics engine.
        /// </remarks>
        public void GetTransform(out ControllerTransform xfb, float beta)

        /// <summary>
        ///     Advances the sweep forward to a new time step, yielding a new initial state.
        /// </summary>
        /// <param name="alpha">The new initial time fraction in [0,1]. The sweep state is interpolated to this point and becomes the new baseline.</param>
        /// <remarks>
        ///     This method is used during continuous collision detection to rebase the sweep
        ///     at the time of impact, allowing further TOI computation from that point.
        /// </remarks>
        public void Advance(float alpha)

        /// <summary>
        ///     Normalizes both angles to the range [0, 2π) by subtracting full rotations.
        /// </summary>
        /// <remarks>
        ///     This prevents angle values from growing unbounded over long simulations,
        ///     which could cause floating-point precision issues.
        /// </remarks>
        public void Normalize()
        {
            float d = Constant.Tau * (float) Math.Floor(A0 / Constant.Tau);
            A0 -= d;
            A -= d;
        }
    }
}