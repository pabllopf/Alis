// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWebRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for EmscriptenWeb.
    ///     Since the native "emscripten" library is unavailable on non-WebAssembly
    ///     runtimes, all DllImport calls throw DllNotFoundException / EntryPointNotFoundException.
    ///     These tests verify the catch / fallback paths of every public wrapper method.
    /// </summary>
    public class EmscriptenWebRemainingCoverageTests
    {
        // =====================================================================
        // RegisterKeyboardCallbacks
        // =====================================================================

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

        // =====================================================================
        // RegisterMouseCallbacks
        // =====================================================================

        /// <summary>
        /// Tests that register mouse callbacks does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterMouseCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterGamepadCallbacks
        // =====================================================================

        /// <summary>
        /// Tests that register gamepad callbacks does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterGamepadCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterWindowCallbacks
        // =====================================================================

        /// <summary>
        /// Tests that register window callbacks does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterWindowCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // GetConnectedGamepads
        // =====================================================================

        /// <summary>
        /// Tests that get connected gamepads returns empty array on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetConnectedGamepads_ReturnsEmptyArrayOnNativeFailure()
        {
            int[] result = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadAxes
        // =====================================================================

        /// <summary>
        /// Tests that get gamepad axes returns empty array on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadAxes_ReturnsEmptyArrayOnNativeFailure()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadButtons
        // =====================================================================

        /// <summary>
        /// Tests that get gamepad buttons returns empty array on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadButtons_ReturnsEmptyArrayOnNativeFailure()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // ShowCanvas
        // =====================================================================

        /// <summary>
        /// Tests that show canvas does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowCanvas());
            Assert.Null(ex);
        }

        // =====================================================================
        // HideCanvas
        // =====================================================================

        /// <summary>
        /// Tests that hide canvas does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void HideCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.HideCanvas());
            Assert.Null(ex);
        }

        // =====================================================================
        // SetWindowTitle
        // =====================================================================

        /// <summary>
        /// Tests that set window title does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetWindowTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle("Test Title"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window title null title does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetWindowTitle_NullTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // SetCanvasSize
        // =====================================================================

        /// <summary>
        /// Tests that set canvas size does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetCanvasSize_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(800, 600));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set canvas size zero dimensions does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetCanvasSize_ZeroDimensions_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(0, 0));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set canvas size negative dimensions does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetCanvasSize_NegativeDimensions_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(-1, -1));
            Assert.Null(ex);
        }

        // =====================================================================
        // SetWindowIcon
        // =====================================================================

        /// <summary>
        /// Tests that set window icon does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetWindowIcon_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window icon null path does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetWindowIcon_NullPath_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that set window icon empty path does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // GetWindowPositionX
        // =====================================================================

        /// <summary>
        /// Tests that get window position x returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetWindowPositionX_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetWindowPositionX();
            Assert.Equal(0, result);
        }

        // =====================================================================
        // GetWindowPositionY
        // =====================================================================

        /// <summary>
        /// Tests that get window position y returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetWindowPositionY_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetWindowPositionY();
            Assert.Equal(0, result);
        }

        // =====================================================================
        // GetDevicePixelRatio
        // =====================================================================

        /// <summary>
        /// Tests that get device pixel ratio returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetDevicePixelRatio_ReturnsDefaultOnNativeFailure()
        {
            float result = EmscriptenWeb.GetDevicePixelRatio();
            Assert.Equal(1.0f, result);
        }

        // =====================================================================
        // RequestFullscreen
        // =====================================================================

        /// <summary>
        /// Tests that request fullscreen returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void RequestFullscreen_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestFullscreen();
            Assert.False(result);
        }

        // =====================================================================
        // ExitFullscreen
        // =====================================================================

        /// <summary>
        /// Tests that exit fullscreen returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void ExitFullscreen_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.ExitFullscreen();
            Assert.False(result);
        }

        // =====================================================================
        // IsFullscreenEnabled
        // =====================================================================

        /// <summary>
        /// Tests that is fullscreen enabled returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void IsFullscreenEnabled_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsFullscreenEnabled();
            Assert.False(result);
        }

        // =====================================================================
        // LockPointer
        // =====================================================================

        /// <summary>
        /// Tests that lock pointer returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void LockPointer_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.LockPointer();
            Assert.False(result);
        }

        // =====================================================================
        // UnlockPointer
        // =====================================================================

        /// <summary>
        /// Tests that unlock pointer returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void UnlockPointer_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.UnlockPointer();
            Assert.False(result);
        }

        // =====================================================================
        // IsPointerLocked
        // =====================================================================

        /// <summary>
        /// Tests that is pointer locked returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void IsPointerLocked_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsPointerLocked();
            Assert.False(result);
        }

        // =====================================================================
        // VibrateGamepad
        // =====================================================================

        /// <summary>
        /// Tests that vibrate gamepad returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that vibrate gamepad negative index returns false
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_NegativeIndex_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(-1, 1.0f, 1.0f, 50.0f);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that vibrate gamepad zero duration returns false
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_ZeroDuration_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(0, 0.0f, 0.0f, 0.0f);
            Assert.False(result);
        }

        // =====================================================================
        // GetSystemTimeMs
        // =====================================================================

        /// <summary>
        /// Tests that get system time ms returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetSystemTimeMs_ReturnsDefaultOnNativeFailure()
        {
            double result = EmscriptenWeb.GetSystemTimeMs();
            Assert.Equal(0.0, result);
        }

        // =====================================================================
        // OpenFileDialog
        // =====================================================================

        /// <summary>
        /// Tests that open file dialog default mime returns null on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_DefaultMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog();
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that open file dialog custom mime returns null on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_CustomMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog("image/png,image/jpeg");
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that open file dialog null mime returns null on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_NullMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog(null);
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that open file dialog empty mime returns null on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_EmptyMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog(string.Empty);
            Assert.Null(result);
        }

        // =====================================================================
        // SaveFile
        // =====================================================================

        /// <summary>
        /// Tests that save file returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void SaveFile_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that save file with data returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void SaveFile_WithData_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.SaveFile("test.bin", new byte[] { 0x01, 0x02, 0x03 }, 3);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that save file null filename returns false
        /// </summary>
        [WebOnlyAttribute]
        public void SaveFile_NullFilename_ReturnsFalse()
        {
            bool result = EmscriptenWeb.SaveFile(null, Array.Empty<byte>(), 0);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that save file null data returns false
        /// </summary>
        [WebOnlyAttribute]
        public void SaveFile_NullData_ReturnsFalse()
        {
            bool result = EmscriptenWeb.SaveFile("file.dat", null, 0);
            Assert.False(result);
        }

        // =====================================================================
        // CopyToClipboard
        // =====================================================================

        /// <summary>
        /// Tests that copy to clipboard returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void CopyToClipboard_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.CopyToClipboard("test text");
            Assert.False(result);
        }

        /// <summary>
        /// Tests that copy to clipboard null text returns false
        /// </summary>
        [WebOnlyAttribute]
        public void CopyToClipboard_NullText_ReturnsFalse()
        {
            bool result = EmscriptenWeb.CopyToClipboard(null);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that copy to clipboard empty text returns false
        /// </summary>
        [WebOnlyAttribute]
        public void CopyToClipboard_EmptyText_ReturnsFalse()
        {
            bool result = EmscriptenWeb.CopyToClipboard(string.Empty);
            Assert.False(result);
        }

        // =====================================================================
        // PasteFromClipboard
        // =====================================================================

        /// <summary>
        /// Tests that paste from clipboard returns null on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void PasteFromClipboard_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.PasteFromClipboard();
            Assert.Null(result);
        }

        // =====================================================================
        // ShowAlert
        // =====================================================================

        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert("Alert message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show alert null message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that show alert empty message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // ShowConfirm
        // =====================================================================

        /// <summary>
        /// Tests that show confirm returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.ShowConfirm("Confirm?");
            Assert.False(result);
        }

        /// <summary>
        /// Tests that show confirm null message returns false
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_NullMessage_ReturnsFalse()
        {
            bool result = EmscriptenWeb.ShowConfirm(null);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that show confirm empty message returns false
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_EmptyMessage_ReturnsFalse()
        {
            bool result = EmscriptenWeb.ShowConfirm(string.Empty);
            Assert.False(result);
        }

        // =====================================================================
        // GetLanguage
        // =====================================================================

        /// <summary>
        /// Tests that get language returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetLanguage_ReturnsDefaultOnNativeFailure()
        {
            string result = EmscriptenWeb.GetLanguage();
            Assert.Equal("en", result);
        }

        // =====================================================================
        // IsOnline
        // =====================================================================

        /// <summary>
        /// Tests that is online returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void IsOnline_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsOnline();
            Assert.False(result);
        }

        // =====================================================================
        // GetBatteryLevel
        // =====================================================================

        /// <summary>
        /// Tests that get battery level returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetBatteryLevel_ReturnsDefaultOnNativeFailure()
        {
            float result = EmscriptenWeb.GetBatteryLevel();
            Assert.Equal(-1.0f, result);
        }

        // =====================================================================
        // IsCharging
        // =====================================================================

        /// <summary>
        /// Tests that is charging returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void IsCharging_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsCharging();
            Assert.False(result);
        }

        // =====================================================================
        // GetOrientation
        // =====================================================================

        /// <summary>
        /// Tests that get orientation returns default on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void GetOrientation_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetOrientation();
            Assert.Equal(1, result);
        }

        // =====================================================================
        // RequestCameraPermission
        // =====================================================================

        /// <summary>
        /// Tests that request camera permission returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void RequestCameraPermission_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestCameraPermission();
            Assert.False(result);
        }

        // =====================================================================
        // RequestMicrophonePermission
        // =====================================================================

        /// <summary>
        /// Tests that request microphone permission returns false on native failure
        /// </summary>
        [WebOnlyAttribute]
        public void RequestMicrophonePermission_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestMicrophonePermission();
            Assert.False(result);
        }

        // =====================================================================
        // ConsoleLog
        // =====================================================================

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog("log message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console log null message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // ConsoleWarn
        // =====================================================================

        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleWarn_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn("warn message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console warn null message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleWarn_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // ConsoleError
        // =====================================================================

        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleError_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError("error message"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console error null message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleError_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterKeyboardCallbacks Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that register keyboard callbacks all non default int ptr does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterKeyboardCallbacks_AllNonDefaultIntPtr_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(
                    new IntPtr(123), new IntPtr(456), new IntPtr(789)));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterMouseCallbacks Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that register mouse callbacks all non default int ptr does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterMouseCallbacks_AllNonDefaultIntPtr_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3), new IntPtr(4)));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterGamepadCallbacks Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that register gamepad callbacks all non default int ptr does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterGamepadCallbacks_AllNonDefaultIntPtr_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(new IntPtr(10), new IntPtr(20)));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterWindowCallbacks Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that register window callbacks all non default int ptr does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void RegisterWindowCallbacks_AllNonDefaultIntPtr_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(
                    new IntPtr(100), new IntPtr(200), new IntPtr(300)));
            Assert.Null(ex);
        }

        // =====================================================================
        // GetGamepadAxes Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that get gamepad axes multiple indices all return empty
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadAxes_MultipleIndices_AllReturnEmpty()
        {
            for (int i = 0; i < 4; i++)
            {
                float[] result = EmscriptenWeb.GetGamepadAxes(i);
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        /// <summary>
        /// Tests that get gamepad axes negative index returns empty
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadAxes_NegativeIndex_ReturnsEmpty()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadButtons Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that get gamepad buttons multiple indices all return empty
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadButtons_MultipleIndices_AllReturnEmpty()
        {
            for (int i = 0; i < 4; i++)
            {
                bool[] result = EmscriptenWeb.GetGamepadButtons(i);
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        /// <summary>
        /// Tests that get gamepad buttons negative index returns empty
        /// </summary>
        [WebOnlyAttribute]
        public void GetGamepadButtons_NegativeIndex_ReturnsEmpty()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetConnectedGamepads Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that get connected gamepads called multiple times returns empty
        /// </summary>
        [WebOnlyAttribute]
        public void GetConnectedGamepads_CalledMultipleTimes_ReturnsEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                int[] result = EmscriptenWeb.GetConnectedGamepads();
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        // =====================================================================
        // GetSystemTimeMs Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that get system time ms called multiple times returns zero
        /// </summary>
        [WebOnlyAttribute]
        public void GetSystemTimeMs_CalledMultipleTimes_ReturnsZero()
        {
            for (int i = 0; i < 3; i++)
            {
                double result = EmscriptenWeb.GetSystemTimeMs();
                Assert.Equal(0.0, result);
            }
        }

        // =====================================================================
        // GetWindowPositionX / Y Called Multiple Times
        // =====================================================================

        /// <summary>
        /// Tests that get window position called multiple times returns zero
        /// </summary>
        [WebOnlyAttribute]
        public void GetWindowPosition_CalledMultipleTimes_ReturnsZero()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(0, EmscriptenWeb.GetWindowPositionX());
                Assert.Equal(0, EmscriptenWeb.GetWindowPositionY());
            }
        }

        // =====================================================================
        // OpenFileDialog — edge cases for null coalesce path
        // =====================================================================

        /// <summary>
        /// Tests that open file dialog all mime types returns null
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_AllMimeTypes_ReturnsNull()
        {
            string result = EmscriptenWeb.OpenFileDialog("*/*");
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that open file dialog called multiple times returns null
        /// </summary>
        [WebOnlyAttribute]
        public void OpenFileDialog_CalledMultipleTimes_ReturnsNull()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.Null(EmscriptenWeb.OpenFileDialog());
            }
        }

        // =====================================================================
        // PasteFromClipboard Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that paste from clipboard called multiple times returns null
        /// </summary>
        [WebOnlyAttribute]
        public void PasteFromClipboard_CalledMultipleTimes_ReturnsNull()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.Null(EmscriptenWeb.PasteFromClipboard());
            }
        }

        // =====================================================================
        // GetLanguage Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that get language called multiple times returns default
        /// </summary>
        [WebOnlyAttribute]
        public void GetLanguage_CalledMultipleTimes_ReturnsDefault()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.Equal("en", EmscriptenWeb.GetLanguage());
            }
        }

        // =====================================================================
        // SaveFile Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that save file large data array returns false
        /// </summary>
        [WebOnlyAttribute]
        public void SaveFile_LargeDataArray_ReturnsFalse()
        {
            byte[] data = new byte[1024 * 1024];
            bool result = EmscriptenWeb.SaveFile("large.bin", data, data.Length);
            Assert.False(result);
        }

        // =====================================================================
        // ShowConfirm Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that show confirm long message returns false
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_LongMessage_ReturnsFalse()
        {
            string longMsg = new string('A', 1000);
            bool result = EmscriptenWeb.ShowConfirm(longMsg);
            Assert.False(result);
        }

        // =====================================================================
        // VibrateGamepad Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that vibrate gamepad max values returns false
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_MaxValues_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(10, float.MaxValue, float.MaxValue, float.MaxValue);
            Assert.False(result);
        }

        // =====================================================================
        // ConsoleLog / ConsoleWarn / ConsoleError Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that console log empty message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console warn empty message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleWarn_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(string.Empty));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that console error empty message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleError_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // ShowAlert Edge Cases
        // =====================================================================

        /// <summary>
        /// Tests that show alert very long message does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_VeryLongMessage_DoesNotThrow()
        {
            string longMsg = new string('B', 5000);
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(longMsg));
            Assert.Null(ex);
        }
    }
}
