// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformRemainingCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly platform remaining coverage tests class
    /// </summary>
    public class WebAssemblyPlatformRemainingCoverageTests
    {
        /// <summary>
        /// Tests that initialize full path returns false when egl fails
        /// </summary>
        [WebOnly]
        public void Initialize_FullPath_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test", null);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that initialize full path with icon path returns false when egl fails
        /// </summary>
        [WebOnly]
        public void Initialize_FullPath_WithIconPath_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test", "/icon.png");
            Assert.False(result);
        }

        /// <summary>
        /// Tests that initialize already initialized returns true
        /// </summary>
        [WebOnly]
        public void Initialize_AlreadyInitialized_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            SetPrivateField(platform, "_isInitialized", true);
            bool result = platform.Initialize(800, 600, "Test");
            Assert.True(result);
        }

        /// <summary>
        /// Tests that initialize already initialized with icon returns true
        /// </summary>
        [WebOnly]
        public void Initialize_AlreadyInitializedWithIcon_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            SetPrivateField(platform, "_isInitialized", true);
            bool result = platform.Initialize(800, 600, "Test", "/icon.png");
            Assert.True(result);
        }

        /// <summary>
        /// Tests that poll events update gamepad states no exception
        /// </summary>
        [WebOnly]
        public void PollEvents_UpdateGamepadStates_NoException()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.PollEvents();
            Assert.True(result);
        }

        /// <summary>
        /// Tests that update single gamepad state new index does not throw
        /// </summary>
        [WebOnly]
        public void UpdateSingleGamepadState_NewIndex_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "UpdateSingleGamepadState", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.NotNull(state);
        }

        /// <summary>
        /// Tests that update single gamepad state existing index updates state
        /// </summary>
        [WebOnly]
        public void UpdateSingleGamepadState_ExistingIndex_UpdatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "UpdateSingleGamepadState", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
        }

        /// <summary>
        /// Tests that update gamepad states multiple gamepads does not throw
        /// </summary>
        [WebOnly]
        public void UpdateGamepadStates_MultipleGamepads_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadConnect", 2);
            InvokePrivate(platform, "UpdateGamepadStates");
        }

        /// <summary>
        /// Tests that cleanup when not initialized does not clear state
        /// </summary>
        [WebOnly]
        public void Cleanup_WhenNotInitialized_DoesNotClearState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            platform.Cleanup();
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that cleanup when initialized clears state
        /// </summary>
        [WebOnly]
        public void Cleanup_WhenInitialized_ClearsState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that cleanup when initialized clears input chars
        /// </summary>
        [WebOnly]
        public void Cleanup_WhenInitialized_ClearsInputChars()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'X');
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetLastInputCharacters(out string _));
        }

        /// <summary>
        /// Tests that cleanup when initialized clears key queue
        /// </summary>
        [WebOnly]
        public void Cleanup_WhenInitialized_ClearsKeyQueue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
        }

        /// <summary>
        /// Tests that cleanup when initialized clears gamepad states
        /// </summary>
        [WebOnly]
        public void Cleanup_WhenInitialized_ClearsGamepadStates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetGamepadState(0, out GamepadState _));
        }

        /// <summary>
        /// Tests that make context current with zero handles does nothing
        /// </summary>
        [WebOnly]
        public void MakeContextCurrent_WithZeroHandles_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
        }

        /// <summary>
        /// Tests that swap buffers with zero handles does nothing
        /// </summary>
        [WebOnly]
        public void SwapBuffers_WithZeroHandles_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SwapBuffers();
        }

        /// <summary>
        /// Tests that get window metrics returns default values
        /// </summary>
        [WebOnly]
        public void GetWindowMetrics_ReturnsDefaultValues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);
            Assert.Equal(0, winX);
            Assert.Equal(0, winY);
            Assert.Equal(800, winW);
            Assert.Equal(600, winH);
            Assert.Equal(800, fbW);
            Assert.Equal(600, fbH);
        }

        /// <summary>
        /// Tests that get window metrics after resize returns updated values
        /// </summary>
        [WebOnly]
        public void GetWindowMetrics_AfterResize_ReturnsUpdatedValues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            platform.GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);
            Assert.Equal(1920, winW);
            Assert.Equal(1080, winH);
        }

        /// <summary>
        /// Tests that on key down key already down does not enqueue again
        /// </summary>
        [WebOnly]
        public void OnKeyDown_KeyAlreadyDown_DoesNotEnqueueAgain()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        /// <summary>
        /// Tests that on key down key not in states adds and enqueues
        /// </summary>
        [WebOnly]
        public void OnKeyDown_KeyNotInStates_AddsAndEnqueues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        /// <summary>
        /// Tests that on key up key exists sets false
        /// </summary>
        [WebOnly]
        public void OnKeyUp_KeyExists_SetsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that on key up key not in states does not throw
        /// </summary>
        [WebOnly]
        public void OnKeyUp_KeyNotInStates_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyUp", 999, 0);
        }

        /// <summary>
        /// Tests that on char input valid char appends to string builder
        /// </summary>
        [WebOnly]
        public void OnCharInput_ValidChar_AppendsToStringBuilder()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'A');
            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("A", chars);
        }

        /// <summary>
        /// Tests that on char input invalid char code does not throw
        /// </summary>
        [WebOnly]
        public void OnCharInput_InvalidCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0x110000);
        }

        /// <summary>
        /// Tests that on char input zero char code does not throw
        /// </summary>
        [WebOnly]
        public void OnCharInput_ZeroCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0);
        }

        /// <summary>
        /// Tests that on mouse move updates client coords
        /// </summary>
        [WebOnly]
        public void OnMouseMove_UpdatesClientCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out _);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        /// <summary>
        /// Tests that on mouse down negative button does not set button
        /// </summary>
        [WebOnly]
        public void OnMouseDown_NegativeButton_DoesNotSetButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", -1, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        /// <summary>
        /// Tests that on mouse down out of range button does not set button
        /// </summary>
        [WebOnly]
        public void OnMouseDown_OutOfRangeButton_DoesNotSetButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 10, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        /// <summary>
        /// Tests that on mouse up negative button does not throw
        /// </summary>
        [WebOnly]
        public void OnMouseUp_NegativeButton_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", -1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Tests that on mouse up out of range button does not throw
        /// </summary>
        [WebOnly]
        public void OnMouseUp_OutOfRangeButton_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", 10, 0, 0, 0, 0);
        }

        /// <summary>
        /// Tests that on window resize updates dimensions
        /// </summary>
        [WebOnly]
        public void OnWindowResize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that on window close sets should close
        /// </summary>
        [WebOnly]
        public void OnWindowClose_SetsShouldClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            Assert.False(platform.PollEvents());
        }

        /// <summary>
        /// Tests that on window focus true sets visible
        /// </summary>
        [WebOnly]
        public void OnWindowFocus_True_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", true);
            Assert.True(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that on window focus false clears visible
        /// </summary>
        [WebOnly]
        public void OnWindowFocus_False_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", false);
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that on gamepad connect creates new state
        /// </summary>
        [WebOnly]
        public void OnGamepadConnect_CreatesNewState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
        }

        /// <summary>
        /// Tests that on gamepad connect existing index does not overwrite
        /// </summary>
        [WebOnly]
        public void OnGamepadConnect_ExistingIndex_DoesNotOverwrite()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
        }

        /// <summary>
        /// Tests that on gamepad disconnect existing index sets disconnected
        /// </summary>
        [WebOnly]
        public void OnGamepadDisconnect_ExistingIndex_SetsDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.False(state.Connected);
        }

        /// <summary>
        /// Tests that on gamepad disconnect non existent index does not throw
        /// </summary>
        [WebOnly]
        public void OnGamepadDisconnect_NonExistentIndex_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadDisconnect", 99);
        }

        /// <summary>
        /// Tests that convert key code alphabet a maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetA_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that convert key code alphabet z maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetZ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 90, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Z));
        }

        /// <summary>
        /// Tests that convert key code number 0 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number0_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 48, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D0));
        }

        /// <summary>
        /// Tests that convert key code number 9 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number9_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 57, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D9));
        }

        /// <summary>
        /// Tests that convert key code enter maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Enter_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 13, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Enter));
        }

        /// <summary>
        /// Tests that convert key code tab maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Tab_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 9, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Tab));
        }

        /// <summary>
        /// Tests that convert key code spacebar maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Spacebar_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Spacebar));
        }

        /// <summary>
        /// Tests that convert key code backspace maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Backspace_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 8, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Backspace));
        }

        /// <summary>
        /// Tests that convert key code escape maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Escape_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 27, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
        }

        /// <summary>
        /// Tests that convert key code delete maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Delete_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 46, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Delete));
        }

        /// <summary>
        /// Tests that convert key code arrow keys maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_ArrowKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 37, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));
            InvokePrivate(platform, "OnKeyUp", 37, 0);
            InvokePrivate(platform, "OnKeyDown", 38, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.UpArrow));
            InvokePrivate(platform, "OnKeyUp", 38, 0);
            InvokePrivate(platform, "OnKeyDown", 39, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.RightArrow));
            InvokePrivate(platform, "OnKeyUp", 39, 0);
            InvokePrivate(platform, "OnKeyDown", 40, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.DownArrow));
        }

        /// <summary>
        /// Tests that convert key code function keys maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 112, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F1));
            InvokePrivate(platform, "OnKeyUp", 112, 0);
            InvokePrivate(platform, "OnKeyDown", 123, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F12));
        }

        /// <summary>
        /// Tests that convert key code numpad keys maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_NumpadKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 96, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad0));
            InvokePrivate(platform, "OnKeyUp", 96, 0);
            InvokePrivate(platform, "OnKeyDown", 105, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad9));
        }

        /// <summary>
        /// Tests that convert key code numpad operators maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_NumpadOperators_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 106, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Multiply));
            InvokePrivate(platform, "OnKeyUp", 106, 0);
            InvokePrivate(platform, "OnKeyDown", 107, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Add));
            InvokePrivate(platform, "OnKeyUp", 107, 0);
            InvokePrivate(platform, "OnKeyDown", 109, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Subtract));
            InvokePrivate(platform, "OnKeyUp", 109, 0);
            InvokePrivate(platform, "OnKeyDown", 110, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Decimal));
            InvokePrivate(platform, "OnKeyUp", 110, 0);
            InvokePrivate(platform, "OnKeyDown", 111, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Divide));
        }

        /// <summary>
        /// Tests that convert key code navigation keys maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_NavigationKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 36, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Home));
            InvokePrivate(platform, "OnKeyUp", 36, 0);
            InvokePrivate(platform, "OnKeyDown", 35, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.End));
            InvokePrivate(platform, "OnKeyUp", 35, 0);
            InvokePrivate(platform, "OnKeyDown", 33, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.PageUp));
            InvokePrivate(platform, "OnKeyUp", 33, 0);
            InvokePrivate(platform, "OnKeyDown", 34, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.PageDown));
            InvokePrivate(platform, "OnKeyUp", 34, 0);
            InvokePrivate(platform, "OnKeyDown", 45, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Insert));
            InvokePrivate(platform, "OnKeyUp", 45, 0);
            InvokePrivate(platform, "OnKeyDown", 19, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Pause));
        }

        /// <summary>
        /// Tests that convert key code modifier shift maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_ModifierShift_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 16, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));
        }

        /// <summary>
        /// Tests that convert key code modifier ctrl maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_ModifierCtrl_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 17, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
        }

        /// <summary>
        /// Tests that convert key code unknown key maps to no name
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_UnknownKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        /// <summary>
        /// Tests that convert key code negative key maps to no name
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_NegativeKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", -1, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        /// <summary>
        /// Tests that try get last key pressed empty queue returns false
        /// </summary>
        [WebOnly]
        public void TryGetLastKeyPressed_EmptyQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.NoName, key);
        }

        /// <summary>
        /// Tests that try get last key pressed queue with items returns true
        /// </summary>
        [WebOnly]
        public void TryGetLastKeyPressed_QueueWithItems_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        /// <summary>
        /// Tests that is key down key in states returns value
        /// </summary>
        [WebOnly]
        public void IsKeyDown_KeyInStates_ReturnsValue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that is key down key not in states returns false
        /// </summary>
        [WebOnly]
        public void IsKeyDown_KeyNotInStates_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
        }

        /// <summary>
        /// Tests that try get last input characters has chars returns true
        /// </summary>
        [WebOnly]
        public void TryGetLastInputCharacters_HasChars_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'H');
            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("H", chars);
        }

        /// <summary>
        /// Tests that try get last input characters empty returns false
        /// </summary>
        [WebOnly]
        public void TryGetLastInputCharacters_Empty_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal(string.Empty, chars);
        }

        /// <summary>
        /// Tests that try get last input characters clears after read
        /// </summary>
        [WebOnly]
        public void TryGetLastInputCharacters_ClearsAfterRead()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'A');
            Assert.True(platform.TryGetLastInputCharacters(out _));
            Assert.False(platform.TryGetLastInputCharacters(out _));
        }

        /// <summary>
        /// Tests that gamepad state default state connected false
        /// </summary>
        [WebOnly]
        public void GamepadState_DefaultState_ConnectedFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.Connected);
        }

        /// <summary>
        /// Tests that gamepad state get button valid index returns value
        /// </summary>
        [WebOnly]
        public void GamepadState_GetButton_ValidIndex_ReturnsValue()
        {
            GamepadState state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.GetButton(0));
            Assert.True(state.GetButton(0));
        }

        /// <summary>
        /// Tests that gamepad state get button invalid index returns false
        /// </summary>
        [WebOnly]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(-1));
            Assert.False(state.GetButton(100));
        }

        /// <summary>
        /// Tests that gamepad state get button index boundary returns false
        /// </summary>
        [WebOnly]
        public void GamepadState_GetButton_IndexBoundary_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(13));
        }

        /// <summary>
        /// Tests that gamepad state button a returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonA_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonA);
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        /// <summary>
        /// Tests that gamepad state button b returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonB_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonB);
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        /// <summary>
        /// Tests that gamepad state button x returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonX_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonX);
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        /// <summary>
        /// Tests that gamepad state button y returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonY_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonY);
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        /// <summary>
        /// Tests that gamepad state button lb returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonLb_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLb);
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        /// <summary>
        /// Tests that gamepad state button rb returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonRb_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRb);
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        /// <summary>
        /// Tests that gamepad state button left stick click returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonLeftStickClick_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLeftStickClick);
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        /// <summary>
        /// Tests that gamepad state button right stick click returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonRightStickClick_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRightStickClick);
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        /// <summary>
        /// Tests that gamepad state button start returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonStart_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonStart);
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        /// <summary>
        /// Tests that gamepad state button back returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonBack_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonBack);
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        /// <summary>
        /// Tests that gamepad state button guide returns correct value
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonGuide_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonGuide);
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        /// <summary>
        /// Tests that gamepad state all button properties default are false
        /// </summary>
        [WebOnly]
        public void GamepadState_AllButtonProperties_DefaultAreFalse()
        {
            GamepadState state = new GamepadState();
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
        }

        /// <summary>
        /// Tests that get mouse wheel default returns zero
        /// </summary>
        [WebOnly]
        public void GetMouseWheel_Default_ReturnsZero()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        /// <summary>
        /// Tests that get mouse wheel after wheel event returns delta
        /// </summary>
        [WebOnly]
        public void GetMouseWheel_AfterWheelEvent_ReturnsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 42);
            Assert.Equal(42.0f, platform.GetMouseWheel(), 5);
        }

        /// <summary>
        /// Tests that get mouse state returns cloned array not same reference
        /// </summary>
        [WebOnly]
        public void GetMouseState_ReturnsClonedArray_NotSameReference()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMouseState(out _, out _, out bool[] first);
            platform.GetMouseState(out _, out _, out bool[] second);
            Assert.NotSame(first, second);
        }

        /// <summary>
        /// Tests that get mouse position in view after mouse move returns updated coords
        /// </summary>
        [WebOnly]
        public void GetMousePositionInView_AfterMouseMove_ReturnsUpdatedCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 0, 0, 123, 456);
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(123.0f, x);
            Assert.Equal(456.0f, y);
        }

        /// <summary>
        /// Tests that get window position x returns default on non browser
        /// </summary>
        [WebOnly]
        public void GetWindowPositionX_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0, platform.GetWindowPositionX());
        }

        /// <summary>
        /// Tests that get window position y returns default on non browser
        /// </summary>
        [WebOnly]
        public void GetWindowPositionY_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0, platform.GetWindowPositionY());
        }

        /// <summary>
        /// Tests that show window sets visible
        /// </summary>
        [WebOnly]
        public void ShowWindow_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that hide window clears visible
        /// </summary>
        [WebOnly]
        public void HideWindow_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that show hide window toggle works repeatedly
        /// </summary>
        [WebOnly]
        public void ShowHideWindow_Toggle_WorksRepeatedly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that set title does not throw
        /// </summary>
        [WebOnly]
        public void SetTitle_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle("Test Title");
        }

        /// <summary>
        /// Tests that set title empty string does not throw
        /// </summary>
        [WebOnly]
        public void SetTitle_EmptyString_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle(string.Empty);
        }

        /// <summary>
        /// Tests that set title null string does not throw
        /// </summary>
        [WebOnly]
        public void SetTitle_NullString_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle(null);
        }

        /// <summary>
        /// Tests that set size updates dimensions
        /// </summary>
        [WebOnly]
        public void SetSize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(1024, 768);
            Assert.Equal(1024, platform.GetWindowWidth());
            Assert.Equal(768, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that set size zero dimensions does not throw
        /// </summary>
        [WebOnly]
        public void SetSize_ZeroDimensions_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(0, 0);
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that set size negative dimensions does not throw
        /// </summary>
        [WebOnly]
        public void SetSize_NegativeDimensions_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(-100, -200);
            Assert.Equal(-100, platform.GetWindowWidth());
            Assert.Equal(-200, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that set window icon valid path does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_ValidPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("/icon.png");
        }

        /// <summary>
        /// Tests that set window icon empty path does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(string.Empty);
        }

        /// <summary>
        /// Tests that set window icon null path does not throw
        /// </summary>
        [WebOnly]
        public void SetWindowIcon_NullPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(null);
        }

        /// <summary>
        /// Tests that get connected gamepad indices empty returns empty array
        /// </summary>
        [WebOnly]
        public void GetConnectedGamepadIndices_Empty_ReturnsEmptyArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        /// <summary>
        /// Tests that get connected gamepad indices with connections returns indices
        /// </summary>
        [WebOnly]
        public void GetConnectedGamepadIndices_WithConnections_ReturnsIndices()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Equal(2, indices.Length);
            Assert.Contains(0, indices);
            Assert.Contains(1, indices);
        }

        /// <summary>
        /// Tests that get connected gamepad indices after disconnect returns only connected
        /// </summary>
        [WebOnly]
        public void GetConnectedGamepadIndices_AfterDisconnect_ReturnsOnlyConnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadDisconnect", 1);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
            Assert.Contains(0, indices);
        }

        /// <summary>
        /// Tests that poll events returns true when not closing
        /// </summary>
        [WebOnly]
        public void PollEvents_ReturnsTrue_WhenNotClosing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.True(platform.PollEvents());
        }

        /// <summary>
        /// Tests that poll events returns false after window close
        /// </summary>
        [WebOnly]
        public void PollEvents_ReturnsFalse_AfterWindowClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            Assert.False(platform.PollEvents());
        }

        /// <summary>
        /// Tests that poll events resets mouse wheel delta
        /// </summary>
        [WebOnly]
        public void PollEvents_ResetsMouseWheelDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 100);
            Assert.Equal(100.0f, platform.GetMouseWheel(), 5);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        /// <summary>
        /// Tests that get proc address throws on non browser
        /// </summary>
        [WebOnly]
        public void GetProcAddress_ThrowsOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.ThrowsAny<Exception>(() => platform.GetProcAddress("glClearColor"));
        }

        /// <summary>
        /// Tests that try get gamepad state non existent returns false
        /// </summary>
        [WebOnly]
        public void TryGetGamepadState_NonExistent_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.Null(state);
        }

        /// <summary>
        /// Tests that try get gamepad state existent returns true
        /// </summary>
        [WebOnly]
        public void TryGetGamepadState_Existent_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.NotNull(state);
            Assert.True(state.Connected);
        }

        /// <summary>
        /// Tests that register input events does not throw on non browser
        /// </summary>
        [WebOnly]
        public void RegisterInputEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterInputEvents");
        }

        /// <summary>
        /// Tests that register keyboard events does not throw on non browser
        /// </summary>
        [WebOnly]
        public void RegisterKeyboardEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterKeyboardEvents");
        }

        /// <summary>
        /// Tests that register mouse events does not throw on non browser
        /// </summary>
        [WebOnly]
        public void RegisterMouseEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterMouseEvents");
        }

        /// <summary>
        /// Tests that register gamepad events does not throw on non browser
        /// </summary>
        [WebOnly]
        public void RegisterGamepadEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterGamepadEvents");
        }

        /// <summary>
        /// Tests that register window events does not throw on non browser
        /// </summary>
        [WebOnly]
        public void RegisterWindowEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterWindowEvents");
        }

        /// <summary>
        /// Invokes the private using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="methodName">The method name</param>
        /// <param name="arguments">The arguments</param>
        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }

        /// <summary>
        /// Sets the private field using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetPrivateField(object instance, string fieldName, object value)
        {
            FieldInfo field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(field);
            field.SetValue(instance, value);
        }
    }
}
