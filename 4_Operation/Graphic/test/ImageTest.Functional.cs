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
using System.IO;
using System.Reflection;
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
            // Create minimal valid 24-bit BMP file in memory
            using MemoryStream stream = CreateMinimalBmp24Bit(2, 2);
            
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
            Assert.NotNull(image.Data);
            Assert.Equal(2 * 2 * 4, image.Data.Length); // RGBA
        }


        /// <summary>
        ///     Tests loading an 8-bit indexed BMP with palette.
        /// </summary>
        [Fact]
        public void LoadFromStream_When8BitIndexed_ReturnsCorrectPaletteColors()
        {
            using MemoryStream stream = CreateMinimalBmp8BitIndexed(2, 2);
            
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

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
            using MemoryStream stream = CreateMinimalBmp4BitIndexed(2, 2);

            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

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
            using MemoryStream stream = CreateMinimalBmp32Bit(2, 2);

            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

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
            using MemoryStream stream = CreateMinimalBmp1Bit(2, 2);

            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

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
            using MemoryStream stream = CreateInvalidBmpHeader();

            MethodInfo loadMethod = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.ThrowsAny<Exception>(() =>
                loadMethod.Invoke(null, new object[] { stream }));
        }

        /// <summary>
        ///     Tests that unsupported BMP compression type throws an exception.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenUnsupportedCompression_ThrowsException()
        {
            using MemoryStream stream = CreateBmpWithUnsupportedCompression();

            MethodInfo loadMethod = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.ThrowsAny<Exception>(() =>
                loadMethod.Invoke(null, new object[] { stream }));
        }

        /// <summary>
        ///     Tests that empty stream throws exception.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenEmptyStream_ThrowsException()
        {
            using MemoryStream stream = new MemoryStream(Array.Empty<byte>());
            
            MethodInfo loadMethod = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static);
            
            Assert.ThrowsAny<Exception>(() => 
                loadMethod.Invoke(null, new object[] { stream }));
        }

        #endregion

        #region Edge Cases

        /// <summary>
        ///     Tests loading a 1x1 pixel image.
        /// </summary>
        [Fact]
        public void LoadFromStream_When1x1Image_ReturnsMinimalValidImage()
        {
            using MemoryStream stream = CreateMinimalBmp24Bit(1, 1);
            
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;

            Assert.NotNull(image);
            Assert.Equal(1, image.Width);
            Assert.Equal(1, image.Height);
            Assert.Equal(4, image.Data.Length); // 1x1 RGBA
        }


        #endregion

        #region Helper Methods to Create BMP Byte Arrays

        /// <summary>
        ///     Creates a minimal valid 24-bit BMP file in memory.
        /// </summary>
        private static MemoryStream CreateMinimalBmp24Bit(int width, int height)
        {
            int rowSize = (width * 3 + 3) / 4 * 4; // Padded row size
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header (14 bytes)
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize); // File size
            WriteLittleEndian(bmp, 6, 0); // Reserved
            WriteLittleEndian(bmp, 10, 54); // Pixel data offset
            
            // DIB Header (40 bytes - BITMAPINFOHEADER)
            WriteLittleEndian(bmp, 14, 40); // Header size
            WriteLittleEndian(bmp, 18, (uint)width); // Width
            WriteLittleEndian(bmp, 22, (uint)height); // Height
            WriteLittleEndian(bmp, 26, (ushort)1); // Color planes
            WriteLittleEndian(bmp, 28, (ushort)24); // Bits per pixel
            WriteLittleEndian(bmp, 32, 0); // Compression (0 = none)
            WriteLittleEndian(bmp, 36, (uint)imageSize); // Image size
            WriteLittleEndian(bmp, 40, 2835); // Horizontal resolution
            WriteLittleEndian(bmp, 44, 2835); // Vertical resolution
            WriteLittleEndian(bmp, 48, 0); // Colors used
            WriteLittleEndian(bmp, 52, 0); // Important colors
            
            // Pixel data (RGB, no padding for 2x2)
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255; // Blue
                    bmp[pixelOffset++] = 128; // Green
                    bmp[pixelOffset++] = 64;  // Red
                }
                // Padding
                while ((pixelOffset % 4 != 0) && (pixelOffset < 54 + rowSize * (y + 1)))
                {
                    bmp[pixelOffset++] = 0;
                }
            }

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a minimal valid 32-bit BMP file with alpha channel.
        /// </summary>
        private static MemoryStream CreateMinimalBmp32Bit(int width, int height)
        {
            int rowSize = (width * 4 + 3) / 4 * 4; // Padded row size (already multiple of 4)
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            // DIB Header
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)32); // 32 bits per pixel
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            // Pixel data (BGRA)
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255; // Blue
                    bmp[pixelOffset++] = 128; // Green
                    bmp[pixelOffset++] = 64;  // Red
                    bmp[pixelOffset++] = 255; // Alpha (opaque)
                }
            }

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a minimal 8-bit indexed BMP with palette.
        /// </summary>
        private static MemoryStream CreateMinimalBmp8BitIndexed(int width, int height)
        {
            int paletteSize = 256 * 4; // 256 entries * 4 bytes (BGRA)
            int rowSize = (width + 3) / 4 * 4; // Padded for 8-bit
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            // DIB Header
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8); // 8 bits per pixel
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 256); // Colors used
            WriteLittleEndian(bmp, 52, 0);
            
            // Palette (256 entries)
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i; // Blue
                bmp[paletteOffset + i * 4 + 1] = (byte)(i / 2); // Green
                bmp[paletteOffset + i * 4 + 2] = (byte)(i / 4); // Red
                bmp[paletteOffset + i * 4 + 3] = 255; // Alpha
            }
            
            // Pixel indices
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

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a minimal 4-bit indexed BMP.
        /// </summary>
        private static MemoryStream CreateMinimalBmp4BitIndexed(int width, int height)
        {
            int paletteSize = 16 * 4; // 16 entries for 4-bit
            int pixelDataPerRow = (width + 1) / 2; // 2 pixels per byte
            int rowSize = (pixelDataPerRow + 3) / 4 * 4; // Padded to 4-byte boundary
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            // DIB Header
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4); // 4 bits per pixel
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 16); // Colors used
            WriteLittleEndian(bmp, 52, 0);
            
            // Palette (16 entries)
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 16);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 8);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 4);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            
            // Pixel indices (packed 2 per byte) with 4-byte row alignment
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

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a minimal 1-bit monochrome BMP.
        /// </summary>
        private static MemoryStream CreateMinimalBmp1Bit(int width, int height)
        {
            int paletteSize = 2 * 4; // 2 entries for 1-bit
            int pixelDataPerRow = (width + 7) / 8; // 8 pixels per byte
            int rowSize = (pixelDataPerRow + 3) / 4 * 4; // Padded to 4-byte boundary
            int imageSize = rowSize * height;
            int fileSize = 54 + paletteSize + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, (uint)(54 + paletteSize));
            
            // DIB Header
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)1); // 1 bit per pixel
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 2); // Colors used
            WriteLittleEndian(bmp, 52, 0);
            
            // Palette (2 entries)
            int paletteOffset = 54;
            bmp[paletteOffset] = 0; bmp[paletteOffset + 1] = 0; bmp[paletteOffset + 2] = 0; bmp[paletteOffset + 3] = 255; // Black
            bmp[paletteOffset + 4] = 255; bmp[paletteOffset + 5] = 255; bmp[paletteOffset + 6] = 255; bmp[paletteOffset + 7] = 255; // White
            
            // Pixel data (1 bit per pixel, 8 pixels per byte) with 4-byte row alignment
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

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates an invalid BMP file with wrong header.
        /// </summary>
        private static MemoryStream CreateInvalidBmpHeader()
        {
            byte[] bmp = new byte[54];
            bmp[0] = (byte)'X'; // Wrong header - should be 'B'
            bmp[1] = (byte)'M';
            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a BMP with unsupported compression type.
        /// </summary>
        private static MemoryStream CreateBmpWithUnsupportedCompression()
        {
            int width = 2;
            int height = 2;
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            // DIB Header with unsupported compression (type 4)
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 4); // Unsupported compression type
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            // Pixel data
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

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a BMP with negative height (bottom-up).
        /// </summary>
        private static MemoryStream CreateBmpWithNegativeHeight(int width, int height)
        {
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;

            byte[] bmp = new byte[fileSize];
            
            // BMP File Header
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            
            // DIB Header with negative height
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)-height); // Negative height
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            
            // Pixel data
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

            return new MemoryStream(bmp);
        }

        /// <summary>
        ///     Creates a stream with 8-bit palette data.
        /// </summary>
        private static MemoryStream CreateStreamWith8BitPalette()
        {
            byte[] data = new byte[256 * 4];
            for (int i = 0; i < 256; i++)
            {
                data[i * 4 + 0] = (byte)i;
                data[i * 4 + 1] = (byte)(i / 2);
                data[i * 4 + 2] = (byte)(i / 4);
                data[i * 4 + 3] = 255;
            }
            return new MemoryStream(data);
        }

        /// <summary>
        ///     Creates a stream with 4-bit palette data.
        /// </summary>
        private static MemoryStream CreateStreamWith4BitPalette()
        {
            byte[] data = new byte[16 * 4];
            for (int i = 0; i < 16; i++)
            {
                data[i * 4 + 0] = (byte)(i * 16);
                data[i * 4 + 1] = (byte)(i * 8);
                data[i * 4 + 2] = (byte)(i * 4);
                data[i * 4 + 3] = 255;
            }
            return new MemoryStream(data);
        }

        /// <summary>
        ///     Creates a stream with 1-bit palette data.
        /// </summary>
        private static MemoryStream CreateStreamWith1BitPalette()
        {
            byte[] data = new byte[2 * 4];
            data[0] = 0; data[1] = 0; data[2] = 0; data[3] = 255; // Black
            data[4] = 255; data[5] = 255; data[6] = 255; data[7] = 255; // White
            return new MemoryStream(data);
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
