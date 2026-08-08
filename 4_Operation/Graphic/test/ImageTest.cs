// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageTest.cs
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

using System.IO;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Tests for the Image class validating image loading, dimensions, and data handling.
    /// </summary>
    public partial class ImageTest
    {
        /// <summary>
        ///     Tests that Image type is accessible
        /// </summary>
        [Fact]
        public void Image_Type_IsAccessible()
        {
            Assert.NotNull(typeof(Image));
        }

        /// <summary>
        ///     Tests that Load throws FileNotFoundException for non-existent file
        /// </summary>
        [Fact]
        public void Load_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => Image.Load("nonexistent.bmp"));
        }

        /// <summary>
        ///     Tests that LoadImageFromResources throws FileNotFoundException for non-existent resource
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WithNonExistentResource_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => Image.LoadImageFromResources("nonexistent_resource"));
        }
    }
}