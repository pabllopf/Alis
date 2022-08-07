using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The manifold point tests class
    /// </summary>
    public class ManifoldPointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ManifoldPointTests"/> class
        /// </summary>
        public ManifoldPointTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manifold point
        /// </summary>
        /// <returns>The manifold point</returns>
        private ManifoldPoint CreateManifoldPoint()
        {
            return new ManifoldPoint();
        }

        /// <summary>
        /// Tests that clone state under test expected behavior
        /// </summary>
        [Fact]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manifoldPoint = this.CreateManifoldPoint();

            // Act
            var result = manifoldPoint.Clone();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
