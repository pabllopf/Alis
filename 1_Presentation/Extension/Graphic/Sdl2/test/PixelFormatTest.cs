using System;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The pixel format test class
    /// </summary>
    public class PixelFormatTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            PixelFormat fmt = new PixelFormat();
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

        /// <summary>
        /// Tests that should assign palette
        /// </summary>
        [Fact]
        public void ShouldAssignPalette()
        {
            PixelFormat fmt = new PixelFormat();
            fmt.Palette = new IntPtr(0xFADE);
            Assert.Equal(new IntPtr(0xFADE), fmt.Palette);
        }

        /// <summary>
        /// Tests that should assign next
        /// </summary>
        [Fact]
        public void ShouldAssignNext()
        {
            PixelFormat fmt = new PixelFormat();
            fmt.Next = new IntPtr(0xBEEF);
            Assert.Equal(new IntPtr(0xBEEF), fmt.Next);
        }
    }
}
