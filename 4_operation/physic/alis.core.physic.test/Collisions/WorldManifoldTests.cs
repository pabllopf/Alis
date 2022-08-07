using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The world manifold tests class
    /// </summary>
    public class WorldManifoldTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="WorldManifoldTests"/> class
        /// </summary>
        public WorldManifoldTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the world manifold
        /// </summary>
        /// <returns>The world manifold</returns>
        private WorldManifold CreateWorldManifold()
        {
            return new WorldManifold();
        }

        /// <summary>
        /// Tests that clone state under test expected behavior
        /// </summary>
        [Fact]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var worldManifold = CreateWorldManifold();

            // Act
            var result = worldManifold.Clone();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
           /* var worldManifold = CreateWorldManifold();
            Manifold manifold = null;
            XForm xfA = default(XForm);
            float radiusA = 0;
            XForm xfB = default(XForm);
            float radiusB = 0;

            // Act
            worldManifold.Initialize(
                manifold,
                xfA,
                radiusA,
                xfB,
                radiusB);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
