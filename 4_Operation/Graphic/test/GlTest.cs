

using System;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     The gl test class
    /// </summary>
    public class GlTest
    {
        /// <summary>
        ///     Tests that vertex attrib pointer throws argument out of range exception for negative index
        /// </summary>
        [Fact]
        public void VertexAttribPointer_ThrowsArgumentOutOfRangeExceptionForNegativeIndex()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Gl.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
        }


        /// <summary>
        ///     Tests that enable vertex attrib array throws argument out of range exception for negative index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_ThrowsArgumentOutOfRangeExceptionForNegativeIndex()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(index));
        }
    }
}