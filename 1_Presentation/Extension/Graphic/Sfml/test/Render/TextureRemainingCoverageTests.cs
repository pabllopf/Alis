// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="Texture"/> class
    /// </summary>
    public class TextureRemainingCoverageTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureRemainingCoverageTests"/> class
        /// </summary>
        static TextureRemainingCoverageTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(TextureRemainingCoverageTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Gets the value of the bitmap sample path
        /// </summary>
        private static string BitmapSamplePath => Path.Combine(AssetsDir, "tile000.bmp");

        /// <summary>
        /// Tests the width height constructor throws when no context is available
        /// </summary>
        [RequireCSfmlSystemFact]
        public void WidthHeight_Constructor_ThrowsWithoutContext()
        {
            Assert.Throws<LoadingFailedException>(() => new Texture(64, 64));
        }

        /// <summary>
        /// Tests the file constructor creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void File_Constructor_CreatesTexture()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the file constructor with area creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void File_Constructor_WithArea_CreatesTexture()
        {
            using Texture texture = new Texture(BitmapSamplePath, new IntRect(0, 0, 8, 8));
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the file constructor throws on invalid path
        /// </summary>
        [RequireCSfmlSystemFact]
        public void File_Constructor_ThrowsOnInvalidPath()
        {
            Assert.Throws<LoadingFailedException>(() => new Texture("/nonexistent/texture.bmp"));
        }

        /// <summary>
        /// Tests the stream constructor creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Stream_Constructor_CreatesTexture()
        {
            byte[] bytes = File.ReadAllBytes(BitmapSamplePath);
            using MemoryStream stream = new MemoryStream(bytes);
            using Texture texture = new Texture(stream);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the stream constructor with area creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Stream_Constructor_WithArea_CreatesTexture()
        {
            byte[] bytes = File.ReadAllBytes(BitmapSamplePath);
            using MemoryStream stream = new MemoryStream(bytes);
            using Texture texture = new Texture(stream, new IntRect(0, 0, 8, 8));
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the stream constructor throws on empty stream
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Stream_Constructor_ThrowsOnEmptyStream()
        {
            using MemoryStream stream = new MemoryStream();
            Assert.Throws<LoadingFailedException>(() => new Texture(stream));
        }

        /// <summary>
        /// Tests the bytes constructor creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bytes_Constructor_CreatesTexture()
        {
            byte[] bytes = File.ReadAllBytes(BitmapSamplePath);
            using Texture texture = new Texture(bytes);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the bytes constructor throws on empty bytes
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bytes_Constructor_ThrowsOnEmptyBytes()
        {
            Assert.Throws<LoadingFailedException>(() => new Texture(Array.Empty<byte>()));
        }

        /// <summary>
        /// Tests the image constructor creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_Constructor_CreatesTexture()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(image);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the image constructor with area creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_Constructor_WithArea_CreatesTexture()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(image, new IntRect(0, 0, 8, 8));
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the copy constructor creates a texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_Constructor_CreatesTexture()
        {
            using Texture original = new Texture(BitmapSamplePath);
            using Texture copy = new Texture(original);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
        }

        /// <summary>
        /// Tests the native handle is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_IsReadable()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            _ = texture.NativeHandle;
        }

        /// <summary>
        /// Tests the smooth property get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_GetAndSet()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            texture.Smooth = true;
            Assert.True(texture.Smooth);
            texture.Smooth = false;
            Assert.False(texture.Smooth);
        }

        /// <summary>
        /// Tests the srgb property throws entry point not found
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Srgb_ThrowsEntryPointNotFound()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.Throws<EntryPointNotFoundException>(() => texture.Srgb = false);
        }

        /// <summary>
        /// Tests the repeated property get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_GetAndSet()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            texture.Repeated = true;
            Assert.True(texture.Repeated);
            texture.Repeated = false;
            Assert.False(texture.Repeated);
        }

        /// <summary>
        /// Tests the size property is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_IsReadable()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            _ = texture.Size;
        }

        /// <summary>
        /// Tests the maximum size property is greater than zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumSize_IsGreaterThanZero()
        {
            Assert.True(Texture.MaximumSize > 0);
        }

        /// <summary>
        /// Tests the copy to image creates an image
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyToImage_CreatesImage()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            using Image image = texture.CopyToImage();
            Context.Global.SetActive(false);
            Assert.NotEqual(IntPtr.Zero, image.CPointer);
        }

        /// <summary>
        /// Tests the update pixels overload does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Pixels_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            texture.Update(new byte[1024]);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the update pixels with size overload does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_PixelsWithSize_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            texture.Update(new byte[1024], 16, 16, 0, 0);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the update texture overload does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Texture_DoesNotThrow()
        {
            using Texture source = new Texture(BitmapSamplePath);
            using Texture target = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            target.Update(source, 0, 0);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the update image overload does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Image_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            texture.Update(image);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the update image with offset overload does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_ImageWithOffset_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            texture.Update(image, 0, 0);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the generate mipmap does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GenerateMipmap_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            _ = texture.GenerateMipmap();
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the swap exchanges the contents
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Swap_DoesNotThrow()
        {
            using Texture left = new Texture(BitmapSamplePath);
            using Texture right = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            left.Swap(right);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the bind with a texture does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_WithTexture_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Context.Global.SetActive(true);
            Texture.Bind(texture);
            Texture.Bind(null);
            Context.Global.SetActive(false);
        }

        /// <summary>
        /// Tests the to string returns a formatted description
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ReturnsFormattedDescription()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.StartsWith("[Texture]", texture.ToString());
        }

        /// <summary>
        /// Tests the destroy sets the pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_SetsPointerToZero()
        {
            Texture texture = new Texture(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
            texture.Dispose();
            Assert.Equal(IntPtr.Zero, texture.CPointer);
        }
    }
}
