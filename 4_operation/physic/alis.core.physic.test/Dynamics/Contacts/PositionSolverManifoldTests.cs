using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The position solver manifold tests class
    /// </summary>
    public class PositionSolverManifoldTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PositionSolverManifoldTests"/> class
        /// </summary>
        public PositionSolverManifoldTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the position solver manifold
        /// </summary>
        /// <returns>The position solver manifold</returns>
        private PositionSolverManifold CreatePositionSolverManifold()
        {
            return new PositionSolverManifold();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var positionSolverManifold = CreatePositionSolverManifold();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
