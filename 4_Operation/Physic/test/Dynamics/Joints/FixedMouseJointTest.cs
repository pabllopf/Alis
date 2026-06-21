// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedMouseJointTest.cs
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
    /// The fixed mouse joint test class
    /// </summary>
    public class FixedMouseJointTest
    {
        /// <summary>
        /// Tests that fixed mouse joint type should be accessible
        /// </summary>
        [Fact]
        public void FixedMouseJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(FixedMouseJoint));
        }

        /// <summary>
        /// Tests that constructor with body and anchor should set joint type to fixed mouse
        /// </summary>
        [Fact]
        public void Constructor_WithBodyAndAnchor_ShouldSetJointTypeToFixedMouse()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(JointType.FixedMouse, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with body and anchor should set body a
        /// </summary>
        [Fact]
        public void Constructor_WithBodyAndAnchor_ShouldSetBodyA()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Same(body, joint.BodyA);
        }

        /// <summary>
        /// Tests that max force should round trip
        /// </summary>
        [Fact]
        public void MaxForce_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.MaxForce = 500.0f;

            Assert.Equal(500.0f, joint.MaxForce);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.Frequency = 10.0f;

            Assert.Equal(10.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.DampingRatio = 0.5f;

            Assert.Equal(0.5f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F anchor = new Vector2F(2.0f, 3.0f);
            joint.LocalAnchorA = anchor;

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor a get should return body a get world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAGetWorldPoint()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(body.Position, anchor);
        }

        /// <summary>
        /// Tests that world anchor a set should update local anchor a
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldUpdateLocalAnchorA()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(5.0f, 0.0f), 0.0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.WorldAnchorA = new Vector2F(8.0f, 3.0f);

            Assert.Equal(new Vector2F(3.0f, 3.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b should round trip
        /// </summary>
        [Fact]
        public void WorldAnchorB_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F expected = new Vector2F(5.0f, 10.0f);
            joint.WorldAnchorB = expected;

            Assert.Equal(expected, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that world anchor b get from constructor should return world anchor
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetWorldAnchorB()
        {
            Body body = new Body();
            Vector2F worldAnchor = new Vector2F(10.0f, 20.0f);
            FixedMouseJoint joint = new FixedMouseJoint(body, worldAnchor);

            Assert.Equal(worldAnchor, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that frequency should default to five
        /// </summary>
        [Fact]
        public void Frequency_ShouldDefaultToFive()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(5.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should default to zero point seven
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldDefaultToZeroPointSeven()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(0.7f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that max force should default to body mass times thousand
        /// </summary>
        [Fact]
        public void MaxForce_ShouldDefaultToBodyMassTimesThousand()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(1000.0f * body.Mass, joint.MaxForce);
        }

        /// <summary>
        /// Tests that get reaction force should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroInitially()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction force with inv dt should return zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithInvDt_ShouldReturnZero()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(62.5f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that local anchor a from constructor should be computed from world anchor
        /// </summary>
        [Fact]
        public void Constructor_ShouldComputeLocalAnchorA()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(3.0f, 4.0f));

            Assert.Equal(new Vector2F(3.0f, 4.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that constructor with body and world anchor should compute local anchor a correctly
        /// </summary>
        [Fact]
        public void Constructor_WithWorldAnchor_ShouldComputeLocalAnchorACorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(5.0f, 10.0f), 0.0f, BodyType.Dynamic);

            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(8.0f, 15.0f));

            Assert.Equal(new Vector2F(3.0f, 5.0f), joint.LocalAnchorA);
        }
    }
}
