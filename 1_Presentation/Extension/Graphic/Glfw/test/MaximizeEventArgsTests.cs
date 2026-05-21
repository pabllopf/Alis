

using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for MaximizeEventArgs class
    /// </summary>
    public class MaximizeEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor with true value sets is maximized to true
        /// </summary>
        [Fact]
        public void Constructor_WithTrueValue_SetsIsMaximizedToTrue()
        {
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            Assert.True(args.IsMaximized);
        }

        /// <summary>
        ///     Tests that constructor with false value sets is maximized to false
        /// </summary>
        [Fact]
        public void Constructor_WithFalseValue_SetsIsMaximizedToFalse()
        {
            MaximizeEventArgs args = new MaximizeEventArgs(false);

            Assert.False(args.IsMaximized);
        }

        /// <summary>
        ///     Tests that is maximized property returns correct value
        /// </summary>
        [Fact]
        public void IsMaximized_Property_ReturnsCorrectValue()
        {
            bool expectedValue = true;
            MaximizeEventArgs args = new MaximizeEventArgs(expectedValue);

            bool result = args.IsMaximized;

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        ///     Tests that constructor with false value returns correct state
        /// </summary>
        [Fact]
        public void Constructor_WithFalseValue_ReturnsCorrectState()
        {
            bool expectedValue = false;
            MaximizeEventArgs args = new MaximizeEventArgs(expectedValue);

            bool result = args.IsMaximized;

            Assert.Equal(expectedValue, result);
        }
    }
}