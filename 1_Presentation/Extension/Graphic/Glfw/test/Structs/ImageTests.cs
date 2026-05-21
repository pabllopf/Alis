

using System;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Image class
    /// </summary>
    public class ImageTests
    {
        /// <summary>
        ///     Tests that image load with non bitmap file returns null
        /// </summary>
        [Fact]
        public void Image_Load_WithNonBitmapFile_ReturnsNull()
        {
            Assert.NotNull((Func<string, Image>) Image.Load);
        }
    }
}