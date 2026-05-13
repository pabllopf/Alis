// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityLimitController.cs
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
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     Limits the linear and angular velocity of registered bodies.
    /// </summary>
    /// <remarks>
    ///     <para>This controller constrains body velocities to prevent excessive speeds that could
    ///     cause numerical instability or unrealistic behavior in the simulation.</para>
    ///     <para>It can be configured to limit only linear velocity, only angular velocity, or both.
    ///     Pass <c>0</c> or <c>float.MaxValue</c> to a constructor parameter to disable that limit.</para>
    ///     <para>The velocity is clamped by computing the displacement that would occur during the
    ///     time step (<c>dt * velocity</c>) and scaling the velocity if this displacement exceeds
    ///     the configured maximum.</para>
    ///     <example>
    ///     <code>
    ///     // Limit maximum speed to prevent tunneling
    ///     var speedLimit = new VelocityLimitController(20f, 10f); // 20 units/s linear, 10 rad/s angular
    ///     world.AddController(speedLimit);
    ///     
    ///     // Add bodies to limit
    ///     speedLimit.AddBody(playerBody);
    ///     speedLimit.AddBody(vehicleBody);
    ///     </code>
    ///     </example>
    /// </remarks>
    public class VelocityLimitController : Controller
    {
        /// <summary>
        ///     The collection of bodies whose velocities are constrained.
        /// </summary>
        private readonly List<Body> _bodies = new List<Body>();

        /// <summary>
        ///     Gets whether angular velocity limiting is enabled.
        /// </summary>
        /// <value><c>true</c> if angular velocity is limited; otherwise <c>false</c>.</value>
        public readonly bool LimitAngularVelocity = true;

        /// <summary>
        ///     Gets whether linear velocity limiting is enabled.
        /// </summary>
        /// <value><c>true</c> if linear velocity is limited; otherwise <c>false</c>.</value>
        public readonly bool LimitLinearVelocity = true;

        /// <summary>
        ///     The max angular sqared
        /// </summary>
        private float _maxAngularSqared;

        /// <summary>
        ///     The max angular velocity
        /// </summary>
        private float _maxAngularVelocity;

        /// <summary>
        ///     The max linear sqared
        /// </summary>
        private float _maxLinearSqared;

        /// <summary>
        ///     The max linear velocity
        /// </summary>
        private float _maxLinearVelocity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VelocityLimitController" /> class.
        ///     Sets the max linear velocity to Settings.MaxTranslation
        ///     Sets the max angular velocity to Settings.MaxRotation
        /// </summary>
        public VelocityLimitController()
        {
            MaxLinearVelocity = SettingEnv.MaxTranslation;
            MaxAngularVelocity = SettingEnv.MaxRotation;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VelocityLimitController" /> class.
        ///     Pass in 0 or float.MaxValue to disable the limit.
        ///     maxAngularVelocity = 0 will disable the angular velocity limit.
        /// </summary>
        /// <param name="maxLinearVelocity">The max linear velocity.</param>
        /// <param name="maxAngularVelocity">The max angular velocity.</param>
        public VelocityLimitController(float maxLinearVelocity, float maxAngularVelocity)
        {
            if (Math.Abs(maxLinearVelocity) < float.Epsilon || Math.Abs(maxLinearVelocity - float.MaxValue) < float.Epsilon)
            {
                LimitLinearVelocity = false;
            }

            if (Math.Abs(maxAngularVelocity) < float.Epsilon || Math.Abs(maxAngularVelocity - float.MaxValue) < float.Epsilon)
            {
                LimitAngularVelocity = false;
            }

            MaxLinearVelocity = maxLinearVelocity;
            MaxAngularVelocity = maxAngularVelocity;
        }

        /// <summary>
        ///     Gets or sets the maximum allowable angular velocity.
        /// </summary>
        /// <value>The maximum angular velocity in radians per second.</value>
        /// <remarks>
        ///     Setting this property also updates the internal squared value for efficient comparison.
        /// </remarks>
        public float MaxAngularVelocity
        {
            get => _maxAngularVelocity;
            set
            {
                _maxAngularVelocity = value;
                _maxAngularSqared = _maxAngularVelocity * _maxAngularVelocity;
            }
        }

        /// <summary>
        ///     Gets or sets the maximum allowable linear velocity.
        /// </summary>
        /// <value>The maximum linear velocity in units per second.</value>
        /// <remarks>
        ///     Setting this property also updates the internal squared value for efficient comparison.
        /// </remarks>
        public float MaxLinearVelocity
        {
            get => _maxLinearVelocity;
            set
            {
                _maxLinearVelocity = value;
                _maxLinearSqared = _maxLinearVelocity * _maxLinearVelocity;
            }
        }

        /// <summary>
        ///     Clamps velocities of all registered bodies to their maximum limits.
        /// </summary>
        /// <param name="dt">Time step delta in seconds. Used to compute the displacement that would occur during the step.</param>
        /// <remarks>
        ///     <para>This method is called automatically by the physics world during simulation.
        ///     For each registered body, it checks whether the computed displacement (<c>dt * velocity</c>)
        ///     would exceed the configured maximum and scales the velocity proportionally if needed.</para>
        ///     <para>Linear velocity is clamped using: <c>ratio = maxLinearVelocity / |velocity|</c></para>
        ///     <para>Angular velocity is clamped using: <c>ratio = maxAngularVelocity / |angularVelocity|</c></para>
        /// </remarks>
        public override void Update(float dt)
        {
            foreach (Body body in _bodies)
            {
                if (!IsActiveOn(body))
                {
                    continue;
                }

                if (LimitLinearVelocity)
                {
                    //Translation
                    // Check for large velocities.
                    float translationX = dt * body.LinearVelocityInternal.X;
                    float translationY = dt * body.LinearVelocityInternal.Y;
                    float result = translationX * translationX + translationY * translationY;

                    if (result > dt * _maxLinearSqared)
                    {
                        float sq = (float) Math.Sqrt(result);

                        float ratio = _maxLinearVelocity / sq;
                        body.LinearVelocityInternal.X *= ratio;
                        body.LinearVelocityInternal.Y *= ratio;
                    }
                }

                if (LimitAngularVelocity)
                {
                    //Rotation
                    float rotation = dt * body.AngularVelocity;
                    if (rotation * rotation > _maxAngularSqared)
                    {
                        float ratio = _maxAngularVelocity / Math.Abs(rotation);
                        body.AngularVelocity *= ratio;
                    }
                }
            }
        }

        /// <summary>
        ///     Adds the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void AddBody(Body body)
        {
            _bodies.Add(body);
        }

        /// <summary>
        ///     Removes the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void RemoveBody(Body body)
        {
            _bodies.Remove(body);
        }
    }
}