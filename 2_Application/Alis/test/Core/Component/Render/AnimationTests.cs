using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The animation tests class
    /// </summary>
    public class AnimationTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationTests"/> class
        /// </summary>
        public AnimationTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the animation
        /// </summary>
        /// <returns>The animation</returns>
        private Animation CreateAnimation()
        {
            return new Animation();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animation = this.CreateAnimation();

            // Act
            var result = animation.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that has next state under test expected behavior
        /// </summary>
        [Fact]
        public void HasNext_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animation = this.CreateAnimation();

            // Act
            var result = animation.HasNext();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that next texture state under test expected behavior
        /// </summary>
        [Fact]
        public void NextTexture_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animation = this.CreateAnimation();

            // Act
            var result = animation.NextTexture();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add frame state under test expected behavior
        /// </summary>
        [Fact]
        public void AddFrame_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animation = this.CreateAnimation();
            Frame frame = null;

            // Act
            animation.AddFrame(
                frame);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
