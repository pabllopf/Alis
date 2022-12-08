using Alis.Core.Component.Mesh;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Mesh
{
    /// <summary>
    /// The circle mesh tests class
    /// </summary>
    public class CircleMeshTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleMeshTests"/> class
        /// </summary>
        public CircleMeshTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle mesh
        /// </summary>
        /// <returns>The circle mesh</returns>
        private CircleMesh CreateCircleMesh()
        {
            return new CircleMesh();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var circleMesh = this.CreateCircleMesh();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
