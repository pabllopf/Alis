using Alis.Builder.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Light
{
    /// <summary>
    /// The area light builder tests class
    /// </summary>
    public class AreaLightBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AreaLightBuilderTests"/> class
        /// </summary>
        public AreaLightBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the area light builder
        /// </summary>
        /// <returns>The area light builder</returns>
        private AreaLightBuilder CreateAreaLightBuilder()
        {
            return new AreaLightBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var areaLightBuilder = this.CreateAreaLightBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
