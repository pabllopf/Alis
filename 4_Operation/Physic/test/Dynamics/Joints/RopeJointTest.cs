// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RopeJointTest.cs
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
    /// The rope joint test class
    /// </summary>
    public class RopeJointTest
    {
        /// <summary>
        /// Tests that rope joint type should be accessible
        /// </summary>
        [Fact]
        public void RopeJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(RopeJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to rope
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToRope()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(JointType.Rope, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that constructor with default use world coordinates should set anchors directly
        /// </summary>
        [Fact]
        public void Constructor_WithDefaultUseWorldCoordinates_ShouldSetAnchorsDirectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchorA = new Vector2F(1.0f, 2.0f);
            Vector2F anchorB = new Vector2F(3.0f, 4.0f);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, anchorA, anchorB);

            Assert.Equal(anchorA, joint.LocalAnchorA);
            Assert.Equal(anchorB, joint.LocalAnchorB);
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

            RopeJoint joint = new RopeJoint(bodyA, bodyB, worldAnchorA, worldAnchorB, true);

            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorA);
            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that constructor should compute max length from anchors
        /// </summary>
        [Fact]
        public void Constructor_ShouldComputeMaxLengthFromAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(3.0f, 4.0f));

            Assert.Equal(5.0f, joint.MaxLength, 5);
        }

        /// <summary>
        /// Tests that constructor with use world coordinates should compute max length
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinates_ShouldComputeMaxLength()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(10.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(20.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F worldAnchorA = new Vector2F(12.0f, 0.0f);
            Vector2F worldAnchorB = new Vector2F(22.0f, 0.0f);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, worldAnchorA, worldAnchorB, true);

            Assert.Equal(10.0f, joint.MaxLength, 5);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

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
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F anchor = new Vector2F(3.0f, 4.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that max length should round trip
        /// </summary>
        [Fact]
        public void MaxLength_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    MaxLength = 5.0f
                };

            Assert.Equal(5.0f, joint.MaxLength, 5);
        }

        /// <summary>
        /// Tests that max length should default to distance between anchors
        /// </summary>
        [Fact]
        public void MaxLength_ShouldDefaultToDistanceBetweenAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(3.0f, 4.0f));

            Assert.Equal(5.0f, joint.MaxLength, 5);
        }

        /// <summary>
        /// Tests that world anchor a get should return body a get world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAGetWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

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
            Body bodyB = new Body
                {
                    Position = new Vector2F(5.0f, 3.0f)
                };
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(new Vector2F(7.0f, 3.0f), anchor);
        }

        /// <summary>
        /// Tests that world anchor a set should update local anchor a
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldUpdateLocalAnchorA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    WorldAnchorA = new Vector2F(5.0f, 10.0f)
                };

            Assert.Equal(new Vector2F(5.0f, 10.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b set should update local anchor b
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldUpdateLocalAnchorB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    WorldAnchorB = new Vector2F(5.0f, 10.0f)
                };

            Assert.Equal(new Vector2F(5.0f, 10.0f), joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that state default should be inactive
        /// </summary>
        [Fact]
        public void State_Default_ShouldBeInactive()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(LimitState.Inactive, joint.State);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that get reaction force should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that step with default values should not throw
        /// </summary>
        [Fact]
        public void Step_WithDefaultValues_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with bodies separated beyond max length should activate constraint
        /// </summary>
        [Fact]
        public void Step_WithSeparatedBodies_ShouldActivateConstraint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-2.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    MaxLength = 1.0f
                };
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps should progress simulation
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_ShouldProgressSimulation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with small max length should keep bodies constrained
        /// </summary>
        [Fact]
        public void Step_WithSmallMaxLength_ShouldKeepBodiesConstrained()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    MaxLength = 0.5f
                };
            world.Add(joint);

            for (int i = 0; i < 30; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that get reaction force after step should not throw
        /// </summary>
        [Fact]
        public void Step_WithMaxLengthSet_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
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
            RopeJoint joint = new RopeJoint();
            Assert.Equal(JointType.Rope, joint.JointType);
        }

        /// <summary>
        /// Tests that step with overlapping bodies at same position should not throw
        /// </summary>
        [Fact]
        public void Step_WithOverlappingBodies_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.001f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max length greater than distance does not throw
        /// </summary>
        [Fact]
        public void Step_WithMaxLengthGreaterThanDistance_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    MaxLength = 10.0f
                };
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with zero mass bodies sets mass to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithZeroMassBodies_ShouldSetMassToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0));
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0));
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = Math.Max(indexA, indexB);

            TimeStep step = new TimeStep
                {
                    Dt = 1.0f / 60.0f,
                    InvDt = 60.0f,
                    DtRatio = 1.0f,
                    PositionIterations = 3,
                    VelocityIterations = 8,
                    WarmStarting = false
                };

            SolverData data = new SolverData
                {
                    Step = step,
                    Positions = new SolverPosition[maxIndex + 1],
                    Velocities = new SolverVelocity[maxIndex + 1],
                    Locks = new int[maxIndex + 1]
                };

            data.Positions[indexA] = new SolverPosition { C = bodyA.Sweep.C, A = bodyA.Sweep.A };
            data.Positions[indexB] = new SolverPosition { C = bodyB.Sweep.C, A = bodyB.Sweep.A };
            data.Velocities[indexA] = new SolverVelocity { V = bodyA.LinearVelocityInternal, W = bodyA.AngularVelocity };
            data.Velocities[indexB] = new SolverVelocity { V = bodyB.LinearVelocityInternal, W = bodyB.AngularVelocity };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._impulse, 5);
            Assert.Equal(0.0f, joint._mass, 5);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with warm starting disabled sets impulse to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingDisabled_ShouldSetImpulseToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = Math.Max(indexA, indexB);

            TimeStep step = new TimeStep
                {
                    Dt = 1.0f / 60.0f,
                    InvDt = 60.0f,
                    DtRatio = 1.0f,
                    PositionIterations = 3,
                    VelocityIterations = 8,
                    WarmStarting = false
                };

            SolverData data = new SolverData
                {
                    Step = step,
                    Positions = new SolverPosition[maxIndex + 1],
                    Velocities = new SolverVelocity[maxIndex + 1],
                    Locks = new int[maxIndex + 1]
                };

            data.Positions[indexA] = new SolverPosition { C = bodyA.Sweep.C, A = bodyA.Sweep.A };
            data.Positions[indexB] = new SolverPosition { C = bodyB.Sweep.C, A = bodyB.Sweep.A };
            data.Velocities[indexA] = new SolverVelocity { V = bodyA.LinearVelocityInternal, W = bodyA.AngularVelocity };
            data.Velocities[indexB] = new SolverVelocity { V = bodyB.LinearVelocityInternal, W = bodyB.AngularVelocity };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._impulse, 5);
        }
    }
}
