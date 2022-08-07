using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockConstantAccelControllerDef = this.mockRepository.Create<ConstantAccelControllerDef>();
        }

        /// <summary>
        /// Creates the constant accel controller
        /// </summary>
        /// <returns>The constant accel controller</returns>
        private ConstantAccelController CreateConstantAccelController()
        {
            return new ConstantAccelController(
                this.mockConstantAccelControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var constantAccelController = this.CreateConstantAccelController();
            TimeStep step = default(global::Alis.Aspect.Time.TimeStep);

            // Act
            constantAccelController.Step(
                step);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
