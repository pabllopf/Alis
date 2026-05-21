

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the Vertex struct.
    /// </summary>
    public class VertexTest
    {
        /// <summary>
        ///     Tests the Vertex struct default initialization.
        /// </summary>
        [Fact]
        public void Vertex_DefaultInitialization_CreatesValidStruct()
        {
            Vertex vertex = new Vertex();

            Assert.Equal(0.0f, vertex.Position.X);
            Assert.Equal(0.0f, vertex.Position.Y);
        }
    }
}