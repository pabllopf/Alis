using System;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The display mode test class
    /// </summary>
    public class DisplayModeTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            DisplayMode mode = new DisplayMode();
            Assert.Equal(0u, mode.format);
            Assert.Equal(0, mode.w);
            Assert.Equal(0, mode.h);
            Assert.Equal(0, mode.refresh_rate);
            Assert.Equal(IntPtr.Zero, mode.DriverData);
        }

        /// <summary>
        /// Tests that should assign and retrieve fields
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveFields()
        {
            DisplayMode mode = new DisplayMode
            {
                format = 123u,
                w = 1920,
                h = 1080,
                refresh_rate = 60,
                DriverData = new IntPtr(0xDEAD)
            };
            Assert.Equal(123u, mode.format);
            Assert.Equal(1920, mode.w);
            Assert.Equal(1080, mode.h);
            Assert.Equal(60, mode.refresh_rate);
            Assert.Equal(new IntPtr(0xDEAD), mode.DriverData);
        }
    }
}
