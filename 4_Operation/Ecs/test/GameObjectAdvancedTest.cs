

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object advanced test class
    /// </summary>
    /// <remarks>
    ///     Tests advanced GameObject functionality including lifecycle,
    ///     versioning, validity checking, and complex scenarios.
    /// </remarks>
    public class GameObjectAdvancedTest
    {
        /// <summary>
        ///     Tests game object equality comparison
        /// </summary>
        /// <remarks>
        ///     Validates that the same GameObject instance equals itself.
        /// </remarks>
        [Fact]
        public void GameObject_EqualityComparison()
        {
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = e1;

            Assert.True(e1.Equals(e2));
            Assert.Equal(e1, e2);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests different game objects are not equal
        /// </summary>
        /// <remarks>
        ///     Verifies that different GameObject instances are not equal.
        /// </remarks>
        [Fact]
        public void GameObject_DifferentObjectsNotEqual()
        {
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            Assert.False(e1.Equals(e2));
            Assert.NotEqual(e1, e2);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests game object null comparison
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjects have proper null comparison behavior.
        /// </remarks>
        [Fact]
        public void GameObject_NullComparison()
        {
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.False(entity.Equals(null));

            scene.Dispose();
        }

        /// <summary>
        ///     Tests hash code consistency for game objects
        /// </summary>
        /// <remarks>
        ///     Validates that GetHashCode returns consistent values for the same entity.
        /// </remarks>
        [Fact]
        public void GameObject_HashCodeConsistency()
        {
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            int hash1 = entity.GetHashCode();
            int hash2 = entity.GetHashCode();

            Assert.Equal(hash1, hash2);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests different game objects have different hash codes
        /// </summary>
        /// <remarks>
        ///     Validates that different GameObjects produce different hash codes.
        /// </remarks>
        [Fact]
        public void GameObject_DifferentObjectsDifferentHashCodes()
        {
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            int hash1 = e1.GetHashCode();
            int hash2 = e2.GetHashCode();

            Assert.NotEqual(hash1, hash2);

            scene.Dispose();
        }
    }
}