using System;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class DisplayModeTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var mode = new DisplayMode();
            Assert.Equal(0u, mode.format);
            Assert.Equal(0, mode.w);
            Assert.Equal(0, mode.h);
            Assert.Equal(0, mode.refresh_rate);
            Assert.Equal(IntPtr.Zero, mode.DriverData);
        }
    }
}
