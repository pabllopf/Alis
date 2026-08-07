// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfigurationSafeTests.cs
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
    ///     Safe tests for WebAssembly configuration classes that only exercise pure logic
    ///     (no browser/WebAssembly runtime required).
    /// </summary>
    public class WebAssemblyConfigurationSafeTests
    {
        /// <summary>
        ///     Tests that WebAssemblyPlatformFactory.CreateDefault returns a non-null WebAssemblyPlatform.
        /// </summary>
        [WebOnly]
        public void CreateDefault_ReturnsNonNullWebAssemblyPlatform()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformFactory.CreateDefault();
            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that WebAssemblyConfigurationBuilder can chain multiple method calls.
        /// </summary>
        [WebOnly]
        public void ConfigurationBuilder_CanChainMethods()
        {
            WebAssemblyConfiguration config = new WebAssemblyConfigurationBuilder()
                .WithSize(1280, 720)
                .WithTitle("Chained Test")
                .WithVSync(true)
                .WithTargetFrameRate(60)
                .WithMultisampling(true)
                .WithMultisampleCount(8)
                .WithFullscreen(false)
                .WithPointerLock(true)
                .WithDisplayQuality(DisplayQuality.High)
                .WithGamepadInput(true)
                .WithKeyboardInput(true)
                .WithMouseInput(true)
                .WithTouchInput(false)
                .WithGamepadDeadzone(0.2f)
                .WithTriggerDeadzone(0.05f)
                .WithDebugMode(true)
                .Build();

            Assert.Equal(1280, config.WindowWidth);
            Assert.Equal(720, config.WindowHeight);
            Assert.Equal("Chained Test", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.False(config.Fullscreen);
            Assert.True(config.PointerLock);
            Assert.Equal(DisplayQuality.High, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
            Assert.False(config.TouchInputEnabled);
            Assert.Equal(0.2f, config.GamepadDeadzone);
            Assert.Equal(0.05f, config.TriggerDeadzone);
            Assert.True(config.DebugMode);
        }

        /// <summary>
        ///     Tests that GameContextPresets.Game2D returns a non-null configuration.
        /// </summary>
        [WebOnly]
        public void GameContextPresets_Game2D_ReturnsNonNull()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game2D();
            Assert.NotNull(config);
        }

        /// <summary>
        ///     Tests that GameContextPresets.Game3D returns a non-null configuration.
        /// </summary>
        [WebOnly]
        public void GameContextPresets_Game3D_ReturnsNonNull()
        {
            WebAssemblyConfiguration config = GameContextPresets.Game3D();
            Assert.NotNull(config);
        }

        /// <summary>
        ///     Tests that GameContextPresets.MobileGame returns a non-null configuration.
        /// </summary>
        [WebOnly]
        public void GameContextPresets_MobileGame_ReturnsNonNull()
        {
            WebAssemblyConfiguration config = GameContextPresets.MobileGame();
            Assert.NotNull(config);
        }
    }
}
