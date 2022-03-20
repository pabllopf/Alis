// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DistanceJointDef.cs
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
using Alis.Core.Physics2D.Dynamics.Bodies;

namespace Alis.Core.Physics2D.Dynamics.Joints.Distance
{
    /// <summary>
    ///     Distance joint definition. This requires defining an
    ///     anchor point on both bodies and the non-zero length of the
    ///     distance joint. The definition uses local anchor points
    ///     so that the initial configuration can violate the constraint
    ///     slightly. This helps when saving and loading a game.
    ///     @warning Do not use a zero or short length.
    /// </summary>
    public class DistanceJointDef : JointDef
    {
        /// <summary>
        ///     The linear damping in N*s/m.
        /// </summary>
        public float damping;

        /// <summary>
        /// The damping ratio
        /// </summary>
        [Obsolete("Use stiffness and damping instead of frequencyHz and dampingRatio")]
        public float? dampingRatio;

        /// <summary>
        /// The frequency hz
        /// </summary>
        [Obsolete("Use stiffness and damping instead of frequencyHz and dampingRatio")]
        public float? frequencyHz;

        /// <summary>
        ///     The equilibrium length between the anchor points.
        /// </summary>
        public float length;

        /// <summary>
        ///     The local anchor point relative to body1's origin.
        /// </summary>
        public Vector2 localAnchorA;

        /// <summary>
        ///     The local anchor point relative to body2's origin.
        /// </summary>
        public Vector2 localAnchorB;

        /// <summary>
        ///     The linear stiffness in N/m. A value of 0 disables softness.
        /// </summary>
        public float stiffness;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceJointDef"/> class
        /// </summary>
        public DistanceJointDef() => length = 1.0f;

        /// <summary>
        ///     Initialize the bodies, anchors, and length using the world anchors.
        /// </summary>
        public void Initialize(Body bodyA, Body bodyB, Vector2 anchor1, Vector2 anchor2, float frequencyHz = 0f,
            float dampingRatio = 0f)
        {
            this.bodyA = bodyA;
            this.bodyB = bodyB;

            localAnchorA = bodyA.GetLocalPoint(anchor1);
            localAnchorB = bodyB.GetLocalPoint(anchor2);

            Vector2 d = anchor2 - anchor1;
            length = d.Length();

            Joint.LinearStiffness(out stiffness, out damping, frequencyHz, dampingRatio, bodyA, bodyB);
        }
    }
}