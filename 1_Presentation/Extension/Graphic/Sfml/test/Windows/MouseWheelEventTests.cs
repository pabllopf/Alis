using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse wheel event tests class
    /// </summary>
    public class MouseWheelEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseWheelEvent evt = new MouseWheelEvent { Delta = 2, X = 10, Y = 20 };
            Assert.Equal(2, evt.Delta);
            Assert.Equal(10, evt.X);
            Assert.Equal(20, evt.Y);
        }
    }

    /// <summary>
    /// The mouse wheel event args tests class
    /// </summary>
    public class MouseWheelEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseWheelEvent evt = new MouseWheelEvent { Delta = 1, X = 5, Y = 15 };
            MouseWheelEventArgs args = new MouseWheelEventArgs(evt);
            Assert.Equal(1, args.Delta);
            Assert.Equal(5, args.X);
            Assert.Equal(15, args.Y);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseWheelEvent evt = new MouseWheelEvent { Delta = -1, X = -5, Y = 99 };
            MouseWheelEventArgs args = new MouseWheelEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("Delta(-1)", str);
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}

