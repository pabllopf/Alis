// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeExecutionTests.cs
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
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Executes the non-extern wrapper members of <see cref="GlfwNative" /> against the real native GLFW library.
    ///     <para>
    ///         Thread-safe or thread-agnostic bindings are invoked directly on the xUnit worker thread. Window attribute
    ///         reads use the persistent window created by <see cref="GlfwTestBootstrap" /> on the process main thread.
    ///         Main-thread-only operations (clipboard, title) are asserted through the results recorded by
    ///         <see cref="MainThreadNativeWorker" /> at startup. Every test is a harmless no-op when the startup hook was
    ///         not installed (<see cref="GlfwTestBootstrap.Ready" /> is false on CI).
    ///     </para>
    /// </summary>
    public class GlfwNativeExecutionTests
    {
        /// <summary>
        ///     The invalid joystick identifier used to probe the no-device code paths.
        /// </summary>
        private const int InvalidJoystickId = 999;

        /// <summary>
        ///     Tests that the compiled version of the native library is three or newer.
        /// </summary>
        [RequireGlfwFact]
        public void Version_Get_IsThreeOrNewer()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Version version = GlfwNative.Version;
            Assert.True(version.Major >= 3);
        }

        /// <summary>
        ///     Tests that the compile-time generated version string of the native library is not empty.
        /// </summary>
        [RequireGlfwFact]
        public void VersionString_Get_IsNotEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            string versionString = GlfwNative.VersionString;
            Assert.NotEmpty(versionString);
        }

        /// <summary>
        ///     Tests that the GLFW timer reports a non-negative value.
        /// </summary>
        [RequireGlfwFact]
        public void Time_Get_IsNonNegative()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            double time = GlfwNative.Time;
            Assert.True(time >= 0.0);
        }

        /// <summary>
        ///     Tests that the timer can be set and read back on the same thread.
        /// </summary>
        [RequireGlfwFact]
        public void Time_SetThenGet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.Time = 1.5;
            double time = GlfwNative.Time;
            Assert.True(time >= 1.4 && time <= 1.6);
        }

        /// <summary>
        ///     Tests that the raw timer frequency is positive.
        /// </summary>
        [RequireGlfwFact]
        public void TimerFrequency_Get_IsPositive()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            ulong frequency = GlfwNative.TimerFrequency;
            Assert.True(frequency > 0);
        }

        /// <summary>
        ///     Tests that the raw timer value can be read without an exception.
        /// </summary>
        [RequireGlfwFact]
        public void TimerValue_Get_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            ulong value = GlfwNative.TimerValue;
            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that the error query clears and returns the none code on a clean thread.
        /// </summary>
        [RequireGlfwFact]
        public void GetError_CleanThread_ReturnsNone()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            ErrorCode code = GlfwNative.GetError(out string description);
            Assert.Equal(ErrorCode.None, code);
            Assert.Null(description);
        }

        /// <summary>
        ///     Tests that an invalid native hint produces a pending error that the query returns with a description.
        /// </summary>
        [RequireGlfwFact]
        public void GetError_AfterInvalidHint_ReturnsDescription()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHintStringUTF8((Hint) 0xFFFF, "invalid-hint");
            ErrorCode code = GlfwNative.GetError(out string description);
            Assert.NotEqual(ErrorCode.None, code);
            Assert.NotNull(description);
        }

        /// <summary>
        ///     Tests that the monitor enumeration returns at least one connected monitor.
        /// </summary>
        [RequireGlfwFact]
        public void Monitors_Get_IsNotEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Monitor[] monitors = GlfwNative.Monitors;
            Assert.NotEmpty(monitors);
        }

        /// <summary>
        ///     Tests that the primary monitor handle is valid.
        /// </summary>
        [RequireGlfwFact]
        public void PrimaryMonitor_Get_IsNotNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Monitor monitor = GlfwNative.PrimaryMonitor;
            Assert.NotEqual(Monitor.None, monitor);
        }

        /// <summary>
        ///     Tests that the current context query does not throw on the worker thread.
        /// </summary>
        [RequireGlfwFact]
        public void CurrentContext_Get_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            _ = GlfwNative.CurrentContext;
        }

        /// <summary>
        ///     Tests that the joystick hats query for a missing device returns no hats.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickHats_MissingDevice_ReturnsNone()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Hats hats = GlfwNative.GetJoystickHats(InvalidJoystickId);
            Assert.Equal(Hats.None, hats);
        }

        /// <summary>
        ///     Tests that the joystick GUID query for a missing device returns null.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickGuid_MissingDevice_ReturnsNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            string guid = GlfwNative.GetJoystickGuid(InvalidJoystickId);
            Assert.Null(guid);
        }

        /// <summary>
        ///     Tests that the gamepad name query for a missing device returns null.
        /// </summary>
        [RequireGlfwFact]
        public void GetGamepadName_MissingDevice_ReturnsNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            string name = GlfwNative.GetGamepadName(InvalidJoystickId);
            Assert.Null(name);
        }

        /// <summary>
        ///     Tests that parsing an empty mappings string does not crash.
        /// </summary>
        [RequireGlfwFact]
        public void UpdateGamepadMappings_EmptyString_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.UpdateGamepadMappings("");
        }

        /// <summary>
        ///     Tests that parsing a malformed mappings string fails without crashing.
        /// </summary>
        [RequireGlfwFact]
        public void UpdateGamepadMappings_MalformedString_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.UpdateGamepadMappings("not-a-gamepad-mapping");
        }

        /// <summary>
        ///     Tests that a UTF-8 window string hint can be set and reset without an exception.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHintStringUTF8_CocoaFrameName_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHintStringUTF8(Hint.CocoaFrameName, "alis-frame-name");
            GlfwNative.WindowHintStringUTF8(Hint.CocoaFrameName, "");
        }

        /// <summary>
        ///     Tests that an ASCII window string hint can be set and reset without an exception.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHintStringASCII_CocoaFrameName_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHintStringASCII(Hint.CocoaFrameName, "alis-frame-name");
            GlfwNative.WindowHintStringASCII(Hint.CocoaFrameName, "");
        }

        /// <summary>
        ///     Tests that the boolean window hint wrapper accepts a default value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_Bool_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.Focused, true);
        }

        /// <summary>
        ///     Tests that the client API window hint wrapper accepts the default value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_ClientApi_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.ClientApi, ClientApi.OpenGl);
        }

        /// <summary>
        ///     Tests that the constants window hint wrapper accepts the no preference value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_Constants_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.Samples, Constants.Default);
        }

        /// <summary>
        ///     Tests that the context creation API window hint wrapper accepts the default value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_ContextApi_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.ContextCreationApi, ContextApi.Native);
        }

        /// <summary>
        ///     Tests that the robustness window hint wrapper accepts the default value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_Robustness_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.ContextRobustness, Robustness.None);
        }

        /// <summary>
        ///     Tests that the profile window hint wrapper accepts the value used by the bootstrap window.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_GlfwProfile_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
        }

        /// <summary>
        ///     Tests that the release behavior window hint wrapper accepts the default value.
        /// </summary>
        [RequireGlfwFact]
        public void WindowHint_ReleaseBehavior_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.ContextReleaseBehavior, ReleaseBehavior.Any);
        }

        /// <summary>
        ///     Tests that the client API attribute of the bootstrap window reports the OpenGL API.
        /// </summary>
        [RequireGlfwFact]
        public void GetClientApi_BootstrapWindow_ReturnsOpenGl()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            ClientApi api = GlfwNative.GetClientApi(window);
            Assert.Equal(ClientApi.OpenGl, api);
        }

        /// <summary>
        ///     Tests that the context creation API attribute of the bootstrap window reports the native API.
        /// </summary>
        [RequireGlfwFact]
        public void GetContextCreationApi_BootstrapWindow_ReturnsNative()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            ContextApi api = GlfwNative.GetContextCreationApi(window);
            Assert.Equal(ContextApi.Native, api);
        }

        /// <summary>
        ///     Tests that the context version attribute of the bootstrap window reports version 3.3.
        /// </summary>
        [RequireGlfwFact]
        public void GetContextVersion_BootstrapWindow_ReturnsThreeThree()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            Version version = GlfwNative.GetContextVersion(window);
            Assert.True(version.Major >= 3);
        }

        /// <summary>
        ///     Tests that the debug context attribute of the bootstrap window is disabled.
        /// </summary>
        [RequireGlfwFact]
        public void GetIsDebugContext_BootstrapWindow_IsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            bool debug = GlfwNative.GetIsDebugContext(window);
            Assert.False(debug);
        }

        /// <summary>
        ///     Tests that the forward compatible attribute of the bootstrap window is enabled.
        /// </summary>
        [RequireGlfwFact]
        public void GetIsForwardCompatible_BootstrapWindow_IsTrue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            bool forwardCompatible = GlfwNative.GetIsForwardCompatible(window);
            Assert.True(forwardCompatible);
        }

        /// <summary>
        ///     Tests that the profile attribute of the bootstrap window reports the core profile.
        /// </summary>
        [RequireGlfwFact]
        public void GetProfile_BootstrapWindow_ReturnsCore()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            GlfwProfile profile = GlfwNative.GetProfile(window);
            Assert.Equal(GlfwProfile.Core, profile);
        }

        /// <summary>
        ///     Tests that the robustness attribute of the bootstrap window reports no robustness.
        /// </summary>
        [RequireGlfwFact]
        public void GetRobustness_BootstrapWindow_ReturnsNone()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            Robustness robustness = GlfwNative.GetRobustness(window);
            Assert.Equal(Robustness.None, robustness);
        }

        /// <summary>
        ///     Tests that the decorated attribute of the bootstrap window is enabled.
        /// </summary>
        [RequireGlfwFact]
        public void GetWindowAttribute_BootstrapWindow_DecoratedIsTrue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            bool decorated = GlfwNative.GetWindowAttribute(window, WindowAttribute.Decorated);
            Assert.True(decorated);
        }

        /// <summary>
        ///     Tests that the clipboard recorded by the main thread worker round trips the set value.
        /// </summary>
        [RequireGlfwFact]
        public void GetClipboardString_MainThreadWorker_RecordedValue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal("alis-clip", MainThreadNativeWorker.ClipboardResult);
        }

        /// <summary>
        ///     Tests that the title recorded by the main thread worker round trips the set value.
        /// </summary>
        [RequireGlfwFact]
        public void SetWindowTitle_MainThreadWorker_RecordedValue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal("exec-title", MainThreadNativeWorker.TitleResult);
        }

        /// <summary>
        ///     Tests that the joystick axes query for a missing device returns an empty array.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickAxes_MissingDevice_ReturnsEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            float[] axes = GlfwNative.GetJoystickAxes((Joystick) InvalidJoystickId);
            Assert.Empty(axes);
        }

        /// <summary>
        ///     Tests that the joystick buttons query for a missing device returns an empty array.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickButtons_MissingDevice_ReturnsEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            InputState[] states = GlfwNative.GetJoystickButtons((Joystick) InvalidJoystickId);
            Assert.Empty(states);
        }

        /// <summary>
        ///     Tests that the joystick name query for a missing device returns an empty string.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickName_MissingDevice_ReturnsEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            string name = GlfwNative.GetJoystickName((Joystick) InvalidJoystickId);
            Assert.Equal("", name);
        }

        /// <summary>
        ///     Tests that the joystick state queries do not crash when a device is actually present. It is a no-op on
        ///     machines without a connected joystick.
        /// </summary>
        [RequireGlfwFact]
        public void GetJoystickState_PresentDevice_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            if (!GlfwNative.JoystickPresent(Joystick.Joystick1))
            {
                return;
            }

            GlfwNative.GetJoystickHats(0);
            GlfwNative.GetJoystickAxes(Joystick.Joystick1);
            GlfwNative.GetJoystickButtons(Joystick.Joystick1);
            GlfwNative.GetJoystickGuid(0);
            GlfwNative.GetJoystickName(Joystick.Joystick1);
        }

        /// <summary>
        ///     Tests that the key name query for an unknown key does not crash.
        /// </summary>
        [RequireGlfwFact]
        public void GetKeyName_UnknownKey_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.GetKeyName(Keys.Unknown, 0);
        }

        /// <summary>
        ///     Tests that the extension support query does not crash without a current context.
        /// </summary>
        [RequireGlfwFact]
        public void GetExtensionSupported_NoCurrentContext_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.GetExtensionSupported("GL_ARB_multisample");
        }

        /// <summary>
        ///     Tests that a function address can be resolved from the native library.
        /// </summary>
        [RequireGlfwFact]
        public void GetProcAddress_KnownFunction_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwNative.GetProcAddress("glfwGetTime");
        }

        /// <summary>
        ///     Tests that the primary monitor name is not empty.
        /// </summary>
        [RequireGlfwFact]
        public void GetMonitorName_PrimaryMonitor_IsNotEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            string name = GlfwNative.GetMonitorName(GlfwTestBootstrap.PrimaryMonitor);
            Assert.NotEmpty(name);
        }

        /// <summary>
        ///     Tests that the current video mode of the primary monitor reports a positive width.
        /// </summary>
        [RequireGlfwFact]
        public void GetVideoMode_PrimaryMonitor_WidthIsPositive()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            VideoMode mode = GlfwNative.GetVideoMode(GlfwTestBootstrap.PrimaryMonitor);
            Assert.True(mode.Width > 0);
        }

        /// <summary>
        ///     Tests that the supported video modes of the primary monitor are not empty.
        /// </summary>
        [RequireGlfwFact]
        public void GetVideoModes_PrimaryMonitor_IsNotEmpty()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            VideoMode[] modes = GlfwNative.GetVideoModes(GlfwTestBootstrap.PrimaryMonitor);
            Assert.NotEmpty(modes);
        }

        /// <summary>
        ///     Tests that the gamma ramp of the primary monitor can be read.
        /// </summary>
        [RequireGlfwFact]
        public void GetGammaRamp_PrimaryMonitor_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GammaRamp ramp = GlfwNative.GetGammaRamp(GlfwTestBootstrap.PrimaryMonitor);
            Assert.True(ramp.Red != null && ramp.Green != null && ramp.Blue != null);
        }

        /// <summary>
        ///     Tests that the internal gamma ramp pointer of the primary monitor is valid.
        /// </summary>
        [RequireGlfwFact]
        public void GetGammaRampInternal_PrimaryMonitor_IsNotNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            IntPtr pointer = GlfwNative.GetGammaRampInternal(GlfwTestBootstrap.PrimaryMonitor);
            Assert.NotEqual(IntPtr.Zero, pointer);
        }
    }
}
