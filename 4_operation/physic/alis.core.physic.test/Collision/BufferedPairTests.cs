using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The buffered pair tests class
    /// </summary>
    public class BufferedPairTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BufferedPairTests"/> class
        /// </summary>
        public BufferedPairTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the buffered pair
        /// </summary>
        /// <returns>The buffered pair</returns>
        private BufferedPair CreateBufferedPair()
        {
            return new BufferedPair();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var bufferedPair = this.CreateBufferedPair();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
