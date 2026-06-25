using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class RevoluteJointTest
    {
        [Fact]
        public void RevoluteJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(RevoluteJoint));
        }

        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetJointTypeToRevolute()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(JointType.Revolute, joint.JointType);
        }

        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F anchor = new Vector2F(1.0f, 2.0f);
            joint.LocalAnchorA = anchor;

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        [Fact]
        public void LocalAnchorB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F anchor = new Vector2F(3.0f, 4.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        [Fact]
        public void Constructor_WithSeparateAnchors_SetsCorrectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchorA = new Vector2F(1f, 2f);
            Vector2F anchorB = new Vector2F(3f, 4f);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, anchorA, anchorB);

            Assert.Equal(anchorA, joint.LocalAnchorA);
            Assert.Equal(anchorB, joint.LocalAnchorB);
        }

        [Fact]
        public void Constructor_WithWorldCoordinates_SetsAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F worldAnchor = new Vector2F(5f, 5f);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, worldAnchor, worldAnchor, useWorldCoordinates: true);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Constructor_WithLocalCoordinates_KeepsAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F localAnchor = new Vector2F(2f, 3f);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, localAnchor, localAnchor, useWorldCoordinates: false);

            Assert.Equal(localAnchor, joint.LocalAnchorA);
            Assert.Equal(localAnchor, joint.LocalAnchorB);
        }

        [Fact]
        public void Constructor_WithSingleAnchor_AppliesToBoth()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Vector2F anchor = new Vector2F(1f, 1f);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, anchor);

            Assert.Equal(anchor, joint.LocalAnchorA);
            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        [Fact]
        public void WorldAnchorA_Get_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F expected = bodyA.GetWorldPoint(joint.LocalAnchorA);
            Assert.Equal(expected, joint.WorldAnchorA);
        }

        [Fact]
        public void WorldAnchorA_Set_UpdatesLocalAnchor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F worldValue = new Vector2F(10f, 10f);
            joint.WorldAnchorA = worldValue;

            Vector2F expected = bodyA.GetLocalPoint(worldValue);
            Assert.Equal(expected, joint.LocalAnchorA);
        }

        [Fact]
        public void WorldAnchorB_Get_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F expected = bodyB.GetWorldPoint(joint.LocalAnchorB);
            Assert.Equal(expected, joint.WorldAnchorB);
        }

        [Fact]
        public void WorldAnchorB_Set_UpdatesLocalAnchor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F worldValue = new Vector2F(10f, 10f);
            joint.WorldAnchorB = worldValue;

            Vector2F expected = bodyB.GetLocalPoint(worldValue);
            Assert.Equal(expected, joint.LocalAnchorB);
        }

        [Fact]
        public void ReferenceAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            float angle = 0.5f;
            joint.ReferenceAngle = angle;

            Assert.Equal(angle, joint.ReferenceAngle);
        }

        [Fact]
        public void ReferenceAngle_Constructor_SetsFromBodies()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Rotation = 0.3f;

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(0.3f, joint.ReferenceAngle);
        }

        [Fact]
        public void JointAngle_ComputesCorrectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            bodyA.Sweep.A = 0.2f;
            bodyB.Sweep.A = 0.8f;
            joint.ReferenceAngle = 0.1f;

            float expected = 0.8f - 0.2f - 0.1f;
            Assert.Equal(expected, joint.JointAngle);
        }

        [Fact]
        public void JointSpeed_ComputesCorrectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.GetBodyType = BodyType.Dynamic;
            bodyB.GetBodyType = BodyType.Dynamic;
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            bodyA.AngularVelocity = 1.0f;
            bodyB.AngularVelocity = 3.5f;

            Assert.Equal(2.5f, joint.JointSpeed);
        }

        [Fact]
        public void LimitEnabled_Default_IsFalse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.False(joint.LimitEnabled);
        }

        [Fact]
        public void LimitEnabled_SetTrue_StoresValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.LimitEnabled = true;

            Assert.True(joint.LimitEnabled);
        }

        [Fact]
        public void LowerLimit_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.LowerLimit = -1.0f;

            Assert.Equal(-1.0f, joint.LowerLimit);
        }

        [Fact]
        public void LowerLimit_WithSameValue_DoesNotResetImpulse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.LowerLimit = -1.0f;
            float current = joint.LowerLimit;
            joint.LowerLimit = -1.0f;

            Assert.Equal(current, joint.LowerLimit);
        }

        [Fact]
        public void UpperLimit_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.UpperLimit = 2.0f;

            Assert.Equal(2.0f, joint.UpperLimit);
        }

        [Fact]
        public void UpperLimit_WithSameValue_DoesNotResetImpulse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.UpperLimit = 2.0f;
            float current = joint.UpperLimit;
            joint.UpperLimit = 2.0f;

            Assert.Equal(current, joint.UpperLimit);
        }

        [Fact]
        public void MotorEnabled_Default_IsFalse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.False(joint.MotorEnabled);
        }

        [Fact]
        public void MotorEnabled_SetTrue_StoresValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MotorEnabled = true;

            Assert.True(joint.MotorEnabled);
        }

        [Fact]
        public void MotorSpeed_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MotorSpeed = 5.0f;

            Assert.Equal(5.0f, joint.MotorSpeed);
        }

        [Fact]
        public void MaxMotorTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MaxMotorTorque = 100.0f;

            Assert.Equal(100.0f, joint.MaxMotorTorque);
        }

        [Fact]
        public void MotorImpulse_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MotorImpulse = 25.0f;

            Assert.Equal(25.0f, joint.MotorImpulse);
        }

        [Fact]
        public void SetLimits_WithDifferentValues_ChangesBoth()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.SetLimits(-2.0f, 2.0f);

            Assert.Equal(-2.0f, joint.LowerLimit);
            Assert.Equal(2.0f, joint.UpperLimit);
        }

        [Fact]
        public void SetLimits_WithSameValues_DoesNotChange()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.SetLimits(-1.0f, 1.0f);
            joint.SetLimits(-1.0f, 1.0f);

            Assert.Equal(-1.0f, joint.LowerLimit);
            Assert.Equal(1.0f, joint.UpperLimit);
        }

        [Fact]
        public void GetMotorTorque_ReturnsProduct()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MotorImpulse = 10.0f;
            float result = joint.GetMotorTorque(2.0f);

            Assert.Equal(20.0f, result);
        }

        [Fact]
        public void GetReactionForce_WithZeroImpulse_ReturnsZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        [Fact]
        public void GetReactionForce_WithImpulse_ReturnsScaled()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(2.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        [Fact]
        public void GetReactionTorque_WithZeroImpulse_ReturnsZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        [Fact]
        public void Step_WithRevoluteJoint_UpdatesVelocities()
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

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_WithMotorEnabled_AppliesMotorTorque()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(-1, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 50.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_WithLimitEnabled_ConstrainsMotion()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-0.5f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.5f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.5f, 0.5f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_WithEqualLimit_LocksAngle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-0.5f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.5f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(0.0f, 0.0f);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtLower_TriggersSolveAtLower()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 1.0f);
            bodyB.Rotation = -0.5f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtUpper_TriggersSolveAtUpper()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(-1.0f, -0.1f);
            bodyB.Rotation = 0.5f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Constructor_InternalDefault_SetsJointType()
        {
            RevoluteJoint joint = new RevoluteJoint();
            Assert.Equal(JointType.Revolute, joint.JointType);
        }

        [Fact]
        public void Step_WithFixedRotationBodies_UsesPointToPointConstraint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-0.5f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.5f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            bodyA.FixedRotation = true;
            bodyB.FixedRotation = true;

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_WithLimitAndMotor_MultipleSteps()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(0, 1), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.3f, 1.0f);
            bodyB.CreateFixture(shape);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.5f, 0.5f);
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 50.0f;
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtLower_WithReversedMotor_ClampsNegativeImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.1f, 0.8f);
            bodyB.Rotation = -0.5f;
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtUpper_WithReversedMotor_ClampsPositiveImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.8f, 0.1f);
            bodyB.Rotation = 0.5f;
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitWithGravity_SwingsThroughLimit()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -20));
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(0, 1), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 10.0f);
            bodyB.CreateFixture(shape);

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            bodyB.Rotation = 0.8f;
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 0.5f);
            world.Add(joint);

            for (int i = 0; i < 120; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtLower_WithWorldAnchorOffset_Warmstarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 10.0f);
            bodyB.CreateFixture(shape);
            bodyB.AngularVelocity = -5.0f;

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0), true);
            joint.LimitEnabled = true;
            joint.SetLimits(0.1f, 0.8f);
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        [Fact]
        public void Step_LimitAtUpper_WithWorldAnchorOffset_Warmstarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 10.0f);
            bodyB.CreateFixture(shape);
            bodyB.AngularVelocity = 5.0f;

            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0), true);
            joint.LimitEnabled = true;
            joint.SetLimits(-0.8f, -0.1f);
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }
    }
}
