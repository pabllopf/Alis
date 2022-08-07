using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Alis.Aspect.Time;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The constant accel controller tests class
    /// </summary>
    public class ConstantAccelControllerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock constant accel controller def
        /// </summary>
        private Mock<ConstantAccelControllerDef> mockConstantAccelControllerDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantAccelControllerTests"/> class
        /// </summary>
        public ConstantAccelControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockConstantAccelControllerDef = mockRepository.Create<ConstantAccelControllerDef>();
        }

        /// <summary>
        /// Creates the constant accel controller
        /// </summary>
        /// <returns>The constant accel controller</returns>
        private ConstantAccelController CreateConstantAccelController()
        {
            return new ConstantAccelController(
                mockConstantAccelControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var constantAccelController = CreateConstantAccelController();
            TimeStep step = default(TimeStep);

            // Act
            constantAccelController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
