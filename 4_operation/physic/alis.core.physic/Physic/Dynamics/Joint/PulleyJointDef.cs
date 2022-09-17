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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     Pulley joint definition. This requires two ground anchors,
    ///     two dynamic body anchor points, max lengths for each side,
    ///     and a pulley ratio.
    /// </summary>
    public class PulleyJointDef : JointDef
    {
        /// <summary>
        ///     The first ground anchor in world coordinates. This point never moves.
        /// </summary>
        public Vector2 GroundAnchor1;

        /// <summary>
        ///     The second ground anchor in world coordinates. This point never moves.
        /// </summary>
        public Vector2 GroundAnchor2;

        /// <summary>
        ///     The a reference length for the segment attached to body1.
        /// </summary>
        public float Length1;

        /// <summary>
        ///     The local anchor point relative to body1's origin.
        /// </summary>
        public Vector2 LocalAnchor1;

        /// <summary>
        ///     The local anchor point relative to body2's origin.
        /// </summary>
        public Vector2 LocalAnchor2;

        /// <summary>
        ///     The maximum length of the segment attached to body1.
        /// </summary>
        public float MaxLength1;

        /// <summary>
        ///     The pulley ratio, used to simulate a block-and-tackle.
        /// </summary>
        public float Ratio;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJointDef" /> class
        /// </summary>
        public PulleyJointDef()
        {
            Type = JointType.PulleyJoint;
            GroundAnchor1.Set(-1.0f, 1.0f);
            GroundAnchor2.Set(1.0f, 1.0f);
            LocalAnchor1.Set(-1.0f, 0.0f);
            LocalAnchor2.Set(1.0f, 0.0f);
            Length1 = 0.0f;
            MaxLength1 = 0.0f;
            Length2 = 0.0f;
            MaxLength2 = 0.0f;
            Ratio = 1.0f;
            CollideConnected = true;
        }

        /// <summary>
        ///     The a reference length for the segment attached to body2.
        /// </summary>
        public float Length2 { get; set; }

        /// <summary>
        ///     The maximum length of the segment attached to body2.
        /// </summary>
        public float MaxLength2 { get; set; }

        /// Initialize the bodies, anchors, lengths, max lengths, and ratio using the world anchors.
        public void Initialize(BodyBase body1, BodyBase body2,
            Vector2 groundAnchor1, Vector2 groundAnchor2,
            Vector2 anchor1, Vector2 anchor2,
            float ratio)
        {
            Body1 = body1;
            Body2 = body2;
            GroundAnchor1 = groundAnchor1;
            GroundAnchor2 = groundAnchor2;
            LocalAnchor1 = body1.GetLocalPoint(anchor1);
            LocalAnchor2 = body2.GetLocalPoint(anchor2);
            Vector2 d1 = anchor1 - groundAnchor1;
            Length1 = d1.Length();
            Vector2 d2 = anchor2 - groundAnchor2;
            Length2 = d2.Length();
            Ratio = ratio;
            Box2DxDebug.Assert(ratio > Settings.FltEpsilon);
            float c = Length1 + ratio * Length2;
            MaxLength1 = c - ratio * PulleyJoint.MinPulleyLength;
            MaxLength2 = (c - PulleyJoint.MinPulleyLength) / ratio;
        }
    }
}