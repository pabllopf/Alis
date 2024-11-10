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
    ///     Put a limit on the linear (translation - the movespeed) and angular (rotation) velocity
    ///     of bodies added to this controller.
    /// </summary>
    public class VelocityLimitController : Controller
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly List<Body> _bodies = new List<Body>();

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
        ///     The limit angular velocity
        /// </summary>
        public bool LimitAngularVelocity = true;

        /// <summary>
        ///     The limit linear velocity
        /// </summary>
        public bool LimitLinearVelocity = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VelocityLimitController" /> class.
        ///     Sets the max linear velocity to Settings.MaxTranslation
        ///     Sets the max angular velocity to Settings.MaxRotation
        /// </summary>
        public VelocityLimitController()
        {
            MaxLinearVelocity = Settings.MaxTranslation;
            MaxAngularVelocity = Settings.MaxRotation;
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
            if (maxLinearVelocity == 0 || Math.Abs(maxLinearVelocity - float.MaxValue) < float.Epsilon)
                LimitLinearVelocity = false;

            if (maxAngularVelocity == 0 || Math.Abs(maxAngularVelocity - float.MaxValue) < float.Epsilon)
                LimitAngularVelocity = false;

            MaxLinearVelocity = maxLinearVelocity;
            MaxAngularVelocity = maxAngularVelocity;
        }

        /// <summary>
        ///     Gets or sets the max angular velocity.
        /// </summary>
        /// <value>The max angular velocity.</value>
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
        ///     Gets or sets the max linear velocity.
        /// </summary>
        /// <value>The max linear velocity.</value>
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
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        public override void Update(float dt)
        {
            foreach (Body body in _bodies)
            {
                if (!IsActiveOn(body))
                    continue;

                if (LimitLinearVelocity)
                {
                    //Translation
                    // Check for large velocities.
                    float translationX = dt * body._linearVelocity.X;
                    float translationY = dt * body._linearVelocity.Y;
                    float result = translationX * translationX + translationY * translationY;

                    if (result > dt * _maxLinearSqared)
                    {
                        float sq = (float) Math.Sqrt(result);

                        float ratio = _maxLinearVelocity / sq;
                        body._linearVelocity.X *= ratio;
                        body._linearVelocity.Y *= ratio;
                    }
                }

                if (LimitAngularVelocity)
                {
                    //Rotation
                    float rotation = dt * body._angularVelocity;
                    if (rotation * rotation > _maxAngularSqared)
                    {
                        float ratio = _maxAngularVelocity / Math.Abs(rotation);
                        body._angularVelocity *= ratio;
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