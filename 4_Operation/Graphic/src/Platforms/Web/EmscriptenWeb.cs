// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWeb.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     EmscriptenWeb provides JavaScript interop for WebAssembly applications
    ///     Handles communication with JavaScript functions for DOM manipulation,
    ///     input event handling, and browser APIs
    /// </summary>
    public static class EmscriptenWeb
    {
        /// <summary>
        /// The emscripten lib
        /// </summary>
        private const string EmscriptenLib = "emscripten";

        // =====================================================================
        // Native DllImport methods (private - accessed via public wrappers)
        // =====================================================================

        [DllImport(EmscriptenLib, EntryPoint = "registerKeyboardCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void RegisterKeyboardCallbacksNative(
            IntPtr onKeyDownCallback,
            IntPtr onKeyUpCallback,
            IntPtr onCharInputCallback);

        [DllImport(EmscriptenLib, EntryPoint = "registerMouseCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void RegisterMouseCallbacksNative(
            IntPtr onMouseMoveCallback,
            IntPtr onMouseDownCallback,
            IntPtr onMouseUpCallback,
            IntPtr onMouseWheelCallback);

        [DllImport(EmscriptenLib, EntryPoint = "registerGamepadCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void RegisterGamepadCallbacksNative(
            IntPtr onGamepadConnectCallback,
            IntPtr onGamepadDisconnectCallback);

        [DllImport(EmscriptenLib, EntryPoint = "registerWindowCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void RegisterWindowCallbacksNative(
            IntPtr onWindowResizeCallback,
            IntPtr onWindowCloseCallback,
            IntPtr onWindowFocusCallback);

        [DllImport(EmscriptenLib, EntryPoint = "getConnectedGamepads", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetConnectedGamepadsNative();

        [DllImport(EmscriptenLib, EntryPoint = "getGamepadAxes", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetGamepadAxesNative(int gamepadIndex);

        [DllImport(EmscriptenLib, EntryPoint = "getGamepadButtons", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetGamepadButtonsNative(int gamepadIndex);

        [DllImport(EmscriptenLib, EntryPoint = "getArrayLength", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetArrayLength(IntPtr arrayPtr);

        [DllImport(EmscriptenLib, EntryPoint = "getArrayIntElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetArrayIntElement(IntPtr arrayPtr, int index);

        [DllImport(EmscriptenLib, EntryPoint = "getArrayFloatElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern float GetArrayFloatElement(IntPtr arrayPtr, int index);

        [DllImport(EmscriptenLib, EntryPoint = "getArrayBoolElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool GetArrayBoolElement(IntPtr arrayPtr, int index);

        [DllImport(EmscriptenLib, EntryPoint = "freeArray", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void FreeArray(IntPtr arrayPtr);

        [DllImport(EmscriptenLib, EntryPoint = "showCanvas", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void ShowCanvasNative();

        [DllImport(EmscriptenLib, EntryPoint = "hideCanvas", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void HideCanvasNative();

        [DllImport(EmscriptenLib, EntryPoint = "setWindowTitle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void SetWindowTitleNative(string title);

        [DllImport(EmscriptenLib, EntryPoint = "setCanvasSize", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void SetCanvasSizeNative(int width, int height);

        [DllImport(EmscriptenLib, EntryPoint = "setWindowIcon", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void SetWindowIconNative(string iconPath);

        [DllImport(EmscriptenLib, EntryPoint = "getWindowPositionX", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetWindowPositionXNative();

        [DllImport(EmscriptenLib, EntryPoint = "getWindowPositionY", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetWindowPositionYNative();

        [DllImport(EmscriptenLib, EntryPoint = "getDevicePixelRatio", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern float GetDevicePixelRatioNative();

        [DllImport(EmscriptenLib, EntryPoint = "requestFullscreen", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool RequestFullscreenNative();

        [DllImport(EmscriptenLib, EntryPoint = "exitFullscreen", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool ExitFullscreenNative();

        [DllImport(EmscriptenLib, EntryPoint = "isFullscreenEnabled", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool IsFullscreenEnabledNative();

        [DllImport(EmscriptenLib, EntryPoint = "lockPointer", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool LockPointerNative();

        [DllImport(EmscriptenLib, EntryPoint = "unlockPointer", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool UnlockPointerNative();

        [DllImport(EmscriptenLib, EntryPoint = "isPointerLocked", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool IsPointerLockedNative();

        [DllImport(EmscriptenLib, EntryPoint = "vibrateGamepad", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool VibrateGamepadNative(int gamepadIndex, float leftMotor, float rightMotor, float duration);

        [DllImport(EmscriptenLib, EntryPoint = "getSystemTimeMs", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern double GetSystemTimeMsNative();

        [DllImport(EmscriptenLib, EntryPoint = "openFileDialog", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr OpenFileDialogNative(string mimeTypes);

        [DllImport(EmscriptenLib, EntryPoint = "saveFile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool SaveFileNative(string filename, byte[] data, int dataLength);

        [DllImport(EmscriptenLib, EntryPoint = "copyToClipboard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool CopyToClipboardNative(string text);

        [DllImport(EmscriptenLib, EntryPoint = "pasteFromClipboard", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr PasteFromClipboardNative();

        [DllImport(EmscriptenLib, EntryPoint = "showAlert", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void ShowAlertNative(string message);

        [DllImport(EmscriptenLib, EntryPoint = "showConfirm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool ShowConfirmNative(string message);

        [DllImport(EmscriptenLib, EntryPoint = "getLanguage", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetLanguageNative();

        [DllImport(EmscriptenLib, EntryPoint = "isOnline", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool IsOnlineNative();

        [DllImport(EmscriptenLib, EntryPoint = "getBatteryLevel", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern float GetBatteryLevelNative();

        [DllImport(EmscriptenLib, EntryPoint = "isCharging", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool IsChargingNative();

        [DllImport(EmscriptenLib, EntryPoint = "getOrientation", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetOrientationNative();

        [DllImport(EmscriptenLib, EntryPoint = "requestCameraPermission", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool RequestCameraPermissionNative();

        [DllImport(EmscriptenLib, EntryPoint = "requestMicrophonePermission", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool RequestMicrophonePermissionNative();

        [DllImport(EmscriptenLib, EntryPoint = "consoleLog", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void ConsoleLogNative(string message);

        [DllImport(EmscriptenLib, EntryPoint = "consoleWarn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void ConsoleWarnNative(string message);

        [DllImport(EmscriptenLib, EntryPoint = "consoleError", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void ConsoleErrorNative(string message);

        // =====================================================================
        // Public wrapper methods with safe exception handling
        // =====================================================================

        /// <summary>
        ///     Registers keyboard event callbacks with JavaScript handler
        /// </summary>
        public static void RegisterKeyboardCallbacks(
            IntPtr onKeyDownCallback,
            IntPtr onKeyUpCallback,
            IntPtr onCharInputCallback)
        {
            try
            {
                RegisterKeyboardCallbacksNative(onKeyDownCallback, onKeyUpCallback, onCharInputCallback);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers mouse event callbacks with JavaScript handler
        /// </summary>
        public static void RegisterMouseCallbacks(
            IntPtr onMouseMoveCallback,
            IntPtr onMouseDownCallback,
            IntPtr onMouseUpCallback,
            IntPtr onMouseWheelCallback)
        {
            try
            {
                RegisterMouseCallbacksNative(onMouseMoveCallback, onMouseDownCallback, onMouseUpCallback, onMouseWheelCallback);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers gamepad event callbacks with JavaScript handler
        /// </summary>
        public static void RegisterGamepadCallbacks(
            IntPtr onGamepadConnectCallback,
            IntPtr onGamepadDisconnectCallback)
        {
            try
            {
                RegisterGamepadCallbacksNative(onGamepadConnectCallback, onGamepadDisconnectCallback);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers window event callbacks with JavaScript handler
        /// </summary>
        public static void RegisterWindowCallbacks(
            IntPtr onWindowResizeCallback,
            IntPtr onWindowCloseCallback,
            IntPtr onWindowFocusCallback)
        {
            try
            {
                RegisterWindowCallbacksNative(onWindowResizeCallback, onWindowCloseCallback, onWindowFocusCallback);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Wrapper to safely get connected gamepads as a managed array
        /// </summary>
        public static int[] GetConnectedGamepads()
        {
            try
            {
                IntPtr nativeArray = GetConnectedGamepadsNative();
                if (nativeArray == IntPtr.Zero)
                {
                    return Array.Empty<int>();
                }

                int length = GetArrayLength(nativeArray);
                int[] result = new int[length];

                for (int i = 0; i < length; i++)
                {
                    result[i] = GetArrayIntElement(nativeArray, i);
                }

                FreeArray(nativeArray);
                return result;
            }
            catch
            {
                return Array.Empty<int>();
            }
        }

        /// <summary>
        ///     Wrapper to safely get gamepad axes as a managed array
        /// </summary>
        public static float[] GetGamepadAxes(int gamepadIndex)
        {
            try
            {
                IntPtr nativeArray = GetGamepadAxesNative(gamepadIndex);
                if (nativeArray == IntPtr.Zero)
                {
                    return Array.Empty<float>();
                }

                int length = GetArrayLength(nativeArray);
                float[] result = new float[length];

                for (int i = 0; i < length; i++)
                {
                    result[i] = GetArrayFloatElement(nativeArray, i);
                }

                FreeArray(nativeArray);
                return result;
            }
            catch
            {
                return Array.Empty<float>();
            }
        }

        /// <summary>
        ///     Wrapper to safely get gamepad buttons as a managed array
        /// </summary>
        public static bool[] GetGamepadButtons(int gamepadIndex)
        {
            try
            {
                IntPtr nativeArray = GetGamepadButtonsNative(gamepadIndex);
                if (nativeArray == IntPtr.Zero)
                {
                    return Array.Empty<bool>();
                }

                int length = GetArrayLength(nativeArray);
                bool[] result = new bool[length];

                for (int i = 0; i < length; i++)
                {
                    result[i] = GetArrayBoolElement(nativeArray, i);
                }

                FreeArray(nativeArray);
                return result;
            }
            catch
            {
                return Array.Empty<bool>();
            }
        }

        /// <summary>
        ///     Shows the canvas element
        /// </summary>
        public static void ShowCanvas()
        {
            try
            {
                ShowCanvasNative();
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Hides the canvas element
        /// </summary>
        public static void HideCanvas()
        {
            try
            {
                HideCanvasNative();
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Sets the window title
        /// </summary>
        public static void SetWindowTitle(string title)
        {
            try
            {
                SetWindowTitleNative(title);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Sets the canvas size
        /// </summary>
        public static void SetCanvasSize(int width, int height)
        {
            try
            {
                SetCanvasSizeNative(width, height);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Sets the window icon from a data URI
        /// </summary>
        public static void SetWindowIcon(string iconPath)
        {
            try
            {
                SetWindowIconNative(iconPath);
            }
            catch
            {
                // Icon setting not available in WebAssembly context
            }
        }

        /// <summary>
        ///     Gets the window position X
        /// </summary>
        public static int GetWindowPositionX()
        {
            try
            {
                return GetWindowPositionXNative();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the window position Y
        /// </summary>
        public static int GetWindowPositionY()
        {
            try
            {
                return GetWindowPositionYNative();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the device pixel ratio for high DPI displays
        /// </summary>
        public static float GetDevicePixelRatio()
        {
            try
            {
                return GetDevicePixelRatioNative();
            }
            catch
            {
                return 1.0f;
            }
        }

        /// <summary>
        ///     Requests the browser to enter fullscreen mode
        /// </summary>
        public static bool RequestFullscreen()
        {
            try
            {
                return RequestFullscreenNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Exits fullscreen mode
        /// </summary>
        public static bool ExitFullscreen()
        {
            try
            {
                return ExitFullscreenNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Checks if the browser is currently in fullscreen mode
        /// </summary>
        public static bool IsFullscreenEnabled()
        {
            try
            {
                return IsFullscreenEnabledNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Locks the pointer and hides the cursor
        /// </summary>
        public static bool LockPointer()
        {
            try
            {
                return LockPointerNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Unlocks the pointer and shows the cursor
        /// </summary>
        public static bool UnlockPointer()
        {
            try
            {
                return UnlockPointerNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Checks if the pointer is currently locked
        /// </summary>
        public static bool IsPointerLocked()
        {
            try
            {
                return IsPointerLockedNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Vibrates the gamepad (if supported by hardware)
        /// </summary>
        public static bool VibrateGamepad(int gamepadIndex, float leftMotor, float rightMotor, float duration)
        {
            try
            {
                return VibrateGamepadNative(gamepadIndex, leftMotor, rightMotor, duration);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Gets the current system time in milliseconds
        /// </summary>
        public static double GetSystemTimeMs()
        {
            try
            {
                return GetSystemTimeMsNative();
            }
            catch
            {
                return 0.0;
            }
        }

        /// <summary>
        ///     Managed wrapper for file picker dialog
        /// </summary>
        public static string OpenFileDialog(string mimeTypes = "*/*")
        {
            try
            {
                IntPtr resultPtr = OpenFileDialogNative(mimeTypes ?? "*/*");
                if (resultPtr == IntPtr.Zero)
                {
                    return null;
                }

                return Marshal.PtrToStringAnsi(resultPtr);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Saves a file to the user's downloads folder
        /// </summary>
        public static bool SaveFile(string filename, byte[] data, int dataLength)
        {
            try
            {
                return SaveFileNative(filename, data, dataLength);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Copies text to the clipboard
        /// </summary>
        public static bool CopyToClipboard(string text)
        {
            try
            {
                return CopyToClipboardNative(text);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Managed wrapper for clipboard paste
        /// </summary>
        public static string PasteFromClipboard()
        {
            try
            {
                IntPtr resultPtr = PasteFromClipboardNative();
                if (resultPtr == IntPtr.Zero)
                {
                    return null;
                }

                return Marshal.PtrToStringAnsi(resultPtr);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Shows an alert dialog
        /// </summary>
        public static void ShowAlert(string message)
        {
            try
            {
                ShowAlertNative(message);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Shows a confirmation dialog and returns true if user clicks OK
        /// </summary>
        public static bool ShowConfirm(string message)
        {
            try
            {
                return ShowConfirmNative(message);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Managed wrapper for getting browser language
        /// </summary>
        public static string GetLanguage()
        {
            try
            {
                IntPtr resultPtr = GetLanguageNative();
                if (resultPtr == IntPtr.Zero)
                {
                    return "en";
                }

                string result = Marshal.PtrToStringAnsi(resultPtr);
                return result ?? "en";
            }
            catch
            {
                return "en";
            }
        }

        /// <summary>
        ///     Checks if the browser is online
        /// </summary>
        public static bool IsOnline()
        {
            try
            {
                return IsOnlineNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Gets the battery status (if available)
        /// </summary>
        public static float GetBatteryLevel()
        {
            try
            {
                return GetBatteryLevelNative();
            }
            catch
            {
                return -1.0f;
            }
        }

        /// <summary>
        ///     Checks if the device is charging
        /// </summary>
        public static bool IsCharging()
        {
            try
            {
                return IsChargingNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Gets the device orientation (portrait or landscape)
        /// </summary>
        public static int GetOrientation()
        {
            try
            {
                return GetOrientationNative();
            }
            catch
            {
                return 1; // Default to landscape
            }
        }

        /// <summary>
        ///     Requests permission to use the camera
        /// </summary>
        public static bool RequestCameraPermission()
        {
            try
            {
                return RequestCameraPermissionNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Requests permission to use the microphone
        /// </summary>
        public static bool RequestMicrophonePermission()
        {
            try
            {
                return RequestMicrophonePermissionNative();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Logs a message to the browser console
        /// </summary>
        public static void ConsoleLog(string message)
        {
            try
            {
                ConsoleLogNative(message);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Logs a warning to the browser console
        /// </summary>
        public static void ConsoleWarn(string message)
        {
            try
            {
                ConsoleWarnNative(message);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Logs an error to the browser console
        /// </summary>
        public static void ConsoleError(string message)
        {
            try
            {
                ConsoleErrorNative(message);
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }
    }
}
