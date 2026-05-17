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
        // WebAssemblyInputManager - Key Bindings
        // =====================================================================

        [Fact]
        public void InputManager_RegisterKeyBinding_SingleKey_Works()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionActive("Jump"));
        }

        [Fact]
        public void InputManager_RegisterKeyBinding_MultipleKeys_Works()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Move", ConsoleKey.W, ConsoleKey.UpArrow);
            Assert.False(manager.IsActionActive("Move"));
        }

        [Fact]
        public void InputManager_RegisterKeyBinding_SameActionTwice_AddsKeys()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Action", ConsoleKey.A);
            manager.RegisterKeyBinding("Action", ConsoleKey.B);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(manager.IsActionActive("Action"));
        }

        [Fact]
        public void InputManager_ClearKeyBinding_RemovesAction()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            manager.ClearKeyBinding("Fire");
            Assert.False(manager.IsActionActive("Fire"));
        }

        [Fact]
        public void InputManager_ClearKeyBinding_NonExistent_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.ClearKeyBinding("NonExistent");
        }

        [Fact]
        public void InputManager_IsActionActive_NonExistentAction_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionActive("Unknown"));
        }

        [Fact]
        public void InputManager_IsActionActive_WithPressedKey_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(manager.IsActionActive("Fire"));
        }

        [Fact]
        public void InputManager_IsActionActive_AfterKeyUp_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            InvokePrivate(platform, "OnKeyUp", 70, 0);
            Assert.False(manager.IsActionActive("Fire"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_NoKeysInQueue_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_MatchingKey_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_NonMatchingKey_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_ConsumesKeyFromQueue()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            manager.IsActionJustPressed("Jump");
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_NonExistentAction_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionJustPressed("Unknown"));
        }

        // =====================================================================
        // WebAssemblyInputManager - Mouse
        // =====================================================================

        [Fact]
        public void InputManager_GetMousePosition_ReturnsDefaultCoords()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void InputManager_GetMousePosition_AfterMove_ReturnsNewCoords()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseMove", 0, 0, 100, 200);
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        [Fact]
        public void InputManager_GetMouseWheelDelta_Default_ReturnsZero()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.Equal(0.0f, manager.GetMouseWheelDelta());
        }

        [Fact]
        public void InputManager_GetMouseWheelDelta_AfterWheel_ReturnsDelta()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            manager.Update();
            Assert.Equal(5.0f, manager.GetMouseWheelDelta());
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_Default_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_AfterClick_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_RightButton()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 1, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(1));
            Assert.False(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_InvalidButton_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(-1));
            Assert.False(manager.IsMouseButtonDown(10));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_AfterMouseUp_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 50);
            InvokePrivate(platform, "OnMouseUp", 0, 0, 0, 50, 50);
            Assert.False(manager.IsMouseButtonDown(0));
        }

        // =====================================================================
        // WebAssemblyInputManager - Gamepad
        // =====================================================================

        [Fact]
        public void InputManager_GetConnectedGamepadIndices_Empty_ReturnsEmpty()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        [Fact]
        public void InputManager_TryGetGamepadState_NoGamepad_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            bool result = manager.TryGetGamepadState(0, out var state);
            Assert.False(result);
            Assert.Null(state);
        }

        [Fact]
        public void InputManager_IsGamepadButtonJustPressed_NoGamepad_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void InputManager_IsGamepadButtonJustReleased_NoGamepad_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        // =====================================================================
        // WebAssemblyInputManager - Update
        // =====================================================================

        [Fact]
        public void InputManager_Update_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.Update();
        }

        [Fact]
        public void InputManager_Update_MultipleTimes_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            manager.Update();
            manager.Update();
            manager.Update();
        }

        [Fact]
        public void InputManager_Update_DoesNotResetWheelDelta()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            manager.Update();
            Assert.Equal(10.0f, manager.GetMouseWheelDelta());
        }

        // =====================================================================
        // WebAssemblyInputManager - VibrateGamepad
        // =====================================================================

        [Fact]
        public void InputManager_VibrateGamepad_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.VibrateGamepad(0, 1.0f, 0.5f));
            }
        }

        // =====================================================================
        // WebAssemblyInputManager - Constructor
        // =====================================================================

        [Fact]
        public void InputManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputManager(null));
        }

        // =====================================================================
        // KeyBinding
        // =====================================================================

        [Fact]
        public void KeyBinding_Default_HasNoKeys()
        {
            var binding = new KeyBinding();
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_AddKey_AddsKey()
        {
            var binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_AddKey_DuplicateKey_DoesNotThrow()
        {
            var binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_RemoveKey_RemovesKey()
        {
            var binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_RemoveKey_NonExistent_DoesNotThrow()
        {
            var binding = new KeyBinding();
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_Clear_RemovesAllKeys()
        {
            var binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.AddKey(ConsoleKey.B);
            binding.AddKey(ConsoleKey.C);
            binding.Clear();
            Assert.False(binding.ContainsKey(ConsoleKey.A));
            Assert.False(binding.ContainsKey(ConsoleKey.B));
            Assert.False(binding.ContainsKey(ConsoleKey.C));
        }

        [Fact]
        public void KeyBinding_MultipleKeys_AllDetected()
        {
            var binding = new KeyBinding();
            binding.AddKey(ConsoleKey.W);
            binding.AddKey(ConsoleKey.UpArrow);
            Assert.True(binding.ContainsKey(ConsoleKey.W));
            Assert.True(binding.ContainsKey(ConsoleKey.UpArrow));
            Assert.False(binding.ContainsKey(ConsoleKey.S));
        }

        // =====================================================================
        // WebAssemblyInputContext
        // =====================================================================

        [Fact]
        public void InputContext_Constructor_CreatesInstance()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            Assert.NotNull(context.InputManager);
            Assert.NotNull(context.Platform);
            Assert.Same(platform, context.Platform);
        }

        [Fact]
        public void InputContext_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputContext(null));
        }

        [Fact]
        public void InputContext_TryGetTextInput_Empty_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            bool result = context.TryGetTextInput(out string text);
            Assert.False(result);
            Assert.Equal(string.Empty, text);
        }

        [Fact]
        public void InputContext_TryGetTextInput_WithInput_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            InvokePrivate(platform, "OnCharInput", (uint)'X');
            bool result = context.TryGetTextInput(out string text);
            Assert.True(result);
            Assert.Equal("X", text);
        }

        [Fact]
        public void InputContext_Update_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            context.Update();
        }

        [Fact]
        public void InputContext_LockPointer_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.LockPointer());
            }
        }

        [Fact]
        public void InputContext_UnlockPointer_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.UnlockPointer());
            }
        }

        [Fact]
        public void InputContext_IsPointerLocked_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.IsPointerLocked());
            }
        }

        [Fact]
        public void InputContext_RequestFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.RequestFullscreen());
            }
        }

        [Fact]
        public void InputContext_ExitFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.ExitFullscreen());
            }
        }

        [Fact]
        public void InputContext_IsFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var context = new WebAssemblyInputContext(platform);
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => context.IsFullscreen());
            }
        }

        // =====================================================================
        // TouchPoint
        // =====================================================================

        [Fact]
        public void TouchPoint_Default_IsActiveAndBegin()
        {
            var touch = new TouchPoint();
            Assert.True(touch.IsActive);
            Assert.Equal(TouchState.Begin, touch.State);
        }

        [Fact]
        public void TouchPoint_SetProperties_Works()
        {
            var touch = new TouchPoint
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
        // WebAssemblyInputManager - GetKeyName
        // =====================================================================

        [Theory]
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

        [Fact]
        public void WebAssemblyInputManager_GetKeyName_UnknownKey_ReturnsUnknown()
        {
            string name = WebAssemblyInputManager.GetKeyName(ConsoleKey.NoName);
            Assert.Equal("Unknown", name);
        }

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
