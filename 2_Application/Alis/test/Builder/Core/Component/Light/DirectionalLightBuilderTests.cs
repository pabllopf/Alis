using Alis.Builder.Core.Component.Light;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Light
{
    /// <summary>
    /// The directional light builder tests class
    /// </summary>
    public class DirectionalLightBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DirectionalLightBuilderTests"/> class
        /// </summary>
        public DirectionalLightBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the directional light builder
        /// </summary>
        /// <returns>The directional light builder</returns>
        private DirectionalLightBuilder CreateDirectionalLightBuilder()
        {
            return new DirectionalLightBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var directionalLightBuilder = this.CreateDirectionalLightBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
