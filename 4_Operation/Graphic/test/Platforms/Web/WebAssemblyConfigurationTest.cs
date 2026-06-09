// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfigurationTest.cs
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
    ///     Tests for WebAssemblyConfiguration, WebAssemblyConfigurationBuilder,
    ///     WebAssemblyPlatformFactory, and GameContextPresets.
    /// </summary>
    public class WebAssemblyConfigurationTest
    {
        // =====================================================================

        /// <summary>
        /// Tests that web assembly configuration default values are correct
        /// </summary>
        [Fact]
        public void WebAssemblyConfiguration_DefaultValues_AreCorrect()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();

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

        /// <summary>
        /// Tests that config builder with size sets width and height
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithSize_SetsWidthAndHeight()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(1920, 1080)
                .Build();

            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
        }

        /// <summary>
        /// Tests that config builder with title sets title
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTitle_SetsTitle()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle("My Game")
                .Build();

            Assert.Equal("My Game", config.WindowTitle);
        }

        /// <summary>
        /// Tests that config builder with icon path sets icon path
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithIconPath_SetsIconPath()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithIconPath("/assets/icon.png")
                .Build();

            Assert.Equal("/assets/icon.png", config.IconPath);
        }

        /// <summary>
        /// Tests that config builder with v sync sets v sync
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithVSync_SetsVSync()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithVSync(false)
                .Build();

            Assert.False(config.VSync);
        }

        /// <summary>
        /// Tests that config builder with target frame rate valid value sets rate
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_ValidValue_SetsRate()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(120)
                .Build();

            Assert.Equal(120, config.TargetFrameRate);
        }

        /// <summary>
        /// Tests that config builder with target frame rate zero throws
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_Zero_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTargetFrameRate(0));
        }

        /// <summary>
        /// Tests that config builder with target frame rate negative throws
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_Negative_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTargetFrameRate(-1));
        }

        /// <summary>
        /// Tests that config builder with multisampling sets enabled
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithMultisampling_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithMultisampling(false)
                .Build();

            Assert.False(config.MultisamplingEnabled);
        }

        
        /// <summary>
        /// Configs the builder with multisample count valid value sets count using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        public void ConfigBuilder_WithMultisampleCount_ValidValue_SetsCount(int count)
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithMultisampleCount(count)
                .Build();

            Assert.Equal(count, config.MultisampleCount);
        }

        
        /// <summary>
        /// Configs the builder with multisample count invalid value throws using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(32)]
        public void ConfigBuilder_WithMultisampleCount_InvalidValue_Throws(int count)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithMultisampleCount(count));
        }

        /// <summary>
        /// Tests that config builder with fullscreen sets fullscreen
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithFullscreen_SetsFullscreen()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithFullscreen(true)
                .Build();

            Assert.True(config.Fullscreen);
        }

        /// <summary>
        /// Tests that config builder with pointer lock sets pointer lock
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithPointerLock_SetsPointerLock()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithPointerLock(true)
                .Build();

            Assert.True(config.PointerLock);
        }

        /// <summary>
        /// Tests that config builder with display quality sets quality
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithDisplayQuality_SetsQuality()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithDisplayQuality(DisplayQuality.Ultra)
                .Build();

            Assert.Equal(DisplayQuality.Ultra, config.DisplayQuality);
        }

        /// <summary>
        /// Tests that config builder with gamepad input sets enabled
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithGamepadInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithGamepadInput(false)
                .Build();

            Assert.False(config.GamepadInputEnabled);
        }

        /// <summary>
        /// Tests that config builder with keyboard input sets enabled
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithKeyboardInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithKeyboardInput(false)
                .Build();

            Assert.False(config.KeyboardInputEnabled);
        }

        /// <summary>
        /// Tests that config builder with mouse input sets enabled
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithMouseInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithMouseInput(false)
                .Build();

            Assert.False(config.MouseInputEnabled);
        }

        /// <summary>
        /// Tests that config builder with touch input sets enabled
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTouchInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTouchInput(false)
                .Build();

            Assert.False(config.TouchInputEnabled);
        }

        
        /// <summary>
        /// Configs the builder with gamepad deadzone valid value sets deadzone using the specified deadzone
        /// </summary>
        /// <param name="deadzone">The deadzone</param>
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        public void ConfigBuilder_WithGamepadDeadzone_ValidValue_SetsDeadzone(float deadzone)
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(deadzone)
                .Build();

            Assert.Equal(deadzone, config.GamepadDeadzone);
        }

        
        /// <summary>
        /// Configs the builder with gamepad deadzone invalid value throws using the specified deadzone
        /// </summary>
        /// <param name="deadzone">The deadzone</param>
        [InlineData(-0.1f)]
        [InlineData(1.1f)]
        public void ConfigBuilder_WithGamepadDeadzone_InvalidValue_Throws(float deadzone)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithGamepadDeadzone(deadzone));
        }

        
        /// <summary>
        /// Configs the builder with trigger deadzone valid value sets deadzone using the specified deadzone
        /// </summary>
        /// <param name="deadzone">The deadzone</param>
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        public void ConfigBuilder_WithTriggerDeadzone_ValidValue_SetsDeadzone(float deadzone)
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(deadzone)
                .Build();

            Assert.Equal(deadzone, config.TriggerDeadzone);
        }

        
        /// <summary>
        /// Configs the builder with trigger deadzone invalid value throws using the specified deadzone
        /// </summary>
        /// <param name="deadzone">The deadzone</param>
        [InlineData(-0.01f)]
        [InlineData(1.01f)]
        public void ConfigBuilder_WithTriggerDeadzone_InvalidValue_Throws(float deadzone)
        {
            Assert.Throws<ArgumentException>(() =>
                new WebAssemblyConfigurationBuilder().WithTriggerDeadzone(deadzone));
        }

        /// <summary>
        /// Tests that config builder with debug mode sets debug mode
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithDebugMode_SetsDebugMode()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithDebugMode(true)
                .Build();

            Assert.True(config.DebugMode);
        }

        /// <summary>
        /// Tests that config builder chained methods works
        /// </summary>
        [Fact]
        public void ConfigBuilder_ChainedMethods_Works()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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

        /// <summary>
        /// Tests that config builder build multiple times returns same instance
        /// </summary>
        [Fact]
        public void ConfigBuilder_Build_MultipleTimes_ReturnsSameInstance()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder()
                .WithSize(800, 600);

            WebAssemblyConfiguration config1 = builder.Build();
            WebAssemblyConfiguration config2 = builder.Build();

            Assert.Same(config1, config2);
        }

        /// <summary>
        /// Tests that config builder with size negative values accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithSize_NegativeValues_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(-100, -200)
                .Build();

            Assert.Equal(-100, config.WindowWidth);
            Assert.Equal(-200, config.WindowHeight);
        }

        /// <summary>
        /// Tests that config builder with size zero values accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithSize_ZeroValues_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(0, 0)
                .Build();

            Assert.Equal(0, config.WindowWidth);
            Assert.Equal(0, config.WindowHeight);
        }

        /// <summary>
        /// Tests that config builder with title empty string accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTitle_EmptyString_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle("")
                .Build();

            Assert.Equal("", config.WindowTitle);
        }

        /// <summary>
        /// Tests that config builder with title null accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTitle_Null_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle(null)
                .Build();

            Assert.Null(config.WindowTitle);
        }

        /// <summary>
        /// Tests that config builder with icon path null accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithIconPath_Null_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithIconPath(null)
                .Build();

            Assert.Null(config.IconPath);
        }

        /// <summary>
        /// Tests that config builder with target frame rate one accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_One_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(1)
                .Build();

            Assert.Equal(1, config.TargetFrameRate);
        }

        /// <summary>
        /// Tests that config builder with target frame rate max int accepts
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_MaxInt_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(int.MaxValue)
                .Build();

            Assert.Equal(int.MaxValue, config.TargetFrameRate);
        }

        /// <summary>
        /// Tests that config builder with gamepad deadzone boundary values
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithGamepadDeadzone_BoundaryValues()
        {
            WebAssemblyConfiguration configMin = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(0.0f)
                .Build();
            WebAssemblyConfiguration configMax = new WebAssemblyConfigurationBuilder()
                .WithGamepadDeadzone(1.0f)
                .Build();

            Assert.Equal(0.0f, configMin.GamepadDeadzone);
            Assert.Equal(1.0f, configMax.GamepadDeadzone);
        }

        /// <summary>
        /// Tests that config builder with trigger deadzone boundary values
        /// </summary>
        [Fact]
        public void ConfigBuilder_WithTriggerDeadzone_BoundaryValues()
        {
            WebAssemblyConfiguration configMin = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(0.0f)
                .Build();
            WebAssemblyConfiguration configMax = new WebAssemblyConfigurationBuilder()
                .WithTriggerDeadzone(1.0f)
                .Build();

            Assert.Equal(0.0f, configMin.TriggerDeadzone);
            Assert.Equal(1.0f, configMax.TriggerDeadzone);
        }

        // =====================================================================

        /// <summary>
        /// Tests that web assembly platform factory create default returns instance
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformFactory_CreateDefault_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformFactory.CreateDefault();
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        /// Tests that web assembly platform factory create null config throws
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformFactory_Create_NullConfig_Throws()
        {
            WebAssemblyConfiguration nullConfig = null;
            Assert.Throws<ArgumentNullException>(() =>
                WebAssemblyPlatformFactory.Create(nullConfig));
        }
        

        /// <summary>
        /// Tests that web assembly platform factory create with action null action throws
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformFactory_Create_WithAction_NullAction_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                WebAssemblyPlatformFactory.Create((Action<WebAssemblyConfigurationBuilder>)null));
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
    }
}
