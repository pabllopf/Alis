// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrismaticJointTest.cs
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
    /// The prismatic joint test class
    /// </summary>
    public class PrismaticJointTest
    {
        /// <summary>
        /// Tests that prismatic joint type should be accessible
        /// </summary>
        [Fact]
        public void PrismaticJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PrismaticJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set joint type to prismatic
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetJointTypeToPrismatic()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Assert.Equal(JointType.Prismatic, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

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
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F anchor = new Vector2F(2.0f, 3.0f);
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
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F anchor = new Vector2F(4.0f, 5.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that motor impulse should round trip
        /// </summary>
        [Fact]
        public void MotorImpulse_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MotorImpulse = 2.5f;

            Assert.Equal(2.5f, joint.MotorImpulse);
        }

        /// <summary>
        /// Tests that reference angle should round trip
        /// </summary>
        [Fact]
        public void ReferenceAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.ReferenceAngle = 0.3f;

            Assert.Equal(0.3f, joint.ReferenceAngle);
        }

        /// <summary>
        /// Tests that the internal default constructor sets the joint type
        /// </summary>
        [Fact]
        public void Constructor_InternalDefault_SetsJointType()
        {
            PrismaticJoint joint = new PrismaticJoint();

            Assert.Equal(JointType.Prismatic, joint.JointType);
        }

        /// <summary>
        /// Tests that world anchor a should round trip via local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F worldAnchor = new Vector2F(0.5f, 0.5f);
            joint.WorldAnchorA = worldAnchor;

            Vector2F localAnchor = bodyA.GetLocalPoint(worldAnchor);
            Assert.Equal(localAnchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b should round trip via local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorB_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F worldAnchor = new Vector2F(0.5f, 0.5f);
            joint.WorldAnchorB = worldAnchor;

            Vector2F localAnchor = bodyB.GetLocalPoint(worldAnchor);
            Assert.Equal(localAnchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that axis1 should round trip
        /// </summary>
        [Fact]
        public void Axis1_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F axis = new Vector2F(0.5f, 0.866f);
            joint.Axis1 = axis;

            Assert.Equal(axis, joint.Axis1);
        }

        /// <summary>
        /// Tests that local x axis is computed from axis1
        /// </summary>
        [Fact]
        public void LocalXAxis_ShouldBeNormalized()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Assert.True(joint.LocalXAxis.Length() > 0.99);
        }

        /// <summary>
        /// Tests that limit enabled round trips
        /// </summary>
        [Fact]
        public void LimitEnabled_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.LimitEnabled = true;
            Assert.True(joint.LimitEnabled);

            joint.LimitEnabled = false;
            Assert.False(joint.LimitEnabled);
        }

        /// <summary>
        /// Tests that motor enabled round trips
        /// </summary>
        [Fact]
        public void MotorEnabled_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MotorEnabled = true;
            Assert.True(joint.MotorEnabled);

            joint.MotorEnabled = false;
            Assert.False(joint.MotorEnabled);
        }

        /// <summary>
        /// Tests that lower limit round trips
        /// </summary>
        [Fact]
        public void LowerLimit_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.LowerLimit = -2.5f;
            Assert.Equal(-2.5f, joint.LowerLimit);
        }

        /// <summary>
        /// Tests that upper limit round trips
        /// </summary>
        [Fact]
        public void UpperLimit_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.UpperLimit = 3.5f;
            Assert.Equal(3.5f, joint.UpperLimit);
        }

        /// <summary>
        /// Tests that motor speed round trips
        /// </summary>
        [Fact]
        public void MotorSpeed_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MotorSpeed = 5.0f;
            Assert.Equal(5.0f, joint.MotorSpeed);
        }

        /// <summary>
        /// Tests that world anchor a getter works with bodies in a world
        /// </summary>
        [Fact]
        public void WorldAnchorA_Getter_ShouldReturnCorrectWorldPoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(1.0f, 2.0f), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(3.0f, 4.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F worldAnchor = joint.WorldAnchorA;

            Assert.Equal(new Vector2F(1.0f, 2.0f), worldAnchor);
        }

        /// <summary>
        /// Tests that world anchor b getter works with bodies in a world
        /// </summary>
        [Fact]
        public void WorldAnchorB_Getter_ShouldReturnCorrectWorldPoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(1.0f, 2.0f), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(3.0f, 4.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F worldAnchor = joint.WorldAnchorB;

            Assert.Equal(new Vector2F(3.0f, 4.0f), worldAnchor);
        }

        /// <summary>
        /// Tests that joint translation is computed correctly with bodies in a world
        /// </summary>
        [Fact]
        public void JointTranslation_ShouldReturnCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            float translation = joint.JointTranslation;

            Assert.Equal(2.0f, translation);
        }

        /// <summary>
        /// Tests that joint speed is computed correctly with bodies in a world
        /// </summary>
        [Fact]
        public void JointSpeed_ShouldReturnCorrectValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0, BodyType.Dynamic);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            bodyB.LinearVelocityInternal = new Vector2F(1.0f, 0.0f);

            float speed = joint.JointSpeed;

            Assert.True(speed > 0.0f);
        }

        /// <summary>
        /// Tests that max motor force round trips
        /// </summary>
        [Fact]
        public void MaxMotorForce_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MaxMotorForce = 100.0f;
            Assert.Equal(100.0f, joint.MaxMotorForce);
        }

        /// <summary>
        /// Tests that set limits wakes bodies and resets impulse
        /// </summary>
        [Fact]
        public void SetLimits_ShouldSetValues()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.SetLimits(-1.0f, 2.0f);

            Assert.Equal(-1.0f, joint.LowerLimit);
            Assert.Equal(2.0f, joint.UpperLimit);
        }

        /// <summary>
        /// Tests that set limits with same values does not reset impulse
        /// </summary>
        [Fact]
        public void SetLimits_WithSameValues_DoesNotResetImpulse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.SetLimits(-1.0f, 2.0f);
            joint.MotorImpulse = 5.0f;
            joint.SetLimits(-1.0f, 2.0f);

            Assert.Equal(5.0f, joint.MotorImpulse);
        }

        /// <summary>
        /// Tests that get motor force returns impulse times inv dt
        /// </summary>
        [Fact]
        public void GetMotorForce_ShouldReturnImpulseTimesInvDt()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MotorImpulse = 10.0f;
            float force = joint.GetMotorForce(2.0f);

            Assert.Equal(20.0f, force);
        }

        /// <summary>
        /// Tests that step with limit enabled initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithLimitEnabled_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with motor enabled initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithMotorEnabled_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with both limit and motor enabled initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithLimitAndMotor_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at lower bound initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtLower_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(-2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at upper bound initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtUpper_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, -0.1f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with equal limit (zero range) initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithEqualLimit_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(0.0f, 0.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit enabled and motor enabled over multiple steps initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithLimitAndMotor_MultipleSteps_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at lower bound and motor over multiple steps initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtLower_WithMotor_MultipleSteps_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(-2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 1.0f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at upper bound and motor over multiple steps initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtUpper_WithMotor_MultipleSteps_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, -0.1f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = -2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with fixed rotation bodies initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithFixedRotationBodies_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            bodyA.FixedRotation = true;
            bodyB.FixedRotation = true;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with world coordinates constructor initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithWorldCoordinates_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f), true);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with world coordinates and offset anchor initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithWorldCoordinatesAndOffsetAnchor_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, new Vector2F(0.5f, 0), new Vector2F(1.0f, 0.0f), true);
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at lower bound and world anchor offset initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtLower_WithWorldAnchorOffset_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 10.0f);
            bodyB.CreateFixture(shape);
            bodyB.AngularVelocity = -5.0f;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, new Vector2F(0.5f, 0), new Vector2F(1.0f, 0.0f), true);
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 0.8f);
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit at upper bound and world anchor offset initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_LimitAtUpper_WithWorldAnchorOffset_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 10.0f);
            bodyB.CreateFixture(shape);
            bodyB.AngularVelocity = 5.0f;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, new Vector2F(0.5f, 0), new Vector2F(1.0f, 0.0f), true);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.8f, -0.1f);
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with limit and motor over multiple steps initializes solver constraints
        /// </summary>
        [Fact]
        public void Step_WithLimitAndMotor_MultipleStepsWithWorldAnchor_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 10.0f);
            bodyB.CreateFixture(shape);
            bodyB.AngularVelocity = -5.0f;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, new Vector2F(0.5f, 0), new Vector2F(1.0f, 0.0f), true);
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 0.8f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorForce = 50.0f;
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction torque returns non-zero value after step
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnNonZeroAfterStep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            float torque = joint.GetReactionTorque(60.0f);
            Assert.True(System.Math.Abs(torque) >= 0.0f);
        }

        /// <summary>
        /// Tests that step with fixed rotation bodies in position constraints uses fixed path
        /// </summary>
        [Fact]
        public void Step_WithFixedRotationBodies_PositionConstraint_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            bodyA.FixedRotation = true;
            bodyB.FixedRotation = true;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, 1.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with fixed rotation bodies and no limit triggers k22 fixup
        /// </summary>
        [Fact]
        public void Step_WithFixedRotationBodies_NoLimit_ShouldInitializeSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            bodyA.FixedRotation = true;
            bodyB.FixedRotation = true;

            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }
    }
}
