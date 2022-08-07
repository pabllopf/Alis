using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The constant force controller def tests class
    /// </summary>
    public class ConstantForceControllerDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantForceControllerDefTests"/> class
        /// </summary>
        public ConstantForceControllerDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the constant force controller def
        /// </summary>
        /// <returns>The constant force controller def</returns>
        private ConstantForceControllerDef CreateConstantForceControllerDef()
        {
            return new ConstantForceControllerDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var constantForceControllerDef = CreateConstantForceControllerDef();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
