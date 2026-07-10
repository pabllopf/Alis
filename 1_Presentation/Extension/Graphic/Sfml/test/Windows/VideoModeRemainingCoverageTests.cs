// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoModeRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The video mode remaining coverage tests class
    /// </summary>
    public class VideoModeRemainingCoverageTests
    {
        /// <summary>
        /// Tests that desktop mode returns non zero width
        /// </summary>
        [Fact]
        public void DesktopMode_ReturnsNonZeroWidth()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.Width > 0);
        }

        /// <summary>
        /// Tests that desktop mode returns non zero height
        /// </summary>
        [Fact]
        public void DesktopMode_ReturnsNonZeroHeight()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.Height > 0);
        }

        /// <summary>
        /// Tests that desktop mode returns non zero bits per pixel
        /// </summary>
        [Fact]
        public void DesktopMode_ReturnsNonZeroBitsPerPixel()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.BitsPerPixel > 0);
        }

        /// <summary>
        /// Tests that fullscreen modes returns non null array
        /// </summary>
        [Fact]
        public void FullscreenModes_ReturnsNonNullArray()
        {
            VideoMode[] modes = VideoMode.FullscreenModes;
            Assert.NotNull(modes);
        }

        /// <summary>
        /// Tests that fullscreen modes returns at least one mode
        /// </summary>
        [Fact]
        public void FullscreenModes_ReturnsAtLeastOneMode()
        {
            VideoMode[] modes = VideoMode.FullscreenModes;
            Assert.True(modes.Length > 0);
        }

        /// <summary>
        /// Tests that each fullscreen mode has valid dimensions
        /// </summary>
        [Fact]
        public void FullscreenModes_EachModeHasValidDimensions()
        {
            VideoMode[] modes = VideoMode.FullscreenModes;
            foreach (VideoMode mode in modes)
            {
                Assert.True(mode.Width > 0);
                Assert.True(mode.Height > 0);
                Assert.True(mode.BitsPerPixel > 0);
            }
        }

        /// <summary>
        /// Tests that isValid returns true for valid video mode
        /// </summary>
        [Fact]
        public void IsValid_WithDesktopMode_ReturnsTrue()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.IsValid());
        }

        /// <summary>
        /// Tests that isValid returns true for common resolution
        /// </summary>
        [Fact]
        public void IsValid_WithCommonResolution_ReturnsTrue()
        {
            VideoMode vm = new VideoMode(1920, 1080);
            Assert.True(vm.IsValid());
        }

        /// <summary>
        /// Tests that isValid returns false for zero resolution
        /// </summary>
        [Fact]
        public void IsValid_WithZeroResolution_ReturnsFalse()
        {
            VideoMode vm = new VideoMode(0, 0, 0);
            Assert.False(vm.IsValid());
        }
    }
}
