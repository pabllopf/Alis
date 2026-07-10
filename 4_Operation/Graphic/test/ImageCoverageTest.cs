using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public partial class ImageTest
    {
        [Fact]
        public void LoadFromStream_When16BitBmp_ThrowsNotSupportedException()
        {
            using MemoryStream stream = CreateBmp16Bit(2, 2);
            MethodInfo loadMethod = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static);
            var ex = Assert.Throws<TargetInvocationException>(() =>
                loadMethod.Invoke(null, new object[] { stream }));
            Assert.IsType<NotSupportedException>(ex.InnerException);
        }

        [Fact]
        public void LoadFromStream_WhenBitfields32Bit_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpBitfields32Bit(2, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(2, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle8Encoded_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle8(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle8EndOfLine_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle8EndOfLine(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle8Delta_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle8Delta(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle8AbsoluteMode_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle8Absolute(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle4Encoded_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle4(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle4EndOfLine_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle4EndOfLine(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle4Delta_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle4Delta(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle4AbsoluteMode_ReturnsCorrectImage()
        {
            using MemoryStream stream = CreateBmpRle4Absolute(4, 2);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(4, image.Width);
            Assert.Equal(2, image.Height);
        }

        [Fact]
        public void LoadFromStream_WhenRle8OddAbsoluteCount_SkipsPadding()
        {
            using MemoryStream stream = CreateBmpRle8Absolute(5, 1);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
        }

        [Fact]
        public void LoadFromStream_When24BitWidthNotAligned_LoadsCorrectly()
        {
            using MemoryStream stream = CreateMinimalBmp24Bit(3, 3);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
            Assert.Equal(3, image.Width);
            Assert.Equal(3, image.Height);
            Assert.Equal(36, image.Data.Length);
        }

        #region BMP Helper Methods for Coverage

        private static MemoryStream CreateBmp16Bit(int width, int height)
        {
            int pixelDataPerRow = width * 2;
            int rowSize = (pixelDataPerRow + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, 54);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)16);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            int offset = 54;
            for (int y = 0; y < height; y++)
            {
                int rowStart = offset;
                for (int x = 0; x < width; x++)
                {
                    bmp[offset++] = 0; bmp[offset++] = 0;
                }
                while (offset - rowStart < rowSize) bmp[offset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpBitfields32Bit(int width, int height)
        {
            int headerSize = 56;
            int paletteSize = 0;
            int pixelDataPerRow = width * 4;
            int rowSize = (pixelDataPerRow + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int pixelDataOffset = 14 + headerSize + paletteSize;
            int fileSize = pixelDataOffset + imageSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, (uint)headerSize);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)32);
            WriteLittleEndian(bmp, 32, 3);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            int bitfieldsOffset = 14 + headerSize;
            byte[] masks = new byte[16];
            BitConverter.GetBytes(0x00FF0000).CopyTo(masks, 0);
            BitConverter.GetBytes(0x0000FF00).CopyTo(masks, 4);
            BitConverter.GetBytes(0x000000FF).CopyTo(masks, 8);
            BitConverter.GetBytes(0xFF000000).CopyTo(masks, 12);
            Buffer.BlockCopy(masks, 0, bmp, bitfieldsOffset, 16);
            int offset = pixelDataOffset;
            for (int y = 0; y < height; y++)
            {
                int rowStart = offset;
                for (int x = 0; x < width; x++)
                {
                    bmp[offset++] = 255; bmp[offset++] = 128;
                    bmp[offset++] = 64;  bmp[offset++] = 255;
                }
                while (offset - rowStart < rowSize) bmp[offset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle8(int width, int height)
        {
            int paletteSize = 256 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = height * (2 + 2);
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 32, 1);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 256);
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)i;
                bmp[paletteOffset + i * 4 + 2] = (byte)i;
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            for (int y = 0; y < height; y++)
            {
                bmp[rleOffset++] = (byte)width;
                bmp[rleOffset++] = 1;
                bmp[rleOffset++] = 0;
                bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle8EndOfLine(int width, int height)
        {
            int paletteSize = 256 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = 4 + (height - 1) * 2;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 32, 1);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 256);
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)i;
                bmp[paletteOffset + i * 4 + 2] = (byte)i;
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = (byte)width; bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            for (int y = 1; y < height; y++)
            {
                bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle8Delta(int width, int height)
        {
            int paletteSize = 256 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = 8;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 32, 1);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 256);
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)i;
                bmp[paletteOffset + i * 4 + 2] = (byte)i;
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = (byte)width; bmp[rleOffset++] = 1;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 2;
            bmp[rleOffset++] = 1; bmp[rleOffset++] = 1;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle8Absolute(int width, int height)
        {
            int paletteSize = 256 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = 4 + width + (width % 2 == 1 ? 1 : 0) + 2;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 32, 1);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 256);
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)i;
                bmp[paletteOffset + i * 4 + 2] = (byte)i;
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int i = 0; i < width; i++)
                bmp[rleOffset++] = (byte)(i % 256);
            if (width % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle4(int width, int height)
        {
            int paletteSize = 16 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = height * (2 + 2);
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 32, 2);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 16);
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            for (int y = 0; y < height; y++)
            {
                bmp[rleOffset++] = (byte)(width / 2);
                bmp[rleOffset++] = 0x10;
                bmp[rleOffset++] = 0;
                bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle4EndOfLine(int width, int height)
        {
            int paletteSize = 16 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = 4 + (height - 1) * 2;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 32, 2);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 16);
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = (byte)(width / 2); bmp[rleOffset++] = 0x10;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            for (int y = 1; y < height; y++)
            {
                bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle4Delta(int width, int height)
        {
            int paletteSize = 16 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int rleDataSize = 8;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 32, 2);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 16);
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = (byte)(width / 2); bmp[rleOffset++] = 0x10;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 2;
            bmp[rleOffset++] = 1; bmp[rleOffset++] = 1;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        private static MemoryStream CreateBmpRle4Absolute(int width, int height)
        {
            int paletteSize = 16 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int pairs = (width + 1) / 2;
            int rleDataSize = 4 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 32, 2);
            WriteLittleEndian(bmp, 36, (uint)rleDataSize);
            WriteLittleEndian(bmp, 48, 16);
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            int rleOffset = pixelDataOffset;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int i = 0; i < pairs; i++)
            {
                byte high = (byte)(((i * 2) % 16) << 4);
                byte low = (byte)((i * 2 + 1) % 16);
                bmp[rleOffset++] = (byte)(high | low);
            }
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        #endregion
    }
}
