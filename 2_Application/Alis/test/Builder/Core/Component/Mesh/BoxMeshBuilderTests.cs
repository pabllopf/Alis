using Alis.Builder.Core.Component.Mesh;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Mesh
{
    /// <summary>
    /// The box mesh builder tests class
    /// </summary>
    public class BoxMeshBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BoxMeshBuilderTests"/> class
        /// </summary>
        public BoxMeshBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the box mesh builder
        /// </summary>
        /// <returns>The box mesh builder</returns>
        private BoxMeshBuilder CreateBoxMeshBuilder()
        {
            return new BoxMeshBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var boxMeshBuilder = this.CreateBoxMeshBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
