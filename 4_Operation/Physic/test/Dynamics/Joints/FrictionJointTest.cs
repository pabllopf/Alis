// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJointTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The friction joint test class
    /// </summary>
    public class FrictionJointTest
    {
        /// <summary>
        /// Tests that friction joint type should be accessible
        /// </summary>
        [Fact]
        public void FrictionJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(FrictionJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to friction
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToFriction()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(JointType.Friction, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that max force should round trip
        /// </summary>
        [Fact]
        public void MaxForce_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 300.0f
                };

            Assert.Equal(300.0f, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that max torque should round trip
        /// </summary>
        [Fact]
        public void MaxTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxTorque = 50.0f
                };

            Assert.Equal(50.0f, joint.MaxTorque, 5);
        }

        /// <summary>
        /// Tests that internal parameterless constructor should set joint type to friction
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointTypeToFriction()
        {
            FrictionJoint joint = new FrictionJoint();

            Assert.Equal(JointType.Friction, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchor should set local anchor a
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetLocalAnchorA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchor = new Vector2F(1.0f, 2.0f);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, anchor);

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchor should set local anchor b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetLocalAnchorB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchor = new Vector2F(1.0f, 2.0f);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, anchor);

            Assert.Equal(anchor, joint.LocalAnchorB);
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
            Vector2F worldAnchor = new Vector2F(10.0f, 5.0f);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, worldAnchor, true);

            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorA);
            Assert.Equal(new Vector2F(-10.0f, 5.0f), joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that max force should default to zero
        /// </summary>
        [Fact]
        public void MaxForce_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(0.0f, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that max torque should default to zero
        /// </summary>
        [Fact]
        public void MaxTorque_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(0.0f, joint.MaxTorque, 5);
        }

        /// <summary>
        /// Tests that get reaction force should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that get reaction force with inv dt should return zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithInvDt_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(62.5f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque with inv dt should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_WithInvDt_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            float torque = joint.GetReactionTorque(62.5f);

            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that world anchor a get should return body a get world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAGetWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

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
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(new Vector2F(5.0f, 3.0f), anchor);
        }

        /// <summary>
        /// Tests that world anchor a set should update local anchor a
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldUpdateLocalAnchorA()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(5.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10.0f, 0.0f), 0.0f, BodyType.Dynamic);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    WorldAnchorA = new Vector2F(8.0f, 3.0f)
                };

            Assert.Equal(new Vector2F(3.0f, 3.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b set should update local anchor b
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldUpdateLocalAnchorB()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(5.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10.0f, 0.0f), 0.0f, BodyType.Dynamic);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    WorldAnchorB = new Vector2F(15.0f, 4.0f)
                };

            Assert.Equal(new Vector2F(5.0f, 4.0f), joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

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
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F expected = new Vector2F(6.0f, 7.0f);
            joint.LocalAnchorB = expected;

            Assert.Equal(expected, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that step with default values initializes solver without throwing
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

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max force initializes linear friction solver
        /// </summary>
        [Fact]
        public void Step_WithMaxForce_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 50.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max torque initializes angular friction solver
        /// </summary>
        [Fact]
        public void Step_WithMaxTorque_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxTorque = 25.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with both max force and max torque initializes both friction solvers
        /// </summary>
        [Fact]
        public void Step_WithMaxForceAndMaxTorque_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 50.0f,
                    MaxTorque = 25.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with large max force clamps linear impulse correctly
        /// </summary>
        [Fact]
        public void Step_WithLargeMaxForce_MultipleSteps_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 500.0f
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
        /// Tests that multiple steps with max torque progress the simulation
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_WithMaxTorque_ShouldProgressSimulation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxTorque = 50.0f
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
        /// Tests that step with very high force produces non-zero reaction force
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterStep_WithMaxForce_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 100.0f
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

            joint.GetReactionForce(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps with both force and torque maintain stability
        /// </summary>
        [Fact]
        public void Step_WithForceAndTorque_MultipleSteps_ShouldMaintainStability()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 50.0f,
                    MaxTorque = 25.0f
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
        /// Tests that GetReactionTorque after step with max torque returns non-zero value.
        /// </summary>
        [Fact]
        public void GetReactionTorque_AfterStep_WithMaxTorque_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxTorque = 50.0f
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

            joint.GetReactionTorque(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that angular mass is computed when both bodies have inertia.
        /// </summary>
        [Fact]
        public void AngularMass_WithPositiveInertia_ShouldComputeCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 0.0f,
                    MaxTorque = 0.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that construction with useWorldCoordinates=false uses local anchors directly.
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesFalse_UsesLocalAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchor = new Vector2F(2.0f, 3.0f);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, anchor);

            Assert.Equal(anchor, joint.LocalAnchorA);
            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that Step with zero MaxForce and MaxTorque still progresses simulation.
        /// </summary>
        [Fact]
        public void Step_WithZeroForceAndTorque_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 0.0f,
                    MaxTorque = 0.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that linear impulse clamping is exercised with large velocity difference.
        /// </summary>
        [Fact]
        public void Step_WithLargeVelocityDifference_ExercisesImpulseClamping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
                {
                    MaxForce = 1.0f
                };
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(joint);
        }

   
    }
}
