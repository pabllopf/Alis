using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblySafeFinalTests
    {
        [Fact]
        public void GameContextPresets_Game2D_Works()
        {
            var c = GameContextPresets.Game2D();
            Assert.Equal(1280, c.WindowWidth);
            Assert.Equal("2D Game", c.WindowTitle);
        }

        [Fact]
        public void GameContextPresets_Game3D_Works()
        {
            var c = GameContextPresets.Game3D();
            Assert.Equal(1920, c.WindowWidth);
            Assert.Equal("3D Game", c.WindowTitle);
        }

        [Fact]
        public void GameContextPresets_PuzzleGame_Works()
        {
            var c = GameContextPresets.PuzzleGame();
            Assert.Equal(800, c.WindowWidth);
        }

        [Fact]
        public void GameContextPresets_MobileGame_Works()
        {
            var c = GameContextPresets.MobileGame();
            Assert.Equal(720, c.WindowWidth);
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
        [Fact] public void ShowConfirm_ReturnsFalse() => Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
        [Fact] public void IsFullscreen_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsFullscreen());
        [Fact] public void VibrateGamepad_ReturnsFalse() => Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
        [Fact] public void LockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.LockPointer());
        [Fact] public void UnlockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.UnlockPointer());
        [Fact] public void IsPointerLocked_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsPointerLocked());
        [Fact] public void GetDeviceLanguage_NotNull() => Assert.NotNull(WebAssemblyGameContext.GetDeviceLanguage());
        [Fact] public void GetBatteryLevel_DoesNotThrow() => WebAssemblyGameContext.GetBatteryLevel();
        [Fact] public void IsCharging_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsCharging());
        [Fact] public void IsOnline_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsOnline());
        [Fact] public void GetRefreshRate_NonNegative() => Assert.True(WebAssemblyGameContext.GetRefreshRate() >= 0);

        // GameDevelopmentUtils
        [Fact]
        public void ApplyDeadzone_Below_Zeroes()
        {
            float x = 0.1f, y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x); Assert.Equal(0, y);
        }

        [Fact]
        public void ApplyDeadzone_Above_Scales()
        {
            float x = 0.5f, y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.True(x > 0);
        }

        [Fact]
        public void NormalizeInput_Above1_Normalizes()
        {
            float x = 0.8f, y = 0.6f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            double mag = Math.Sqrt(x * x + y * y);
            Assert.True(mag <= 1.0);
        }

        [Fact]
        public void NormalizeInput_Below1_Keeps()
        {
            float x = 0.3f, y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x); Assert.Equal(0.4f, y);
        }

        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(12, "Guide / Home")]
        [InlineData(99, "Button 99")]
        public void GetGamepadButtonName_Returns(int idx, string expected) => Assert.Equal(expected, GameDevelopmentUtils.GetGamepadButtonName(idx));

        [Fact] public void GetKeyName_ReturnsString() => Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.A));

        // WebAssemblyPlatformIntegration
        [Fact]
        public void GetSupportedPlatforms_Contains() { var p = WebAssemblyPlatformIntegration.GetSupportedPlatforms(); Assert.Contains("WebAssembly", p); Assert.Contains("WASM", p); }
        [Fact] public void GetPlatform_Valid_Returns() { Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("WebAssembly")); }
        [Fact] public void GetPlatform_Invalid_Throws() => Assert.Throws<PlatformNotSupportedException>(() => WebAssemblyPlatformIntegration.GetPlatform("Invalid"));
        [Fact] public void RegisterPlatform_Works() { WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(WebAssemblyPlatform)); Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("Custom")); }
        [Fact] public void CreateOptimizedPlatform_Default_Returns() => Assert.NotNull(WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default));
        [Fact] public void CreateOptimizedPlatform_Game2D_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        [Fact] public void CreateOptimizedPlatform_HighEnd_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        [Fact] public void CreateOptimizedPlatform_Mobile_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));

        [Fact]
        public void OptimizationProfile_AllDefined()
        {
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Default));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Game2D));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Game3D));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.LowEnd));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.HighEnd));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Mobile));
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), OptimizationProfile.Web));
        }

        [Fact] public void QuickStart_LogPlatformInfo_DoesNotThrow() => QuickStart.LogPlatformInfo();
        [Fact] public void QuickStart_RunMinimalGame_Throws() => Assert.ThrowsAny<Exception>(() => QuickStart.RunMinimalGame((w, h) => { }));
        [Fact] public void CreateGameContext_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateGameContext("Test"));

        // WebAssemblyGameExamples - example methods
        [Fact] public void Example_BasicGameLoop_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        [Fact] public void Example_GamepadInput_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.GamepadInputExample());
        [Fact] public void Example_DisplayManagement_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DisplayManagementExample());
        [Fact] public void Example_FpsGame_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.FpsGameExample());
        [Fact] public void Example_SystemInfo_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.SystemInfoExample());
        [Fact] public void Example_ConfigurationPresets_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        [Fact] public void Example_TextInput_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.TextInputExample());
        [Fact] public void Example_PerformanceMonitoring_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        [Fact] public void Example_DialogBox_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DialogBoxExample());
        [Fact] public void Example_CompleteGameTemplate_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.CompleteGameTemplate());
    }
}
