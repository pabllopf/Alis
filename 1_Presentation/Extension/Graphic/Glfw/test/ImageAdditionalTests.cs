// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageAdditionalTests.cs
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    /// The image additional tests class
    /// </summary>
    public class ImageAdditionalTests
    {
        /// <summary>
        /// Creates the bmp with bit depth using the specified bits per pixel
        /// </summary>
        /// <param name="bitsPerPixel">The bits per pixel</param>
        /// <returns>The temp file</returns>
        private static string CreateBmpWithBitDepth(int bitsPerPixel)
        {
            string tempFile = Path.GetTempFileName() + ".bmp";
            int width = 2;
            int height = 2;
            int pixelDataOffset = 54 + (bitsPerPixel == 32 ? 0 : 0);
            if (bitsPerPixel <= 8)
            {
                pixelDataOffset = 54 + 256 * 4;
            }

            int rowSize = (width * bitsPerPixel + 31) / 32 * 4;
            int pixelDataSize = rowSize * height;

            using (BinaryWriter writer = new BinaryWriter(File.Create(tempFile)))
            {
                writer.Write((byte)'B');
                writer.Write((byte)'M');
                writer.Write(14 + 40 + (pixelDataOffset - 54) + pixelDataSize);
                writer.Write((ushort)0);
                writer.Write((ushort)0);
                writer.Write(pixelDataOffset);

                writer.Write(40);
                writer.Write(width);
                writer.Write(height);
                writer.Write((ushort)1);
                writer.Write((ushort)bitsPerPixel);
                writer.Write(0);
                writer.Write(pixelDataSize);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0);

                if (bitsPerPixel <= 8)
                {
                    for (int i = 0; i < 256; i++)
                    {
                        writer.Write((byte)i);
                        writer.Write((byte)i);
                        writer.Write((byte)i);
                        writer.Write((byte)0);
                    }
                }

                writer.Write(new byte[pixelDataSize]);
            }
            return tempFile;
        }

        /// <summary>
        /// Creates the 24 bit bmp with padding using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The temp file</returns>
        private static string Create24BitBmpWithPadding(int width, int height)
        {
            string tempFile = Path.GetTempFileName() + ".bmp";
            int bitsPerPixel = 24;
            int bytesPerPixel = 3;
            int rowPadded = (width * bytesPerPixel + 3) & ~3;
            int pixelDataSize = rowPadded * height;
            int pixelDataOffset = 54;

            using (BinaryWriter writer = new BinaryWriter(File.Create(tempFile)))
            {
                writer.Write((byte)'B');
                writer.Write((byte)'M');
                writer.Write(14 + 40 + pixelDataSize);
                writer.Write((ushort)0);
                writer.Write((ushort)0);
                writer.Write(pixelDataOffset);

                writer.Write(40);
                writer.Write(width);
                writer.Write(height);
                writer.Write((ushort)1);
                writer.Write((ushort)bitsPerPixel);
                writer.Write(0);
                writer.Write(pixelDataSize);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0);

                byte[] pixelData = new byte[pixelDataSize];
                for (int y = 0; y < height; y++)
                {
                    int rowStart = y * rowPadded;
                    for (int x = 0; x < width; x++)
                    {
                        int offset = rowStart + x * 3;
                        pixelData[offset] = (byte)(x * 50);
                        pixelData[offset + 1] = (byte)(y * 50);
                        pixelData[offset + 2] = 128;
                    }
                }
                writer.Write(pixelData);
            }
            return tempFile;
        }

        /// <summary>
        /// Tests that image load with 8 bit bmp returns null
        /// </summary>
        [Fact]
        public void Image_Load_With8BitBmp_ReturnsNull()
        {
            string path = CreateBmpWithBitDepth(8);
            try
            {
                Image image = Image.Load(path);
                Assert.Null(image);
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that image load with 1 bit bmp returns null
        /// </summary>
        [Fact]
        public void Image_Load_With1BitBmp_ReturnsNull()
        {
            string path = CreateBmpWithBitDepth(1);
            try
            {
                Image image = Image.Load(path);
                Assert.Null(image);
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that image load with 16 bit bmp returns null
        /// </summary>
        [Fact]
        public void Image_Load_With16BitBmp_ReturnsNull()
        {
            string path = CreateBmpWithBitDepth(16);
            try
            {
                Image image = Image.Load(path);
                Assert.Null(image);
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that image load with 24 bit bmp with padding loads successfully
        /// </summary>
        [Fact]
        public void Image_Load_With24BitBmpWithPadding_LoadsSuccessfully()
        {
            string path = Create24BitBmpWithPadding(3, 3);
            try
            {
                Image image = Image.Load(path);
                Assert.NotNull(image);
                Assert.Equal(3, image.Width);
                Assert.Equal(3, image.Height);
                Assert.NotNull(image.Data);
                Assert.Equal(3 * 3 * 4, image.Data.Length);
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that image load with 24 bit bmp wide with padding loads successfully
        /// </summary>
        [Fact]
        public void Image_Load_With24BitBmpWideWithPadding_LoadsSuccessfully()
        {
            string path = Create24BitBmpWithPadding(5, 2);
            try
            {
                Image image = Image.Load(path);
                Assert.NotNull(image);
                Assert.Equal(5, image.Width);
                Assert.Equal(2, image.Height);
                Assert.NotNull(image.Data);
                Assert.Equal(5 * 2 * 4, image.Data.Length);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
