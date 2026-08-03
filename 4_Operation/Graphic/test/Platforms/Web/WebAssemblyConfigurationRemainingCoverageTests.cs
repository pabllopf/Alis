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
using Alis.Core.Graphic.Test.Attributes;
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

        /// <summary>
        /// Tests that create with valid config throws invalid operation exception
        /// </summary>
        [WebOnly]
        public void Create_WithValidConfig_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        /// <summary>
        /// Tests that create with config with icon path throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithConfigWithIconPath_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                IconPath = "/assets/icon.png"
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        /// <summary>
        /// Tests that create with config with size throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
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

        /// <summary>
        /// Tests that create with config with fullscreen throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithConfigWithFullscreen_ThrowsInvalidOperationException()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration
            {
                Fullscreen = true
            };
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(config));
        }

        /// <summary>
        /// Tests that create with config with pointer lock throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
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

        /// <summary>
        /// Tests that create with action valid action throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithAction_ValidAction_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.Create(builder =>
                    builder.WithSize(1280, 720)
                        .WithTitle("Test")
                        .WithVSync(true)));
        }

        /// <summary>
        /// Tests that create with action chained full config throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
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

        /// <summary>
        /// Tests that create for game development throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForGameDevelopment_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForGameDevelopment());
        }

        /// <summary>
        /// Tests that create for game development with custom size throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForGameDevelopment_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForGameDevelopment(1600, 900));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.CreateForLowEndDevice
        // =====================================================================

        /// <summary>
        /// Tests that create for low end device throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForLowEndDevice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForLowEndDevice());
        }

        /// <summary>
        /// Tests that create for low end device with custom size throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForLowEndDevice_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForLowEndDevice(640, 480));
        }

        // =====================================================================
        // WebAssemblyPlatformFactory.CreateForHighEndDevice
        // =====================================================================

        /// <summary>
        /// Tests that create for high end device throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForHighEndDevice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForHighEndDevice());
        }

        /// <summary>
        /// Tests that create for high end device with custom size throws invalid operation exception
        /// </summary>
        [WebOnlyAttribute]
        public void CreateForHighEndDevice_WithCustomSize_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => WebAssemblyPlatformFactory.CreateForHighEndDevice(2560, 1440));
        }
    }
}
