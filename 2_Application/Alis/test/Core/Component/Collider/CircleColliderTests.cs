using Alis.Core.Component.Collider;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Collider
{
    /// <summary>
    /// The circle collider tests class
    /// </summary>
    public class CircleColliderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleColliderTests"/> class
        /// </summary>
        public CircleColliderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle collider
        /// </summary>
        /// <returns>The circle collider</returns>
        private CircleCollider CreateCircleCollider()
        {
            return new CircleCollider();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var circleCollider = this.CreateCircleCollider();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
