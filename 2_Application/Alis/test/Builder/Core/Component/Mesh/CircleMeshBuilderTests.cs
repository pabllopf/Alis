using Alis.Builder.Core.Component.Mesh;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Mesh
{
    /// <summary>
    /// The circle mesh builder tests class
    /// </summary>
    public class CircleMeshBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleMeshBuilderTests"/> class
        /// </summary>
        public CircleMeshBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle mesh builder
        /// </summary>
        /// <returns>The circle mesh builder</returns>
        private CircleMeshBuilder CreateCircleMeshBuilder()
        {
            return new CircleMeshBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var circleMeshBuilder = this.CreateCircleMeshBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
