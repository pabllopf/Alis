using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// The image test class
    /// </summary>
    public partial class ImageTest
    {
        /// <summary>
        /// Tests that load from stream when 16 bit bmp throws not supported exception
        /// </summary>
        [Fact]
        public void LoadFromStream_When16BitBmp_ThrowsNotSupportedException()
        {
            using MemoryStream stream = CreateBmp16Bit(2, 2);
            MethodInfo loadMethod = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static);
            var ex = Assert.Throws<TargetInvocationException>(() =>
                loadMethod.Invoke(null, new object[] { stream }));
            Assert.IsType<NotSupportedException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that load from stream when bitfields 32 bit returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 8 encoded returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 8 end of line returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 8 delta returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 8 absolute mode returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 4 encoded returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 4 end of line returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 4 delta returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 4 absolute mode returns correct image
        /// </summary>
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

        /// <summary>
        /// Tests that load from stream when rle 8 odd absolute count skips padding
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8OddAbsoluteCount_SkipsPadding()
        {
            using MemoryStream stream = CreateBmpRle8Absolute(5, 1);
            Image image = typeof(Image).GetMethod("LoadFromStream", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { stream }) as Image;
            Assert.NotNull(image);
        }

        /// <summary>
        /// Tests that load from stream when 24 bit width not aligned loads correctly
        /// </summary>
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

        /// <summary>
        /// Creates the bmp 16 bit using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmp16Bit(int width, int height)
        {
            int rowSize = (width * 2 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, 54u);
            WriteLittleEndian(bmp, 14, 40u);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)16);
            WriteLittleEndian(bmp, 30, 0u);
            WriteLittleEndian(bmp, 34, (uint)imageSize);
            int offset = 54;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                { bmp[offset++] = 0; bmp[offset++] = 0; }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp bitfields 32 bit using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpBitfields32Bit(int width, int height)
        {
            int headerSize = 56;
            int pixelDataOffset = 14 + headerSize;
            int rowSize = width * 4;
            int imageSize = rowSize * height;
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
            WriteLittleEndian(bmp, 30, 3u);
            WriteLittleEndian(bmp, 34, (uint)imageSize);
            int masksOffset = 14 + headerSize;
            BitConverter.GetBytes(0x00FF0000u).CopyTo(bmp, masksOffset);
            BitConverter.GetBytes(0x0000FF00u).CopyTo(bmp, masksOffset + 4);
            BitConverter.GetBytes(0x000000FFu).CopyTo(bmp, masksOffset + 8);
            BitConverter.GetBytes(0xFF000000u).CopyTo(bmp, masksOffset + 12);
            int offset = pixelDataOffset;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                { bmp[offset++] = 255; bmp[offset++] = 128; bmp[offset++] = 64; bmp[offset++] = 255; }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Builds the rle 8 header using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="rleDataSize">The rle data size</param>
        /// <param name="paletteSize">The palette size</param>
        /// <returns>The bmp</returns>
        private static byte[] BuildRle8Header(int width, int height, int rleDataSize, int paletteSize)
        {
            int pixelDataOffset = 14 + 40 + paletteSize;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40u);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)8);
            WriteLittleEndian(bmp, 30, 1u);
            WriteLittleEndian(bmp, 34, (uint)rleDataSize);
            WriteLittleEndian(bmp, 46, 256u);
            int paletteOffset = 54;
            for (int i = 0; i < 256; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)i;
                bmp[paletteOffset + i * 4 + 1] = (byte)i;
                bmp[paletteOffset + i * 4 + 2] = (byte)i;
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            return bmp;
        }

        /// <summary>
        /// Builds the rle 4 header using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="rleDataSize">The rle data size</param>
        /// <returns>The bmp</returns>
        private static byte[] BuildRle4Header(int width, int height, int rleDataSize)
        {
            int paletteSize = 16 * 4;
            int pixelDataOffset = 14 + 40 + paletteSize;
            int fileSize = pixelDataOffset + rleDataSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B'; bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, 40u);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)4);
            WriteLittleEndian(bmp, 30, 2u);
            WriteLittleEndian(bmp, 34, (uint)rleDataSize);
            WriteLittleEndian(bmp, 46, 16u);
            int paletteOffset = 54;
            for (int i = 0; i < 16; i++)
            {
                bmp[paletteOffset + i * 4 + 0] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 1] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 2] = (byte)(i * 17);
                bmp[paletteOffset + i * 4 + 3] = 255;
            }
            return bmp;
        }

        /// <summary>
        /// Creates the bmp rle 8 using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle8(int width, int height)
        {
            int absModeSize = 2 + width + (width % 2 == 1 ? 1 : 0) + 2;
            int rleDataSize = absModeSize * height;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            for (int y = 0; y < height; y++)
            {
                bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
                for (int x = 0; x < width; x++) bmp[rleOffset++] = 1;
                if (width % 2 == 1) bmp[rleOffset++] = 0;
                bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 8 end of line using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle8EndOfLine(int width, int height)
        {
            int absModeSize = 2 + width + (width % 2 == 1 ? 1 : 0) + 2;
            int rleDataSize = absModeSize + (height - 1) * 2;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int x = 0; x < width; x++) bmp[rleOffset++] = 1;
            if (width % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            for (int y = 1; y < height; y++)
            { bmp[rleOffset++] = 0; bmp[rleOffset++] = 0; }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 8 delta using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle8Delta(int width, int height)
        {
            int absModeSize = 2 + width + (width % 2 == 1 ? 1 : 0);
            int rleDataSize = absModeSize + 6;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int x = 0; x < width; x++) bmp[rleOffset++] = 1;
            if (width % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 2;
            bmp[rleOffset++] = 1; bmp[rleOffset++] = 1;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 8 absolute using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle8Absolute(int width, int height)
        {
            int rleDataSize = 4 + width + (width % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int i = 0; i < width; i++) bmp[rleOffset++] = (byte)(i % 256);
            if (width % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 4 using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle4(int width, int height)
        {
            int rleDataSize = height * (4 + 2);
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            for (int y = 0; y < height; y++)
            {
                bmp[rleOffset++] = (byte)(width / 2);
                bmp[rleOffset++] = (byte)((1 << 4) | 2);
                bmp[rleOffset++] = 0;
                bmp[rleOffset++] = 0;
            }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 4 end of line using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle4EndOfLine(int width, int height)
        {
            int rleDataSize = 4 + 2 + (height - 1) * 2;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = (byte)(width / 2);
            bmp[rleOffset++] = (byte)((1 << 4) | 2);
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            for (int y = 1; y < height; y++)
            { bmp[rleOffset++] = 0; bmp[rleOffset++] = 0; }
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 4 delta using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle4Delta(int width, int height)
        {
            int rleDataSize = 4 + 6;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = (byte)(width / 2);
            bmp[rleOffset++] = (byte)((1 << 4) | 2);
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 2;
            bmp[rleOffset++] = 1; bmp[rleOffset++] = 1;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        /// <summary>
        /// Creates the bmp rle 4 absolute using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream CreateBmpRle4Absolute(int width, int height)
        {
            int pairs = (width + 1) / 2;
            int rleDataSize = 4 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = (byte)width;
            for (int i = 0; i < pairs; i++)
                bmp[rleOffset++] = (byte)(((i * 2 % 16) << 4) | ((i * 2 + 1) % 16));
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0; bmp[rleOffset++] = 0;
            return new MemoryStream(bmp);
        }

        #endregion
    }
}
