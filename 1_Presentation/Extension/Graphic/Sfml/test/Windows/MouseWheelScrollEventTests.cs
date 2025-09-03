using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse wheel scroll event tests class
    /// </summary>
    public class MouseWheelScrollEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseWheelScrollEvent evt = new MouseWheelScrollEvent { Wheel = Mouse.Wheel.VerticalWheel, Delta = 1.5f, X = 10, Y = 20 };
            Assert.Equal(Mouse.Wheel.VerticalWheel, evt.Wheel);
            Assert.Equal(1.5f, evt.Delta);
            Assert.Equal(10, evt.X);
            Assert.Equal(20, evt.Y);
        }
    }
}

