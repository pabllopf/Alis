using Alis.Core.Component.Mesh;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Mesh
{
    /// <summary>
    /// The box mesh tests class
    /// </summary>
    public class BoxMeshTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BoxMeshTests"/> class
        /// </summary>
        public BoxMeshTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the box mesh
        /// </summary>
        /// <returns>The box mesh</returns>
        private BoxMesh CreateBoxMesh()
        {
            return new BoxMesh();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var boxMesh = this.CreateBoxMesh();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
