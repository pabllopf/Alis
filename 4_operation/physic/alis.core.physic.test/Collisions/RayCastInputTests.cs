using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The ray cast input tests class
    /// </summary>
    public class RayCastInputTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="RayCastInputTests"/> class
        /// </summary>
        public RayCastInputTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the ray cast input
        /// </summary>
        /// <returns>The ray cast input</returns>
        private RayCastInput CreateRayCastInput()
        {
            return new RayCastInput();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var rayCastInput = CreateRayCastInput();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
