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
        private const string EmscriptenLib = "emscripten";

        /// <summary>
        ///     Registers keyboard event callbacks with JavaScript handler
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "registerKeyboardCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void RegisterKeyboardCallbacks(
            IntPtr onKeyDownCallback,
            IntPtr onKeyUpCallback,
            IntPtr onCharInputCallback);

        /// <summary>
        ///     Registers mouse event callbacks with JavaScript handler
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "registerMouseCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void RegisterMouseCallbacks(
            IntPtr onMouseMoveCallback,
            IntPtr onMouseDownCallback,
            IntPtr onMouseUpCallback,
            IntPtr onMouseWheelCallback);

        /// <summary>
        ///     Registers gamepad event callbacks with JavaScript handler
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "registerGamepadCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void RegisterGamepadCallbacks(
            IntPtr onGamepadConnectCallback,
            IntPtr onGamepadDisconnectCallback);

        /// <summary>
        ///     Registers window event callbacks with JavaScript handler
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "registerWindowCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void RegisterWindowCallbacks(
            IntPtr onWindowResizeCallback,
            IntPtr onWindowCloseCallback,
            IntPtr onWindowFocusCallback);

        /// <summary>
        ///     Gets the array of connected gamepad indices
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getConnectedGamepads", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetConnectedGamepadsNative();

        /// <summary>
        ///     Gets the axes values for a specific gamepad
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getGamepadAxes", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetGamepadAxesNative(int gamepadIndex);

        /// <summary>
        ///     Gets the button states for a specific gamepad
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getGamepadButtons", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetGamepadButtonsNative(int gamepadIndex);

        /// <summary>
        ///     Gets the length of a native array
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getArrayLength", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetArrayLength(IntPtr arrayPtr);

        /// <summary>
        ///     Gets an integer element from a native array
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getArrayIntElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern int GetArrayIntElement(IntPtr arrayPtr, int index);

        /// <summary>
        ///     Gets a float element from a native array
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getArrayFloatElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern float GetArrayFloatElement(IntPtr arrayPtr, int index);

        /// <summary>
        ///     Gets a boolean element from a native array
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getArrayBoolElement", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern bool GetArrayBoolElement(IntPtr arrayPtr, int index);

        /// <summary>
        ///     Frees a native array allocated by JavaScript
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "freeArray", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void FreeArray(IntPtr arrayPtr);

        /// <summary>
        ///     Shows the canvas element
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "showCanvas", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void ShowCanvas();

        /// <summary>
        ///     Hides the canvas element
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "hideCanvas", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void HideCanvas();

        /// <summary>
        ///     Sets the window title
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "setWindowTitle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void SetWindowTitle(string title);

        /// <summary>
        ///     Sets the canvas size
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "setCanvasSize", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void SetCanvasSize(int width, int height);

        /// <summary>
        ///     Sets the window icon from a data URI
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "setWindowIcon", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void SetWindowIcon(string iconPath);

        /// <summary>
        ///     Gets the window position X
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getWindowPositionX", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern int GetWindowPositionX();

        /// <summary>
        ///     Gets the window position Y
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getWindowPositionY", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern int GetWindowPositionY();

        /// <summary>
        ///     Gets the device pixel ratio for high DPI displays
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getDevicePixelRatio", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern float GetDevicePixelRatio();

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
                    return null;
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
                return null;
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
                    return null;
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
                return null;
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
                    return null;
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
                return null;
            }
        }

        /// <summary>
        ///     Requests the browser to enter fullscreen mode
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "requestFullscreen", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool RequestFullscreen();

        /// <summary>
        ///     Exits fullscreen mode
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "exitFullscreen", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool ExitFullscreen();

        /// <summary>
        ///     Checks if the browser is currently in fullscreen mode
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "isFullscreenEnabled", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool IsFullscreenEnabled();

        /// <summary>
        ///     Locks the pointer and hides the cursor
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "lockPointer", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool LockPointer();

        /// <summary>
        ///     Unlocks the pointer and shows the cursor
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "unlockPointer", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool UnlockPointer();

        /// <summary>
        ///     Checks if the pointer is currently locked
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "isPointerLocked", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool IsPointerLocked();

        /// <summary>
        ///     Vibrates the gamepad (if supported by hardware)
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "vibrateGamepad", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool VibrateGamepad(int gamepadIndex, float leftMotor, float rightMotor, float duration);

        /// <summary>
        ///     Gets the current system time in milliseconds
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getSystemTimeMs", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern double GetSystemTimeMs();

        /// <summary>
        ///     Requests a file picker and returns the file path (if user selects one)
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "openFileDialog", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr OpenFileDialogNative(string mimeTypes);

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

                string result = Marshal.PtrToStringAnsi(resultPtr);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Saves a file to the user's downloads folder
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "saveFile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool SaveFile(string filename, byte[] data, int dataLength);

        /// <summary>
        ///     Copies text to the clipboard
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "copyToClipboard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool CopyToClipboard(string text);

        /// <summary>
        ///     Pastes text from the clipboard
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "pasteFromClipboard", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr PasteFromClipboardNative();

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

                string result = Marshal.PtrToStringAnsi(resultPtr);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Shows an alert dialog
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "showAlert", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void ShowAlert(string message);

        /// <summary>
        ///     Shows a confirmation dialog and returns true if user clicks OK
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "showConfirm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool ShowConfirm(string message);

        /// <summary>
        ///     Gets the browser's preferred language code
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getLanguage", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern IntPtr GetLanguageNative();

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
        [DllImport(EmscriptenLib, EntryPoint = "isOnline", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool IsOnline();

        /// <summary>
        ///     Gets the battery status (if available)
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getBatteryLevel", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern float GetBatteryLevel();

        /// <summary>
        ///     Checks if the device is charging
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "isCharging", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool IsCharging();

        /// <summary>
        ///     Gets the device orientation (portrait or landscape)
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "getOrientation", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern int GetOrientation(); // 0 = portrait, 1 = landscape

        /// <summary>
        ///     Requests permission to use the camera
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "requestCameraPermission", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool RequestCameraPermission();

        /// <summary>
        ///     Requests permission to use the microphone
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "requestMicrophonePermission", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern bool RequestMicrophonePermission();

        /// <summary>
        ///     Logs a message to the browser console
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "consoleLog", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void ConsoleLog(string message);

        /// <summary>
        ///     Logs a warning to the browser console
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "consoleWarn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void ConsoleWarn(string message);

        /// <summary>
        ///     Logs an error to the browser console
        /// </summary>
        [DllImport(EmscriptenLib, EntryPoint = "consoleError", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern void ConsoleError(string message);
    }
}

