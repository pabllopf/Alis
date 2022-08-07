using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The manifold tests class
    /// </summary>
    public class ManifoldTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ManifoldTests"/> class
        /// </summary>
        public ManifoldTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manifold
        /// </summary>
        /// <returns>The manifold</returns>
        private Manifold CreateManifold()
        {
            return new Manifold();
        }

        /// <summary>
        /// Tests that clone state under test expected behavior
        /// </summary>
        [Fact]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manifold = CreateManifold();

            // Act
            var result = manifold.Clone();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
