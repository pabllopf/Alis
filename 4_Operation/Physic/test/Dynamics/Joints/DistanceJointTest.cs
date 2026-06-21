// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The distance joint test class
    /// </summary>
    public class DistanceJointTest
    {
        /// <summary>
        /// Tests that distance joint type should be accessible
        /// </summary>
        [Fact]
        public void DistanceJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DistanceJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to distance
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToDistance()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(JointType.Distance, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.Frequency = 5.0f;

            Assert.Equal(5.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.DampingRatio = 0.5f;

            Assert.Equal(0.5f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that length should round trip
        /// </summary>
        [Fact]
        public void Length_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.Length = 3.0f;

            Assert.Equal(3.0f, joint.Length);
        }

        /// <summary>
        /// Tests that internal parameterless constructor should set joint type to distance
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointTypeToDistance()
        {
            DistanceJoint joint = new DistanceJoint();

            Assert.Equal(JointType.Distance, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set local anchor a
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetLocalAnchorA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchorA = new Vector2F(1.0f, 2.0f);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, anchorA, new Vector2F(3.0f, 4.0f));

            Assert.Equal(anchorA, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set local anchor b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetLocalAnchorB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchorB = new Vector2F(3.0f, 4.0f);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(1.0f, 2.0f), anchorB);

            Assert.Equal(anchorB, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should calculate length
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldCalculateLength()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(3.0f, 4.0f));

            Assert.Equal(5.0f, joint.Length);
        }

        /// <summary>
        /// Tests that constructor with use world coordinates should transform anchors
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinates_ShouldTransformAnchors()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(10.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(20.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F worldAnchorA = new Vector2F(10.0f, 5.0f);
            Vector2F worldAnchorB = new Vector2F(20.0f, 5.0f);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, worldAnchorA, worldAnchorB, true);

            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorA);
            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorB);
            Assert.Equal(10.0f, joint.Length);
        }

        /// <summary>
        /// Tests that frequency should default to zero
        /// </summary>
        [Fact]
        public void Frequency_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(0.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should default to zero
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(0.0f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that get reaction force should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction force with inv dt should return zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithInvDt_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F force = joint.GetReactionForce(62.5f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that world anchor a get should return body a get world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAGetWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(bodyA.Position, anchor);
        }

        /// <summary>
        /// Tests that world anchor b get should return body b get world point
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnBodyBGetWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(5.0f, 3.0f);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(new Vector2F(7.0f, 3.0f), anchor);
        }

        /// <summary>
        /// Tests that world anchor a set should not throw
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldNotThrow()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.WorldAnchorA = new Vector2F(5.0f, 10.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that world anchor b set should not throw
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldNotThrow()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.WorldAnchorB = new Vector2F(5.0f, 10.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F expected = new Vector2F(4.0f, 5.0f);
            joint.LocalAnchorA = expected;

            Assert.Equal(expected, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that local anchor b should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F expected = new Vector2F(6.0f, 7.0f);
            joint.LocalAnchorB = expected;

            Assert.Equal(expected, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that length defaults to value computed from constructor
        /// </summary>
        [Fact]
        public void Length_ShouldDefaultToComputedValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(3.0f, 4.0f));

            Assert.Equal(5.0f, joint.Length);
        }
    }
}
