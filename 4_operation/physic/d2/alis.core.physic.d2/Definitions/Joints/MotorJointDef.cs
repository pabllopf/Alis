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

using Alis.Core.Physic.D2.Dynamics;
using Alis.Core.Physic.D2.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.D2.Definitions.Joints
{
    /// <summary>
    ///     The motor joint def class
    /// </summary>
    /// <seealso cref="JointDef" />
    public sealed class MotorJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MotorJointDef" /> class
        /// </summary>
        public MotorJointDef() : base(JointType.Motor)
        {
            SetDefaults();
        }

        /// <summary>The bodyB angle minus bodyA angle in radians.</summary>
        public float AngularOffset { get; set; }

        /// <summary>Position correction factor in the range [0,1].</summary>
        public float CorrectionFactor { get; set; }

        /// <summary>Position of bodyB minus the position of bodyA, in bodyA's frame, in meters.</summary>
        public Vector2 LinearOffset { get; set; }

        /// <summary>The maximum motor force in N.</summary>
        public float MaxForce { get; set; }

        /// <summary>The maximum motor torque in N-m.</summary>
        public float MaxTorque { get; set; }

        /// <summary>
        ///     Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        public void Initialize(Body bA, Body bB)
        {
            BodyA = bA;
            BodyB = bB;
            Vector2 xB = BodyB.Position;
            LinearOffset = BodyA.GetLocalPoint(xB);

            float angleA = BodyA.Rotation;
            float angleB = BodyB.Rotation;
            AngularOffset = angleB - angleA;
        }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            LinearOffset = Vector2.Zero;
            AngularOffset = 0.0f;
            MaxForce = 1.0f;
            MaxTorque = 1.0f;
            CorrectionFactor = 0.3f;
        }
    }
}