// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   JointHelper.cs
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

using Alis.Core.Systems.Physics2D.Dynamics;

namespace Alis.Core.Systems.Physics2D.Utilities
{
    /// <summary>
    ///     The joint helper class
    /// </summary>
    public static class JointHelper
    {
        /// <summary>
        ///     Linears the stiffness using the specified frequency hertz
        /// </summary>
        /// <param name="frequencyHertz">The frequency hertz</param>
        /// <param name="dampingRatio">The damping ratio</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        public static void LinearStiffness(float frequencyHertz, float dampingRatio, Body bodyA, Body bodyB,
            out float stiffness, out float damping)
        {
            float massA = bodyA.Mass;

            float massB = 0;

            if (bodyB != null)
            {
                massB = bodyB.Mass;
            }

            float mass;

            if (massA > 0.0f && massB > 0.0f)
            {
                mass = massA * massB / (massA + massB);
            }
            else if (massA > 0.0f)
            {
                mass = massA;
            }
            else
            {
                mass = massB;
            }

            float omega = MathConstants.TwoPi * frequencyHertz;
            stiffness = mass * omega * omega;
            damping = 2.0f * mass * dampingRatio * omega;
        }

        /// <summary>
        ///     Angulars the stiffness using the specified frequency hertz
        /// </summary>
        /// <param name="frequencyHertz">The frequency hertz</param>
        /// <param name="dampingRatio">The damping ratio</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        public static void AngularStiffness(float frequencyHertz, float dampingRatio, Body bodyA, Body bodyB,
            out float stiffness, out float damping)
        {
            float inertiaA = bodyA.Inertia;
            float inertiaB = bodyB.Inertia;
            float I;

            if (inertiaA > 0.0f && inertiaB > 0.0f)
            {
                I = inertiaA * inertiaB / (inertiaA + inertiaB);
            }
            else if (inertiaA > 0.0f)
            {
                I = inertiaA;
            }
            else
            {
                I = inertiaB;
            }

            float omega = MathConstants.TwoPi * frequencyHertz;
            stiffness = I * omega * omega;
            damping = 2.0f * I * dampingRatio * omega;
        }
    }
}