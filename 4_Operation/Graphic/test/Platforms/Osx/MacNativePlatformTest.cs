#if osxarm64 || osxarm || osxx64 || osx
using System;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Tests for MacNativePlatform default behavior without native initialization.
    /// </summary>
    public class MacNativePlatformTest
    {
        /// <summary>
        ///     Verifies that default state getters are safe before initialization.
        /// </summary>
        [Fact]
        public void MacNativePlatform_DefaultState_IsSafe()
        {
            MacNativePlatform platform = new MacNativePlatform();

            Assert.False(platform.IsWindowVisible());
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
            Assert.False(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal(string.Empty, chars);

            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0.0f, x, 5);
            Assert.Equal(0.0f, y, 5);
        }
    }
}
#endif
