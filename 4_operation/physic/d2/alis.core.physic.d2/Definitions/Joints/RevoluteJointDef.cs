// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RevoluteJointDef.cs
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
using Alis.Core.Physic.D2.Dynamics;
using Alis.Core.Physic.D2.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.D2.Definitions.Joints
{
    /// <summary>
    ///     Revolute joint definition. This requires defining an anchor point where the bodies are joined. The definition
    ///     uses local anchor points so that the initial configuration can violate the constraint slightly. You also need to
    ///     specify the initial relative angle for joint limits. This helps when saving and loading a game. The local anchor
    ///     points
    ///     are measured from the body's origin rather than the center of mass because: 1. you might not know where the center
    ///     of
    ///     mass will be. 2. if you add/remove shapes from a body and recompute the mass, the joints will be broken.
    /// </summary>
    public sealed class RevoluteJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RevoluteJointDef" /> class
        /// </summary>
        public RevoluteJointDef() : base(JointType.Revolute)
        {
            SetDefaults();
        }

        /// <summary>A flag to enable joint limits.</summary>
        public bool EnableLimit { get; set; }

        /// <summary>A flag to enable the joint motor.</summary>
        public bool EnableMotor { get; set; }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2 LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2 LocalAnchorB { get; set; }

        /// <summary>The lower angle for the joint limit (radians).</summary>
        public float LowerAngle { get; set; }

        /// <summary>The maximum motor torque used to achieve the desired motor speed. Usually in N-m.</summary>
        public float MaxMotorTorque { get; set; }

        /// <summary>The desired motor speed. Usually in radians per second.</summary>
        public float MotorSpeed { get; set; }

        /// <summary>The bodyB angle minus bodyA angle in the reference state (radians).</summary>
        public float ReferenceAngle { get; set; }

        /// <summary>The upper angle for the joint limit (radians).</summary>
        public float UpperAngle { get; set; }

        /// <summary>
        ///     Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        /// <param name="anchor">The anchor</param>
        public void Initialize(Body bA, Body bB, Vector2 anchor)
        {
            BodyA = bA;
            BodyB = bB;
            LocalAnchorA = BodyA.GetLocalPoint(anchor);
            LocalAnchorB = BodyB.GetLocalPoint(anchor);
            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;
        }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            LocalAnchorA = Vector2.Zero;
            LocalAnchorB = Vector2.Zero;
            ReferenceAngle = 0.0f;
            LowerAngle = 0.0f;
            UpperAngle = 0.0f;
            MaxMotorTorque = 0.0f;
            MotorSpeed = 0.0f;
            EnableLimit = false;
            EnableMotor = false;

            base.SetDefaults();
        }
    }
}