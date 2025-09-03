using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse button event tests class
    /// </summary>
    public class MouseButtonEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseButtonEvent evt = new MouseButtonEvent { Button = Mouse.Button.Left, X = 10, Y = 20 };
            Assert.Equal(Mouse.Button.Left, evt.Button);
            Assert.Equal(10, evt.X);
            Assert.Equal(20, evt.Y);
        }
        
        /// <summary>
        /// Tests that can set button and coordinates
        /// </summary>
        [Fact]
        public void CanSetButtonAndCoordinates()
        {
            MouseButtonEvent evt = new MouseButtonEvent
            {
                Button = Mouse.Button.Left,
                X = 1,
                Y = 2
            };
            Assert.Equal(Mouse.Button.Left, evt.Button);
            Assert.Equal(1, evt.X);
            Assert.Equal(2, evt.Y);
        }
    }
}

