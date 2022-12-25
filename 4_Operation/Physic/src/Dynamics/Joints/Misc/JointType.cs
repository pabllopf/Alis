// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   JointType.cs
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

namespace Alis.Core.Physic.Dynamics.Joints.Misc
{
    /// <summary>
    ///     The joint type enum
    /// </summary>
    public enum JointType
    {
        /// <summary>
        ///     The unknown joint type
        /// </summary>
        Unknown,

        /// <summary>
        ///     The revolute joint type
        /// </summary>
        Revolute,

        /// <summary>
        ///     The prismatic joint type
        /// </summary>
        Prismatic,

        /// <summary>
        ///     The distance joint type
        /// </summary>
        Distance,

        /// <summary>
        ///     The pulley joint type
        /// </summary>
        Pulley,

        //Mouse, <- We have fixed mouse
        /// <summary>
        ///     The gear joint type
        /// </summary>
        Gear,

        /// <summary>
        ///     The wheel joint type
        /// </summary>
        Wheel,

        /// <summary>
        ///     The weld joint type
        /// </summary>
        Weld,

        /// <summary>
        ///     The friction joint type
        /// </summary>
        Friction,

        /// <summary>
        ///     The motor joint type
        /// </summary>
        Motor,

        //Velcro note: From here on and down, it is only FPE joints
        /// <summary>
        ///     The angle joint type
        /// </summary>
        Angle,

        /// <summary>
        ///     The fixed mouse joint type
        /// </summary>
        FixedMouse,

        /// <summary>
        ///     The fixed revolute joint type
        /// </summary>
        FixedRevolute,

        /// <summary>
        ///     The fixed distance joint type
        /// </summary>
        FixedDistance,

        /// <summary>
        ///     The fixed line joint type
        /// </summary>
        FixedLine,

        /// <summary>
        ///     The fixed prismatic joint type
        /// </summary>
        FixedPrismatic,

        /// <summary>
        ///     The fixed angle joint type
        /// </summary>
        FixedAngle,

        /// <summary>
        ///     The fixed friction joint type
        /// </summary>
        FixedFriction
    }
}