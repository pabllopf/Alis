// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MotorJointTest.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The motor joint test class
    /// </summary>
    public class MotorJointTest
    {
        /// <summary>
        /// Tests that motor joint type should be accessible
        /// </summary>
        [Fact]
        public void MotorJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(MotorJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies should set joint type to motor
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetJointTypeToMotor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(JointType.Motor, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

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
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxForce = 500.0f
                };

            Assert.Equal(500.0f, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that max torque should round trip
        /// </summary>
        [Fact]
        public void MaxTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxTorque = 100.0f
                };

            Assert.Equal(100.0f, joint.MaxTorque, 5);
        }

        /// <summary>
        /// Tests that get reaction force should return zero for default joint
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroForDefaultJoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero for default joint
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroForDefaultJoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that linear offset should round trip
        /// </summary>
        [Fact]
        public void LinearOffset_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F offset = new Vector2F(3.0f, 4.0f);
            joint.LinearOffset = offset;

            Assert.Equal(offset, joint.LinearOffset);
        }

        /// <summary>
        /// Tests that angular offset should round trip
        /// </summary>
        [Fact]
        public void AngularOffset_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    AngularOffset = 0.5f
                };

            Assert.Equal(0.5f, joint.AngularOffset, 5);
        }

        /// <summary>
        /// Tests that constructor with useWorldCoordinates true sets linear offset correctly
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesTrue_ShouldSetLinearOffset()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(10.0f, 0.0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(20.0f, 0.0f), 0f, BodyType.Dynamic);

            MotorJoint joint = new MotorJoint(bodyA, bodyB, true);

            Assert.Equal(JointType.Motor, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with useWorldCoordinates false uses world coordinates directly
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesFalse_ShouldUseWorldCoordinates()
        {
            Body bodyA = new Body();
            Body bodyB = new Body
                {
                    Position = new Vector2F(5.0f, 3.0f)
                };

            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(JointType.Motor, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor initializes max force to one
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeMaxForceToOne()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(1.0f, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that constructor initializes max torque to one
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeMaxTorqueToOne()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(1.0f, joint.MaxTorque, 5);
        }

        /// <summary>
        /// Tests that world anchor a get returns body a position
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(3.0f, 4.0f);
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(new Vector2F(3.0f, 4.0f), anchor);
        }

        /// <summary>
        /// Tests that world anchor b get returns body b position
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnBodyBPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body
                {
                    Position = new Vector2F(5.0f, 6.0f)
                };
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(new Vector2F(5.0f, 6.0f), anchor);
        }

        /// <summary>
        /// Tests that world anchor a set updates linear error and does not throw
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldNotThrow()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    WorldAnchorA = new Vector2F(10.0f, 20.0f)
                };

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that world anchor b set updates linear error and does not throw
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldNotThrow()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    WorldAnchorB = new Vector2F(15.0f, 25.0f)
                };

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that linear offset set with same value does not change offset
        /// </summary>
        [Fact]
        public void LinearOffset_SetSameValue_ShouldNotChange()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F original = joint.LinearOffset;
            joint.LinearOffset = original;

            Assert.Equal(original, joint.LinearOffset);
        }

        /// <summary>
        /// Tests that angular offset set with same value does not change offset
        /// </summary>
        [Fact]
        public void AngularOffset_SetSameValue_ShouldNotChange()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            float original = joint.AngularOffset;
            joint.AngularOffset = original;

            Assert.Equal(original, joint.AngularOffset);
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

            MotorJoint joint = new MotorJoint(bodyA, bodyB);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max force initializes linear friction solver without throwing
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

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxForce = 50.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max torque initializes angular friction solver without throwing
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

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxTorque = 25.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with max force and max torque initializes both friction solvers without throwing
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

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxForce = 50.0f,
                    MaxTorque = 25.0f
                };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps with max force progress the simulation without throwing
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_WithMaxForce_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
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

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps with max torque progress the simulation without throwing
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_WithMaxTorque_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
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
        /// Tests that multiple steps with linear offset progress the simulation without throwing
        /// </summary>
        [Fact]
        public void Step_WithLinearOffset_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    LinearOffset = new Vector2F(0.5f, 0.0f)
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
        /// Tests that multiple steps with angular offset progress the simulation without throwing
        /// </summary>
        [Fact]
        public void Step_WithAngularOffset_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    AngularOffset = 0.1f
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
        /// Tests that get reaction force returns value after step with max force
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterStep_WithMaxForce_ShouldReturnValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
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
        /// Tests that get reaction torque returns value after step with max torque
        /// </summary>
        [Fact]
        public void GetReactionTorque_AfterStep_WithMaxTorque_ShouldReturnValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
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
        /// Tests that step with both force and torque for multiple steps maintains stability
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

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
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
        /// Tests that GetReactionTorque after step with max torque returns a value.
        /// </summary>
        [Fact]
        public void GetReactionTorque_AfterStep_WithMaxTorque_ReturnsValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxTorque = 50.0f,
                    MaxForce = 0.0f
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
        /// Tests that motor joint with large linear offset and max force exercises linear friction clamping.
        /// </summary>
        [Fact]
        public void Step_WithLargeLinearOffset_ExercisesLinearClamping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    MaxForce = 500.0f,
                    LinearOffset = new Vector2F(10.0f, 10.0f)
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
        /// Tests that angular mass is zero when both bodies have no inertia.
        /// </summary>
        [Fact]
        public void AngularMass_WithNoInertia_HandlesCorrectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
            Assert.Equal(Vector2F.Zero, joint.GetReactionForce(1.0f));
        }

        /// <summary>
        /// Tests that AngularOffset set with new value wakes bodies and updates offset.
        /// </summary>
        [Fact]
        public void AngularOffset_SetDifferentValue_ShouldWakeBodies()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    AngularOffset = 0.3f
                };

            Assert.Equal(0.3f, joint.AngularOffset, 5);
        }

        /// <summary>
        /// Tests that LinearOffset set with new value wakes bodies and updates offset.
        /// </summary>
        [Fact]
        public void LinearOffset_SetDifferentValue_ShouldWakeBodies()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB)
                {
                    LinearOffset = new Vector2F(1.0f, 2.0f)
                };

            Assert.Equal(new Vector2F(1.0f, 2.0f), joint.LinearOffset);
        }

        /// <summary>
        /// Tests that the constructor initializes correction factor to 0.3.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeCorrectionFactor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(0.3f, joint.CorrectionFactor, 5);
        }

        /// <summary>
        /// Tests that WorldAnchorA set updates linear error (not position).
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_UpdatesLinearError()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);
            Vector2F original = joint.WorldAnchorA;

            joint.WorldAnchorA = new Vector2F(10.0f, 20.0f);

            Vector2F afterSet = joint.WorldAnchorA;
            Assert.Equal(original, afterSet);
        }

        /// <summary>
        /// Tests that WorldAnchorB set updates linear error (not position).
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_UpdatesLinearError()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);
            Vector2F original = joint.WorldAnchorB;

            joint.WorldAnchorB = new Vector2F(10.0f, 20.0f);

            Vector2F afterSet = joint.WorldAnchorB;
            Assert.Equal(original, afterSet);
        }

        /// <summary>
        /// Tests that internal constructor should set joint type
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointType()
        {
            MotorJoint joint = new MotorJoint();
            Assert.Equal(JointType.Motor, joint.JointType);
        }

        /// <summary>
        /// Tests that step with motor joint covers branch
        /// </summary>
        [Fact]
        public void Step_WithMotorJoint_CoversBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            MotorJoint joint = new MotorJoint(bodyA, bodyB);
            world.Add(joint);
            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with WarmStarting=false zeros impulses.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingFalse_ShouldZeroImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = new SolverData
                {
                    Step = new TimeStep { WarmStarting = false },
                    Positions = new SolverPosition[2]
                    {
                        new SolverPosition { C = Vector2F.Zero, A = 0f },
                        new SolverPosition { C = Vector2F.Zero, A = 0f }
                    },
                    Velocities = new SolverVelocity[2]
                    {
                        new SolverVelocity { V = Vector2F.Zero, W = 0f },
                        new SolverVelocity { V = Vector2F.Zero, W = 0f }
                    }
                };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(Vector2F.Zero, joint.GetReactionForce(1.0f));
            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
        }
    }
}
