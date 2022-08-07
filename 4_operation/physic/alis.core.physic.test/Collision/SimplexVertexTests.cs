using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            var simplexVertex = this.CreateSimplexVertex();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
