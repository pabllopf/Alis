using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse move event tests class
    /// </summary>
    public class MouseMoveEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseMoveEvent evt = new MouseMoveEvent { X = 123, Y = 456 };
            Assert.Equal(123, evt.X);
            Assert.Equal(456, evt.Y);
        }
    }

    /// <summary>
    /// The mouse move event args tests class
    /// </summary>
    public class MouseMoveEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseMoveEvent evt = new MouseMoveEvent { X = 10, Y = 20 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(evt);
            Assert.Equal(10, args.X);
            Assert.Equal(20, args.Y);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseMoveEvent evt = new MouseMoveEvent { X = -5, Y = 99 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}

