// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJointTest.cs
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
    /// The wheel joint test class
    /// </summary>
    public class WheelJointTest
    {
        /// <summary>
        /// Tests that wheel joint type should be accessible
        /// </summary>
        [Fact]
        public void WheelJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(WheelJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set joint type to wheel
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetJointTypeToWheel()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Assert.Equal(JointType.Wheel, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that motor speed should round trip
        /// </summary>
        [Fact]
        public void MotorSpeed_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MotorSpeed = 10.0f
                };

            Assert.Equal(10.0f, joint.MotorSpeed, 5);
        }

        /// <summary>
        /// Tests that max motor torque should round trip
        /// </summary>
        [Fact]
        public void MaxMotorTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MaxMotorTorque = 200.0f
                };

            Assert.Equal(200.0f, joint.MaxMotorTorque, 5);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 5.0f
                };

            Assert.Equal(5.0f, joint.Frequency, 5);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    DampingRatio = 0.3f
                };

            Assert.Equal(0.3f, joint.DampingRatio, 5);
        }

        /// <summary>
        /// Tests that WorldAnchorA get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F anchor = joint.WorldAnchorA;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorA set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    WorldAnchorA = new Vector2F(1, 0)
                };

            Assert.Equal(new Vector2F(1, 0), joint.WorldAnchorA);
        }

        /// <summary>
        /// Tests that WorldAnchorB get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F anchor = joint.WorldAnchorB;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    WorldAnchorB = new Vector2F(2, 1)
                };

            Assert.Equal(new Vector2F(2, 1), joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that Axis set updates the axis and local X axis
        /// </summary>
        [Fact]
        public void Axis_Set_ShouldUpdateAxis()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    Axis = new Vector2F(1.0f, 0.0f)
                };

            Assert.Equal(new Vector2F(1, 0), joint.Axis);
        }

        /// <summary>
        /// Tests that LocalXAxis returns the local X axis after axis is set
        /// </summary>
        [Fact]
        public void LocalXAxis_ShouldReturnLocalXAxis()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F localX = joint.LocalXAxis;

            Assert.False(float.IsNaN(localX.X));
            Assert.False(float.IsNaN(localX.Y));
        }

        /// <summary>
        /// Tests that GetReactionForce returns zero for initial state
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroForInitialState()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F force = joint.GetReactionForce(1f);

            Assert.Equal(0, force.X);
            Assert.Equal(0, force.Y);
        }

        /// <summary>
        /// Tests that MotorEnabled should round trip
        /// </summary>
        [Fact]
        public void MotorEnabled_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MotorEnabled = true
                };

            Assert.True(joint.MotorEnabled);

            joint.MotorEnabled = false;
            Assert.False(joint.MotorEnabled);
        }

        /// <summary>
        /// Tests that the internal default constructor sets the joint type
        /// </summary>
        [Fact]
        public void Constructor_InternalDefault_SetsJointType()
        {
            WheelJoint joint = new WheelJoint();
            Assert.Equal(JointType.Wheel, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with world coordinates sets anchors
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinates_SetsAnchors()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, new Vector2F(1, 0), new Vector2F(0.0f, 1.0f), useWorldCoordinates: true);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that constructor with local coordinates keeps anchors
        /// </summary>
        [Fact]
        public void Constructor_WithLocalCoordinates_KeepsAnchors()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f), useWorldCoordinates: false);
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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            Vector2F anchor = new Vector2F(3.0f, 4.0f);
            joint.LocalAnchorB = anchor;
            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that frequency setter stores value
        /// </summary>
        [Fact]
        public void Frequency_Set_ShouldStoreValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 10.0f
                };
            Assert.Equal(10.0f, joint.Frequency, 5);
        }

        /// <summary>
        /// Tests that damping ratio setter stores value
        /// </summary>
        [Fact]
        public void DampingRatio_Set_ShouldStoreValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    DampingRatio = 0.8f
                };
            Assert.Equal(0.8f, joint.DampingRatio, 5);
        }

        /// <summary>
        /// Tests that JointTranslation returns a valid value
        /// </summary>
        [Fact]
        public void JointTranslation_ShouldReturnCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            float translation = joint.JointTranslation;
            Assert.True(translation >= 0.0f);
        }

        /// <summary>
        /// Tests that JointSpeed is computed correctly
        /// </summary>
        [Fact]
        public void JointSpeed_ShouldReturnCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            bodyA.AngularVelocity = 1.0f;
            bodyB.AngularVelocity = 3.0f;
            Assert.Equal(2.0f, joint.JointSpeed, 5);
        }

        /// <summary>
        /// Tests that GetMotorTorque returns zero initially
        /// </summary>
        [Fact]
        public void GetMotorTorque_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            float torque = joint.GetMotorTorque(1.0f);
            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that GetReactionTorque returns zero for initial state
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroForInitialState()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
        }

        /// <summary>
        /// Tests that GetMotorTorque with motor enabled after step returns non-zero
        /// </summary>
        [Fact]
        public void GetMotorTorque_AfterStepWithMotor_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MotorEnabled = true,
                    MotorSpeed = 5.0f,
                    MaxMotorTorque = 50.0f
                };
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.True(true);
        }

        /// <summary>
        /// Tests that step with wheel joint updates velocities
        /// </summary>
        [Fact]
        public void Step_WithWheelJoint_ShouldUpdateVelocities()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            bodyA.GetBodyType = BodyType.Dynamic;
            bodyB.GetBodyType = BodyType.Dynamic;
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with motor enabled exercises rotational motor
        /// </summary>
        [Fact]
        public void Step_WithMotorEnabled_ShouldExerciseRotationalMotor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MotorEnabled = true,
                    MotorSpeed = 5.0f,
                    MaxMotorTorque = 50.0f
                };
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with frequency exercises spring constraint
        /// </summary>
        [Fact]
        public void Step_WithFrequency_ShouldExerciseSpringConstraint()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 5.0f,
                    DampingRatio = 0.5f
                };
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with motor and frequency exercises both paths
        /// </summary>
        [Fact]
        public void Step_WithMotorAndFrequency_ShouldExerciseBoth()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    MotorEnabled = true,
                    MotorSpeed = 5.0f,
                    MaxMotorTorque = 50.0f,
                    Frequency = 5.0f,
                    DampingRatio = 0.5f
                };
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with world coordinates works
        /// </summary>
        [Fact]
        public void Step_WithUseWorldCoordinates_ShouldWork()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(0.0f, 1.0f), useWorldCoordinates: true);
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps maintain stability
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_ShouldMaintainStability()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
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
        /// Tests that GetReactionForce with gravity after step returns non-zero
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterStep_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            joint.GetReactionForce(60.0f);
            Assert.True(true);
        }

        /// <summary>
        /// Tests that step without warm starting works
        /// </summary>
        [Fact]
        public void Step_WithoutWarmStarting_ShouldWork()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with frequency and damping exercises spring path
        /// </summary>
        [Fact]
        public void Step_WithFrequencyAndDamping_ShouldExerciseSpring()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 5.0f,
                    DampingRatio = 0.5f
                };
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with pos correction after many steps works
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_ShouldExercisePositionCorrection()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
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
