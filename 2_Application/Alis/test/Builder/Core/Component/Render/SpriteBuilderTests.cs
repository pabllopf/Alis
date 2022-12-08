using Alis.Builder.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Render
{
    /// <summary>
    /// The sprite builder tests class
    /// </summary>
    public class SpriteBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteBuilderTests"/> class
        /// </summary>
        public SpriteBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the sprite builder
        /// </summary>
        /// <returns>The sprite builder</returns>
        private SpriteBuilder CreateSpriteBuilder()
        {
            return new SpriteBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var spriteBuilder = this.CreateSpriteBuilder();

            // Act
            var result = spriteBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that depth state under test expected behavior
        /// </summary>
        [Fact]
        public void Depth_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var spriteBuilder = this.CreateSpriteBuilder();
            int value = 0;

            // Act
            var result = spriteBuilder.Depth(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set texture state under test expected behavior
        /// </summary>
        [Fact]
        public void SetTexture_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var spriteBuilder = this.CreateSpriteBuilder();
            string value = null;

            // Act
            var result = spriteBuilder.SetTexture(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
