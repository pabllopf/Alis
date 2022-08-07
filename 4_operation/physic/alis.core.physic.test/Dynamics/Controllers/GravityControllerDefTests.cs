using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The gravity controller def tests class
    /// </summary>
    public class GravityControllerDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GravityControllerDefTests"/> class
        /// </summary>
        public GravityControllerDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the gravity controller def
        /// </summary>
        /// <returns>The gravity controller def</returns>
        private GravityControllerDef CreateGravityControllerDef()
        {
            return new GravityControllerDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var gravityControllerDef = CreateGravityControllerDef();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
