using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The controller edge tests class
    /// </summary>
    public class ControllerEdgeTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerEdgeTests"/> class
        /// </summary>
        public ControllerEdgeTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the controller edge
        /// </summary>
        /// <returns>The controller edge</returns>
        private ControllerEdge CreateControllerEdge()
        {
            return new ControllerEdge();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var controllerEdge = CreateControllerEdge();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
