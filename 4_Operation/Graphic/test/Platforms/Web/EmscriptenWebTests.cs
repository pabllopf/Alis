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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for EmscriptenWeb JavaScript interop static class.
    ///     On non-WebAssembly runtimes all P/Invoke calls to "emscripten"
    ///     throw DllNotFoundException — these tests verify the catch/fallback
    ///     paths of every public wrapper method.
    /// </summary>
    public class EmscriptenWebTests
    {
        /// <summary>
        /// Tests that register keyboard callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterKeyboardCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register mouse callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterMouseCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register gamepad callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterGamepadCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register window callbacks does not throw
        /// </summary>
        [WebOnly]
        public void RegisterWindowCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that get connected gamepads returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetConnectedGamepads_ReturnsEmptyOnNativeFailure()
        {
            int[] result = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that get gamepad axes returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetGamepadAxes_ReturnsEmptyOnNativeFailure()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that get gamepad buttons returns empty on native failure
        /// </summary>
        [WebOnly]
        public void GetGamepadButtons_ReturnsEmptyOnNativeFailure()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that show canvas does not throw
        /// </summary>
        [WebOnly]
        public void ShowCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowCanvas());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that hide canvas does not throw
        /// </summary>
        [WebOnly]
        public void HideCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.HideCanvas());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window title does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle("Test Title"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window title null does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowTitle_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set canvas size does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(800, 600));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window icon does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window icon null does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that get window position x returns default
        /// </summary>
        [WebOnly]
        public void GetWindowPositionX_ReturnsDefault()
        {
            Assert.Equal(0, EmscriptenWeb.GetWindowPositionX());
        }

        /// <summary>
        /// Tests that get window position y returns default
        /// </summary>
        [WebOnly]
        public void GetWindowPositionY_ReturnsDefault()
        {
            Assert.Equal(0, EmscriptenWeb.GetWindowPositionY());
        }

        /// <summary>
        /// Tests that get device pixel ratio returns default
        /// </summary>
        [WebOnly]
        public void GetDevicePixelRatio_ReturnsDefault()
        {
            Assert.Equal(1.0f, EmscriptenWeb.GetDevicePixelRatio());
        }

        /// <summary>
        /// Tests that request fullscreen returns false
        /// </summary>
        [WebOnly]
        public void RequestFullscreen_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestFullscreen());
        }

        /// <summary>
        /// Tests that exit fullscreen returns false
        /// </summary>
        [WebOnly]
        public void ExitFullscreen_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ExitFullscreen());
        }

        /// <summary>
        /// Tests that is fullscreen enabled returns false
        /// </summary>
        [WebOnly]
        public void IsFullscreenEnabled_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsFullscreenEnabled());
        }

        /// <summary>
        /// Tests that lock pointer returns false
        /// </summary>
        [WebOnly]
        public void LockPointer_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.LockPointer());
        }

        /// <summary>
        /// Tests that unlock pointer returns false
        /// </summary>
        [WebOnly]
        public void UnlockPointer_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.UnlockPointer());
        }

        /// <summary>
        /// Tests that is pointer locked returns false
        /// </summary>
        [WebOnly]
        public void IsPointerLocked_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsPointerLocked());
        }

        /// <summary>
        /// Tests that vibrate gamepad returns false
        /// </summary>
        [WebOnly]
        public void VibrateGamepad_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f));
        }

        /// <summary>
        /// Tests that get system time ms returns default
        /// </summary>
        [WebOnly]
        public void GetSystemTimeMs_ReturnsDefault()
        {
            Assert.Equal(0.0, EmscriptenWeb.GetSystemTimeMs());
        }

        /// <summary>
        /// Tests that open file dialog returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog());
        }

        /// <summary>
        /// Tests that open file dialog custom mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_CustomMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog("image/png"));
        }

        /// <summary>
        /// Tests that open file dialog null mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_NullMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog(null));
        }

        /// <summary>
        /// Tests that save file returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0));
        }

        /// <summary>
        /// Tests that save file with data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_WithData_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("test.bin", new byte[] { 1, 2, 3 }, 3));
        }

        /// <summary>
        /// Tests that save file null filename returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_NullFilename_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile(null, Array.Empty<byte>(), 0));
        }

        /// <summary>
        /// Tests that save file null data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_NullData_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("file.dat", null, 0));
        }

        /// <summary>
        /// Tests that copy to clipboard returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard("test"));
        }

        /// <summary>
        /// Tests that copy to clipboard null returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_Null_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard(null));
        }

        /// <summary>
        /// Tests that copy to clipboard empty returns false
        /// </summary>
        [WebOnly]
        public void CopyToClipboard_Empty_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard(string.Empty));
        }

        /// <summary>
        /// Tests that paste from clipboard returns null
        /// </summary>
        [WebOnly]
        public void PasteFromClipboard_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.PasteFromClipboard());
        }

        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert("Alert message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show alert null does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show confirm returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm("Confirm?"));
        }

        /// <summary>
        /// Tests that show confirm null returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_Null_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(null));
        }

        /// <summary>
        /// Tests that get language returns default
        /// </summary>
        [WebOnly]
        public void GetLanguage_ReturnsDefault()
        {
            Assert.Equal("en", EmscriptenWeb.GetLanguage());
        }

        /// <summary>
        /// Tests that is online returns false
        /// </summary>
        [WebOnly]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsOnline());
        }

        /// <summary>
        /// Tests that get battery level returns default
        /// </summary>
        [WebOnly]
        public void GetBatteryLevel_ReturnsDefault()
        {
            Assert.Equal(-1.0f, EmscriptenWeb.GetBatteryLevel());
        }

        /// <summary>
        /// Tests that is charging returns false
        /// </summary>
        [WebOnly]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsCharging());
        }

        /// <summary>
        /// Tests that get orientation returns default
        /// </summary>
        [WebOnly]
        public void GetOrientation_ReturnsDefault()
        {
            Assert.Equal(1, EmscriptenWeb.GetOrientation());
        }

        /// <summary>
        /// Tests that request camera permission returns false
        /// </summary>
        [WebOnly]
        public void RequestCameraPermission_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestCameraPermission());
        }

        /// <summary>
        /// Tests that request microphone permission returns false
        /// </summary>
        [WebOnly]
        public void RequestMicrophonePermission_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestMicrophonePermission());
        }

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog("log message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console log null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn("warn message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console warn null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError("error message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console error null does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register keyboard callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterKeyboardCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3)));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register mouse callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterMouseCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3), new IntPtr(4)));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register gamepad callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterGamepadCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(new IntPtr(10), new IntPtr(20)));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register window callbacks non default ptrs does not throw
        /// </summary>
        [WebOnly]
        public void RegisterWindowCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(
                    new IntPtr(100), new IntPtr(200), new IntPtr(300)));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that get gamepad axes negative index returns empty
        /// </summary>
        [WebOnly]
        public void GetGamepadAxes_NegativeIndex_ReturnsEmpty()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that get gamepad buttons negative index returns empty
        /// </summary>
        [WebOnly]
        public void GetGamepadButtons_NegativeIndex_ReturnsEmpty()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that vibrate gamepad zero duration returns false
        /// </summary>
        [WebOnly]
        public void VibrateGamepad_ZeroDuration_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.VibrateGamepad(0, 0.0f, 0.0f, 0.0f));
        }

        /// <summary>
        /// Tests that save file large data returns false
        /// </summary>
        [WebOnly]
        public void SaveFile_LargeData_ReturnsFalse()
        {
            byte[] data = new byte[1024 * 1024];
            Assert.False(EmscriptenWeb.SaveFile("large.bin", data, data.Length));
        }

        /// <summary>
        /// Tests that show alert long message does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_LongMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(new string('A', 5000)));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show confirm long message returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_LongMessage_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(new string('A', 1000)));
        }

        /// <summary>
        /// Tests that open file dialog empty mime returns null
        /// </summary>
        [WebOnly]
        public void OpenFileDialog_EmptyMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog(string.Empty));
        }

        /// <summary>
        /// Tests that console log empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console warn empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console error empty does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set canvas size zero does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_Zero_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(0, 0));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set canvas size negative does not throw
        /// </summary>
        [WebOnly]
        public void SetCanvasSize_Negative_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(-1, -1));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window icon empty does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show alert empty does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show confirm empty returns false
        /// </summary>
        [WebOnly]
        public void ShowConfirm_Empty_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(string.Empty));
        }
    }
}
