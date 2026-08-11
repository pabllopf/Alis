// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformFactoryTests.cs
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
    ///     Tests the web assembly platform factory
    /// </summary>
    public class WebAssemblyPlatformFactoryTests
    {
        /// <summary>
        ///     Tests that create default returns a platform instance
        /// </summary>
        [Fact]
        public void CreateDefault_ReturnsPlatformInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformFactory.CreateDefault();

            Assert.NotNull(platform);
        }

        /// <summary>
        ///     Tests that create with null configuration throws argument null exception
        /// </summary>
        [Fact]
        public void Create_WithNullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WebAssemblyPlatformFactory.Create((WebAssemblyConfiguration) null));
        }

        /// <summary>
        ///     Tests that create with null configure action throws argument null exception
        /// </summary>
        [Fact]
        public void Create_WithNullConfigureAction_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WebAssemblyPlatformFactory.Create((Action<WebAssemblyConfigurationBuilder>) null));
        }

        /// <summary>
        ///     Tests that create with configuration throws when platform cannot initialize
        /// </summary>
        [Fact]
        public void Create_WithConfiguration_ThrowsWhenPlatformCannotInitialize()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfiguration();

            Assert.Throws<InvalidOperationException>(() => WebAssemblyPlatformFactory.Create(config));
        }

        /// <summary>
        ///     Tests that create with configure action applies the action before failing to initialize
        /// </summary>
        [Fact]
        public void Create_WithConfigureAction_AppliesConfiguration()
        {
            bool configured = false;

            Assert.Throws<InvalidOperationException>(() => WebAssemblyPlatformFactory.Create(builder =>
            {
                builder.WithSize(1024, 768).WithTitle("Configured");
                configured = true;
            }));

            Assert.True(configured);
        }

        /// <summary>
        ///     Tests that create for game development throws when platform cannot initialize
        /// </summary>
        [Fact]
        public void CreateForGameDevelopment_ThrowsWhenPlatformCannotInitialize()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyPlatformFactory.CreateForGameDevelopment());
        }

        /// <summary>
        ///     Tests that create for low end device throws when platform cannot initialize
        /// </summary>
        [Fact]
        public void CreateForLowEndDevice_ThrowsWhenPlatformCannotInitialize()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyPlatformFactory.CreateForLowEndDevice());
        }

        /// <summary>
        ///     Tests that create for high end device throws when platform cannot initialize
        /// </summary>
        [Fact]
        public void CreateForHighEndDevice_ThrowsWhenPlatformCannotInitialize()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyPlatformFactory.CreateForHighEndDevice());
        }
    }
}
