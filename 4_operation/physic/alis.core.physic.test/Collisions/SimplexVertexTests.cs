using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The simplex vertex tests class
    /// </summary>
    public class SimplexVertexTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SimplexVertexTests"/> class
        /// </summary>
        public SimplexVertexTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the simplex vertex
        /// </summary>
        /// <returns>The simplex vertex</returns>
        private SimplexVertex CreateSimplexVertex()
        {
            return new SimplexVertex();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var simplexVertex = CreateSimplexVertex();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
