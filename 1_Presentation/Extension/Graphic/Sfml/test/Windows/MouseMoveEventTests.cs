using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class MouseMoveEventTests
    {
        [Fact]
        public void CanSetFields()
        {
            MouseMoveEvent evt = new MouseMoveEvent { X = 123, Y = 456 };
            Assert.Equal(123, evt.X);
            Assert.Equal(456, evt.Y);
        }
    }

    public class MouseMoveEventArgsTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseMoveEvent evt = new MouseMoveEvent { X = 10, Y = 20 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(evt);
            Assert.Equal(10, args.X);
            Assert.Equal(20, args.Y);
        }

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

