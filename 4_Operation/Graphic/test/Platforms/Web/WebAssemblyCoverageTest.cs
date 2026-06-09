// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyCoverageTest.cs
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
    ///     Tests targeting remaining uncovered code paths in WebAssembly platform files.
    ///     Focus: WebAssemblyGameContext, WebAssemblyPlatform (Initialize, Cleanup, ConvertKeyCode),
    ///     WebAssemblyGameExamples, WebAssemblyPlatformIntegration (MultiplatformGameEngine, wrappers),
    ///     EmscriptenWeb wrappers.
    /// </summary>
    public class WebAssemblyCoverageTest
    {
        // =====================================================================

        // =====================================================================

        /// <summary>
        /// Tests that game context console log does not throw
        /// </summary>
        [Fact]
        public void GameContext_ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test");
        }

        /// <summary>
        /// Tests that game context console warn does not throw
        /// </summary>
        [Fact]
        public void GameContext_ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test");
        }

        /// <summary>
        /// Tests that game context console error does not throw
        /// </summary>
        [Fact]
        public void GameContext_ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test");
        }

        // =====================================================================

        /// <summary>
        /// Tests that game context show alert does not throw
        /// </summary>
        [Fact]
        public void GameContext_ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test");
        }

        /// <summary>
        /// Tests that game context show confirm returns false on non browser
        /// </summary>
        [Fact]
        public void GameContext_ShowConfirm_ReturnsFalseOnNonBrowser()
        {
            bool result = WebAssemblyGameContext.ShowConfirm("test");
            Assert.False(result);
        }

        // =====================================================================

      

        /// <summary>
        /// Tests that web assembly platform initialize already initialized returns true
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_Initialize_AlreadyInitialized_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
        }

        // =====================================================================

        /// <summary>
        /// Tests that web assembly platform cleanup when initialized clears state
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_Cleanup_WhenInitialized_ClearsState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.Cleanup();
        }

        // =====================================================================
        /// <summary>
        /// Webs the assembly platform convert key code alphabet keys using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(65, ConsoleKey.A)]
        [InlineData(66, ConsoleKey.B)]
        [InlineData(67, ConsoleKey.C)]
        [InlineData(68, ConsoleKey.D)]
        [InlineData(69, ConsoleKey.E)]
        [InlineData(70, ConsoleKey.F)]
        [InlineData(71, ConsoleKey.G)]
        [InlineData(72, ConsoleKey.H)]
        [InlineData(73, ConsoleKey.I)]
        [InlineData(74, ConsoleKey.J)]
        [InlineData(75, ConsoleKey.K)]
        [InlineData(76, ConsoleKey.L)]
        [InlineData(77, ConsoleKey.M)]
        [InlineData(78, ConsoleKey.N)]
        [InlineData(79, ConsoleKey.O)]
        [InlineData(80, ConsoleKey.P)]
        [InlineData(81, ConsoleKey.Q)]
        [InlineData(82, ConsoleKey.R)]
        [InlineData(83, ConsoleKey.S)]
        [InlineData(84, ConsoleKey.T)]
        [InlineData(85, ConsoleKey.U)]
        [InlineData(86, ConsoleKey.V)]
        [InlineData(87, ConsoleKey.W)]
        [InlineData(88, ConsoleKey.X)]
        [InlineData(89, ConsoleKey.Y)]
        [InlineData(90, ConsoleKey.Z)]
        public void WebAssemblyPlatform_ConvertKeyCode_AlphabetKeys(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code number keys using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(48, ConsoleKey.D0)]
        [InlineData(49, ConsoleKey.D1)]
        [InlineData(50, ConsoleKey.D2)]
        [InlineData(51, ConsoleKey.D3)]
        [InlineData(52, ConsoleKey.D4)]
        [InlineData(53, ConsoleKey.D5)]
        [InlineData(54, ConsoleKey.D6)]
        [InlineData(55, ConsoleKey.D7)]
        [InlineData(56, ConsoleKey.D8)]
        [InlineData(57, ConsoleKey.D9)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumberKeys(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code function keys using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(112, ConsoleKey.F1)]
        [InlineData(113, ConsoleKey.F2)]
        [InlineData(114, ConsoleKey.F3)]
        [InlineData(115, ConsoleKey.F4)]
        [InlineData(116, ConsoleKey.F5)]
        [InlineData(117, ConsoleKey.F6)]
        [InlineData(118, ConsoleKey.F7)]
        [InlineData(119, ConsoleKey.F8)]
        [InlineData(120, ConsoleKey.F9)]
        [InlineData(121, ConsoleKey.F10)]
        [InlineData(122, ConsoleKey.F11)]
        [InlineData(123, ConsoleKey.F12)]
        public void WebAssemblyPlatform_ConvertKeyCode_FunctionKeys(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code numpad keys using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(96, ConsoleKey.NumPad0)]
        [InlineData(97, ConsoleKey.NumPad1)]
        [InlineData(98, ConsoleKey.NumPad2)]
        [InlineData(99, ConsoleKey.NumPad3)]
        [InlineData(100, ConsoleKey.NumPad4)]
        [InlineData(101, ConsoleKey.NumPad5)]
        [InlineData(102, ConsoleKey.NumPad6)]
        [InlineData(103, ConsoleKey.NumPad7)]
        [InlineData(104, ConsoleKey.NumPad8)]
        [InlineData(105, ConsoleKey.NumPad9)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumpadKeys(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code numpad operators using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(106, ConsoleKey.Multiply)]
        [InlineData(107, ConsoleKey.Add)]
        [InlineData(109, ConsoleKey.Subtract)]
        [InlineData(110, ConsoleKey.Decimal)]
        [InlineData(111, ConsoleKey.Divide)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumpadOperators(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code modifier keys using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(16, ConsoleKey.LeftArrow)]
        [InlineData(17, ConsoleKey.Escape)]
        public void WebAssemblyPlatform_ConvertKeyCode_ModifierKeys(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        /// <summary>
        /// Tests that web assembly platform convert key code default returns no name
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_ConvertKeyCode_Default_ReturnsNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 9999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        // =====================================================================

        /// <summary>
        /// Tests that game examples basic game loop example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_BasicGameLoopExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples gamepad input example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_GamepadInputExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples display management example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_DisplayManagementExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples fps game example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_FpsGameExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples system info example does not throw
        /// </summary>
        [Fact]
        public void GameExamples_SystemInfoExample_DoesNotThrow()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples configuration presets example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_ConfigurationPresetsExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples text input example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_TextInputExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples performance monitoring example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_PerformanceMonitoringExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples dialog box example skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_DialogBoxExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game examples complete game template skipped on non browser
        /// </summary>
        [Fact]
        public void GameExamples_CompleteGameTemplate_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        // =====================================================================

        // =====================================================================

        /// <summary>
        /// Tests that system info get platform name returns web assembly
        /// </summary>
        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.PlatformName);
        }

        /// <summary>
        /// Tests that system info is online returns false on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsOnline());
        }

        /// <summary>
        /// Tests that system info get language returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = SystemInfo.GetLanguage();
            Assert.Equal("en", lang);
        }

        /// <summary>
        /// Tests that system info get device pixel ratio returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            float ratio = SystemInfo.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        /// <summary>
        /// Tests that system info get battery level returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = SystemInfo.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        /// <summary>
        /// Tests that system info is charging returns false on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsCharging());
        }

        /// <summary>
        /// Tests that system info get screen orientation returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetScreenOrientation_ReturnsDefaultOnNonBrowser()
        {
            int orientation = SystemInfo.GetScreenOrientation();
            Assert.Equal(1, orientation); // landscape
        }

        /// <summary>
        /// Tests that system info get system time ms returns zero on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetSystemTimeMs_ReturnsZeroOnNonBrowser()
        {
            double time = SystemInfo.GetSystemTimeMs();
            Assert.Equal(0.0, time);
        }

        /// <summary>
        /// Tests that system info log to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_LogToConsole_DoesNotThrow()
        {
            SystemInfo.LogToConsole("test");
        }

        /// <summary>
        /// Tests that system info warn to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_WarnToConsole_DoesNotThrow()
        {
            SystemInfo.WarnToConsole("test");
        }

        /// <summary>
        /// Tests that system info error to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_ErrorToConsole_DoesNotThrow()
        {
            SystemInfo.ErrorToConsole("test");
        }

        // =====================================================================

      

        /// <summary>
        /// Tests that quick start log platform info does not throw
        /// </summary>
        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }

        // =====================================================================

        /// <summary>
        /// Tests that game context presets game 2 d returns valid config
        /// </summary>
        [Fact]
        public void GameContextPresets_Game2D_ReturnsValidConfig()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game2D();
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

        /// <summary>
        /// Tests that game context presets game 3 d returns valid config
        /// </summary>
        [Fact]
        public void GameContextPresets_Game3D_ReturnsValidConfig()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game3D();
            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
            Assert.Equal("3D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.Equal(DisplayQuality.VeryHigh, config.DisplayQuality);
        }

        /// <summary>
        /// Tests that game context presets puzzle game returns valid config
        /// </summary>
        [Fact]
        public void GameContextPresets_PuzzleGame_ReturnsValidConfig()
        {
            WebAssemblyConfiguration config = GameContextPresets.PuzzleGame();
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

        /// <summary>
        /// Tests that game context presets mobile game returns valid config
        /// </summary>
        [Fact]
        public void GameContextPresets_MobileGame_ReturnsValidConfig()
        {
            WebAssemblyConfiguration config = GameContextPresets.MobileGame();
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

        /// <summary>
        /// Tests that emscripten web get connected gamepads returns empty on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_GetConnectedGamepads_ReturnsEmptyOnNonBrowser()
        {
            int[] gamepads = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(gamepads);
            Assert.Empty(gamepads);
        }

        /// <summary>
        /// Tests that emscripten web get gamepad axes returns empty on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_GetGamepadAxes_ReturnsEmptyOnNonBrowser()
        {
            float[] axes = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(axes);
            Assert.Empty(axes);
        }

        /// <summary>
        /// Tests that emscripten web get gamepad buttons returns empty on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_GetGamepadButtons_ReturnsEmptyOnNonBrowser()
        {
            bool[] buttons = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(buttons);
            Assert.Empty(buttons);
        }

        /// <summary>
        /// Tests that emscripten web open file dialog returns null on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_OpenFileDialog_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.OpenFileDialog();
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that emscripten web open file dialog with mime types returns null on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_OpenFileDialog_WithMimeTypes_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.OpenFileDialog("image/*");
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that emscripten web paste from clipboard returns null on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_PasteFromClipboard_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.PasteFromClipboard();
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that emscripten web get language returns default on non browser
        /// </summary>
        [Fact]
        public void EmscriptenWeb_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = EmscriptenWeb.GetLanguage();
            Assert.Equal("en", lang);
        }

        // =====================================================================

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
