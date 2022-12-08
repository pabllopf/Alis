using Alis.Builder.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Entity
{
    /// <summary>
    /// The transform builder tests class
    /// </summary>
    public class TransformBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="TransformBuilderTests"/> class
        /// </summary>
        public TransformBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the transform builder
        /// </summary>
        /// <returns>The transform builder</returns>
        private TransformBuilder CreateTransformBuilder()
        {
            return new TransformBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transformBuilder = this.CreateTransformBuilder();

            // Act
            var result = transformBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that position state under test expected behavior
        /// </summary>
        [Fact]
        public void Position_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transformBuilder = this.CreateTransformBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = transformBuilder.Position(
                x,
                y);

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
            var transformBuilder = this.CreateTransformBuilder();
            float angle = 0;

            // Act
            var result = transformBuilder.Rotation(
                angle);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that scale state under test expected behavior
        /// </summary>
        [Fact]
        public void Scale_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transformBuilder = this.CreateTransformBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = transformBuilder.Scale(
                x,
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
