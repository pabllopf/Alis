// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MouseJointDef.cs
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
    ///     Mouse joint definition. This requires a world target point,
    ///     tuning parameters, and the time step.
    /// </summary>
    public class MouseJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseJointDef" /> class
        /// </summary>
        public MouseJointDef()
        {
            Type = JointType.MouseJoint;
            Target.Set(0.0f, 0.0f);
            MaxForce = 0.0f;
            FrequencyHz = 5.0f;
            DampingRatio = 0.7f;
        }

        /// <summary>
        ///     The initial world target point. This is assumed
        ///     to coincide with the body anchor initially.
        /// </summary>
        public Vec2 Target { get; }

        /// <summary>
        ///     The maximum constraint force that can be exerted
        ///     to move the candidate body. Usually you will express
        ///     as some multiple of the weight (multiplier * mass * gravity).
        /// </summary>
        public float MaxForce { get; }

        /// <summary>
        ///     The response speed.
        /// </summary>
        public float FrequencyHz { get; }

        /// <summary>
        ///     The damping ratio. 0 = no damping, 1 = critical damping.
        /// </summary>
        public float DampingRatio { get; }
    }
}