using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Alis.Aspect.Time;
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
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockConstantForceControllerDef = mockRepository.Create<ConstantForceControllerDef>();
        }

        /// <summary>
        /// Creates the constant force controller
        /// </summary>
        /// <returns>The constant force controller</returns>
        private ConstantForceController CreateConstantForceController()
        {
            return new ConstantForceController(
                mockConstantForceControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var constantForceController = CreateConstantForceController();
            TimeStep step = default(TimeStep);

            // Act
            constantForceController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
