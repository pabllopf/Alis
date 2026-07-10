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

        [Fact]
        public void RegisterKeyboardCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterMouseCallbacks
        // =====================================================================

        [Fact]
        public void RegisterMouseCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterGamepadCallbacks
        // =====================================================================

        [Fact]
        public void RegisterGamepadCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterWindowCallbacks
        // =====================================================================

        [Fact]
        public void RegisterWindowCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        // =====================================================================
        // GetConnectedGamepads
        // =====================================================================

        [Fact]
        public void GetConnectedGamepads_ReturnsEmptyArrayOnNativeFailure()
        {
            int[] result = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadAxes
        // =====================================================================

        [Fact]
        public void GetGamepadAxes_ReturnsEmptyArrayOnNativeFailure()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadButtons
        // =====================================================================

        [Fact]
        public void GetGamepadButtons_ReturnsEmptyArrayOnNativeFailure()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // ShowCanvas
        // =====================================================================

        [Fact]
        public void ShowCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowCanvas());
            Assert.Null(ex);
        }

        // =====================================================================
        // HideCanvas
        // =====================================================================

        [Fact]
        public void HideCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.HideCanvas());
            Assert.Null(ex);
        }

        // =====================================================================
        // SetWindowTitle
        // =====================================================================

        [Fact]
        public void SetWindowTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle("Test Title"));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowTitle_NullTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // SetCanvasSize
        // =====================================================================

        [Fact]
        public void SetCanvasSize_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(800, 600));
            Assert.Null(ex);
        }

        [Fact]
        public void SetCanvasSize_ZeroDimensions_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(0, 0));
            Assert.Null(ex);
        }

        [Fact]
        public void SetCanvasSize_NegativeDimensions_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(-1, -1));
            Assert.Null(ex);
        }

        // =====================================================================
        // SetWindowIcon
        // =====================================================================

        [Fact]
        public void SetWindowIcon_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowIcon_NullPath_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(null));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // GetWindowPositionX
        // =====================================================================

        [Fact]
        public void GetWindowPositionX_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetWindowPositionX();
            Assert.Equal(0, result);
        }

        // =====================================================================
        // GetWindowPositionY
        // =====================================================================

        [Fact]
        public void GetWindowPositionY_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetWindowPositionY();
            Assert.Equal(0, result);
        }

        // =====================================================================
        // GetDevicePixelRatio
        // =====================================================================

        [Fact]
        public void GetDevicePixelRatio_ReturnsDefaultOnNativeFailure()
        {
            float result = EmscriptenWeb.GetDevicePixelRatio();
            Assert.Equal(1.0f, result);
        }

        // =====================================================================
        // RequestFullscreen
        // =====================================================================

        [Fact]
        public void RequestFullscreen_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestFullscreen();
            Assert.False(result);
        }

        // =====================================================================
        // ExitFullscreen
        // =====================================================================

        [Fact]
        public void ExitFullscreen_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.ExitFullscreen();
            Assert.False(result);
        }

        // =====================================================================
        // IsFullscreenEnabled
        // =====================================================================

        [Fact]
        public void IsFullscreenEnabled_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsFullscreenEnabled();
            Assert.False(result);
        }

        // =====================================================================
        // LockPointer
        // =====================================================================

        [Fact]
        public void LockPointer_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.LockPointer();
            Assert.False(result);
        }

        // =====================================================================
        // UnlockPointer
        // =====================================================================

        [Fact]
        public void UnlockPointer_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.UnlockPointer();
            Assert.False(result);
        }

        // =====================================================================
        // IsPointerLocked
        // =====================================================================

        [Fact]
        public void IsPointerLocked_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsPointerLocked();
            Assert.False(result);
        }

        // =====================================================================
        // VibrateGamepad
        // =====================================================================

        [Fact]
        public void VibrateGamepad_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f);
            Assert.False(result);
        }

        [Fact]
        public void VibrateGamepad_NegativeIndex_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(-1, 1.0f, 1.0f, 50.0f);
            Assert.False(result);
        }

        [Fact]
        public void VibrateGamepad_ZeroDuration_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(0, 0.0f, 0.0f, 0.0f);
            Assert.False(result);
        }

        // =====================================================================
        // GetSystemTimeMs
        // =====================================================================

        [Fact]
        public void GetSystemTimeMs_ReturnsDefaultOnNativeFailure()
        {
            double result = EmscriptenWeb.GetSystemTimeMs();
            Assert.Equal(0.0, result);
        }

        // =====================================================================
        // OpenFileDialog
        // =====================================================================

        [Fact]
        public void OpenFileDialog_DefaultMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog();
            Assert.Null(result);
        }

        [Fact]
        public void OpenFileDialog_CustomMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog("image/png,image/jpeg");
            Assert.Null(result);
        }

        [Fact]
        public void OpenFileDialog_NullMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog(null);
            Assert.Null(result);
        }

        [Fact]
        public void OpenFileDialog_EmptyMime_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.OpenFileDialog(string.Empty);
            Assert.Null(result);
        }

        // =====================================================================
        // SaveFile
        // =====================================================================

        [Fact]
        public void SaveFile_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0);
            Assert.False(result);
        }

        [Fact]
        public void SaveFile_WithData_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.SaveFile("test.bin", new byte[] { 0x01, 0x02, 0x03 }, 3);
            Assert.False(result);
        }

        [Fact]
        public void SaveFile_NullFilename_ReturnsFalse()
        {
            bool result = EmscriptenWeb.SaveFile(null, Array.Empty<byte>(), 0);
            Assert.False(result);
        }

        [Fact]
        public void SaveFile_NullData_ReturnsFalse()
        {
            bool result = EmscriptenWeb.SaveFile("file.dat", null, 0);
            Assert.False(result);
        }

        // =====================================================================
        // CopyToClipboard
        // =====================================================================

        [Fact]
        public void CopyToClipboard_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.CopyToClipboard("test text");
            Assert.False(result);
        }

        [Fact]
        public void CopyToClipboard_NullText_ReturnsFalse()
        {
            bool result = EmscriptenWeb.CopyToClipboard(null);
            Assert.False(result);
        }

        [Fact]
        public void CopyToClipboard_EmptyText_ReturnsFalse()
        {
            bool result = EmscriptenWeb.CopyToClipboard(string.Empty);
            Assert.False(result);
        }

        // =====================================================================
        // PasteFromClipboard
        // =====================================================================

        [Fact]
        public void PasteFromClipboard_ReturnsNullOnNativeFailure()
        {
            string result = EmscriptenWeb.PasteFromClipboard();
            Assert.Null(result);
        }

        // =====================================================================
        // ShowAlert
        // =====================================================================

        [Fact]
        public void ShowAlert_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert("Alert message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowAlert_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(null));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowAlert_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // ShowConfirm
        // =====================================================================

        [Fact]
        public void ShowConfirm_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.ShowConfirm("Confirm?");
            Assert.False(result);
        }

        [Fact]
        public void ShowConfirm_NullMessage_ReturnsFalse()
        {
            bool result = EmscriptenWeb.ShowConfirm(null);
            Assert.False(result);
        }

        [Fact]
        public void ShowConfirm_EmptyMessage_ReturnsFalse()
        {
            bool result = EmscriptenWeb.ShowConfirm(string.Empty);
            Assert.False(result);
        }

        // =====================================================================
        // GetLanguage
        // =====================================================================

        [Fact]
        public void GetLanguage_ReturnsDefaultOnNativeFailure()
        {
            string result = EmscriptenWeb.GetLanguage();
            Assert.Equal("en", result);
        }

        // =====================================================================
        // IsOnline
        // =====================================================================

        [Fact]
        public void IsOnline_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsOnline();
            Assert.False(result);
        }

        // =====================================================================
        // GetBatteryLevel
        // =====================================================================

        [Fact]
        public void GetBatteryLevel_ReturnsDefaultOnNativeFailure()
        {
            float result = EmscriptenWeb.GetBatteryLevel();
            Assert.Equal(-1.0f, result);
        }

        // =====================================================================
        // IsCharging
        // =====================================================================

        [Fact]
        public void IsCharging_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.IsCharging();
            Assert.False(result);
        }

        // =====================================================================
        // GetOrientation
        // =====================================================================

        [Fact]
        public void GetOrientation_ReturnsDefaultOnNativeFailure()
        {
            int result = EmscriptenWeb.GetOrientation();
            Assert.Equal(1, result);
        }

        // =====================================================================
        // RequestCameraPermission
        // =====================================================================

        [Fact]
        public void RequestCameraPermission_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestCameraPermission();
            Assert.False(result);
        }

        // =====================================================================
        // RequestMicrophonePermission
        // =====================================================================

        [Fact]
        public void RequestMicrophonePermission_ReturnsFalseOnNativeFailure()
        {
            bool result = EmscriptenWeb.RequestMicrophonePermission();
            Assert.False(result);
        }

        // =====================================================================
        // ConsoleLog
        // =====================================================================

        [Fact]
        public void ConsoleLog_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog("log message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleLog_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // ConsoleWarn
        // =====================================================================

        [Fact]
        public void ConsoleWarn_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn("warn message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleWarn_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // ConsoleError
        // =====================================================================

        [Fact]
        public void ConsoleError_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError("error message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleError_NullMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(null));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterKeyboardCallbacks Edge Cases
        // =====================================================================

        [Fact]
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

        [Fact]
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

        [Fact]
        public void RegisterGamepadCallbacks_AllNonDefaultIntPtr_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(new IntPtr(10), new IntPtr(20)));
            Assert.Null(ex);
        }

        // =====================================================================
        // RegisterWindowCallbacks Edge Cases
        // =====================================================================

        [Fact]
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

        [Fact]
        public void GetGamepadAxes_MultipleIndices_AllReturnEmpty()
        {
            for (int i = 0; i < 4; i++)
            {
                float[] result = EmscriptenWeb.GetGamepadAxes(i);
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void GetGamepadAxes_NegativeIndex_ReturnsEmpty()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetGamepadButtons Edge Cases
        // =====================================================================

        [Fact]
        public void GetGamepadButtons_MultipleIndices_AllReturnEmpty()
        {
            for (int i = 0; i < 4; i++)
            {
                bool[] result = EmscriptenWeb.GetGamepadButtons(i);
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void GetGamepadButtons_NegativeIndex_ReturnsEmpty()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        // =====================================================================
        // GetConnectedGamepads Edge Cases
        // =====================================================================

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void OpenFileDialog_AllMimeTypes_ReturnsNull()
        {
            string result = EmscriptenWeb.OpenFileDialog("*/*");
            Assert.Null(result);
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void SaveFile_LargeDataArray_ReturnsFalse()
        {
            byte[] data = new byte[1024 * 1024];
            bool result = EmscriptenWeb.SaveFile("large.bin", data, data.Length);
            Assert.False(result);
        }

        // =====================================================================
        // ShowConfirm Edge Cases
        // =====================================================================

        [Fact]
        public void ShowConfirm_LongMessage_ReturnsFalse()
        {
            string longMsg = new string('A', 1000);
            bool result = EmscriptenWeb.ShowConfirm(longMsg);
            Assert.False(result);
        }

        // =====================================================================
        // VibrateGamepad Edge Cases
        // =====================================================================

        [Fact]
        public void VibrateGamepad_MaxValues_ReturnsFalse()
        {
            bool result = EmscriptenWeb.VibrateGamepad(10, float.MaxValue, float.MaxValue, float.MaxValue);
            Assert.False(result);
        }

        // =====================================================================
        // ConsoleLog / ConsoleWarn / ConsoleError Edge Cases
        // =====================================================================

        [Fact]
        public void ConsoleLog_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleWarn_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleError_EmptyMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(string.Empty));
            Assert.Null(ex);
        }

        // =====================================================================
        // ShowAlert Edge Cases
        // =====================================================================

        [Fact]
        public void ShowAlert_VeryLongMessage_DoesNotThrow()
        {
            string longMsg = new string('B', 5000);
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(longMsg));
            Assert.Null(ex);
        }
    }
}
