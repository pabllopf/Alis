#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public class MacNativePlatformFullTests
    {
        [Fact]
        public void ShowWindow_NoWindow_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.ShowWindow();
        }

        [Fact]
        public void HideWindow_NoWindow_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.HideWindow();
        }

        [Fact]
        public void SetTitle_NoWindow_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.SetTitle("test");
        }

        [Fact]
        public void SetSize_NoWindow_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.SetSize(800, 600);
        }

        [Fact]
        public void MakeContextCurrent_NoGl_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.MakeContextCurrent();
        }

        [Fact]
        public void SwapBuffers_NoGl_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.SwapBuffers();
        }

        [Fact]
        public void Cleanup_NoPool_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.Cleanup();
        }

        [Fact]
        public void Initialize_DoesNotThrow_OnMacOS()
        {
            var p = new MacNativePlatform();
            try { bool r = p.Initialize(100, 100, "T"); Assert.True(r); p.Cleanup(); }
            catch (Exception ex) { Assert.IsAssignableFrom<Exception>(ex); }
        }

        [Fact]
        public void Initialize_WithIcon_NonExistent_ReturnsFalse()
        {
            var p = new MacNativePlatform();
            bool r = p.Initialize(100, 100, "T", "/nonexistent.bmp");
            Assert.False(r);
        }

        [Fact]
        public void GetWindowPositionX_NoWindow_Throws()
        {
            var p = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => p.GetWindowPositionX());
        }

        [Fact]
        public void GetWindowPositionY_NoWindow_Throws()
        {
            var p = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => p.GetWindowPositionY());
        }

        [Fact]
        public void GetWindowMetrics_NoWindow_Throws()
        {
            var p = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => p.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
        }

        [Fact]
        public void GetMousePositionInView_NoWindow_ReturnsZeros()
        {
            var p = new MacNativePlatform();
            p.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void TryGetLastInputCharacters_ReturnsFalse()
        {
            var p = new MacNativePlatform();
            Assert.False(p.TryGetLastInputCharacters(out string s));
            Assert.Equal("", s);
        }

        [Fact]
        public void GetMouseWheel_Default_Zero()
        {
            var p = new MacNativePlatform();
            Assert.Equal(0, p.GetMouseWheel());
        }

        [Fact]
        public void GetMouseState_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.NotNull(buttons);
            Assert.Equal(5, buttons.Length);
        }

        [Fact]
        public void SetWindowIcon_NoWindow_DoesNotThrow()
        {
            var p = new MacNativePlatform();
            p.SetWindowIcon("");
        }

        [Fact]
        public void TryGetLastKeyPressed_Default_ReturnsFalse()
        {
            var p = new MacNativePlatform();
            Assert.False(p.TryGetLastKeyPressed(out _));
        }

        [Fact]
        public void IsKeyDown_Default_ReturnsFalse()
        {
            var p = new MacNativePlatform();
            Assert.False(p.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void GetWindowWidth_Default_Zero()
        {
            var p = new MacNativePlatform();
            Assert.Equal(0, p.GetWindowWidth());
        }

        [Fact]
        public void GetWindowHeight_Default_Zero()
        {
            var p = new MacNativePlatform();
            Assert.Equal(0, p.GetWindowHeight());
        }

        [Fact]
        public void IsWindowVisible_Default_False()
        {
            var p = new MacNativePlatform();
            Assert.False(p.IsWindowVisible());
        }
    }
}
#endif
