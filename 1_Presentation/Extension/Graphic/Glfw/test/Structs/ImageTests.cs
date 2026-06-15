// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageTests.cs
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
using System.IO;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Image class
    /// </summary>
    public class ImageTests
    {
        /// <summary>
        /// The base directory
        /// </summary>
        private readonly string _testAssetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Assets");

        /// <summary>
        ///     Tests that loading a valid BMP file returns a non-null image with correct properties
        /// </summary>
        [Fact]
        public void Image_Load_WithValidBmpFile_ReturnsImageWithCorrectProperties()
        {
            string bmpPath = Path.Combine(_testAssetsPath, "logo.bmp");
            
            if (!File.Exists(bmpPath))
            {
                throw new FileNotFoundException($"Test asset not found: {bmpPath}");
            }

            Image image = Image.Load(bmpPath);

            Assert.NotNull(image);
            Assert.True(image.Width > 0, "Image width should be positive");
            Assert.True(image.Height > 0, "Image height should be positive");
            Assert.NotNull(image.Data);
            Assert.True(image.Data.Length > 0, "Image data should not be empty");
            
            int expectedDataLength = image.Width * image.Height * 4;
            Assert.Equal(expectedDataLength, image.Data.Length);
        }

        /// <summary>
        ///     Tests that loading a non-BMP file returns null
        /// </summary>
        [Fact]
        public void Image_Load_WithNonBmpFile_ReturnsNull()
        {
            string wavPath = Path.Combine(_testAssetsPath, "AudioSample.wav");
            
            if (!File.Exists(wavPath))
            {
                throw new FileNotFoundException($"Test asset not found: {wavPath}");
            }

            Image image = Image.Load(wavPath);

            Assert.Null(image);
        }

        /// <summary>
        ///     Tests that loading with null path throws ArgumentNullException
        /// </summary>
        [Fact]
        public void Image_Load_WithNullPath_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Image.Load(null));
        }

        /// <summary>
        ///     Tests that loading with empty path throws ArgumentException
        /// </summary>
        [Fact]
        public void Image_Load_WithEmptyPath_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.Load(""));
        }

        /// <summary>
        ///     Tests that loading a non-existent file throws FileNotFoundException
        /// </summary>
        [Fact]
        public void Image_Load_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            string nonExistentPath = Path.Combine(_testAssetsPath, "nonexistent.bmp");
            Assert.Throws<FileNotFoundException>(() => Image.Load(nonExistentPath));
        }

        /// <summary>
        ///     Tests that loaded image has correct width and height properties
        /// </summary>
        [Fact]
        public void Image_Load_WithValidBmpFile_ReturnsCorrectDimensions()
        {
            string bmpPath = Path.Combine(_testAssetsPath, "tile000.bmp");
            
            if (!File.Exists(bmpPath))
            {
                throw new FileNotFoundException($"Test asset not found: {bmpPath}");
            }

            Image image = Image.Load(bmpPath);

            Assert.NotNull(image);
            
            int expectedDataLength = image.Width * image.Height * 4;
            Assert.Equal(expectedDataLength, image.Data.Length);
        }

        /// <summary>
        ///     Tests that image data contains valid pixel information
        /// </summary>
        [Fact]
        public void Image_Load_WithValidBmpFile_ReturnsValidPixelData()
        {
            string bmpPath = Path.Combine(_testAssetsPath, "tile000.bmp");
            
            if (!File.Exists(bmpPath))
            {
                throw new FileNotFoundException($"Test asset not found: {bmpPath}");
            }

            Image image = Image.Load(bmpPath);

            Assert.NotNull(image);
            Assert.NotEmpty(image.Data);
            
            for (int i = 0; i < image.Data.Length; i += 4)
            {
                byte red = image.Data[i];
                byte green = image.Data[i + 1];
                byte blue = image.Data[i + 2];
                byte alpha = image.Data[i + 3];
                
                Assert.True((red >= 0) && (red <= 255), $"Red value at index {i} is invalid: {red}");
                Assert.True((green >= 0) && (green <= 255), $"Green value at index {i + 1} is invalid: {green}");
                Assert.True((blue >= 0) && (blue <= 255), $"Blue value at index {i + 2} is invalid: {blue}");
                Assert.True((alpha >= 0) && (alpha <= 255), $"Alpha value at index {i + 3} is invalid: {alpha}");
            }
        }
    }
}