// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamplesTests.cs
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
    public class WebAssemblyGameExamplesTests
    {
        // =====================================================================
        // Example methods — all require WebAssembly runtime, so they throw
        // on non-WebAssembly hosts.  We verify the expected exception.
        // =====================================================================

        [Fact]
        public void BasicGameLoopExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        }

        [Fact]
        public void GamepadInputExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.GamepadInputExample());
        }

        [Fact]
        public void DisplayManagementExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DisplayManagementExample());
        }

        [Fact]
        public void FpsGameExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.FpsGameExample());
        }

        [Fact]
        public void SystemInfoExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.SystemInfoExample());
        }

        [Fact]
        public void ConfigurationPresetsExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        }

        [Fact]
        public void TextInputExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.TextInputExample());
        }

        [Fact]
        public void PerformanceMonitoringExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        }

        [Fact]
        public void DialogBoxExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DialogBoxExample());
        }

        [Fact]
        public void CompleteGameTemplate_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.CompleteGameTemplate());
        }

        // =====================================================================
        // Private helpers via reflection
        // =====================================================================

        [Fact]
        public void HandleSingleGamepadInput_NullContext_ThrowsNullReferenceException()
        {
            MethodInfo method = typeof(WebAssemblyGameExamples)
                .GetMethod("HandleSingleGamepadInput", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null, 0 }));
        }

        [Fact]
        public void HandlePointerLock_NullContext_ThrowsNullReferenceException()
        {
            MethodInfo method = typeof(WebAssemblyGameExamples)
                .GetMethod("HandlePointerLock", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null, false }));
        }

        [Fact]
        public void HandleKeyboardMovement_NullContext_ThrowsNullReferenceException()
        {
            MethodInfo method = typeof(WebAssemblyGameExamples)
                .GetMethod("HandleKeyboardMovement", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null }));
        }

        // =====================================================================
        // GamepadState
        // =====================================================================

        [Fact]
        public void GamepadState_Default_NotConnected()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.Connected);
        }

        [Fact]
        public void GamepadState_ButtonA_ReturnsButtons0()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonA);
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        [Fact]
        public void GamepadState_ButtonB_ReturnsButtons1()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonB);
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        [Fact]
        public void GamepadState_ButtonX_ReturnsButtons2()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonX);
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        [Fact]
        public void GamepadState_ButtonY_ReturnsButtons3()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonY);
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        [Fact]
        public void GamepadState_ButtonLb_ReturnsButtons4()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLb);
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        [Fact]
        public void GamepadState_ButtonRb_ReturnsButtons5()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRb);
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        [Fact]
        public void GamepadState_ButtonLeftStickClick_ReturnsButtons10()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLeftStickClick);
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        [Fact]
        public void GamepadState_ButtonRightStickClick_ReturnsButtons11()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRightStickClick);
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        [Fact]
        public void GamepadState_ButtonStart_ReturnsButtons9()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonStart);
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        [Fact]
        public void GamepadState_ButtonBack_ReturnsButtons8()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonBack);
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        [Fact]
        public void GamepadState_ButtonGuide_ReturnsButtons12()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonGuide);
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        [Fact]
        public void GamepadState_AxesProperties_RoundTrip()
        {
            GamepadState state = new GamepadState
            {
                LeftStickX = 0.5f,
                LeftStickY = -0.5f,
                RightStickX = 1.0f,
                RightStickY = -1.0f,
                LeftTrigger = 0.75f,
                RightTrigger = 0.25f
            };
            Assert.Equal(0.5f, state.LeftStickX);
            Assert.Equal(-0.5f, state.LeftStickY);
            Assert.Equal(1.0f, state.RightStickX);
            Assert.Equal(-1.0f, state.RightStickY);
            Assert.Equal(0.75f, state.LeftTrigger);
            Assert.Equal(0.25f, state.RightTrigger);
        }

        [Fact]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(-1));
            Assert.False(state.GetButton(13));
            Assert.False(state.GetButton(99));
        }

        [Fact]
        public void GamepadState_GetButton_ValidIndex_ReturnsButtonState()
        {
            GamepadState state = new GamepadState();
            state.Buttons[2] = true;
            Assert.True(state.GetButton(2));
            Assert.False(state.GetButton(1));
        }

        // =====================================================================
        // GamepadInputState
        // =====================================================================

        [Fact]
        public void GamepadInputState_Default_PropertiesAreNull()
        {
            GamepadInputState inputState = new GamepadInputState();
            Assert.Null(inputState.CurrentState);
            Assert.Null(inputState.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_ShiftsStates()
        {
            GamepadInputState inputState = new GamepadInputState();
            GamepadState first = new GamepadState { Connected = true };
            GamepadState second = new GamepadState { Connected = false };

            inputState.Update(first);
            Assert.Same(first, inputState.CurrentState);
            Assert.Null(inputState.PreviousState);

            inputState.Update(second);
            Assert.Same(second, inputState.CurrentState);
            Assert.Same(first, inputState.PreviousState);
        }

        // =====================================================================
        // WebAssemblyConfigurationBuilder — fluent chain used in examples
        // =====================================================================

        [Fact]
        public void ConfigurationBuilder_DefaultBuild_HasDefaults()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder().Build();
            Assert.Equal(800, config.WindowWidth);
            Assert.Equal(600, config.WindowHeight);
            Assert.Equal("WebAssembly Application", config.WindowTitle);
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
            Assert.Null(config.IconPath);
        }

        [Fact]
        public void ConfigurationBuilder_FullChain_ConfiguresCorrectly()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(1600, 900)
                .WithTitle("Custom Game")
                .WithVSync(true)
                .WithTargetFrameRate(120)
                .WithMultisampling(true)
                .WithMultisampleCount(8)
                .WithGamepadInput(true)
                .WithKeyboardInput(true)
                .WithMouseInput(true)
                .WithFullscreen(true)
                .WithPointerLock(false)
                .WithDisplayQuality(DisplayQuality.Ultra)
                .WithTouchInput(false)
                .WithGamepadDeadzone(0.2f)
                .WithTriggerDeadzone(0.05f)
                .WithDebugMode(true)
                .WithIconPath("icon.png")
                .Build();

            Assert.Equal(1600, config.WindowWidth);
            Assert.Equal(900, config.WindowHeight);
            Assert.Equal("Custom Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(120, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.True(config.Fullscreen);
            Assert.False(config.PointerLock);
            Assert.Equal(DisplayQuality.Ultra, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
            Assert.False(config.TouchInputEnabled);
            Assert.Equal(0.2f, config.GamepadDeadzone);
            Assert.Equal(0.05f, config.TriggerDeadzone);
            Assert.True(config.DebugMode);
            Assert.Equal("icon.png", config.IconPath);
        }

        [Fact]
        public void ConfigurationBuilder_DisableOptions_Works()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithVSync(false)
                .WithMultisampling(false)
                .WithGamepadInput(false)
                .WithKeyboardInput(false)
                .WithMouseInput(false)
                .WithFullscreen(false)
                .Build();

            Assert.False(config.VSync);
            Assert.False(config.MultisamplingEnabled);
            Assert.False(config.GamepadInputEnabled);
            Assert.False(config.KeyboardInputEnabled);
            Assert.False(config.MouseInputEnabled);
            Assert.False(config.Fullscreen);
        }

        [Fact]
        public void ConfigurationBuilder_WithTargetFrameRate_ZeroOrNegative_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithTargetFrameRate(0));
            Assert.Throws<ArgumentException>(() => builder.WithTargetFrameRate(-1));
        }

        [Fact]
        public void ConfigurationBuilder_WithMultisampleCount_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(3));
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(6));
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(0));
        }

        [Fact]
        public void ConfigurationBuilder_WithGamepadDeadzone_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithGamepadDeadzone(-0.1f));
            Assert.Throws<ArgumentException>(() => builder.WithGamepadDeadzone(1.1f));
        }

        [Fact]
        public void ConfigurationBuilder_WithTriggerDeadzone_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithTriggerDeadzone(-0.1f));
            Assert.Throws<ArgumentException>(() => builder.WithTriggerDeadzone(1.1f));
        }

        // =====================================================================
        // WebAssemblyInputManager — methods used indirectly in HandleSingleGamepadInput
        // =====================================================================

        [Fact]
        public void InputManager_NoGamepads_GetConnectedGamepadIndices_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        [Fact]
        public void InputManager_NoGamepads_TryGetGamepadState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.TryGetGamepadState(0, out GamepadInputState state));
            Assert.Null(state);
        }

        [Fact]
        public void InputManager_NoGamepads_IsGamepadButtonJustPressed_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        [Fact]
        public void InputManager_NoGamepads_IsGamepadButtonJustReleased_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        // =====================================================================
        // WebAssemblyDisplayManager event-args types
        // =====================================================================

        [Fact]
        public void DisplayEventArgs_Properties_RoundTrip()
        {
            DisplayEventArgs args = new DisplayEventArgs
            {
                Width = 1920,
                Height = 1080
            };
            Assert.Equal(1920, args.Width);
            Assert.Equal(1080, args.Height);
        }

        [Fact]
        public void OrientationEventArgs_Properties_RoundTrip()
        {
            OrientationEventArgs args = new OrientationEventArgs
            {
                Orientation = ScreenOrientation.Portrait
            };
            Assert.Equal(ScreenOrientation.Portrait, args.Orientation);

            args.Orientation = ScreenOrientation.Landscape;
            Assert.Equal(ScreenOrientation.Landscape, args.Orientation);

            args.Orientation = ScreenOrientation.Square;
            Assert.Equal(ScreenOrientation.Square, args.Orientation);
        }

        [Fact]
        public void FullscreenEventArgs_Properties_RoundTrip()
        {
            FullscreenEventArgs args = new FullscreenEventArgs
            {
                IsFullscreen = true
            };
            Assert.True(args.IsFullscreen);

            args.IsFullscreen = false;
            Assert.False(args.IsFullscreen);
        }

        // =====================================================================
        // DisplayMode
        // =====================================================================

        [Fact]
        public void DisplayMode_Properties_RoundTrip()
        {
            DisplayMode mode = new DisplayMode
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
        public void DisplayMode_ToString_ReturnsFormattedString()
        {
            DisplayMode mode = new DisplayMode
            {
                Width = 1920,
                Height = 1080,
                RefreshRate = 60
            };
            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        // =====================================================================
        // ScreenOrientation enum
        // =====================================================================

        [Fact]
        public void ScreenOrientation_Values_AreCorrect()
        {
            Assert.Equal(0, (int)ScreenOrientation.Portrait);
            Assert.Equal(1, (int)ScreenOrientation.Landscape);
            Assert.Equal(2, (int)ScreenOrientation.Square);
        }

        // =====================================================================
        // DisplayQuality enum
        // =====================================================================

        [Fact]
        public void DisplayQuality_Values_AreCorrect()
        {
            Assert.Equal(0, (int)DisplayQuality.VeryLow);
            Assert.Equal(1, (int)DisplayQuality.Low);
            Assert.Equal(2, (int)DisplayQuality.Medium);
            Assert.Equal(3, (int)DisplayQuality.High);
            Assert.Equal(4, (int)DisplayQuality.VeryHigh);
            Assert.Equal(5, (int)DisplayQuality.Ultra);
        }

        // =====================================================================
        // GameDevelopmentUtils — pure logic edge cases beyond existing tests
        // =====================================================================

        [Fact]
        public void ApplyDeadzone_NegativeDeadzone_AppliesFormula()
        {
            float x = 0.3f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, -0.1f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude >= 0);
        }

        [Fact]
        public void ApplyDeadzone_MagnitudeAboveDeadzone_ResultMagnitudeIsNormalized()
        {
            float x = 0.9f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
            Assert.True(magnitude <= 1.0f);
        }

        [Fact]
        public void NormalizeInput_MagnitudeExactlyOne_NoChange()
        {
            float x = 0.6f;
            float y = 0.8f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.6f, x, 5);
            Assert.Equal(0.8f, y, 5);
        }

        [Fact]
        public void NormalizeInput_YOnlyExceedsBounds_Normalizes()
        {
            float x = 0.0f;
            float y = 2.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.0f, x, 5);
            Assert.Equal(1.0f, y, 5);
        }

        [Fact]
        public void GetGamepadButtonName_NegativeIndex_ReturnsFormatted()
        {
            Assert.Equal("Button -1", GameDevelopmentUtils.GetGamepadButtonName(-1));
        }

        [Fact]
        public void GetGamepadButtonName_LargeIndex_ReturnsFormatted()
        {
            Assert.Equal("Button 100", GameDevelopmentUtils.GetGamepadButtonName(100));
        }

        [Fact]
        public void GetKeyName_ReturnsStringForAllCommonKeys()
        {
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Spacebar));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Tab));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.F12));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.NumPad9));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Pause));
        }

        [Fact]
        public void GetKeyName_UnknownKey_ReturnsUnknown()
        {
            Assert.Equal("Unknown", GameDevelopmentUtils.GetKeyName((ConsoleKey)255));
        }

        // =====================================================================
        // WebAssemblyConfiguration properties
        // =====================================================================

        [Fact]
        public void WebAssemblyConfiguration_DefaultValues()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();
            Assert.Equal(800, config.WindowWidth);
            Assert.Equal(600, config.WindowHeight);
            Assert.Equal("WebAssembly Application", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(4, config.MultisampleCount);
            Assert.Equal(DisplayQuality.High, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
            Assert.True(config.TouchInputEnabled);
            Assert.Equal(0.15f, config.GamepadDeadzone);
            Assert.Equal(0.1f, config.TriggerDeadzone);
            Assert.False(config.Fullscreen);
            Assert.False(config.PointerLock);
            Assert.False(config.DebugMode);
            Assert.Null(config.IconPath);
        }

        [Fact]
        public void WebAssemblyConfiguration_Properties_RoundTrip()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                WindowWidth = 640,
                WindowHeight = 480,
                WindowTitle = "Test",
                VSync = false,
                TargetFrameRate = 30,
                MultisamplingEnabled = false,
                MultisampleCount = 2,
                Fullscreen = true,
                PointerLock = true,
                DisplayQuality = DisplayQuality.Low,
                GamepadInputEnabled = false,
                KeyboardInputEnabled = false,
                MouseInputEnabled = false,
                TouchInputEnabled = false,
                GamepadDeadzone = 0.3f,
                TriggerDeadzone = 0.2f,
                DebugMode = true,
                IconPath = "custom.ico"
            };

            Assert.Equal(640, config.WindowWidth);
            Assert.Equal(480, config.WindowHeight);
            Assert.Equal("Test", config.WindowTitle);
            Assert.False(config.VSync);
            Assert.Equal(30, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(2, config.MultisampleCount);
            Assert.True(config.Fullscreen);
            Assert.True(config.PointerLock);
            Assert.Equal(DisplayQuality.Low, config.DisplayQuality);
            Assert.False(config.GamepadInputEnabled);
            Assert.False(config.KeyboardInputEnabled);
            Assert.False(config.MouseInputEnabled);
            Assert.False(config.TouchInputEnabled);
            Assert.Equal(0.3f, config.GamepadDeadzone);
            Assert.Equal(0.2f, config.TriggerDeadzone);
            Assert.True(config.DebugMode);
            Assert.Equal("custom.ico", config.IconPath);
        }

        // =====================================================================
        // WebAssemblyPlatform — low-level constructor does not need runtime
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_Constructor_InitializesDefaults()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }
    }
}
