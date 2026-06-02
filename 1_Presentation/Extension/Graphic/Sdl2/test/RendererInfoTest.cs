using System;
using System.Runtime.InteropServices;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class RendererInfoTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var info = new RendererInfo();
            Assert.Equal(IntPtr.Zero, info.Name);
            Assert.Equal(0u, info.flags);
            Assert.Equal(0u, info.num_texture_formats);
            Assert.Equal(0, info.maxTextureWidth);
            Assert.Equal(0, info.maxTextureHeight);
        }
    }
}
