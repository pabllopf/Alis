using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The position tests class
    /// </summary>
    public class PositionTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PositionTests"/> class
        /// </summary>
        public PositionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the position
        /// </summary>
        /// <returns>The position</returns>
        private Position CreatePosition()
        {
            return new Position();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var position = this.CreatePosition();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
