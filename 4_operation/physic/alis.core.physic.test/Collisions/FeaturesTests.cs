using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
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
            mockRepository = new MockRepository(MockBehavior.Strict);


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
            var features = CreateFeatures();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
