using System;
using System.IO;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// The image test class
    /// </summary>
    public partial class ImageTest
    {
        /// <summary>
        /// Tests that load with valid bmp file returns correct image
        /// </summary>
        [Fact]
        public void Load_WithValidBmpFile_ReturnsCorrectImage()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(2, 2);
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

        /// <summary>
        /// Tests that load with non existent path throws file not found exception
        /// </summary>
        [Fact]
        public void Load_WithNonExistentPath_ThrowsFileNotFoundException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bmp");
            Assert.Throws<FileNotFoundException>(() => Image.Load(path));
        }

        /// <summary>
        /// Tests that load with null path throws argument null exception
        /// </summary>
        [Fact]
        public void Load_WithNullPath_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Image.Load(null));
        }

        /// <summary>
        /// Tests that load with empty path throws argument exception
        /// </summary>
        [Fact]
        public void Load_WithEmptyPath_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.Load(string.Empty));
        }

        /// <summary>
        /// Tests that load image from resources with null resource name throws argument exception
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WithNullResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources(null));
        }

        /// <summary>
        /// Tests that load image from resources with empty resource name throws argument exception
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WithEmptyResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources(string.Empty));
        }

        /// <summary>
        /// Tests that load image from resources with whitespace resource name throws argument exception
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Image.LoadImageFromResources("   "));
        }

        /// <summary>
        /// Tests that load image from resources when resource not found throws file not found exception
        /// </summary>
        [Fact]
        public void LoadImageFromResources_WhenResourceNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => Image.LoadImageFromResources("nonexistent_resource_" + Guid.NewGuid().ToString("N")));
        }

        /// <summary>
        /// Tests that image loaded via load has expected property values
        /// </summary>
        [Fact]
        public void Image_LoadedViaLoad_HasExpectedPropertyValues()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(3, 4);
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

        /// <summary>
        /// Tests that image loaded via load has non null data
        /// </summary>
        [Fact]
        public void Image_LoadedViaLoad_HasNonNullData()
        {
            string tempPath = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmpData = CreateMinimalBmp24Bit(3, 4);
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
