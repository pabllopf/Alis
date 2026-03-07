using Alis.Core.Aspect.Math;
using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    /// The custom math test class
    /// </summary>
    public class CustomMathFTest
    {
        /// <summary>
        /// Tests that sqrt with negative value returns na n
        /// </summary>
        [Fact]
        public void Sqrt_WithNegativeValue_ReturnsNaN()
        {
            float result = CustomMathF.Sqrt(-1f);

            Assert.True(float.IsNaN(result));
        }

        /// <summary>
        /// Tests that sqrt with zero returns zero
        /// </summary>
        [Fact]
        public void Sqrt_WithZero_ReturnsZero()
        {
            float result = CustomMathF.Sqrt(0f);

            Assert.Equal(0f, result);
        }

        /// <summary>
        /// Tests that sin and cos with canonical angles return expected values
        /// </summary>
        [Fact]
        public void SinAndCos_WithCanonicalAngles_ReturnExpectedValues()
        {
            float sin = CustomMathF.Sin(CustomMathF.Pi / 2f);
            float cos = CustomMathF.Cos(0f);

            Assert.Equal(1f, sin, 2);
            Assert.Equal(1f, cos, 2);
        }

        /// <summary>
        /// Tests that trigonometric functions with invalid values return na n
        /// </summary>
        [Fact]
        public void TrigonometricFunctions_WithInvalidValues_ReturnNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Sin(float.NaN)));
            Assert.True(float.IsNaN(CustomMathF.Cos(float.PositiveInfinity)));
            Assert.True(float.IsNaN(CustomMathF.Tan(float.NegativeInfinity)));
        }

        /// <summary>
        /// Tests that tan with half pi returns positive infinity
        /// </summary>
        [Fact]
        public void Tan_WithHalfPi_ReturnsPositiveInfinity()
        {
            float result = CustomMathF.Tan(CustomMathF.Pi / 2f);

            Assert.True(float.IsPositiveInfinity(result));
        }

        /// <summary>
        /// Tests that acos out of range returns na n
        /// </summary>
        [Fact]
        public void Acos_OutOfRange_ReturnsNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Acos(-1.01f)));
            Assert.True(float.IsNaN(CustomMathF.Acos(1.01f)));
        }

        /// <summary>
        /// Tests that clamp limits value to range
        /// </summary>
        [Fact]
        public void Clamp_LimitsValueToRange()
        {
            Assert.Equal(0f, CustomMathF.Clamp(-1f, 0f, 1f));
            Assert.Equal(1f, CustomMathF.Clamp(5f, 0f, 1f));
            Assert.Equal(0.3f, CustomMathF.Clamp(0.3f, 0f, 1f));
        }

        /// <summary>
        /// Tests that max min for int and float return expected operand
        /// </summary>
        [Fact]
        public void MaxMin_ForIntAndFloat_ReturnExpectedOperand()
        {
            Assert.Equal(7, CustomMathF.Max(7, 3));
            Assert.Equal(3, CustomMathF.Min(7, 3));
            Assert.Equal(7.5f, CustomMathF.Max(7.5f, 7.4f));
            Assert.Equal(7.4f, CustomMathF.Min(7.5f, 7.4f));
        }
    }
}

