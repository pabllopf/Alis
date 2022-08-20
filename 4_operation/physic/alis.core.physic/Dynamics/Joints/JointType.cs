// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointType.cs
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
    ///     The joint type enum
    /// </summary>
    public enum JointType
    {
        /// <summary>
        ///     The unknown joint joint type
        /// </summary>
        UnknownJoint,

        /// <summary>
        ///     The revolute joint joint type
        /// </summary>
        RevoluteJoint,

        /// <summary>
        ///     The prismatic joint joint type
        /// </summary>
        PrismaticJoint,

        /// <summary>
        ///     The distance joint joint type
        /// </summary>
        DistanceJoint,

        /// <summary>
        ///     The pulley joint joint type
        /// </summary>
        PulleyJoint,

        /// <summary>
        ///     The mouse joint joint type
        /// </summary>
        MouseJoint,

        /// <summary>
        ///     The gear joint joint type
        /// </summary>
        GearJoint,

        /// <summary>
        ///     The line joint joint type
        /// </summary>
        LineJoint
    }
}