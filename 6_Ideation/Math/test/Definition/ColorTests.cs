

using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Definition;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Definition
{
    /// <summary>
    ///     The color tests class
    /// </summary>
    public class ColorTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly when given bytes
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly_WhenGivenBytes()
        {
            const byte r = 255;
            const byte g = 128;
            const byte b = 64;
            const byte a = 32;

            Color color = new Color(r, g, b, a);

            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }

        /// <summary>
        ///     Tests that constructor sets properties correctly when given ints
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly_WhenGivenInts()
        {
            const int r = 255;
            const int g = 128;
            const int b = 64;
            const int a = 32;

            Color color = new Color(r, g, b, a);

            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }

        /// <summary>
        ///     Tests that black returns correct color
        /// </summary>
        [Fact]
        public void Black_ReturnsCorrectColor()
        {
            Color expected = new Color(0, 0, 0, 255);

            Color actual = Color.Black;

            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Red_ReturnsCorrectColor()
        {
            Color expected = new Color(255, 0, 0, 255);

            Color actual = Color.Red;

            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Green_ReturnsCorrectColor()
        {
            Color expected = new Color(0, 255, 0, 255);

            Color actual = Color.Green;

            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Brown_ReturnsCorrectColor()
        {
            Color expected = new Color(165, 42, 42, 255);

            Color actual = Color.Brown;

            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that dark green returns correct color
        /// </summary>
        [Fact]
        public void DarkGreen_ReturnsCorrectColor()
        {
            Color expected = new Color(0, 100, 0, 255);

            Color actual = Color.DarkGreen;

            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that white and transparent return expected values
        /// </summary>
        [Fact]
        public void WhiteAndTransparent_ReturnExpectedValues()
        {
            Color white = Color.White;
            Color transparent = Color.Transparent;

            Assert.Equal(255, white.R);
            Assert.Equal(255, white.G);
            Assert.Equal(255, white.B);
            Assert.Equal(255, white.A);

            Assert.Equal(0, transparent.R);
            Assert.Equal(0, transparent.G);
            Assert.Equal(0, transparent.B);
            Assert.Equal(0, transparent.A);
        }

        /// <summary>
        ///     Tests that primary palette properties return expected values
        /// </summary>
        [Fact]
        public void PrimaryPaletteProperties_ReturnExpectedValues()
        {
            Assert.Equal(255, Color.Cyan.G);
            Assert.Equal(255, Color.Cyan.B);

            Assert.Equal(255, Color.Magenta.R);
            Assert.Equal(255, Color.Magenta.B);

            Assert.Equal(255, Color.Yellow.R);
            Assert.Equal(255, Color.Yellow.G);

            Assert.Equal(255, Color.Blue.B);
        }

        /// <summary>
        ///     Tests that get object data writes all channels
        /// </summary>
        [Fact]
        public void GetObjectData_WritesAllChannels()
        {
            Color color = new Color(1, 2, 3, 4);
            SerializationInfo info = new SerializationInfo(typeof(Color), new FormatterConverter());

            color.GetObjectData(info, default(StreamingContext));

            Assert.Equal((byte) 1, info.GetByte("r"));
            Assert.Equal((byte) 2, info.GetByte("g"));
            Assert.Equal((byte) 3, info.GetByte("b"));
            Assert.Equal((byte) 4, info.GetByte("a"));
        }
    }
}