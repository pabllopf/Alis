using Alis.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Light
{
    /// <summary>
    /// The directional light tests class
    /// </summary>
    public class DirectionalLightTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DirectionalLightTests"/> class
        /// </summary>
        public DirectionalLightTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the directional light
        /// </summary>
        /// <returns>The directional light</returns>
        private DirectionalLight CreateDirectionalLight()
        {
            return new DirectionalLight();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var directionalLight = this.CreateDirectionalLight();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
