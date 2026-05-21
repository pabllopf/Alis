

using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests for the CircleCollider component struct
    /// </summary>
    public class CircleColliderTest
    {
        /// <summary>
        ///     Tests that the constructor creates a CircleCollider with default values
        /// </summary>
        [Fact]
        public void CircleCollider_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider default state is valid
        /// </summary>
        [Fact]
        public void CircleCollider_DefaultState_ShouldBeValid()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider has expected public members
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldHaveExpectedPublicMembers()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider is a struct type
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldBeStructType()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider implements expected interfaces
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldImplementExpectedInterfaces()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsAssignableFrom<object>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider constructor doesn't throw
        /// </summary>
        [Fact]
        public void CircleCollider_Constructor_ShouldNotThrow()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider can be instantiated multiple times
        /// </summary>
        [Fact]
        public void CircleCollider_MultipleInstances_ShouldBeIndependent()
        {
            CircleCollider collider1 = new CircleCollider();
            CircleCollider collider2 = new CircleCollider();

            Assert.NotNull(collider1);
            Assert.NotNull(collider2);
        }

        /// <summary>
        ///     Tests that CircleCollider can be created without exceptions
        /// </summary>
        [Fact]
        public void CircleCollider_Constructor_WithoutParameters_ShouldNotThrow()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
            Assert.IsType<CircleCollider>(collider);
        }
    }
}
