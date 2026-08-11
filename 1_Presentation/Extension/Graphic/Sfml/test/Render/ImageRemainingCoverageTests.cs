// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="Image"/> class
    /// </summary>
    public class ImageRemainingCoverageTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRemainingCoverageTests"/> class
        /// </summary>
        static ImageRemainingCoverageTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(ImageRemainingCoverageTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Gets the value of the bitmap sample path
        /// </summary>
        private static string BitmapSamplePath => Path.Combine(AssetsDir, "tile000.bmp");

        /// <summary>
        /// Tests the width height constructor creates a non null pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void WidthHeight_Constructor_CreatesNonNullPointer()
        {
            using Image image = new Image(8, 8);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
        }

        /// <summary>
        /// Tests the width height color constructor creates a non null pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void WidthHeightColor_Constructor_CreatesNonNullPointer()
        {
            using Image image = new Image(8, 8, Color.Red);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
        }

        /// <summary>
        /// Tests the pixels constructor creates a non null pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Pixels_Constructor_CreatesNonNullPointer()
        {
            using Image image = new Image(8, 8, new byte[8 * 8 * 4]);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
        }

        /// <summary>
        /// Tests the file constructor loads a valid image and saves it
        /// </summary>
        [RequireCSfmlSystemFact]
        public void File_Constructor_LoadsAndSaves()
        {
            using Image image = new Image(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
            string path = Path.Combine(AppContext.BaseDirectory, "img_file.bmp");
            Assert.True(image.SaveToFile(path));
        }

        /// <summary>
        /// Tests the file constructor throws on invalid path
        /// </summary>
        [RequireCSfmlSystemFact]
        public void File_Constructor_ThrowsOnInvalidPath()
        {
            Assert.Throws<LoadingFailedException>(() => new Image("/nonexistent/image.bmp"));
        }

        /// <summary>
        /// Tests the stream constructor loads a valid image and saves it
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Stream_Constructor_LoadsAndSaves()
        {
            byte[] bytes = File.ReadAllBytes(BitmapSamplePath);
            using MemoryStream stream = new MemoryStream(bytes);
            using Image image = new Image(stream);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
            string path = Path.Combine(AppContext.BaseDirectory, "img_stream.bmp");
            Assert.True(image.SaveToFile(path));
        }

        /// <summary>
        /// Tests the stream constructor throws on empty stream
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Stream_Constructor_ThrowsOnEmptyStream()
        {
            using MemoryStream stream = new MemoryStream();
            Assert.Throws<LoadingFailedException>(() => new Image(stream));
        }

        /// <summary>
        /// Tests the bytes constructor loads a valid image and saves it
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bytes_Constructor_LoadsAndSaves()
        {
            byte[] bytes = File.ReadAllBytes(BitmapSamplePath);
            using Image image = new Image(bytes);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
            string path = Path.Combine(AppContext.BaseDirectory, "img_bytes.bmp");
            Assert.True(image.SaveToFile(path));
        }

        /// <summary>
        /// Tests the bytes constructor throws on empty bytes
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bytes_Constructor_ThrowsOnEmptyBytes()
        {
            Assert.Throws<LoadingFailedException>(() => new Image(Array.Empty<byte>()));
        }

        /// <summary>
        /// Tests the copy constructor produces an independent valid image
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_Constructor_ProducesValidImage()
        {
            using Image original = new Image(BitmapSamplePath);
            using Image copy = new Image(original);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
            Assert.NotEqual(original.CPointer, copy.CPointer);
            string path = Path.Combine(AppContext.BaseDirectory, "img_copy.bmp");
            Assert.True(copy.SaveToFile(path));
        }

        /// <summary>
        /// Tests the pixels property returns an array
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Pixels_ReturnsArray()
        {
            using Image image = new Image(BitmapSamplePath);
            byte[] pixels = image.Pixels;
            Assert.NotNull(pixels);
        }

        /// <summary>
        /// Tests the size property is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_IsReadable()
        {
            using Image image = new Image(BitmapSamplePath);
            _ = image.Size;
        }

        /// <summary>
        /// Tests the save to file returns true for a loaded image
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SaveToFile_ReturnsTrue()
        {
            using Image image = new Image(BitmapSamplePath);
            string path = Path.Combine(AppContext.BaseDirectory, "img_save.bmp");
            Assert.True(image.SaveToFile(path));
        }

        /// <summary>
        /// Tests the create mask from color single parameter overload
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CreateMaskFromColor_SingleParameter()
        {
            using Image image = new Image(BitmapSamplePath);
            image.CreateMaskFromColor(Color.Black);
        }

        /// <summary>
        /// Tests the create mask from color two parameters overload
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CreateMaskFromColor_TwoParameters()
        {
            using Image image = new Image(BitmapSamplePath);
            image.CreateMaskFromColor(Color.Black, 0);
        }

        /// <summary>
        /// Tests the copy three parameters overload
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_ThreeParameters()
        {
            using Image source = new Image(BitmapSamplePath);
            using Image target = new Image(BitmapSamplePath);
            target.Copy(source, 1, 1);
        }

        /// <summary>
        /// Tests the copy four parameters overload
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_FourParameters()
        {
            using Image source = new Image(BitmapSamplePath);
            using Image target = new Image(BitmapSamplePath);
            target.Copy(source, 1, 1, new IntRect(0, 0, 8, 8));
        }

        /// <summary>
        /// Tests the copy five parameters overload
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_FiveParameters()
        {
            using Image source = new Image(BitmapSamplePath);
            using Image target = new Image(BitmapSamplePath);
            target.Copy(source, 1, 1, new IntRect(0, 0, 8, 8), true);
        }

        /// <summary>
        /// Tests the get pixel does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPixel_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            image.SetPixel(0, 0, new Color(200, 100, 50, 255));
            _ = image.GetPixel(0, 0);
        }

        /// <summary>
        /// Tests the set pixel does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPixel_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            image.SetPixel(0, 0, Color.Blue);
        }

        /// <summary>
        /// Tests the flip horizontally does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FlipHorizontally_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            image.FlipHorizontally();
        }

        /// <summary>
        /// Tests the flip vertically does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FlipVertically_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            image.FlipVertically();
        }

        /// <summary>
        /// Tests the to string returns a formatted description
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ReturnsFormattedDescription()
        {
            using Image image = new Image(BitmapSamplePath);
            Assert.StartsWith("[Image]", image.ToString());
        }

        /// <summary>
        /// Tests the destroy sets the pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_SetsPointerToZero()
        {
            Image image = new Image(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
            image.Dispose();
            Assert.Equal(IntPtr.Zero, image.CPointer);
        }
    }
}
