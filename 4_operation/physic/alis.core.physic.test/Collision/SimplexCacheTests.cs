using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The simplex cache tests class
    /// </summary>
    public class SimplexCacheTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SimplexCacheTests"/> class
        /// </summary>
        public SimplexCacheTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the simplex cache
        /// </summary>
        /// <returns>The simplex cache</returns>
        private SimplexCache CreateSimplexCache()
        {
            return new SimplexCache();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var simplexCache = this.CreateSimplexCache();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
