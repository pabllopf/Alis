using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The separation function tests class
    /// </summary>
    public class SeparationFunctionTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SeparationFunctionTests"/> class
        /// </summary>
        public SeparationFunctionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the separation function
        /// </summary>
        /// <returns>The separation function</returns>
        private SeparationFunction CreateSeparationFunction()
        {
            return new SeparationFunction();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var separationFunction = this.CreateSeparationFunction();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
