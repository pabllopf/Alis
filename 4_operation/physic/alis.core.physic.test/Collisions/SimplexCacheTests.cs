using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
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
            mockRepository = new MockRepository(MockBehavior.Strict);


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
            var simplexCache = CreateSimplexCache();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
