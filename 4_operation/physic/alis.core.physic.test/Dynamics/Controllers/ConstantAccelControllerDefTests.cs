using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The constant accel controller def tests class
    /// </summary>
    public class ConstantAccelControllerDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantAccelControllerDefTests"/> class
        /// </summary>
        public ConstantAccelControllerDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the constant accel controller def
        /// </summary>
        /// <returns>The constant accel controller def</returns>
        private ConstantAccelControllerDef CreateConstantAccelControllerDef()
        {
            return new ConstantAccelControllerDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var constantAccelControllerDef = CreateConstantAccelControllerDef();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
