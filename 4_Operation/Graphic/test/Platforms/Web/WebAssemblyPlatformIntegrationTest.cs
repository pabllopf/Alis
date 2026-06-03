// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegrationTest.cs
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
using Alis.Core.Graphic.Platforms;
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

        
        [InlineData("WebAssembly")]
        [InlineData("Web")]
        [InlineData("Emscripten")]
        [InlineData("WASM")]
        public void WebAssemblyPlatformIntegration_GetPlatform_ValidName_ReturnsInstance(string name)
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform(name);
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
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }
        // =====================================================================

        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.PlatformName);
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

        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }
    }
}
