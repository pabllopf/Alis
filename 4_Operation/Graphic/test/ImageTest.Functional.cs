// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageTest.Functional.cs
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
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Functional tests for the Image class validating actual BMP loading functionality.
    /// </summary>
    public partial class ImageTest
    {
        #region Valid BMP Loading Tests

        /// <summary>
        ///     Tests loading a minimal 24-bit BMP image.
        /// </summary>
        [Fact]
        public void LoadFromStream_When24BitBmp_ReturnsCorrectImage()
        {
            string path = WriteTempBmp(CreateMinimalBmp24Bit(2, 2));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
            Assert.Equal(2 * 2 * 4, image.Data.Length);
        }


        /// <summary>
        ///     Tests loading an 8-bit indexed BMP with palette.
        /// </summary>
        [Fact]
        public void LoadFromStream_When8BitIndexed_ReturnsCorrectPaletteColors()
        {
            string path = WriteTempBmp(CreateMinimalBmp8BitIndexed(2, 2));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
        }

        /// <summary>
        ///     Tests loading a 4-bit indexed BMP with palette.
        /// </summary>
        [Fact]
        public void LoadFromStream_When4BitIndexed_ReturnsCorrectImage()
        {
            string path = WriteTempBmp(CreateMinimalBmp4BitIndexed(2, 2));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
            Assert.Equal(2 * 2 * 4, image.Data.Length);
        }

        
        #endregion

        #region Error Handling Tests
        
        /// <summary>
        ///     Tests loading a 32-bit BMP with alpha channel.
        /// </summary>
        [Fact]
        public void LoadFromStream_When32BitBmp_ReturnsCorrectImage()
        {
            string path = WriteTempBmp(CreateMinimalBmp32Bit(2, 2));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
            Assert.Equal(2 * 2 * 4, image.Data.Length);
        }

        /// <summary>
        ///     Tests loading a 1-bit monochrome BMP with palette.
        /// </summary>
        [Fact]
        public void LoadFromStream_When1BitMonochrome_ReturnsCorrectImage()
        {
            string path = WriteTempBmp(CreateMinimalBmp1Bit(2, 2));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
            Assert.Equal(2 * 2 * 4, image.Data.Length);
        }

        /// <summary>
        ///     Tests that invalid BMP header throws an exception.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenInvalidHeader_ThrowsException()
        {
            byte[] bmp = new byte[54];
            bmp[0] = (byte)'X';
            bmp[1] = (byte)'M';
            string path = WriteTempBmp(bmp);

            Assert.ThrowsAny<Exception>(() => Image.Load(path));
        }

        /// <summary>
        ///     Tests that unsupported BMP compression type throws an exception.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenUnsupportedCompression_ThrowsException()
        {
            string path = WriteTempBmp(CreateBmpWithUnsupportedCompression());
            Assert.ThrowsAny<Exception>(() => Image.Load(path));
        }

        /// <summary>
        ///     Tests that empty stream throws exception.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenEmptyStream_ThrowsException()
        {
            string path = WriteTempBmp(Array.Empty<byte>());
            Assert.ThrowsAny<Exception>(() => Image.Load(path));
        }

        #endregion

        #region Edge Cases

        /// <summary>
        ///     Tests that a BMP with negative height (top-down) loads correctly.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenNegativeHeight_LoadsCorrectly()
        {
            string path = WriteTempBmp(CreateBmpWithNegativeHeight(2, 2));
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
        }

        /// <summary>
        ///     Tests loading a 1x1 pixel image.
        /// </summary>
        [Fact]
        public void LoadFromStream_When1x1Image_ReturnsMinimalValidImage()
        {
            string path = WriteTempBmp(CreateMinimalBmp24Bit(1, 1));
            Image image = Image.Load(path);

            Assert.NotNull(image);
            Assert.Equal(1, image.Width);
            Assert.Equal(1, image.Height);
            Assert.Equal(4, image.Data.Length);
        }

        #endregion

        #region Helper Methods to Create BMP Byte Arrays

        /// <summary>
        ///     Creates a minimal valid 24-bit BMP file in memory.
        /// </summary>
        private static byte[] CreateMinimalBmp24Bit(int width, int height)
        {
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255;
                    bmp[pixelOffset++] = 128;
                    bmp[pixelOffset++] = 64;
                }
                while ((pixelOffset % 4 != 0) && (pixelOffset < 54 + rowSize * (y + 1)))
                {
                    bmp[pixelOffset++] = 0;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a minimal valid 32-bit BMP file with alpha channel.
        /// </summary>
        private static byte[] CreateMinimalBmp32Bit(int width, int height)
        {
            int rowSize = (width * 4 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)32);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255;
                    bmp[pixelOffset++] = 128;
                    bmp[pixelOffset++] = 64;
                    bmp[pixelOffset++] = 255;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a minimal 8-bit indexed BMP with palette.
        /// </summary>
        private static byte[] CreateMinimalBmp8BitIndexed(int width, int height)
        {
            int paletteSize = 256 * 4;
            int rowSize = (width + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 256);
            WriteLittleEndian(bmp, 52, 0);
            
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)(i / 2);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i / 4);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            
            int pixelOffset = 54 + paletteSize;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = (byte)((x + y) % 256);
                }
                while ((pixelOffset % 4 != 0) && (pixelOffset < 54 + paletteSize + rowSize * (y + 1)))
                {
                    bmp[pixelOffset++] = 0;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a minimal 4-bit indexed BMP.
        /// </summary>
        private static byte[] CreateMinimalBmp4BitIndexed(int width, int height)
        {
            int paletteSize = 16 * 4;
            int pixelDataPerRow = (width + 1) / 2;
            int rowSize = (pixelDataPerRow + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 16);
            WriteLittleEndian(bmp, 52, 0);
            
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 16);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 8);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 4);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            
            int pixelOffset = 54 + paletteSize;
            for (int y = 0; y < height; y++)
            {
                int rowStart = pixelOffset;
                for (int x = 0; x < width; x += 2)
                {
                    byte high = (byte)(x % 16);
                    byte low = (byte)((x + 1) % 16);
                    bmp[pixelOffset++] = (byte)((high << 4) | low);
                }
                int written = pixelOffset - rowStart;
                while (written < rowSize)
                {
                    bmp[pixelOffset++] = 0;
                    written++;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a minimal 1-bit monochrome BMP.
        /// </summary>
        private static byte[] CreateMinimalBmp1Bit(int width, int height)
        {
            int paletteSize = 2 * 4;
            int pixelDataPerRow = (width + 7) / 8;
            int rowSize = (pixelDataPerRow + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)1);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 2);
            WriteLittleEndian(bmp, 52, 0);
            
            int paletteOffset = 54;
            bmp[paletteOffset] = 0; bmp[paletteOffset + 1] = 0; bmp[paletteOffset + 2] = 0; bmp[paletteOffset + 3] = 255;
            bmp[paletteOffset + 4] = 255; bmp[paletteOffset + 5] = 255; bmp[paletteOffset + 6] = 255; bmp[paletteOffset + 7] = 255;
            
            int pixelOffset = 54 + paletteSize;
            for (int y = 0; y < height; y++)
            {
                int rowStart = pixelOffset;
                byte pixelByte = 0;
                for (int x = 0; x < width; x++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        pixelByte |= (byte)(1 << (7 - x % 8));
                    }
                    if (x % 8 == 7 || x == width - 1)
                    {
                        bmp[pixelOffset++] = pixelByte;
                        pixelByte = 0;
                    }
                }
                int written = pixelOffset - rowStart;
                while (written < rowSize)
                {
                    bmp[pixelOffset++] = 0;
                    written++;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a BMP with unsupported compression type.
        /// </summary>
        private static byte[] CreateBmpWithUnsupportedCompression()
        {
            int width = 2;
            int height = 2;
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 4);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255;
                    bmp[pixelOffset++] = 128;
                    bmp[pixelOffset++] = 64;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Creates a BMP with negative height (bottom-up).
        /// </summary>
        private static byte[] CreateBmpWithNegativeHeight(int width, int height)
        {
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)-height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255;
                    bmp[pixelOffset++] = 128;
                    bmp[pixelOffset++] = 64;
                }
            }

            return bmp;
        }

        /// <summary>
        ///     Writes a 32-bit value to byte array in little-endian format.
        /// </summary>
        private static void WriteLittleEndian(byte[] buffer, int offset, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
            }
            else
            {
                Buffer.BlockCopy(bytes, 3, buffer, offset, 1);
                Buffer.BlockCopy(bytes, 2, buffer, offset + 1, 1);
                Buffer.BlockCopy(bytes, 1, buffer, offset + 2, 1);
                Buffer.BlockCopy(bytes, 0, buffer, offset + 3, 1);
            }
        }

        #endregion
    }
}