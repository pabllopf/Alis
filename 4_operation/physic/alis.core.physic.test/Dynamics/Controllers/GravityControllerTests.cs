using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Alis.Aspect.Time;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The gravity controller tests class
    /// </summary>
    public class GravityControllerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock gravity controller def
        /// </summary>
        private Mock<GravityControllerDef> mockGravityControllerDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="GravityControllerTests"/> class
        /// </summary>
        public GravityControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockGravityControllerDef = mockRepository.Create<GravityControllerDef>();
        }

        /// <summary>
        /// Creates the gravity controller
        /// </summary>
        /// <returns>The gravity controller</returns>
        private GravityController CreateGravityController()
        {
            return new GravityController(
                mockGravityControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gravityController = CreateGravityController();
            TimeStep step = default(Aspect.Time.TimeStep);

            // Act
            gravityController.Step(
                step);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
