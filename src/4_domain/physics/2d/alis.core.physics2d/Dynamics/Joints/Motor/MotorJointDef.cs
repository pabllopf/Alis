// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MotorJointDef.cs
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

using System.Numerics;
using Alis.Core.Physics2D.Dynamics.Bodies;

namespace Alis.Core.Physics2D.Dynamics.Joints.Motor
{
    /// <summary>
    /// The motor joint def class
    /// </summary>
    /// <seealso cref="JointDef"/>
    public class MotorJointDef : JointDef
    {
        /// The bodyB angle minus bodyA angle in radians.
        public float angularOffset;

        /// Position correction factor in the range [0,1].
        public float correctionFactor;

        /// Position of bodyB minus the position of bodyA, in bodyA's frame, in meters.
        public Vector2 linearOffset;

        /// The maximum motor force in N.
        public float maxForce;

        /// The maximum motor torque in N-m.
        public float maxTorque;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorJointDef"/> class
        /// </summary>
        private MotorJointDef()
        {
            maxForce = 1.0f;
            maxTorque = 1.0f;
            correctionFactor = 0.3f;
        }

        /// Initialize the bodies and offsets using the current transforms.
        public void Initialize(Body bA, Body bB)
        {
            bodyA = bA;
            bodyB = bB;
            Vector2 xB = bodyB.GetPosition();
            linearOffset = bodyA.GetLocalPoint(xB);

            float angleA = bodyA.GetAngle();
            float angleB = bodyB.GetAngle();
            angularOffset = angleB - angleA;
        }
    }
}