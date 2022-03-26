// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WheelJointDef.cs
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
using Alis.Core.Physics2D.Bodies;

namespace Alis.Core.Physics2D.Joints.Wheel
{
    /// <summary>
    ///     The wheel joint def class
    /// </summary>
    /// <seealso cref="JointDef" />
    public class WheelJointDef : JointDef
    {
        /// <summary>
        ///     The damping
        /// </summary>
        public float damping;

        /// <summary>
        ///     The damping ratio
        /// </summary>
        [Obsolete("Use stiffness and damping instead of frequencyHz and dampingRatio")]
        public float? dampingRatio;

        /// <summary>
        ///     The enable limit
        /// </summary>
        public bool enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        public bool enableMotor;

        /// <summary>
        ///     The frequency hz
        /// </summary>
        [Obsolete("Use stiffness and damping instead of frequencyHz and dampingRatio")]
        public float? frequencyHz;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 localAnchorB;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vector2 localAxisA;

        /// <summary>
        ///     The lower translation
        /// </summary>
        public float lowerTranslation;

        /// <summary>
        ///     The max motor torque
        /// </summary>
        public float maxMotorTorque;

        /// <summary>
        ///     The motor speed
        /// </summary>
        public float motorSpeed;

        /// <summary>
        ///     The stiffness
        /// </summary>
        public float stiffness;

        /// <summary>
        ///     The upper translation
        /// </summary>
        public float upperTranslation;

        /// <summary>
        ///     Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        /// <param name="anchor">The anchor</param>
        /// <param name="axis">The axis</param>
        public void Initialize(Body bA, Body bB, in Vector2 anchor, in Vector2 axis)
        {
            bodyA = bA;
            bodyB = bB;
            localAnchorA = bodyA.GetLocalPoint(anchor);
            localAnchorB = bodyB.GetLocalPoint(anchor);
            localAxisA = bodyA.GetLocalVector(axis);
        }
    }
}