
using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The features tests class
    /// </summary>
    public class FeaturesTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="FeaturesTests"/> class
        /// </summary>
        public FeaturesTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the features
        /// </summary>
        /// <returns>The features</returns>
        private Features CreateFeatures()
        {
            return new Features();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var features = this.CreateFeatures();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
