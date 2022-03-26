// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PrismaticJointDef.cs
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
using Alis.Core.Physics2D.Bodies;

namespace Alis.Core.Physics2D.Joints.Prismatic
{
    /// <summary>
    ///     Prismatic joint definition. This requires defining a line of
    ///     motion using an axis and an anchor point. The definition uses local
    ///     anchor points and a local axis so that the initial configuration
    ///     can violate the constraint slightly. The joint translation is zero
    ///     when the local anchor points coincide in world space. Using local
    ///     anchors and a local axis helps when saving and loading a game.
    /// </summary>
    public class PrismaticJointDef : JointDef
    {
        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public bool enableLimit;

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public bool enableMotor;

        /// <summary>
        ///     The local anchor point relative to body1's origin.
        /// </summary>
        public Vector2 localAnchorA;

        /// <summary>
        ///     The local anchor point relative to body2's origin.
        /// </summary>
        public Vector2 localAnchorB;

        /// <summary>
        ///     The local translation axis in body1.
        /// </summary>
        public Vector2 localAxisA;

        /// <summary>
        ///     The lower translation limit, usually in meters.
        /// </summary>
        public float lowerTranslation;

        /// <summary>
        ///     The maximum motor torque, usually in N-m.
        /// </summary>
        public float maxMotorForce;

        /// <summary>
        ///     The desired motor speed in radians per second.
        /// </summary>
        public float motorSpeed;

        /// <summary>
        ///     The constrained angle between the bodies: body2_angle - body1_angle.
        /// </summary>
        public float referenceAngle;

        /// <summary>
        ///     The upper translation limit, usually in meters.
        /// </summary>
        public float upperTranslation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJointDef" /> class
        /// </summary>
        public PrismaticJointDef() => localAxisA = new Vector2(1.0f, 0.0f);

        /// <summary>
        ///     Initialize the bodies, anchors, axis, and reference angle using the world
        ///     anchor and world axis.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vector2 anchor, Vector2 axis)
        {
            bodyA = body1;
            bodyB = body2;
            localAnchorA = body1.GetLocalPoint(anchor);
            localAnchorB = body2.GetLocalPoint(anchor);
            localAxisA = body1.GetLocalVector(axis);
            referenceAngle = body2.GetAngle() - body1.GetAngle();
        }
    }
}