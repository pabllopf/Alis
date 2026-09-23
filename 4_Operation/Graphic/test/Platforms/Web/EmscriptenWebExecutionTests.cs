// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWebExecutionTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Execution tests for EmscriptenWeb JavaScript interop static class.
    ///     On non-WebAssembly runtimes all P/Invoke calls to "emscripten"
    ///     throw DllNotFoundException. The wrappers no longer swallow the
    ///     exception, so every public wrapper method propagates the native
    ///     failure to the caller.
    /// </summary>
    public class EmscriptenWebExecutionTests
    {
        /// <summary>
        /// Tests that register keyboard callbacks propagates the native failure
        /// </summary>
        [Fact]
        public void RegisterKeyboardCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register mouse callbacks propagates the native failure
        /// </summary>
        [Fact]
        public void RegisterMouseCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register gamepad callbacks propagates the native failure
        /// </summary>
        [Fact]
        public void RegisterGamepadCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register window callbacks propagates the native failure
        /// </summary>
        [Fact]
        public void RegisterWindowCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that get connected gamepads propagates the native failure
        /// </summary>
        [Fact]
        public void GetConnectedGamepads_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetConnectedGamepads());
        }

        /// <summary>
        /// Tests that get gamepad axes propagates the native failure
        /// </summary>
        [Fact]
        public void GetGamepadAxes_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadAxes(0));
        }

        /// <summary>
        /// Tests that get gamepad buttons propagates the native failure
        /// </summary>
        [Fact]
        public void GetGamepadButtons_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadButtons(0));
        }

        /// <summary>
        /// Tests that show canvas propagates the native failure
        /// </summary>
        [Fact]
        public void ShowCanvas_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowCanvas());
        }

        /// <summary>
        /// Tests that hide canvas propagates the native failure
        /// </summary>
        [Fact]
        public void HideCanvas_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.HideCanvas());
        }

        /// <summary>
        /// Tests that set window title propagates the native failure
        /// </summary>
        [Fact]
        public void SetWindowTitle_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowTitle("Test Title"));
        }

        /// <summary>
        /// Tests that set window title null propagates the native failure
        /// </summary>
        [Fact]
        public void SetWindowTitle_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowTitle(null));
        }

        /// <summary>
        /// Tests that set canvas size propagates the native failure
        /// </summary>
        [Fact]
        public void SetCanvasSize_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetCanvasSize(800, 600));
        }

        /// <summary>
        /// Tests that set window icon propagates the native failure
        /// </summary>
        [Fact]
        public void SetWindowIcon_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
        }

        /// <summary>
        /// Tests that set window icon null propagates the native failure
        /// </summary>
        [Fact]
        public void SetWindowIcon_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowIcon(null));
        }

        /// <summary>
        /// Tests that get window position x propagates the native failure
        /// </summary>
        [Fact]
        public void GetWindowPositionX_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetWindowPositionX());
        }

        /// <summary>
        /// Tests that get window position y propagates the native failure
        /// </summary>
        [Fact]
        public void GetWindowPositionY_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetWindowPositionY());
        }

        /// <summary>
        /// Tests that get device pixel ratio propagates the native failure
        /// </summary>
        [Fact]
        public void GetDevicePixelRatio_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetDevicePixelRatio());
        }

        /// <summary>
        /// Tests that request fullscreen propagates the native failure
        /// </summary>
        [Fact]
        public void RequestFullscreen_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestFullscreen());
        }

        /// <summary>
        /// Tests that exit fullscreen propagates the native failure
        /// </summary>
        [Fact]
        public void ExitFullscreen_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ExitFullscreen());
        }

        /// <summary>
        /// Tests that is fullscreen enabled propagates the native failure
        /// </summary>
        [Fact]
        public void IsFullscreenEnabled_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsFullscreenEnabled());
        }

        /// <summary>
        /// Tests that lock pointer propagates the native failure
        /// </summary>
        [Fact]
        public void LockPointer_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.LockPointer());
        }

        /// <summary>
        /// Tests that unlock pointer propagates the native failure
        /// </summary>
        [Fact]
        public void UnlockPointer_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.UnlockPointer());
        }

        /// <summary>
        /// Tests that is pointer locked propagates the native failure
        /// </summary>
        [Fact]
        public void IsPointerLocked_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsPointerLocked());
        }

        /// <summary>
        /// Tests that vibrate gamepad propagates the native failure
        /// </summary>
        [Fact]
        public void VibrateGamepad_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f));
        }

        /// <summary>
        /// Tests that get system time ms propagates the native failure
        /// </summary>
        [Fact]
        public void GetSystemTimeMs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetSystemTimeMs());
        }

        /// <summary>
        /// Tests that open file dialog propagates the native failure
        /// </summary>
        [Fact]
        public void OpenFileDialog_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog());
        }

        /// <summary>
        /// Tests that open file dialog custom mime propagates the native failure
        /// </summary>
        [Fact]
        public void OpenFileDialog_CustomMime_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog("image/png"));
        }

        /// <summary>
        /// Tests that open file dialog null mime propagates the native failure
        /// </summary>
        [Fact]
        public void OpenFileDialog_NullMime_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog(null));
        }

        /// <summary>
        /// Tests that save file propagates the native failure
        /// </summary>
        [Fact]
        public void SaveFile_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0));
        }

        /// <summary>
        /// Tests that save file with data propagates the native failure
        /// </summary>
        [Fact]
        public void SaveFile_WithData_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("test.bin", new byte[] { 1, 2, 3 }, 3));
        }

        /// <summary>
        /// Tests that save file null data propagates the native failure
        /// </summary>
        [Fact]
        public void SaveFile_NullData_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("file.dat", null, 0));
        }

        /// <summary>
        /// Tests that copy to clipboard propagates the native failure
        /// </summary>
        [Fact]
        public void CopyToClipboard_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.CopyToClipboard("test"));
        }

        /// <summary>
        /// Tests that copy to clipboard null propagates the native failure
        /// </summary>
        [Fact]
        public void CopyToClipboard_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.CopyToClipboard(null));
        }

        /// <summary>
        /// Tests that paste from clipboard propagates the native failure
        /// </summary>
        [Fact]
        public void PasteFromClipboard_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.PasteFromClipboard());
        }

        /// <summary>
        /// Tests that show alert propagates the native failure
        /// </summary>
        [Fact]
        public void ShowAlert_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert("Alert message"));
        }

        /// <summary>
        /// Tests that show alert null propagates the native failure
        /// </summary>
        [Fact]
        public void ShowAlert_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert(null));
        }

        /// <summary>
        /// Tests that show confirm propagates the native failure
        /// </summary>
        [Fact]
        public void ShowConfirm_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm("Confirm?"));
        }

        /// <summary>
        /// Tests that show confirm null propagates the native failure
        /// </summary>
        [Fact]
        public void ShowConfirm_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm(null));
        }

        /// <summary>
        /// Tests that get language propagates the native failure
        /// </summary>
        [Fact]
        public void GetLanguage_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetLanguage());
        }

        /// <summary>
        /// Tests that is online propagates the native failure
        /// </summary>
        [Fact]
        public void IsOnline_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsOnline());
        }

        /// <summary>
        /// Tests that get battery level propagates the native failure
        /// </summary>
        [Fact]
        public void GetBatteryLevel_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetBatteryLevel());
        }

        /// <summary>
        /// Tests that is charging propagates the native failure
        /// </summary>
        [Fact]
        public void IsCharging_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsCharging());
        }

        /// <summary>
        /// Tests that get orientation propagates the native failure
        /// </summary>
        [Fact]
        public void GetOrientation_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetOrientation());
        }

        /// <summary>
        /// Tests that request camera permission propagates the native failure
        /// </summary>
        [Fact]
        public void RequestCameraPermission_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestCameraPermission());
        }

        /// <summary>
        /// Tests that request microphone permission propagates the native failure
        /// </summary>
        [Fact]
        public void RequestMicrophonePermission_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestMicrophonePermission());
        }

        /// <summary>
        /// Tests that console log propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleLog_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleLog("log message"));
        }

        /// <summary>
        /// Tests that console log null propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleLog_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleLog(null));
        }

        /// <summary>
        /// Tests that console warn propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleWarn_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleWarn("warn message"));
        }

        /// <summary>
        /// Tests that console warn null propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleWarn_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleWarn(null));
        }

        /// <summary>
        /// Tests that console error propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleError_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleError("error message"));
        }

        /// <summary>
        /// Tests that console error null propagates the native failure
        /// </summary>
        [Fact]
        public void ConsoleError_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleError(null));
        }
    }
}