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

        [Fact]
        public void InputManager_RegisterKeyBinding_SingleKey_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionActive("Jump"));
        }

        [Fact]
        public void InputManager_RegisterKeyBinding_MultipleKeys_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Move", ConsoleKey.W, ConsoleKey.UpArrow);
            Assert.False(manager.IsActionActive("Move"));
        }

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

        [Fact]
        public void InputManager_ClearKeyBinding_RemovesAction()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            manager.ClearKeyBinding("Fire");
            Assert.False(manager.IsActionActive("Fire"));
        }

        [Fact]
        public void InputManager_ClearKeyBinding_NonExistent_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.ClearKeyBinding("NonExistent");
        }

        [Fact]
        public void InputManager_IsActionActive_NonExistentAction_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionActive("Unknown"));
        }

        [Fact]
        public void InputManager_IsActionActive_WithPressedKey_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Fire", ConsoleKey.F);
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(manager.IsActionActive("Fire"));
        }

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

        [Fact]
        public void InputManager_IsActionJustPressed_NoKeysInQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_MatchingKey_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 32, 0);
            Assert.True(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_NonMatchingKey_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.False(manager.IsActionJustPressed("Jump"));
        }

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

        [Fact]
        public void InputManager_IsActionJustPressed_NonExistentAction_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsActionJustPressed("Unknown"));
        }

        // =====================================================================

        [Fact]
        public void InputManager_GetMousePosition_ReturnsDefaultCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.GetMousePosition(out int x, out int y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

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

        [Fact]
        public void InputManager_GetMouseWheelDelta_Default_ReturnsZero()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.Equal(0.0f, manager.GetMouseWheelDelta());
        }

        [Fact]
        public void InputManager_GetMouseWheelDelta_AfterWheel_ReturnsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            manager.Update();
            Assert.Equal(5.0f, manager.GetMouseWheelDelta());
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_Default_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_AfterClick_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_RightButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            InvokePrivate(platform, "OnMouseDown", 1, 0, 0, 50, 50);
            Assert.True(manager.IsMouseButtonDown(1));
            Assert.False(manager.IsMouseButtonDown(0));
        }

        [Fact]
        public void InputManager_IsMouseButtonDown_InvalidButton_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsMouseButtonDown(-1));
            Assert.False(manager.IsMouseButtonDown(10));
        }

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

        [Fact]
        public void InputManager_GetConnectedGamepadIndices_Empty_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        [Fact]
        public void InputManager_TryGetGamepadState_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            bool result = manager.TryGetGamepadState(0, out GamepadInputState state);
            Assert.False(result);
            Assert.Null(state);
        }

        [Fact]
        public void InputManager_IsGamepadButtonJustPressed_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void InputManager_IsGamepadButtonJustReleased_NoGamepad_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        // =====================================================================

        [Fact]
        public void InputManager_Update_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.Update();
        }

        [Fact]
        public void InputManager_Update_MultipleTimes_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            manager.Update();
            manager.Update();
            manager.Update();
        }

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

        [Fact]
        public void InputManager_VibrateGamepad_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(WebAssemblyInputManager.VibrateGamepad(0, 1.0f, 0.5f));
        }

        // =====================================================================

        [Fact]
        public void InputManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputManager(null));
        }

        // =====================================================================

        [Fact]
        public void KeyBinding_Default_HasNoKeys()
        {
            KeyBinding binding = new KeyBinding();
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_AddKey_AddsKey()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_AddKey_DuplicateKey_DoesNotThrow()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.AddKey(ConsoleKey.A);
            Assert.True(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_RemoveKey_RemovesKey()
        {
            KeyBinding binding = new KeyBinding();
            binding.AddKey(ConsoleKey.A);
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

        [Fact]
        public void KeyBinding_RemoveKey_NonExistent_DoesNotThrow()
        {
            KeyBinding binding = new KeyBinding();
            binding.RemoveKey(ConsoleKey.A);
            Assert.False(binding.ContainsKey(ConsoleKey.A));
        }

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

        [Fact]
        public void InputContext_Constructor_CreatesInstance()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
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
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            bool result = context.TryGetTextInput(out string text);
            Assert.False(result);
            Assert.Equal(string.Empty, text);
        }

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

        [Fact]
        public void InputContext_Update_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputContext context = new WebAssemblyInputContext(platform);
            context.Update();
        }

        [Fact]
        public void InputContext_LockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.LockPointer());
        }

        [Fact]
        public void InputContext_UnlockPointer_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.UnlockPointer());
        }

        [Fact]
        public void InputContext_IsPointerLocked_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsPointerLocked());
        }

        [Fact]
        public void InputContext_RequestFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.RequestFullscreen());
        }

        [Fact]
        public void InputContext_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.ExitFullscreen());
        }

        [Fact]
        public void InputContext_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyInputContext.IsFullscreen());
        }

        // =====================================================================

        [Fact]
        public void TouchPoint_Default_IsActiveAndBegin()
        {
            TouchPoint touch = new TouchPoint();
            Assert.True(touch.IsActive);
            Assert.Equal(TouchState.Begin, touch.State);
        }

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
