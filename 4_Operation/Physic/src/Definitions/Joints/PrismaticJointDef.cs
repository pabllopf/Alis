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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.Definitions.Joints
{
    /// <summary>
    ///     Prismatic joint definition. This requires defining a line of motion using an axis and an anchor point. The
    ///     definition uses local anchor points and a local axis so that the initial configuration can violate the constraint
    ///     slightly. The joint translation is zero when the local anchor points coincide in world space. Using local anchors
    ///     and a
    ///     local axis helps when saving and loading a game.
    /// </summary>
    public sealed class PrismaticJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJointDef" /> class
        /// </summary>
        public PrismaticJointDef() : base(JointType.Prismatic)
        {
            SetDefaults();
        }

        /// <summary>Enable/disable the joint limit.</summary>
        public bool EnableLimit { get; set; }

        /// <summary>Enable/disable the joint motor.</summary>
        public bool EnableMotor { get; set; }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2F LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2F LocalAnchorB { get; set; }

        /// <summary>The local translation unit axis in bodyA.</summary>
        public Vector2F LocalAxisA { get; set; }

        /// <summary>The lower translation limit, usually in meters.</summary>
        public float LowerTranslation { get; set; }

        /// <summary>The maximum motor torque, usually in N-m.</summary>
        public float MaxMotorForce { get; set; }

        /// <summary>The desired motor speed in radians per second.</summary>
        public float MotorSpeed { get; set; }

        /// <summary>The constrained angle between the bodies: bodyB_angle - bodyA_angle.</summary>
        public float ReferenceAngle { get; set; }

        /// <summary>The upper translation limit, usually in meters.</summary>
        public float UpperTranslation { get; set; }

        /// <summary>
        ///     Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        /// <param name="anchor">The anchor</param>
        /// <param name="axis">The axis</param>
        public void Initialize(Body bA, Body bB, Vector2F anchor, Vector2F axis)
        {
            BodyA = bA;
            BodyB = bB;
            LocalAnchorA = BodyA.GetLocalPoint(anchor);
            LocalAnchorB = BodyB.GetLocalPoint(anchor);
            LocalAxisA = BodyA.GetLocalVector(axis);
            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;
        }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            LocalAnchorA = Vector2F.Zero;
            LocalAnchorB = Vector2F.Zero;
            LocalAxisA = new Vector2F(1.0f, 0.0f);
            ReferenceAngle = 0.0f;
            EnableLimit = false;
            LowerTranslation = 0.0f;
            UpperTranslation = 0.0f;
            EnableMotor = false;
            MaxMotorForce = 0.0f;
            MotorSpeed = 0.0f;
        }
    }
}