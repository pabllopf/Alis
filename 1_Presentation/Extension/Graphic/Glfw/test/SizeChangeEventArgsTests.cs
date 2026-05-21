

using System.Drawing;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for SizeChangeEventArgs class
    /// </summary>
    public class SizeChangeEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor with width and height sets size
        /// </summary>
        [Fact]
        public void Constructor_WithWidthAndHeight_SetsSize()
        {
            int width = 800;
            int height = 600;

            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            Assert.Equal(width, args.Size.Width);
            Assert.Equal(height, args.Size.Height);
        }

        /// <summary>
        ///     Tests that constructor with size object sets size
        /// </summary>
        [Fact]
        public void Constructor_WithSizeObject_SetsSize()
        {
            Size size = new Size(1024, 768);

            SizeChangeEventArgs args = new SizeChangeEventArgs(size);

            Assert.Equal(size, args.Size);
        }

        /// <summary>
        ///     Tests that size property returns correct value
        /// </summary>
        [Fact]
        public void Size_Property_ReturnsCorrectValue()
        {
            Size expectedSize = new Size(1920, 1080);
            SizeChangeEventArgs args = new SizeChangeEventArgs(expectedSize);

            Size result = args.Size;

            Assert.Equal(expectedSize, result);
        }

        /// <summary>
        ///     Tests that constructor with zero size sets size
        /// </summary>
        [Fact]
        public void Constructor_WithZeroSize_SetsSize()
        {
            int width = 0;
            int height = 0;

            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            Assert.Equal(0, args.Size.Width);
            Assert.Equal(0, args.Size.Height);
        }

        /// <summary>
        ///     Tests that constructor with large size sets size
        /// </summary>
        [Fact]
        public void Constructor_WithLargeSize_SetsSize()
        {
            int width = 3840;
            int height = 2160;

            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            Assert.Equal(width, args.Size.Width);
            Assert.Equal(height, args.Size.Height);
        }

        /// <summary>
        ///     Tests that constructor with different values creates distinct objects
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentValues_CreatesDistinctObjects()
        {
            SizeChangeEventArgs args1 = new SizeChangeEventArgs(800, 600);
            SizeChangeEventArgs args2 = new SizeChangeEventArgs(1024, 768);

            Assert.NotEqual(args1.Size, args2.Size);
        }
    }
}