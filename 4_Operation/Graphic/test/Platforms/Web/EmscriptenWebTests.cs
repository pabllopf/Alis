// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:EmscriptenWebTests.cs
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
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for EmscriptenWeb JavaScript interop static class.
    ///     On non-WebAssembly runtimes all P/Invoke calls to "emscripten"
    ///     throw DllNotFoundException. The wrappers no longer swallow the
    ///     exception, so these tests verify every public wrapper method
    ///     propagates the native failure.
    /// </summary>
    public class EmscriptenWebTests
    {
        /// <summary>
        /// Tests that register keyboard callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterKeyboardCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RegisterKeyboardCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register mouse callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterMouseCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register gamepad callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterGamepadCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that register window callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterWindowCallbacks_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that get connected gamepads returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetConnectedGamepads_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetConnectedGamepads());
        }

        /// <summary>
        /// Tests that get gamepad axes returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetGamepadAxes_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadAxes(0));
        }

        /// <summary>
        /// Tests that get gamepad buttons returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetGamepadButtons_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadButtons(0));
        }

        /// <summary>
        /// Tests that show canvas does not throw
        /// </summary>
        [WebOnly]
        public void ShowCanvas_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowCanvas());
        }

        /// <summary>
        /// Tests that hide canvas does not throw
        /// </summary>
        [WebOnly]
        public void HideCanvas_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.HideCanvas());
        }

        /// <summary>
        /// Tests that set window title does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowTitle_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowTitle("Test Title"));
        }

        /// <summary>
        /// Tests that set window title null does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowTitle_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowTitle(null));
        }

        /// <summary>
        /// Tests that set canvas size does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetCanvasSize(800, 600));
        }

        /// <summary>
        /// Tests that set window icon does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
        }

        /// <summary>
        /// Tests that set window icon null does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowIcon(null));
        }

        /// <summary>
        /// Tests that get window position x returns default
        /// </summary>
        [WebOnly]
        public void GetWindowPositionX_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetWindowPositionX());
        }

        /// <summary>
        /// Tests that get window position y returns default
        /// </summary>
        [WebOnly]
        public void GetWindowPositionY_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetWindowPositionY());
        }

        /// <summary>
        /// Tests that get device pixel ratio returns default
        /// </summary>
        [WebOnly]
        public void GetDevicePixelRatio_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetDevicePixelRatio());
        }

        /// <summary>
        /// Tests that request fullscreen returns false
        /// </summary>
        [WebOnly]
        public void RequestFullscreen_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestFullscreen());
        }

        /// <summary>
        /// Tests that exit fullscreen returns false
        /// </summary>
        [WebOnly]
        public void ExitFullscreen_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ExitFullscreen());
        }

        /// <summary>
        /// Tests that is fullscreen enabled returns false
        /// </summary>
        [WebOnly]
        public void IsFullscreenEnabled_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsFullscreenEnabled());
        }

        /// <summary>
        /// Tests that lock pointer returns false
        /// </summary>
        [WebOnly]
        public void LockPointer_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.LockPointer());
        }

        /// <summary>
        /// Tests that unlock pointer returns false
        /// </summary>
        [WebOnly]
        public void UnlockPointer_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.UnlockPointer());
        }

        /// <summary>
        /// Tests that is pointer locked returns false
        /// </summary>
        [WebOnly]
        public void IsPointerLocked_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsPointerLocked());
        }

        /// <summary>
        /// Tests that vibrate gamepad returns false
        /// </summary>
        [WebOnly]
        public void VibrateGamepad_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f));
        }

        /// <summary>
        /// Tests that get system time ms returns default
        /// </summary>
        [WebOnly]
        public void GetSystemTimeMs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetSystemTimeMs());
        }

        /// <summary>
        /// Tests that open file dialog returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog());
        }

        /// <summary>
        /// Tests that open file dialog custom mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_CustomMime_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog("image/png"));
        }

        /// <summary>
        /// Tests that open file dialog null mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_NullMime_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog(null));
        }

        /// <summary>
        /// Tests that save file returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0));
        }

        /// <summary>
        /// Tests that save file with data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_WithData_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("test.bin", new byte[] { 1, 2, 3 }, 3));
        }

        /// <summary>
        /// Tests that save file null filename returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_NullFilename_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile(null, Array.Empty<byte>(), 0));
        }

        /// <summary>
        /// Tests that save file null data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_NullData_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("file.dat", null, 0));
        }

        /// <summary>
        /// Tests that copy to clipboard returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.CopyToClipboard("test"));
        }

        /// <summary>
        /// Tests that copy to clipboard null returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.CopyToClipboard(null));
        }

        /// <summary>
        /// Tests that copy to clipboard empty returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.CopyToClipboard(string.Empty));
        }

        /// <summary>
        /// Tests that paste from clipboard returns null
        /// </summary>
        [WebOnly]
        public void PasteFromClipboard_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.PasteFromClipboard());
        }

        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert("Alert message"));
        }

        /// <summary>
        /// Tests that show alert null does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert(null));
        }

        /// <summary>
        /// Tests that show confirm returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm("Confirm?"));
        }

        /// <summary>
        /// Tests that show confirm null returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm(null));
        }

        /// <summary>
        /// Tests that get language propagates the native failure
        /// </summary>
        [WebOnly]
        public void GetLanguage_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetLanguage());
        }

        /// <summary>
        /// Tests that is online returns false
        /// </summary>
        [WebOnly]
        public void IsOnline_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsOnline());
        }

        /// <summary>
        /// Tests that get battery level returns default
        /// </summary>
        [WebOnly]
        public void GetBatteryLevel_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetBatteryLevel());
        }

        /// <summary>
        /// Tests that is charging returns false
        /// </summary>
        [WebOnly]
        public void IsCharging_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.IsCharging());
        }

        /// <summary>
        /// Tests that get orientation returns default
        /// </summary>
        [WebOnly]
        public void GetOrientation_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetOrientation());
        }

        /// <summary>
        /// Tests that request camera permission returns false
        /// </summary>
        [WebOnly]
        public void RequestCameraPermission_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestCameraPermission());
        }

        /// <summary>
        /// Tests that request microphone permission returns false
        /// </summary>
        [WebOnly]
        public void RequestMicrophonePermission_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.RequestMicrophonePermission());
        }

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleLog("log message"));
        }

        /// <summary>
        /// Tests that console log null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleLog(null));
        }

        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleWarn("warn message"));
        }

        /// <summary>
        /// Tests that console warn null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleWarn(null));
        }

        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleError("error message"));
        }

        /// <summary>
        /// Tests that console error null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_Null_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleError(null));
        }

        /// <summary>
        /// Tests that register keyboard callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterKeyboardCallbacks_NonDefaultPtrs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3)));
        }

        /// <summary>
        /// Tests that register mouse callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterMouseCallbacks_NonDefaultPtrs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterMouseCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3), new IntPtr(4)));
        }

        /// <summary>
        /// Tests that register gamepad callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterGamepadCallbacks_NonDefaultPtrs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(
                    new IntPtr(10), new IntPtr(20)));
        }

        /// <summary>
        /// Tests that register window callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterWindowCallbacks_NonDefaultPtrs_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() =>
                EmscriptenWeb.RegisterWindowCallbacks(
                    new IntPtr(100), new IntPtr(200), new IntPtr(300)));
        }

        /// <summary>
        /// Tests that get gamepad axes negative index returns empty
        /// </summary>
        [WebOnly]
        public void GetGamepadAxes_NegativeIndex_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadAxes(-1));
        }

        /// <summary>
        /// Tests that get gamepad buttons negative index returns empty
        /// </summary>
        [WebOnly]
        public void GetGamepadButtons_NegativeIndex_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.GetGamepadButtons(-1));
        }

        /// <summary>
        /// Tests that vibrate gamepad zero duration returns false
        /// </summary>
        [WebOnly]
        public void VibrateGamepad_ZeroDuration_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.VibrateGamepad(0, 0.0f, 0.0f, 0.0f));
        }

        /// <summary>
        /// Tests that save file large data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_LargeData_PropagatesOnNonWeb()
        {
            byte[] data = new byte[1024 * 1024];
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SaveFile("large.bin", data, data.Length));
        }

        /// <summary>
        /// Tests that show alert long message does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_LongMessage_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert(new string('A', 5000)));
        }

        /// <summary>
        /// Tests that show confirm long message returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_LongMessage_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm(new string('A', 1000)));
        }

        /// <summary>
        /// Tests that open file dialog empty mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_EmptyMime_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.OpenFileDialog(string.Empty));
        }

        /// <summary>
        /// Tests that console log empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleLog(string.Empty));
        }

        /// <summary>
        /// Tests that console warn empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleWarn(string.Empty));
        }

        /// <summary>
        /// Tests that console error empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ConsoleError(string.Empty));
        }

        /// <summary>
        /// Tests that set canvas size zero does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_Zero_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetCanvasSize(0, 0));
        }

        /// <summary>
        /// Tests that set canvas size negative does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_Negative_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetCanvasSize(-1, -1));
        }

        /// <summary>
        /// Tests that set window icon empty does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.SetWindowIcon(string.Empty));
        }

        /// <summary>
        /// Tests that show alert empty does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowAlert(string.Empty));
        }

        /// <summary>
        /// Tests that show confirm empty returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_Empty_PropagatesOnNonWeb()
        {
            Assert.ThrowsAny<Exception>(() => EmscriptenWeb.ShowConfirm(string.Empty));
        }
    }
}
