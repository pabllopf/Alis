using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGravityControllerDef = this.mockRepository.Create<GravityControllerDef>();
        }

        /// <summary>
        /// Creates the gravity controller
        /// </summary>
        /// <returns>The gravity controller</returns>
        private GravityController CreateGravityController()
        {
            return new GravityController(
                this.mockGravityControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gravityController = this.CreateGravityController();
            TimeStep step = default(global::Alis.Aspect.Time.TimeStep);

            // Act
            gravityController.Step(
                step);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
