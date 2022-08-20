// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJointDef.cs
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

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     Gear joint definition. This definition requires two existing
    ///     revolute or prismatic joints (any combination will work).
    ///     The provided joints must attach a dynamic body to a static body.
    /// </summary>
    public class GearJointDef : JointDef
    {
        /// <summary>
        ///     The first revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public readonly Joint Joint1;

        /// <summary>
        ///     The second revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public readonly Joint Joint2;

        /// <summary>
        ///     The gear ratio.
        ///     @see GearJoint for explanation.
        /// </summary>
        public readonly float Ratio;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GearJointDef" /> class
        /// </summary>
        public GearJointDef()
        {
            Type = JointType.GearJoint;
            Joint1 = null;
            Joint2 = null;
            Ratio = 1.0f;
        }
    }
}