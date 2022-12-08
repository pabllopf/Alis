using Alis.Builder.Core.Component.Collider;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Collider
{
    /// <summary>
    /// The circle collider builder tests class
    /// </summary>
    public class CircleColliderBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleColliderBuilderTests"/> class
        /// </summary>
        public CircleColliderBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle collider builder
        /// </summary>
        /// <returns>The circle collider builder</returns>
        private CircleColliderBuilder CreateCircleColliderBuilder()
        {
            return new CircleColliderBuilder();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var circleColliderBuilder = this.CreateCircleColliderBuilder();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
