using Alis.Core.Physic.Collision.Shapes;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    /// The mass data tests class
    /// </summary>
    public class MassDataTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="MassDataTests"/> class
        /// </summary>
        public MassDataTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the mass data
        /// </summary>
        /// <returns>The mass data</returns>
        private MassData CreateMassData()
        {
            return new MassData();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var massData = this.CreateMassData();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
