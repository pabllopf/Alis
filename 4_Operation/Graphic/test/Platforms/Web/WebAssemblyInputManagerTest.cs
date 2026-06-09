// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManagerTest.cs
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
    /// <summary>
    ///     Tests for WebAssemblyInputManager, WebAssemblyInputContext,
    ///     KeyBinding, TouchPoint, and TouchState.
    /// </summary>
    public class WebAssemblyInputManagerTest
    {
        // =====================================================================

        /// <summary>
        /// Tests that input manager register key binding single key works
        /// </summary>
        [Fact]
        public void InputManager_RegisterKeyBinding_SingleKey_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionActive("Jump"));
        }

        /// <summary>
        /// Tests that input manager register key binding multiple keys works
        /// </summary>
        [Fact]
        public void InputManager_RegisterKeyBinding_MultipleKeys_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Move", ConsoleKey.W, ConsoleKey.UpArrow);
            Assert.False(manager.IsActionActive("Move"));
        }

        /// <summary>
        /// Tests that input manager register key binding same action twice adds keys
        /// </summary>
        [Fact]
        public void InputManager_RegisterKeyBinding_SameActionTwice_AddsKeys()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Action", ConsoleKey.A);
            manager.RegisterKeyBinding("Action", ConsoleKey.B);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(manager.IsActionActive("Action"));
        }

        /// <summary>
        /// Tests that input manager clear key binding removes action
        /// </summary>
        [Fact]
        public void InputManager_ClearKeyBinding_RemovesAction()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            manager.ClearKeyBinding("Fire");
            Assert.False(manager.IsActionActive("Fire"));
        }

        /// <summary>
        /// Tests that input manager clear key binding non existent does not throw
        /// </summary>
        [Fact]
        public void InputManager_ClearKeyBinding_NonExistent_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.ClearKeyBinding("NonExistent");
        }

        /// <summary>
        /// Tests that input manager is action active non existent action returns false
        /// </summary>
        [Fact]
        public void InputManager_IsActionActive_NonExistentAction_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionActive("Unknown"));
        }

        /// <summary>
        /// Tests that input manager is action active with pressed key returns true
        /// </summary>
        [Fact]
        public void InputManager_IsActionActive_WithPressedKey_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(manager.IsActionActive("Fire"));
        }

        /// <summary>
        /// Tests that input manager is action active after key up returns false
        /// </summary>
        [Fact]
        public void InputManager_IsActionActive_AfterKeyUp_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            InvokePrivate(platform, "OnKeyUp", 70, 0);
            Assert.False(manager.IsActionActive("Fire"));
        }

        /// <summary>
        /// Tests that input manager is action just pressed no keys in queue returns false
        /// </summary>
        [Fact]
        public void InputManager_IsActionJustPressed_NoKeysInQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        /// <summary>
        /// Tests that input manager is action just pressed matching key returns true
        /// </summary>
        [Fact]
        public void InputManager_IsActionJustPressed_MatchingKey_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(manager.IsActionJustPressed("Jump"));
        }

        /// <summary>
        /// Tests that input manager is action just pressed non matching key returns false
        /// </summary>
        [Fact]
        public void InputManager_IsActionJustPressed_NonMatchingKey_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        /// <summary>
        /// Tests that input manager is action just pressed consumes key from queue
        /// </summary>
        [Fact]
        public void InputManager_IsActionJustPressed_ConsumesKeyFromQueue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            manager.IsActionJustPressed("Jump");
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        /// <summary>
        /// Tests that input manager is action just pressed non existent action returns false
        /// </summary>
        [Fact]
        public void InputManager_IsActionJustPressed_NonExistentAction_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionJustPressed("Unknown"));
        }

        // =====================================================================

        /// <summary>
        /// Tests that input manager get mouse position returns default coords
        /// </summary>
        [Fact]
        public void InputManager_GetMousePosition_ReturnsDefaultCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that input manager get mouse position after move returns new coords
        /// </summary>
        [Fact]
        public void InputManager_GetMousePosition_AfterMove_ReturnsNewCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseMove", 0, 0, 100, 200);
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        /// <summary>
        /// Tests that input manager get mouse wheel delta default returns zero
        /// </summary>
        [Fact]
        public void InputManager_GetMouseWheelDelta_Default_ReturnsZero()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.Equal(0.0f, manager.GetMouseWheelDelta());
        }

        /// <summary>
        /// Tests that input manager get mouse wheel delta after wheel returns delta
        /// </summary>
        [Fact]
        public void InputManager_GetMouseWheelDelta_AfterWheel_ReturnsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            manager.Update();
            Assert.Equal(5.0f, manager.GetMouseWheelDelta());
        }

        /// <summary>
        /// Tests that input manager is mouse button down default returns false
        /// </summary>
        [Fact]
        public void InputManager_IsMouseButtonDown_Default_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(0));
        }

        /// <summary>
        /// Tests that input manager is mouse button down after click returns true
        /// </summary>
        [Fact]
        public void InputManager_IsMouseButtonDown_AfterClick_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(0));
        }

        /// <summary>
        /// Tests that input manager is mouse button down right button
        /// </summary>
        [Fact]
        public void InputManager_IsMouseButtonDown_RightButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 1, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(1));
            Assert.False(manager.IsMouseButtonDown(0));
        }

        /// <summary>
        /// Tests that input manager is mouse button down invalid button returns false
        /// </summary>
        [Fact]
        public void InputManager_IsMouseButtonDown_InvalidButton_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(-1));
            Assert.False(manager.IsMouseButtonDown(10));
        }

        /// <summary>
        /// Tests that input manager is mouse button down after mouse up returns false
        /// </summary>
        [Fact]
        public void InputManager_IsMouseButtonDown_AfterMouseUp_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 50);
            InvokePrivate(platform, "OnMouseUp", 0, 0, 0, 50, 50);
            Assert.False(manager.IsMouseButtonDown(0));
        }

        // =====================================================================

        /// <summary>
        /// Tests that input manager get connected gamepad indices empty returns empty
        /// </summary>
        [Fact]
        public void InputManager_GetConnectedGamepadIndices_Empty_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        /// <summary>
        /// Tests that input manager try get gamepad state no gamepad returns false
        /// </summary>
        [Fact]
        public void InputManager_TryGetGamepadState_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);
            Assert.False(result);
            Assert.Null(state);
        }

        /// <summary>
        /// Tests that input manager is gamepad button just pressed no gamepad returns false
        /// </summary>
        [Fact]
        public void InputManager_IsGamepadButtonJustPressed_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        /// <summary>
        /// Tests that input manager is gamepad button just released no gamepad returns false
        /// </summary>
        [Fact]
        public void InputManager_IsGamepadButtonJustReleased_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        // =====================================================================

        /// <summary>
        /// Tests that input manager update does not throw
        /// </summary>
        [Fact]
        public void InputManager_Update_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.Update();
        }

        /// <summary>
        /// Tests that input manager update multiple times does not throw
        /// </summary>
        [Fact]
        public void InputManager_Update_MultipleTimes_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.Update();
            manager.Update();
            manager.Update();
        }

        /// <summary>
        /// Tests that input manager update does not reset wheel delta
        /// </summary>
        [Fact]
        public void InputManager_Update_DoesNotResetWheelDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            manager.Update();
            Assert.Equal(10.0f, manager.GetMouseWheelDelta());
        }

        // =====================================================================

        /// <summary>
        /// Tests that input manager vibrate gamepad returns false on non browser
        /// </summary>
        [Fact]
        public void InputManager_VibrateGamepad_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(WebAssemblyInputManager.VibrateGamepad(0, 1.0f, 0.5f));
        }

        // =====================================================================

        /// <summary>
        /// Tests that input manager constructor null platform throws
        /// </summary>
        [Fact]
        public void InputManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputManager(null));
        }

        // =====================================================================

        /// <summary>
        /// Tests that key binding default has no keys
        /// </summary>
        [Fact]
        public void KeyBinding_Default_HasNoKeys()
        {
            KeyBinding binding = new KeyBinding();
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that key binding add key adds key
        /// </summary>
        [Fact]
        public void KeyBinding_AddKey_AddsKey()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that key binding add key duplicate key does not throw
        /// </summary>
        [Fact]
        public void KeyBinding_AddKey_DuplicateKey_DoesNotThrow()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that key binding remove key removes key
        /// </summary>
        [Fact]
        public void KeyBinding_RemoveKey_RemovesKey()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that key binding remove key non existent does not throw
        /// </summary>
        [Fact]
        public void KeyBinding_RemoveKey_NonExistent_DoesNotThrow()
        {
            KeyBinding binding = new KeyBinding();
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that key binding clear removes all keys
        /// </summary>
        [Fact]
        public void KeyBinding_Clear_RemovesAllKeys()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.AddKey(ConsoleKey.B);
            binding.AddKey(ConsoleKey.C);
            binding.Clear();
            Assert.False(binding.ContainsKey(ConsoleKey.A));
            Assert.False(binding.ContainsKey(ConsoleKey.B));
            Assert.False(binding.ContainsKey(ConsoleKey.C));
        }

        /// <summary>
        /// Tests that key binding multiple keys all detected
        /// </summary>
        [Fact]
        public void KeyBinding_MultipleKeys_AllDetected()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.W);
            binding.AddKey(ConsoleKey.UpArrow);
            Assert.True(binding.ContainsKey(ConsoleKey.W));
            Assert.True(binding.ContainsKey(ConsoleKey.UpArrow));
            Assert.False(binding.ContainsKey(ConsoleKey.S));
        }

        // =====================================================================

        /// <summary>
        /// Tests that input context constructor creates instance
        /// </summary>
        [Fact]
        public void InputContext_Constructor_CreatesInstance()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            Assert.NotNull(context.InputManager);
            Assert.NotNull(context.Platform);
            Assert.Same(platform, context.Platform);
        }

        /// <summary>
        /// Tests that input context constructor null platform throws
        /// </summary>
        [Fact]
        public void InputContext_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputContext(null));
        }

        /// <summary>
        /// Tests that input context try get text input empty returns false
        /// </summary>
        [Fact]
        public void InputContext_TryGetTextInput_Empty_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            bool result = context.TryGetTextInput(out string text);
            Assert.False(result);
            Assert.Equal(string.Empty, text);
        }

        /// <summary>
        /// Tests that input context try get text input with input returns true
        /// </summary>
        [Fact]
        public void InputContext_TryGetTextInput_WithInput_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            InvokePrivate(platform, "OnCharInput", (uint)'X');
            bool result = context.TryGetTextInput(out string text);
            Assert.True(result);
            Assert.Equal("X", text);
        }

        /// <summary>
        /// Tests that input context update does not throw
        /// </summary>
        [Fact]
        public void InputContext_Update_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            context.Update();
        }

        /// <summary>
        /// Tests that input context lock pointer returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_LockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.LockPointer());
        }

        /// <summary>
        /// Tests that input context unlock pointer returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_UnlockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.UnlockPointer());
        }

        /// <summary>
        /// Tests that input context is pointer locked returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_IsPointerLocked_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsPointerLocked());
        }

        /// <summary>
        /// Tests that input context request fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_RequestFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.RequestFullscreen());
        }

        /// <summary>
        /// Tests that input context exit fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.ExitFullscreen());
        }

        /// <summary>
        /// Tests that input context is fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void InputContext_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsFullscreen());
        }

        // =====================================================================

        /// <summary>
        /// Tests that touch point default is active and begin
        /// </summary>
        [Fact]
        public void TouchPoint_Default_IsActiveAndBegin()
        {
            TouchPoint touch = new TouchPoint();
            Assert.True(touch.IsActive);
            Assert.Equal(TouchState.Begin, touch.State);
        }

        /// <summary>
        /// Tests that touch point set properties works
        /// </summary>
        [Fact]
        public void TouchPoint_SetProperties_Works()
        {
            TouchPoint touch = new TouchPoint
            {
                Id = 42,
                X = 100,
                Y = 200,
                IsActive = false,
                State = TouchState.Ended
            };
            Assert.Equal(42, touch.Id);
            Assert.Equal(100, touch.X);
            Assert.Equal(200, touch.Y);
            Assert.False(touch.IsActive);
            Assert.Equal(TouchState.Ended, touch.State);
        }

        // =====================================================================

        
        /// <summary>
        /// Webs the assembly input manager get key name returns correct name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="expected">The expected</param>
        [InlineData(ConsoleKey.A, "A")]
        [InlineData(ConsoleKey.B, "B")]
        [InlineData(ConsoleKey.Enter, "Enter")]
        [InlineData(ConsoleKey.Escape, "Escape")]
        [InlineData(ConsoleKey.Spacebar, "Space")]
        [InlineData(ConsoleKey.UpArrow, "Up")]
        [InlineData(ConsoleKey.DownArrow, "Down")]
        [InlineData(ConsoleKey.LeftArrow, "Left")]
        [InlineData(ConsoleKey.RightArrow, "Right")]
        [InlineData(ConsoleKey.F1, "F1")]
        [InlineData(ConsoleKey.F12, "F12")]
        [InlineData(ConsoleKey.NumPad0, "Numpad 0")]
        [InlineData(ConsoleKey.NumPad9, "Numpad 9")]
        [InlineData(ConsoleKey.Home, "Home")]
        [InlineData(ConsoleKey.End, "End")]
        [InlineData(ConsoleKey.PageUp, "Page Up")]
        [InlineData(ConsoleKey.PageDown, "Page Down")]
        [InlineData(ConsoleKey.Insert, "Insert")]
        [InlineData(ConsoleKey.Delete, "Delete")]
        [InlineData(ConsoleKey.Tab, "Tab")]
        [InlineData(ConsoleKey.Backspace, "Backspace")]
        [InlineData(ConsoleKey.D0, "0")]
        [InlineData(ConsoleKey.D9, "9")]
        [InlineData(ConsoleKey.Pause, "Pause")]
        public void WebAssemblyInputManager_GetKeyName_ReturnsCorrectName(ConsoleKey key, string expected)
        {
            string name = WebAssemblyInputManager.GetKeyName(key);
            Assert.Equal(expected, name);
        }

        /// <summary>
        /// Tests that web assembly input manager get key name unknown key returns unknown
        /// </summary>
        [Fact]
        public void WebAssemblyInputManager_GetKeyName_UnknownKey_ReturnsUnknown()
        {
            string name = WebAssemblyInputManager.GetKeyName(ConsoleKey.NoName);
            Assert.Equal("Unknown", name);
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
    }
}
