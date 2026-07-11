using System;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// The gl safe tests class
    /// </summary>
    public class GlSafeTests
    {
        /// <summary>
        /// Tests that gl is static
        /// </summary>
        [Fact]
        public void Gl_IsStaticClass()
        {
            Assert.True(typeof(Gl).IsAbstract && typeof(Gl).IsSealed);
        }

        /// <summary>
        /// Tests that vertex attrib pointer throws on negative index
        /// </summary>
        [Fact]
        public void VertexAttribPointer_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.VertexAttribPointer(-1, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that enable vertex attrib array throws on negative index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.EnableVertexAttribArray(-1));
        }
    }
}
