// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FrictionJointDef.cs
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
using Alis.Core.Physic.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.Definitions.Joints
{
    /// <summary>
    ///     The friction joint def class
    /// </summary>
    /// <seealso cref="JointDef" />
    public sealed class FrictionJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrictionJointDef" /> class
        /// </summary>
        public FrictionJointDef() : base(JointType.Friction)
        {
            SetDefaults();
        }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2 LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2 LocalAnchorB { get; set; }

        /// <summary>The maximum friction force in N.</summary>
        public float MaxForce { get; set; }

        /// <summary>The maximum friction torque in N-m.</summary>
        public float MaxTorque { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            LocalAnchorA = Vector2.Zero;
            LocalAnchorB = Vector2.Zero;
            MaxForce = 0.0f;
            MaxTorque = 0.0f;

            base.SetDefaults();
        }
    }
}