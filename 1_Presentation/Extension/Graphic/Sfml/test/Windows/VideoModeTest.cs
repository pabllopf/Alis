// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoModeTest.cs
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
    /// The video mode test class
    /// </summary>
    public class VideoModeTest
    {
        /// <summary>
        /// Tests that constructor with width and height sets defaults
        /// </summary>
        [Fact]
        public void Constructor_WithWidthAndHeight_SetsDefaults()
        {
            VideoMode vm = new VideoMode(800, 600);
            Assert.Equal(800u, vm.Width);
            Assert.Equal(600u, vm.Height);
            Assert.Equal(32u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that constructor with width height and bpp sets all fields
        /// </summary>
        [Fact]
        public void Constructor_WithWidthHeightAndBpp_SetsAllFields()
        {
            VideoMode vm = new VideoMode(1024, 768, 16);
            Assert.Equal(1024u, vm.Width);
            Assert.Equal(768u, vm.Height);
            Assert.Equal(16u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that to string includes component names
        /// </summary>
        [Fact]
        public void ToString_IncludesComponentNames()
        {
            VideoMode vm = new VideoMode(1920, 1080);
            string str = vm.ToString();
            Assert.Contains("Width", str);
            Assert.Contains("Height", str);
            Assert.Contains("BitsPerPixel", str);
        }
    }
}
