using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    public class ShapeTest
    {
        [Fact]
        public void Shape_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Collisions.Shapes.Shape));
        }
    }
}

