using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    /// Parametrized extensive tests for CustomMathF static class.
    /// Tests hundreds of mathematical function combinations.
    /// </summary>
    public class CustomMathFParametrizedTest
    {
        

        /// <summary>
        /// Gets the sqrt test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetSqrtTestCases()
        {
            yield return new object[] { 0f, 0f };
            yield return new object[] { 1f, 1f };
            yield return new object[] { 4f, 2f };
            yield return new object[] { 9f, 3f };
            yield return new object[] { 16f, 4f };
            yield return new object[] { 25f, 5f };
            yield return new object[] { 36f, 6f };
            yield return new object[] { 49f, 7f };
            yield return new object[] { 64f, 8f };
            yield return new object[] { 81f, 9f };
            yield return new object[] { 100f, 10f };
            yield return new object[] { 121f, 11f };
            yield return new object[] { 144f, 12f };
            yield return new object[] { 169f, 13f };
            yield return new object[] { 196f, 14f };
            yield return new object[] { 225f, 15f };
            yield return new object[] { 256f, 16f };
            yield return new object[] { 289f, 17f };
            yield return new object[] { 324f, 18f };
            yield return new object[] { 361f, 19f };
            yield return new object[] { 400f, 20f };
            yield return new object[] { 0.25f, 0.5f };
            yield return new object[] { 0.5f, 0.7071067811865476f };
            yield return new object[] { 2f, 1.4142135623730951f };
            yield return new object[] { 3f, 1.7320508075688772f };
            yield return new object[] { 10f, 3.1622776601683795f };
            yield return new object[] { 100f, 10f };
            yield return new object[] { 1000f, 31.622776601683793f };
            yield return new object[] { 10000f, 100f };
        }

        /// <summary>
        /// Tests that sqrt with various positive values returns expected result
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetSqrtTestCases))]
        public void Sqrt_WithVariousPositiveValues_ReturnsExpectedResult(float input, float expected)
        {
            float result = CustomMathF.Sqrt(input);
            Assert.Equal(expected, result, 2);
        }

        /// <summary>
        /// Tests that sqrt with negative values returns na n
        /// </summary>
        /// <param name="input">The input</param>
        [Theory]
        [InlineData(-1f)]
        [InlineData(-10f)]
        [InlineData(-100f)]
        [InlineData(-0.5f)]
        public void Sqrt_WithNegativeValues_ReturnsNaN(float input)
        {
            float result = CustomMathF.Sqrt(input);
            Assert.True(float.IsNaN(result));
        }

        

        

        /// <summary>
        /// Gets the abs test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetAbsTestCases()
        {
            yield return new object[] { 0f, 0f };
            yield return new object[] { 1f, 1f };
            yield return new object[] { -1f, 1f };
            yield return new object[] { 10f, 10f };
            yield return new object[] { -10f, 10f };
            yield return new object[] { 100f, 100f };
            yield return new object[] { -100f, 100f };
            yield return new object[] { 0.5f, 0.5f };
            yield return new object[] { -0.5f, 0.5f };
            yield return new object[] { 99.99f, 99.99f };
            yield return new object[] { -99.99f, 99.99f };
            yield return new object[] { 1000f, 1000f };
            yield return new object[] { -1000f, 1000f };
            yield return new object[] { 0.1f, 0.1f };
            yield return new object[] { -0.1f, 0.1f };
            yield return new object[] { float.MaxValue / 2, float.MaxValue / 2 };
            yield return new object[] { -(float.MaxValue / 2), float.MaxValue / 2 };
        }

        /// <summary>
        /// Tests that abs with various values returns correct magnitude
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetAbsTestCases))]
        public void Abs_WithVariousValues_ReturnsCorrectMagnitude(float input, float expected)
        {
            float result = CustomMathF.Abs(input);
            Assert.Equal(expected, result, 5);
        }

        

        

        /// <summary>
        /// Gets the clamp test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetClampTestCases()
        {
            // Value within range
            yield return new object[] { 5f, 0f, 10f, 5f };
            yield return new object[] { 0f, 0f, 10f, 0f };
            yield return new object[] { 10f, 0f, 10f, 10f };
            
            // Value below range
            yield return new object[] { -1f, 0f, 10f, 0f };
            yield return new object[] { -100f, 0f, 10f, 0f };
            yield return new object[] { -0.5f, 0f, 1f, 0f };
            
            // Value above range
            yield return new object[] { 11f, 0f, 10f, 10f };
            yield return new object[] { 100f, 0f, 10f, 10f };
            yield return new object[] { 1.5f, 0f, 1f, 1f };
            
            // Negative ranges
            yield return new object[] { -5f, -10f, 0f, -5f };
            yield return new object[] { -15f, -10f, 0f, -10f };
            yield return new object[] { 5f, -10f, 0f, 0f };
            
            // Single point ranges
            yield return new object[] { 5f, 5f, 5f, 5f };
            yield return new object[] { 0f, 0f, 0f, 0f };
            yield return new object[] { 100f, 50f, 50f, 50f };
            
            // Float precision
            yield return new object[] { 0.5f, 0f, 1f, 0.5f };
            yield return new object[] { 0.1f, 0f, 1f, 0.1f };
            yield return new object[] { 0.9f, 0f, 1f, 0.9f };
        }

        /// <summary>
        /// Tests that clamp with various inputs returns correct value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetClampTestCases))]
        public void Clamp_WithVariousInputs_ReturnsCorrectValue(float value, float min, float max, float expected)
        {
            float result = CustomMathF.Clamp(value, min, max);
            Assert.Equal(expected, result, 5);
        }

        

        

        /// <summary>
        /// Gets the max int test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetMaxIntTestCases()
        {
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 1, 0, 1 };
            yield return new object[] { 0, 1, 1 };
            yield return new object[] { 5, 3, 5 };
            yield return new object[] { 3, 5, 5 };
            yield return new object[] { -5, 3, 3 };
            yield return new object[] { -3, -5, -3 };
            yield return new object[] { 100, 1, 100 };
            yield return new object[] { 1, 100, 100 };
            yield return new object[] { int.MaxValue, 0, int.MaxValue };
            yield return new object[] { int.MinValue, 0, 0 };
            yield return new object[] { int.MaxValue, int.MinValue, int.MaxValue };
        }

        /// <summary>
        /// Tests that max with int values returns greater
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetMaxIntTestCases))]
        public void Max_WithIntValues_ReturnsGreater(int a, int b, int expected)
        {
            int result = CustomMathF.Max(a, b);
            Assert.Equal(expected, result);
        }

        

        

        /// <summary>
        /// Gets the min int test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetMinIntTestCases()
        {
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 1, 0, 0 };
            yield return new object[] { 0, 1, 0 };
            yield return new object[] { 5, 3, 3 };
            yield return new object[] { 3, 5, 3 };
            yield return new object[] { -5, 3, -5 };
            yield return new object[] { -3, -5, -5 };
            yield return new object[] { 100, 1, 1 };
            yield return new object[] { 1, 100, 1 };
            yield return new object[] { int.MaxValue, 0, 0 };
            yield return new object[] { int.MinValue, 0, int.MinValue };
            yield return new object[] { int.MaxValue, int.MinValue, int.MinValue };
        }

        /// <summary>
        /// Tests that min with int values returns smaller
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetMinIntTestCases))]
        public void Min_WithIntValues_ReturnsSmaller(int a, int b, int expected)
        {
            int result = CustomMathF.Min(a, b);
            Assert.Equal(expected, result);
        }

        

        

        /// <summary>
        /// Gets the trigonometric test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetTrigonometricTestCases()
        {
            // Common angles in radians
            float pi = CustomMathF.Pi;
            float tau = CustomMathF.Tau;
            float halfPi = pi / 2f;
            
            // Sin tests
            yield return new object[] { "Sin", 0f, 0f };
            yield return new object[] { "Sin", halfPi, 1f };
            yield return new object[] { "Sin", pi, 0f };
            yield return new object[] { "Sin", 3f * halfPi, -1f };
            yield return new object[] { "Sin", tau, 0f };
            
            // Cos tests
            yield return new object[] { "Cos", 0f, 1f };
            yield return new object[] { "Cos", halfPi, 0f };
            yield return new object[] { "Cos", pi, -1f };
            yield return new object[] { "Cos", 3f * halfPi, 0f };
            yield return new object[] { "Cos", tau, 1f };
        }

        /// <summary>
        /// Tests that trigonometric common angles return expected values
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="angle">The angle</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(GetTrigonometricTestCases))]
        public void Trigonometric_CommonAngles_ReturnExpectedValues(string function, float angle, float expected)
        {
            float result = function == "Sin" 
                ? CustomMathF.Sin(angle)
                : CustomMathF.Cos(angle);
            
            Assert.Equal(expected, result, 1);
        }

        

        

        /// <summary>
        /// Tests that sqrt with special values handles correctly
        /// </summary>
        /// <param name="input">The input</param>
        [Theory]
        [InlineData(float.NaN)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity)]
        public void Sqrt_WithSpecialValues_HandlesCorrectly(float input)
        {
            float result = CustomMathF.Sqrt(input);
            Assert.True(float.IsNaN(result) || float.IsInfinity(result));
        }

        /// <summary>
        /// Tests that abs with special values handles properly
        /// </summary>
        /// <param name="input">The input</param>
        [Theory]
        [InlineData(float.NaN)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity)]
        public void Abs_WithSpecialValues_HandlesProperly(float input)
        {
            if (float.IsNaN(input))
            {
                float result = CustomMathF.Abs(input);
                Assert.True(float.IsNaN(result));
            }
            else
            {
                float result = CustomMathF.Abs(input);
                Assert.True(float.IsInfinity(result) || float.IsNaN(result));
            }
        }

        

        

        /// <summary>
        /// Tests that multi operation combinations
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 20, 30)]
        [InlineData(100, 200, 300)]
        [InlineData(-1, -2, -3)]
        [InlineData(-10, 0, 10)]
        public void MultiOperation_Combinations(float a, float b, float c)
        {
            // Test mathematical properties
            float absA = CustomMathF.Abs(a);
            float absB = CustomMathF.Abs(b);
            float maxAB = CustomMathF.Max((int)a, (int)b);
            
            Assert.True(absA >= 0);
            Assert.True(absB >= 0);
            Assert.True(maxAB >= a && maxAB >= b);
        }

        
    }
}

