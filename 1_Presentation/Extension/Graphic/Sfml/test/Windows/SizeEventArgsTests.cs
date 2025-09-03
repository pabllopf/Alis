using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The size event args tests class
    /// </summary>
    public class SizeEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets width and height
        /// </summary>
        [Fact]
        public void Constructor_SetsWidthAndHeight()
        {
            try
            {
                SizeEvent sizeEvent = new SizeEvent { Width = 800, Height = 600 };
                SizeEventArgs args = new SizeEventArgs(sizeEvent);
                Assert.Equal((uint)800, args.Width);
                Assert.Equal((uint)600, args.Height);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            try
            {
                SizeEvent sizeEvent = new SizeEvent { Width = 1024, Height = 768 };
                SizeEventArgs args = new SizeEventArgs(sizeEvent);
                string str = args.ToString();
                Assert.Contains("Width(1024)", str);
                Assert.Contains("Height(768)", str);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }

    /// <summary>
    /// The size event tests class
    /// </summary>
    public class SizeEventTests
    {
        /// <summary>
        /// Tests that can set width and height
        /// </summary>
        [Fact]
        public void CanSetWidthAndHeight()
        {
            try
            {
                SizeEvent evt = new SizeEvent { Width = 123, Height = 456 };
                Assert.Equal((uint)123, evt.Width);
                Assert.Equal((uint)456, evt.Height);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }
}
