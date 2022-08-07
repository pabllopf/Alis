using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The buoyancy controller def tests class
    /// </summary>
    public class BuoyancyControllerDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BuoyancyControllerDefTests"/> class
        /// </summary>
        public BuoyancyControllerDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the buoyancy controller def
        /// </summary>
        /// <returns>The buoyancy controller def</returns>
        private BuoyancyControllerDef CreateBuoyancyControllerDef()
        {
            return new BuoyancyControllerDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var buoyancyControllerDef = CreateBuoyancyControllerDef();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
