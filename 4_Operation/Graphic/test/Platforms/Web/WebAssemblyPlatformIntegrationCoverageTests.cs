// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegrationCoverageTests.cs
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
    public class WebAssemblyPlatformIntegrationCoverageTests
    {
        // =====================================================================
        // WebAssemblyPlatformIntegration
        // =====================================================================

        [Fact]
        public void CreateGameContext_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateGameContext("TestGame"));
        }

        [Fact]
        public void CreateGameContext_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateGameContext("TestGame", 800, 600));
        }

        [Fact]
        public void CreateOptimizedPlatform_Game2D_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        }

        [Fact]
        public void CreateOptimizedPlatform_Game3D_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game3D));
        }

        [Fact]
        public void CreateOptimizedPlatform_LowEnd_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.LowEnd));
        }

        [Fact]
        public void CreateOptimizedPlatform_HighEnd_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        }

        [Fact]
        public void CreateOptimizedPlatform_Mobile_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
        }

        [Fact]
        public void CreateOptimizedPlatform_Web_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Web);
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        // =====================================================================
        // MultiplatformGameEngine (blocked by WASM runtime)
        // =====================================================================

        [Fact]
        public void MultiplatformGameEngine_Constructor_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new MultiplatformGameEngine(800, 600, "Test"));
        }

        // =====================================================================
        // InputManager (blocked by WASM runtime - needs WebAssemblyGameContext)
        // =====================================================================

        [Fact]
        public void InputManager_Constructor_NullContext_StoresNull()
        {
            InputManager manager = new InputManager(null);
            Assert.NotNull(manager);
        }

        // =====================================================================
        // DisplayManager
        // =====================================================================

        [Fact]
        public void DisplayManager_Constructor_NullContext_StoresNull()
        {
            DisplayManager manager = new DisplayManager(null);
            Assert.NotNull(manager);
        }

        [Fact]
        public void DisplayManager_IsFullscreen_ReturnsDefault()
        {
            Assert.False(DisplayManager.IsFullscreen());
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_RunMinimalGame_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                QuickStart.RunMinimalGame((w, h) => { }));
        }
    }
}
