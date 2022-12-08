using Alis.Builder.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Light
{
    /// <summary>
    /// The point light builder tests class
    /// </summary>
    public class PointLightBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PointLightBuilderTests"/> class
        /// </summary>
        public PointLightBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the point light builder
        /// </summary>
        /// <returns>The point light builder</returns>
        private PointLightBuilder CreatePointLightBuilder()
        {
            return new PointLightBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var pointLightBuilder = this.CreatePointLightBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
