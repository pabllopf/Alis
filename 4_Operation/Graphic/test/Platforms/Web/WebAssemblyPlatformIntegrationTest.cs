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

        
        /// <summary>
        /// Webs the assembly platform integration get platform valid name returns instance using the specified name
        /// </summary>
        /// <param name="name">The name</param>
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

        /// <summary>
        /// Tests that web assembly platform integration get platform invalid name throws
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformIntegration_GetPlatform_InvalidName_Throws()
        {
            Assert.Throws<PlatformNotSupportedException>(() =>
                WebAssemblyPlatformIntegration.GetPlatform("InvalidPlatform"));
        }

        /// <summary>
        /// Tests that web assembly platform integration get supported platforms returns names
        /// </summary>
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

        /// <summary>
        /// Tests that web assembly platform integration register platform invalid type throws
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformIntegration_RegisterPlatform_InvalidType_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(string)));
        }

        /// <summary>
        /// Tests that web assembly platform integration create optimized platform default returns instance
        /// </summary>
        [Fact]
        public void WebAssemblyPlatformIntegration_CreateOptimizedPlatform_Default_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }
        // =====================================================================

        /// <summary>
        /// Tests that system info get platform name returns web assembly
        /// </summary>
        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.PlatformName);
        }

        /// <summary>
        /// Tests that system info is online returns false on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsOnline());
        }

        /// <summary>
        /// Tests that system info get language returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = SystemInfo.GetLanguage();
            Assert.Equal("en", lang);
        }

        /// <summary>
        /// Tests that system info get device pixel ratio returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            float ratio = SystemInfo.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        /// <summary>
        /// Tests that system info get battery level returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = SystemInfo.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        /// <summary>
        /// Tests that system info is charging returns false on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsCharging());
        }

        /// <summary>
        /// Tests that system info get screen orientation returns default on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetScreenOrientation_ReturnsDefaultOnNonBrowser()
        {
            int orientation = SystemInfo.GetScreenOrientation();
            Assert.Equal(1, orientation);
        }

        /// <summary>
        /// Tests that system info get system time ms returns zero on non browser
        /// </summary>
        [Fact]
        public void SystemInfo_GetSystemTimeMs_ReturnsZeroOnNonBrowser()
        {
            double time = SystemInfo.GetSystemTimeMs();
            Assert.Equal(0.0, time);
        }

        /// <summary>
        /// Tests that system info log to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_LogToConsole_DoesNotThrow()
        {
            SystemInfo.LogToConsole("test");
        }

        /// <summary>
        /// Tests that system info warn to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_WarnToConsole_DoesNotThrow()
        {
            SystemInfo.WarnToConsole("test");
        }

        /// <summary>
        /// Tests that system info error to console does not throw
        /// </summary>
        [Fact]
        public void SystemInfo_ErrorToConsole_DoesNotThrow()
        {
            SystemInfo.ErrorToConsole("test");
        }

        /// <summary>
        /// Tests that quick start log platform info does not throw
        /// </summary>
        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }
    }
}
