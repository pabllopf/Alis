#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    public class MacNativePlatformRemainingTests
    {
        [Fact]
        public void ShowWindow_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.ShowWindow();
        }

        [Fact]
        public void HideWindow_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.HideWindow();
        }

        [Fact]
        public void SetTitle_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.SetTitle("Test");
        }

        [Fact]
        public void SetSize_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.SetSize(800, 600);
        }

        [Fact]
        public void MakeContextCurrent_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.MakeContextCurrent();
        }

        [Fact]
        public void SwapBuffers_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.SwapBuffers();
        }

        [Fact]
        public void Cleanup_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.Cleanup();
        }

        [Fact]
        public void Initialize_WithIcon_ThrowsOnMissingFile()
        {
            var platform = new MacNativePlatform();
            bool result = platform.Initialize(800, 600, "Test", "/nonexistent/icon.bmp");
            Assert.False(result);
        }

        [Fact]
        public void GetWindowPositionX_WhenNotInitialized_Throws()
        {
            var platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => platform.GetWindowPositionX());
        }

        [Fact]
        public void GetWindowPositionY_WhenNotInitialized_Throws()
        {
            var platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => platform.GetWindowPositionY());
        }

        [Fact]
        public void GetWindowMetrics_WhenNotInitialized_Throws()
        {
            var platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() =>
                platform.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
        }

        [Fact]
        public void GetMousePositionInView_WhenNotInitialized_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GetMouseState_DoesNotThrow()
        {
            var platform = new MacNativePlatform();
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.NotNull(buttons);
            Assert.Equal(5, buttons.Length);
        }

        [Fact]
        public void IsKeyDown_KeyNotInSet_ReturnsFalse()
        {
            var platform = new MacNativePlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.LeftWindows));
            Assert.False(platform.IsKeyDown(ConsoleKey.F13));
        }

        [Fact]
        public void Initialize_ReturnsTrue_OnMacOS()
        {
            var platform = new MacNativePlatform();
            bool result = platform.Initialize(100, 100, "TestInit");
            Assert.True(result);
            platform.Cleanup();
        }
    }
}
#endif
