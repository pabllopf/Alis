using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The color tests class
    /// </summary>
    public class ColorTests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            Color color = new Color(10, 20, 30, 40);
            Assert.Equal((byte)10, color.R);
            Assert.Equal((byte)20, color.G);
            Assert.Equal((byte)30, color.B);
            Assert.Equal((byte)40, color.A);
        }

        /// <summary>
        /// Tests that constructor three args sets alpha to 255
        /// </summary>
        [Fact]
        public void Constructor_ThreeArgs_SetsAlphaTo255()
        {
            Color color = new Color(1, 2, 3);
            Assert.Equal((byte)1, color.R);
            Assert.Equal((byte)2, color.G);
            Assert.Equal((byte)3, color.B);
            Assert.Equal((byte)255, color.A);
        }

        /// <summary>
        /// Tests that constructor from u int sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_FromUInt_SetsFieldsCorrectly()
        {
            Color color = new Color(0x0A141E28);
            Assert.Equal((byte)0x0A, color.R);
            Assert.Equal((byte)0x14, color.G);
            Assert.Equal((byte)0x1E, color.B);
            Assert.Equal((byte)0x28, color.A);
        }

        /// <summary>
        /// Tests that to integer returns expected
        /// </summary>
        [Fact]
        public void ToInteger_ReturnsExpected()
        {
            Color color = new Color(0x0A, 0x14, 0x1E, 0x28);
            Assert.Equal(0x0A141E28u, color.ToInteger());
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            Color color = new Color(1, 2, 3, 4);
            string str = color.ToString();
            Assert.Contains("R(1)", str);
            Assert.Contains("G(2)", str);
            Assert.Contains("B(3)", str);
            Assert.Contains("A(4)", str);
        }

        /// <summary>
        /// Tests that equality operators work
        /// </summary>
        [Fact]
        public void Equality_Operators_Work()
        {
            Color a = new Color(1, 2, 3, 4);
            Color b = new Color(1, 2, 3, 4);
            Color c = new Color(5, 6, 7, 8);
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.False(a == c);
            Assert.True(a != c);
        }

        /// <summary>
        /// Tests that addition operator clamps to 255
        /// </summary>
        [Fact]
        public void Addition_Operator_ClampsTo255()
        {
            Color a = new Color(200, 200, 200, 200);
            Color b = new Color(100, 100, 100, 100);
            Color result = a + b;
            Assert.Equal((byte)255, result.R);
            Assert.Equal((byte)255, result.G);
            Assert.Equal((byte)255, result.B);
            Assert.Equal((byte)255, result.A);
        }

        /// <summary>
        /// Tests that subtraction operator clamps to zero
        /// </summary>
        [Fact]
        public void Subtraction_Operator_ClampsToZero()
        {
            Color a = new Color(10, 10, 10, 10);
            Color b = new Color(20, 20, 20, 20);
            Color result = a - b;
            Assert.Equal((byte)0, result.R);
            Assert.Equal((byte)0, result.G);
            Assert.Equal((byte)0, result.B);
            Assert.Equal((byte)0, result.A);
        }

        /// <summary>
        /// Tests that multiplication operator works
        /// </summary>
        [Fact]
        public void Multiplication_Operator_Works()
        {
            Color a = new Color(255, 128, 64, 32);
            Color b = new Color(255, 128, 64, 32);
            Color result = a * b;
            Assert.Equal((byte)255, result.R);
            Assert.Equal((byte)64, result.G);
            Assert.Equal((byte)16, result.B);
            Assert.Equal((byte)4, result.A);
        }

        /// <summary>
        /// Tests that get hash code is consistent
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            Color a = new Color(1, 2, 3, 4);
            Color b = new Color(1, 2, 3, 4);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        /// <summary>
        /// Tests that predefined colors are correct
        /// </summary>
        [Fact]
        public void PredefinedColors_AreCorrect()
        {
            Assert.Equal(new Color(0, 0, 0), Color.Black);
            Assert.Equal(new Color(255, 255, 255), Color.White);
            Assert.Equal(new Color(255, 0, 0), Color.Red);
            Assert.Equal(new Color(0, 255, 0), Color.Green);
            Assert.Equal(new Color(0, 0, 255), Color.Blue);
            Assert.Equal(new Color(255, 255, 0), Color.Yellow);
            Assert.Equal(new Color(255, 0, 255), Color.Magenta);
            Assert.Equal(new Color(0, 255, 255), Color.Cyan);
            Assert.Equal(new Color(0, 0, 0, 0), Color.Transparent);
        }
    }
}

