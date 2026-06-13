// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJointTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint test class
    /// </summary>
    public class PulleyJointTest
    {
        /// <summary>
        /// Tests that pulley joint type should be accessible
        /// </summary>
        [Fact]
        public void PulleyJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PulleyJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to pulley
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToPulley()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Assert.Equal(JointType.Pulley, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Vector2F anchor = new Vector2F(1.0f, 2.0f);
            joint.LocalAnchorA = anchor;

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that local anchor b should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Vector2F anchor = new Vector2F(3.0f, 4.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that ratio should round trip
        /// </summary>
        [Fact]
        public void Ratio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            joint.Ratio = 2.0f;

            Assert.Equal(2.0f, joint.Ratio);
        }

        /// <summary>
        /// Tests that length a should round trip
        /// </summary>
        [Fact]
        public void LengthA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            joint.LengthA = 3.0f;

            Assert.Equal(3.0f, joint.LengthA);
        }

        /// <summary>
        /// Tests that length b should round trip
        /// </summary>
        [Fact]
        public void LengthB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            joint.LengthB = 4.0f;

            Assert.Equal(4.0f, joint.LengthB);
        }
    }
}
