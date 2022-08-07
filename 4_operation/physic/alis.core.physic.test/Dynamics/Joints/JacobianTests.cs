using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The jacobian tests class
    /// </summary>
    public class JacobianTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="JacobianTests"/> class
        /// </summary>
        public JacobianTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the jacobian
        /// </summary>
        /// <returns>The jacobian</returns>
        private Jacobian CreateJacobian()
        {
            return new Jacobian();
        }

        /// <summary>
        /// Tests that set zero state under test expected behavior
        /// </summary>
        [Fact]
        public void SetZero_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jacobian = this.CreateJacobian();

            // Act
            jacobian.SetZero();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set state under test expected behavior
        /// </summary>
        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jacobian = this.CreateJacobian();
            Vector2 x1 = default(global::Alis.Aspect.Math.Vector2);
            float a1 = 0;
            Vector2 x2 = default(global::Alis.Aspect.Math.Vector2);
            float a2 = 0;

            // Act
            jacobian.Set(
                x1,
                a1,
                x2,
                a2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute state under test expected behavior
        /// </summary>
        [Fact]
        public void Compute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jacobian = this.CreateJacobian();
            Vector2 x1 = default(global::Alis.Aspect.Math.Vector2);
            float a1 = 0;
            Vector2 x2 = default(global::Alis.Aspect.Math.Vector2);
            float a2 = 0;

            // Act
            var result = jacobian.Compute(
                x1,
                a1,
                x2,
                a2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
