// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The vertex buffer test class
    /// </summary>
    public class VertexBufferTest
    {
        /// <summary>
        /// Tests that vertex buffer is assignable from object base
        /// </summary>
        [Fact]
        public void VertexBuffer_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexBuffer)));
        }

        /// <summary>
        /// Tests that vertex buffer implements i drawable
        /// </summary>
        [Fact]
        public void VertexBuffer_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexBuffer)));
        }

        /// <summary>
        /// Tests that usage specifier has correct values
        /// </summary>
        [Fact]
        public void UsageSpecifier_HasCorrectValues()
        {
            Assert.Equal(0, (int)VertexBuffer.UsageSpecifier.Stream);
            Assert.Equal(1, (int)VertexBuffer.UsageSpecifier.Dynamic);
            Assert.Equal(2, (int)VertexBuffer.UsageSpecifier.Static);
        }

        /// <summary>
        /// Tests that available property exists
        /// </summary>
        [Fact]
        public void Available_Property_Exists()
        {
            var prop = typeof(VertexBuffer).GetProperty("Available");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that vertex count native handle properties exist
        /// </summary>
        [Fact]
        public void VertexCount_NativeHandle_Properties_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("VertexCount"));
            Assert.NotNull(typeof(VertexBuffer).GetProperty("NativeHandle"));
        }

        /// <summary>
        /// Tests that primitive type usage properties exist
        /// </summary>
        [Fact]
        public void PrimitiveType_Usage_Properties_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("PrimitiveType"));
            Assert.NotNull(typeof(VertexBuffer).GetProperty("Usage"));
        }

        /// <summary>
        /// Tests that update swap methods exist
        /// </summary>
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
