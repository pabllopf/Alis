// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WeldJointDef.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.Definitions.Joints
{
    /// <summary>
    ///     Weld joint definition. You need to specify local anchor points where they are attached and the relative body
    ///     angle. The position of the anchor points is important for computing the reaction torque.
    /// </summary>
    public sealed class WeldJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WeldJointDef" /> class
        /// </summary>
        public WeldJointDef() : base(JointType.Weld)
        {
            SetDefaults();
        }

        /// <summary>The rotational damping in N*m*s</summary>
        public float Damping { get; set; }

        /// <summary>The rotational stiffness in N*m. Disable softness with a value of 0</summary>
        public float Stiffness { get; set; }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2 LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2 LocalAnchorB { get; set; }

        /// <summary>The bodyB angle minus bodyA angle in the reference state (radians).</summary>
        public float ReferenceAngle { get; set; }

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
            Stiffness = 0.0f;
            Damping = 0.0f;

            base.SetDefaults();
        }
    }
}