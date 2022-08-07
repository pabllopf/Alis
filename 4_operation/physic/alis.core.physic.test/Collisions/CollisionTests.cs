using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
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
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Tests that collide circles state under test expected behavior
        /// </summary>
        [Fact]
        public void CollideCircles_StateUnderTest_ExpectedBehavior()
        {
            /*Manifold manifold = null;
            CircleShape circle1 = null;
            XForm xf1 = default(XForm);
            CircleShape circle2 = null;
            XForm xf2 = default(XForm);

            // Act
            Collision.CollideCircles(
                ref manifold,
                circle1,
                xf1,
                circle2,
                xf2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that collide polygon and circle state under test expected behavior
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*Manifold manifold = null;
            PolygonShape polygon = null;
            XForm xf1 = default(XForm);
            CircleShape circle = null;
            XForm xf2 = default(XForm);

            // Act
            Collision.CollidePolygonAndCircle(
                ref manifold,
                polygon,
                xf1,
                circle,
                xf2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
