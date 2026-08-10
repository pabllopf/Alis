// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfigurationRemainingCoverageTests.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     The web assembly configuration remaining coverage tests class
    /// </summary>
    public class WebAssemblyConfigurationRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default configuration has expected values
        /// </summary>
        [Fact]
        public void DefaultConfiguration_HasExpectedValues()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();

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
        }

        /// <summary>
        ///     Tests that properties round trip
        /// </summary>
        [Fact]
        public void Properties_RoundTrip()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                WindowWidth = 1024,
                WindowHeight = 768,
                WindowTitle = "Test",
                IconPath = "icon.png",
                VSync = false,
                TargetFrameRate = 120,
                MultisamplingEnabled = false,
                MultisampleCount = 8,
                Fullscreen = true,
                PointerLock = true,
                DisplayQuality = DisplayQuality.Low,
                GamepadInputEnabled = false,
                KeyboardInputEnabled = false,
                MouseInputEnabled = false,
                TouchInputEnabled = false,
                GamepadDeadzone = 0.5f,
                TriggerDeadzone = 0.2f,
                DebugMode = true
            };

            Assert.Equal(1024, config.WindowWidth);
            Assert.Equal(768, config.WindowHeight);
            Assert.Equal("Test", config.WindowTitle);
            Assert.Equal("icon.png", config.IconPath);
            Assert.False(config.VSync);
            Assert.Equal(120, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.True(config.Fullscreen);
            Assert.True(config.PointerLock);
            Assert.Equal(DisplayQuality.Low, config.DisplayQuality);
            Assert.False(config.GamepadInputEnabled);
            Assert.False(config.KeyboardInputEnabled);
            Assert.False(config.MouseInputEnabled);
            Assert.False(config.TouchInputEnabled);
            Assert.Equal(0.5f, config.GamepadDeadzone, 5);
            Assert.Equal(0.2f, config.TriggerDeadzone, 5);
            Assert.True(config.DebugMode);
        }

        /// <summary>
        ///     Tests that builder with size builds configuration
        /// </summary>
        [Fact]
        public void Builder_WithSize_BuildsConfiguration()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(1920, 1080)
                .WithTitle("Game")
                .WithIconPath("icon.ico")
                .WithVSync(false)
                .WithTargetFrameRate(144)
                .WithMultisampling(false)
                .WithMultisampleCount(2)
                .WithFullscreen(true)
                .WithPointerLock(true)
                .WithDisplayQuality(DisplayQuality.Ultra)
                .WithGamepadInput(false)
                .WithKeyboardInput(false)
                .WithMouseInput(false)
                .WithTouchInput(false)
                .WithGamepadDeadzone(0.3f)
                .WithTriggerDeadzone(0.4f)
                .WithDebugMode(true)
                .Build();

            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
            Assert.Equal("Game", config.WindowTitle);
            Assert.Equal("icon.ico", config.IconPath);
            Assert.False(config.VSync);
            Assert.Equal(144, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(2, config.MultisampleCount);
            Assert.True(config.Fullscreen);
            Assert.True(config.PointerLock);
            Assert.Equal(DisplayQuality.Ultra, config.DisplayQuality);
            Assert.False(config.GamepadInputEnabled);
            Assert.False(config.KeyboardInputEnabled);
            Assert.False(config.MouseInputEnabled);
            Assert.False(config.TouchInputEnabled);
            Assert.Equal(0.3f, config.GamepadDeadzone, 5);
            Assert.Equal(0.4f, config.TriggerDeadzone, 5);
            Assert.True(config.DebugMode);
        }

        /// <summary>
        ///     Tests that builder with invalid multisample count throws
        /// </summary>
        [Fact]
        public void Builder_WithInvalidMultisampleCount_Throws()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();

            Assert.Throws<System.ArgumentException>(() => builder.WithMultisampleCount(3));
        }

        /// <summary>
        ///     Tests that builder with valid multisample counts passes
        /// </summary>
        [Fact]
        public void Builder_WithValidMultisampleCounts_Passes()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();

            Assert.NotNull(builder.WithMultisampleCount(2));
            Assert.NotNull(builder.WithMultisampleCount(4));
            Assert.NotNull(builder.WithMultisampleCount(8));
            Assert.NotNull(builder.WithMultisampleCount(16));
        }
    }
}
