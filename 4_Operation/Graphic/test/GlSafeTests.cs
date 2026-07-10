using System;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public class GlSafeTests
    {
        [Fact]
        public void Gl_IsStaticClass()
        {
            Assert.True(typeof(Gl).IsAbstract && typeof(Gl).IsSealed);
        }

        [Fact]
        public void VertexAttribPointer_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.VertexAttribPointer(-1, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
        }

        [Fact]
        public void EnableVertexAttribArray_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.EnableVertexAttribArray(-1));
        }
    }
}
