using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyPlatformIntegration, MultiplatformGameEngine,
    ///     InputManager wrapper, DisplayManager wrapper, SystemInfo, QuickStart,
    ///     and OptimizationProfile.
    /// </summary>
    public class WebAssemblyPlatformIntegrationTest
    {
        // =====================================================================
        // WebAssemblyPlatformIntegration
        // =====================================================================

        [Theory]
        [InlineData("WebAssembly")]
        [InlineData("Web")]
        [InlineData("Emscripten")]
        [InlineData("WASM")]
        public void WebAssemblyPlatformIntegration_GetPlatform_ValidName_ReturnsInstance(string name)
        {
            var platform = WebAssemblyPlatformIntegration.GetPlatform(name);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_GetPlatform_InvalidName_Throws()
        {
            Assert.Throws<PlatformNotSupportedException>(() =>
                WebAssemblyPlatformIntegration.GetPlatform("InvalidPlatform"));
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_GetSupportedPlatforms_ReturnsNames()
        {
            string[] platforms = WebAssemblyPlatformIntegration.GetSupportedPlatforms();
            Assert.NotNull(platforms);
            Assert.Contains("WebAssembly", platforms);
            Assert.Contains("Web", platforms);
            Assert.Contains("Emscripten", platforms);
            Assert.Contains("WASM", platforms);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_RegisterPlatform_InvalidType_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(string)));
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Default_ReturnsInstance()
        {
            var platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Game2D()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Game3D()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game3D));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_LowEnd()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.LowEnd));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_HighEnd()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Mobile()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
            }
        }

        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Web_ReturnsInstance()
        {
            var platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Web);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        // =====================================================================
        // OptimizationProfile Enum
        // =====================================================================

        [Theory]
        [InlineData(OptimizationProfile.Default)]
        [InlineData(OptimizationProfile.Game2D)]
        [InlineData(OptimizationProfile.Game3D)]
        [InlineData(OptimizationProfile.LowEnd)]
        [InlineData(OptimizationProfile.HighEnd)]
        [InlineData(OptimizationProfile.Mobile)]
        [InlineData(OptimizationProfile.Web)]
        public void OptimizationProfile_EnumValuesExist(OptimizationProfile profile)
        {
            Assert.True(Enum.IsDefined(typeof(OptimizationProfile), profile));
        }

        // =====================================================================
        // MultiplatformGameEngine
        // =====================================================================

        [Fact]
        public void MultiplatformGameEngine_Constructor_DoesNotThrow()
        {
            var engine = new MultiplatformGameEngine(800, 600, "Test");
            Assert.NotNull(engine.GameContext);
        }

        [Fact]
        public void MultiplatformGameEngine_Dispose_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Dispose();
                engine.Dispose();
            }
        }

        // =====================================================================
        // SystemInfo
        // =====================================================================

        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.GetPlatformName());
        }

        [Fact]
        public void SystemInfo_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsOnline());
        }

        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = SystemInfo.GetLanguage();
            Assert.Equal("en", lang);
        }

        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            float ratio = SystemInfo.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        [Fact]
        public void SystemInfo_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = SystemInfo.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        [Fact]
        public void SystemInfo_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsCharging());
        }

        [Fact]
        public void SystemInfo_GetScreenOrientation_ReturnsDefaultOnNonBrowser()
        {
            int orientation = SystemInfo.GetScreenOrientation();
            Assert.Equal(1, orientation);
        }

        [Fact]
        public void SystemInfo_GetSystemTimeMs_ReturnsZeroOnNonBrowser()
        {
            double time = SystemInfo.GetSystemTimeMs();
            Assert.Equal(0.0, time);
        }

        [Fact]
        public void SystemInfo_LogToConsole_DoesNotThrow()
        {
            SystemInfo.LogToConsole("test");
        }

        [Fact]
        public void SystemInfo_WarnToConsole_DoesNotThrow()
        {
            SystemInfo.WarnToConsole("test");
        }

        [Fact]
        public void SystemInfo_ErrorToConsole_DoesNotThrow()
        {
            SystemInfo.ErrorToConsole("test");
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_RunMinimalGame_DoesNotThrow()
        {
            QuickStart.RunMinimalGame((w, h) => { });
        }

        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }
    }
}
