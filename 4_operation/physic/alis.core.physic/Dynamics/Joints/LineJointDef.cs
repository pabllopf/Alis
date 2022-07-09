// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LineJointDef.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     Line joint definition. This requires defining a line of
    ///     motion using an axis and an anchor point. The definition uses local
    ///     anchor points and a local axis so that the initial configuration
    ///     can violate the constraint slightly. The joint translation is zero
    ///     when the local anchor points coincide in world space. Using local
    ///     anchors and a local axis helps when saving and loading a game.
    /// </summary>
    public class LineJointDef : JointDef
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
        public Vec2 localAnchor1;

        /// <summary>
        ///     The local anchor point relative to body2's origin.
        /// </summary>
        public Vec2 localAnchor2;

        /// <summary>
        ///     The local translation axis in body1.
        /// </summary>
        public Vec2 localAxis1;

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
        ///     The upper translation limit, usually in meters.
        /// </summary>
        public float upperTranslation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LineJointDef" /> class
        /// </summary>
        public LineJointDef()
        {
            Type = JointType.LineJoint;
            localAnchor1.SetZero();
            localAnchor2.SetZero();
            localAxis1.Set(1.0f, 0.0f);
            enableLimit = false;
            lowerTranslation = 0.0f;
            upperTranslation = 0.0f;
            enableMotor = false;
            maxMotorForce = 0.0f;
            motorSpeed = 0.0f;
        }

        /// <summary>
        ///     Initialize the bodies, anchors, axis, and reference angle using the world
        ///     anchor and world axis.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vec2 anchor, Vec2 axis)
        {
            Body1 = body1;
            Body2 = body2;
            localAnchor1 = body1.GetLocalPoint(anchor);
            localAnchor2 = body2.GetLocalPoint(anchor);
            localAxis1 = body1.GetLocalVector(axis);
        }
    }
}