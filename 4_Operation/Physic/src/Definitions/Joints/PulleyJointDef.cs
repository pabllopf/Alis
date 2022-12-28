// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJointDef.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints.Misc;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Definitions.Joints
{
    /// <summary>Pulley joint definition. This requires two ground anchors, two dynamic body anchor points, and a pulley ratio.</summary>
    public sealed class PulleyJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJointDef" /> class
        /// </summary>
        public PulleyJointDef() : base(JointType.Pulley)
        {
            SetDefaults();
        }

        /// <summary>The first ground anchor in world coordinates. This point never moves.</summary>
        public Vector2F GroundAnchorA { get; set; }

        /// <summary>The second ground anchor in world coordinates. This point never moves.</summary>
        public Vector2F GroundAnchorB { get; set; }

        /// <summary>The a reference length for the segment attached to bodyA.</summary>
        public float LengthA { get; set; }

        /// <summary>The a reference length for the segment attached to bodyB.</summary>
        public float LengthB { get; set; }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2F LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2F LocalAnchorB { get; set; }

        /// <summary>The pulley ratio, used to simulate a block-and-tackle.</summary>
        public float Ratio { get; set; }

        /// <summary>
        ///     Initializes the b a
        /// </summary>
        /// <param name="bA">The </param>
        /// <param name="bB">The </param>
        /// <param name="groundA">The ground</param>
        /// <param name="groundB">The ground</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="r">The </param>
        public void Initialize(Body bA, Body bB, Vector2F groundA, Vector2F groundB, Vector2F anchorA, Vector2F anchorB,
            float r)
        {
            BodyA = bA;
            BodyB = bB;
            GroundAnchorA = groundA;
            GroundAnchorB = groundB;
            LocalAnchorA = BodyA.GetLocalPoint(anchorA);
            LocalAnchorB = BodyB.GetLocalPoint(anchorB);
            Vector2F dA = anchorA - groundA;
            LengthA = dA.Length();
            Vector2F dB = anchorB - groundB;
            LengthB = dB.Length();
            Ratio = r;
            Debug.Assert(Ratio > MathConstants.Epsilon);
        }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            GroundAnchorA = new Vector2F(-1.0f, 1.0f);
            GroundAnchorB = new Vector2F(1.0f, 1.0f);
            LocalAnchorA = new Vector2F(-1.0f, 0.0f);
            LocalAnchorB = new Vector2F(1.0f, 0.0f);
            LengthA = 0.0f;
            LengthB = 0.0f;
            Ratio = 1.0f;
            CollideConnected = true;
        }
    }
}