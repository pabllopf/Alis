using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The frame tests class
    /// </summary>
    public class FrameTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="FrameTests"/> class
        /// </summary>
        public FrameTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the frame
        /// </summary>
        /// <returns>The frame</returns>
        private Frame CreateFrame()
        {
            return new Frame();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var frame = this.CreateFrame();

            // Act
            var result = frame.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
