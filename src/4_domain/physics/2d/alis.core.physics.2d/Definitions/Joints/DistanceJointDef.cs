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

using System.Numerics;
using Alis.Core.Systems.Physics2D.Config;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Definitions.Joints
{
    /// <summary>
    ///     Distance joint definition. This requires defining an anchor point on both bodies and the non-zero length of
    ///     the distance joint. The definition uses local anchor points so that the initial configuration can violate the
    ///     constraint slightly. This helps when saving and loading a game.
    ///     <remarks>Do not use a zero or a short length.</remarks>
    /// </summary>
    public sealed class DistanceJointDef : JointDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJointDef" /> class
        /// </summary>
        public DistanceJointDef() : base(JointType.Distance)
        {
            SetDefaults();
        }

        /// <summary>The linear damping in N*s/m.</summary>
        public float Damping { get; set; }

        /// <summary>The linear stiffness in N/m.</summary>
        public float Stiffness { get; set; }

        /// <summary>The rest length of this joint. Clamped to a stable minimum value.</summary>
        public float Length { get; set; }

        /// <summary>Minimum length. Clamped to a stable minimum value.</summary>
        public float MinLength { get; set; }

        /// <summary>Maximum length. Must be greater than or equal to the minimum length.</summary>
        public float MaxLength { get; set; }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2 LocalAnchorA { get; set; }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2 LocalAnchorB { get; set; }

        /// <summary>
        ///     Initializes the b 1
        /// </summary>
        /// <param name="b1">The </param>
        /// <param name="b2">The </param>
        /// <param name="anchor1">The anchor</param>
        /// <param name="anchor2">The anchor</param>
        public void Initialize(Body b1, Body b2, Vector2 anchor1, Vector2 anchor2)
        {
            BodyA = b1;
            BodyB = b2;
            LocalAnchorA = BodyA.GetLocalPoint(anchor1);
            LocalAnchorB = BodyB.GetLocalPoint(anchor2);
            Vector2 d = anchor2 - anchor1;
            Length = MathUtils.Max(d.Length(), Settings.LinearSlop);
            MinLength = Length;
            MaxLength = Length;
        }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            LocalAnchorA = Vector2.Zero;
            LocalAnchorB = Vector2.Zero;
            Length = 1.0f;
            MinLength = 0.0f;
            MaxLength = float.MaxValue;
            Stiffness = 0.0f;
            Damping = 0.0f;
        }
    }
}