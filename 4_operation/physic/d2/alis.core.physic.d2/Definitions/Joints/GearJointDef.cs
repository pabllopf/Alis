// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GearJointDef.cs
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

using Alis.Core.Physic.D2.Dynamics.Joints;
using Alis.Core.Physic.D2.Dynamics.Joints.Misc;

namespace Alis.Core.Physic.D2.Definitions.Joints
{
    /// <summary>
    ///     The gear joint def class
    /// </summary>
    /// <seealso cref="JointDef" />
    public sealed class GearJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GearJointDef" /> class
        /// </summary>
        public GearJointDef() : base(JointType.Gear)
        {
            SetDefaults();
        }

        /// <summary>The first revolute/prismatic joint attached to the gear joint.</summary>
        public Joint JointA { get; set; }

        /// <summary>The second revolute/prismatic joint attached to the gear joint.</summary>
        public Joint JointB { get; set; }

        /// <summary>The gear ratio.</summary>
        public float Ratio { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            JointA = null;
            JointB = null;
            Ratio = 1.0f;
        }
    }
}