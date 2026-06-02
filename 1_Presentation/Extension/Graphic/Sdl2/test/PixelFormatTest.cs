using System;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class PixelFormatTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var fmt = new PixelFormat();
            Assert.Equal(0u, fmt.format);
            Assert.Equal(IntPtr.Zero, fmt.Palette);
            Assert.Equal(0, fmt.BitsPerPixel);
            Assert.Equal(0, fmt.BytesPerPixel);
            Assert.Equal(0u, fmt.RMask);
            Assert.Equal(0u, fmt.GMask);
            Assert.Equal(0u, fmt.BMask);
            Assert.Equal(0u, fmt.AMask);
            Assert.Equal(0, fmt.refCount);
            Assert.Equal(IntPtr.Zero, fmt.Next);
        }
    }
}
