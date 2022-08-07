using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The constant force controller tests class
    /// </summary>
    public class ConstantForceControllerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock constant force controller def
        /// </summary>
        private Mock<ConstantForceControllerDef> mockConstantForceControllerDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantForceControllerTests"/> class
        /// </summary>
        public ConstantForceControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockConstantForceControllerDef = this.mockRepository.Create<ConstantForceControllerDef>();
        }

        /// <summary>
        /// Creates the constant force controller
        /// </summary>
        /// <returns>The constant force controller</returns>
        private ConstantForceController CreateConstantForceController()
        {
            return new ConstantForceController(
                this.mockConstantForceControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var constantForceController = this.CreateConstantForceController();
            TimeStep step = default(global::Alis.Aspect.Time.TimeStep);

            // Act
            constantForceController.Step(
                step);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
