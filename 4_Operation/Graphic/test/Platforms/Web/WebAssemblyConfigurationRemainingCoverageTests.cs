// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfigurationRemainingCoverageTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Remaining coverage tests for WebAssemblyPlatformFactory
    ///     covering Create with various configurations, CreateForGameDevelopment,
    ///     CreateForLowEndDevice, and CreateForHighEndDevice paths that depend
    ///     on EGL initialization (which fails on non-WebAssembly environments).
    /// </summary>
    public class WebAssemblyConfigurationRemainingCoverageTests
    {
        // =====================================================================
        // WebAssemblyPlatformFactory.Create(WebAssemblyConfiguration)
        // =====================================================================

        [Fact]
        public void Create_WithValidConfig_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        [Fact]
        public void Create_WithConfigWithIconPath_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                IconPath = "/assets/icon.png"
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        [Fact]
        public void Create_WithConfigWithSize_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                WindowWidth = 1920,
                WindowHeight = 1080
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        [Fact]
        public void Create_WithConfigWithFullscreen_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                Fullscreen = true
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        [Fact]
        public void Create_WithConfigWithPointerLock_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                PointerLock = true
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.Create(Action<WebAssemblyConfigurationBuilder>)
        // =====================================================================

        [Fact]
        public void Create_WithAction_ValidAction_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(builder =>
                    builder.WithSize(1280, 720)
                        .WithTitle("Test")
                        .WithVSync(true)));
        }

        [Fact]
        public void Create_WithAction_ChainedFullConfig_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(builder =>
                    builder.WithSize(1920, 1080)
                        .WithTitle("Game")
                        .WithIconPath("/icon.png")
                        .WithVSync(true)
                        .WithTargetFrameRate(60)
                        .WithMultisampling(true)
                        .WithMultisampleCount(8)
                        .WithFullscreen(true)
                        .WithPointerLock(true)
                        .WithDisplayQuality(DisplayQuality.Ultra)
                        .WithGamepadInput(true)
                        .WithKeyboardInput(true)
                        .WithMouseInput(true)
                        .WithTouchInput(false)
                        .WithGamepadDeadzone(0.2f)
                        .WithTriggerDeadzone(0.15f)
                        .WithDebugMode(true)));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.CreateForGameDevelopment
        // =====================================================================

        [Fact]
        public void CreateForGameDevelopment_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForGameDevelopment());
        }

        [Fact]
        public void CreateForGameDevelopment_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForGameDevelopment(1600, 900));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.CreateForLowEndDevice
        // =====================================================================

        [Fact]
        public void CreateForLowEndDevice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForLowEndDevice());
        }

        [Fact]
        public void CreateForLowEndDevice_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForLowEndDevice(640, 480));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.CreateForHighEndDevice
        // =====================================================================

        [Fact]
        public void CreateForHighEndDevice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForHighEndDevice());
        }

        [Fact]
        public void CreateForHighEndDevice_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForHighEndDevice(2560, 1440));
        }
    }
}
