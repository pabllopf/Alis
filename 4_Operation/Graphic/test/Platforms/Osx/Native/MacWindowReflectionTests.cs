#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    public class MacWindowReflectionTests
    {
        [Fact]
        public void MacWindow_IsInternal()
        {
            Assert.True(typeof(MacWindow).IsNotPublic);
        }

        [Fact]
        public void MacWindow_Properties_Exist()
        {
            Assert.NotNull(typeof(MacWindow).GetProperty("Handle"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Width"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Height"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Title"));
        }

        [Fact]
        public void MacWindow_Constructor_SetsWidthHeightTitle()
        {
            var window = new MacWindow(1024, 768, "TestWindow");
            Assert.Equal(1024, window.Width);
            Assert.Equal(768, window.Height);
            Assert.Equal("TestWindow", window.Title);
            Assert.NotEqual(IntPtr.Zero, window.Handle);
        }

        [Fact]
        public void MacWindow_Show_Hide_DoNotThrow()
        {
            var window = new MacWindow(100, 100, "sh");
            window.Show();
            window.Hide();
        }

        [Fact]
        public void MacWindow_SetTitle_ChangesProperty()
        {
            var window = new MacWindow(100, 100, "old");
            window.SetTitle("new");
            Assert.Equal("new", window.Title);
        }

        [Fact]
        public void MacWindow_SetSize_ChangesDimensions()
        {
            var window = new MacWindow(100, 100, "size");
            window.SetSize(640, 480);
            Assert.Equal(640, window.Width);
            Assert.Equal(480, window.Height);
        }

        [Fact]
        public void MacWindow_IsVisible_ReturnsBool()
        {
            var window = new MacWindow(100, 100, "vis");
            Assert.IsType<bool>(window.IsVisible());
        }

        [Fact]
        public void MacWindow_GetFrame_ReturnsNonZero()
        {
            var window = new MacWindow(200, 200, "frame");
            NsRect frame = window.GetFrame();
            Assert.True(frame.width > 0);
            Assert.True(frame.height > 0);
        }

        [Fact]
        public void MacOpenGLContext_IsInternal()
        {
            Assert.True(typeof(MacOpenGLContext).IsNotPublic);
        }

        [Fact]
        public void MacOpenGLContext_Properties_Exist()
        {
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("View"));
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("Context"));
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("PixelFormat"));
        }

        [Fact]
        public void MacOpenGLContext_Constructor_ThrowsWhenNull()
        {
            Assert.Throws<NullReferenceException>(() => new MacOpenGLContext(null));
        }

        [Fact]
        public void MacOpenGLContext_WithWindow_Creates()
        {
            var window = new MacWindow(100, 100, "gltest");
            var ctx = new MacOpenGLContext(window);
            Assert.NotNull(ctx);
        }

        [Fact]
        public void MacOpenGLContext_MakeCurrent_DoesNotThrow()
        {
            var window = new MacWindow(100, 100, "glmake");
            var ctx = new MacOpenGLContext(window);
            ctx.MakeCurrent();
        }

        [Fact]
        public void MacOpenGLContext_SwapBuffers_DoesNotThrow()
        {
            var window = new MacWindow(100, 100, "glswap");
            var ctx = new MacOpenGLContext(window);
            ctx.SwapBuffers();
        }
    }
}
#endif
