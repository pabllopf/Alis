using Alis.Builder.Core.Component.Body;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Body
{
    /// <summary>
    /// The rigid body builder tests class
    /// </summary>
    public class RigidBodyBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="RigidBodyBuilderTests"/> class
        /// </summary>
        public RigidBodyBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the rigid body builder
        /// </summary>
        /// <returns>The rigid body builder</returns>
        private RigidBodyBuilder CreateRigidBodyBuilder()
        {
            return new RigidBodyBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var rigidBodyBuilder = this.CreateRigidBodyBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
