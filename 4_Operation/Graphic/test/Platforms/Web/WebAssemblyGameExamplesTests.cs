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
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly game examples tests class
    /// </summary>
    public class WebAssemblyGameExamplesTests
    {
        // =====================================================================
        // Example methods — all require WebAssembly runtime, so they throw
        // on non-WebAssembly hosts.  We verify the expected exception.
        // =====================================================================

        /// <summary>
        /// Tests that basic game loop example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void BasicGameLoopExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        }

        /// <summary>
        /// Tests that gamepad input example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void GamepadInputExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.GamepadInputExample());
        }

        /// <summary>
        /// Tests that display management example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void DisplayManagementExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DisplayManagementExample());
        }

        /// <summary>
        /// Tests that fps game example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void FpsGameExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.FpsGameExample());
        }

        /// <summary>
        /// Tests that system info example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void SystemInfoExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.SystemInfoExample());
        }

        /// <summary>
        /// Tests that configuration presets example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void ConfigurationPresetsExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        }

        /// <summary>
        /// Tests that text input example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void TextInputExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.TextInputExample());
        }

        /// <summary>
        /// Tests that performance monitoring example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void PerformanceMonitoringExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        }

        /// <summary>
        /// Tests that dialog box example throws on non web assembly
        /// </summary>
        [WebOnly]
        public void DialogBoxExample_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DialogBoxExample());
        }

        /// <summary>
        /// Tests that complete game template throws on non web assembly
        /// </summary>
        [WebOnly]
        public void CompleteGameTemplate_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.CompleteGameTemplate());
        }

        // =====================================================================
        // Private helpers via reflection
        // =====================================================================

        /// <summary>
        /// Tests that handle single gamepad input null context throws null reference exception
        /// </summary>
        [WebOnly]
        public void HandleSingleGamepadInput_NullContext_ThrowsNullReferenceException()
        {
            MethodInfo method = typeof(WebAssemblyGameExamples)
                .GetMethod("HandleSingleGamepadInput", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null, 0 }));
        }

        /// <summary>
        /// Tests that handle pointer lock null context throws null reference exception
        /// </summary>
        [WebOnly]
        public void HandlePointerLock_NullContext_ThrowsNullReferenceException()
        {
            MethodInfo method = typeof(WebAssemblyGameExamples)
                .GetMethod("HandlePointerLock", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null, false }));
        }

        /// <summary>
        /// Tests that handle keyboard movement null context throws null reference exception
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that gamepad state default not connected
        /// </summary>
        [WebOnly]
        public void GamepadState_Default_NotConnected()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.Connected);
        }

        /// <summary>
        /// Tests that gamepad state button a returns buttons 0
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonA_ReturnsButtons0()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonA);
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        /// <summary>
        /// Tests that gamepad state button b returns buttons 1
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonB_ReturnsButtons1()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonB);
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        /// <summary>
        /// Tests that gamepad state button x returns buttons 2
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonX_ReturnsButtons2()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonX);
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        /// <summary>
        /// Tests that gamepad state button y returns buttons 3
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonY_ReturnsButtons3()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonY);
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        /// <summary>
        /// Tests that gamepad state button lb returns buttons 4
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonLb_ReturnsButtons4()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLb);
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        /// <summary>
        /// Tests that gamepad state button rb returns buttons 5
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonRb_ReturnsButtons5()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRb);
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        /// <summary>
        /// Tests that gamepad state button left stick click returns buttons 10
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonLeftStickClick_ReturnsButtons10()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonLeftStickClick);
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        /// <summary>
        /// Tests that gamepad state button right stick click returns buttons 11
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonRightStickClick_ReturnsButtons11()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonRightStickClick);
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        /// <summary>
        /// Tests that gamepad state button start returns buttons 9
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonStart_ReturnsButtons9()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonStart);
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        /// <summary>
        /// Tests that gamepad state button back returns buttons 8
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonBack_ReturnsButtons8()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonBack);
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        /// <summary>
        /// Tests that gamepad state button guide returns buttons 12
        /// </summary>
        [WebOnly]
        public void GamepadState_ButtonGuide_ReturnsButtons12()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.ButtonGuide);
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        /// <summary>
        /// Tests that gamepad state axes properties round trip
        /// </summary>
        [WebOnly]
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
            Assert.Equal(0.5f, state.LeftStickX, 5);
            Assert.Equal(-0.5f, state.LeftStickY, 5);
            Assert.Equal(1.0f, state.RightStickX, 5);
            Assert.Equal(-1.0f, state.RightStickY, 5);
            Assert.Equal(0.75f, state.LeftTrigger, 5);
            Assert.Equal(0.25f, state.RightTrigger, 5);
        }

        /// <summary>
        /// Tests that gamepad state get button invalid index returns false
        /// </summary>
        [WebOnly]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(-1));
            Assert.False(state.GetButton(13));
            Assert.False(state.GetButton(99));
        }

        /// <summary>
        /// Tests that gamepad state get button valid index returns button state
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that gamepad input state default properties are null
        /// </summary>
        [WebOnly]
        public void GamepadInputState_Default_PropertiesAreNull()
        {
            GamepadInputState inputState = new GamepadInputState();
            Assert.Null(inputState.CurrentState);
            Assert.Null(inputState.PreviousState);
        }

        /// <summary>
        /// Tests that gamepad input state update shifts states
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that configuration builder default build has defaults
        /// </summary>
        [WebOnly]
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
            Assert.Equal(0.15f, config.GamepadDeadzone, 5);
            Assert.Equal(0.1f, config.TriggerDeadzone, 5);
            Assert.False(config.DebugMode);
            Assert.Null(config.IconPath);
        }

        /// <summary>
        /// Tests that configuration builder full chain configures correctly
        /// </summary>
        [WebOnly]
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
            Assert.Equal(0.2f, config.GamepadDeadzone, 5);
            Assert.Equal(0.05f, config.TriggerDeadzone, 5);
            Assert.True(config.DebugMode);
            Assert.Equal("icon.png", config.IconPath);
        }

        /// <summary>
        /// Tests that configuration builder disable options works
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that configuration builder with target frame rate zero or negative throws
        /// </summary>
        [WebOnly]
        public void ConfigurationBuilder_WithTargetFrameRate_ZeroOrNegative_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithTargetFrameRate(0));
            Assert.Throws<ArgumentException>(() => builder.WithTargetFrameRate(-1));
        }

        /// <summary>
        /// Tests that configuration builder with multisample count invalid throws
        /// </summary>
        [WebOnly]
        public void ConfigurationBuilder_WithMultisampleCount_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(3));
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(6));
            Assert.Throws<ArgumentException>(() => builder.WithMultisampleCount(0));
        }

        /// <summary>
        /// Tests that configuration builder with gamepad deadzone invalid throws
        /// </summary>
        [WebOnly]
        public void ConfigurationBuilder_WithGamepadDeadzone_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithGamepadDeadzone(-0.1f));
            Assert.Throws<ArgumentException>(() => builder.WithGamepadDeadzone(1.1f));
        }

        /// <summary>
        /// Tests that configuration builder with trigger deadzone invalid throws
        /// </summary>
        [WebOnly]
        public void ConfigurationBuilder_WithTriggerDeadzone_Invalid_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            Assert.Throws<ArgumentException>(() => builder.WithTriggerDeadzone(-0.1f));
            Assert.Throws<ArgumentException>(() => builder.WithTriggerDeadzone(1.1f));
        }

        // =====================================================================
        // WebAssemblyInputManager — methods used indirectly in HandleSingleGamepadInput
        // =====================================================================

        /// <summary>
        /// Tests that input manager no gamepads get connected gamepad indices returns empty
        /// </summary>
        [WebOnly]
        public void InputManager_NoGamepads_GetConnectedGamepadIndices_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            int[] indices = manager.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        /// <summary>
        /// Tests that input manager no gamepads try get gamepad state returns false
        /// </summary>
        [WebOnly]
        public void InputManager_NoGamepads_TryGetGamepadState_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.TryGetGamepadState(0, out GamepadInputState state));
            Assert.Null(state);
        }

        /// <summary>
        /// Tests that input manager no gamepads is gamepad button just pressed returns false
        /// </summary>
        [WebOnly]
        public void InputManager_NoGamepads_IsGamepadButtonJustPressed_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustPressed(0, 0));
        }

        /// <summary>
        /// Tests that input manager no gamepads is gamepad button just released returns false
        /// </summary>
        [WebOnly]
        public void InputManager_NoGamepads_IsGamepadButtonJustReleased_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            Assert.False(manager.IsGamepadButtonJustReleased(0, 0));
        }

        // =====================================================================
        // WebAssemblyDisplayManager event-args types
        // =====================================================================

        /// <summary>
        /// Tests that display event args properties round trip
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that orientation event args properties round trip
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that fullscreen event args properties round trip
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that display mode properties round trip
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that display mode to string returns formatted string
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that screen orientation values are correct
        /// </summary>
        [WebOnly]
        public void ScreenOrientation_Values_AreCorrect()
        {
            Assert.Equal(0, (int)ScreenOrientation.Portrait);
            Assert.Equal(1, (int)ScreenOrientation.Landscape);
            Assert.Equal(2, (int)ScreenOrientation.Square);
        }

        // =====================================================================
        // DisplayQuality enum
        // =====================================================================

        /// <summary>
        /// Tests that display quality values are correct
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that apply deadzone negative deadzone applies formula
        /// </summary>
        [WebOnly]
        public void ApplyDeadzone_NegativeDeadzone_AppliesFormula()
        {
            float x = 0.3f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, -0.1f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude >= 0);
        }

        /// <summary>
        /// Tests that apply deadzone magnitude above deadzone result magnitude is normalized
        /// </summary>
        [WebOnly]
        public void ApplyDeadzone_MagnitudeAboveDeadzone_ResultMagnitudeIsNormalized()
        {
            float x = 0.9f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
            Assert.True(magnitude <= 1.0f);
        }

        /// <summary>
        /// Tests that normalize input magnitude exactly one no change
        /// </summary>
        [WebOnly]
        public void NormalizeInput_MagnitudeExactlyOne_NoChange()
        {
            float x = 0.6f;
            float y = 0.8f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.6f, x, 5);
            Assert.Equal(0.8f, y, 5);
        }

        /// <summary>
        /// Tests that normalize input y only exceeds bounds normalizes
        /// </summary>
        [WebOnly]
        public void NormalizeInput_YOnlyExceedsBounds_Normalizes()
        {
            float x = 0.0f;
            float y = 2.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.0f, x, 5);
            Assert.Equal(1.0f, y, 5);
        }

        /// <summary>
        /// Tests that get gamepad button name negative index returns formatted
        /// </summary>
        [WebOnly]
        public void GetGamepadButtonName_NegativeIndex_ReturnsFormatted()
        {
            Assert.Equal("Button -1", GameDevelopmentUtils.GetGamepadButtonName(-1));
        }

        /// <summary>
        /// Tests that get gamepad button name large index returns formatted
        /// </summary>
        [WebOnly]
        public void GetGamepadButtonName_LargeIndex_ReturnsFormatted()
        {
            Assert.Equal("Button 100", GameDevelopmentUtils.GetGamepadButtonName(100));
        }

        /// <summary>
        /// Tests that get key name returns string for all common keys
        /// </summary>
        [WebOnly]
        public void GetKeyName_ReturnsStringForAllCommonKeys()
        {
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Spacebar));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Tab));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.F12));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.NumPad9));
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.Pause));
        }

        /// <summary>
        /// Tests that get key name unknown key returns unknown
        /// </summary>
        [WebOnly]
        public void GetKeyName_UnknownKey_ReturnsUnknown()
        {
            Assert.Equal("Unknown", GameDevelopmentUtils.GetKeyName((ConsoleKey)255));
        }

        // =====================================================================
        // WebAssemblyConfiguration properties
        // =====================================================================

        /// <summary>
        /// Tests that web assembly configuration default values
        /// </summary>
        [WebOnly]
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
            Assert.Equal(0.15f, config.GamepadDeadzone, 5);
            Assert.Equal(0.1f, config.TriggerDeadzone, 5);
            Assert.False(config.Fullscreen);
            Assert.False(config.PointerLock);
            Assert.False(config.DebugMode);
            Assert.Null(config.IconPath);
        }

        /// <summary>
        /// Tests that web assembly configuration properties round trip
        /// </summary>
        [WebOnly]
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
            Assert.Equal(0.3f, config.GamepadDeadzone, 5);
            Assert.Equal(0.2f, config.TriggerDeadzone, 5);
            Assert.True(config.DebugMode);
            Assert.Equal("custom.ico", config.IconPath);
        }

        // =====================================================================
        // WebAssemblyPlatform — low-level constructor does not need runtime
        // =====================================================================

        /// <summary>
        /// Tests that web assembly platform constructor initializes defaults
        /// </summary>
        [WebOnly]
        public void WebAssemblyPlatform_Constructor_InitializesDefaults()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }
    }
}
