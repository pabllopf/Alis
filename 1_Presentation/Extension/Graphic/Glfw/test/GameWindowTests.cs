

using System;
using System.Drawing;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GameWindow class
    /// </summary>
    public class GameWindowTests : IDisposable
    {
        /// <summary>
        ///     The window
        /// </summary>
        private GameWindow window;

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }

        /// <summary>
        ///     Games the window default constructor creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_DefaultConstructor_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Games the window constructor with parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_ConstructorWithParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Test Game Window");

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Games the window constructor with all parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_ConstructorWithAllParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(1024, 768, "Full Test Window", Monitor.None, Window.None);

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Games the window inherits from native window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_InheritsFromNativeWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();

            Assert.IsAssignableFrom<NativeWindow>(window);
        }

        /// <summary>
        ///     Games the window can be disposed
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_CanBeDisposed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Disposable Window");

            window.Dispose();
        }

        /// <summary>
        ///     Games the window with custom size has correct size
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_WithCustomSize_HasCorrectSize()
        {
            int expectedWidth = 1280;
            int expectedHeight = 720;
            GlfwNative.WindowHint(Hint.Visible, false);

            window = new GameWindow(expectedWidth, expectedHeight, "Sized Window");
            Size size = window.Size;

            Assert.Equal(expectedWidth, size.Width);
            Assert.Equal(expectedHeight, size.Height);
        }
    }
}