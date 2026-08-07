// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegrationSafeTests.cs
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
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Safe tests for WebAssemblyPlatformIntegration that only exercise pure logic
    ///     (no browser/WebAssembly runtime required).
    /// </summary>
    public class WebAssemblyPlatformIntegrationSafeTests
    {
        /// <summary>
        ///     Tests that GetPlatform returns a non-null INativePlatform for "WebAssembly".
        /// </summary>
        [WebOnly]
        public void GetPlatform_WebAssembly_ReturnsNonNull()
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("WebAssembly");
            Assert.NotNull(platform);
        }

        /// <summary>
        ///     Tests that GetPlatform returns a non-null INativePlatform for "Web".
        /// </summary>
        [WebOnly]
        public void GetPlatform_Web_ReturnsNonNull()
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("Web");
            Assert.NotNull(platform);
        }

        /// <summary>
        ///     Tests that GetPlatform returns a non-null INativePlatform for "Emscripten".
        /// </summary>
        [WebOnly]
        public void GetPlatform_Emscripten_ReturnsNonNull()
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("Emscripten");
            Assert.NotNull(platform);
        }

        /// <summary>
        ///     Tests that GetPlatform returns a non-null INativePlatform for "WASM".
        /// </summary>
        [WebOnly]
        public void GetPlatform_WASM_ReturnsNonNull()
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("WASM");
            Assert.NotNull(platform);
        }

        /// <summary>
        ///     Tests that GetPlatform throws PlatformNotSupportedException for an invalid name.
        /// </summary>
        [WebOnly]
        public void GetPlatform_Invalid_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(() =>
                WebAssemblyPlatformIntegration.GetPlatform("Invalid"));
        }

        /// <summary>
        ///     Tests that RegisterPlatform adds a new platform that can be retrieved.
        /// </summary>
        [WebOnly]
        public void RegisterPlatform_AddsNewPlatform()
        {
            WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(WebAssemblyPlatform));
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("Custom");
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that GetSupportedPlatforms returns at least 4 entries.
        /// </summary>
        [WebOnly]
        public void GetSupportedPlatforms_ReturnsAtLeastFourEntries()
        {
            string[] platforms = WebAssemblyPlatformIntegration.GetSupportedPlatforms();
            Assert.NotNull(platforms);
            Assert.True(platforms.Length >= 4);
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with Default profile returns a non-null WebAssemblyPlatform.
        /// </summary>
        [WebOnly]
        public void CreateOptimizedPlatform_Default_ReturnsNonNullWebAssemblyPlatform()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }
    }
}
