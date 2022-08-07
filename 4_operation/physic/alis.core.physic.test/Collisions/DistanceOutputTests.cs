using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The distance output tests class
    /// </summary>
    public class DistanceOutputTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceOutputTests"/> class
        /// </summary>
        public DistanceOutputTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the distance output
        /// </summary>
        /// <returns>The distance output</returns>
        private DistanceOutput CreateDistanceOutput()
        {
            return new DistanceOutput();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var distanceOutput = this.CreateDistanceOutput();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
