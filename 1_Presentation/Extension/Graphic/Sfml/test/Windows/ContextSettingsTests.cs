using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The context settings tests class
    /// </summary>
    public class ContextSettingsTests
    {
        /// <summary>
        /// Tests that constructor sets depth and stencil bits
        /// </summary>
        [Fact]
        public void Constructor_SetsDepthAndStencilBits()
        {
            ContextSettings settings = new ContextSettings(24, 8);
            Assert.Equal((uint)24, settings.DepthBits);
            Assert.Equal((uint)8, settings.StencilBits);
        }

        /// <summary>
        /// Tests that constructor sets antialiasing level
        /// </summary>
        [Fact]
        public void Constructor_SetsAntialiasingLevel()
        {
            ContextSettings settings = new ContextSettings(16, 4, 2);
            Assert.Equal((uint)16, settings.DepthBits);
            Assert.Equal((uint)4, settings.StencilBits);
            Assert.Equal((uint)2, settings.AntialiasingLevel);
        }

        /// <summary>
        /// Tests that constructor sets all properties
        /// </summary>
        [Fact]
        public void Constructor_SetsAllProperties()
        {
            ContextSettings settings = new ContextSettings(1, 2, 3, 4, 5, ContextSettings.Attribute.Debug, true);
            Assert.Equal((uint)1, settings.DepthBits);
            Assert.Equal((uint)2, settings.StencilBits);
            Assert.Equal((uint)3, settings.AntialiasingLevel);
            Assert.Equal((uint)4, settings.MajorVersion);
            Assert.Equal((uint)5, settings.MinorVersion);
            Assert.Equal(ContextSettings.Attribute.Debug, settings.AttributeFlags);
            Assert.True(settings.SRgbCapable);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            ContextSettings settings = new ContextSettings(1, 2, 3, 4, 5, ContextSettings.Attribute.Core, false);
            string str = settings.ToString();
            Assert.Contains("DepthBits(1)", str);
            Assert.Contains("StencilBits(2)", str);
            Assert.Contains("AntialiasingLevel(3)", str);
            Assert.Contains("MajorVersion(4)", str);
            Assert.Contains("MinorVersion(5)", str);
            Assert.Contains("AttributeFlags(Core)", str);
        }
    }
}

