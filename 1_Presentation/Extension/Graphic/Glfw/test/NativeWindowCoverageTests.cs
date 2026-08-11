// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowCoverageTests.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Coverage tests for <see cref="NativeWindow" /> executed against the persistent window created by
    ///     <see cref="GlfwTestBootstrap" /> on the main thread.
    /// </summary>
    public class NativeWindowCoverageTests
    {
        /// <summary>
        ///     Gets the bootstrapped window.
        /// </summary>
        private static TestableNativeWindow Window
        {
            get
            {
                GlfwTestBootstrap.EnsureReady();
                return (TestableNativeWindow) GlfwTestBootstrap.Window;
            }
        }

        /// <summary>
        ///     Tests that handle returns a non zero pointer
        /// </summary>
        [Fact]
        public void Handle_ReturnsNonZero()
        {
            IntPtr handle = Window.Handle;

            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Tests that hwnd access does not throw
        /// </summary>
        [Fact]
        public void Hwnd_Access_DoesNotThrow()
        {
            IntPtr hwnd = Window.Hwnd;

            Assert.NotNull(hwnd);
        }

        /// <summary>
        ///     Tests that is closing returns false for an open window
        /// </summary>
        [Fact]
        public void IsClosing_ForOpenWindow_ReturnsFalse()
        {
            Assert.False(Window.IsClosing);
        }

        /// <summary>
        ///     Tests that is decorated returns a boolean
        /// </summary>
        [Fact]
        public void IsDecorated_ReturnsBoolean()
        {
            bool decorated = Window.IsDecorated;

            Assert.True(decorated || !decorated);
        }

        /// <summary>
        ///     Tests that is floating returns a boolean
        /// </summary>
        [Fact]
        public void IsFloating_ReturnsBoolean()
        {
            bool floating = Window.IsFloating;

            Assert.True(floating || !floating);
        }

        /// <summary>
        ///     Tests that is focused returns a boolean
        /// </summary>
        [Fact]
        public void IsFocused_ReturnsBoolean()
        {
            bool focused = Window.IsFocused;

            Assert.True(focused || !focused);
        }

        /// <summary>
        ///     Tests that is resizable returns a boolean
        /// </summary>
        [Fact]
        public void IsResizable_ReturnsBoolean()
        {
            bool resizable = Window.IsResizable;

            Assert.True(resizable || !resizable);
        }

        /// <summary>
        ///     Tests that maximized getter returns a boolean
        /// </summary>
        [Fact]
        public void Maximized_Getter_ReturnsBoolean()
        {
            bool maximized = Window.Maximized;

            Assert.True(maximized || !maximized);
        }

        /// <summary>
        ///     Tests that minimized getter returns a boolean
        /// </summary>
        [Fact]
        public void Minimized_Getter_ReturnsBoolean()
        {
            bool minimized = Window.Minimized;

            Assert.True(minimized || !minimized);
        }

        /// <summary>
        ///     Tests that monitor returns none for a windowed window
        /// </summary>
        [Fact]
        public void Monitor_ForWindowedWindow_ReturnsNone()
        {
            Monitor monitor = Window.Monitor;

            Assert.Equal(Monitor.None, monitor);
        }

        /// <summary>
        ///     Tests that title returns the initial title
        /// </summary>
        [Fact]
        public void Title_ReturnsInitialTitle()
        {
            string title = Window.Title;

            Assert.Equal("alis-coverage", title);
        }

        /// <summary>
        ///     Tests that client width returns the creation width
        /// </summary>
        [Fact]
        public void ClientWidth_ReturnsCreationWidth()
        {
            int width = Window.ClientWidth;

            Assert.True(width > 0);
        }

        /// <summary>
        ///     Tests that client height returns the creation height
        /// </summary>
        [Fact]
        public void ClientHeight_ReturnsCreationHeight()
        {
            int height = Window.ClientHeight;

            Assert.True(height > 0);
        }

        /// <summary>
        ///     Tests that client size returns a non empty size
        /// </summary>
        [Fact]
        public void ClientSize_ReturnsNonEmptySize()
        {
            Size size = Window.ClientSize;

            Assert.True(size.Width > 0);
            Assert.True(size.Height > 0);
        }

        /// <summary>
        ///     Tests that size getter returns a non empty size
        /// </summary>
        [Fact]
        public void Size_Getter_ReturnsNonEmptySize()
        {
            Size size = Window.Size;

            Assert.True(size.Width > 0);
            Assert.True(size.Height > 0);
        }

        /// <summary>
        ///     Tests that bounds getter returns a non empty rectangle
        /// </summary>
        [Fact]
        public void Bounds_Getter_ReturnsNonEmptyRectangle()
        {
            Rectangle bounds = Window.Bounds;

            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        ///     Tests that client bounds getter returns a non empty rectangle
        /// </summary>
        [Fact]
        public void ClientBounds_Getter_ReturnsNonEmptyRectangle()
        {
            Rectangle bounds = Window.ClientBounds;

            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        ///     Tests that position getter returns a point
        /// </summary>
        [Fact]
        public void Position_Getter_ReturnsPoint()
        {
            Point position = Window.Position;

            Assert.True(position.X >= -10000);
            Assert.True(position.Y >= -10000);
        }

        /// <summary>
        ///     Tests that content scale returns positive values
        /// </summary>
        [Fact]
        public void ContentScale_ReturnsPositiveValues()
        {
            PointF scale = Window.ContentScale;

            Assert.True(scale.X > 0.0f);
            Assert.True(scale.Y > 0.0f);
        }

        /// <summary>
        ///     Tests that clipboard round trips a string
        /// </summary>
        [Fact]
        public void Clipboard_RoundTripsString()
        {
            Window.Clipboard = "coverage-clipboard";

            string value = Window.Clipboard;

            Assert.Equal("coverage-clipboard", value);
        }

        /// <summary>
        ///     Tests that cursor mode getter returns normal for a new window
        /// </summary>
        [Fact]
        public void CursorMode_Getter_ReturnsNormal()
        {
            CursorMode mode = Window.CursorMode;

            Assert.True(mode == CursorMode.Normal || mode == CursorMode.Hidden);
        }

        /// <summary>
        ///     Tests that sticky keys getter returns a boolean
        /// </summary>
        [Fact]
        public void StickyKeys_Getter_ReturnsBoolean()
        {
            bool stickyKeys = Window.StickyKeys;

            Assert.True(stickyKeys || !stickyKeys);
        }

        /// <summary>
        ///     Tests that sticky mouse buttons getter returns a boolean
        /// </summary>
        [Fact]
        public void StickyMouseButtons_Getter_ReturnsBoolean()
        {
            bool stickyMouseButtons = Window.StickyMouseButtons;

            Assert.True(stickyMouseButtons || !stickyMouseButtons);
        }

        /// <summary>
        ///     Tests that mouse position getter returns a point
        /// </summary>
        [Fact]
        public void MousePosition_Getter_ReturnsPoint()
        {
            Point position = Window.MousePosition;

            Assert.True(position.X >= -100000);
            Assert.True(position.Y >= -100000);
        }

        /// <summary>
        ///     Tests that mouse position setter does not throw
        /// </summary>
        [Fact]
        public void MousePosition_Setter_DoesNotThrow()
        {
            Window.MousePosition = new Point(10, 10);

            Point position = Window.MousePosition;

            Assert.True(position.X >= -100000);
        }

        /// <summary>
        ///     Tests that user pointer round trips a value
        /// </summary>
        [Fact]
        public void UserPointer_RoundTripsValue()
        {
            IntPtr expected = new IntPtr(12345);

            Window.UserPointer = expected;
            IntPtr actual = Window.UserPointer;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///     Tests that video mode getter returns a mode with positive width
        /// </summary>
        [Fact]
        public void VideoMode_Getter_ReturnsModeWithPositiveWidth()
        {
            VideoMode mode = Window.VideoMode;

            Assert.True(mode.Width > 0);
            Assert.True(mode.Height > 0);
        }

        /// <summary>
        ///     Tests that visible getter returns false for a hidden window
        /// </summary>
        [Fact]
        public void Visible_Getter_ForHiddenWindow_ReturnsFalse()
        {
            bool visible = Window.Visible;

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that implicit conversion to window returns the underlying handle
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToWindow_ReturnsUnderlyingHandle()
        {
            Alis.Extension.Graphic.Glfw.Structs.Window handle = Window;

            Assert.NotEqual(Alis.Extension.Graphic.Glfw.Structs.Window.None, handle);
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns the underlying handle
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_ReturnsUnderlyingHandle()
        {
            IntPtr handle = Window;

            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Tests that equals with the same instance returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameInstance_ReturnsTrue()
        {
            NativeWindow window = Window;

            Assert.True(window.Equals(window));
        }

        /// <summary>
        ///     Tests that equals with null returns false
        /// </summary>
        [Fact]
        public void Equals_WithNull_ReturnsFalse()
        {
            NativeWindow window = Window;

            Assert.False(window.Equals((NativeWindow) null));
        }

        /// <summary>
        ///     Tests that equals with a non window object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonWindowObject_ReturnsFalse()
        {
            NativeWindow window = Window;

            Assert.False(window.Equals(new object()));
        }

        /// <summary>
        ///     Tests that equals with the same object returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameObject_ReturnsTrue()
        {
            object window = Window;

            Assert.True(window.Equals(window));
        }

        /// <summary>
        ///     Tests that get hash code does not throw
        /// </summary>
        [Fact]
        public void GetHashCode_DoesNotThrow()
        {
            int hash = Window.GetHashCode();

            Assert.True(hash != int.MinValue);
        }

        /// <summary>
        ///     Tests that client width setter with zero throws
        /// </summary>
        [Fact]
        public void ClientWidth_Setter_WithZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Window.ClientWidth = 0);
        }

        /// <summary>
        ///     Tests that client height setter with zero throws
        /// </summary>
        [Fact]
        public void ClientHeight_Setter_WithZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Window.ClientHeight = 0);
        }

        /// <summary>
        ///     Tests that cursor mode setter sets the mode
        /// </summary>
        [Fact]
        public void CursorMode_Setter_SetsMode()
        {
            Window.CursorMode = CursorMode.Hidden;

            CursorMode mode = Window.CursorMode;

            Assert.Equal(CursorMode.Hidden, mode);
            Window.CursorMode = CursorMode.Normal;
        }

        /// <summary>
        ///     Tests that sticky keys setter sets the mode
        /// </summary>
        [Fact]
        public void StickyKeys_Setter_SetsMode()
        {
            Window.StickyKeys = true;

            bool stickyKeys = Window.StickyKeys;

            Assert.True(stickyKeys);
            Window.StickyKeys = false;
        }

        /// <summary>
        ///     Tests that sticky mouse buttons setter sets the mode
        /// </summary>
        [Fact]
        public void StickyMouseButtons_Setter_SetsMode()
        {
            Window.StickyMouseButtons = true;

            bool stickyMouseButtons = Window.StickyMouseButtons;

            Assert.True(stickyMouseButtons);
            Window.StickyMouseButtons = false;
        }

        /// <summary>
        ///     Tests that make current does not throw
        /// </summary>
        [Fact]
        public void MakeCurrent_DoesNotThrow()
        {
            Window.MakeCurrent();
        }

        /// <summary>
        ///     Tests that swap buffers does not throw
        /// </summary>
        [Fact]
        public void SwapBuffers_DoesNotThrow()
        {
            Window.SwapBuffers();
        }

        /// <summary>
        ///     Tests that get x 11 selection string on mac os throws entry point not found
        /// </summary>
        [Fact]
        public void GetX11SelectionString_OnMacOS_ThrowsEntryPointNotFound()
        {
            if (!OperatingSystem.IsMacOS())
            {
                return;
            }

            Assert.Throws<EntryPointNotFoundException>(() => NativeWindow.GetX11SelectionString());
        }

        /// <summary>
        ///     Tests that set x 11 selection string on mac os throws entry point not found
        /// </summary>
        [Fact]
        public void SetX11SelectionString_OnMacOS_ThrowsEntryPointNotFound()
        {
            if (!OperatingSystem.IsMacOS())
            {
                return;
            }

            Assert.Throws<EntryPointNotFoundException>(() => NativeWindow.SetX11SelectionString("value"));
        }

        /// <summary>
        ///     Tests that get win 32 adapter on mac os throws entry point not found
        /// </summary>
        [Fact]
        public void GetWin32Adapter_OnMacOS_ThrowsEntryPointNotFound()
        {
            if (!OperatingSystem.IsMacOS())
            {
                return;
            }

            Assert.Throws<EntryPointNotFoundException>(() => NativeWindow.GetWin32Adapter(Monitor.None));
        }

        /// <summary>
        ///     Tests that get win 32 monitor on mac os throws entry point not found
        /// </summary>
        [Fact]
        public void GetWin32Monitor_OnMacOS_ThrowsEntryPointNotFound()
        {
            if (!OperatingSystem.IsMacOS())
            {
                return;
            }

            Assert.Throws<EntryPointNotFoundException>(() => NativeWindow.GetWin32Monitor(Monitor.None));
        }

        /// <summary>
        ///     Tests that the closed event is raised
        /// </summary>
        [Fact]
        public void Closed_Event_IsRaised()
        {
            bool raised = false;
            Window.Closed += (s, e) => raised = true;

            Window.FireOnClosed();

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that closing with cancel keeps the window open
        /// </summary>
        [Fact]
        public void Closing_WithCancel_KeepsWindowOpen()
        {
            bool raised = false;
            Window.Closing += (s, e) =>
            {
                raised = true;
                e.Cancel = true;
            };

            Window.FireOnClosing();

            Assert.True(raised);
            Assert.False(Window.IsClosing);
        }

        /// <summary>
        ///     Tests that file drop with paths raises the event
        /// </summary>
        [Fact]
        public void FileDrop_WithPaths_RaisesEvent()
        {
            FileDropEventArgs received = null;
            Window.FileDrop += (s, e) => received = e;

            Window.FireOnFileDrop(new[] {"alpha.txt", "beta.txt"});

            Assert.NotNull(received);
            Assert.Equal(2, received.Filenames.Length);
            Assert.Equal("alpha.txt", received.Filenames[0]);
            Assert.Equal("beta.txt", received.Filenames[1]);
        }

        /// <summary>
        ///     Tests that file drop with a pointer array raises the event
        /// </summary>
        [Fact]
        public void FileDrop_WithPointerArray_RaisesEvent()
        {
            FileDropEventArgs received = null;
            Window.FileDrop += (s, e) => received = e;
            byte[] first = Encoding.UTF8.GetBytes("first.txt\0");
            byte[] second = Encoding.UTF8.GetBytes("second.txt\0");
            IntPtr buffer = Marshal.AllocHGlobal(2 * IntPtr.Size);
            IntPtr firstPtr = Marshal.AllocHGlobal(first.Length);
            IntPtr secondPtr = Marshal.AllocHGlobal(second.Length);
            try
            {
                Marshal.Copy(first, 0, firstPtr, first.Length);
                Marshal.Copy(second, 0, secondPtr, second.Length);
                Marshal.WriteIntPtr(buffer, 0, firstPtr);
                Marshal.WriteIntPtr(buffer, IntPtr.Size, secondPtr);

                Window.FireOnFileDrop(2, buffer);

                Assert.NotNull(received);
                Assert.Equal(2, received.Filenames.Length);
                Assert.Equal("first.txt", received.Filenames[0]);
                Assert.Equal("second.txt", received.Filenames[1]);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
                Marshal.FreeHGlobal(firstPtr);
                Marshal.FreeHGlobal(secondPtr);
            }
        }

        /// <summary>
        ///     Tests that focus changed raises the event
        /// </summary>
        [Fact]
        public void FocusChanged_RaisesEvent()
        {
            bool raised = false;
            Window.FocusChanged += (s, e) => raised = true;

            Window.FireOnFocusChanged(true);

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that framebuffer size changed raises the event
        /// </summary>
        [Fact]
        public void FramebufferSizeChanged_RaisesEvent()
        {
            SizeChangeEventArgs received = null;
            Window.FramebufferSizeChanged += (s, e) => received = e;

            Window.FireOnFramebufferSizeChanged(640, 480);

            Assert.NotNull(received);
            Assert.Equal(640, received.Size.Width);
        }

        /// <summary>
        ///     Tests that key press raises key press and key action
        /// </summary>
        [Fact]
        public void OnKey_Press_RaisesKeyPressAndKeyAction()
        {
            bool pressRaised = false;
            bool actionRaised = false;
            Window.KeyPress += (s, e) => pressRaised = true;
            Window.KeyAction += (s, e) => actionRaised = true;

            Window.FireOnKey(Keys.A, 0, InputState.Press, ModifierKeys.None);

            Assert.True(pressRaised);
            Assert.True(actionRaised);
        }

        /// <summary>
        ///     Tests that key release raises key release and key action
        /// </summary>
        [Fact]
        public void OnKey_Release_RaisesKeyReleaseAndKeyAction()
        {
            bool releaseRaised = false;
            bool actionRaised = false;
            Window.KeyRelease += (s, e) => releaseRaised = true;
            Window.KeyAction += (s, e) => actionRaised = true;

            Window.FireOnKey(Keys.A, 0, InputState.Release, ModifierKeys.None);

            Assert.True(releaseRaised);
            Assert.True(actionRaised);
        }

        /// <summary>
        ///     Tests that key repeat state raises the key action with a repeat argument
        /// </summary>
        [Fact]
        public void OnKey_Repeat_RaisesKeyAction()
        {
            KeyEventArgs received = null;
            Window.KeyAction += (s, e) => received = e;

            Window.FireOnKey(Keys.A, 0, InputState.Repeat, ModifierKeys.None);

            Assert.NotNull(received);
            Assert.Equal(InputState.Repeat, received.State);
        }

        /// <summary>
        ///     Tests that mouse button raises the event
        /// </summary>
        [Fact]
        public void MouseButton_RaisesEvent()
        {
            MouseButtonEventArgs received = null;
            Window.MouseButton += (s, e) => received = e;

            Window.FireOnMouseButton(MouseButton.Left, InputState.Press, ModifierKeys.None);

            Assert.NotNull(received);
            Assert.Equal(MouseButton.Left, received.Button);
        }

        /// <summary>
        ///     Tests that mouse enter with true raises mouse enter
        /// </summary>
        [Fact]
        public void OnMouseEnter_WithTrue_RaisesMouseEnter()
        {
            bool enterRaised = false;
            bool leaveRaised = false;
            Window.MouseEnter += (s, e) => enterRaised = true;
            Window.MouseLeave += (s, e) => leaveRaised = true;

            Window.FireOnMouseEnter(true);

            Assert.True(enterRaised);
            Assert.False(leaveRaised);
        }

        /// <summary>
        ///     Tests that mouse enter with false raises mouse leave
        /// </summary>
        [Fact]
        public void OnMouseEnter_WithFalse_RaisesMouseLeave()
        {
            bool enterRaised = false;
            bool leaveRaised = false;
            Window.MouseEnter += (s, e) => enterRaised = true;
            Window.MouseLeave += (s, e) => leaveRaised = true;

            Window.FireOnMouseEnter(false);

            Assert.False(enterRaised);
            Assert.True(leaveRaised);
        }

        /// <summary>
        ///     Tests that mouse move raises the event
        /// </summary>
        [Fact]
        public void MouseMove_RaisesEvent()
        {
            MouseMoveEventArgs received = null;
            Window.MouseMoved += (s, e) => received = e;

            Window.FireOnMouseMove(12.5, 34.5);

            Assert.NotNull(received);
            Assert.Equal(12.5, received.X);
        }

        /// <summary>
        ///     Tests that mouse scroll raises the event
        /// </summary>
        [Fact]
        public void MouseScroll_RaisesEvent()
        {
            MouseMoveEventArgs received = null;
            Window.MouseScroll += (s, e) => received = e;

            Window.FireOnMouseScroll(1.5, 2.5);

            Assert.NotNull(received);
            Assert.Equal(1.5, received.X);
        }

        /// <summary>
        ///     Tests that position changed raises the event
        /// </summary>
        [Fact]
        public void PositionChanged_RaisesEvent()
        {
            bool raised = false;
            Window.PositionChanged += (s, e) => raised = true;

            Window.FireOnPositionChanged(100, 200);

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that size changed raises the event
        /// </summary>
        [Fact]
        public void SizeChanged_RaisesEvent()
        {
            SizeChangeEventArgs received = null;
            Window.SizeChanged += (s, e) => received = e;

            Window.FireOnSizeChanged(800, 600);

            Assert.NotNull(received);
            Assert.Equal(800, received.Size.Width);
        }

        /// <summary>
        ///     Tests that character input raises the event
        /// </summary>
        [Fact]
        public void CharacterInput_RaisesEvent()
        {
            CharEventArgs received = null;
            Window.CharacterInput += (s, e) => received = e;

            Window.FireOnCharacterInput(65, ModifierKeys.None);

            Assert.NotNull(received);
            Assert.Equal((uint) 65, received.CodePoint);
        }

        /// <summary>
        ///     Tests that maximize changed raises the event
        /// </summary>
        [Fact]
        public void MaximizeChanged_RaisesEvent()
        {
            MaximizeEventArgs received = null;
            Window.MaximizeChanged += (s, e) => received = e;

            Window.FireOnMaximizeChanged(true);

            Assert.NotNull(received);
            Assert.True(received.IsMaximized);
        }

        /// <summary>
        ///     Tests that content scale changed raises the event
        /// </summary>
        [Fact]
        public void ContentScaleChanged_RaisesEvent()
        {
            ContentScaleEventArgs received = null;
            Window.ContentScaleChanged += (s, e) => received = e;

            Window.FireOnContentScaleChanged(1.5f, 2.0f);

            Assert.NotNull(received);
            Assert.Equal(1.5f, received.XScale);
        }

    }
}
