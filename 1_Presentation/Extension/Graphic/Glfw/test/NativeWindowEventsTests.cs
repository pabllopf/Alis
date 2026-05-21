

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for NativeWindow events
    /// </summary>
    public class NativeWindowEventsTests : IDisposable
    {
        /// <summary>
        ///     The window
        /// </summary>
        private NativeWindow window;

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }

        /// <summary>
        ///     Natives the window closing event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Closing_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.Closing += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window size changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SizeChanged_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.SizeChanged += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }


        /// <summary>
        ///     Natives the window key press event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_KeyPress_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.KeyPress += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window key release event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_KeyRelease_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.KeyRelease += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }


        /// <summary>
        ///     Natives the window mouse enter event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MouseEnter_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.MouseEnter += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window mouse leave event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MouseLeave_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            window.MouseLeave += (sender, args) => { eventRaised = true; };

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window file drop event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_FileDrop_Event_CanBeSubscribed()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            // Act
            window.FileDrop += (sender, args) => { eventRaised = true; };

            // Assert - Event subscription doesn't throw
            Assert.NotNull(window);
        }


        /// <summary>
        ///     Natives the window framebuffer size changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_FramebufferSizeChanged_Event_CanBeSubscribed()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            // Act
            window.FramebufferSizeChanged += (sender, args) => { eventRaised = true; };

            // Assert - Event subscription doesn't throw
            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window content scale changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ContentScaleChanged_Event_CanBeSubscribed()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            bool eventRaised = false;

            // Act
            window.ContentScaleChanged += (sender, args) => { eventRaised = true; };

            // Assert - Event subscription doesn't throw
            Assert.NotNull(window);
        }
    }
}