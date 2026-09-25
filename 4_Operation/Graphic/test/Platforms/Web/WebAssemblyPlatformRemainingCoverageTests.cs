// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformRemainingCoverageTests.cs
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
    ///     Covers the remaining reachable WebAssemblyPlatform managed members: the window
    ///     resize callback, the state-setting portion of the emscripten-bridging window
    ///     methods (which throw at the native boundary on non-web hosts), and the
    ///     unmatched-key lookup path of IsKeyDown.
    /// </summary>
    public class WebAssemblyPlatformRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that OnWindowResize updates the stored window dimensions.
        /// </summary>
        [Fact]
        public void OnWindowResize_UpdatesWidthAndHeight()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnWindowResize(1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        /// <summary>
        ///     Verifies that HideWindow clears the visibility flag before the native canvas
        ///     call fails at the emscripten boundary.
        /// </summary>
        [Fact]
        public void HideWindow_OnNonWeb_SetsInvisibleBeforeNativeCall()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            try
            {
                platform.ShowWindow();
            }
            catch (DllNotFoundException)
            {
            }

            Assert.True(platform.IsWindowVisible());
            try
            {
                platform.HideWindow();
            }
            catch (DllNotFoundException)
            {
            }
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        ///     Verifies that SetTitle and SetSize update managed state before the native
        ///     boundary call fails on non-web hosts.
        /// </summary>
        [Fact]
        public void SetTitleAndSize_OnNonWeb_UpdateStateBeforeNativeCall()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            try
            {
                platform.SetTitle("Alis");
            }
            catch (DllNotFoundException)
            {
            }

            try
            {
                platform.SetSize(1024, 768);
            }
            catch (DllNotFoundException)
            {
            }

            Assert.Equal(1024, platform.GetWindowWidth());
            Assert.Equal(768, platform.GetWindowHeight());
        }

        /// <summary>
        ///     Verifies that SetWindowIcon reaches the emscripten boundary on non-web hosts.
        /// </summary>
        [Fact]
        public void SetWindowIcon_OnNonWeb_PropagatesDllNotFound()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.Throws<DllNotFoundException>(() => platform.SetWindowIcon("icon.png"));
        }

        /// <summary>
        ///     Verifies that IsKeyDown returns false for keys not present in the state map.
        /// </summary>
        [Fact]
        public void IsKeyDown_WithUnknownKey_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown((ConsoleKey)999));
        }
    }
}