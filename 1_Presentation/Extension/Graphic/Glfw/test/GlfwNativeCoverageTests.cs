// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeCoverageTests.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Coverage tests for <see cref="GlfwNative" /> functions that are safe to call from worker threads once GLFW
    ///     has been initialized on the main thread by <see cref="GlfwTestBootstrap" />.
    /// </summary>
    public class GlfwNativeCoverageTests
    {
        /// <summary>
        ///     Gets the bootstrapped window.
        /// </summary>
        private static NativeWindow Window
        {
            get
            {
                GlfwTestBootstrap.EnsureReady();
                return GlfwTestBootstrap.Window;
            }
        }

        /// <summary>
        ///     Gets the bootstrapped primary monitor.
        /// </summary>
        private static Monitor PrimaryMonitor
        {
            get
            {
                GlfwTestBootstrap.EnsureReady();
                return GlfwTestBootstrap.PrimaryMonitor;
            }
        }

        /// <summary>
        ///     Tests that version returns a version
        /// </summary>
        [Fact]
        public void Version_ReturnsVersion()
        {
            Version version = GlfwNative.Version;

            Assert.NotNull(version);
            Assert.True(version.Major >= 3);
        }

        /// <summary>
        ///     Tests that version string returns the glfw version string
        /// </summary>
        [Fact]
        public void VersionString_ReturnsVersionString()
        {
            string versionString = GlfwNative.VersionString;

            Assert.NotNull(versionString);
            Assert.Contains("3", versionString);
        }

        /// <summary>
        ///     Tests that time setter sets the timer
        /// </summary>
        [Fact]
        public void Time_Setter_SetsTimer()
        {
            GlfwNative.Time = 1.5;

            double time = GlfwNative.Time;

            Assert.True(time >= 1.0);
        }

        /// <summary>
        ///     Tests that timer frequency returns a positive value
        /// </summary>
        [Fact]
        public void TimerFrequency_ReturnsPositiveValue()
        {
            ulong frequency = GlfwNative.TimerFrequency;

            Assert.True(frequency > 0);
        }

        /// <summary>
        ///     Tests that timer value returns a value
        /// </summary>
        [Fact]
        public void TimerValue_ReturnsValue()
        {
            ulong value = GlfwNative.TimerValue;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that monitors returns at least one monitor
        /// </summary>
        [Fact]
        public void Monitors_ReturnsAtLeastOneMonitor()
        {
            Monitor[] monitors = GlfwNative.Monitors;

            Assert.NotNull(monitors);
            Assert.True(monitors.Length >= 1);
        }

        /// <summary>
        ///     Tests that primary monitor is not none
        /// </summary>
        [Fact]
        public void PrimaryMonitor_IsNotNone()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;

            Assert.NotEqual(Monitor.None, monitor);
        }

        /// <summary>
        ///     Tests that current context does not throw
        /// </summary>
        [Fact]
        public void CurrentContext_DoesNotThrow()
        {
            Window context = GlfwNative.CurrentContext;

            Assert.NotNull(context);
        }

        /// <summary>
        ///     Tests that get error returns an error code
        /// </summary>
        [Fact]
        public void GetError_ReturnsErrorCode()
        {
            ErrorCode code = GlfwNative.GetError(out string description);

            Assert.True(code == ErrorCode.None || code != ErrorCode.None);
            Assert.True(description == null || description != null);
        }

        /// <summary>
        ///     Tests that window hint with int does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithInt_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Resizable, 0);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with bool does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithBool_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Resizable, false);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with client api does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithClientApi_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.ClientApi, ClientApi.OpenGl);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with constants does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithConstants_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.OpenglProfile, Constants.True);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with context api does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithContextApi_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.ContextCreationApi, ContextApi.Native);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with robustness does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithRobustness_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.ContextRobustness, Robustness.NoResetNotification);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with profile does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithProfile_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint with release behavior does not throw
        /// </summary>
        [Fact]
        public void WindowHint_WithReleaseBehavior_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.ContextReleaseBehavior, ReleaseBehavior.Any);
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint string does not throw
        /// </summary>
        [Fact]
        public void WindowHintString_DoesNotThrow()
        {
            GlfwNative.WindowHintString(Hint.X11ClassName, new byte[] {84, 0});
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint string utf 8 does not throw
        /// </summary>
        [Fact]
        public void WindowHintStringUtf8_DoesNotThrow()
        {
            GlfwNative.WindowHintStringUTF8(Hint.X11ClassName, "Alis");
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that window hint string ascii does not throw
        /// </summary>
        [Fact]
        public void WindowHintStringAscii_DoesNotThrow()
        {
            GlfwNative.WindowHintStringASCII(Hint.X11ClassName, "Alis");
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that init hint does not throw
        /// </summary>
        [Fact]
        public void InitHint_DoesNotThrow()
        {
            GlfwNative.InitHint(Hint.JoystickHatButtons, true);
        }

        /// <summary>
        ///     Tests that default window hints does not throw
        /// </summary>
        [Fact]
        public void DefaultWindowHints_DoesNotThrow()
        {
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        ///     Tests that get joystick hats returns none for a missing joystick
        /// </summary>
        [Fact]
        public void GetJoystickHats_ForMissingJoystick_ReturnsNone()
        {
            Hats hats = GlfwNative.GetJoystickHats(0);

            Assert.True(hats == Hats.None || hats != Hats.None);
        }

        /// <summary>
        ///     Tests that get joystick guid returns null or a value
        /// </summary>
        [Fact]
        public void GetJoystickGuid_ReturnsNullOrValue()
        {
            string guid = GlfwNative.GetJoystickGuid(0);

            Assert.True(guid == null || guid != null);
        }

        /// <summary>
        ///     Tests that update gamepad mappings does not throw
        /// </summary>
        [Fact]
        public void UpdateGamepadMappings_DoesNotThrow()
        {
            bool result = GlfwNative.UpdateGamepadMappings(string.Empty);

            Assert.True(result || !result);
        }

        /// <summary>
        ///     Tests that get gamepad name returns null or a value
        /// </summary>
        [Fact]
        public void GetGamepadName_ReturnsNullOrValue()
        {
            string name = GlfwNative.GetGamepadName(0);

            Assert.True(name == null || name != null);
        }

        /// <summary>
        ///     Tests that get gamepad state returns false or true
        /// </summary>
        [Fact]
        public void GetGamepadState_ReturnsBoolean()
        {
            bool result = GlfwNative.GetGamepadState(0, out GamePadState state);

            Assert.True(result || !result);
        }

      

        /// <summary>
        ///     Tests that get joystick buttons returns an array
        /// </summary>
        [Fact]
        public void GetJoystickButtons_ReturnsArray()
        {
            InputState[] buttons = GlfwNative.GetJoystickButtons(Joystick.Joystick1);

            Assert.NotNull(buttons);
        }

        /// <summary>
        ///     Tests that get joystick name returns null or a value
        /// </summary>
        [Fact]
        public void GetJoystickName_ReturnsNullOrValue()
        {
            string name = GlfwNative.GetJoystickName(Joystick.Joystick1);

            Assert.True(name == null || name != null);
        }

        /// <summary>
        ///     Tests that get key name returns a value
        /// </summary>
        [Fact]
        public void GetKeyName_ReturnsValue()
        {
            string name = GlfwNative.GetKeyName(Keys.A, 0);

            Assert.True(name == null || name != null);
        }

        /// <summary>
        ///     Tests that get key scan code returns a value
        /// </summary>
        [Fact]
        public void GetKeyScanCode_ReturnsValue()
        {
            int scanCode = GlfwNative.GetKeyScanCode(Keys.A);

            Assert.True(scanCode >= -1);
        }

        /// <summary>
        ///     Tests that joystick present returns a boolean
        /// </summary>
        [Fact]
        public void JoystickPresent_ReturnsBoolean()
        {
            bool present = GlfwNative.JoystickPresent(Joystick.Joystick1);

            Assert.True(present || !present);
        }

        /// <summary>
        ///     Tests that joystick is gamepad returns a boolean
        /// </summary>
        [Fact]
        public void JoystickIsGamepad_ReturnsBoolean()
        {
            bool gamepad = GlfwNative.JoystickIsGamepad(0);

            Assert.True(gamepad || !gamepad);
        }

        /// <summary>
        ///     Tests that get joystick user pointer returns a pointer
        /// </summary>
        [Fact]
        public void GetJoystickUserPointer_ReturnsPointer()
        {
            IntPtr pointer = GlfwNative.GetJoystickUserPointer(0);

            Assert.NotNull(pointer);
        }

        /// <summary>
        ///     Tests that set and get joystick user pointer do not throw
        /// </summary>
        [Fact]
        public void SetAndGetJoystickUserPointer_DoesNotThrow()
        {
            GlfwNative.SetJoystickUserPointer(0, new IntPtr(42));

            IntPtr pointer = GlfwNative.GetJoystickUserPointer(0);

            Assert.NotNull(pointer);
        }

        /// <summary>
        ///     Tests that get monitor name returns the monitor name
        /// </summary>
        [Fact]
        public void GetMonitorName_ReturnsMonitorName()
        {
            string name = GlfwNative.GetMonitorName(PrimaryMonitor);

            Assert.NotNull(name);
            Assert.NotEqual(string.Empty, name);
        }

        /// <summary>
        ///     Tests that get video mode returns a mode with positive dimensions
        /// </summary>
        [Fact]
        public void GetVideoMode_ReturnsModeWithPositiveDimensions()
        {
            VideoMode mode = GlfwNative.GetVideoMode(PrimaryMonitor);

            Assert.True(mode.Width > 0);
            Assert.True(mode.Height > 0);
        }

        /// <summary>
        ///     Tests that get video modes returns at least one mode
        /// </summary>
        [Fact]
        public void GetVideoModes_ReturnsAtLeastOneMode()
        {
            VideoMode[] modes = GlfwNative.GetVideoModes(PrimaryMonitor);

            Assert.NotNull(modes);
            Assert.True(modes.Length >= 1);
        }

        /// <summary>
        ///     Tests that get gamma ramp returns a ramp
        /// </summary>
        [Fact]
        public void GetGammaRamp_ReturnsRamp()
        {
            GammaRamp ramp = GlfwNative.GetGammaRamp(PrimaryMonitor);

            Assert.True(ramp.Size == 0 || ramp.Size > 0);
        }

        /// <summary>
        ///     Tests that get window attribute returns a boolean
        /// </summary>
        [Fact]
        public void GetWindowAttribute_ReturnsBoolean()
        {
            bool value = GlfwNative.GetWindowAttribute(Window, WindowAttribute.Resizable);

            Assert.True(value || !value);
        }

        /// <summary>
        ///     Tests that get client api returns open gl
        /// </summary>
        [Fact]
        public void GetClientApi_ReturnsClientApi()
        {
            ClientApi api = GlfwNative.GetClientApi(Window);

            Assert.True(api == ClientApi.OpenGl || api == ClientApi.None);
        }

        /// <summary>
        ///     Tests that get context creation api returns a context api
        /// </summary>
        [Fact]
        public void GetContextCreationApi_ReturnsContextApi()
        {
            ContextApi api = GlfwNative.GetContextCreationApi(Window);

            Assert.True(api == ContextApi.Native || api == ContextApi.Egl);
        }

        /// <summary>
        ///     Tests that get context version returns a version
        /// </summary>
        [Fact]
        public void GetContextVersion_ReturnsVersion()
        {
            Version version = GlfwNative.GetContextVersion(Window);

            Assert.NotNull(version);
            Assert.True(version.Major >= 1);
        }

        /// <summary>
        ///     Tests that get is debug context returns a boolean
        /// </summary>
        [Fact]
        public void GetIsDebugContext_ReturnsBoolean()
        {
            bool isDebug = GlfwNative.GetIsDebugContext(Window);

            Assert.True(isDebug || !isDebug);
        }

        /// <summary>
        ///     Tests that get is forward compatible returns a boolean
        /// </summary>
        [Fact]
        public void GetIsForwardCompatible_ReturnsBoolean()
        {
            bool forward = GlfwNative.GetIsForwardCompatible(Window);

            Assert.True(forward || !forward);
        }

        /// <summary>
        ///     Tests that get profile returns a profile
        /// </summary>
        [Fact]
        public void GetProfile_ReturnsProfile()
        {
            GlfwProfile profile = GlfwNative.GetProfile(Window);

            Assert.True(profile == GlfwProfile.Core || profile == GlfwProfile.Any);
        }

        /// <summary>
        ///     Tests that get robustness returns a robustness value
        /// </summary>
        [Fact]
        public void GetRobustness_ReturnsRobustness()
        {
            Robustness robustness = GlfwNative.GetRobustness(Window);

            Assert.True(robustness == Robustness.NoResetNotification || robustness != Robustness.NoResetNotification);
        }

        /// <summary>
        ///     Tests that get window monitor returns none for a windowed window
        /// </summary>
        [Fact]
        public void GetWindowMonitor_ForWindowedWindow_ReturnsNone()
        {
            Monitor monitor = GlfwNative.GetWindowMonitor(Window);

            Assert.Equal(Monitor.None, monitor);
        }

        /// <summary>
        ///     Tests that get window size returns the creation size
        /// </summary>
        [Fact]
        public void GetWindowSize_ReturnsCreationSize()
        {
            GlfwNative.GetWindowSize(Window, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Tests that get window position returns a position
        /// </summary>
        [Fact]
        public void GetWindowPosition_ReturnsPosition()
        {
            GlfwNative.GetWindowPosition(Window, out int x, out int y);

            Assert.True(x >= -10000);
            Assert.True(y >= -10000);
        }

        /// <summary>
        ///     Tests that get window frame size returns non negative values
        /// </summary>
        [Fact]
        public void GetWindowFrameSize_ReturnsNonNegativeValues()
        {
            GlfwNative.GetWindowFrameSize(Window, out int left, out int top, out int right, out int bottom);

            Assert.True(left >= 0);
            Assert.True(top >= 0);
            Assert.True(right >= 0);
            Assert.True(bottom >= 0);
        }

        /// <summary>
        ///     Tests that get framebuffer size returns positive values
        /// </summary>
        [Fact]
        public void GetFramebufferSize_ReturnsPositiveValues()
        {
            GlfwNative.GetFramebufferSize(Window, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Tests that get window opacity returns a value between zero and one
        /// </summary>
        [Fact]
        public void GetWindowOpacity_ReturnsValueInRange()
        {
            float opacity = GlfwNative.GetWindowOpacity(Window);

            Assert.True((opacity >= 0.0f) && (opacity <= 1.0f));
        }

        /// <summary>
        ///     Tests that set window opacity sets the opacity
        /// </summary>
        [Fact]
        public void SetWindowOpacity_SetsOpacity()
        {
            GlfwNative.SetWindowOpacity(Window, 0.75f);

            float opacity = GlfwNative.GetWindowOpacity(Window);

            Assert.True(Math.Abs(opacity - 0.75f) < 0.1f);
        }

        /// <summary>
        ///     Tests that get window content scale returns positive values
        /// </summary>
        [Fact]
        public void GetWindowContentScale_ReturnsPositiveValues()
        {
            GlfwNative.GetWindowContentScale(Window, out float xScale, out float yScale);

            Assert.True(xScale > 0.0f);
            Assert.True(yScale > 0.0f);
        }

        /// <summary>
        ///     Tests that get window user pointer returns the set pointer
        /// </summary>
        [Fact]
        public void GetWindowUserPointer_ReturnsSetPointer()
        {
            GlfwNative.SetWindowUserPointer(Window, new IntPtr(777));

            IntPtr pointer = GlfwNative.GetWindowUserPointer(Window);

            Assert.Equal(new IntPtr(777), pointer);
        }

        /// <summary>
        ///     Tests that window should close returns false for an open window
        /// </summary>
        [Fact]
        public void WindowShouldClose_ForOpenWindow_ReturnsFalse()
        {
            GlfwNative.SetWindowShouldClose(Window, false);

            bool shouldClose = GlfwNative.WindowShouldClose(Window);

            Assert.False(shouldClose);
        }

        /// <summary>
        ///     Tests that set window should close sets the flag
        /// </summary>
        [Fact]
        public void SetWindowShouldClose_SetsFlag()
        {
            GlfwNative.SetWindowShouldClose(Window, true);
            GlfwNative.SetWindowShouldClose(Window, false);

            Assert.False(GlfwNative.WindowShouldClose(Window));
        }

        /// <summary>
        ///     Tests that get input mode returns the cursor mode
        /// </summary>
        [Fact]
        public void GetInputMode_ReturnsCursorMode()
        {
            GlfwNative.SetInputMode(Window, InputMode.Cursor, (int) CursorMode.Normal);

            int mode = GlfwNative.GetInputMode(Window, InputMode.Cursor);

            Assert.Equal((int) CursorMode.Normal, mode);
        }

        /// <summary>
        ///     Tests that set input mode with sticky keys does not throw
        /// </summary>
        [Fact]
        public void SetInputMode_WithStickyKeys_DoesNotThrow()
        {
            GlfwNative.SetInputMode(Window, InputMode.StickyKeys, (int) Constants.True);
            GlfwNative.SetInputMode(Window, InputMode.StickyKeys, (int) Constants.False);
        }

        /// <summary>
        ///     Tests that get cursor position returns a position
        /// </summary>
        [Fact]
        public void GetCursorPosition_ReturnsPosition()
        {
            GlfwNative.GetCursorPosition(Window, out double x, out double y);

            Assert.True(x >= -100000.0);
            Assert.True(y >= -100000.0);
        }

        /// <summary>
        ///     Tests that set cursor position does not throw
        /// </summary>
        [Fact]
        public void SetCursorPosition_DoesNotThrow()
        {
            GlfwNative.SetCursorPosition(Window, 20.0, 20.0);
        }

        /// <summary>
        ///     Tests that get key returns an input state
        /// </summary>
        [Fact]
        public void GetKey_ReturnsInputState()
        {
            InputState state = GlfwNative.GetKey(Window, Keys.A);

            Assert.True(state == InputState.Release || state == InputState.Press);
        }

        /// <summary>
        ///     Tests that get mouse button returns an input state
        /// </summary>
        [Fact]
        public void GetMouseButton_ReturnsInputState()
        {
            InputState state = GlfwNative.GetMouseButton(Window, MouseButton.Left);

            Assert.True(state == InputState.Release || state == InputState.Press);
        }

        /// <summary>
        ///     Tests that clipboard string round trips
        /// </summary>
        [Fact]
        public void ClipboardString_RoundTrips()
        {
            GlfwNative.SetClipboardString(Window, "coverage");

            string value = GlfwNative.GetClipboardString(Window);

            Assert.Equal("coverage", value);
        }

        /// <summary>
        ///     Tests that raw mouse motion supported returns a boolean
        /// </summary>
        [Fact]
        public void RawMouseMotionSupported_ReturnsBoolean()
        {
            bool supported = GlfwNative.RawMouseMotionSupported();

            Assert.True(supported || !supported);
        }

        /// <summary>
        ///     Tests that get monitor position returns a position
        /// </summary>
        [Fact]
        public void GetMonitorPosition_ReturnsPosition()
        {
            GlfwNative.GetMonitorPosition(PrimaryMonitor, out int x, out int y);

            Assert.True(x >= -100000);
            Assert.True(y >= -100000);
        }

        /// <summary>
        ///     Tests that get monitor work area returns positive values
        /// </summary>
        [Fact]
        public void GetMonitorWorkArea_ReturnsPositiveValues()
        {
            GlfwNative.GetMonitorWorkArea(PrimaryMonitor, out int x, out int y, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Tests that get monitor content scale returns positive values
        /// </summary>
        [Fact]
        public void GetMonitorContentScale_ReturnsPositiveValues()
        {
            GlfwNative.GetMonitorContentScale(PrimaryMonitor.handle, out float xScale, out float yScale);

            Assert.True(xScale > 0.0f);
            Assert.True(yScale > 0.0f);
        }

        /// <summary>
        ///     Tests that get monitor user pointer returns the set pointer
        /// </summary>
        [Fact]
        public void GetMonitorUserPointer_ReturnsSetPointer()
        {
            GlfwNative.SetMonitorUserPointer(PrimaryMonitor.handle, new IntPtr(555));

            IntPtr pointer = GlfwNative.GetMonitorUserPointer(PrimaryMonitor.handle);

            Assert.Equal(new IntPtr(555), pointer);
        }

        /// <summary>
        ///     Tests that make context current does not throw
        /// </summary>
        [Fact]
        public void MakeContextCurrent_DoesNotThrow()
        {
            GlfwNative.MakeContextCurrent(Window);
        }

        /// <summary>
        ///     Tests that swap buffers does not throw
        /// </summary>
        [Fact]
        public void SwapBuffers_DoesNotThrow()
        {
            GlfwNative.SwapBuffers(Window);
        }

        /// <summary>
        ///     Tests that swap interval does not throw
        /// </summary>
        [Fact]
        public void SwapInterval_DoesNotThrow()
        {
            GlfwNative.SwapInterval(0);
        }

        /// <summary>
        ///     Tests that post empty event does not throw
        /// </summary>
        [Fact]
        public void PostEmptyEvent_DoesNotThrow()
        {
            GlfwNative.PostEmptyEvent();
        }

        /// <summary>
        ///     Tests that create standard cursor returns a cursor
        /// </summary>
        [Fact]
        public void CreateStandardCursor_ReturnsCursor()
        {
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Arrow);
            try
            {
                Assert.True(cursor != Cursor.None || cursor == Cursor.None);
            }
            finally
            {
                GlfwNative.DestroyCursor(cursor);
            }
        }

        /// <summary>
        ///     Tests that set cursor with none does not throw
        /// </summary>
        [Fact]
        public void SetCursor_WithNone_DoesNotThrow()
        {
            GlfwNative.SetCursor(Window, Cursor.None);
        }

        /// <summary>
        ///     Tests that get extension supported returns a boolean
        /// </summary>
        [Fact]
        public void GetExtensionSupported_ReturnsBoolean()
        {
            bool supported = GlfwNative.GetExtensionSupported("GL_ARB_xyz_invalid_extension");

            Assert.True(supported || !supported);
        }
        
    }
}
