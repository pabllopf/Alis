using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The video mode test class
    /// </summary>
    public class VideoModeTest
    {
        /// <summary>
        /// Tests that constructor with width and height sets defaults
        /// </summary>
        [Fact]
        public void Constructor_WithWidthAndHeight_SetsDefaults()
        {
            VideoMode vm = new VideoMode(800, 600);
            Assert.Equal(800u, vm.Width);
            Assert.Equal(600u, vm.Height);
            Assert.Equal(32u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that constructor with width height and bpp sets all fields
        /// </summary>
        [Fact]
        public void Constructor_WithWidthHeightAndBpp_SetsAllFields()
        {
            VideoMode vm = new VideoMode(1024, 768, 16);
            Assert.Equal(1024u, vm.Width);
            Assert.Equal(768u, vm.Height);
            Assert.Equal(16u, vm.BitsPerPixel);
        }

        /// <summary>
        /// Tests that to string includes component names
        /// </summary>
        [Fact]
        public void ToString_IncludesComponentNames()
        {
            VideoMode vm = new VideoMode(1920, 1080);
            string str = vm.ToString();
            Assert.Contains("Width", str);
            Assert.Contains("Height", str);
            Assert.Contains("BitsPerPixel", str);
        }
    }
}
