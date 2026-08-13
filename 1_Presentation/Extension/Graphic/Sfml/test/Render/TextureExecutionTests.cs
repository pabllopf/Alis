// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureExecutionTests.cs
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
    ///     Executes the <see cref="Texture" /> wrapper members against the real native CSFML library. Textures are
    ///     loaded from the bundled bitmap asset because the installed CSFML 3.0 changed the creation ABI to
    ///     <c>sfVector2u</c> and the wrapper still declares the two integer form, which makes the width and height
    ///     constructor always fail. Pixel operations run inside the global <see cref="Context" /> activation because
    ///     they need an OpenGL context; the window based update overloads are not exercised because creating a
    ///     <see cref="Window" /> on a worker thread aborts the test host on macOS.
    /// </summary>
    public class TextureExecutionTests
    {
        /// <summary>
        ///     The texture width used by the assertions
        /// </summary>
        private const uint TextureWidth = 64;

        /// <summary>
        ///     The texture height used by the assertions
        /// </summary>
        private const uint TextureHeight = 64;

        /// <summary>
        ///     The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextureExecutionTests"/> class
        /// </summary>
        static TextureExecutionTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(TextureExecutionTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        ///     Gets the value of the bitmap sample path
        /// </summary>
        private static string BitmapSamplePath => Path.Combine(AssetsDir, "tile000.bmp");

        /// <summary>
        ///     Runs the specified action with the global OpenGL context activated.
        /// </summary>
        /// <param name="action">The action to execute</param>
        private static void WithContext(Action action)
        {
            Context.Global.SetActive(true);
            try
            {
                action();
            }
            finally
            {
                Context.Global.SetActive(false);
            }
        }

        /// <summary>
        ///     Tests that the file constructor creates a texture with the requested size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_File_CreatesTexture()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        ///     Tests that the image constructor creates a texture from an in memory image
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_Image_CreatesTexture()
        {
            using Image image = new Image(BitmapSamplePath);
            WithContext(() =>
            {
                using Texture texture = new Texture(image);
                Assert.NotEqual(IntPtr.Zero, texture.CPointer);
            });
        }

        /// <summary>
        ///     Tests that the image constructor with an out of bounds area throws a loading failed exception
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_ImageWithOutOfBoundsArea_ThrowsLoadingFailed()
        {
            using Image image = new Image(BitmapSamplePath);
            Assert.Throws<LoadingFailedException>(() => new Texture(image, new IntRect(100, 100, 100, 100)));
        }

        /// <summary>
        ///     Tests that the copy constructor creates an independent texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_Copy_CreatesTexture()
        {
            using Texture original = new Texture(BitmapSamplePath);
            using Texture copy = new Texture(original);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
        }

        /// <summary>
        ///     Tests that the size property is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_IsReadable()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            _ = texture.Size;
        }

        /// <summary>
        ///     Tests that the native handle is a non zero OpenGL identifier
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_IsNonZero()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.NotEqual(0u, texture.NativeHandle);
        }

        /// <summary>
        ///     Tests that the smooth property round trips true and false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_RoundTrips()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            texture.Smooth = true;
            Assert.True(texture.Smooth);
            texture.Smooth = false;
            Assert.False(texture.Smooth);
        }

        /// <summary>
        ///     Tests that the repeated property round trips true and false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_RoundTrips()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            texture.Repeated = true;
            Assert.True(texture.Repeated);
            texture.Repeated = false;
            Assert.False(texture.Repeated);
        }

        /// <summary>
        ///     Tests that the srgb getter is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Srgb_Get_IsReadable()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            _ = texture.Srgb;
        }

        /// <summary>
        ///     Tests that the srgb setter throws the missing entry point error of the installed CSFML 3.0 library
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Srgb_Set_ThrowsEntryPointNotFound()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.Throws<EntryPointNotFoundException>(() => texture.Srgb = false);
        }

        /// <summary>
        ///     Tests that the maximum size property is greater than zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumSize_IsGreaterThanZero()
        {
            Assert.True(Texture.MaximumSize > 0);
        }

        /// <summary>
        ///     Tests that copy to image returns a valid image
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyToImage_ReturnsValidImage()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                using Image image = texture.CopyToImage();
                Assert.NotEqual(IntPtr.Zero, image.CPointer);
            });
        }

        /// <summary>
        ///     Tests that updating from a pixel array of the texture size does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Pixels_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            byte[] pixels = new byte[TextureWidth * TextureHeight * 4];
            WithContext(() =>
            {
                texture.Update(pixels);
            });
        }

        /// <summary>
        ///     Tests that updating from a pixel array with explicit dimensions does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_PixelsWithSize_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            byte[] pixels = new byte[TextureWidth * TextureHeight * 4];
            WithContext(() =>
            {
                texture.Update(pixels, TextureWidth, TextureHeight, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that updating from a source texture does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Texture_DoesNotThrow()
        {
            using Texture source = new Texture(BitmapSamplePath);
            using Texture target = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                target.Update(source, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that updating from an image does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Image_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                texture.Update(image);
            });
        }

        /// <summary>
        ///     Tests that updating from an image with an offset does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_ImageWithOffset_DoesNotThrow()
        {
            using Image image = new Image(BitmapSamplePath);
            using Texture texture = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                texture.Update(image, 4, 4);
            });
        }

        /// <summary>
        ///     Tests that generating a mipmap returns a boolean without throwing
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GenerateMipmap_ReturnsBoolean()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                _ = texture.GenerateMipmap();
            });
        }

        /// <summary>
        ///     Tests that swapping two textures does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Swap_DoesNotThrow()
        {
            using Texture left = new Texture(BitmapSamplePath);
            using Texture right = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                left.Swap(right);
            });
        }

        /// <summary>
        ///     Tests that binding a texture and binding null do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_WithTextureAndNull_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            WithContext(() =>
            {
                Texture.Bind(texture);
                Texture.Bind(null);
            });
        }

        /// <summary>
        ///     Tests that the string description contains the texture marker
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ContainsTextureMarker()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            Assert.StartsWith("[Texture]", texture.ToString());
        }

        /// <summary>
        ///     Tests that destroying the texture clears the native pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_ClearsNativePointer()
        {
            Texture texture = new Texture(BitmapSamplePath);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
            texture.Dispose();
            Assert.Equal(IntPtr.Zero, texture.CPointer);
        }
    }
}
