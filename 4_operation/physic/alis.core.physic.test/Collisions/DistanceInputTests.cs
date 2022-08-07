using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The distance input tests class
    /// </summary>
    public class DistanceInputTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceInputTests"/> class
        /// </summary>
        public DistanceInputTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the distance input
        /// </summary>
        /// <returns>The distance input</returns>
        private DistanceInput CreateDistanceInput()
        {
            return new DistanceInput();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var distanceInput = CreateDistanceInput();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
