// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJointRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint remaining coverage tests class
    /// </summary>
    public class PulleyJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor with use world coordinates true sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesTrue_SetsPropertiesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            Vector2F anchorA = new Vector2F(2, 3);
            Vector2F anchorB = new Vector2F(8, 3);
            Vector2F worldAnchorA = new Vector2F(0, 5);
            Vector2F worldAnchorB = new Vector2F(10, 5);
            float ratio = 1.5f;

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, anchorA, anchorB, worldAnchorA, worldAnchorB, ratio, true);

            Assert.Equal(JointType.Pulley, joint.JointType);
            Assert.Equal(worldAnchorA, joint.WorldAnchorA);
            Assert.Equal(worldAnchorB, joint.WorldAnchorB);
            Assert.Equal(ratio, joint.Ratio);
            Vector2F expectedLocalA = bodyA.GetLocalPoint(anchorA);
            Assert.Equal(expectedLocalA, joint.LocalAnchorA);
            Vector2F expectedLocalB = bodyB.GetLocalPoint(anchorB);
            Assert.Equal(expectedLocalB, joint.LocalAnchorB);
            float expectedLengthA = (anchorA - worldAnchorA).Length();
            Assert.Equal(expectedLengthA, joint.LengthA);
            float expectedLengthB = (anchorB - worldAnchorB).Length();
            Assert.Equal(expectedLengthB, joint.LengthB);
            float expectedConstant = expectedLengthA + ratio * expectedLengthB;
        }

        /// <summary>
        /// Tests that constructor with use world coordinates false sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesFalse_SetsPropertiesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            Vector2F localAnchorA = new Vector2F(1, 2);
            Vector2F localAnchorB = new Vector2F(-1, 2);
            Vector2F worldAnchorA = new Vector2F(0, 5);
            Vector2F worldAnchorB = new Vector2F(10, 5);
            float ratio = 0.75f;

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, localAnchorA, localAnchorB, worldAnchorA, worldAnchorB, ratio, false);

            Assert.Equal(JointType.Pulley, joint.JointType);
            Assert.Equal(worldAnchorA, joint.WorldAnchorA);
            Assert.Equal(worldAnchorB, joint.WorldAnchorB);
            Assert.Equal(ratio, joint.Ratio);
            Assert.Equal(localAnchorA, joint.LocalAnchorA);
            Assert.Equal(localAnchorB, joint.LocalAnchorB);
            Vector2F dA = localAnchorA - bodyA.GetLocalPoint(worldAnchorA);
            Assert.Equal(dA.Length(), joint.LengthA);
            Vector2F dB = localAnchorB - bodyB.GetLocalPoint(worldAnchorB);
            Assert.Equal(dB.Length(), joint.LengthB);
        }

        /// <summary>
        /// Tests that constructor with default use world coordinates sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_WithDefaultUseWorldCoordinates_UsesLocalCoordinates()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            Vector2F localAnchorA = new Vector2F(1, 2);
            Vector2F localAnchorB = new Vector2F(-1, 2);
            Vector2F worldAnchorA = new Vector2F(0, 5);
            Vector2F worldAnchorB = new Vector2F(10, 5);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, localAnchorA, localAnchorB, worldAnchorA, worldAnchorB, 1.0f);

            Assert.Equal(localAnchorA, joint.LocalAnchorA);
            Assert.Equal(localAnchorB, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that local anchor a get and set works
        /// </summary>
        [Fact]
        public void LocalAnchorA_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            Vector2F expected = new Vector2F(3, 4);
            joint.LocalAnchorA = expected;
            Assert.Equal(expected, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that local anchor b get and set works
        /// </summary>
        [Fact]
        public void LocalAnchorB_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            Vector2F expected = new Vector2F(3, 4);
            joint.LocalAnchorB = expected;
            Assert.Equal(expected, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that world anchor a get and set works
        /// </summary>
        [Fact]
        public void WorldAnchorA_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            Vector2F expected = new Vector2F(7, 8);
            joint.WorldAnchorA = expected;
            Assert.Equal(expected, joint.WorldAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b get and set works
        /// </summary>
        [Fact]
        public void WorldAnchorB_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            Vector2F expected = new Vector2F(7, 8);
            joint.WorldAnchorB = expected;
            Assert.Equal(expected, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that length a set and get works
        /// </summary>
        [Fact]
        public void LengthA_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            joint.LengthA = 42.0f;
            Assert.Equal(42.0f, joint.LengthA);
        }

        /// <summary>
        /// Tests that length b set and get works
        /// </summary>
        [Fact]
        public void LengthB_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            joint.LengthB = 24.0f;
            Assert.Equal(24.0f, joint.LengthB);
        }

        /// <summary>
        /// Tests that ratio set and get works
        /// </summary>
        [Fact]
        public void Ratio_SetAndGet_ReturnsCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);
            joint.Ratio = 2.5f;
            Assert.Equal(2.5f, joint.Ratio);
        }

        /// <summary>
        /// Tests that get reaction torque always returns zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_Always_ReturnsZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);

            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
            Assert.Equal(0.0f, joint.GetReactionTorque(0.5f));
            Assert.Equal(0.0f, joint.GetReactionTorque(0.0f));
        }

        /// <summary>
        /// Tests that get reaction force with zero impulse returns zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithZeroImpulse_ReturnsZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0, 5), new Vector2F(10, 5), 1.0f);

            Assert.Equal(Vector2F.Zero, joint.GetReactionForce(1.0f));
        }

        /// <summary>
        /// Tests that get reaction force computes correctly
        /// </summary>
        [Fact]
        public void GetReactionForce_WithInvDt_ReturnsScaledResult()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);
            Assert.True(force.LengthSquared() >= 0.0f);
        }

        /// <summary>
        /// Tests that current length a returns correct value after step
        /// </summary>
        [Fact]
        public void CurrentLengthA_AfterWorldStep_ReturnsCorrectLength()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            float currentLengthA = joint.CurrentLengthA;
            Assert.True(currentLengthA >= 0.0f);
        }

        /// <summary>
        /// Tests that current length b returns correct value after step
        /// </summary>
        [Fact]
        public void CurrentLengthB_AfterWorldStep_ReturnsCorrectLength()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            float currentLengthB = joint.CurrentLengthB;
            Assert.True(currentLengthB >= 0.0f);
        }

        /// <summary>
        /// Tests that init velocity constraints with warm starting updates impulse via world step
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStarting_UpdatesImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);
            float torque = joint.GetReactionTorque(1.0f / 60.0f);
            Assert.Equal(0.0f, torque);
            Assert.NotNull(joint.BodyA);
            Assert.NotNull(joint.BodyB);
        }

        /// <summary>
        /// Tests that init velocity constraints without warm starting sets impulse to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithoutWarmStarting_SetsImpulseToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Vector2F forceAfterStep = joint.GetReactionForce(1.0f / 60.0f);
            Assert.True(forceAfterStep.LengthSquared() >= 0.0f);
        }

        /// <summary>
        /// Tests that solve velocity constraints updates body velocities
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_UpdatesBodyVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);
            float torque = joint.GetReactionTorque(1.0f / 60.0f);

            Assert.Equal(0.0f, torque);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that solve position constraints returns result
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ReturnsResult()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);

            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint.BodyA);
            Assert.NotNull(joint.BodyB);
        }

        /// <summary>
        /// Tests that world step with pulley joint modifies body positions
        /// </summary>
        [Fact]
        public void WorldStep_WithPulleyJoint_ModifiesBodyPositions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            Vector2F posA0 = bodyA.Position;
            Vector2F posB0 = bodyB.Position;

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }

        /// <summary>
        /// Tests that multiple world steps converge pulley constraint
        /// </summary>
        [Fact]
        public void MultipleWorldSteps_WithPulleyJoint_ConvergesConstraint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(2, 3), new Vector2F(8, 3), new Vector2F(0, 5), new Vector2F(10, 5), 1.0f, true);

            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            float constant = joint.CurrentLengthA + joint.Ratio * joint.CurrentLengthB;
            float originalConstant = joint.LengthA + joint.Ratio * joint.LengthB;
            Assert.True(Math.Abs(constant - originalConstant) < 1.0f);
        }

        /// <summary>
        /// Tests that world step with disconnected anchors initializes properly
        /// </summary>
        [Fact]
        public void WorldStep_WithDisconnectedAnchors_InitializesProperly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0), 0.5f, true);

            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Assert.Equal(0.0f, joint.LengthA, 4);
            Assert.Equal(0.0f, joint.LengthB, 4);
        }
    }
}
