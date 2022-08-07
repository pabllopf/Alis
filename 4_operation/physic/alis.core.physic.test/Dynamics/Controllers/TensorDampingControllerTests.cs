using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    /// The tensor damping controller tests class
    /// </summary>
    public class TensorDampingControllerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="TensorDampingControllerTests"/> class
        /// </summary>
        public TensorDampingControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the tensor damping controller
        /// </summary>
        /// <returns>The tensor damping controller</returns>
        private TensorDampingController CreateTensorDampingController()
        {
            return new TensorDampingController();
        }

        /// <summary>
        /// Tests that set axis aligned state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAxisAligned_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var tensorDampingController = this.CreateTensorDampingController();
            float xDamping = 0;
            float yDamping = 0;

            // Act
            tensorDampingController.SetAxisAligned(
                xDamping,
                yDamping);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var tensorDampingController = this.CreateTensorDampingController();
            TimeStep step = default(global::Alis.Aspect.Time.TimeStep);

            // Act
            tensorDampingController.Step(
                step);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
