using Alis.Builder.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Light
{
    /// <summary>
    /// The spot light builder tests class
    /// </summary>
    public class SpotLightBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SpotLightBuilderTests"/> class
        /// </summary>
        public SpotLightBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the spot light builder
        /// </summary>
        /// <returns>The spot light builder</returns>
        private SpotLightBuilder CreateSpotLightBuilder()
        {
            return new SpotLightBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var spotLightBuilder = this.CreateSpotLightBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
