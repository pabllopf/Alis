using Alis.Builder.Core.Manager;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Manager
{
    /// <summary>
    /// The manager base builder tests class
    /// </summary>
    public class ManagerBaseBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerBaseBuilderTests"/> class
        /// </summary>
        public ManagerBaseBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager base builder
        /// </summary>
        /// <returns>The manager base builder</returns>
        private ManagerBaseBuilder CreateManagerBaseBuilder()
        {
            return new ManagerBaseBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var managerBaseBuilder = this.CreateManagerBaseBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
