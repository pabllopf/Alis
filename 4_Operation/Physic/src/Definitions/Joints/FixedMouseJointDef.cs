// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixedMouseJointDef.cs
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
using Alis.Core.Physic.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.Definitions.Joints
{
    /// <summary>Mouse joint definition. This requires a world target point, tuning parameters, and the time step.</summary>
    public sealed class FixedMouseJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FixedMouseJointDef" /> class
        /// </summary>
        public FixedMouseJointDef() : base(JointType.FixedMouse)
        {
            SetDefaults();
        }

        /// <summary>The linear damping in N*s/m</summary>
        public float Damping { get; set; }

        /// <summary>The linear stiffness in N/m</summary>
        public float Stiffness { get; set; }

        /// <summary>
        ///     The maximum constraint force that can be exerted to move the candidate body. Usually you will express as some
        ///     multiple of the weight (multiplier * mass * gravity).
        /// </summary>
        public float MaxForce { get; set; }

        /// <summary>The initial world target point. This is assumed to coincide with the body anchor initially.</summary>
        public Vector2F Target { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            Target = Vector2F.Zero;
            MaxForce = 0.0f;
            Stiffness = 0.0f;
            Damping = 0.0f;
        }
    }
}