using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
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
            mockRepository = new MockRepository(MockBehavior.Strict);


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
            var rayCastOutput = CreateRayCastOutput();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
