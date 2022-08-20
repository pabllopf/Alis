// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RevoluteJointDef.cs
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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     Revolute joint definition. This requires defining an
    ///     anchor point where the bodies are joined. The definition
    ///     uses local anchor points so that the initial configuration
    ///     can violate the constraint slightly. You also need to
    ///     specify the initial relative angle for joint limits. This
    ///     helps when saving and loading a game.
    ///     The local anchor points are measured from the body's origin
    ///     rather than the center of mass because:
    ///     1. you might not know where the center of mass will be.
    ///     2. if you add/remove shapes from a body and recompute the mass,
    ///     the joints will be broken.
    /// </summary>
    public class RevoluteJointDef : JointDef
    {
        /// <summary>
        ///     A flag to enable joint limits.
        /// </summary>
        public readonly bool EnableLimit;

        /// <summary>
        ///     A flag to enable the joint motor.
        /// </summary>
        public readonly bool EnableMotor;

        /// <summary>
        ///     The lower angle for the joint limit (radians).
        /// </summary>
        public readonly float LowerAngle;

        /// <summary>
        ///     The maximum motor torque used to achieve the desired motor speed.
        ///     Usually in N-m.
        /// </summary>
        public readonly float MaxMotorTorque;

        /// <summary>
        ///     The desired motor speed. Usually in radians per second.
        /// </summary>
        public readonly float MotorSpeed;

        /// <summary>
        ///     The upper angle for the joint limit (radians).
        /// </summary>
        public readonly float UpperAngle;

        /// <summary>
        ///     The local anchor point relative to body1's origin.
        /// </summary>
        public Vector2 LocalAnchor1;

        /// <summary>
        ///     The local anchor point relative to body2's origin.
        /// </summary>
        public Vector2 LocalAnchor2;

        /// <summary>
        ///     The body2 angle minus body1 angle in the reference state (radians).
        /// </summary>
        public float ReferenceAngle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RevoluteJointDef" /> class
        /// </summary>
        public RevoluteJointDef()
        {
            Type = JointType.RevoluteJoint;
            LocalAnchor1.Set(0.0f, 0.0f);
            LocalAnchor2.Set(0.0f, 0.0f);
            ReferenceAngle = 0.0f;
            LowerAngle = 0.0f;
            UpperAngle = 0.0f;
            MaxMotorTorque = 0.0f;
            MotorSpeed = 0.0f;
            EnableLimit = false;
            EnableMotor = false;
        }

        /// <summary>
        ///     Initialize the bodies, anchors, and reference angle using the world
        ///     anchor.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vector2 anchor)
        {
            Body1 = body1;
            Body2 = body2;
            LocalAnchor1 = body1.GetLocalPoint(anchor);
            LocalAnchor2 = body2.GetLocalPoint(anchor);
            ReferenceAngle = body2.GetAngle() - body1.GetAngle();
        }
    }
}