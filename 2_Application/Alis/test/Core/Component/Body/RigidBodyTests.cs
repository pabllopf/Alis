using Alis.Core.Component.Body;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Body
{
    /// <summary>
    /// The rigid body tests class
    /// </summary>
    public class RigidBodyTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="RigidBodyTests"/> class
        /// </summary>
        public RigidBodyTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the rigid body
        /// </summary>
        /// <returns>The rigid body</returns>
        private RigidBody CreateRigidBody()
        {
            return new RigidBody();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rigidBody = this.CreateRigidBody();

            // Act
            var result = rigidBody.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
