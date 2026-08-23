// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformTests.cs
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
    ///     Exercises the WebAssemblyPlatform input, window, and lifecycle paths that
    ///     run on desktop hosts where the emscripten and EGL native libraries are absent.
    /// </summary>
    public class WebAssemblyPlatformTests
    {
        /// <summary>
        ///     Verifies that the four argument initialize falls back to the icon path overload
        ///     and reports failure when the EGL native library is unavailable.
        /// </summary>
        [Fact]
        public void Initialize_WithNullIconPath_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(640, 480, "title", null);
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that the three argument initialize forwards to the icon path overload
        ///     and reports failure when the EGL native library is unavailable.
        /// </summary>
        [Fact]
        public void Initialize_ThreeArguments_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(640, 480, "title");
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that a failed initialize attempt does not permanently disable retries
        ///     and that repeated attempts keep reporting failure on desktop.
        /// </summary>
        [Fact]
        public void Initialize_RepeatedAttempts_KeepReportingFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.Initialize(800, 600, "a"));
            Assert.False(platform.Initialize(800, 600, "b"));
            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }

        /// <summary>
        ///     Verifies that the input event registration pipeline executes without throwing
        ///     when the emscripten native library is unavailable.
        /// </summary>
        [Fact]
        public void RegisterInputEvents_WithoutNativeLibrary_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.RegisterInputEvents();
            platform.RegisterKeyboardEvents();
            platform.RegisterMouseEvents();
            platform.RegisterGamepadEvents();
            platform.RegisterWindowEvents();
        }

        /// <summary>
        ///     Verifies that a key down event maps the key code to the matching console key,
        ///     marks it as pressed and queues it for consumption.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsAlphabetKeys()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(65, 0);
            platform.OnKeyDown(90, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.IsKeyDown(ConsoleKey.Z));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey first));
            Assert.Equal(ConsoleKey.A, first);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey second));
            Assert.Equal(ConsoleKey.Z, second);
        }

        /// <summary>
        ///     Verifies that every letter key code maps to its matching console key.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsEveryLetter()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            ConsoleKey[] expected = new ConsoleKey[]
            {
                ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F,
                ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L,
                ConsoleKey.M, ConsoleKey.N, ConsoleKey.O, ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R,
                ConsoleKey.S, ConsoleKey.T, ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X,
                ConsoleKey.Y, ConsoleKey.Z
            };

            for (int i = 0; i < expected.Length; i++)
            {
                platform.OnKeyDown(65 + i, 0);
            }

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(platform.IsKeyDown(expected[i]));
            }
        }

        /// <summary>
        ///     Verifies that every digit key code maps to its matching console key.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsEveryDigit()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            for (int i = 0; i < 10; i++)
            {
                platform.OnKeyDown(48 + i, 0);
            }

            Assert.True(platform.IsKeyDown(ConsoleKey.D0));
            Assert.True(platform.IsKeyDown(ConsoleKey.D1));
            Assert.True(platform.IsKeyDown(ConsoleKey.D2));
            Assert.True(platform.IsKeyDown(ConsoleKey.D3));
            Assert.True(platform.IsKeyDown(ConsoleKey.D4));
            Assert.True(platform.IsKeyDown(ConsoleKey.D5));
            Assert.True(platform.IsKeyDown(ConsoleKey.D6));
            Assert.True(platform.IsKeyDown(ConsoleKey.D7));
            Assert.True(platform.IsKeyDown(ConsoleKey.D8));
            Assert.True(platform.IsKeyDown(ConsoleKey.D9));
        }

        /// <summary>
        ///     Verifies that every function key code maps to its matching console key.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsEveryFunctionKey()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            for (int i = 0; i < 12; i++)
            {
                platform.OnKeyDown(112 + i, 0);
            }

            Assert.True(platform.IsKeyDown(ConsoleKey.F1));
            Assert.True(platform.IsKeyDown(ConsoleKey.F6));
            Assert.True(platform.IsKeyDown(ConsoleKey.F12));
        }

        /// <summary>
        ///     Verifies that every keypad key code maps to its matching console key.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsEveryKeypadKey()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(96, 0);
            platform.OnKeyDown(97, 0);
            platform.OnKeyDown(98, 0);
            platform.OnKeyDown(99, 0);
            platform.OnKeyDown(100, 0);
            platform.OnKeyDown(101, 0);
            platform.OnKeyDown(102, 0);
            platform.OnKeyDown(103, 0);
            platform.OnKeyDown(104, 0);
            platform.OnKeyDown(105, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad0));
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad5));
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad9));
        }

        /// <summary>
        ///     Verifies that number, control, arrow, function and keypad key codes map to the
        ///     expected console keys.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsSpecialKeys()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int[] codes = new int[] { 48, 57, 13, 9, 32, 8, 27, 46, 37, 38, 39, 40, 112, 123, 36, 35, 33, 34, 45, 19, 96, 105, 106, 107, 109, 110, 111 };
            ConsoleKey[] expected = new ConsoleKey[]
            {
                ConsoleKey.D0, ConsoleKey.D9, ConsoleKey.Enter, ConsoleKey.Tab, ConsoleKey.Spacebar,
                ConsoleKey.Backspace, ConsoleKey.Escape, ConsoleKey.Delete, ConsoleKey.LeftArrow,
                ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.F1,
                ConsoleKey.F12, ConsoleKey.Home, ConsoleKey.End, ConsoleKey.PageUp, ConsoleKey.PageDown,
                ConsoleKey.Insert, ConsoleKey.Pause, ConsoleKey.NumPad0, ConsoleKey.NumPad9,
                ConsoleKey.Multiply, ConsoleKey.Add, ConsoleKey.Subtract, ConsoleKey.Decimal, ConsoleKey.Divide
            };

            for (int i = 0; i < codes.Length; i++)
            {
                platform.OnKeyDown(codes[i], 0);
                Assert.True(platform.IsKeyDown(expected[i]), $"code {codes[i]} should map to {expected[i]}");
            }
        }

        /// <summary>
        ///     Verifies that the shift and control key code remappings fall back to arrow and
        ///     escape mappings and that unknown codes map to NoName.
        /// </summary>
        [Fact]
        public void OnKeyDown_MapsRemappedAndUnknownCodes()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(16, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));
            platform.OnKeyDown(17, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
            platform.OnKeyDown(999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        /// <summary>
        ///     Verifies that repeated key down events for an already pressed key are not
        ///     enqueued a second time.
        /// </summary>
        [Fact]
        public void OnKeyDown_RepeatedPress_DoesNotRequeue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(66, 0);
            platform.OnKeyDown(66, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.NoName, key);
        }

        /// <summary>
        ///     Verifies that a key up event clears the pressed state of a mapped key and that
        ///     unknown keys are ignored.
        /// </summary>
        [Fact]
        public void OnKeyUp_ClearsPressedState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(67, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.C));
            platform.OnKeyUp(67, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.C));
            platform.OnKeyUp(68, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.D));
        }

        /// <summary>
        ///     Verifies that character input is collected and returned once by the character
        ///     queue.
        /// </summary>
        [Fact]
        public void OnCharInput_CollectsAndReturnsCharacters()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnCharInput(72);
            platform.OnCharInput(105);
            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("Hi", chars);
            Assert.False(platform.TryGetLastInputCharacters(out string empty));
            Assert.Equal(string.Empty, empty);
        }

        /// <summary>
        ///     Verifies that invalid unicode code points are swallowed by the character input
        ///     handler.
        /// </summary>
        [Fact]
        public void OnCharInput_WithInvalidCodePoint_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnCharInput(0xD800);
            Assert.False(platform.TryGetLastInputCharacters(out _));
        }

        /// <summary>
        ///     Verifies that mouse move events update the client coordinates.
        /// </summary>
        [Fact]
        public void OnMouseMove_UpdatesCoordinates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnMouseMove(1, 2, 30, 40);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.Equal(30, x);
            Assert.Equal(40, y);
            Assert.Equal(5, buttons.Length);
            platform.GetMousePositionInView(out float fx, out float fy);
            Assert.Equal(30.0f, fx);
            Assert.Equal(40.0f, fy);
        }

        /// <summary>
        ///     Verifies that mouse down events set the matching button and coordinates and
        ///     that out of range buttons are ignored.
        /// </summary>
        [Fact]
        public void OnMouseDown_SetsButtonAndCoordinates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnMouseDown(0, 5, 6, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(10, x);
            Assert.Equal(20, y);
            platform.OnMouseDown(4, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out buttons);
            Assert.True(buttons[4]);
            platform.OnMouseDown(5, 0, 0, 0, 0);
            platform.OnMouseDown(-1, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out buttons);
            Assert.True(buttons[0]);
            Assert.True(buttons[4]);
        }

        /// <summary>
        ///     Verifies that mouse up events clear the matching button.
        /// </summary>
        [Fact]
        public void OnMouseUp_ClearsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnMouseDown(1, 0, 0, 0, 0);
            platform.OnMouseUp(1, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[1]);
            platform.OnMouseUp(2, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out buttons);
            Assert.False(buttons[2]);
        }

        /// <summary>
        ///     Verifies that the wheel delta is stored and returned.
        /// </summary>
        [Fact]
        public void OnMouseWheel_SetsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnMouseWheel(-2, 7);
            Assert.Equal(7.0f, platform.GetMouseWheel());
            platform.OnMouseWheel(0, -3);
            Assert.Equal(-3.0f, platform.GetMouseWheel());
        }

        /// <summary>
        ///     Verifies that connecting a gamepad creates a connected state entry and that a
        ///     repeated connect keeps a single entry.
        /// </summary>
        [Fact]
        public void OnGamepadConnect_CreatesConnectedState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnGamepadConnect(0);
            platform.OnGamepadConnect(0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
            Assert.True(platform.TryGetGamepadState(1, out _) == false);
        }

        /// <summary>
        ///     Verifies that disconnecting a gamepad marks it disconnected and that unknown
        ///     indices are ignored.
        /// </summary>
        [Fact]
        public void OnGamepadDisconnect_MarksDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnGamepadConnect(2);
            platform.OnGamepadDisconnect(2);
            Assert.True(platform.TryGetGamepadState(2, out GamepadState state));
            Assert.False(state.Connected);
            platform.OnGamepadDisconnect(7);
            Assert.False(platform.TryGetGamepadState(7, out _));
        }

        /// <summary>
        ///     Verifies that only connected gamepads are reported by the index query.
        /// </summary>
        [Fact]
        public void GetConnectedGamepadIndices_ReturnsOnlyConnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnGamepadConnect(0);
            platform.OnGamepadConnect(1);
            platform.OnGamepadDisconnect(1);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
            Assert.Equal(0, indices[0]);
        }

        /// <summary>
        ///     Verifies that the gamepad state update handles a missing native library without
        ///     throwing and returns no indices.
        /// </summary>
        [Fact]
        public void UpdateGamepadStates_WithoutNativeLibrary_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnGamepadConnect(0);
            platform.UpdateGamepadStates();
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
        }

        /// <summary>
        ///     Verifies that updating a single gamepad state creates the entry and keeps the
        ///     default axes and buttons when the native library is unavailable.
        /// </summary>
        [Fact]
        public void UpdateSingleGamepadState_CreatesEntryWithDefaults()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.UpdateSingleGamepadState(3);
            Assert.True(platform.TryGetGamepadState(3, out GamepadState state));
            Assert.Equal(0.0f, state.LeftStickX);
            Assert.Equal(0.0f, state.LeftStickY);
            Assert.Equal(0.0f, state.RightStickX);
            Assert.Equal(0.0f, state.RightStickY);
            Assert.Equal(0.0f, state.LeftTrigger);
            Assert.Equal(0.0f, state.RightTrigger);
            Assert.False(state.Buttons[0]);
            Assert.False(state.ButtonA);
            Assert.False(state.ButtonB);
            Assert.False(state.ButtonX);
            Assert.False(state.ButtonY);
            Assert.False(state.ButtonLb);
            Assert.False(state.ButtonRb);
            Assert.False(state.ButtonLeftStickClick);
            Assert.False(state.ButtonRightStickClick);
            Assert.False(state.ButtonStart);
            Assert.False(state.ButtonBack);
            Assert.False(state.ButtonGuide);
            Assert.False(state.GetButton(0));
            Assert.False(state.GetButton(20));
            Assert.False(state.GetButton(-1));
            platform.UpdateSingleGamepadState(3);
        }

        /// <summary>
        ///     Verifies that the window visibility is toggled by the show and hide operations
        ///     when the native library is unavailable.
        /// </summary>
        [Fact]
        public void ShowAndHideWindow_ToggleVisibility()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsWindowVisible());
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        ///     Verifies that the title, size and icon operations execute without throwing when
        ///     the native library is unavailable.
        /// </summary>
        [Fact]
        public void WindowManagement_WithoutNativeLibrary_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle("New Title");
            platform.SetSize(1024, 768);
            Assert.Equal(1024, platform.GetWindowWidth());
            Assert.Equal(768, platform.GetWindowHeight());
            platform.SetWindowIcon("/icon.png");
            platform.SetWindowIcon(null);
        }

        /// <summary>
        ///     Verifies that context operations are no-ops when the EGL handles are zero.
        /// </summary>
        [Fact]
        public void ContextOperations_WithZeroHandles_DoNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
            platform.SwapBuffers();
        }

        /// <summary>
        ///     Verifies that the window position queries fall back to zero when the native
        ///     library is unavailable and that the window metrics are computed from them.
        /// </summary>
        [Fact]
        public void WindowMetrics_WithoutNativeLibrary_ReturnsZeroBasedValues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0, platform.GetWindowPositionX());
            Assert.Equal(0, platform.GetWindowPositionY());
            platform.OnWindowResize(320, 240);
            platform.GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);
            Assert.Equal(0, winX);
            Assert.Equal(0, winY);
            Assert.Equal(320, winW);
            Assert.Equal(240, winH);
            Assert.Equal(320, fbW);
            Assert.Equal(240, fbH);
        }

        /// <summary>
        ///     Verifies that polling events resets the wheel delta and reports true while the
        ///     window is not closing.
        /// </summary>
        [Fact]
        public void PollEvents_ResetsWheelDeltaAndReportsOpen()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnMouseWheel(0, 5);
            Assert.True(platform.PollEvents());
            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        /// <summary>
        ///     Verifies that polling events reports false once the window close callback ran.
        /// </summary>
        [Fact]
        public void PollEvents_ReportsFalseAfterWindowClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnWindowClose();
            Assert.False(platform.PollEvents());
        }

        /// <summary>
        ///     Verifies that the focus callback drives the visible flag.
        /// </summary>
        [Fact]
        public void OnWindowFocus_DrivesVisibleFlag()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnWindowFocus(true);
            Assert.True(platform.IsWindowVisible());
            platform.OnWindowFocus(false);
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        ///     Verifies that the cleanup operation is safe before initialization.
        /// </summary>
        [Fact]
        public void Cleanup_BeforeInitialization_DoesNotClearQueuedInput()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnKeyDown(65, 0);
            platform.Cleanup();
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        /// <summary>
        ///     Verifies that the proc address query executes whether the EGL native library
        ///     is present or absent.
        /// </summary>
        [Fact]
        public void GetProcAddress_WithOrWithoutNativeLibrary_DoesNotFail()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            try
            {
                IntPtr address = platform.GetProcAddress("glClear");
                Assert.NotEqual(IntPtr.Zero, address);
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Verifies that the default key states cover every console key as released.
        /// </summary>
        [Fact]
        public void InitializeDefaultKeyStates_AllKeysReleased()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.InitializeDefaultKeyStates();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
            platform.OnKeyDown(65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            platform.InitializeDefaultKeyStates();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }
    }
}
