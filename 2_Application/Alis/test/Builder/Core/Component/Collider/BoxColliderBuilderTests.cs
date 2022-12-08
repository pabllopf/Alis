using Alis.Builder.Core.Component.Collider;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Collider
{
    /// <summary>
    /// The box collider builder tests class
    /// </summary>
    public class BoxColliderBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BoxColliderBuilderTests"/> class
        /// </summary>
        public BoxColliderBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the box collider builder
        /// </summary>
        /// <returns>The box collider builder</returns>
        private BoxColliderBuilder CreateBoxColliderBuilder()
        {
            return new BoxColliderBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();

            // Act
            var result = boxColliderBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that size state under test expected behavior
        /// </summary>
        [Fact]
        public void Size_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = boxColliderBuilder.Size(
                x,
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that fixed rotation state under test expected behavior
        /// </summary>
        [Fact]
        public void FixedRotation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            bool value = false;

            // Act
            var result = boxColliderBuilder.FixedRotation(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that auto tilling state under test expected behavior
        /// </summary>
        [Fact]
        public void AutoTilling_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            bool value = false;

            // Act
            var result = boxColliderBuilder.AutoTilling(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that gravity scale state under test expected behavior
        /// </summary>
        [Fact]
        public void GravityScale_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float value = 0;

            // Act
            var result = boxColliderBuilder.GravityScale(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that mass state under test expected behavior
        /// </summary>
        [Fact]
        public void Mass_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float value = 0;

            // Act
            var result = boxColliderBuilder.Mass(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that friction state under test expected behavior
        /// </summary>
        [Fact]
        public void Friction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float value = 0;

            // Act
            var result = boxColliderBuilder.Friction(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that density state under test expected behavior
        /// </summary>
        [Fact]
        public void Density_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float value = 0;

            // Act
            var result = boxColliderBuilder.Density(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that rotation state under test expected behavior
        /// </summary>
        [Fact]
        public void Rotation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float angle = 0;

            // Act
            var result = boxColliderBuilder.Rotation(
                angle);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that relative position state under test expected behavior
        /// </summary>
        [Fact]
        public void RelativePosition_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = boxColliderBuilder.RelativePosition(
                x,
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that restitution state under test expected behavior
        /// </summary>
        [Fact]
        public void Restitution_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float value = 0;

            // Act
            var result = boxColliderBuilder.Restitution(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is trigger state under test expected behavior
        /// </summary>
        [Fact]
        public void IsTrigger_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();

            // Act
            var result = boxColliderBuilder.IsTrigger();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is trigger state under test expected behavior 1
        /// </summary>
        [Fact]
        public void IsTrigger_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            bool value = false;

            // Act
            var result = boxColliderBuilder.IsTrigger(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is active state under test expected behavior
        /// </summary>
        [Fact]
        public void IsActive_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            bool value = false;

            // Act
            var result = boxColliderBuilder.IsActive(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that linear velocity state under test expected behavior
        /// </summary>
        [Fact]
        public void LinearVelocity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = boxColliderBuilder.LinearVelocity(
                x,
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that body type state under test expected behavior
        /// </summary>
        [Fact]
        public void BodyType_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxColliderBuilder = this.CreateBoxColliderBuilder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
