using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The blend mode tests class
    /// </summary>
    public class BlendModeTests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Add,
                                     BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Subtract);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        /// <summary>
        /// Tests that predefined modes are correct
        /// </summary>
        [Fact]
        public void PredefinedModes_AreCorrect()
        {
            BlendMode alpha = BlendMode.Alpha;
            Assert.Equal(BlendMode.Factor.SrcAlpha, alpha.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, alpha.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, alpha.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, alpha.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, alpha.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, alpha.AlphaEquation);
        }

        /// <summary>
        /// Tests that equality operators work
        /// </summary>
        [Fact]
        public void Equality_Operators_Work()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode b = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode c = new BlendMode(BlendMode.Factor.Zero, BlendMode.Factor.One);
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.False(a == c);
            Assert.True(a != c);
        }

        /// <summary>
        /// Tests that get hash code is consistent
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode b = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
    }
}

