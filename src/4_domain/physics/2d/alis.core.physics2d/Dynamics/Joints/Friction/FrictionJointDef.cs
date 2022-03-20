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
using Alis.Core.Physics2D.Dynamics.Bodies;

namespace Alis.Core.Physics2D.Dynamics.Joints.Friction
{
    /// <summary>
    /// The friction joint def class
    /// </summary>
    /// <seealso cref="JointDef"/>
    public class FrictionJointDef : JointDef
    {
        /// <summary>
        /// The local anchor
        /// </summary>
        public Vector2 localAnchorA;
        /// <summary>
        /// The local anchor
        /// </summary>
        public Vector2 localAnchorB;
        /// <summary>
        /// The max force
        /// </summary>
        public float maxForce;
        /// <summary>
        /// The max torque
        /// </summary>
        public float maxTorque;

        /// <summary>
        /// Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        /// <param name="anchor">The anchor</param>
        public void Initialize(Body bA, Body bB, in Vector2 anchor)
        {
            bodyA = bA;
            bodyB = bB;
            localAnchorA = bodyA.GetLocalPoint(anchor);
            localAnchorB = bodyB.GetLocalPoint(anchor);
        }
    }
}