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

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
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
        [RequireCSfmlWindowsFact]
        public void DesktopMode_ReturnsNonZeroWidth()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.Width > 0);
        }

        /// <summary>
        /// Tests that desktop mode returns non zero height
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void DesktopMode_ReturnsNonZeroHeight()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.Height > 0);
        }

        /// <summary>
        /// Tests that desktop mode returns non zero bits per pixel
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void DesktopMode_ReturnsNonZeroBitsPerPixel()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.BitsPerPixel > 0);
        }

        /// <summary>
        /// Tests that fullscreen modes returns non null array
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FullscreenModes_ReturnsNonNullArray()
        {
            VideoMode[] modes = VideoMode.FullscreenModes;
            Assert.NotNull(modes);
        }

        /// <summary>
        /// Tests that fullscreen modes returns at least one mode
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FullscreenModes_ReturnsAtLeastOneMode()
        {
            VideoMode[] modes = VideoMode.FullscreenModes;
            Assert.True(modes.Length > 0);
        }

        /// <summary>
        /// Tests that each fullscreen mode has valid dimensions
        /// </summary>
        [RequireCSfmlWindowsFact]
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
        [RequireCSfmlWindowsFact]
        public void IsValid_WithDesktopMode_ReturnsTrue()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.IsValid());
        }

        /// <summary>
        /// Tests that isValid returns true for the current desktop resolution
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsValid_WithCommonResolution_ReturnsTrue()
        {
            VideoMode vm = VideoMode.DesktopMode;
            Assert.True(vm.IsValid());
        }

        /// <summary>
        /// Tests that isValid returns false for zero resolution
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsValid_WithZeroResolution_ReturnsFalse()
        {
            VideoMode vm = new VideoMode(0, 0, 0);
            Assert.False(vm.IsValid());
        }

        /// <summary>
        /// Tests that constructor with width and height defaults bpp to 32
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithWidthAndHeight_DefaultsBppTo32()
        {
            VideoMode vm = new VideoMode(1280, 720);
            Assert.Equal(1280u, vm.Width);
            Assert.Equal(720u, vm.Height);
            Assert.Equal(32u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that constructor with width height and bpp assigns all fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithWidthHeightAndBpp_AssignsAllFields()
        {
            VideoMode vm = new VideoMode(2560, 1440, 24);
            Assert.Equal(2560u, vm.Width);
            Assert.Equal(1440u, vm.Height);
            Assert.Equal(24u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that constructor with zero values assigns zero fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithZeroValues_AssignsZeroFields()
        {
            VideoMode vm = new VideoMode(0, 0, 0);
            Assert.Equal(0u, vm.Width);
            Assert.Equal(0u, vm.Height);
            Assert.Equal(0u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that to string contains width height and bits per pixel values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ContainsAllValues()
        {
            VideoMode vm = new VideoMode(640, 480, 16);
            string str = vm.ToString();
            Assert.Contains("640", str);
            Assert.Contains("480", str);
            Assert.Contains("16", str);
        }

        /// <summary>
        /// Tests that to string contains component labels
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ContainsComponentLabels()
        {
            VideoMode vm = new VideoMode(800, 600);
            string str = vm.ToString();
            Assert.Contains("Width", str);
            Assert.Contains("Height", str);
            Assert.Contains("BitsPerPixel", str);
        }

        /// <summary>
        /// Tests that fields can be mutated directly
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Fields_CanBeMutatedDirectly()
        {
            VideoMode vm = new VideoMode(1, 2, 3);
            vm.Width = 3840;
            vm.Height = 2160;
            vm.BitsPerPixel = 30;
            Assert.Equal(3840u, vm.Width);
            Assert.Equal(2160u, vm.Height);
            Assert.Equal(30u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that isValid throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsValid_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                VideoMode vm = new VideoMode(800, 600);
                Assert.Throws<DllNotFoundException>(() => vm.IsValid());
            }
        }

        /// <summary>
        /// Tests that desktop mode throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void DesktopMode_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => VideoMode.DesktopMode);
            }
        }

        /// <summary>
        /// Tests that fullscreen modes throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FullscreenModes_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => VideoMode.FullscreenModes);
            }
        }

        /// <summary>
        /// Determines whether the csfml window native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadWindowLibrary()
        {
            if (NativeLibrary.TryLoad("csfml-window", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(Alis.Extension.Graphic.Sfml.Test.Attributes.RequireCSfmlWindowsFactAttribute).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "csfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
