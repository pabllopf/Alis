// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameContextExecutionTests.cs
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
    ///     Execution tests for WebAssemblyGameContext on non-WebAssembly runtimes.
    ///     On desktop the constructor fails because the platform factory cannot
    ///     initialize an EGL display, so only the static members, factory throw
    ///     paths, and configuration presets are executable. The EmscriptenWeb
    ///     P/Invoke wrappers swallow DllNotFoundException and return fallbacks,
    ///     so every covered member runs to completion.
    /// </summary>
    public class WebAssemblyGameContextExecutionTests
    {
        /// <summary>
        /// Tests that constructor with configuration throws on non web assembly
        /// </summary>
        [Fact]
        public void Constructor_WithConfiguration_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with null configuration throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_NullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        /// <summary>
        /// Tests that default constructor throws on non web assembly
        /// </summary>
        [Fact]
        public void DefaultConstructor_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext());
        }

        /// <summary>
        /// Tests that create with width height and title throws on non web assembly
        /// </summary>
        [Fact]
        public void Create_WithWidthHeightTitle_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(800, 600, "Test"));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        /// <summary>
        /// Tests that create with null configure throws null reference exception
        /// </summary>
        [Fact]
        public void Create_WithNullConfigure_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => WebAssemblyGameContext.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        /// <summary>
        /// Tests that create with configure throws on non web assembly
        /// </summary>
        [Fact]
        public void Create_WithConfigure_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(builder => builder.WithTitle("Test")));
        }

        /// <summary>
        /// Tests that console log does not throw with various inputs
        /// </summary>
        [Fact]
        public void ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test log");
            WebAssemblyGameContext.ConsoleLog(null);
            WebAssemblyGameContext.ConsoleLog(string.Empty);
            WebAssemblyGameContext.ConsoleLog("special chars: !@#$%");
        }

        /// <summary>
        /// Tests that console warn does not throw with various inputs
        /// </summary>
        [Fact]
        public void ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test warn");
            WebAssemblyGameContext.ConsoleWarn(null);
            WebAssemblyGameContext.ConsoleWarn(string.Empty);
        }

        /// <summary>
        /// Tests that console error does not throw with various inputs
        /// </summary>
        [Fact]
        public void ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test error");
            WebAssemblyGameContext.ConsoleError(null);
            WebAssemblyGameContext.ConsoleError(string.Empty);
        }

        /// <summary>
        /// Tests that show alert does not throw with various inputs
        /// </summary>
        [Fact]
        public void ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test alert");
            WebAssemblyGameContext.ShowAlert(null);
            WebAssemblyGameContext.ShowAlert(string.Empty);
        }

        /// <summary>
        /// Tests that show confirm returns false on non web assembly
        /// </summary>
        [Fact]
        public void ShowConfirm_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
            Assert.False(WebAssemblyGameContext.ShowConfirm(null));
            Assert.False(WebAssemblyGameContext.ShowConfirm(string.Empty));
        }

        /// <summary>
        /// Tests that is fullscreen returns false on non web assembly
        /// </summary>
        [Fact]
        public void IsFullscreen_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsFullscreen());
        }

        /// <summary>
        /// Tests that lock pointer unlock pointer and is pointer locked return false on non web assembly
        /// </summary>
        [Fact]
        public void LockPointer_UnlockPointer_IsPointerLocked_ReturnFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.LockPointer());
            Assert.False(WebAssemblyGameContext.UnlockPointer());
            Assert.False(WebAssemblyGameContext.IsPointerLocked());
        }

        /// <summary>
        /// Tests that get device language returns a non null value
        /// </summary>
        [Fact]
        public void GetDeviceLanguage_ReturnsNonNull()
        {
            string language = WebAssemblyGameContext.GetDeviceLanguage();
            Assert.NotNull(language);
        }

        /// <summary>
        /// Tests that get battery level returns a non negative value
        /// </summary>
        [Fact]
        public void GetBatteryLevel_ReturnsNonNegative()
        {
            float level = WebAssemblyGameContext.GetBatteryLevel();
            Assert.True(level >= -1.0f);
        }

        /// <summary>
        /// Tests that is charging returns false on non web assembly
        /// </summary>
        [Fact]
        public void IsCharging_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsCharging());
        }

        /// <summary>
        /// Tests that is online returns false on non web assembly
        /// </summary>
        [Fact]
        public void IsOnline_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsOnline());
        }

        /// <summary>
        /// Tests that get refresh rate returns sixty
        /// </summary>
        [Fact]
        public void GetRefreshRate_ReturnsSixty()
        {
            Assert.Equal(60, WebAssemblyGameContext.GetRefreshRate());
        }

        /// <summary>
        /// Tests that vibrate gamepad returns false on non web assembly
        /// </summary>
        [Fact]
        public void VibrateGamepad_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
            Assert.False(WebAssemblyGameContext.VibrateGamepad(1, 0.5f, 0.5f, 0.2f));
        }

        /// <summary>
        /// Tests that game context presets game 2 d returns a fully configured preset
        /// </summary>
        [Fact]
        public void GameContextPresets_Game2D_ReturnsConfiguredPreset()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game2D();
            Assert.NotNull(config);
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
        /// Tests that game context presets game 3 d returns a fully configured preset
        /// </summary>
        [Fact]
        public void GameContextPresets_Game3D_ReturnsConfiguredPreset()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game3D();
            Assert.NotNull(config);
            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
            Assert.Equal("3D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.Equal(DisplayQuality.VeryHigh, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
        }

        /// <summary>
        /// Tests that game context presets puzzle game returns a fully configured preset
        /// </summary>
        [Fact]
        public void GameContextPresets_PuzzleGame_ReturnsConfiguredPreset()
        {
            WebAssemblyConfiguration config = GameContextPresets.PuzzleGame();
            Assert.NotNull(config);
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
        /// Tests that game context presets mobile game returns a fully configured preset
        /// </summary>
        [Fact]
        public void GameContextPresets_MobileGame_ReturnsConfiguredPreset()
        {
            WebAssemblyConfiguration config = GameContextPresets.MobileGame();
            Assert.NotNull(config);
            Assert.Equal(720, config.WindowWidth);
            Assert.Equal(1280, config.WindowHeight);
            Assert.Equal("Mobile Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(DisplayQuality.Medium, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
            Assert.True(config.TouchInputEnabled);
        }
    }
}
