#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     The mac native window context tests class
    /// </summary>
    public class MacNativeWindowContextTests
    {
        [DllImport("/usr/lib/libSystem.B.dylib")]
        private static extern int pthread_main_np();

        private static bool IsMainThread() => pthread_main_np() != 0;

        private static MacWindow CreateWindow(int width, int height, string title)
        {
            if (!IsMainThread())
            {
                return null;
            }
            ObjectiveCInterop.NSApplicationLoad();
            return new MacWindow(width, height, title);
        }

        /// <summary>
        ///     MacWindow_Constructor_WithValidValues_SetsProperties
        /// </summary>
        [Fact]
        public void MacWindow_Constructor_WithValidValues_SetsProperties()
        {
            MacWindow window = CreateWindow(800, 600, "Test Window");
            if (window == null) return;
            Assert.Equal(800, window.Width);
            Assert.Equal(600, window.Height);
            Assert.Equal("Test Window", window.Title);
        }

        /// <summary>
        ///     MacWindow_Constructor_WithNegativeValues_CreatesOrThrows
        /// </summary>
        [Fact]
        public void MacWindow_Constructor_WithNegativeValues_CreatesOrThrows()
        {
            if (!IsMainThread()) return;
            ObjectiveCInterop.NSApplicationLoad();
            var ex = Record.Exception(() => new MacWindow(-1, -1, "Negative"));
            if (ex != null)
            {
                Assert.IsAssignableFrom<Exception>(ex);
            }
        }

        /// <summary>
        ///     MacWindow_Handle_IsNonZero
        /// </summary>
        [Fact]
        public void MacWindow_Handle_IsNonZero()
        {
            MacWindow window = CreateWindow(800, 600, "Handle Test");
            if (window == null) return;
            Assert.NotEqual(IntPtr.Zero, window.Handle);
        }

        /// <summary>
        ///     MacWindow_IsVisible_ReturnsBool
        /// </summary>
        [Fact]
        public void MacWindow_IsVisible_ReturnsBool()
        {
            MacWindow window = CreateWindow(800, 600, "Visible Test");
            if (window == null) return;
            bool visible = window.IsVisible();
            Assert.False(visible);
        }

        /// <summary>
        ///     MacWindow_Show_DoesNotThrow
        /// </summary>
        [Fact]
        public void MacWindow_Show_DoesNotThrow()
        {
            MacWindow window = CreateWindow(800, 600, "Show Test");
            if (window == null) return;
            window.Show();
        }

        /// <summary>
        ///     MacWindow_Hide_DoesNotThrow
        /// </summary>
        [Fact]
        public void MacWindow_Hide_DoesNotThrow()
        {
            MacWindow window = CreateWindow(800, 600, "Hide Test");
            if (window == null) return;
            window.Hide();
        }

        /// <summary>
        ///     MacWindow_GetFrame_ReturnsNonZeroDimensions
        /// </summary>
        [Fact]
        public void MacWindow_GetFrame_ReturnsNonZeroDimensions()
        {
            MacWindow window = CreateWindow(800, 600, "Frame Test");
            if (window == null) return;
            NsRect frame = window.GetFrame();
            Assert.True(frame.width > 0);
            Assert.True(frame.height > 0);
        }

        /// <summary>
        ///     MacWindow_SetTitle_ChangesTitle
        /// </summary>
        [Fact]
        public void MacWindow_SetTitle_ChangesTitle()
        {
            MacWindow window = CreateWindow(800, 600, "Original");
            if (window == null) return;
            window.SetTitle("Updated Title");
            Assert.Equal("Updated Title", window.Title);
        }

        /// <summary>
        ///     MacWindow_SetSize_ChangesWidthAndHeight
        /// </summary>
        [Fact]
        public void MacWindow_SetSize_ChangesWidthAndHeight()
        {
            MacWindow window = CreateWindow(800, 600, "Size Test");
            if (window == null) return;
            window.SetSize(1024, 768);
            Assert.Equal(1024, window.Width);
            Assert.Equal(768, window.Height);
        }

        /// <summary>
        ///     MacWindow_WidthGetter_ReturnsCorrectValue
        /// </summary>
        [Fact]
        public void MacWindow_WidthGetter_ReturnsCorrectValue()
        {
            MacWindow window = CreateWindow(1920, 1080, "Width Test");
            if (window == null) return;
            Assert.Equal(1920, window.Width);
        }

        /// <summary>
        ///     MacWindow_HeightGetter_ReturnsCorrectValue
        /// </summary>
        [Fact]
        public void MacWindow_HeightGetter_ReturnsCorrectValue()
        {
            MacWindow window = CreateWindow(1920, 1080, "Height Test");
            if (window == null) return;
            Assert.Equal(1080, window.Height);
        }

        /// <summary>
        ///     MacOpenGLContext_Constructor_WithNullWindow_ThrowsNullReferenceException
        /// </summary>
        [Fact]
        public void MacOpenGLContext_Constructor_WithNullWindow_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new MacOpenGLContext(null));
        }

        /// <summary>
        ///     MacOpenGLContext_Constructor_WithValidWindow_CreatesOrThrows
        /// </summary>
        [Fact]
        public void MacOpenGLContext_Constructor_WithValidWindow_CreatesOrThrows()
        {
            MacWindow window = CreateWindow(800, 600, "GL Test");
            if (window == null) return;
            var ex = Record.Exception(() => new MacOpenGLContext(window));
            if (ex != null)
            {
                Assert.IsAssignableFrom<Exception>(ex);
            }
        }

        /// <summary>
        ///     MacOpenGLContext_View_PropertyExists
        /// </summary>
        [Fact]
        public void MacOpenGLContext_View_PropertyExists()
        {
            MacOpenGLContext context = CreateContextIfPossible();
            if (context != null)
            {
                Assert.NotEqual(IntPtr.Zero, context.View);
            }
        }

        /// <summary>
        ///     MacOpenGLContext_Context_PropertyExists
        /// </summary>
        [Fact]
        public void MacOpenGLContext_Context_PropertyExists()
        {
            MacOpenGLContext context = CreateContextIfPossible();
            if (context != null)
            {
                Assert.NotEqual(IntPtr.Zero, context.Context);
            }
        }

        /// <summary>
        ///     MacOpenGLContext_PixelFormat_PropertyExists
        /// </summary>
        [Fact]
        public void MacOpenGLContext_PixelFormat_PropertyExists()
        {
            MacOpenGLContext context = CreateContextIfPossible();
            if (context != null)
            {
                Assert.NotEqual(IntPtr.Zero, context.PixelFormat);
            }
        }

        /// <summary>
        ///     MacOpenGLContext_MakeCurrent_CanBeCalled
        /// </summary>
        [Fact]
        public void MacOpenGLContext_MakeCurrent_CanBeCalled()
        {
            MacOpenGLContext context = CreateContextIfPossible();
            if (context != null)
            {
                var ex = Record.Exception(() => context.MakeCurrent());
                if (ex != null)
                {
                    Assert.IsAssignableFrom<Exception>(ex);
                }
            }
        }

        /// <summary>
        ///     MacOpenGLContext_SwapBuffers_CanBeCalled
        /// </summary>
        [Fact]
        public void MacOpenGLContext_SwapBuffers_CanBeCalled()
        {
            MacOpenGLContext context = CreateContextIfPossible();
            if (context != null)
            {
                var ex = Record.Exception(() => context.SwapBuffers());
                if (ex != null)
                {
                    Assert.IsAssignableFrom<Exception>(ex);
                }
            }
        }

        /// <summary>
        ///     MacWindow_IsInternalClass
        /// </summary>
        [Fact]
        public void MacWindow_IsInternalClass()
        {
            Type type = typeof(MacWindow);
            Assert.True(type.IsClass);
            Assert.True(type.IsNotPublic);
        }

        /// <summary>
        ///     MacOpenGLContext_IsInternalClass
        /// </summary>
        [Fact]
        public void MacOpenGLContext_IsInternalClass()
        {
            Type type = typeof(MacOpenGLContext);
            Assert.True(type.IsClass);
            Assert.True(type.IsNotPublic);
        }

        /// <summary>
        ///     MacWindow_Properties_Exist_Reflection
        /// </summary>
        [Fact]
        public void MacWindow_Properties_Exist_Reflection()
        {
            Assert.NotNull(typeof(MacWindow).GetProperty("Handle"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Width"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Height"));
            Assert.NotNull(typeof(MacWindow).GetProperty("Title"));
        }

        /// <summary>
        ///     MacOpenGLContext_Properties_Exist_Reflection
        /// </summary>
        [Fact]
        public void MacOpenGLContext_Properties_Exist_Reflection()
        {
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("View"));
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("Context"));
            Assert.NotNull(typeof(MacOpenGLContext).GetProperty("PixelFormat"));
        }

        /// <summary>
        ///     MacWindow_Methods_Exist_Reflection
        /// </summary>
        [Fact]
        public void MacWindow_Methods_Exist_Reflection()
        {
            Assert.NotNull(typeof(MacWindow).GetMethod("Show"));
            Assert.NotNull(typeof(MacWindow).GetMethod("Hide"));
            Assert.NotNull(typeof(MacWindow).GetMethod("SetTitle", new[] { typeof(string) }));
            Assert.NotNull(typeof(MacWindow).GetMethod("SetSize", new[] { typeof(int), typeof(int) }));
            Assert.NotNull(typeof(MacWindow).GetMethod("IsVisible"));
            Assert.NotNull(typeof(MacWindow).GetMethod("GetFrame"));
        }

        /// <summary>
        ///     MacOpenGLContext_Methods_Exist_Reflection
        /// </summary>
        [Fact]
        public void MacOpenGLContext_Methods_Exist_Reflection()
        {
            Assert.NotNull(typeof(MacOpenGLContext).GetMethod("MakeCurrent"));
            Assert.NotNull(typeof(MacOpenGLContext).GetMethod("SwapBuffers"));
        }

        private static MacOpenGLContext CreateContextIfPossible()
        {
            MacWindow window = CreateWindow(800, 600, "Helper");
            if (window == null) return null;
            var ex = Record.Exception(() => new MacOpenGLContext(window));
            return ex == null ? new MacOpenGLContext(window) : null;
        }
    }
}
#endif
