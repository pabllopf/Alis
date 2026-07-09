using System;
using System.IO;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public partial class ImageTest
    {
        [Fact]
        public void Load_WithValidBmpFile_ReturnsCorrectImage()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(2, 2).ToArray();
                File.WriteAllBytes(tempPath, bmpData);

                Image image = Image.Load(tempPath);

                Assert.NotNull(image);
                Assert.Equal(2, image.Width);
                Assert.Equal(2, image.Height);
                Assert.NotNull(image.Data);
                Assert.Equal(2 * 2 * 4, image.Data.Length);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        [Fact]
        public void Load_WithNonExistentPath_ThrowsFileNotFoundException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bmp");
            Assert.Throws<FileNotFoundException>(() => Image.Load(path));
        }

        [Fact]
        public void Load_WithNullPath_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Image.Load(null));
        }

        [Fact]
        public void Load_WithEmptyPath_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.Load(string.Empty));
        }

        [Fact]
        public void LoadImageFromResources_WithNullResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources(null));
        }

        [Fact]
        public void LoadImageFromResources_WithEmptyResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources(string.Empty));
        }

        [Fact]
        public void LoadImageFromResources_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources("   "));
        }

        [Fact]
        public void LoadImageFromResources_WhenResourceNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => Image.LoadImageFromResources("nonexistent_resource_" + Guid.NewGuid().ToString("N")));
        }

        [Fact]
        public void Image_LoadedViaLoad_HasExpectedPropertyValues()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(3, 4).ToArray();
                File.WriteAllBytes(tempPath, bmpData);

                Image image = Image.Load(tempPath);

                Assert.Equal(3, image.Width);
                Assert.Equal(4, image.Height);
                Assert.Equal(3 * 4 * 4, image.Data.Length);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        [Fact]
        public void Image_LoadedViaLoad_HasNonNullData()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(3, 4).ToArray();
                File.WriteAllBytes(tempPath, bmpData);

                Image image = Image.Load(tempPath);

                Assert.NotNull(image.Data);
                Assert.Equal(3 * 4 * 4, image.Data.Length);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }
    }
}
