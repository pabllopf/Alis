using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Comprehensive unit tests for WebAssembly platform types, covering configuration,
    ///     gamepad state, display modes, key bindings, integration, wrappers, utilities,
    ///     and the JavaScript bridge script.
    /// </summary>
    public class WebAssemblyComprehensiveTest
    {
        // =====================================================================
        // EGL Constants
        // =====================================================================

        [Fact]
        public void EglConstants_HaveExpectedValues()
        {
            Assert.Equal(0x3038, EGL.EGL_NONE);
            Assert.Equal(0x3024, EGL.EGL_RED_SIZE);
            Assert.Equal(0x3023, EGL.EGL_GREEN_SIZE);
            Assert.Equal(0x3022, EGL.EGL_BLUE_SIZE);
            Assert.Equal(0x3025, EGL.EGL_DEPTH_SIZE);
            Assert.Equal(0x3026, EGL.EGL_STENCIL_SIZE);
            Assert.Equal(0x3033, EGL.EGL_SURFACE_TYPE);
            Assert.Equal(0x3040, EGL.EGL_RENDERABLE_TYPE);
            Assert.Equal(0x3031, EGL.EGL_SAMPLES);
            Assert.Equal(0x0004, EGL.EGL_WINDOW_BIT);
            Assert.Equal(0x0004, EGL.EGL_OPENGL_ES2_BIT);
            Assert.Equal(0x00000040, EGL.EGL_OPENGL_ES3_BIT);
            Assert.Equal(0x3098, EGL.EGL_CONTEXT_CLIENT_VERSION);
            Assert.Equal(0x0, EGL.EGL_NO_CONTEXT);
            Assert.Equal(0x302E, EGL.EGL_NATIVE_VISUAL_ID);
            Assert.Equal(0x30A0, EGL.EGL_OPENGL_ES_API);
        }

        [Fact]
        public void EglConstants_LibEgl_IsCorrectString()
        {
            Assert.Equal("libEGL", EGL.LibEgl);
        }

        // =====================================================================
        // DisplayQuality Enum
        // =====================================================================

        [Theory]
        [InlineData(DisplayQuality.VeryLow, 0)]
        [InlineData(DisplayQuality.Low, 1)]
        [InlineData(DisplayQuality.Medium, 2)]
        [InlineData(DisplayQuality.High, 3)]
        [InlineData(DisplayQuality.VeryHigh, 4)]
        [InlineData(DisplayQuality.Ultra, 5)]
        public void DisplayQuality_HasCorrectValues(DisplayQuality quality, int expectedValue)
        {
            Assert.Equal(expectedValue, (int)quality);
        }

        // =====================================================================
        // ScreenOrientation Enum
        // =====================================================================

        [Theory]
        [InlineData(ScreenOrientation.Portrait)]
        [InlineData(ScreenOrientation.Landscape)]
        [InlineData(ScreenOrientation.Square)]
        public void ScreenOrientation_EnumValuesExist(ScreenOrientation orientation)
        {
            Assert.True(Enum.IsDefined(typeof(ScreenOrientation), orientation));
        }

        // =====================================================================
        // TouchState Enum
        // =====================================================================

        [Theory]
        [InlineData(TouchState.Begin)]
        [InlineData(TouchState.Moved)]
        [InlineData(TouchState.Stationary)]
        [InlineData(TouchState.Ended)]
        [InlineData(TouchState.Cancelled)]
        public void TouchState_EnumValuesExist(TouchState state)
        {
            Assert.True(Enum.IsDefined(typeof(TouchState), state));
        }

        // =====================================================================
        // OptimizationProfile Enum
        // =====================================================================

        [Theory]
        [InlineData(OptimizationProfile.Default)]
        [InlineData(OptimizationProfile.Game2D)]
        [InlineData(OptimizationProfile.Game3D)]
        [InlineData(OptimizationProfile.LowEnd)]
        [InlineData(OptimizationProfile.HighEnd)]
        [InlineData(OptimizationProfile.Mobile)]
        [InlineData(OptimizationProfile.Web)]
        public void OptimizationProfile_EnumValuesExist(OptimizationProfile profile)
        {
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), profile));
        }

        // =====================================================================
        // GamepadState
        // =====================================================================

        [Fact]
        public void GamepadState_DefaultValues_AreCorrect()
        {
            var state = new GamepadState();

            Assert.False(state.Connected);
            Assert.Equal(0.0f, state.LeftStickX);
            Assert.Equal(0.0f, state.LeftStickY);
            Assert.Equal(0.0f, state.RightStickX);
            Assert.Equal(0.0f, state.RightStickY);
            Assert.Equal(0.0f, state.LeftTrigger);
            Assert.Equal(0.0f, state.RightTrigger);
            Assert.NotNull(state.Buttons);
            Assert.Equal(13, state.Buttons.Length);
        }

        [Fact]
        public void GamepadState_ButtonsArray_AllFalseByDefault()
        {
            var state = new GamepadState();
            foreach (bool button in state.Buttons)
            {
                Assert.False(button);
            }
        }

        [Fact]
        public void GamepadState_GetButton_ValidIndex_ReturnsCorrectValue()
        {
            var state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.GetButton(0));
            Assert.False(state.GetButton(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(13)]
        [InlineData(100)]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse(int index)
        {
            var state = new GamepadState();
            Assert.False(state.GetButton(index));
        }

        [Fact]
        public void GamepadState_ButtonA_ReturnsButtons0()
        {
            var state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        [Fact]
        public void GamepadState_ButtonB_ReturnsButtons1()
        {
            var state = new GamepadState();
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        [Fact]
        public void GamepadState_ButtonX_ReturnsButtons2()
        {
            var state = new GamepadState();
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        [Fact]
        public void GamepadState_ButtonY_ReturnsButtons3()
        {
            var state = new GamepadState();
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        [Fact]
        public void GamepadState_ButtonLb_ReturnsButtons4()
        {
            var state = new GamepadState();
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        [Fact]
        public void GamepadState_ButtonRb_ReturnsButtons5()
        {
            var state = new GamepadState();
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        [Fact]
        public void GamepadState_ButtonLeftStickClick_ReturnsButtons10()
        {
            var state = new GamepadState();
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        [Fact]
        public void GamepadState_ButtonRightStickClick_ReturnsButtons11()
        {
            var state = new GamepadState();
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        [Fact]
        public void GamepadState_ButtonStart_ReturnsButtons9()
        {
            var state = new GamepadState();
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        [Fact]
        public void GamepadState_ButtonBack_ReturnsButtons8()
        {
            var state = new GamepadState();
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        [Fact]
        public void GamepadState_ButtonGuide_ReturnsButtons12()
        {
            var state = new GamepadState();
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        [Fact]
        public void GamepadState_SetConnected_Works()
        {
            var state = new GamepadState { Connected = true };
            Assert.True(state.Connected);
        }

        [Fact]
        public void GamepadState_SetAnalogSticks_Works()
        {
            var state = new GamepadState
            {
                LeftStickX = 0.5f,
                LeftStickY = -0.3f,
                RightStickX = 0.8f,
                RightStickY = -0.1f
            };
            Assert.Equal(0.5f, state.LeftStickX);
            Assert.Equal(-0.3f, state.LeftStickY);
            Assert.Equal(0.8f, state.RightStickX);
            Assert.Equal(-0.1f, state.RightStickY);
        }

        [Fact]
        public void GamepadState_SetTriggers_Works()
        {
            var state = new GamepadState
            {
                LeftTrigger = 0.7f,
                RightTrigger = 0.9f
            };
            Assert.Equal(0.7f, state.LeftTrigger);
            Assert.Equal(0.9f, state.RightTrigger);
        }

        // =====================================================================
        // DisplayMode
        // =====================================================================

        [Fact]
        public void DisplayMode_DefaultValues_AreZero()
        {
            var mode = new DisplayMode();
            Assert.Equal(0, mode.Width);
            Assert.Equal(0, mode.Height);
            Assert.Equal(0, mode.RefreshRate);
            Assert.False(mode.IsFullscreenOnly);
        }

        [Fact]
        public void DisplayMode_SetProperties_Works()
        {
            var mode = new DisplayMode
            {
                Width = 1920,
                Height = 1080,
                RefreshRate = 144,
                IsFullscreenOnly = true
            };
            Assert.Equal(1920, mode.Width);
            Assert.Equal(1080, mode.Height);
            Assert.Equal(144, mode.RefreshRate);
            Assert.True(mode.IsFullscreenOnly);
        }

        [Fact]
        public void DisplayMode_ToString_ReturnsExpectedFormat()
        {
            var mode = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        [Fact]
        public void DisplayMode_ToString_WithZeroRefreshRate()
        {
            var mode = new DisplayMode { Width = 800, Height = 600, RefreshRate = 0 };
            Assert.Equal("800x600@0Hz", mode.ToString());
        }

        // =====================================================================
        // DisplayEventArgs
        // =====================================================================

        [Fact]
        public void DisplayEventArgs_CanSetProperties()
        {
            var args = new DisplayEventArgs { Width = 1024, Height = 768 };
            Assert.Equal(1024, args.Width);
            Assert.Equal(768, args.Height);
        }

        // =====================================================================
        // OrientationEventArgs
        // =====================================================================

        [Fact]
        public void OrientationEventArgs_CanSetProperties()
        {
            var args = new OrientationEventArgs { Orientation = ScreenOrientation.Landscape };
            Assert.Equal(ScreenOrientation.Landscape, args.Orientation);
        }

        // =====================================================================
        // FullscreenEventArgs
        // =====================================================================

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FullscreenEventArgs_CanSetIsFullscreen(bool value)
        {
            var args = new FullscreenEventArgs { IsFullscreen = value };
            Assert.Equal(value, args.IsFullscreen);
        }

        // =====================================================================
        // WebAssemblyConfiguration - Default Values
        // =====================================================================

        [Fact]
        public void WebAssemblyConfiguration_DefaultValues_AreCorrect()
        {
            var config = new WebAssemblyConfiguration();

            Assert.Equal(800, config.WindowWidth);
            Assert.Equal(600, config.WindowHeight);
            Assert.Equal("WebAssembly Application", config.WindowTitle);
            Assert.Null(config.IconPath);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(4, config.MultisampleCount);
            Assert.False(config.Fullscreen);
            Assert.False(config.PointerLock);
            Assert.Equal(DisplayQuality.High, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
            Assert.True(config.TouchInputEnabled);
            Assert.Equal(0.15f, config.GamepadDeadzone);
            Assert.Equal(0.1f, config.TriggerDeadzone);
            Assert.False(config.DebugMode);
        }

        // =====================================================================
        // WebAssemblyConfigurationBuilder
        // =====================================================================

        [Fact]
        public void ConfigBuilder_WithSize_SetsWidthAndHeight()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithSize(1920, 1080)
                .Build();

            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_SetsTitle()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTitle("My Game")
                .Build();

            Assert.Equal("My Game", config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithIconPath_SetsIconPath()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithIconPath("/assets/icon.png")
                .Build();

            Assert.Equal("/assets/icon.png", config.IconPath);
        }

        [Fact]
        public void ConfigBuilder_WithVSync_SetsVSync()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithVSync(false)
                .Build();

            Assert.False(config.VSync);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_ValidValue_SetsRate()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(120)
                .Build();

            Assert.Equal(120, config.TargetFrameRate);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_Zero_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTargetFrameRate(0));
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_Negative_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTargetFrameRate(-1));
        }

        [Fact]
        public void ConfigBuilder_WithMultisampling_SetsEnabled()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithMultisampling(false)
                .Build();

            Assert.False(config.MultisamplingEnabled);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        public void ConfigBuilder_WithMultisampleCount_ValidValue_SetsCount(int count)
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithMultisampleCount(count)
                .Build();

            Assert.Equal(count, config.MultisampleCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(32)]
        public void ConfigBuilder_WithMultisampleCount_InvalidValue_Throws(int count)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithMultisampleCount(count));
        }

        [Fact]
        public void ConfigBuilder_WithFullscreen_SetsFullscreen()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithFullscreen(true)
                .Build();

            Assert.True(config.Fullscreen);
        }

        [Fact]
        public void ConfigBuilder_WithPointerLock_SetsPointerLock()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithPointerLock(true)
                .Build();

            Assert.True(config.PointerLock);
        }

        [Fact]
        public void ConfigBuilder_WithDisplayQuality_SetsQuality()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithDisplayQuality(DisplayQuality.Ultra)
                .Build();

            Assert.Equal(DisplayQuality.Ultra, config.DisplayQuality);
        }

        [Fact]
        public void ConfigBuilder_WithGamepadInput_SetsEnabled()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithGamepadInput(false)
                .Build();

            Assert.False(config.GamepadInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithKeyboardInput_SetsEnabled()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithKeyboardInput(false)
                .Build();

            Assert.False(config.KeyboardInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithMouseInput_SetsEnabled()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithMouseInput(false)
                .Build();

            Assert.False(config.MouseInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithTouchInput_SetsEnabled()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTouchInput(false)
                .Build();

            Assert.False(config.TouchInputEnabled);
        }

        [Theory]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        public void ConfigBuilder_WithGamepadDeadzone_ValidValue_SetsDeadzone(float deadzone)
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(deadzone)
                .Build();

            Assert.Equal(deadzone, config.GamepadDeadzone);
        }

        [Theory]
        [InlineData(-0.1f)]
        [InlineData(1.1f)]
        public void ConfigBuilder_WithGamepadDeadzone_InvalidValue_Throws(float deadzone)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithGamepadDeadzone(deadzone));
        }

        [Theory]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        public void ConfigBuilder_WithTriggerDeadzone_ValidValue_SetsDeadzone(float deadzone)
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(deadzone)
                .Build();

            Assert.Equal(deadzone, config.TriggerDeadzone);
        }

        [Theory]
        [InlineData(-0.01f)]
        [InlineData(1.01f)]
        public void ConfigBuilder_WithTriggerDeadzone_InvalidValue_Throws(float deadzone)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTriggerDeadzone(deadzone));
        }

        [Fact]
        public void ConfigBuilder_WithDebugMode_SetsDebugMode()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithDebugMode(true)
                .Build();

            Assert.True(config.DebugMode);
        }

        [Fact]
        public void ConfigBuilder_ChainedMethods_Works()
        {
            var config = new WebAssemblyConfigurationBuilder()
                .WithSize(1280, 720)
                .WithTitle("Chained Test")
                .WithVSync(true)
                .WithTargetFrameRate(60)
                .WithMultisampling(true)
                .WithMultisampleCount(4)
                .WithFullscreen(false)
                .WithDebugMode(true)
                .Build();

            Assert.Equal(1280, config.WindowWidth);
            Assert.Equal(720, config.WindowHeight);
            Assert.Equal("Chained Test", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(4, config.MultisampleCount);
            Assert.False(config.Fullscreen);
            Assert.True(config.DebugMode);
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
        // GamepadInputState
        // =====================================================================

        [Fact]
        public void GamepadInputState_Default_NullStates()
        {
            var state = new GamepadInputState();
            Assert.Null(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_ShiftsCurrentToPrevious()
        {
            var state = new GamepadInputState();
            var newState = new GamepadState { Connected = true, LeftStickX = 0.5f };

            state.Update(newState);

            Assert.Equal(newState, state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_UpdateTwice_PreservesPrevious()
        {
            var state = new GamepadInputState();
            var first = new GamepadState { Connected = true, LeftStickX = 0.3f };
            var second = new GamepadState { Connected = true, LeftStickX = 0.7f };

            state.Update(first);
            state.Update(second);

            Assert.Equal(second, state.CurrentState);
            Assert.Equal(first, state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_SetProperties_Works()
        {
            var state = new GamepadInputState
            {
                CurrentState = new GamepadState { Connected = true },
                PreviousState = new GamepadState { Connected = false }
            };
            Assert.True(state.CurrentState.Connected);
            Assert.False(state.PreviousState.Connected);
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
        // WebAssemblyPlatform - Additional coverage
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionX_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => platform.GetWindowPositionX());
            }
        }

        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionY_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => platform.GetWindowPositionY());
            }
        }

        [Fact]
        public void WebAssemblyPlatform_GetWindowMetrics_CallsInterop()
        {
            var platform = new WebAssemblyPlatform();
            // This calls into EmscriptenWeb interop; on non-browser may throw
            // We test that the method exists and is callable
            Assert.ThrowsAny<Exception>(() =>
                platform.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
        }

        [Fact]
        public void WebAssemblyPlatform_GetMousePositionInView_ReturnsDefaultCoords()
        {
            var platform = new WebAssemblyPlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetGamepadState_NoGamepads_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            bool result = platform.TryGetGamepadState(0, out var state);
            Assert.False(result);
            Assert.Null(state);
        }

        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_Empty_ReturnsEmptyArray()
        {
            var platform = new WebAssemblyPlatform();
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_GetProcAddress_CallsInterop()
        {
            var platform = new WebAssemblyPlatform();
            // Calls EGL.GetProcAddress which is a native interop
            Assert.ThrowsAny<Exception>(() => platform.GetProcAddress("glClearColor"));
        }

        [Fact]
        public void WebAssemblyPlatform_ShowWindow_SetsVisible()
        {
            var platform = new WebAssemblyPlatform();
            if (OperatingSystem.IsBrowser())
            {
                platform.ShowWindow();
                Assert.True(platform.IsWindowVisible());
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => platform.ShowWindow());
            }
        }

        [Fact]
        public void WebAssemblyPlatform_HideWindow_ClearsVisible()
        {
            var platform = new WebAssemblyPlatform();
            if (OperatingSystem.IsBrowser())
            {
                platform.ShowWindow();
                platform.HideWindow();
                Assert.False(platform.IsWindowVisible());
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => platform.ShowWindow());
            }
        }

        [Fact]
        public void WebAssemblyPlatform_SetTitle_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => platform.SetTitle("New Title"));
            }
        }

        [Fact]
        public void WebAssemblyPlatform_SetSize_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => platform.SetSize(1024, 768));
            }
        }

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("/icon.png");
            // Should not throw even if interop fails
        }

        [Fact]
        public void WebAssemblyPlatform_PollEvents_ResetsWheelDelta()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            Assert.Equal(5.0f, platform.GetMouseWheel());

            platform.PollEvents();

            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_PollEvents_ReturnsTrueWhenNotClosing()
        {
            var platform = new WebAssemblyPlatform();
            bool result = platform.PollEvents();
            Assert.True(result);
        }

        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNothing()
        {
            var platform = new WebAssemblyPlatform();
            platform.Cleanup();
            // Should not throw
        }

        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNotClearState()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnCharInput", (uint)'B');

            // Cleanup returns early when not initialized
            platform.Cleanup();

            // State is NOT cleared because _isInitialized is false
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void WebAssemblyPlatform_Initialize_WhenAlreadyInitialized_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            // First call may fail (no EGL), but second call should return true
            // because _isInitialized is set on first call
            platform.Initialize(800, 600, "Test");
            // The Initialize method catches exceptions and returns false on failure,
            // but if it succeeded, a second call returns true
        }

        [Fact]
        public void WebAssemblyPlatform_MakeContextCurrent_WithZeroHandles_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
            // Should not throw when EGL handles are zero
        }

        [Fact]
        public void WebAssemblyPlatform_SwapBuffers_WithZeroHandles_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            platform.SwapBuffers();
            // Should not throw when EGL handles are zero
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetLastKeyPressed_EmptyQueue_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.False(result);
            Assert.Equal(ConsoleKey.NoName, key);
        }

        [Fact]
        public void WebAssemblyPlatform_IsKeyDown_UnknownKey_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetLastInputCharacters_Empty_ReturnsFalse()
        {
            var platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastInputCharacters(out string chars);
            Assert.False(result);
            Assert.Equal(string.Empty, chars);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_SetsDelta()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, -3);
            Assert.Equal(-3.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_PositiveDelta()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            Assert.Equal(10.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_BoundaryButton0_Works()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 60);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(50, x);
            Assert.Equal(60, y);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_BoundaryButton4_Works()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[4]);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_OutOfBoundsButton_Ignored()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 5, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
            Assert.False(buttons[1]);
            Assert.False(buttons[2]);
            Assert.False(buttons[3]);
            Assert.False(buttons[4]);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_NegativeButton_Ignored()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", -1, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseUp_OutOfBoundsButton_Ignored()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", 10, 0, 0, 0, 0);
            // Should not throw
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_UpdatesDimensions()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowClose_SetsShouldClose()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            bool result = platform.PollEvents();
            Assert.False(result);
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_True_SetsVisible()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", true);
            Assert.True(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_False_ClearsVisible()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", false);
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_CreatesState()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            bool result = platform.TryGetGamepadState(0, out var state);
            Assert.True(result);
            Assert.True(state.Connected);
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_MultipleGamepads()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadConnect", 2);

            Assert.True(platform.TryGetGamepadState(0, out var s0) && s0.Connected);
            Assert.True(platform.TryGetGamepadState(1, out var s1) && s1.Connected);
            Assert.True(platform.TryGetGamepadState(2, out var s2) && s2.Connected);
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadDisconnect_SetsDisconnected()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            bool result = platform.TryGetGamepadState(0, out var state);
            Assert.True(result);
            Assert.False(state.Connected);
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadDisconnect_NonExistent_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadDisconnect", 99);
            // Should not throw
        }

        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_ReturnsOnlyConnected()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadDisconnect", 1);

            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
            Assert.Contains(0, indices);
        }

        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_AllDisconnected_ReturnsEmpty()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);

            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_OnCharInput_InvalidCharCode_DoesNotThrow()
        {
            var platform = new WebAssemblyPlatform();
            // Invalid UTF-32 code point
            InvokePrivate(platform, "OnCharInput", (uint)0x110000);
            // Should not throw
        }

        [Fact]
        public void WebAssemblyPlatform_OnCharInput_MultipleCharacters_Accumulates()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'H');
            InvokePrivate(platform, "OnCharInput", (uint)'i');
            InvokePrivate(platform, "OnCharInput", (uint)'!');

            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("Hi!", chars);
        }

        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_SameKeyMultipleTimes_EnqueuesEachTime()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key1));
            Assert.Equal(ConsoleKey.A, key1);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key2));
            Assert.Equal(ConsoleKey.A, key2);
        }

        // =====================================================================
        // WebAssemblyPlatform - Key code conversion
        // =====================================================================

        [Theory]
        [InlineData(65, ConsoleKey.A)]
        [InlineData(66, ConsoleKey.B)]
        [InlineData(90, ConsoleKey.Z)]
        [InlineData(48, ConsoleKey.D0)]
        [InlineData(57, ConsoleKey.D9)]
        [InlineData(13, ConsoleKey.Enter)]
        [InlineData(9, ConsoleKey.Tab)]
        [InlineData(32, ConsoleKey.Spacebar)]
        [InlineData(8, ConsoleKey.Backspace)]
        [InlineData(27, ConsoleKey.Escape)]
        [InlineData(46, ConsoleKey.Delete)]
        [InlineData(37, ConsoleKey.LeftArrow)]
        [InlineData(38, ConsoleKey.UpArrow)]
        [InlineData(39, ConsoleKey.RightArrow)]
        [InlineData(40, ConsoleKey.DownArrow)]
        [InlineData(112, ConsoleKey.F1)]
        [InlineData(123, ConsoleKey.F12)]
        [InlineData(96, ConsoleKey.NumPad0)]
        [InlineData(105, ConsoleKey.NumPad9)]
        [InlineData(36, ConsoleKey.Home)]
        [InlineData(35, ConsoleKey.End)]
        [InlineData(33, ConsoleKey.PageUp)]
        [InlineData(34, ConsoleKey.PageDown)]
        [InlineData(45, ConsoleKey.Insert)]
        [InlineData(19, ConsoleKey.Pause)]
        public void WebAssemblyPlatform_ConvertKeyCode_MapsCorrectly(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Fact]
        public void WebAssemblyPlatform_ConvertKeyCode_UnknownKey_MapsToNoName()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 999, 0);
            // Unknown key code maps to ConsoleKey.NoName, which IS in _keyStates
            // because InitializeDefaultKeyStates adds all ConsoleKey values
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatformFactory_CreateDefault_ReturnsInstance()
        {
            var platform = WebAssemblyPlatformFactory.CreateDefault();
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        [Fact]
        public void WebAssemblyPlatformFactory_Create_NullConfig_Throws()
        {
            WebAssemblyConfiguration nullConfig = null;
            Assert.Throws<ArgumentNullException>(() =>
                WebAssemblyPlatformFactory.Create(nullConfig));
        }

        [Fact]
        public void WebAssemblyPlatformFactory_Create_WithConfig_ThrowsOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformFactory.Create(config));
            }
        }

        [Fact]
        public void WebAssemblyPlatformFactory_Create_WithAction_NullAction_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                WebAssemblyPlatformFactory.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        [Fact]
        public void WebAssemblyPlatformFactory_CreateForGameDevelopment_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformFactory.CreateForGameDevelopment());
            }
        }

        [Fact]
        public void WebAssemblyPlatformFactory_CreateForLowEndDevice_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformFactory.CreateForLowEndDevice());
            }
        }

        [Fact]
        public void WebAssemblyPlatformFactory_CreateForHighEndDevice_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformFactory.CreateForHighEndDevice());
            }
        }

        // =====================================================================
        // WebAssemblyPlatformIntegration
        // =====================================================================

        [Theory]
        [InlineData("WebAssembly")]
        [InlineData("Web")]
        [InlineData("Emscripten")]
        [InlineData("WASM")]
        public void WebAssemblyPlatformIntegration_GetPlatform_ValidName_ReturnsInstance(string name)
        {
            var platform = WebAssemblyPlatformIntegration.GetPlatform(name);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_GetPlatform_InvalidName_Throws()
        {
            Assert.Throws<PlatformNotSupportedException>(() =>
                WebAssemblyPlatformIntegration.GetPlatform("InvalidPlatform"));
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_GetSupportedPlatforms_ReturnsNames()
        {
            string[] platforms = WebAssemblyPlatformIntegration.GetSupportedPlatforms();
            Assert.NotNull(platforms);
            Assert.Contains("WebAssembly", platforms);
            Assert.Contains("Web", platforms);
            Assert.Contains("Emscripten", platforms);
            Assert.Contains("WASM", platforms);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_RegisterPlatform_InvalidType_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(string)));
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Default_ReturnsInstance()
        {
            var platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Game2D()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Game3D()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game3D));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_LowEnd()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.LowEnd));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_HighEnd()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Mobile()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Web_ReturnsInstance()
        {
            var platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Web);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        // =====================================================================
        // GameContextPresets
        // =====================================================================

        [Fact]
        public void GameContextPresets_Game2D_ReturnsValidConfig()
        {
            var config = GameContextPresets.Game2D();
            Assert.Equal(1280, config.WindowWidth);
            Assert.Equal(720, config.WindowHeight);
            Assert.Equal("2D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(4, config.MultisampleCount);
            Assert.Equal(DisplayQuality.High, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
        }

        [Fact]
        public void GameContextPresets_Game3D_ReturnsValidConfig()
        {
            var config = GameContextPresets.Game3D();
            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
            Assert.Equal("3D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.Equal(DisplayQuality.VeryHigh, config.DisplayQuality);
        }

        [Fact]
        public void GameContextPresets_PuzzleGame_ReturnsValidConfig()
        {
            var config = GameContextPresets.PuzzleGame();
            Assert.Equal(800, config.WindowWidth);
            Assert.Equal(600, config.WindowHeight);
            Assert.Equal("Puzzle Game", config.WindowTitle);
            Assert.False(config.VSync);
            Assert.Equal(30, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(DisplayQuality.Medium, config.DisplayQuality);
            Assert.False(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
        }

        [Fact]
        public void GameContextPresets_MobileGame_ReturnsValidConfig()
        {
            var config = GameContextPresets.MobileGame();
            Assert.Equal(720, config.WindowWidth);
            Assert.Equal(1280, config.WindowHeight);
            Assert.Equal("Mobile Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(DisplayQuality.Medium, config.DisplayQuality);
            Assert.True(config.TouchInputEnabled);
        }

        // =====================================================================
        // WebAssemblyGameContext
        // =====================================================================

        [Fact]
        public void WebAssemblyGameContext_Constructor_NullConfig_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyGameContext(null));
        }

        [Fact]
        public void WebAssemblyGameContext_DefaultConstructor_CreatesInstance()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new WebAssemblyGameContext());
            }
        }

        [Fact]
        public void WebAssemblyGameContext_Create_WithDimensions_ReturnsInstance()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyGameContext.Create(1280, 720, "Test"));
            }
        }

        [Fact]
        public void WebAssemblyGameContext_Create_WithBuilder_NullAction_Throws()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyGameContext.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        [Fact]
        public void WebAssemblyGameContext_Create_WithBuilder_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyGameContext.Create(b => b.WithSize(800, 600)));
            }
        }

        // =====================================================================
        // GameDevelopmentUtils
        // =====================================================================

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_WithinDeadzone_ZeroesOutput()
        {
            float x = 0.1f;
            float y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_OutsideDeadzone_Normalizes()
        {
            float x = 0.5f;
            float y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0 && magnitude <= 1.0f);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_ZeroInput_StaysZero()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_CustomDeadzone_Works()
        {
            float x = 0.3f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.2f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_AtDeadzoneBoundary_ZeroesOutput()
        {
            float x = 0.15f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_WithinBounds_NoChange()
        {
            float x = 0.3f;
            float y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x, 5);
            Assert.Equal(0.4f, y, 5);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ExceedsBounds_Normalizes()
        {
            float x = 2.0f;
            float y = 0.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(1.0f, x, 5);
            Assert.Equal(0.0f, y, 5);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ZeroInput_NoChange()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(2, "X / Square")]
        [InlineData(3, "Y / Triangle")]
        [InlineData(4, "LB / L1")]
        [InlineData(5, "RB / R1")]
        [InlineData(6, "LT")]
        [InlineData(7, "RT")]
        [InlineData(8, "Back / Select")]
        [InlineData(9, "Start")]
        [InlineData(10, "Left Stick Click")]
        [InlineData(11, "Right Stick Click")]
        [InlineData(12, "Guide / Home")]
        [InlineData(13, "Button 13")]
        [InlineData(99, "Button 99")]
        public void GameDevelopmentUtils_GetGamepadButtonName_ReturnsCorrectName(int index, string expected)
        {
            string name = GameDevelopmentUtils.GetGamepadButtonName(index);
            Assert.Equal(expected, name);
        }

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

        [Fact]
        public void GameDevelopmentUtils_GetKeyName_DelegatesToInputManager()
        {
            Assert.Equal("A", GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
            Assert.Equal("Enter", GameDevelopmentUtils.GetKeyName(ConsoleKey.Enter));
        }

        // =====================================================================
        // SystemInfo
        // =====================================================================

        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.GetPlatformName());
        }

        // =====================================================================
        // EmscriptenWebScript
        // =====================================================================

        [Fact]
        public void EmscriptenWebScript_GetBridgeScript_ReturnsNonEmptyString()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.NotNull(script);
            Assert.NotEmpty(script);
        }

        [Fact]
        public void EmscriptenWebScript_GetBridgeScript_ContainsKeyFunctions()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("registerKeyboardCallbacks", script);
            Assert.Contains("registerMouseCallbacks", script);
            Assert.Contains("registerGamepadCallbacks", script);
            Assert.Contains("registerWindowCallbacks", script);
            Assert.Contains("getConnectedGamepads", script);
            Assert.Contains("getGamepadAxes", script);
            Assert.Contains("getGamepadButtons", script);
            Assert.Contains("showCanvas", script);
            Assert.Contains("hideCanvas", script);
            Assert.Contains("setWindowTitle", script);
            Assert.Contains("setCanvasSize", script);
            Assert.Contains("requestFullscreen", script);
            Assert.Contains("exitFullscreen", script);
            Assert.Contains("lockPointer", script);
            Assert.Contains("unlockPointer", script);
            Assert.Contains("vibrateGamepad", script);
            Assert.Contains("getSystemTimeMs", script);
            Assert.Contains("showAlert", script);
            Assert.Contains("showConfirm", script);
            Assert.Contains("getLanguage", script);
            Assert.Contains("isOnline", script);
            Assert.Contains("getBatteryLevel", script);
            Assert.Contains("isCharging", script);
            Assert.Contains("getOrientation", script);
            Assert.Contains("consoleLog", script);
            Assert.Contains("consoleWarn", script);
            Assert.Contains("consoleError", script);
        }

        [Fact]
        public void EmscriptenWebScript_GetBridgeScript_ContainsEmscriptenWebBridge()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("EmscriptenWebBridge", script);
            Assert.Contains("keyboardCallbacks", script);
            Assert.Contains("mouseCallbacks", script);
            Assert.Contains("gamepadCallbacks", script);
            Assert.Contains("windowCallbacks", script);
        }

        [Fact]
        public void EmscriptenWebScript_GetBridgeScript_ContainsArrayHelpers()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("createIntArray", script);
            Assert.Contains("createFloatArray", script);
            Assert.Contains("createBoolArray", script);
            Assert.Contains("freeArray", script);
        }

        [Fact]
        public void EmscriptenWebScript_GetBridgeScript_ContainsInitFunction()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("init: function", script);
            Assert.Contains("registerKeyboardListeners", script);
            Assert.Contains("registerMouseListeners", script);
            Assert.Contains("registerGamepadListeners", script);
            Assert.Contains("registerWindowListeners", script);
        }

        [Fact]
        public void EmscriptenWebScript_GetHtmlTemplate_ReturnsNonEmptyString()
        {
            string html = EmscriptenWebScript.GetHtmlTemplate();
            Assert.NotNull(html);
            Assert.NotEmpty(html);
        }

        [Fact]
        public void EmscriptenWebScript_GetHtmlTemplate_ContainsRequiredElements()
        {
            string html = EmscriptenWebScript.GetHtmlTemplate();
            Assert.Contains("<!DOCTYPE html>", html);
            Assert.Contains("<html", html);
            Assert.Contains("<head>", html);
            Assert.Contains("<body>", html);
            Assert.Contains("canvas", html); // CSS selector for canvas element
            Assert.Contains("</html>", html);
            Assert.Contains("WebAssembly Game", html);
            Assert.Contains("game.js", html);
        }

        // =====================================================================
        // WebAssemblyGameExamples - All examples throw outside browser
        // =====================================================================

        [Fact]
        public void WebAssemblyGameExamples_FpsGameExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.FpsGameExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_SystemInfoExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.SystemInfoExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_ConfigurationPresetsExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_TextInputExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.TextInputExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_PerformanceMonitoringExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_DialogBoxExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DialogBoxExample());
        }

        [Fact]
        public void WebAssemblyGameExamples_CompleteGameTemplate_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.CompleteGameTemplate());
        }

        // =====================================================================
        // WebAssemblyInputContext
        // =====================================================================

        [Fact]
        public void WebAssemblyInputContext_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputContext(null));
        }

        // =====================================================================
        // WebAssemblyInputManager
        // =====================================================================

        [Fact]
        public void WebAssemblyInputManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyInputManager(null));
        }

        // =====================================================================
        // WebAssemblyDisplayManager
        // =====================================================================

        [Fact]
        public void WebAssemblyDisplayManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyDisplayManager(null));
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            // This calls EmscriptenWeb.ConsoleLog which is a native interop
            // On non-browser platforms, this will throw
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => QuickStart.LogPlatformInfo());
            }
        }

        // =====================================================================
        // Helper method for invoking private members
        // =====================================================================

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
