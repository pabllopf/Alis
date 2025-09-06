using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class MouseWheelEventTests
    {
        [Fact]
        public void CanSetFields()
        {
            MouseWheelEvent evt = new MouseWheelEvent { Delta = 2, X = 10, Y = 20 };
            Assert.Equal(2, evt.Delta);
            Assert.Equal(10, evt.X);
            Assert.Equal(20, evt.Y);
        }
    }

    public class MouseWheelEventArgsTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseWheelEvent evt = new MouseWheelEvent { Delta = 1, X = 5, Y = 15 };
            MouseWheelEventArgs args = new MouseWheelEventArgs(evt);
            Assert.Equal(1, args.Delta);
            Assert.Equal(5, args.X);
            Assert.Equal(15, args.Y);
        }

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

