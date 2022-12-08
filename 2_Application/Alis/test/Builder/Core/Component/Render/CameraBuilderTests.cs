using Alis.Builder.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Render
{
    /// <summary>
    /// The camera builder tests class
    /// </summary>
    public class CameraBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CameraBuilderTests"/> class
        /// </summary>
        public CameraBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the camera builder
        /// </summary>
        /// <returns>The camera builder</returns>
        private CameraBuilder CreateCameraBuilder()
        {
            return new CameraBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cameraBuilder = this.CreateCameraBuilder();

            // Act
            var result = cameraBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
