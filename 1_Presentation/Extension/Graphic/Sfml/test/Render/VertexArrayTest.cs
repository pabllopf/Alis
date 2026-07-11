// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class VertexArrayTest
    {
        [Fact]
        public void VertexArray_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexArray)));
        }

        [Fact]
        public void VertexArray_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexArray)));
        }

        [Fact]
        public void VertexCount_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("VertexCount"));
        }

        [Fact]
        public void PrimitiveType_Property_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("PrimitiveType");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Bounds_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("Bounds"));
        }

        [Fact]
        public void Indexer_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("Item");
            Assert.NotNull(prop);
        }

        [Fact]
        public void Clear_Resize_Append_Methods_Exist()
        {
            Assert.NotNull(typeof(VertexArray).GetMethod("Clear"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Resize"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Append"));
        }
    }
}
