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
        [Fact]
        public void RegisterKeyboardCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterMouseCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterGamepadCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterWindowCallbacks_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.Null(ex);
        }

        [Fact]
        public void GetConnectedGamepads_ReturnsEmptyOnNativeFailure()
        {
            int[] result = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetGamepadAxes_ReturnsEmptyOnNativeFailure()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetGamepadButtons_ReturnsEmptyOnNativeFailure()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ShowCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowCanvas());
            Assert.Null(ex);
        }

        [Fact]
        public void HideCanvas_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.HideCanvas());
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowTitle_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle("Test Title"));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowTitle_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowTitle(null));
            Assert.Null(ex);
        }

        [Fact]
        public void SetCanvasSize_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(800, 600));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowIcon_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon("/icon.png"));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowIcon_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(null));
            Assert.Null(ex);
        }

        [Fact]
        public void GetWindowPositionX_ReturnsDefault()
        {
            Assert.Equal(0, EmscriptenWeb.GetWindowPositionX());
        }

        [Fact]
        public void GetWindowPositionY_ReturnsDefault()
        {
            Assert.Equal(0, EmscriptenWeb.GetWindowPositionY());
        }

        [Fact]
        public void GetDevicePixelRatio_ReturnsDefault()
        {
            Assert.Equal(1.0f, EmscriptenWeb.GetDevicePixelRatio());
        }

        [Fact]
        public void RequestFullscreen_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestFullscreen());
        }

        [Fact]
        public void ExitFullscreen_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ExitFullscreen());
        }

        [Fact]
        public void IsFullscreenEnabled_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsFullscreenEnabled());
        }

        [Fact]
        public void LockPointer_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.LockPointer());
        }

        [Fact]
        public void UnlockPointer_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.UnlockPointer());
        }

        [Fact]
        public void IsPointerLocked_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsPointerLocked());
        }

        [Fact]
        public void VibrateGamepad_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.VibrateGamepad(0, 0.5f, 0.5f, 100.0f));
        }

        [Fact]
        public void GetSystemTimeMs_ReturnsDefault()
        {
            Assert.Equal(0.0, EmscriptenWeb.GetSystemTimeMs());
        }

        [Fact]
        public void OpenFileDialog_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog());
        }

        [Fact]
        public void OpenFileDialog_CustomMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog("image/png"));
        }

        [Fact]
        public void OpenFileDialog_NullMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog(null));
        }

        [Fact]
        public void SaveFile_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("test.txt", Array.Empty<byte>(), 0));
        }

        [Fact]
        public void SaveFile_WithData_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("test.bin", new byte[] { 1, 2, 3 }, 3));
        }

        [Fact]
        public void SaveFile_NullFilename_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile(null, Array.Empty<byte>(), 0));
        }

        [Fact]
        public void SaveFile_NullData_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.SaveFile("file.dat", null, 0));
        }

        [Fact]
        public void CopyToClipboard_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard("test"));
        }

        [Fact]
        public void CopyToClipboard_Null_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard(null));
        }

        [Fact]
        public void CopyToClipboard_Empty_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.CopyToClipboard(string.Empty));
        }

        [Fact]
        public void PasteFromClipboard_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.PasteFromClipboard());
        }

        [Fact]
        public void ShowAlert_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert("Alert message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowAlert_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(null));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowConfirm_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm("Confirm?"));
        }

        [Fact]
        public void ShowConfirm_Null_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(null));
        }

        [Fact]
        public void GetLanguage_ReturnsDefault()
        {
            Assert.Equal("en", EmscriptenWeb.GetLanguage());
        }

        [Fact]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsOnline());
        }

        [Fact]
        public void GetBatteryLevel_ReturnsDefault()
        {
            Assert.Equal(-1.0f, EmscriptenWeb.GetBatteryLevel());
        }

        [Fact]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.IsCharging());
        }

        [Fact]
        public void GetOrientation_ReturnsDefault()
        {
            Assert.Equal(1, EmscriptenWeb.GetOrientation());
        }

        [Fact]
        public void RequestCameraPermission_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestCameraPermission());
        }

        [Fact]
        public void RequestMicrophonePermission_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.RequestMicrophonePermission());
        }

        [Fact]
        public void ConsoleLog_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog("log message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleLog_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(null));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleWarn_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn("warn message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleWarn_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(null));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleError_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError("error message"));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleError_Null_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(null));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterKeyboardCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterKeyboardCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3)));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterMouseCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterMouseCallbacks(
                    new IntPtr(1), new IntPtr(2), new IntPtr(3), new IntPtr(4)));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterGamepadCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterGamepadCallbacks(new IntPtr(10), new IntPtr(20)));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterWindowCallbacks_NonDefaultPtrs_DoesNotThrow()
        {
            Exception ex = Record.Exception(() =>
                EmscriptenWeb.RegisterWindowCallbacks(
                    new IntPtr(100), new IntPtr(200), new IntPtr(300)));
            Assert.Null(ex);
        }

        [Fact]
        public void GetGamepadAxes_NegativeIndex_ReturnsEmpty()
        {
            float[] result = EmscriptenWeb.GetGamepadAxes(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetGamepadButtons_NegativeIndex_ReturnsEmpty()
        {
            bool[] result = EmscriptenWeb.GetGamepadButtons(-1);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void VibrateGamepad_ZeroDuration_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.VibrateGamepad(0, 0.0f, 0.0f, 0.0f));
        }

        [Fact]
        public void SaveFile_LargeData_ReturnsFalse()
        {
            byte[] data = new byte[1024 * 1024];
            Assert.False(EmscriptenWeb.SaveFile("large.bin", data, data.Length));
        }

        [Fact]
        public void ShowAlert_LongMessage_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(new string('A', 5000)));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowConfirm_LongMessage_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(new string('A', 1000)));
        }

        [Fact]
        public void OpenFileDialog_EmptyMime_ReturnsNull()
        {
            Assert.Null(EmscriptenWeb.OpenFileDialog(string.Empty));
        }

        [Fact]
        public void ConsoleLog_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleLog(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleWarn_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleWarn(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ConsoleError_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ConsoleError(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void SetCanvasSize_Zero_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(0, 0));
            Assert.Null(ex);
        }

        [Fact]
        public void SetCanvasSize_Negative_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetCanvasSize(-1, -1));
            Assert.Null(ex);
        }

        [Fact]
        public void SetWindowIcon_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.SetWindowIcon(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowAlert_Empty_DoesNotThrow()
        {
            Exception ex = Record.Exception(() => EmscriptenWeb.ShowAlert(string.Empty));
            Assert.Null(ex);
        }

        [Fact]
        public void ShowConfirm_Empty_ReturnsFalse()
        {
            Assert.False(EmscriptenWeb.ShowConfirm(string.Empty));
        }
    }
}
