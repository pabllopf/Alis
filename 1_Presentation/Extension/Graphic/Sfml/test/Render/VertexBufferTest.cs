// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class VertexBufferTest
    {
        [Fact]
        public void VertexBuffer_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexBuffer)));
        }

        [Fact]
        public void VertexBuffer_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexBuffer)));
        }

        [Fact]
        public void UsageSpecifier_HasCorrectValues()
        {
            Assert.Equal(0, (int)VertexBuffer.UsageSpecifier.Stream);
            Assert.Equal(1, (int)VertexBuffer.UsageSpecifier.Dynamic);
            Assert.Equal(2, (int)VertexBuffer.UsageSpecifier.Static);
        }

        [Fact]
        public void Available_Property_Exists()
        {
            var prop = typeof(VertexBuffer).GetProperty("Available");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        [Fact]
        public void VertexCount_NativeHandle_Properties_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("VertexCount"));
            Assert.NotNull(typeof(VertexBuffer).GetProperty("NativeHandle"));
        }

        [Fact]
        public void PrimitiveType_Usage_Properties_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("PrimitiveType"));
            Assert.NotNull(typeof(VertexBuffer).GetProperty("Usage"));
        }

        [Fact]
        public void Update_Swap_Methods_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new[] { typeof(Vertex[]) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new[] { typeof(Vertex[]), typeof(uint) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new[] { typeof(Vertex[]), typeof(uint), typeof(uint) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new[] { typeof(VertexBuffer) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Swap"));
        }
    }
}
