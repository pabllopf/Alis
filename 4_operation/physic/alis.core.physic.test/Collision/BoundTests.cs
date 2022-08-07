using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The bound tests class
    /// </summary>
    public class BoundTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BoundTests"/> class
        /// </summary>
        public BoundTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the bound
        /// </summary>
        /// <returns>The bound</returns>
        private Bound CreateBound()
        {
            return new Bound();
        }

        /// <summary>
        /// Tests that clone state under test expected behavior
        /// </summary>
        [Fact]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bound = this.CreateBound();

            // Act
            var result = bound.Clone();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
