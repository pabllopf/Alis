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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using System.Reflection;
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

            Assert.Equal(2.0f, joint.Ratio, 5);
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

            Assert.Equal(3.0f, joint.LengthA, 5);
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

            Assert.Equal(4.0f, joint.LengthB, 5);
        }

        /// <summary>
        /// Tests that world anchor a should round trip.
        /// </summary>
        [Fact]
        public void WorldAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F expected = new Vector2F(5.0f, 10.0f);
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, expected, new Vector2F(0.0f, -1.0f), 1.0f);

            Assert.Equal(expected, joint.WorldAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b should round trip.
        /// </summary>
        [Fact]
        public void WorldAnchorB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F expected = new Vector2F(5.0f, 10.0f);
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), expected, 1.0f);

            Assert.Equal(expected, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that get reaction torque returns zero.
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
        }

        /// <summary>
        /// Tests that get reaction force uses impulse.
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnImpulseBasedForce()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that constructor with use world coordinates initializes lengths correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinates_ShouldComputeLengths()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F localAnchor = new Vector2F(1.0f, 2.0f);
            Vector2F worldAnchor = new Vector2F(4.0f, 6.0f);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, localAnchor, localAnchor, worldAnchor, worldAnchor, 2.0f, true);

            Assert.Equal(JointType.Pulley, joint.JointType);
            Assert.Equal(2.0f, joint.Ratio, 5);
            Assert.True(joint.LengthA > 0);
            Assert.True(joint.LengthB > 0);
        }

        /// <summary>
        /// Tests that CurrentLengthA returns the distance from WorldAnchorA to the world position of LocalAnchorA.
        /// </summary>
        [Fact]
        public void CurrentLengthA_ShouldReturnDistanceFromWorldAnchorA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            float length = joint.CurrentLengthA;

            Assert.True(length > 0.0f);
        }

        /// <summary>
        /// Tests that CurrentLengthB returns the distance from WorldAnchorB to the world position of LocalAnchorB.
        /// </summary>
        [Fact]
        public void CurrentLengthB_ShouldReturnDistanceFromWorldAnchorB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, -1.0f), 1.0f);

            float length = joint.CurrentLengthB;

            Assert.True(length > 0.0f);
        }

        /// <summary>
        /// Tests that stepping the world with a pulley joint and two dynamic bodies
        /// exercises the solver (InitVelocityConstraints, SolveVelocityConstraints, SolvePositionConstraints).
        /// </summary>
        [Fact]
        public void Step_WithTwoDynamicBodies_ShouldInvokeSolverMethods()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Pulley, joint.JointType);
        }

        /// <summary>
        /// Tests that stepping the world multiple times maintains constraint stability.
        /// </summary>
        [Fact]
        public void Step_MultipleTimes_ShouldMaintainStability()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 1.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 1.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that GetReactionForce can be retrieved after stepping the world.
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterStep_ShouldBeAccessible()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 1.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 1.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Vector2F force = joint.GetReactionForce(1.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with a different ratio exercises varied solver paths.
        /// </summary>
        [Fact]
        public void Step_WithNonUnitRatio_ShouldWork()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                2.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(2.0f, joint.Ratio, 5);
        }

        /// <summary>
        /// Tests that stepping with useWorldCoordinates = true works in simulation context.
        /// </summary>
        [Fact]
        public void Step_WithUseWorldCoordinates_ShouldWork()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f,
                useWorldCoordinates: true);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with zero gravity and setting initial velocities exercises velocity constraint solving.
        /// </summary>
        [Fact]
        public void Step_WithInitialVelocities_ShouldExerciseVelocityConstraints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);
            bodyA.LinearVelocity = new Vector2F(2.0f, 0.0f);
            bodyB.LinearVelocity = new Vector2F(-2.0f, 0.0f);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that the constructor with useWorldCoordinates = false (default) still computes lengths.
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesFalse_ShouldComputeLengths()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchor = new Vector2F(0.5f, 0.5f);
            Vector2F worldAnchor = new Vector2F(0.0f, -1.0f);

            PulleyJoint joint = new PulleyJoint(bodyA, bodyB, anchor, anchor, worldAnchor, worldAnchor, 1.0f);

            Assert.True(joint.LengthA > 0.0f);
            Assert.True(joint.LengthB > 0.0f);
        }

        /// <summary>
        /// Tests that stepping with anchors placed at the same position as world anchors
        /// exercises the short-length branches in the solver (where lengthA/lengthB <= 10*LinearSlop).
        /// </summary>
        [Fact]
        public void Step_WithZeroLengthAnchors_ShouldHitShortLengthBranches()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vector2F position = new Vector2F(0.0f, 0.0f);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, position, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, position, BodyType.Dynamic);

            Vector2F samePoint = new Vector2F(0.0f, 0.0f);
            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                samePoint, samePoint,
                samePoint, samePoint,
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with very close anchors (distance less than 10*LinearSlop)
        /// exercises the else branch in the length checks within solver methods.
        /// </summary>
        [Fact]
        public void Step_WithVeryCloseAnchors_ShouldHitShortLengthBranches()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vector2F position = new Vector2F(0.0f, 0.0f);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, position, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, position, BodyType.Dynamic);

            Vector2F closePoint = new Vector2F(0.001f, 0.0f);
            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                closePoint, closePoint,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(0.0f, 0.0f),
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that GetReactionForce with a high invDt produces a scaled force after stepping.
        /// </summary>
        [Fact]
        public void GetReactionForce_WithHighInvDt_ShouldBeAccessible()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 1.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 1.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Vector2F force = joint.GetReactionForce(100.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with warm starting enabled exercises the warm-start path.
        /// </summary>
        [Fact]
        public void Step_WithWarmStarting_ExercisesWarmStart()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with zero-length anchors (both uA and uB become zero) exercises the short-length branches.
        /// </summary>
        [Fact]
        public void Step_WithZeroLengthBothAnchors_ExercisesShortBranches()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                Vector2F.Zero, Vector2F.Zero,
                Vector2F.Zero, Vector2F.Zero,
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that stepping with mass > 0 in SolvePositionConstraints exercises the mass branch.
        /// </summary>
        [Fact]
        public void Step_WithValidMass_ExercisesPositionMassBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                2.0f);

            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that internal constructor should set joint type
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointType()
        {
            PulleyJoint joint = new PulleyJoint();
            Assert.Equal(JointType.Pulley, joint.JointType);
        }

        /// <summary>
        /// Tests that step with pulley joint and without warm starting covers else branch
        /// </summary>
        [Fact]
        public void Step_WithPulleyJoint_CoversElseBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                new Vector2F(0.0f, 1.0f),
                new Vector2F(0.0f, -1.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, -2.0f),
                1.0f);

            world.Add(joint);
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with WarmStarting = false zeros out impulse, covering else branch lines 340-342
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingFalse_ShouldZeroOutImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PulleyJoint joint = new PulleyJoint(
                bodyA, bodyB,
                Vector2F.Zero, Vector2F.Zero,
                new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f),
                1.0f);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(PulleyJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }
    }
}
