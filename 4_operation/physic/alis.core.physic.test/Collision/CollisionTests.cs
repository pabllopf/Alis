using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The collision tests class
    /// </summary>
    public class CollisionTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionTests"/> class
        /// </summary>
        public CollisionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the collision
        /// </summary>
        /// <returns>The collision</returns>
        private Collision CreateCollision()
        {
            return new Collision();
        }

        /// <summary>
        /// Tests that collide circles state under test expected behavior
        /// </summary>
        [Fact]
        public void CollideCircles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var collision = this.CreateCollision();
            Manifold manifold = null;
            CircleShape circle1 = null;
            XForm xf1 = default(global::Alis.Aspect.Math.XForm);
            CircleShape circle2 = null;
            XForm xf2 = default(global::Alis.Aspect.Math.XForm);

            // Act
            collision.CollideCircles(
                ref manifold,
                circle1,
                xf1,
                circle2,
                xf2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that collide polygon and circle state under test expected behavior
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var collision = this.CreateCollision();
            Manifold manifold = null;
            PolygonShape polygon = null;
            XForm xf1 = default(global::Alis.Aspect.Math.XForm);
            CircleShape circle = null;
            XForm xf2 = default(global::Alis.Aspect.Math.XForm);

            // Act
            collision.CollidePolygonAndCircle(
                ref manifold,
                polygon,
                xf1,
                circle,
                xf2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
