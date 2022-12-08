using Alis.Builder.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Render
{
    /// <summary>
    /// The animation builder tests class
    /// </summary>
    public class AnimationBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationBuilderTests"/> class
        /// </summary>
        public AnimationBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the animation builder
        /// </summary>
        /// <returns>The animation builder</returns>
        private AnimationBuilder CreateAnimationBuilder()
        {
            return new AnimationBuilder();
        }

        /// <summary>
        /// Tests that add frame state under test expected behavior
        /// </summary>
        [Fact]
        public void AddFrame_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animationBuilder = this.CreateAnimationBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animationBuilder = this.CreateAnimationBuilder();

            // Act
            var result = animationBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that name state under test expected behavior
        /// </summary>
        [Fact]
        public void Name_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animationBuilder = this.CreateAnimationBuilder();
            string value = null;

            // Act
            var result = animationBuilder.Name(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that order state under test expected behavior
        /// </summary>
        [Fact]
        public void Order_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animationBuilder = this.CreateAnimationBuilder();
            int value = 0;

            // Act
            var result = animationBuilder.Order(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that speed state under test expected behavior
        /// </summary>
        [Fact]
        public void Speed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animationBuilder = this.CreateAnimationBuilder();
            float value = 0;

            // Act
            var result = animationBuilder.Speed(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
