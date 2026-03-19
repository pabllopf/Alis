using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The shape test class
    /// </summary>
    public class ShapeTest
    {
        /// <summary>
        /// Tests that shape type should be accessible
        /// </summary>
        [Fact]
        public void Shape_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Collisions.Shapes.Shape));
        }
    }
}

