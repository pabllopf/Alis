using Alis.Builder.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Render
{
    /// <summary>
    /// The frame builder tests class
    /// </summary>
    public class FrameBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="FrameBuilderTests"/> class
        /// </summary>
        public FrameBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the frame builder
        /// </summary>
        /// <returns>The frame builder</returns>
        private FrameBuilder CreateFrameBuilder()
        {
            return new FrameBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var frameBuilder = this.CreateFrameBuilder();

            // Act
            var result = frameBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that file path state under test expected behavior
        /// </summary>
        [Fact]
        public void FilePath_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var frameBuilder = this.CreateFrameBuilder();
            string value = null;

            // Act
            var result = frameBuilder.FilePath(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
