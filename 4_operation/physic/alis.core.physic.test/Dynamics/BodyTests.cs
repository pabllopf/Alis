using Alis.Core.Physic;
using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The body tests class
    /// </summary>
    public class BodyTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock world
        /// </summary>
        private Mock<World> mockWorld;

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyTests"/> class
        /// </summary>
        public BodyTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockWorld = mockRepository.Create<World>();
        }

        /// <summary>
        /// Creates the body
        /// </summary>
        /// <returns>The body</returns>
        private Body CreateBody()
        {
            return new Body(
                TODO,
                mockWorld.Object);
        }

        /// <summary>
        /// Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            body.Dispose();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that create fixture state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateFixture_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            FixtureDef def = null;

            // Act
            var result = body.CreateFixture(
                def);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy fixture state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyFixture_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Fixture fixture = null;

            // Act
            body.DestroyFixture(
                fixture);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set mass state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMass_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            MassData massData = default(global::Alis.Core.Physic.Collisions.Shapes.MassData);

            // Act
            body.SetMass(
                massData);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set mass from shapes state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMassFromShapes_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            body.SetMassFromShapes();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set x form state under test expected behavior
        /// </summary>
        [Fact]
        public void SetXForm_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 position = default(global::Alis.Aspect.Math.Vector2);
            float angle = 0;

            // Act
            var result = body.SetXForm(
                position,
                angle);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set x form state under test expected behavior 1
        /// </summary>
        [Fact]
        public void SetXForm_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var body = CreateBody();
            XForm xf = default(global::Alis.Aspect.Math.XForm);

            // Act
            var result = body.SetXForm(
                xf);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get x form state under test expected behavior
        /// </summary>
        [Fact]
        public void GetXForm_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetXForm();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set position state under test expected behavior
        /// </summary>
        [Fact]
        public void SetPosition_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 position = default(global::Alis.Aspect.Math.Vector2);

            // Act
            body.SetPosition(
                position);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set angle state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAngle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            float angle = 0;

            // Act
            body.SetAngle(
                angle);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get position state under test expected behavior
        /// </summary>
        [Fact]
        public void GetPosition_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetPosition();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get angle state under test expected behavior
        /// </summary>
        [Fact]
        public void GetAngle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetAngle();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get world center state under test expected behavior
        /// </summary>
        [Fact]
        public void GetWorldCenter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetWorldCenter();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get local center state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLocalCenter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetLocalCenter();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set linear velocity state under test expected behavior
        /// </summary>
        [Fact]
        public void SetLinearVelocity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 v = default(global::Alis.Aspect.Math.Vector2);

            // Act
            body.SetLinearVelocity(
                v);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get linear velocity state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLinearVelocity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetLinearVelocity();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set angular velocity state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAngularVelocity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            float w = 0;

            // Act
            body.SetAngularVelocity(
                w);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get angular velocity state under test expected behavior
        /// </summary>
        [Fact]
        public void GetAngularVelocity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetAngularVelocity();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that apply force state under test expected behavior
        /// </summary>
        [Fact]
        public void ApplyForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 force = default(global::Alis.Aspect.Math.Vector2);
            Vector2 point = default(global::Alis.Aspect.Math.Vector2);

            // Act
            body.ApplyForce(
                force,
                point);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that apply torque state under test expected behavior
        /// </summary>
        [Fact]
        public void ApplyTorque_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            float torque = 0;

            // Act
            body.ApplyTorque(
                torque);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that apply impulse state under test expected behavior
        /// </summary>
        [Fact]
        public void ApplyImpulse_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 impulse = default(global::Alis.Aspect.Math.Vector2);
            Vector2 point = default(global::Alis.Aspect.Math.Vector2);

            // Act
            body.ApplyImpulse(
                impulse,
                point);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get mass state under test expected behavior
        /// </summary>
        [Fact]
        public void GetMass_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetMass();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get inertia state under test expected behavior
        /// </summary>
        [Fact]
        public void GetInertia_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetInertia();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get mass data state under test expected behavior
        /// </summary>
        [Fact]
        public void GetMassData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetMassData();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get world point state under test expected behavior
        /// </summary>
        [Fact]
        public void GetWorldPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 localPoint = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetWorldPoint(
                localPoint);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get world vector state under test expected behavior
        /// </summary>
        [Fact]
        public void GetWorldVector_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 localVector = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetWorldVector(
                localVector);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get local point state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLocalPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 worldPoint = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetLocalPoint(
                worldPoint);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get local vector state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLocalVector_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 worldVector = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetLocalVector(
                worldVector);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get linear velocity from world point state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromWorldPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 worldPoint = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetLinearVelocityFromWorldPoint(
                worldPoint);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get linear velocity from local point state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromLocalPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            Vector2 localPoint = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = body.GetLinearVelocityFromLocalPoint(
                localPoint);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get linear damping state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLinearDamping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetLinearDamping();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set linear damping state under test expected behavior
        /// </summary>
        [Fact]
        public void SetLinearDamping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            float linearDamping = 0;

            // Act
            body.SetLinearDamping(
                linearDamping);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get angular damping state under test expected behavior
        /// </summary>
        [Fact]
        public void GetAngularDamping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetAngularDamping();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set angular damping state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAngularDamping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            float angularDamping = 0;

            // Act
            body.SetAngularDamping(
                angularDamping);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is bullet state under test expected behavior
        /// </summary>
        [Fact]
        public void IsBullet_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsBullet();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set bullet state under test expected behavior
        /// </summary>
        [Fact]
        public void SetBullet_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            bool flag = false;

            // Act
            body.SetBullet(
                flag);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is fixed rotation state under test expected behavior
        /// </summary>
        [Fact]
        public void IsFixedRotation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsFixedRotation();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set fixed rotation state under test expected behavior
        /// </summary>
        [Fact]
        public void SetFixedRotation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            bool fixedr = false;

            // Act
            body.SetFixedRotation(
                fixedr);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is static state under test expected behavior
        /// </summary>
        [Fact]
        public void IsStatic_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsStatic();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set static state under test expected behavior
        /// </summary>
        [Fact]
        public void SetStatic_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            body.SetStatic();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is dynamic state under test expected behavior
        /// </summary>
        [Fact]
        public void IsDynamic_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsDynamic();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is frozen state under test expected behavior
        /// </summary>
        [Fact]
        public void IsFrozen_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsFrozen();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is sleeping state under test expected behavior
        /// </summary>
        [Fact]
        public void IsSleeping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsSleeping();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is allow sleeping state under test expected behavior
        /// </summary>
        [Fact]
        public void IsAllowSleeping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.IsAllowSleeping();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that allow sleeping state under test expected behavior
        /// </summary>
        [Fact]
        public void AllowSleeping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            bool flag = false;

            // Act
            body.AllowSleeping(
                flag);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that wake up state under test expected behavior
        /// </summary>
        [Fact]
        public void WakeUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            body.WakeUp();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that put to sleep state under test expected behavior
        /// </summary>
        [Fact]
        public void PutToSleep_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            body.PutToSleep();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get fixture list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetFixtureList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetFixtureList();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get joint list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetJointList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetJointList();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get controller list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetControllerList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetControllerList();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get next state under test expected behavior
        /// </summary>
        [Fact]
        public void GetNext_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetNext();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get user data state under test expected behavior
        /// </summary>
        [Fact]
        public void GetUserData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetUserData();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set user data state under test expected behavior
        /// </summary>
        [Fact]
        public void SetUserData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();
            object data = null;

            // Act
            body.SetUserData(
                data);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get world state under test expected behavior
        /// </summary>
        [Fact]
        public void GetWorld_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var body = CreateBody();

            // Act
            var result = body.GetWorld();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
