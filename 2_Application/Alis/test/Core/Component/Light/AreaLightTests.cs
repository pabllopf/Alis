using Alis.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Light
{
    /// <summary>
    /// The area light tests class
    /// </summary>
    public class AreaLightTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AreaLightTests"/> class
        /// </summary>
        public AreaLightTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the area light
        /// </summary>
        /// <returns>The area light</returns>
        private AreaLight CreateAreaLight()
        {
            return new AreaLight();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var areaLight = this.CreateAreaLight();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
