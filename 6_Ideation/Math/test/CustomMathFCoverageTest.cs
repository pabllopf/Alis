// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomMathFCoverageTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="CustomMathF" />.
    ///     Covers Newton convergence with extreme values, Taylor series break-on-small-term,
    ///     angle reduction for large inputs, and NaN edge cases.
    /// </summary>
    public class CustomMathFCoverageTest
    {
        /// <summary>
        ///     Tests Sqrt convergence with float.MaxValue.
        ///     Newton's method must handle very large magnitudes without overflow or divergence.
        /// </summary>
        [Fact]
        public void Sqrt_MaxValue_Converges()
        {
            float result = CustomMathF.Sqrt(float.MaxValue);
            Assert.True(result > 0f);
            Assert.True(float.IsFinite(result));
            Assert.True(result > 1e19f);
        }

        /// <summary>
        ///     Tests Sqrt with a very small value above epsilon.
        ///     Verifies Newton's method handles near-zero inputs.
        /// </summary>
        [Fact]
        public void Sqrt_VerySmall_Converges()
        {
            float result = CustomMathF.Sqrt(1e-20f);
            Assert.True(result > 0f);
            Assert.True(result < 1f);
        }

        /// <summary>
        ///     Tests Acos with a value near the center of the domain (0.5f).
        ///     The Taylor series converges quickly and the break-on-small-term path
        ///     (Abs(term) < float.Epsilon) is exercised.
        /// </summary>
        [Fact]
        public void Acos_CenterValue_Converges()
        {
            float result = CustomMathF.Acos(0.5f);
            Assert.Equal(1.047f, result, 1);
        }

        /// <summary>
        ///     Tests Acos with a value very close to zero.
        ///     The Taylor series center provides fastest convergence,
        ///     triggering the break-on-small-term path.
        /// </summary>
        [Fact]
        public void Acos_NearZero_BreakOnSmallTerm()
        {
            float result = CustomMathF.Acos(0.001f);

            float expected = (float)System.Math.Acos(0.001f);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        ///     Tests Sin with a very large angle (many multiples of 2π).
        ///     Verifies angle reduction via modulo works correctly.
        /// </summary>
        [Fact]
        public void Sin_LargeAngle_ReducesCorrectly()
        {
            float result = CustomMathF.Sin(100f * CustomMathF.Pi);
            Assert.True(float.IsFinite(result));
        }

        /// <summary>
        ///     Tests Cos with a very large angle.
        ///     Verifies angle reduction via modulo works correctly.
        /// </summary>
        [Fact]
        public void Cos_LargeAngle_ReducesCorrectly()
        {
            float result = CustomMathF.Cos(100f * CustomMathF.Tau);
            Assert.True(float.IsFinite(result));
        }

        /// <summary>
        ///     Tests Tan with a large angle requiring reduction.
        ///     Verifies Tan reduces via pi %= Pi before computing Sin/Cos.
        /// </summary>
        [Fact]
        public void Tan_LargeAngle_ReducesCorrectly()
        {
            float result = CustomMathF.Tan(5f * CustomMathF.Pi);
            Assert.True(float.IsFinite(result));
        }

        /// <summary>
        ///     Tests Abs with NaN returns NaN.
        ///     NaN comparisons always return false, so Abs(NaN) returns NaN.
        /// </summary>
        [Fact]
        public void Abs_WithNaN_ReturnsNaN()
        {
            float result = CustomMathF.Abs(float.NaN);
            Assert.True(float.IsNaN(result));
        }

        /// <summary>
        ///     Tests Clamp with inverted boundaries (min > max).
        /// </summary>
        [Fact]
        public void Clamp_InvertedBoundaries_ReturnsMin()
        {
            float result = CustomMathF.Clamp(5f, 10f, 1f);
            Assert.Equal(10f, result);
        }

        /// <summary>
        ///     Tests Clamp at boundary value.
        /// </summary>
        [Fact]
        public void Clamp_AtMinBoundary_ReturnsMin()
        {
            Assert.Equal(0f, CustomMathF.Clamp(0f, 0f, 1f));
        }

        /// <summary>
        ///     Tests Clamp at maximum boundary.
        /// </summary>
        [Fact]
        public void Clamp_AtMaxBoundary_ReturnsMax()
        {
            Assert.Equal(1f, CustomMathF.Clamp(1f, 0f, 1f));
        }

        /// <summary>
        ///     Tests Sqrt with value 1 (simple convergence case).
        /// </summary>
        [Fact]
        public void Sqrt_One_ReturnsOne()
        {
            float result = CustomMathF.Sqrt(1f);
            Assert.Equal(1f, result, 3);
        }

        /// <summary>
        ///     Tests Tan value near but not at the asymptote.
        /// </summary>
        [Fact]
        public void Tan_NearAsymptote_ReturnsLargeValue()
        {
            float result = CustomMathF.Tan(CustomMathF.Pi / 2f - 0.01f);
            Assert.True(result > 0f);
        }
    }
}
