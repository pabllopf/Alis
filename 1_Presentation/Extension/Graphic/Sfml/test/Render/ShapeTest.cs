// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The shape test class
    /// </summary>
    public class ShapeTest
    {
        /// <summary>
        /// Tests that shape is abstract
        /// </summary>
        [Fact]
        public void Shape_IsAbstract()
        {
            Assert.True(typeof(Shape).IsAbstract);
        }

        /// <summary>
        /// Tests that shape is assignable from transformable
        /// </summary>
        [Fact]
        public void Shape_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(Shape)));
        }

        /// <summary>
        /// Tests that shape implements i drawable
        /// </summary>
        [Fact]
        public void Shape_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(Shape)));
        }

        /// <summary>
        /// Tests that texture texture rect properties exist
        /// </summary>
        [Fact]
        public void Texture_TextureRect_Properties_Exist()
        {
            Assert.NotNull(typeof(Shape).GetProperty("Texture"));
            Assert.NotNull(typeof(Shape).GetProperty("TextureRect"));
        }

        /// <summary>
        /// Tests that fill color outline color properties exist
        /// </summary>
        [Fact]
        public void FillColor_OutlineColor_Properties_Exist()
        {
            Assert.NotNull(typeof(Shape).GetProperty("FillColor"));
            Assert.NotNull(typeof(Shape).GetProperty("OutlineColor"));
        }

        /// <summary>
        /// Tests that outline thickness property exists
        /// </summary>
        [Fact]
        public void OutlineThickness_Property_Exists()
        {
            Assert.NotNull(typeof(Shape).GetProperty("OutlineThickness"));
        }

        /// <summary>
        /// Tests that get point count get point are abstract
        /// </summary>
        [Fact]
        public void GetPointCount_GetPoint_AreAbstract()
        {
            Assert.True(typeof(Shape).GetMethod("GetPointCount").IsAbstract);
            Assert.True(typeof(Shape).GetMethod("GetPoint").IsAbstract);
        }

        /// <summary>
        /// Tests that get local bounds get global bounds methods exist
        /// </summary>
        [Fact]
        public void GetLocalBounds_GetGlobalBounds_Methods_Exist()
        {
            Assert.NotNull(typeof(Shape).GetMethod("GetLocalBounds"));
            Assert.NotNull(typeof(Shape).GetMethod("GetGlobalBounds"));
        }
    }
}
