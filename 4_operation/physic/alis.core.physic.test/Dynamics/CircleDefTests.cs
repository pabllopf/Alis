using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The circle def tests class
    /// </summary>
    public class CircleDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleDefTests"/> class
        /// </summary>
        public CircleDefTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle def
        /// </summary>
        /// <returns>The circle def</returns>
        private CircleDef CreateCircleDef()
        {
            return new CircleDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var circleDef = this.CreateCircleDef();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
