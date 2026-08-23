// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManagerCoverageTests.cs
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
    ///     The web assembly input manager coverage tests class
    /// </summary>
    public class WebAssemblyInputManagerCoverageTests
    {
        /// <summary>
        ///     Tests that is action active with registered key not pressed returns false
        /// </summary>
        [Fact]
        public void IsActionActive_WithRegisteredKeyNotPressed_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("jump", ConsoleKey.Spacebar);

            Assert.False(manager.IsActionActive("jump"));
        }

        /// <summary>
        ///     Tests that is action just pressed with matching bound key returns true
        /// </summary>
        [Fact]
        public void IsActionJustPressed_WithMatchingBoundKey_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("jump", ConsoleKey.Spacebar);
            platform.OnKeyDown(32, 0);

            Assert.True(manager.IsActionJustPressed("jump"));
        }

        /// <summary>
        ///     Tests that is action just pressed with non matching key consumes and returns false
        /// </summary>
        [Fact]
        public void IsActionJustPressed_WithNonMatchingKey_ConsumesAndReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("jump", ConsoleKey.Spacebar);
            platform.OnKeyDown(65, 0);

            Assert.False(manager.IsActionJustPressed("jump"));
        }

        /// <summary>
        ///     Tests that update tracks gamepad and mouse state
        /// </summary>
        [Fact]
        public void Update_TracksGamepadAndMouseState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            platform.OnGamepadConnect(1);
            platform.OnMouseWheel(0, 5);

            manager.Update();

            Assert.Equal(2, manager.GetConnectedGamepadIndices().Length);
            Assert.True(manager._previousGamepadStates.ContainsKey(0));
            Assert.True(manager._previousGamepadStates.ContainsKey(1));
            Assert.Equal(5.0f, manager.GetMouseWheelDelta());
        }

        /// <summary>
        ///     Tests that update gamepad states refreshes existing gamepad state
        /// </summary>
        [Fact]
        public void UpdateGamepadStates_RefreshesExistingGamepadState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);

            manager.Update();
            manager.Update();

            Assert.True(manager._previousGamepadStates.ContainsKey(0));
        }

        /// <summary>
        ///     Tests that get mouse position returns platform coordinates
        /// </summary>
        [Fact]
        public void GetMousePosition_ReturnsPlatformCoordinates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnMouseMove(0, 0, 100, 200);

            manager.GetMousePosition(out int x, out int y);

            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        /// <summary>
        ///     Tests that get mouse wheel delta returns last updated delta
        /// </summary>
        [Fact]
        public void GetMouseWheelDelta_ReturnsLastUpdatedDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnMouseWheel(0, 7);

            manager.Update();

            Assert.Equal(7.0f, manager.GetMouseWheelDelta());
        }

        /// <summary>
        ///     Tests that is mouse button down pressed button returns true
        /// </summary>
        [Fact]
        public void IsMouseButtonDown_PressedButton_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnMouseDown(0, 0, 0, 50, 50);

            Assert.True(manager.IsMouseButtonDown(0));

            platform.OnMouseUp(0, 0, 0, 50, 50);

            Assert.False(manager.IsMouseButtonDown(0));
        }

        /// <summary>
        ///     Tests that is mouse button down invalid button returns false
        /// </summary>
        [Fact]
        public void IsMouseButtonDown_InvalidButton_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);

            Assert.False(manager.IsMouseButtonDown(-1));
            Assert.False(manager.IsMouseButtonDown(10));
        }

        /// <summary>
        ///     Tests that try get gamepad state connected gamepad returns true with state
        /// </summary>
        [Fact]
        public void TryGetGamepadState_ConnectedGamepad_ReturnsTrueWithState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);

            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);

            Assert.True(result);
            Assert.NotNull(state);
            Assert.NotNull(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        /// <summary>
        ///     Tests that try get gamepad state with previous state sets previous
        /// </summary>
        [Fact]
        public void TryGetGamepadState_WithPreviousState_SetsPrevious()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            manager.Update();

            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);

            Assert.True(result);
            Assert.NotNull(state.PreviousState);
        }

        /// <summary>
        ///     Tests that try get gamepad state no gamepad returns false
        /// </summary>
        [Fact]
        public void TryGetGamepadState_NoGamepad_ReturnsFalse()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);

            Assert.False(result);
            Assert.Null(state);
        }

        /// <summary>
        ///     Tests that get connected gamepad indices returns connected only
        /// </summary>
        [Fact]
        public void GetConnectedGamepadIndices_ReturnsConnectedOnly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            platform.OnGamepadConnect(1);
            platform.OnGamepadDisconnect(1);

            int[] indices = manager.GetConnectedGamepadIndices();

            Assert.Single(indices);
            Assert.Equal(0, indices[0]);
        }

        /// <summary>
        ///     Tests that is gamepad button just pressed no gamepad returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_NoGamepad_ReturnsFalse()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }


        /// <summary>
        ///     Tests that is gamepad button just released no gamepad returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustReleased_NoGamepad_ReturnsFalse()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        /// <summary>
        ///     Tests that is gamepad button just released no previous state returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustReleased_NoPreviousState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);

            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        /// <summary>
        ///     Tests that vibrate gamepad returns false on non browser
        /// </summary>
        [Fact]
        public void VibrateGamepad_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputManager.VibrateGamepad(0, 1.0f, 0.5f));
        }

        /// <summary>
        ///     Tests that get key name unknown key returns unknown
        /// </summary>
        [Fact]
        public void GetKeyName_UnknownKey_ReturnsUnknown()
        {
            Assert.Equal("Unknown", WebAssemblyInputManager.GetKeyName(ConsoleKey.NoName));
        }

        /// <summary>
        ///     Tests that key binding remove key removes the key
        /// </summary>
        [Fact]
        public void KeyBinding_RemoveKey_RemovesTheKey()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);

            binding.RemoveKey(ConsoleKey.A);

            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        ///     Tests that key binding contains key works
        /// </summary>
        [Fact]
        public void KeyBinding_ContainsKey_Works()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.B);

            Assert.True(binding.ContainsKey(ConsoleKey.B));
            Assert.False(binding.ContainsKey(ConsoleKey.C));
        }

        /// <summary>
        ///     Tests that gamepad input state properties default to null
        /// </summary>
        [Fact]
        public void GamepadInputState_Properties_DefaultToNull()
        {
            GamepadInputState state = new GamepadInputState();

            Assert.Null(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        /// <summary>
        ///     Tests that gamepad input state update moves current to previous
        /// </summary>
        [Fact]
        public void GamepadInputState_Update_MovesCurrentToPrevious()
        {
            GamepadInputState state = new GamepadInputState();
            GamepadState first = new GamepadState();
            GamepadState second = new GamepadState();
            state.CurrentState = first;

            state.Update(second);

            Assert.Same(first, state.PreviousState);
            Assert.Same(second, state.CurrentState);
        }

        /// <summary>
        ///     Tests that touch point default is active and begin
        /// </summary>
        [Fact]
        public void TouchPoint_Default_IsActiveAndBegin()
        {
            TouchPoint touch = new TouchPoint();

            Assert.True(touch.IsActive);
            Assert.Equal(TouchState.Begin, touch.State);
        }

        /// <summary>
        ///     Tests that touch point properties round trip
        /// </summary>
        [Fact]
        public void TouchPoint_Properties_RoundTrip()
        {
            TouchPoint touch = new TouchPoint
            {
                Id = 3,
                X = 10,
                Y = 20,
                IsActive = false,
                State = TouchState.Ended
            };

            Assert.Equal(3, touch.Id);
            Assert.Equal(10, touch.X);
            Assert.Equal(20, touch.Y);
            Assert.False(touch.IsActive);
            Assert.Equal(TouchState.Ended, touch.State);
        }

        /// <summary>
        ///     Tests that input context constructor with null platform throws
        /// </summary>
        [Fact]
        public void InputContext_Constructor_WithNullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyInputContext(null));
        }

        /// <summary>
        ///     Tests that input context constructor assigns fields and getters
        /// </summary>
        [Fact]
        public void InputContext_Constructor_AssignsFieldsAndGetters()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);

            Assert.Same(platform, context.Platform);
            Assert.NotNull(context.InputManager);
            Assert.Same(platform, context._platform);
        }

        /// <summary>
        ///     Tests that input context try get text input with no input returns false
        /// </summary>
        [Fact]
        public void InputContext_TryGetTextInput_NoInput_ReturnsFalse()
        {
            WebAssemblyInputContext context = new WebAssemblyInputContext(new WebAssemblyPlatform());

            bool result = context.TryGetTextInput(out string text);

            Assert.False(result);
            Assert.Equal(string.Empty, text);
        }

        /// <summary>
        ///     Tests that input context try get text input with input returns true
        /// </summary>
        [Fact]
        public void InputContext_TryGetTextInput_WithInput_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            platform.OnCharInput((uint)'X');

            bool result = context.TryGetTextInput(out string text);

            Assert.True(result);
            Assert.Equal("X", text);
        }

        /// <summary>
        ///     Tests that input context update does not throw
        /// </summary>
        [Fact]
        public void InputContext_Update_DoesNotThrow()
        {
            WebAssemblyInputContext context = new WebAssemblyInputContext(new WebAssemblyPlatform());

            context.Update();
        }

        /// <summary>
        ///     Tests that input context lock pointer returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_LockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.LockPointer());
        }

        /// <summary>
        ///     Tests that input context unlock pointer returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_UnlockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.UnlockPointer());
        }

        /// <summary>
        ///     Tests that input context is pointer locked returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_IsPointerLocked_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsPointerLocked());
        }

        /// <summary>
        ///     Tests that input context request fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_RequestFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.RequestFullscreen());
        }

        /// <summary>
        ///     Tests that input context exit fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.ExitFullscreen());
        }

        /// <summary>
        ///     Tests that input context is fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsFullscreen());
        }
    }
}
