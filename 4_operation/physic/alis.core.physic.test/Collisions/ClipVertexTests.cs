using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
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
            mockRepository = new MockRepository(MockBehavior.Strict);


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
            var clipVertex = CreateClipVertex();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
