using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the Color struct.
    /// </summary>
    public class ColorTest
    {
        /// <summary>
        /// Tests the constructors and ToInteger method.
        /// </summary>
        [Fact]
        public void Constructor_And_ToInteger_Works()
        {
            var color = new Color(10, 20, 30, 40);
            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(40, color.A);
            uint intValue = color.ToInteger();
            var color2 = new Color(intValue);
            Assert.Equal(color, color2);
        }

        /// <summary>
        /// Tests the copy constructor.
        /// </summary>
        [Fact]
        public void CopyConstructor_Works()
        {
            var color = new Color(1, 2, 3, 4);
            var copy = new Color(color);
            Assert.Equal(color, copy);
        }

        /// <summary>
        /// Tests equality and inequality.
        /// </summary>
        [Fact]
        public void Equality_Works()
        {
            var c1 = new Color(1, 2, 3, 4);
            var c2 = new Color(1, 2, 3, 4);
            var c3 = new Color(5, 6, 7, 8);
            Assert.True(c1.Equals(c2));
            Assert.False(c1.Equals(c3));
            Assert.True(c1 == c2);
            Assert.True(c1 != c3);
        }

        /// <summary>
        /// Tests ToString returns a non-empty string.
        /// </summary>
        [Fact]
        public void ToString_NotEmpty()
        {
            var color = new Color(1, 2, 3, 4);
            Assert.False(string.IsNullOrWhiteSpace(color.ToString()));
        }
    }
}

