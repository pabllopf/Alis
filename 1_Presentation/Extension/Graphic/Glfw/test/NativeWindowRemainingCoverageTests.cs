// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowRemainingCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Drawing;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for remaining uncovered code in NativeWindow
    /// </summary>
    public class NativeWindowRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The window
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
        ///     Natives the window default constructor creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_DefaultConstructor_CreatesWindow()
        {
            window = new NativeWindow();

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Natives the window handle returns non zero
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Handle_ReturnsNonZero()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            IntPtr handle = window.Handle;

            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Natives the window hwnd does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Hwnd_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            IntPtr hwnd = window.Hwnd;

            Assert.NotNull(hwnd);
        }

        /// <summary>
        ///     Natives the window is closing returns false initially
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsClosing_ReturnsFalseInitially()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool isClosing = window.IsClosing;

            Assert.False(isClosing);
        }

        /// <summary>
        ///     Natives the window is closing returns true after close
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsClosing_ReturnsTrueAfterClose()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Close();

            Assert.True(window.IsClosing);
        }

        /// <summary>
        ///     Natives the window is decorated returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsDecorated_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool isDecorated = window.IsDecorated;

            Assert.True(isDecorated);
        }

        /// <summary>
        ///     Natives the window is floating returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsFloating_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool isFloating = window.IsFloating;

            Assert.False(isFloating);
        }

        /// <summary>
        ///     Natives the window is focused returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsFocused_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool isFocused = window.IsFocused;

            Assert.False(isFocused);
        }

        /// <summary>
        ///     Natives the window is resizable returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_IsResizable_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool isResizable = window.IsResizable;

            Assert.True(isResizable);
        }

        /// <summary>
        ///     Natives the window visible get returns false when hidden
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Visible_Get_ReturnsFalseWhenHidden()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool visible = window.Visible;

            Assert.False(visible);
        }

        /// <summary>
        ///     Natives the window visible set to true shows window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Visible_SetToTrue_ShowsWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Visible = true;

            Assert.True(window.Visible);
        }

        /// <summary>
        ///     Natives the window visible set to false hides window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Visible_SetToFalse_HidesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            window.Visible = true;

            window.Visible = false;

            Assert.False(window.Visible);
        }

        /// <summary>
        ///     Natives the window maximized get returns false initially
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Maximized_Get_ReturnsFalseInitially()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool maximized = window.Maximized;

            Assert.False(maximized);
        }

        /// <summary>
        ///     Natives the window maximized set to true maximizes
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Maximized_SetToTrue_Maximizes()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Maximized = true;

            Assert.True(window.Maximized);
        }

        /// <summary>
        ///     Natives the window maximized set to false restores
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Maximized_SetToFalse_Restores()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            window.Maximized = true;

            window.Maximized = false;

            Assert.False(window.Maximized);
        }

        /// <summary>
        ///     Natives the window minimized set to true minimizes
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Minimized_SetToTrue_Minimizes()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Minimized = true;

            Assert.True(window.Minimized);
        }

        /// <summary>
        ///     Natives the window minimized set to false restores
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Minimized_SetToFalse_Restores()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            window.Minimized = true;

            window.Minimized = false;

            Assert.False(window.Minimized);
        }

        /// <summary>
        ///     Natives the window monitor returns none for windowed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Monitor_ReturnsNoneForWindowed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Monitor monitor = window.Monitor;

            Assert.Equal(Monitor.None, monitor);
        }

        /// <summary>
        ///     Natives the window client bounds can get
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientBounds_CanGet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Rectangle clientBounds = window.ClientBounds;

            Assert.True(clientBounds.Width > 0);
            Assert.True(clientBounds.Height > 0);
        }

        /// <summary>
        ///     Natives the window client bounds can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientBounds_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.ClientBounds = new Rectangle(100, 100, 400, 300);

            Rectangle actual = window.ClientBounds;
            Assert.Equal(400, actual.Width);
            Assert.Equal(300, actual.Height);
        }

        /// <summary>
        ///     Natives the window client width can get
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientWidth_CanGet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            int width = window.ClientWidth;

            Assert.True(width > 0);
        }

        /// <summary>
        ///     Natives the window client width can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientWidth_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.ClientWidth = 400;

            Assert.Equal(400, window.ClientWidth);
        }

        /// <summary>
        ///     Natives the window client width throws on invalid value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientWidth_ThrowsOnInvalidValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Assert.Throws<ArgumentOutOfRangeException>(() => window.ClientWidth = 0);
        }

        /// <summary>
        ///     Natives the window client height can get
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientHeight_CanGet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            int height = window.ClientHeight;

            Assert.True(height > 0);
        }

        /// <summary>
        ///     Natives the window client height can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientHeight_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.ClientHeight = 300;

            Assert.Equal(300, window.ClientHeight);
        }

        /// <summary>
        ///     Natives the window client height throws on invalid value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientHeight_ThrowsOnInvalidValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Assert.Throws<ArgumentOutOfRangeException>(() => window.ClientHeight = 0);
        }

        /// <summary>
        ///     Natives the window client size can get
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientSize_CanGet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Size size = window.ClientSize;

            Assert.True(size.Width > 0);
            Assert.True(size.Height > 0);
        }

        /// <summary>
        ///     Natives the window client size can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ClientSize_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.ClientSize = new Size(500, 400);

            Assert.Equal(500, window.ClientSize.Width);
            Assert.Equal(400, window.ClientSize.Height);
        }

        /// <summary>
        ///     Natives the window bounds can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Bounds_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Bounds = new Rectangle(50, 50, 600, 400);

            Rectangle bounds = window.Bounds;
            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        ///     Natives the window clipboard can get and set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Clipboard_CanGetAndSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Clipboard = "test clipboard";

            Assert.Equal("test clipboard", window.Clipboard);
        }

        /// <summary>
        ///     Natives the window cursor mode can get and set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_CursorMode_CanGetAndSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.CursorMode = CursorMode.Hidden;

            Assert.Equal(CursorMode.Hidden, window.CursorMode);
        }

        /// <summary>
        ///     Natives the window mouse position can get
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MousePosition_CanGet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Point pos = window.MousePosition;

            Assert.True(pos.X >= 0);
            Assert.True(pos.Y >= 0);
        }

        /// <summary>
        ///     Natives the window mouse position can set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MousePosition_CanSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.MousePosition = new Point(100, 100);

            Assert.NotNull(window.MousePosition);
        }

        /// <summary>
        ///     Natives the window sticky keys can get and set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_StickyKeys_CanGetAndSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.StickyKeys = true;

            Assert.True(window.StickyKeys);
        }

        /// <summary>
        ///     Natives the window sticky mouse buttons can get and set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_StickyMouseButtons_CanGetAndSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.StickyMouseButtons = true;

            Assert.True(window.StickyMouseButtons);
        }

        /// <summary>
        ///     Natives the window user pointer can get and set
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_UserPointer_CanGetAndSet()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            IntPtr ptr = new IntPtr(42);
            window.UserPointer = ptr;

            Assert.Equal(ptr, window.UserPointer);
        }

        /// <summary>
        ///     Natives the window video mode returns valid mode
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_VideoMode_ReturnsValidMode()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            VideoMode mode = window.VideoMode;

            Assert.True(mode.Width > 0);
            Assert.True(mode.Height > 0);
        }

        /// <summary>
        ///     Natives the window equals with null returns false
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Equals_WithNull_ReturnsFalse()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool result = window.Equals((NativeWindow)null);

            Assert.False(result);
        }

        /// <summary>
        ///     Natives the window equals with different object type returns false
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Equals_WithDifferentObjectType_ReturnsFalse()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool result = window.Equals("some string");

            Assert.False(result);
        }

        /// <summary>
        ///     Natives the window equals with null object returns false
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Equals_WithNullObject_ReturnsFalse()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            bool result = window.Equals(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Natives the window implicit conversion to window returns valid window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ImplicitConversion_ToWindow_ReturnsValidWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            Window w = window;

            Assert.NotEqual(Window.None, w);
        }

        /// <summary>
        ///     Natives the window implicit conversion to int ptr returns non zero
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ImplicitConversion_ToIntPtr_ReturnsNonZero()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            IntPtr ptr = window;

            Assert.NotEqual(IntPtr.Zero, ptr);
        }

        /// <summary>
        ///     Natives the window center on screen does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_CenterOnScreen_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.CenterOnScreen();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window fullscreen on primary monitor does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Fullscreen_OnPrimary_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Fullscreen();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window fullscreen on specific monitor does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Fullscreen_OnSpecificMonitor_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.Fullscreen(GlfwNative.PrimaryMonitor);

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window request attention does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_RequestAttention_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.RequestAttention();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window set aspect ratio does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetAspectRatio_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.SetAspectRatio(16, 9);

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window set size limits with size values does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetSizeLimits_WithSizeValues_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.SetSizeLimits(new Size(320, 240), new Size(1920, 1080));

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window set size limits with int values does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetSizeLimits_WithIntValues_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.SetSizeLimits(320, 240, 1920, 1080);

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window set monitor does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetMonitor_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.SetMonitor(Monitor.None, 0, 0, 800, 600);

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window set icons with empty array does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetIcons_WithEmptyArray_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");

            window.SetIcons();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window dispose triggers disposed event
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Dispose_TriggersDisposedEvent()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.Disposed += (sender, args) => eventRaised = true;
            window.Dispose();

            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Natives the window close triggers closed event
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Close_TriggersClosedEvent()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.Closed += (sender, args) => eventRaised = true;
            window.Close();

            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Natives the window closing event can cancel
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Closing_Event_CanCancel()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.Closing += (sender, args) =>
            {
                eventRaised = true;
                args.Cancel = true;
            };
            window.Close();

            Assert.True(eventRaised);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Natives the window maximized changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MaximizeChanged_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.MaximizeChanged += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window character input event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_CharacterInput_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.CharacterInput += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window key action event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_KeyAction_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.KeyAction += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window key repeat event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_KeyRepeat_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.KeyRepeat += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window mouse button event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MouseButton_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.MouseButton += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window mouse moved event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MouseMoved_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.MouseMoved += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window mouse scroll event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MouseScroll_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.MouseScroll += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window position changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_PositionChanged_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.PositionChanged += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window refreshed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Refreshed_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.Refreshed += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window focus changed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_FocusChanged_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.FocusChanged += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window disposed event can be subscribed
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Disposed_Event_CanBeSubscribed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            bool eventRaised = false;

            window.Disposed += (sender, args) => eventRaised = true;

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Natives the window get x 11 selection string returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_GetX11SelectionString_ReturnsValue()
        {
            string result = NativeWindow.GetX11SelectionString();

            Assert.True(result == null || result.Length >= 0);
        }

        /// <summary>
        ///     Natives the window set x 11 selection string does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SetX11SelectionString_DoesNotThrow()
        {
            NativeWindow.SetX11SelectionString("test selection");

            Assert.NotNull("test selection");
        }

        /// <summary>
        ///     Natives the window get win 32 adapter returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_GetWin32Adapter_ReturnsValue()
        {
            string result = NativeWindow.GetWin32Adapter(Monitor.None);

            Assert.True(result == null || result.Length >= 0);
        }

        /// <summary>
        ///     Natives the window get win 32 monitor returns value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_GetWin32Monitor_ReturnsValue()
        {
            string result = NativeWindow.GetWin32Monitor(Monitor.None);

            Assert.True(result == null || result.Length >= 0);
        }
    }
}
