// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The vertex array test class
    /// </summary>
    public class VertexArrayTest
    {
        /// <summary>
        /// Tests that vertex array is assignable from object base
        /// </summary>
        [Fact]
        public void VertexArray_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexArray)));
        }

        /// <summary>
        /// Tests that vertex array implements i drawable
        /// </summary>
        [Fact]
        public void VertexArray_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexArray)));
        }

        /// <summary>
        /// Tests that vertex count property exists
        /// </summary>
        [Fact]
        public void VertexCount_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("VertexCount"));
        }

        /// <summary>
        /// Tests that primitive type property exists
        /// </summary>
        [Fact]
        public void PrimitiveType_Property_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("PrimitiveType");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that bounds property exists
        /// </summary>
        [Fact]
        public void Bounds_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("Bounds"));
        }

        /// <summary>
        /// Tests that indexer exists
        /// </summary>
        [Fact]
        public void Indexer_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("Item");
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that clear resize append methods exist
        /// </summary>
        [Fact]
        public void Clear_Resize_Append_Methods_Exist()
        {
            Assert.NotNull(typeof(VertexArray).GetMethod("Clear"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Resize"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Append"));
        }
    }
}
