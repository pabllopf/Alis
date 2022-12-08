using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The camera tests class
    /// </summary>
    public class CameraTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CameraTests"/> class
        /// </summary>
        public CameraTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the camera
        /// </summary>
        /// <returns>The camera</returns>
        private Camera CreateCamera()
        {
            return new Camera();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var camera = this.CreateCamera();

            // Act
            var result = camera.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that start state under test expected behavior
        /// </summary>
        [Fact]
        public void Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var camera = this.CreateCamera();

            // Act
            camera.Start();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that before update state under test expected behavior
        /// </summary>
        [Fact]
        public void BeforeUpdate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var camera = this.CreateCamera();

            // Act
            camera.BeforeUpdate();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that update state under test expected behavior
        /// </summary>
        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var camera = this.CreateCamera();

            // Act
            camera.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
