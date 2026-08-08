using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly safe final tests class
    /// </summary>
    public class WebAssemblySafeFinalTests
    {
        /// <summary>
        /// Tests that game context presets game 2 d works
        /// </summary>
        [WebOnly]
        public void GameContextPresets_Game2D_Works()
        {
            var c = GameContextPresets.Game2D();
            Assert.Equal(1280, c.WindowWidth);
            Assert.Equal("2D Game", c.WindowTitle);
        }

        /// <summary>
        /// Tests that game context presets game 3 d works
        /// </summary>
        [WebOnly]
        public void GameContextPresets_Game3D_Works()
        {
            var c = GameContextPresets.Game3D();
            Assert.Equal(1920, c.WindowWidth);
            Assert.Equal("3D Game", c.WindowTitle);
        }

        /// <summary>
        /// Tests that game context presets puzzle game works
        /// </summary>
        [WebOnly]
        public void GameContextPresets_PuzzleGame_Works()
        {
            var c = GameContextPresets.PuzzleGame();
            Assert.Equal(800, c.WindowWidth);
        }

        /// <summary>
        /// Tests that game context presets mobile game works
        /// </summary>
        [WebOnly]
        public void GameContextPresets_MobileGame_Works()
        {
            var c = GameContextPresets.MobileGame();
            Assert.Equal(720, c.WindowWidth);
            Assert.True(c.TouchInputEnabled);
        }

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleLog_DoesNotThrow() => WebAssemblyGameContext.ConsoleLog("test");
        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleWarn_DoesNotThrow() => WebAssemblyGameContext.ConsoleWarn("test");
        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnly]
        public void ConsoleError_DoesNotThrow() => WebAssemblyGameContext.ConsoleError("test");
        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnly]
        public void ShowAlert_DoesNotThrow() => WebAssemblyGameContext.ShowAlert("test");
        /// <summary>
        /// Tests that show confirm returns false
        /// </summary>
        [WebOnly] public void ShowConfirm_ReturnsFalse() => Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
        /// <summary>
        /// Tests that is fullscreen returns false
        /// </summary>
        [WebOnly] public void IsFullscreen_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsFullscreen());
        /// <summary>
        /// Tests that vibrate gamepad returns false
        /// </summary>
        [WebOnly] public void VibrateGamepad_ReturnsFalse() => Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
        /// <summary>
        /// Tests that lock pointer returns false
        /// </summary>
        [WebOnly] public void LockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.LockPointer());
        /// <summary>
        /// Tests that unlock pointer returns false
        /// </summary>
        [WebOnly] public void UnlockPointer_ReturnsFalse() => Assert.False(WebAssemblyGameContext.UnlockPointer());
        /// <summary>
        /// Tests that is pointer locked returns false
        /// </summary>
        [WebOnly] public void IsPointerLocked_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsPointerLocked());
        /// <summary>
        /// Tests that get device language not null
        /// </summary>
        [WebOnly] public void GetDeviceLanguage_NotNull() => Assert.NotNull(WebAssemblyGameContext.GetDeviceLanguage());
        /// <summary>
        /// Tests that get battery level does not throw
        /// </summary>
        [WebOnly] public void GetBatteryLevel_DoesNotThrow() => WebAssemblyGameContext.GetBatteryLevel();
        /// <summary>
        /// Tests that is charging returns false
        /// </summary>
        [WebOnly] public void IsCharging_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsCharging());
        /// <summary>
        /// Tests that is online returns false
        /// </summary>
        [WebOnly] public void IsOnline_ReturnsFalse() => Assert.False(WebAssemblyGameContext.IsOnline());
        /// <summary>
        /// Tests that get refresh rate non negative
        /// </summary>
        [WebOnly] public void GetRefreshRate_NonNegative() => Assert.True(WebAssemblyGameContext.GetRefreshRate() >= 0);

        // GameDevelopmentUtils
        /// <summary>
        /// Tests that apply deadzone below zeroes
        /// </summary>
        [WebOnly]
        public void ApplyDeadzone_Below_Zeroes()
        {
            float x = 0.1f, y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x); Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that apply deadzone above scales
        /// </summary>
        [WebOnly]
        public void ApplyDeadzone_Above_Scales()
        {
            float x = 0.5f, y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.True(x > 0);
        }

        /// <summary>
        /// Tests that normalize input above 1 normalizes
        /// </summary>
        [WebOnly]
        public void NormalizeInput_Above1_Normalizes()
        {
            float x = 0.8f, y = 0.6f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            double mag = Math.Sqrt(x * x + y * y);
            Assert.True(mag <= 1.0);
        }

        /// <summary>
        /// Tests that normalize input below 1 keeps
        /// </summary>
        [WebOnly]
        public void NormalizeInput_Below1_Keeps()
        {
            float x = 0.3f, y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x, 5); Assert.Equal(0.4f, y, 5);
        }

        /// <summary>
        /// Tests that get gamepad button name returns
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(12, "Guide / Home")]
        [InlineData(99, "Button 99")]
        public void GetGamepadButtonName_Returns(int idx, string expected) => Assert.Equal(expected, GameDevelopmentUtils.GetGamepadButtonName(idx));

        /// <summary>
        /// Tests that get key name returns string
        /// </summary>
        [WebOnly] public void GetKeyName_ReturnsString() => Assert.NotNull(GameDevelopmentUtils.GetKeyName(ConsoleKey.A));

        // WebAssemblyPlatformIntegration
        /// <summary>
        /// Tests that get supported platforms contains
        /// </summary>
        [WebOnly]
        public void GetSupportedPlatforms_Contains() { var p = WebAssemblyPlatformIntegration.GetSupportedPlatforms(); Assert.Contains("WebAssembly", p); Assert.Contains("WASM", p); }
        /// <summary>
        /// Tests that get platform valid returns
        /// </summary>
        [WebOnly] public void GetPlatform_Valid_Returns() { Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("WebAssembly")); }
        /// <summary>
        /// Tests that get platform invalid throws
        /// </summary>
        [WebOnly] public void GetPlatform_Invalid_Throws() => Assert.Throws<PlatformNotSupportedException>(() => WebAssemblyPlatformIntegration.GetPlatform("Invalid"));
        /// <summary>
        /// Tests that register platform works
        /// </summary>
        [WebOnly] public void RegisterPlatform_Works() { WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(WebAssemblyPlatform)); Assert.NotNull(WebAssemblyPlatformIntegration.GetPlatform("Custom")); }
        /// <summary>
        /// Tests that create optimized platform default returns
        /// </summary>
        [WebOnly] public void CreateOptimizedPlatform_Default_Returns() => Assert.NotNull(WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default));
        /// <summary>
        /// Tests that create optimized platform game 2 d throws on non wasm
        /// </summary>
        [WebOnly] public void CreateOptimizedPlatform_Game2D_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        /// <summary>
        /// Tests that create optimized platform high end throws on non wasm
        /// </summary>
        [WebOnly] public void CreateOptimizedPlatform_HighEnd_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        /// <summary>
        /// Tests that create optimized platform mobile throws on non wasm
        /// </summary>
        [WebOnly] public void CreateOptimizedPlatform_Mobile_Throws_OnNonWasm() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));

        /// <summary>
        /// Tests that optimization profile all defined
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that quick start log platform info does not throw
        /// </summary>
        [WebOnly] public void QuickStart_LogPlatformInfo_DoesNotThrow() => QuickStart.LogPlatformInfo();
        
        /// <summary>
        /// Tests that create game context throws
        /// </summary>
        [WebOnly] public void CreateGameContext_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyPlatformIntegration.CreateGameContext("Test"));

        // WebAssemblyGameExamples - example methods
        /// <summary>
        /// Tests that example basic game loop throws
        /// </summary>
        [WebOnly] public void Example_BasicGameLoop_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        /// <summary>
        /// Tests that example gamepad input throws
        /// </summary>
        [WebOnly] public void Example_GamepadInput_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.GamepadInputExample());
        /// <summary>
        /// Tests that example display management throws
        /// </summary>
        [WebOnly] public void Example_DisplayManagement_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DisplayManagementExample());
        /// <summary>
        /// Tests that example fps game throws
        /// </summary>
        [WebOnly] public void Example_FpsGame_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.FpsGameExample());
        /// <summary>
        /// Tests that example system info throws
        /// </summary>
        [WebOnly] public void Example_SystemInfo_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.SystemInfoExample());
        /// <summary>
        /// Tests that example configuration presets throws
        /// </summary>
        [WebOnly] public void Example_ConfigurationPresets_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        /// <summary>
        /// Tests that example text input throws
        /// </summary>
        [WebOnly] public void Example_TextInput_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.TextInputExample());
        /// <summary>
        /// Tests that example performance monitoring throws
        /// </summary>
        [WebOnly] public void Example_PerformanceMonitoring_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        /// <summary>
        /// Tests that example dialog box throws
        /// </summary>
        [WebOnly] public void Example_DialogBox_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.DialogBoxExample());
        /// <summary>
        /// Tests that example complete game template throws
        /// </summary>
        [WebOnly] public void Example_CompleteGameTemplate_Throws() => Assert.ThrowsAny<Exception>(() => WebAssemblyGameExamples.CompleteGameTemplate());
    }
}
