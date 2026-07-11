// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class ShapeTest
    {
        [Fact]
        public void Shape_IsAbstract()
        {
            Assert.True(typeof(Shape).IsAbstract);
        }

        [Fact]
        public void Shape_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(Shape)));
        }

        [Fact]
        public void Shape_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(Shape)));
        }

        [Fact]
        public void Texture_TextureRect_Properties_Exist()
        {
            Assert.NotNull(typeof(Shape).GetProperty("Texture"));
            Assert.NotNull(typeof(Shape).GetProperty("TextureRect"));
        }

        [Fact]
        public void FillColor_OutlineColor_Properties_Exist()
        {
            Assert.NotNull(typeof(Shape).GetProperty("FillColor"));
            Assert.NotNull(typeof(Shape).GetProperty("OutlineColor"));
        }

        [Fact]
        public void OutlineThickness_Property_Exists()
        {
            Assert.NotNull(typeof(Shape).GetProperty("OutlineThickness"));
        }

        [Fact]
        public void GetPointCount_GetPoint_AreAbstract()
        {
            Assert.True(typeof(Shape).GetMethod("GetPointCount").IsAbstract);
            Assert.True(typeof(Shape).GetMethod("GetPoint").IsAbstract);
        }

        [Fact]
        public void GetLocalBounds_GetGlobalBounds_Methods_Exist()
        {
            Assert.NotNull(typeof(Shape).GetMethod("GetLocalBounds"));
            Assert.NotNull(typeof(Shape).GetMethod("GetGlobalBounds"));
        }
    }
}
