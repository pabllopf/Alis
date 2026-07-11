using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblyFinalTests
    {
        [Fact]
        public void WebAssemblyGameContext_NullConfig_ThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        [Fact]
        public void WebAssemblyGameContext_WithConfig_Throws()
        {
            Assert.ThrowsAny<Exception>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
        }

        [Fact]
        public void GameContextPresets_Game2D_Works()
        {
            var c = GameContextPresets.Game2D();
            Assert.Equal(1280, c.WindowWidth);
            Assert.Equal(720, c.WindowHeight);
            Assert.Equal("2D Game", c.WindowTitle);
        }

        [Fact]
        public void GameContextPresets_Game3D_Works()
        {
            var c = GameContextPresets.Game3D();
            Assert.Equal(1920, c.WindowWidth);
            Assert.Equal(1080, c.WindowHeight);
        }

        [Fact]
        public void GameContextPresets_PuzzleGame_Works()
        {
            var c = GameContextPresets.PuzzleGame();
            Assert.Equal(800, c.WindowWidth);
            Assert.Equal(600, c.WindowHeight);
        }

        [Fact]
        public void GameContextPresets_MobileGame_Works()
        {
            var c = GameContextPresets.MobileGame();
            Assert.Equal(720, c.WindowWidth);
            Assert.Equal(1280, c.WindowHeight);
            Assert.True(c.TouchInputEnabled);
        }

        [Fact]
        public void ConsoleLog_DoesNotThrow() => WebAssemblyGameContext.ConsoleLog("test");
        [Fact]
        public void ConsoleWarn_DoesNotThrow() => WebAssemblyGameContext.ConsoleWarn("test");
        [Fact]
        public void ConsoleError_DoesNotThrow() => WebAssemblyGameContext.ConsoleError("test");
        [Fact]
        public void ShowAlert_DoesNotThrow() => WebAssemblyGameContext.ShowAlert("test");
        [Fact]
        public void ShowConfirm_ReturnsFalse() => Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
        [Fact]
        public void IsFullscreen_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsFullscreen());
        [Fact]
        public void VibrateGamepad_ReturnsFalse() => Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
        [Fact]
        public void LockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.LockPointer());
        [Fact]
        public void UnlockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.UnlockPointer());
        [Fact]
        public void IsPointerLocked_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsPointerLocked());
        [Fact]
        public void GetDeviceLanguage_ReturnsString() => Assert.NotNull(WebAssemblyGameContext.GetDeviceLanguage());
        [Fact]
        public void GetBatteryLevel_ReturnsDefault() => WebAssemblyGameContext.GetBatteryLevel();
        [Fact]
        public void IsCharging_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsCharging());
        [Fact]
        public void IsOnline_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsOnline());
        [Fact]
        public void GetRefreshRate_ReturnsDefault() => Assert.True(WebAssemblyGameContext.GetRefreshRate() >= 0);

        // WebAssemblyGameExamples - all example methods throw on non-WASM
        [Fact] public void Example_BasicGameLoop() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        [Fact] public void Example_GamepadInput() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.GamepadInputExample());
        [Fact] public void Example_DisplayManagement() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DisplayManagementExample());
        [Fact] public void Example_FpsGame() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.FpsGameExample());
        [Fact] public void Example_SystemInfo() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.SystemInfoExample());
        [Fact] public void Example_ConfigurationPresets() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        [Fact] public void Example_TextInput() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.TextInputExample());
        [Fact] public void Example_PerformanceMonitoring() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        [Fact] public void Example_DialogBox() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DialogBoxExample());
        [Fact] public void Example_CompleteGameTemplate() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.CompleteGameTemplate());

        // GameDevelopmentUtils
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_Below_Zeroes()
        {
            float x = 0.1f, y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_Above_Scales()
        {
            float x = 0.5f, y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.True(x > 0);
            Assert.True(y > 0);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_Above1_Normalizes()
        {
            float x = 0.8f, y = 0.6f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            double mag = Math.Sqrt(x * x + y * y);
            Assert.True(mag <= 1.0);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_Below1_Keeps()
        {
            float x = 0.3f, y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x);
            Assert.Equal(0.4f, y);
        }

        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(2, "X / Square")]
        [InlineData(3, "Y / Triangle")]
        [InlineData(8, "Back / Select")]
        [InlineData(12, "Guide / Home")]
        [InlineData(99, "Button 99")]
        public void GameDevelopmentUtils_GamepadButtonName(int idx, string expected)
        {
            Assert.Equal(expected, GameDevelopmentUtils.GetGamepadButtonName(idx));
        }

        [Fact]
        public void GameDevelopmentUtils_GetKeyName_ReturnsString()
        {
            Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
        }

        // MultiplatformGameEngine
        [Fact]
        public void MultiplatformGameEngine_Constructor_Throws()
        {
            Assert.ThrowsAny<Exception>(() => new MultiplatformGameEngine(800, 600, "Test"));
        }

        [Fact]
        public void MultiplatformGameEngine_IsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(MultiplatformGameEngine)));
        }

        // InputManager (inner class)
        [Fact]
        public void InputManager_HasMethods()
        {
            Type t = typeof(Alis.Core.Graphic.Platforms.Web.InputManager);
            Assert.NotNull(t.GetMethod("GetMovementInput"));
            Assert.NotNull(t.GetMethod("IsJumpPressed"));
            Assert.NotNull(t.GetMethod("IsAttackPressed"));
            Assert.NotNull(t.GetMethod("GetCameraInput"));
        }

        // DisplayManager (inner class)
        [Fact]
        public void DisplayManager_HasMethods()
        {
            Type t = typeof(Alis.Core.Graphic.Platforms.Web.DisplayManager);
            Assert.NotNull(t.GetMethod("GetWidth"));
            Assert.NotNull(t.GetMethod("GetHeight"));
            Assert.NotNull(t.GetMethod("SetFullscreen"));
            Assert.NotNull(t.GetMethod("ToggleFullscreen"));
            Assert.NotNull(t.GetMethod("SetSize"));
        }

        [Fact]
        public void OptimizationProfile_HasAllValues()
        {
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Default));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Game2D));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Game3D));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.LowEnd));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.HighEnd));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Mobile));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Web));
        }

        // WebAssemblyPlatformIntegration static methods
        [Fact]
        public void GetSupportedPlatforms_ReturnsPlatforms()
        {
            var platforms = WebAssemblyPlatformIntegration.GetSupportedPlatforms();
            Assert.Contains("WebAssembly", platforms);
            Assert.Contains("WASM", platforms);
        }

        [Fact]
        public void GetPlatform_Valid_ReturnsNonNull()
        {
            Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("WebAssembly"));
            Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("Emscripten"));
        }

        [Fact]
        public void GetPlatform_Invalid_Throws()
        {
            Assert.Throws<PlatformNotSupportedException>(() => WebAssemblyPlatformIntegration.GetPlatform("Invalid"));
        }

        [Fact]
        public void RegisterPlatform_ThenGet_Works()
        {
            WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(WebAssemblyPlatform));
            Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("Custom"));
        }

        [Fact]
        public void CreateOptimizedPlatform_Default_ReturnsNonNull()
        {
            var platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
        }

        [Fact]
        public void CreateOptimizedPlatform_Game2D_ReturnsNonNull()
        {
            Assert.NotNull(WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        }

        [Fact]
        public void CreateOptimizedPlatform_HighEnd_ReturnsNonNull()
        {
            Assert.NotNull(WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        }

        [Fact]
        public void CreateOptimizedPlatform_Mobile_ReturnsNonNull()
        {
            Assert.NotNull(WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
        }

        [Fact]
        public void CreateGameContext_Throws()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateGameContext("Test"));
        }

        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }

        [Fact]
        public void QuickStart_RunMinimalGame_Throws()
        {
            Assert.ThrowsAny<Exception>(() => QuickStart.RunMinimalGame((w, h) => { }));
        }
    }
}
