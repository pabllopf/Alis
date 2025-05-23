// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleExplosion.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PhysicsLogic
{
    /// <summary>
    ///     Creates a simple explosion that ignores other bodies hiding behind static bodies.
    /// </summary>
    public sealed class SimpleExplosion : PhysicsLogic
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SimpleExplosion" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        public SimpleExplosion(WorldPhysic worldPhysic) : base(worldPhysic) => Power = 1; //linear

        /// <summary>
        ///     This is the power used in the power function. A value of 1 means the force
        ///     applied to bodies in the explosion is linear. A value of 2 means it is exponential.
        /// </summary>
        public float Power { get; set; }

        /// <summary>
        ///     Activate the explosion at the specified position.
        /// </summary>
        /// <param name="pos">The position (center) of the explosion.</param>
        /// <param name="radius">The radius of the explosion.</param>
        /// <param name="force">The force applied</param>
        /// <param name="maxForce">A maximum amount of force. When force gets over this value, it will be equal to maxForce</param>
        /// <returns>A list of bodies and the amount of force that was applied to them.</returns>
        public Dictionary<Body, Vector2F> Activate(Vector2F pos, float radius, float force, float maxForce = float.MaxValue)
        {
            HashSet<Body> affectedBodies = new HashSet<Body>();

            Aabb aabb;
            aabb.LowerBound = pos - new Vector2F(radius);
            aabb.UpperBound = pos + new Vector2F(radius);

            // Query the world for bodies within the radius.
            WorldPhysic.QueryAabb(fixture =>
            {
                if (Vector2F.Distance(fixture.GetBody.Position, pos) <= radius)
                {
                    if (!affectedBodies.Contains(fixture.GetBody))
                    {
                        affectedBodies.Add(fixture.GetBody);
                    }
                }

                return true;
            }, ref aabb);

            return ApplyImpulse(pos, radius, force, maxForce, affectedBodies);
        }

        /// <summary>
        ///     Applies the impulse using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="radius">The radius</param>
        /// <param name="force">The force</param>
        /// <param name="maxForce">The max force</param>
        /// <param name="overlappingBodies">The overlapping bodies</param>
        /// <returns>The forces</returns>
        private Dictionary<Body, Vector2F> ApplyImpulse(Vector2F pos, float radius, float force, float maxForce, HashSet<Body> overlappingBodies)
        {
            Dictionary<Body, Vector2F> forces = new Dictionary<Body, Vector2F>(overlappingBodies.Count);

            foreach (Body overlappingBody in overlappingBodies)
            {
                if (IsActiveOn(overlappingBody))
                {
                    float distance = Vector2F.Distance(pos, overlappingBody.Position);
                    float forcePercent = GetPercent(distance, radius);

                    Vector2F forceVector = pos - overlappingBody.Position;
                    forceVector *= 1f / (float) Math.Sqrt(forceVector.X * forceVector.X + forceVector.Y * forceVector.Y);
                    forceVector *= Math.Min(force * forcePercent, maxForce);
                    forceVector *= -1;

                    overlappingBody.ApplyLinearImpulse(forceVector);
                    forces.Add(overlappingBody, forceVector);
                }
            }

            return forces;
        }

        /// <summary>
        ///     Gets the percent using the specified distance
        /// </summary>
        /// <param name="distance">The distance</param>
        /// <param name="radius">The radius</param>
        /// <returns>The float</returns>
        private float GetPercent(float distance, float radius)
        {
            //(1-(distance/radius))^power-1
            float percent = (float) Math.Pow(1 - (distance - radius) / radius, Power) - 1;

            if (float.IsNaN(percent))
            {
                return 0f;
            }

            return MathUtils.Clamp(percent, 0f, 1f);
        }
    }
}