// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureRandomTests.cs
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

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     Tests for the SecureRandom static class.
    /// </summary>
    public class SecureRandomTests
    {
        /// <summary>
        ///     Tests that NextInt returns a value.
        /// </summary>
        [Fact]
        public void NextInt_ShouldReturnValue()
        {
            int result = SecureRandom.NextInt();
        }

        /// <summary>
        ///     Tests that NextInt returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextInt_ShouldReturnDifferentValues()
        {
            int first = SecureRandom.NextInt();
            int second = SecureRandom.NextInt();

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that NextChar returns a value.
        /// </summary>
        [Fact]
        public void NextChar_ShouldReturnValue()
        {
            char result = SecureRandom.NextChar();
        }

        /// <summary>
        ///     Tests that NextChar returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextChar_ShouldReturnDifferentValues()
        {
            char first = SecureRandom.NextChar();
            char second = SecureRandom.NextChar();

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that NextLong returns a value.
        /// </summary>
        [Fact]
        public void NextLong_ShouldReturnValue()
        {
            long result = SecureRandom.NextLong();
        }

        /// <summary>
        ///     Tests that NextLong returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextLong_ShouldReturnDifferentValues()
        {
            long first = SecureRandom.NextLong();
            long second = SecureRandom.NextLong();

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that NextByte returns a value.
        /// </summary>
        [Fact]
        public void NextByte_ShouldReturnValue()
        {
            byte result = SecureRandom.NextByte();
        }

        /// <summary>
        ///     Tests that NextDouble returns a value within the specified range.
        /// </summary>
        [Fact]
        public void NextDouble_WithRange_ShouldReturnValueInRange()
        {
            double result = SecureRandom.NextDouble(10, 20);

            Assert.InRange(result, 10.0, 20.0);
        }

        /// <summary>
        ///     Tests that NextDouble with zero range returns the lower bound.
        /// </summary>
        [Fact]
        public void NextDouble_WithZeroRange_ShouldReturnLowerBound()
        {
            double result = SecureRandom.NextDouble(5, 5);

            Assert.Equal(5.0, result);
        }

        /// <summary>
        ///     Tests that NextDouble returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextDouble_ShouldReturnDifferentValues()
        {
            double first = SecureRandom.NextDouble(0, 100);
            double second = SecureRandom.NextDouble(0, 100);

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that NextFloat returns a value within the specified range.
        /// </summary>
        [Fact]
        public void NextFloat_WithRange_ShouldReturnValueInRange()
        {
            float result = SecureRandom.NextFloat(10, 20);

            Assert.InRange(result, 10.0f, 20.0f);
        }

        /// <summary>
        ///     Tests that NextFloat with zero range returns the lower bound.
        /// </summary>
        [Fact]
        public void NextFloat_WithZeroRange_ShouldReturnLowerBound()
        {
            float result = SecureRandom.NextFloat(5, 5);

            Assert.Equal(5.0f, result);
        }

        /// <summary>
        ///     Tests that NextFloat returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextFloat_ShouldReturnDifferentValues()
        {
            float first = SecureRandom.NextFloat(0, 100);
            float second = SecureRandom.NextFloat(0, 100);

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that NextDecimal returns a value within the specified range.
        /// </summary>
        [Fact]
        public void NextDecimal_WithRange_ShouldReturnValueInRange()
        {
            decimal result = SecureRandom.NextDecimal(10, 20);

            Assert.InRange(result, 10.0m, 20.0m);
        }

        /// <summary>
        ///     Tests that NextDecimal with zero range returns the lower bound.
        /// </summary>
        [Fact]
        public void NextDecimal_WithZeroRange_ShouldReturnLowerBound()
        {
            decimal result = SecureRandom.NextDecimal(5, 5);

            Assert.Equal(5.0m, result);
        }

        /// <summary>
        ///     Tests that NextDecimal returns different values on subsequent calls.
        /// </summary>
        [Fact]
        public void NextDecimal_ShouldReturnDifferentValues()
        {
            decimal first = SecureRandom.NextDecimal(0, 100);
            decimal second = SecureRandom.NextDecimal(0, 100);

            Assert.NotEqual(first, second);
        }

        /// <summary>
        ///     Tests that Abs returns the same value for a positive input.
        /// </summary>
        [Fact]
        public void Abs_WithPositiveValue_ShouldReturnSameValue()
        {
            float result = SecureRandom.Abs(5.5f);

            Assert.Equal(5.5f, result);
        }

        /// <summary>
        ///     Tests that Abs returns the positive value for a negative input.
        /// </summary>
        [Fact]
        public void Abs_WithNegativeValue_ShouldReturnPositiveValue()
        {
            float result = SecureRandom.Abs(-5.5f);

            Assert.Equal(5.5f, result);
        }

        /// <summary>
        ///     Tests that Abs returns zero for zero input.
        /// </summary>
        [Fact]
        public void Abs_WithZero_ShouldReturnZero()
        {
            float result = SecureRandom.Abs(0f);

            Assert.Equal(0f, result);
        }
    }
}
