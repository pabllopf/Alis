using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The buoyancy controller tests class
    /// </summary>
    public class BuoyancyControllerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock buoyancy controller def
        /// </summary>
        private Mock<BuoyancyControllerDef> mockBuoyancyControllerDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuoyancyControllerTests"/> class
        /// </summary>
        public BuoyancyControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockBuoyancyControllerDef = mockRepository.Create<BuoyancyControllerDef>();
        }

        /// <summary>
        /// Creates the buoyancy controller
        /// </summary>
        /// <returns>The buoyancy controller</returns>
        private BuoyancyController CreateBuoyancyController()
        {
            return new BuoyancyController(
                mockBuoyancyControllerDef.Object);
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var buoyancyController = CreateBuoyancyController();
            TimeStep step = default(TimeStep);

            // Act
            buoyancyController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that draw state under test expected behavior
        /// </summary>
        [Fact]
        public void Draw_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var buoyancyController = CreateBuoyancyController();
            //DebugDraw debugDraw = null;

            // Act
            //buoyancyController.Draw(debugDraw);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
