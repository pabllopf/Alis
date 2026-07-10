// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManagerRemainingCoverageTests.cs
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
    public class WebAssemblyInputManagerRemainingCoverageTests
    {
        // =====================================================================
        // GamepadInputState Tests
        // =====================================================================

        [Fact]
        public void GamepadInputState_Default_PropertiesAreNull()
        {
            GamepadInputState state = new GamepadInputState();
            Assert.Null(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_SetsCurrentAndPrevious()
        {
            GamepadInputState state = new GamepadInputState();
            GamepadState gs1 = new GamepadState();
            GamepadState gs2 = new GamepadState();

            state.Update(gs1);
            Assert.Same(gs1, state.CurrentState);
            Assert.Null(state.PreviousState);

            state.Update(gs2);
            Assert.Same(gs2, state.CurrentState);
            Assert.Same(gs1, state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_MultipleTimes_ShiftsCorrectly()
        {
            GamepadInputState state = new GamepadInputState();
            GamepadState gs1 = new GamepadState { Connected = true };
            GamepadState gs2 = new GamepadState { Connected = false };
            GamepadState gs3 = new GamepadState { Connected = true };

            state.Update(gs1);
            state.Update(gs2);
            state.Update(gs3);

            Assert.Same(gs3, state.CurrentState);
            Assert.Same(gs2, state.PreviousState);
            Assert.True(state.CurrentState.Connected);
            Assert.False(state.PreviousState.Connected);
        }

        // =====================================================================
        // KeyBinding.IsActive (direct, not via IsActionActive)
        // =====================================================================

        [Fact]
        public void KeyBinding_IsActive_WithNoKeys_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            KeyBinding binding = new KeyBinding();
            Assert.False(binding.IsActive(platform));
        }

        [Fact]
        public void KeyBinding_IsActive_WithKeyDown_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(binding.IsActive(platform));
        }

        [Fact]
        public void KeyBinding_IsActive_WithKeyUp_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            InvokePrivate(platform, "OnKeyUp", 70, 0);
            Assert.False(binding.IsActive(platform));
        }

        [Fact]
        public void KeyBinding_IsActive_MultipleKeys_OneDown_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.F);
            binding.AddKey(ConsoleKey.G);
            binding.AddKey(ConsoleKey.H);
            InvokePrivate(platform, "OnKeyDown", 71, 0);
            Assert.True(binding.IsActive(platform));
        }

        // =====================================================================
        // TryGetGamepadState - successful path
        // =====================================================================

        [Fact]
        public void TryGetGamepadState_WithConnectedGamepad_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);
            Assert.True(result);
            Assert.NotNull(state);
            Assert.NotNull(state.CurrentState);
            Assert.True(state.CurrentState.Connected);
        }

        [Fact]
        public void TryGetGamepadState_WithPreviousState_SetsPrevious()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);
            Assert.True(result);
            Assert.NotNull(state.PreviousState);
        }

        [Fact]
        public void TryGetGamepadState_DisconnectedGamepad_ReturnsTrueWithConnectedFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);
            Assert.True(result);
            Assert.NotNull(state);
            Assert.NotNull(state.CurrentState);
            Assert.False(state.CurrentState.Connected);
        }

        // =====================================================================
        // IsGamepadButtonJustPressed - full branching
        // =====================================================================

        [Fact]
        public void IsGamepadButtonJustPressed_NoPreviousState_ButtonDown_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[0] = true;
            Assert.True(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustPressed_NoPreviousState_ButtonUp_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[0] = true;
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_ButtonUp_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_ButtonReleased_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[0] = true;
            manager.Update();
            manager.Update();
            gs.Buttons[0] = false;
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        // =====================================================================
        // IsGamepadButtonJustReleased - full branching
        // =====================================================================

        [Fact]
        public void IsGamepadButtonJustReleased_NoPreviousState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_ButtonDown_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[1] = true;
            manager.Update();
            manager.Update();
            Assert.False(manager.IsGamepadButtonJustReleased(0, 1));
        }

        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_Released_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[1] = true;
            manager.Update();
            manager.Update();
            gs.Buttons[1] = false;
            Assert.False(manager.IsGamepadButtonJustReleased(0, 1));
        }

        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_Pressed_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            GamepadState gs = GetGamepadState(platform, 0);
            gs.Buttons[3] = true;
            Assert.False(manager.IsGamepadButtonJustReleased(0, 3));
        }

        // =====================================================================
        // Update with gamepad coverage
        // =====================================================================

        [Fact]
        public void Update_WithConnectedGamepad_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            manager.Update();
        }

        [Fact]
        public void Update_MultipleTimes_WithGamepad_TracksPreviousState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            manager.Update();
            manager.Update();
            manager.Update();
            Assert.True(manager.TryGetGamepadState(0, out GamepadInputState state));
            Assert.NotNull(state.PreviousState);
        }

        // =====================================================================
        // IsActionJustPressed - multiple keys in queue
        // =====================================================================

        [Fact]
        public void IsActionJustPressed_MultipleKeys_FirstNonMatchingThenMatching_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void IsActionJustPressed_MultipleNonMatchingKeys_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyDown", 66, 0);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        // =====================================================================
        // Update resets nothing but calls UpdateMouseState
        // =====================================================================

        [Fact]
        public void Update_GetMouseWheelDelta_AfterUpdate_ReturnsLastDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 7);
            manager.Update();
            Assert.Equal(7.0f, manager.GetMouseWheelDelta());
        }

        [Fact]
        public void Update_GetMousePosition_AfterUpdate_ReturnsCurrent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseMove", 0, 0, 320, 240);
            manager.Update();
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(320, x);
            Assert.Equal(240, y);
        }

        // =====================================================================
        // GetConnectedGamepadIndices - with connected gamepads
        // =====================================================================

        [Fact]
        public void GetConnectedGamepadIndices_WithConnected_ReturnsIndices()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 2);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.Contains(0, indices);
            Assert.Contains(2, indices);
            Assert.Equal(2, indices.Length);
        }

        [Fact]
        public void GetConnectedGamepadIndices_AfterDisconnect_ExcludesIndex()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.DoesNotContain(0, indices);
            Assert.Contains(1, indices);
        }

        // =====================================================================
        // VibrateGamepad default duration
        // =====================================================================

        [Fact]
        public void VibrateGamepad_DefaultDuration_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputManager.VibrateGamepad(0, 0.5f, 0.5f));
        }

        // =====================================================================
        // Helper
        // =====================================================================

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }

        private static GamepadState GetGamepadState(WebAssemblyPlatform platform, int index)
        {
            MethodInfo method = typeof(WebAssemblyPlatform).GetMethod("TryGetGamepadState", BindingFlags.Instance | BindingFlags.Public);
            object[] args = new object[] { index, null };
            bool found = (bool)method.Invoke(platform, args);
            Assert.True(found);
            return (GamepadState)args[1];
        }
    }
}
