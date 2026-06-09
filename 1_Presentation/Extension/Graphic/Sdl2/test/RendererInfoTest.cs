using System;
using System.Runtime.InteropServices;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The renderer info test class
    /// </summary>
    public class RendererInfoTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            RendererInfo info = new RendererInfo();
            Assert.Equal(IntPtr.Zero, info.Name);
            Assert.Equal(0u, info.flags);
            Assert.Equal(0u, info.num_texture_formats);
            Assert.Equal(0, info.maxTextureWidth);
            Assert.Equal(0, info.maxTextureHeight);
        }

        /// <summary>
        /// Tests that should assign name
        /// </summary>
        [Fact]
        public void ShouldAssignName()
        {
            RendererInfo info = new RendererInfo();
            info.Name = new IntPtr(0x1234);
            Assert.Equal(new IntPtr(0x1234), info.Name);
        }

        /// <summary>
        /// Tests that should get name from pointer
        /// </summary>
        [Fact]
        public void ShouldGetNameFromPointer()
        {
            RendererInfo info = new RendererInfo();
            string expected = "test_renderer";
            IntPtr ptr = Marshal.StringToHGlobalAnsi(expected);
            info.Name = ptr;
            try
            {
                string result = info.GetName();
                Assert.Equal(expected, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
