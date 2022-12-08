using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The image tests class
    /// </summary>
    public class ImageTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTests"/> class
        /// </summary>
        public ImageTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the image
        /// </summary>
        /// <returns>The image</returns>
        private Image CreateImage()
        {
            return new Image();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var image = this.CreateImage();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
