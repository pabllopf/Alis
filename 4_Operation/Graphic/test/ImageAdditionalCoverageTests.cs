using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Alis.Core.Aspect.Memory;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Additional coverage tests for Image class targeting uncovered lines.
    /// </summary>
    public partial class ImageTest
    {
        /// <summary>
        ///     Tests that DataSpan returns the same data as Data property.
        /// </summary>
        [Fact]
        public void DataSpan_ReturnsSameDataAsDataProperty()
        {
            string path = WriteTempBmp(CreateMinimalBmp24Bit(2, 2));
            Image image = Image.Load(path);
            Assert.Equal(image.Data.Length, image.DataSpan.Length);
            for (int i = 0; i < image.Data.Length; i++)
            {
                Assert.Equal(image.Data[i], image.DataSpan[i]);
            }
        }

        /// <summary>
        ///     Tests RLE8 encoded mode (count > 0) which exercises WriteEncodedPixels.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8EncodedMode_ReturnsCorrectImage()
        {
            int width = 4;
            int height = 1;
            int count = width;
            int rleDataSize = 2 + count * 4 + 2;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = (byte)count;
            bmp[rleOffset++] = 0;
            for (int p = 0; p < count; p++)
            {
                bmp[rleOffset++] = (byte)(p * 64 % 256);
                bmp[rleOffset++] = (byte)(p * 64 % 256);
                bmp[rleOffset++] = (byte)(p * 64 % 256);
                bmp[rleOffset++] = 255;
            }
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(width, image.Width);
            Assert.Equal(height, image.Height);
        }

        /// <summary>
        ///     Tests RLE8 encoded mode with wrap-around (x exceeds width in WriteEncodedPixels).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8EncodedModeWrapsAround_ReturnsCorrectImage()
        {
            int width = 4;
            int height = 2;
            int count = 6;
            int rleDataSize = 2 + count * 4 + 2;
            byte[] bmp = BuildRle8Header(width, height * 2, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = (byte)count;
            bmp[rleOffset++] = 0;
            for (int p = 0; p < count; p++)
            {
                bmp[rleOffset++] = (byte)(p * 40 % 256);
                bmp[rleOffset++] = (byte)(p * 40 % 256);
                bmp[rleOffset++] = (byte)(p * 40 % 256);
                bmp[rleOffset++] = 255;
            }
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests RLE8 absolute mode with wrap-around (x exceeds width in WriteAbsolutePixels).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8AbsoluteModeWrapsAround_ReturnsCorrectImage()
        {
            int width = 4;
            int height = 2;
            int absCount = 6;
            int rleDataSize = 2 + absCount + (absCount % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle8Header(width, height * 2, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            for (int i = 0; i < absCount; i++)
            {
                bmp[rleOffset++] = (byte)(i * 40 % 256);
            }
            if (absCount % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests RLE8 escape code with value 1 (absolute mode with odd count padding).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8EscapeCodeNonZeroNonTwo_HandlesAbsoluteMode()
        {
            int width = 4;
            int height = 1;
            int absCount = 3;
            int rleDataSize = 2 + absCount + (absCount % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle8Header(width, height, rleDataSize, 256 * 4);
            int rleOffset = 14 + 40 + 256 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            for (int i = 0; i < absCount; i++)
            {
                bmp[rleOffset++] = (byte)(i * 80 % 256);
            }
            if (absCount % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(width, image.Width);
            Assert.Equal(height, image.Height);
        }

        /// <summary>
        ///     Tests RLE4 encoded mode wrap-around (x exceeds width in WriteRle4Pixels).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle4EncodedModeWrapsAround_ReturnsCorrectImage()
        {
            int width = 4;
            int height = 2;
            int count = 6;
            int rleDataSize = 2 + 2;
            byte[] bmp = BuildRle4Header(width, height * 2, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = (byte)count;
            bmp[rleOffset++] = 0x10;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests RLE4 absolute mode with odd count triggering padding in HandleRle4EscapeCode.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle4AbsoluteModeOddCount_SkipsPadding()
        {
            int width = 4;
            int height = 1;
            int absCount = 3;
            int pairs = (absCount + 1) / 2;
            int rleDataSize = 2 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            for (int i = 0; i < pairs; i++)
            {
                bmp[rleOffset++] = (byte)((1 << 4) | 1);
            }
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(width, image.Width);
            Assert.Equal(height, image.Height);
        }

        /// <summary>
        ///     Tests RLE4 absolute mode with absCount=1 (padding condition absCount & 3 == 1).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle4AbsoluteModeCountOne_TriggersPadding()
        {
            int width = 4;
            int height = 1;
            int absCount = 1;
            int pairs = (absCount + 1) / 2;
            int rleDataSize = 2 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            bmp[rleOffset++] = 0x10;
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests RLE4 absolute mode with absCount=2 (padding condition absCount & 3 == 2).
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle4AbsoluteModeCountTwo_TriggersPadding()
        {
            int width = 4;
            int height = 1;
            int absCount = 2;
            int pairs = (absCount + 1) / 2;
            int rleDataSize = 2 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle4Header(width, height, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            bmp[rleOffset++] = 0x10;
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests RLE4 absolute mode with wrap-around in WriteRle4AbsolutePixels.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle4AbsoluteModeWrapsAround_ReturnsCorrectImage()
        {
            int width = 4;
            int height = 2;
            int absCount = 6;
            int pairs = (absCount + 1) / 2;
            int rleDataSize = 2 + pairs + (pairs % 2 == 1 ? 1 : 0) + 2;
            byte[] bmp = BuildRle4Header(width, height * 2, rleDataSize);
            int rleOffset = 14 + 40 + 16 * 4;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = (byte)absCount;
            for (int i = 0; i < pairs; i++)
            {
                bmp[rleOffset++] = (byte)((1 << 4) | 1);
            }
            if (pairs % 2 == 1) bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            bmp[rleOffset++] = 0;
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
        }

        /// <summary>
        ///     Tests successful LoadImageFromResources path with AssetRegistry setup.
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WhenValidResource_ReturnsImage()
        {
            string previous = SaveAndSetActive();
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(2, 2);
                string entryName = "test_image.bmp";
                byte[] zipBytes = CreateZipWithEntry(entryName, bmpData);
                string assyName = "GraphicTest_" + Guid.NewGuid().ToString("N");
                AssetRegistry.RegisterAssembly(assyName, () => new MemoryStream(zipBytes, false));
                SetActiveAssembly(assyName);
                Image image = Image.LoadImageFromResources(entryName);
                Assert.NotNull(image);
                Assert.Equal(2, image.Width);
                Assert.Equal(2, image.Height);
                Assert.Equal(16, image.Data.Length);
            }
            finally
            {
                RestoreActive(previous);
            }
        }

        /// <summary>
        ///     Tests handling of BMP with palette size zero (bitsPerPixel > 8).
        /// </summary>
        [Fact]
        public void LoadFromStream_When24BitBmp_VerifyPixelValues()
        {
            string path = WriteTempBmp(CreateMinimalBmp24Bit(2, 2));
            Image image = Image.Load(path);
            Assert.NotNull(image.Data);
            Assert.Equal(16, image.Data.Length);
            Assert.Equal(255, image.Data[3]);
            Assert.Equal(255, image.Data[7]);
            Assert.Equal(255, image.Data[11]);
            Assert.Equal(255, image.Data[15]);
        }

        /// <summary>
        ///     Tests LoadFromStream with compression=1 (RLE8) but bitsPerPixel != 8.
        ///     Exercises the false branch of bitsPerPixel==8 sub-condition in the else-if.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenRle8CompressionWithWrongBpp_ThrowsNotSupported()
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
            WriteLittleEndian(bmp, 10, 54);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 32, 1u);
            WriteLittleEndian(bmp, 36, (uint)imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            string path = WriteTempBmp(bmp);
            Assert.Throws<NotSupportedException>(() => Image.Load(path));
        }

        /// <summary>
        ///     Tests BITFIELDS (compression=3) with 24-bit to cover the bitsPerPixel==32 false branch.
        /// </summary>
        [Fact]
        public void LoadFromStream_WhenBitfields24Bit_ReturnsCorrectImage()
        {
            int width = 2;
            int height = 2;
            int headerSize = 56;
            int masksSize = 12;
            int pixelDataOffset = 14 + headerSize + masksSize;
            int rowSize = width * 3;
            int rowPadded = (rowSize + 3) / 4 * 4;
            int imageSize = rowPadded * height;
            int fileSize = pixelDataOffset + imageSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte)'B';
            bmp[1] = (byte)'M';
            WriteLittleEndian(bmp, 2, (uint)fileSize);
            WriteLittleEndian(bmp, 10, (uint)pixelDataOffset);
            WriteLittleEndian(bmp, 14, (uint)headerSize);
            WriteLittleEndian(bmp, 18, (uint)width);
            WriteLittleEndian(bmp, 22, (uint)height);
            WriteLittleEndian(bmp, 26, (ushort)1);
            WriteLittleEndian(bmp, 28, (ushort)24);
            WriteLittleEndian(bmp, 30, 3u);
            WriteLittleEndian(bmp, 34, (uint)imageSize);
            int masksOffset = 14 + headerSize;
            BitConverter.GetBytes(0x00FF0000u).CopyTo(bmp, masksOffset);
            BitConverter.GetBytes(0x0000FF00u).CopyTo(bmp, masksOffset + 4);
            BitConverter.GetBytes(0x000000FFu).CopyTo(bmp, masksOffset + 8);
            int offset = pixelDataOffset;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[offset++] = 255;
                    bmp[offset++] = 128;
                    bmp[offset++] = 64;
                }
                while (offset < pixelDataOffset + rowPadded * (y + 1))
                {
                    bmp[offset++] = 0;
                }
            }
            string path = WriteTempBmp(bmp);
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(width, image.Width);
            Assert.Equal(height, image.Height);
        }

        /// <summary>
        ///     Tests 1-bit BMP with width > 8 to cover the (i < 8) sub-condition in Load1BitRow.
        /// </summary>
        [Fact]
        public void LoadFromStream_When1BitBmpWidthWide_CoversAllLoopConditions()
        {
            string path = WriteTempBmp(CreateMinimalBmp1Bit(10, 2));
            Image image = Image.Load(path);
            Assert.NotNull(image);
            Assert.Equal(10, image.Width);
            Assert.Equal(2, image.Height);
        }

        #region Helpers for AssetRegistry manipulation

        /// <summary>
        ///     Saves current active assembly and returns previous value.
        /// </summary>
        private static string SaveAndSetActive()
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField(
                "<ActiveAssemblyName>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Static);
            return (string)activeField?.GetValue(null);
        }

        /// <summary>
        ///     Sets the active assembly.
        /// </summary>
        private static void SetActiveAssembly(string name)
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField(
                "<ActiveAssemblyName>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Static);
            activeField?.SetValue(null, name);
        }

        /// <summary>
        ///     Restores the active assembly.
        /// </summary>
        private static void RestoreActive(string previous)
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField(
                "<ActiveAssemblyName>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Static);
            activeField?.SetValue(null, previous);
        }

        /// <summary>
        ///     Creates a zip in memory with a single entry.
        /// </summary>
        private static byte[] CreateZipWithEntry(string entryName, byte[] content)
        {
            using MemoryStream zipMs = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                using Stream entryStream = entry.Open();
                entryStream.Write(content, 0, content.Length);
            }
            return zipMs.ToArray();
        }

        #endregion
    }
}
