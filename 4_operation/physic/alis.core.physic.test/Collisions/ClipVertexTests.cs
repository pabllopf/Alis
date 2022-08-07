using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The clip vertex tests class
    /// </summary>
    public class ClipVertexTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ClipVertexTests"/> class
        /// </summary>
        public ClipVertexTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the clip vertex
        /// </summary>
        /// <returns>The clip vertex</returns>
        private ClipVertex CreateClipVertex()
        {
            return new ClipVertex();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var clipVertex = this.CreateClipVertex();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
