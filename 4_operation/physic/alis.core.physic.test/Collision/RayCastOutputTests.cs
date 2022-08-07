using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The ray cast output tests class
    /// </summary>
    public class RayCastOutputTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="RayCastOutputTests"/> class
        /// </summary>
        public RayCastOutputTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the ray cast output
        /// </summary>
        /// <returns>The ray cast output</returns>
        private RayCastOutput CreateRayCastOutput()
        {
            return new RayCastOutput();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var rayCastOutput = this.CreateRayCastOutput();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
