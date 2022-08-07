using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            var manifold = this.CreateManifold();

            // Act
            var result = manifold.Clone();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
