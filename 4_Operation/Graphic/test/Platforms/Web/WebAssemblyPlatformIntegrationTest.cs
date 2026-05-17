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
        public void MultiplatformGameEngine_Constructor_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new MultiplatformGameEngine(800, 600, "Test"));
            }
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
        public void SystemInfo_IsOnline_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.IsOnline());
            }
        }

        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = SystemInfo.GetLanguage();
            Assert.Equal("en", lang);
        }

        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetDevicePixelRatio());
            }
        }

        [Fact]
        public void SystemInfo_GetBatteryLevel_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetBatteryLevel());
            }
        }

        [Fact]
        public void SystemInfo_IsCharging_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.IsCharging());
            }
        }

        [Fact]
        public void SystemInfo_GetScreenOrientation_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetScreenOrientation());
            }
        }

        [Fact]
        public void SystemInfo_GetSystemTimeMs_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.GetSystemTimeMs());
            }
        }

        [Fact]
        public void SystemInfo_LogToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.LogToConsole("test"));
            }
        }

        [Fact]
        public void SystemInfo_WarnToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.WarnToConsole("test"));
            }
        }

        [Fact]
        public void SystemInfo_ErrorToConsole_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => SystemInfo.ErrorToConsole("test"));
            }
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_RunMinimalGame_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    QuickStart.RunMinimalGame((w, h) => { }));
            }
        }

        [Fact]
        public void QuickStart_LogPlatformInfo_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() => QuickStart.LogPlatformInfo());
            }
        }
    }
}
