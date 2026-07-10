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
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblyPlatformRemainingCoverageTests
    {
        [Fact]
        public void Initialize_FullPath_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test", null);
            Assert.False(result);
        }

        [Fact]
        public void Initialize_FullPath_WithIconPath_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test", "/icon.png");
            Assert.False(result);
        }

        [Fact]
        public void Initialize_AlreadyInitialized_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            SetPrivateField(platform, "_isInitialized", true);
            bool result = platform.Initialize(800, 600, "Test");
            Assert.True(result);
        }

        [Fact]
        public void Initialize_AlreadyInitializedWithIcon_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            SetPrivateField(platform, "_isInitialized", true);
            bool result = platform.Initialize(800, 600, "Test", "/icon.png");
            Assert.True(result);
        }

        [Fact]
        public void PollEvents_UpdateGamepadStates_NoException()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.PollEvents();
            Assert.True(result);
        }

        [Fact]
        public void UpdateSingleGamepadState_NewIndex_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "UpdateSingleGamepadState", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.NotNull(state);
        }

        [Fact]
        public void UpdateSingleGamepadState_ExistingIndex_UpdatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "UpdateSingleGamepadState", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
        }

        [Fact]
        public void UpdateGamepadStates_MultipleGamepads_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadConnect", 2);
            InvokePrivate(platform, "UpdateGamepadStates");
        }

        [Fact]
        public void Cleanup_WhenNotInitialized_DoesNotClearState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            platform.Cleanup();
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void Cleanup_WhenInitialized_ClearsState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void Cleanup_WhenInitialized_ClearsInputChars()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'X');
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetLastInputCharacters(out string _));
        }

        [Fact]
        public void Cleanup_WhenInitialized_ClearsKeyQueue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
        }

        [Fact]
        public void Cleanup_WhenInitialized_ClearsGamepadStates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            SetPrivateField(platform, "_isInitialized", true);
            platform.Cleanup();
            Assert.False(platform.TryGetGamepadState(0, out GamepadState _));
        }

        [Fact]
        public void MakeContextCurrent_WithZeroHandles_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
        }

        [Fact]
        public void SwapBuffers_WithZeroHandles_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SwapBuffers();
        }

        [Fact]
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

        [Fact]
        public void GetWindowMetrics_AfterResize_ReturnsUpdatedValues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            platform.GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);
            Assert.Equal(1920, winW);
            Assert.Equal(1080, winH);
        }

        [Fact]
        public void OnKeyDown_KeyAlreadyDown_DoesNotEnqueueAgain()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        [Fact]
        public void OnKeyDown_KeyNotInStates_AddsAndEnqueues()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        [Fact]
        public void OnKeyUp_KeyExists_SetsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void OnKeyUp_KeyNotInStates_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyUp", 999, 0);
        }

        [Fact]
        public void OnCharInput_ValidChar_AppendsToStringBuilder()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'A');
            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("A", chars);
        }

        [Fact]
        public void OnCharInput_InvalidCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0x110000);
        }

        [Fact]
        public void OnCharInput_ZeroCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0);
        }

        [Fact]
        public void OnMouseMove_UpdatesClientCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out _);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        [Fact]
        public void OnMouseDown_NegativeButton_DoesNotSetButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", -1, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        [Fact]
        public void OnMouseDown_OutOfRangeButton_DoesNotSetButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 10, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        [Fact]
        public void OnMouseUp_NegativeButton_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", -1, 0, 0, 0, 0);
        }

        [Fact]
        public void OnMouseUp_OutOfRangeButton_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", 10, 0, 0, 0, 0);
        }

        [Fact]
        public void OnWindowResize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        [Fact]
        public void OnWindowClose_SetsShouldClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            Assert.False(platform.PollEvents());
        }

        [Fact]
        public void OnWindowFocus_True_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", true);
            Assert.True(platform.IsWindowVisible());
        }

        [Fact]
        public void OnWindowFocus_False_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", false);
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
        public void OnGamepadConnect_CreatesNewState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.True(state.Connected);
        }

        [Fact]
        public void OnGamepadConnect_ExistingIndex_DoesNotOverwrite()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
        }

        [Fact]
        public void OnGamepadDisconnect_ExistingIndex_SetsDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.False(state.Connected);
        }

        [Fact]
        public void OnGamepadDisconnect_NonExistentIndex_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadDisconnect", 99);
        }

        [Fact]
        public void ConvertKeyCode_AlphabetA_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetZ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 90, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Z));
        }

        [Fact]
        public void ConvertKeyCode_Number0_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 48, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D0));
        }

        [Fact]
        public void ConvertKeyCode_Number9_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 57, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D9));
        }

        [Fact]
        public void ConvertKeyCode_Enter_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 13, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Enter));
        }

        [Fact]
        public void ConvertKeyCode_Tab_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 9, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Tab));
        }

        [Fact]
        public void ConvertKeyCode_Spacebar_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Spacebar));
        }

        [Fact]
        public void ConvertKeyCode_Backspace_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 8, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Backspace));
        }

        [Fact]
        public void ConvertKeyCode_Escape_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 27, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
        }

        [Fact]
        public void ConvertKeyCode_Delete_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 46, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Delete));
        }

        [Fact]
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

        [Fact]
        public void ConvertKeyCode_FunctionKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 112, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F1));
            InvokePrivate(platform, "OnKeyUp", 112, 0);
            InvokePrivate(platform, "OnKeyDown", 123, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F12));
        }

        [Fact]
        public void ConvertKeyCode_NumpadKeys_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 96, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad0));
            InvokePrivate(platform, "OnKeyUp", 96, 0);
            InvokePrivate(platform, "OnKeyDown", 105, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad9));
        }

        [Fact]
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

        [Fact]
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

        [Fact]
        public void ConvertKeyCode_ModifierShift_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 16, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));
        }

        [Fact]
        public void ConvertKeyCode_ModifierCtrl_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 17, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
        }

        [Fact]
        public void ConvertKeyCode_UnknownKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        [Fact]
        public void ConvertKeyCode_NegativeKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", -1, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        [Fact]
        public void TryGetLastKeyPressed_EmptyQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.NoName, key);
        }

        [Fact]
        public void TryGetLastKeyPressed_QueueWithItems_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        [Fact]
        public void IsKeyDown_KeyInStates_ReturnsValue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void IsKeyDown_KeyNotInStates_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
        }

        [Fact]
        public void TryGetLastInputCharacters_HasChars_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'H');
            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("H", chars);
        }

        [Fact]
        public void TryGetLastInputCharacters_Empty_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal(string.Empty, chars);
        }

        [Fact]
        public void TryGetLastInputCharacters_ClearsAfterRead()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'A');
            Assert.True(platform.TryGetLastInputCharacters(out _));
            Assert.False(platform.TryGetLastInputCharacters(out _));
        }

        [Fact]
        public void GamepadState_DefaultState_ConnectedFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.Connected);
        }

        [Fact]
        public void GamepadState_GetButton_ValidIndex_ReturnsValue()
        {
            GamepadState state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.GetButton(0));
            Assert.True(state.GetButton(0));
        }

        [Fact]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(-1));
            Assert.False(state.GetButton(100));
        }

        [Fact]
        public void GamepadState_GetButton_IndexBoundary_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(13));
        }

        [Fact]
        public void GamepadState_ButtonA_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonA);
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        [Fact]
        public void GamepadState_ButtonB_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonB);
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        [Fact]
        public void GamepadState_ButtonX_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonX);
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        [Fact]
        public void GamepadState_ButtonY_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonY);
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        [Fact]
        public void GamepadState_ButtonLb_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLb);
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        [Fact]
        public void GamepadState_ButtonRb_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRb);
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        [Fact]
        public void GamepadState_ButtonLeftStickClick_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLeftStickClick);
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        [Fact]
        public void GamepadState_ButtonRightStickClick_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRightStickClick);
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        [Fact]
        public void GamepadState_ButtonStart_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonStart);
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        [Fact]
        public void GamepadState_ButtonBack_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonBack);
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        [Fact]
        public void GamepadState_ButtonGuide_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonGuide);
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        [Fact]
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

        [Fact]
        public void GetMouseWheel_Default_ReturnsZero()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        [Fact]
        public void GetMouseWheel_AfterWheelEvent_ReturnsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 42);
            Assert.Equal(42.0f, platform.GetMouseWheel(), 5);
        }

        [Fact]
        public void GetMouseState_ReturnsClonedArray_NotSameReference()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMouseState(out _, out _, out bool[] first);
            platform.GetMouseState(out _, out _, out bool[] second);
            Assert.NotSame(first, second);
        }

        [Fact]
        public void GetMousePositionInView_AfterMouseMove_ReturnsUpdatedCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 0, 0, 123, 456);
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(123.0f, x);
            Assert.Equal(456.0f, y);
        }

        [Fact]
        public void GetWindowPositionX_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0, platform.GetWindowPositionX());
        }

        [Fact]
        public void GetWindowPositionY_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(0, platform.GetWindowPositionY());
        }

        [Fact]
        public void ShowWindow_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
        }

        [Fact]
        public void HideWindow_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
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

        [Fact]
        public void SetTitle_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle("Test Title");
        }

        [Fact]
        public void SetTitle_EmptyString_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle(string.Empty);
        }

        [Fact]
        public void SetTitle_NullString_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle(null);
        }

        [Fact]
        public void SetSize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(1024, 768);
            Assert.Equal(1024, platform.GetWindowWidth());
            Assert.Equal(768, platform.GetWindowHeight());
        }

        [Fact]
        public void SetSize_ZeroDimensions_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(0, 0);
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
        }

        [Fact]
        public void SetSize_NegativeDimensions_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(-100, -200);
            Assert.Equal(-100, platform.GetWindowWidth());
            Assert.Equal(-200, platform.GetWindowHeight());
        }

        [Fact]
        public void SetWindowIcon_ValidPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("/icon.png");
        }

        [Fact]
        public void SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(string.Empty);
        }

        [Fact]
        public void SetWindowIcon_NullPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(null);
        }

        [Fact]
        public void GetConnectedGamepadIndices_Empty_ReturnsEmptyArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        [Fact]
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

        [Fact]
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

        [Fact]
        public void PollEvents_ReturnsTrue_WhenNotClosing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.True(platform.PollEvents());
        }

        [Fact]
        public void PollEvents_ReturnsFalse_AfterWindowClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            Assert.False(platform.PollEvents());
        }

        [Fact]
        public void PollEvents_ResetsMouseWheelDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 100);
            Assert.Equal(100.0f, platform.GetMouseWheel(), 5);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        [Fact]
        public void GetProcAddress_ThrowsOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.ThrowsAny<Exception>(() => platform.GetProcAddress("glClearColor"));
        }

        [Fact]
        public void TryGetGamepadState_NonExistent_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.Null(state);
        }

        [Fact]
        public void TryGetGamepadState_Existent_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.NotNull(state);
            Assert.True(state.Connected);
        }

        [Fact]
        public void RegisterInputEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterInputEvents");
        }

        [Fact]
        public void RegisterKeyboardEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterKeyboardEvents");
        }

        [Fact]
        public void RegisterMouseEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterMouseEvents");
        }

        [Fact]
        public void RegisterGamepadEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterGamepadEvents");
        }

        [Fact]
        public void RegisterWindowEvents_DoesNotThrowOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "RegisterWindowEvents");
        }

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }

        private static void SetPrivateField(object instance, string fieldName, object value)
        {
            FieldInfo field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(field);
            field.SetValue(instance, value);
        }
    }
}
