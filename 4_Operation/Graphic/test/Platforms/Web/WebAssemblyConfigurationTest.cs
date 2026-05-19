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
        // WebAssemblyConfiguration - Default Values
        // =====================================================================

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
        // WebAssemblyConfigurationBuilder
        // =====================================================================

        [Fact]
        public void ConfigBuilder_WithSize_SetsWidthAndHeight()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(1920, 1080)
                .Build();

            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_SetsTitle()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle("My Game")
                .Build();

            Assert.Equal("My Game", config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithIconPath_SetsIconPath()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithIconPath("/assets/icon.png")
                .Build();

            Assert.Equal("/assets/icon.png", config.IconPath);
        }

        [Fact]
        public void ConfigBuilder_WithVSync_SetsVSync()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithVSync(false)
                .Build();

            Assert.False(config.VSync);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_ValidValue_SetsRate()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithFullscreen(true)
                .Build();

            Assert.True(config.Fullscreen);
        }

        [Fact]
        public void ConfigBuilder_WithPointerLock_SetsPointerLock()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithPointerLock(true)
                .Build();

            Assert.True(config.PointerLock);
        }

        [Fact]
        public void ConfigBuilder_WithDisplayQuality_SetsQuality()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithDisplayQuality(DisplayQuality.Ultra)
                .Build();

            Assert.Equal(DisplayQuality.Ultra, config.DisplayQuality);
        }

        [Fact]
        public void ConfigBuilder_WithGamepadInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithGamepadInput(false)
                .Build();

            Assert.False(config.GamepadInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithKeyboardInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithKeyboardInput(false)
                .Build();

            Assert.False(config.KeyboardInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithMouseInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithMouseInput(false)
                .Build();

            Assert.False(config.MouseInputEnabled);
        }

        [Fact]
        public void ConfigBuilder_WithTouchInput_SetsEnabled()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
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
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithDebugMode(true)
                .Build();

            Assert.True(config.DebugMode);
        }

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

        [Fact]
        public void ConfigBuilder_Build_MultipleTimes_ReturnsSameInstance()
        {
            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder()
                .WithSize(800, 600);

            WebAssemblyConfiguration config1 = builder.Build();
            WebAssemblyConfiguration config2 = builder.Build();

            Assert.Same(config1, config2);
        }

        [Fact]
        public void ConfigBuilder_WithSize_NegativeValues_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(-100, -200)
                .Build();

            Assert.Equal(-100, config.WindowWidth);
            Assert.Equal(-200, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithSize_ZeroValues_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(0, 0)
                .Build();

            Assert.Equal(0, config.WindowWidth);
            Assert.Equal(0, config.WindowHeight);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_EmptyString_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle("")
                .Build();

            Assert.Equal("", config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithTitle_Null_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTitle(null)
                .Build();

            Assert.Null(config.WindowTitle);
        }

        [Fact]
        public void ConfigBuilder_WithIconPath_Null_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithIconPath(null)
                .Build();

            Assert.Null(config.IconPath);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_One_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(1)
                .Build();

            Assert.Equal(1, config.TargetFrameRate);
        }

        [Fact]
        public void ConfigBuilder_WithTargetFrameRate_MaxInt_Accepts()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithTargetFrameRate(int.MaxValue)
                .Build();

            Assert.Equal(int.MaxValue, config.TargetFrameRate);
        }

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
        // WebAssemblyPlatformFactory
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatformFactory_CreateDefault_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformFactory.CreateDefault();
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
        public void WebAssemblyPlatformFactory_Create_WithAction_NullAction_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                WebAssemblyPlatformFactory.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        // =====================================================================
        // GameContextPresets
        // =====================================================================

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
