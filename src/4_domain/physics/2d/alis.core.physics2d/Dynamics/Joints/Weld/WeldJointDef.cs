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

using System;
using System.Numerics;

namespace Alis.Core.Physics2D.Dynamics.Joints.Weld
{
    /// <summary>
    /// The weld joint def class
    /// </summary>
    /// <seealso cref="JointDef"/>
    public class WeldJointDef : JointDef
    {
        /// <summary>
        ///     The rotational damping in N*m*s
        /// </summary>
        public float damping;

        /// <summary>
        /// The damping ratio
        /// </summary>
        [Obsolete("Use Joint.AngularStiffness to get stiffness & damping values", true)]
        public float dampingRatio;

        /// <summary>
        /// The frequency hz
        /// </summary>
        [Obsolete("Use Joint.AngularStiffness to get stiffness & damping values", true)]
        public float frequencyHz;

        /// <summary>
        /// The local anchor
        /// </summary>
        public Vector2 localAnchorA;
        /// <summary>
        /// The local anchor
        /// </summary>
        public Vector2 localAnchorB;
        /// <summary>
        /// The reference angle
        /// </summary>
        public float referenceAngle;

        /// <summary>
        ///     The rotational stiffness in N*m
        ///     Disable softness with a value of 0
        /// </summary>
        public float stiffness;
    }
}