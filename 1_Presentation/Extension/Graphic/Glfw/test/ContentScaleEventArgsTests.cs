

using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for ContentScaleEventArgs class
    /// </summary>
    public class ContentScaleEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor with valid scales sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidScales_SetsProperties()
        {
            float xScale = 1.5f;
            float yScale = 2.0f;

            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, yScale);

            Assert.Equal(xScale, args.XScale);
            Assert.Equal(yScale, args.YScale);
        }

        /// <summary>
        ///     Tests that x scale property returns correct value
        /// </summary>
        [Fact]
        public void XScale_Property_ReturnsCorrectValue()
        {
            float expectedXScale = 1.25f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(expectedXScale, 1.0f);

            float result = args.XScale;

            Assert.Equal(expectedXScale, result);
        }

        /// <summary>
        ///     Tests that y scale property returns correct value
        /// </summary>
        [Fact]
        public void YScale_Property_ReturnsCorrectValue()
        {
            float expectedYScale = 1.75f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(1.0f, expectedYScale);

            float result = args.YScale;

            Assert.Equal(expectedYScale, result);
        }

        /// <summary>
        ///     Tests that constructor with equal scales sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithEqualScales_SetsProperties()
        {
            float scale = 2.0f;

            ContentScaleEventArgs args = new ContentScaleEventArgs(scale, scale);

            Assert.Equal(scale, args.XScale);
            Assert.Equal(scale, args.YScale);
        }

        /// <summary>
        ///     Tests that constructor with default scale sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithDefaultScale_SetsProperties()
        {
            float xScale = 1.0f;
            float yScale = 1.0f;

            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, yScale);

            Assert.Equal(1.0f, args.XScale);
            Assert.Equal(1.0f, args.YScale);
        }

        /// <summary>
        ///     Tests that constructor with high dpi scales sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithHighDpiScales_SetsProperties()
        {
            float xScale = 3.0f;
            float yScale = 3.0f;

            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, yScale);

            Assert.Equal(3.0f, args.XScale);
            Assert.Equal(3.0f, args.YScale);
        }

        /// <summary>
        ///     Tests that constructor with different scales stores each independently
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentScales_StoresEachIndependently()
        {
            float xScale = 1.5f;
            float yScale = 2.5f;

            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, yScale);

            Assert.NotEqual(args.XScale, args.YScale);
        }
    }
}