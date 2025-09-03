using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse button event args tests class
    /// </summary>
    public class MouseButtonEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseButtonEvent evt = new MouseButtonEvent
            {
                Button = Mouse.Button.Right,
                X = 10,
                Y = 20
            };
            MouseButtonEventArgs args = new MouseButtonEventArgs(evt);
            Assert.Equal(Mouse.Button.Right, args.Button);
            Assert.Equal(10, args.X);
            Assert.Equal(20, args.Y);
        }
        

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseButtonEvent evt = new MouseButtonEvent
            {
                Button = Mouse.Button.Middle,
                X = -5,
                Y = 99
            };
            MouseButtonEventArgs args = new MouseButtonEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("Button(Middle)", str);
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}

