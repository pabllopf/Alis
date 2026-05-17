using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Second round of comprehensive tests targeting remaining uncovered code paths:
    ///     WebAssemblyInputManager, WebAssemblyInputContext, WebAssemblyDisplayManager,
    ///     WebAssemblyGameContext, MultiplatformGameEngine, InputManager/DisplayManager wrappers,
    ///     SystemInfo, QuickStart, and additional edge cases.
    /// </summary>
    public class WebAssemblyRound2Test
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

            // Action is registered but key is not pressed, so IsActionActive returns false
            Assert.False(manager.IsActionActive("Jump"));
        }

        [Fact]
        public void InputManager_RegisterKeyBinding_MultipleKeys_Works()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);

            manager.RegisterKeyBinding("Move", ConsoleKey.W, ConsoleKey.UpArrow);

            // Neither key is pressed yet, but action exists
            Assert.False(manager.IsActionActive("Move"));
        }

        [Fact]
        public void InputManager_RegisterKeyBinding_SameActionTwice_AddsKeys()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);

            manager.RegisterKeyBinding("Action", ConsoleKey.A);
            manager.RegisterKeyBinding("Action", ConsoleKey.B);

            // Both keys should be bound to the same action
            InvokePrivate(platform, "OnKeyDown", 65, 0); // A
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
            // Should not throw
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
            InvokePrivate(platform, "OnKeyDown", 70, 0); // F key

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
            InvokePrivate(platform, "OnKeyDown", 32, 0); // Spacebar

            Assert.True(manager.IsActionJustPressed("Jump"));
        }

        [Fact]
        public void InputManager_IsActionJustPressed_NonMatchingKey_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyInputManager(platform);

            manager.RegisterKeyBinding("Jump", ConsoleKey.Spacebar);
            InvokePrivate(platform, "OnKeyDown", 65, 0); // A key

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

            // Second call should return false (queue consumed)
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
            // Should not throw
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

            // InputManager.Update does NOT reset wheel delta; PollEvents does
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
        // WebAssemblyDisplayManager - Basic Properties
        // =====================================================================

        [Fact]
        public void DisplayManager_GetWidth_ReturnsPlatformWidth()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(800, manager.GetWidth());
        }

        [Fact]
        public void DisplayManager_GetHeight_ReturnsPlatformHeight()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(600, manager.GetHeight());
        }

        [Fact]
        public void DisplayManager_GetAspectRatio_CorrectCalculation()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            float aspect = manager.GetAspectRatio();

            Assert.Equal(800.0f / 600.0f, aspect, 3);
        }

        [Fact]
        public void DisplayManager_GetAspectRatio_Widescreen()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            var manager = new WebAssemblyDisplayManager(platform);

            float aspect = manager.GetAspectRatio();

            Assert.Equal(1920.0f / 1080.0f, aspect, 3);
        }

        [Fact]
        public void DisplayManager_GetOrientation_Landscape()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetOrientation_Portrait()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 600, 800);
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(ScreenOrientation.Portrait, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetOrientation_Square()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 500, 500);
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(ScreenOrientation.Square, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetDevicePixelRatio_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.GetDevicePixelRatio());
            }
        }

        // =====================================================================
        // WebAssemblyDisplayManager - SetResolution
        // =====================================================================

        [Fact]
        public void DisplayManager_SetResolution_CatchesException_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            // SetResolution catches exceptions and returns false on non-browser
            bool result = manager.SetResolution(1024, 768);

            Assert.False(result);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Fullscreen
        // =====================================================================

        [Fact]
        public void DisplayManager_ToggleFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.ToggleFullscreen());
            }
        }

        [Fact]
        public void DisplayManager_EnterFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.EnterFullscreen());
            }
        }

        [Fact]
        public void DisplayManager_ExitFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.ExitFullscreen());
            }
        }

        [Fact]
        public void DisplayManager_IsFullscreen_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.IsFullscreen());
            }
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Display Modes
        // =====================================================================

        [Fact]
        public void DisplayManager_GetSupportedModes_ReturnsModes()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.NotNull(modes);
            Assert.NotEmpty(modes);
            // Should have 8 standard modes + 1 fullscreen mode = 9
            Assert.Equal(9, modes.Length);
        }

        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsStandardResolutions()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.Contains(modes, m => m.Width == 640 && m.Height == 480);
            Assert.Contains(modes, m => m.Width == 800 && m.Height == 600);
            Assert.Contains(modes, m => m.Width == 1920 && m.Height == 1080);
        }

        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsFullscreenMode()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.Contains(modes, m => m.IsFullscreenOnly);
        }

        [Fact]
        public void DisplayManager_FindDisplayMode_ExistingMode_ReturnsMode()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode mode = manager.FindDisplayMode(1920, 1080);

            Assert.NotNull(mode);
            Assert.Equal(1920, mode.Width);
            Assert.Equal(1080, mode.Height);
        }

        [Fact]
        public void DisplayManager_FindDisplayMode_NonExisting_ReturnsNull()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode mode = manager.FindDisplayMode(9999, 9999);

            Assert.Null(mode);
        }

        [Fact]
        public void DisplayManager_FindDisplayMode_640x480_ReturnsMode()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            DisplayMode mode = manager.FindDisplayMode(640, 480);

            Assert.NotNull(mode);
            Assert.Equal(640, mode.Width);
            Assert.Equal(480, mode.Height);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Display Quality
        // =====================================================================

        [Theory]
        [InlineData(DisplayQuality.VeryLow, 0.5f)]
        [InlineData(DisplayQuality.Low, 0.75f)]
        [InlineData(DisplayQuality.Medium, 0.875f)]
        [InlineData(DisplayQuality.High, 1.0f)]
        [InlineData(DisplayQuality.VeryHigh, 1.25f)]
        [InlineData(DisplayQuality.Ultra, 1.5f)]
        public void DisplayManager_GetRenderingScale_CorrectValue(DisplayQuality quality, float expectedScale)
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            manager.SetDisplayQuality(quality);

            Assert.Equal(expectedScale, manager.GetRenderingScale());
        }

        [Fact]
        public void DisplayManager_GetDisplayQuality_DefaultIsHigh()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(DisplayQuality.High, manager.GetDisplayQuality());
        }

        [Fact]
        public void DisplayManager_SetDisplayQuality_ChangesQuality()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            manager.SetDisplayQuality(DisplayQuality.Ultra);

            Assert.Equal(DisplayQuality.Ultra, manager.GetDisplayQuality());
        }

        // =====================================================================
        // WebAssemblyDisplayManager - System Info
        // =====================================================================

        [Fact]
        public void DisplayManager_GetSystemLanguage_ReturnsDefaultOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            // GetLanguage has a catch that returns "en" on non-browser
            string lang = manager.GetSystemLanguage();

            Assert.Equal("en", lang);
        }

        [Fact]
        public void DisplayManager_IsOnline_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.IsOnline());
            }
        }

        [Fact]
        public void DisplayManager_GetBatteryLevel_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.GetBatteryLevel());
            }
        }

        [Fact]
        public void DisplayManager_IsCharging_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => manager.IsCharging());
            }
        }

        [Fact]
        public void DisplayManager_GetRefreshRate_Returns60()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(60, manager.GetRefreshRate());
        }

        [Fact]
        public void DisplayManager_SaveScreenshot_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);

            bool result = manager.SaveScreenshot("screenshot.png");

            Assert.True(result);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Update
        // =====================================================================

        [Fact]
        public void DisplayManager_Update_NoChange_DoesNotTriggerEvents()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);
            int resizeCount = 0;

            manager.OnDisplayResized += (s, e) => resizeCount++;

            // Update calls IsFullscreenEnabled which throws on non-browser
            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
            }

            Assert.Equal(0, resizeCount);
        }

        [Fact]
        public void DisplayManager_Update_SizeChange_TriggersResizeEvent()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);
            int resizeCount = 0;

            manager.OnDisplayResized += (s, e) => resizeCount++;

            InvokePrivate(platform, "OnWindowResize", 1920, 1080);

            // Update calls IsFullscreenEnabled which throws on non-browser
            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
                Assert.Equal(1, resizeCount);
            }
        }

        [Fact]
        public void DisplayManager_Update_OrientationChange_TriggersOrientationEvent()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);
            int orientationCount = 0;

            manager.OnOrientationChanged += (s, e) => orientationCount++;

            // Start as landscape (800x600), change to portrait
            InvokePrivate(platform, "OnWindowResize", 600, 800);

            // Update calls IsFullscreenEnabled which throws on non-browser
            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
                Assert.Equal(1, orientationCount);
            }
        }

        [Fact]
        public void DisplayManager_Update_FullscreenChange_TriggersFullscreenEvent()
        {
            var platform = new WebAssemblyPlatform();
            var manager = new WebAssemblyDisplayManager(platform);
            int fullscreenCount = 0;

            manager.OnFullscreenChanged += (s, e) => fullscreenCount++;

            // This will throw on non-browser, so skip
            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Properties
        // =====================================================================

        [Fact]
        public void GameContext_Constructor_WithConfig_ThrowsOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new WebAssemblyGameContext(config));
            }
        }

        [Fact]
        public void GameContext_Create_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyGameContext.Create(800, 600, "Test"));
            }
        }

        [Fact]
        public void GameContext_Constructor_NullConfig_ThrowsArgumentNullException()
        {
            WebAssemblyConfiguration nullConfig = null;
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyGameContext(nullConfig));
        }

        // =====================================================================
        // MultiplatformGameEngine
        // =====================================================================

        [Fact]
        public void MultiplatformGameEngine_Constructor_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new MultiplatformGameEngine(800, 600, "Test"));
            }
        }

        [Fact]
        public void MultiplatformGameEngine_Dispose_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Dispose();
                engine.Dispose(); // Double dispose should not throw
            }
        }

        // =====================================================================
        // InputManager (wrapper)
        // =====================================================================

        [Fact]
        public void InputManagerWrapper_GetMovementInput_NoKeys_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                bool result = engine.Input.GetMovementInput(out float x, out float y);
                Assert.False(result);
                Assert.Equal(0, x);
                Assert.Equal(0, y);
            }
        }

        [Fact]
        public void InputManagerWrapper_IsJumpPressed_Default_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.False(engine.Input.IsJumpPressed());
            }
        }

        [Fact]
        public void InputManagerWrapper_IsAttackPressed_Default_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.False(engine.Input.IsAttackPressed());
            }
        }

        [Fact]
        public void InputManagerWrapper_GetCameraInput_DefaultValues()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Input.GetCameraInput(out float pitch, out float yaw);
                // Default values depend on mouse position
            }
        }

        // =====================================================================
        // DisplayManager (wrapper)
        // =====================================================================

        [Fact]
        public void DisplayManagerWrapper_SetFullscreen_ThrowsOnNonBrowser()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                // These call into EmscriptenWeb which throws on non-browser
            }
        }

        // =====================================================================
        // SystemInfo - All methods
        // =====================================================================

        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.GetPlatformName());
        }

        [Fact]
        public void SystemInfo_IsOnline_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.IsOnline());
            }
        }

        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            // GetLanguage has a catch that returns "en" on non-browser
            string lang = SystemInfo.GetLanguage();

            Assert.Equal("en", lang);
        }

        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetDevicePixelRatio());
            }
        }

        [Fact]
        public void SystemInfo_GetBatteryLevel_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetBatteryLevel());
            }
        }

        [Fact]
        public void SystemInfo_IsCharging_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.IsCharging());
            }
        }

        [Fact]
        public void SystemInfo_GetScreenOrientation_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetScreenOrientation());
            }
        }

        [Fact]
        public void SystemInfo_GetSystemTimeMs_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetSystemTimeMs());
            }
        }

        [Fact]
        public void SystemInfo_LogToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.LogToConsole("test"));
            }
        }

        [Fact]
        public void SystemInfo_WarnToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.WarnToConsole("test"));
            }
        }

        [Fact]
        public void SystemInfo_ErrorToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.ErrorToConsole("test"));
            }
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_RunMinimalGame_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    QuickStart.RunMinimalGame((w, h) => { }));
            }
        }

        [Fact]
        public void QuickStart_LogPlatformInfo_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => QuickStart.LogPlatformInfo());
            }
        }

        // =====================================================================
        // Additional WebAssemblyPlatform edge cases
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_GetMouseState_ReturnsClonedArray()
        {
            var platform = new WebAssemblyPlatform();

            platform.GetMouseState(out int x1, out int y1, out bool[] buttons1);
            platform.GetMouseState(out int x2, out int y2, out bool[] buttons2);

            // Arrays should be different instances (cloned)
            Assert.NotSame(buttons1, buttons2);
        }

        [Fact]
        public void WebAssemblyPlatform_GetMouseState_MultipleButtons()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseDown", 2, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 10, 20);

            platform.GetMouseState(out int x, out int y, out bool[] buttons);

            Assert.True(buttons[0]);
            Assert.False(buttons[1]);
            Assert.True(buttons[2]);
            Assert.False(buttons[3]);
            Assert.True(buttons[4]);
        }

        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_RepeatedKey_DoesNotEnqueueWithoutRelease()
        {
            var platform = new WebAssemblyPlatform();

            // First key down enqueues (key not in states yet)
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));

            // Second key down without release: key IS in states AND state is true
            // so neither condition in OnKeyDown matches - nothing enqueued
            InvokePrivate(platform, "OnKeyDown", 65, 0);

            // Queue is empty - no second enqueue
            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_DifferentKeys_QueueOrderPreserved()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyDown", 65, 0); // A
            InvokePrivate(platform, "OnKeyDown", 66, 0); // B
            InvokePrivate(platform, "OnKeyDown", 67, 0); // C

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k1));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k2));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k3));

            Assert.Equal(ConsoleKey.A, k1);
            Assert.Equal(ConsoleKey.B, k2);
            Assert.Equal(ConsoleKey.C, k3);
        }

        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_KeyNotInStates_AddsToStates()
        {
            var platform = new WebAssemblyPlatform();

            // Simulate a key that might not be in default states
            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void WebAssemblyPlatform_OnKeyUp_KeyNotInStates_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyUp", 65, 0);
            // Should not throw
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseMove_UpdatesClientCoords()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseMove", 100, 200, 300, 400);

            platform.GetMouseState(out int x, out int y, out _);

            Assert.Equal(300, x);
            Assert.Equal(400, y);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_UpdatesCoordsAndButton()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseDown", 0, 50, 60, 70, 80);

            platform.GetMouseState(out int x, out int y, out bool[] buttons);

            Assert.True(buttons[0]);
            Assert.Equal(70, x);
            Assert.Equal(80, y);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseUp_UpdatesCoordsAndReleasesButton()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseUp", 0, 0, 0, 30, 40);

            platform.GetMouseState(out int x, out int y, out bool[] buttons);

            Assert.False(buttons[0]);
            Assert.Equal(30, x);
            Assert.Equal(40, y);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_NegativeDelta()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseWheel", 0, -10);

            Assert.Equal(-10.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_ZeroDelta()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseWheel", 0, 0);

            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_SameIndexTwice_DoesNotDuplicate()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 0);

            int[] indices = platform.GetConnectedGamepadIndices();

            Assert.Single(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_SameSize_Works()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnWindowResize", 800, 600);

            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_ZeroSize_Works()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnWindowResize", 0, 0);

            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_MaxSize_Works()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnWindowResize", int.MaxValue, int.MaxValue);

            Assert.Equal(int.MaxValue, platform.GetWindowWidth());
            Assert.Equal(int.MaxValue, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_NegativeSize_Works()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnWindowResize", -100, -200);

            Assert.Equal(-100, platform.GetWindowWidth());
            Assert.Equal(-200, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_PollEvents_MultipleCalls_ResetsWheelEachTime()
        {
            var platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel());

            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();

            platform.SetWindowIcon("");
        }

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_NullPath_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();

            platform.SetWindowIcon(null);
        }

        [Fact]
        public void WebAssemblyPlatform_GetWindowMetrics_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() =>
                    platform.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
            }
        }

        [Fact]
        public void WebAssemblyPlatform_GetProcAddress_NullOrEmpty_DoesNotCrash()
        {
            var platform = new WebAssemblyPlatform();

            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => platform.GetProcAddress(""));
            }
        }

        // =====================================================================
        // Additional ConfigurationBuilder edge cases
        // =====================================================================

        [Fact]
        public void ConfigBuilder_Build_MultipleTimes_ReturnsSameInstance()
        {
            var builder = new WebAssemblyConfigurationBuilder()
                .WithSize(800, 600);

            var config1 = builder.Build();
            var config2 = builder.Build();

            // Build returns the same _configuration instance
            Assert.Same(config1, config2);
        }

        [Fact]
        public void ConfigBuilder_WithSize_NegativeValues_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithSize(-100, -200)
                .Build();

            Assert.Equal(-100, config.WindowWidth);
            Assert.Equal(-200, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithSize_ZeroValues_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithSize(0, 0)
                .Build();

            Assert.Equal(0, config.WindowWidth);
            Assert.Equal(0, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_EmptyString_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTitle("")
                .Build();

            Assert.Equal("", config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_Null_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTitle(null)
                .Build();

            Assert.Null(config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithIconPath_Null_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithIconPath(null)
                .Build();

            Assert.Null(config.IconPath);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_One_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(1)
                .Build();

            Assert.Equal(1, config.TargetFrameRate);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_MaxInt_Accepts()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(int.MaxValue)
                .Build();

            Assert.Equal(int.MaxValue, config.TargetFrameRate);
        }

        [Fact]
        public void ConfigBuilder_WithGamepadDeadzone_BoundaryValues()
        {
            var configMin = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(0.0f)
                .Build();
            var configMax = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(1.0f)
                .Build();

            Assert.Equal(0.0f, configMin.GamepadDeadzone);
            Assert.Equal(1.0f, configMax.GamepadDeadzone);
        }

        [Fact]
        public void ConfigBuilder_WithTriggerDeadzone_BoundaryValues()
        {
            var configMin = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(0.0f)
                .Build();
            var configMax = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(1.0f)
                .Build();

            Assert.Equal(0.0f, configMin.TriggerDeadzone);
            Assert.Equal(1.0f, configMax.TriggerDeadzone);
        }

        // =====================================================================
        // Additional GamepadState tests
        // =====================================================================

        [Fact]
        public void GamepadState_SetAllButtons_True()
        {
            var state = new GamepadState();
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                state.Buttons[i] = true;
            }

            for (int i = 0; i < state.Buttons.Length; i++)
            {
                Assert.True(state.GetButton(i));
            }
        }

        [Fact]
        public void GamepadState_SetAllButtons_False()
        {
            var state = new GamepadState();
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                state.Buttons[i] = false;
            }

            for (int i = 0; i < state.Buttons.Length; i++)
            {
                Assert.False(state.GetButton(i));
            }
        }

        [Fact]
        public void GamepadState_AllButtonProperties_CorrectIndices()
        {
            var state = new GamepadState();

            // Set all buttons true one at a time and verify property
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
            state.Buttons[0] = false;

            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
            state.Buttons[1] = false;

            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
            state.Buttons[2] = false;

            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
            state.Buttons[3] = false;

            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
            state.Buttons[4] = false;

            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
            state.Buttons[5] = false;

            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
            state.Buttons[8] = false;

            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
            state.Buttons[9] = false;

            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
            state.Buttons[10] = false;

            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
            state.Buttons[11] = false;

            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
            state.Buttons[12] = false;
        }

        // =====================================================================
        // Additional DisplayMode tests
        // =====================================================================

        [Fact]
        public void DisplayMode_MultipleModes_DifferentInstances()
        {
            var mode1 = new DisplayMode { Width = 800, Height = 600 };
            var mode2 = new DisplayMode { Width = 1920, Height = 1080 };

            Assert.NotSame(mode1, mode2);
            Assert.NotEqual(mode1, mode2);
        }

        [Fact]
        public void DisplayMode_ToString_WithDifferentRefreshRates()
        {
            var mode60 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            var mode144 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 144 };

            Assert.Equal("1920x1080@60Hz", mode60.ToString());
            Assert.Equal("1920x1080@144Hz", mode144.ToString());
        }

        // =====================================================================
        // Helper method
        // =====================================================================

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
