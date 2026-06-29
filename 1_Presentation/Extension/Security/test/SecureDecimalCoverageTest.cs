// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureDecimalCoverageTest.cs
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

using System.Globalization;
using System.Threading;
using Xunit;

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="SecureDecimal" />.
    ///     Covers decimal overflow, precision, negative arithmetic,
    ///     near-boundary values, default constructor, and locale-independent ToString.
    /// </summary>
    public class SecureDecimalCoverageTest
    {
        /// <summary>
        ///     Tests default constructor initializes to zero.
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesToZero()
        {
            SecureDecimal secureDecimal = new SecureDecimal();
            Assert.Equal(0m, (decimal)secureDecimal);
        }

        /// <summary>
        ///     Tests a near-MaxValue value round-trips.
        ///     Uses MaxValue - 1024m which safely accommodates the random offset range [-1024, 1024].
        /// </summary>
        [Fact]
        public void NearMaxValue_RoundTrips()
        {
            decimal nearMax = decimal.MaxValue - 1024m;
            SecureDecimal secureDecimal = new SecureDecimal(nearMax);
            Assert.Equal(nearMax, (decimal)secureDecimal);
        }

        /// <summary>
        ///     Tests a near-MinValue value round-trips.
        ///     Uses MinValue + 1024m which safely accommodates the random offset range [-1024, 1024].
        /// </summary>
        [Fact]
        public void NearMinValue_RoundTrips()
        {
            decimal nearMin = decimal.MinValue + 1024m;
            SecureDecimal secureDecimal = new SecureDecimal(nearMin);
            Assert.Equal(nearMin, (decimal)secureDecimal);
        }

        /// <summary>
        ///     Tests arithmetic with negative values.
        /// </summary>
        [Fact]
        public void NegativeValues_Arithmetic_Correct()
        {
            SecureDecimal a = new SecureDecimal(-10m);
            SecureDecimal b = new SecureDecimal(5m);

            Assert.Equal(-5m, (decimal)(a + b));
            Assert.Equal(-15m, (decimal)(a - b));
            Assert.Equal(-50m, (decimal)(a * b));
            Assert.Equal(-2m, (decimal)(a / b));
        }

        /// <summary>
        ///     Tests both operands negative.
        /// </summary>
        [Fact]
        public void BothNegative_Arithmetic_Correct()
        {
            SecureDecimal a = new SecureDecimal(-10m);
            SecureDecimal b = new SecureDecimal(-5m);

            Assert.Equal(-15m, (decimal)(a + b));
            Assert.Equal(-5m, (decimal)(a - b));
            Assert.Equal(50m, (decimal)(a * b));
            Assert.Equal(2m, (decimal)(a / b));
        }

        /// <summary>
        ///     Tests decimal division with repeating decimal (1/3).
        ///     Verifies that the division result multiplied by 3 is approximately 1.
        /// </summary>
        [Fact]
        public void Division_RepeatingDecimal_Correct()
        {
            SecureDecimal a = new SecureDecimal(1m);
            SecureDecimal b = new SecureDecimal(3m);
            SecureDecimal result = a / b;

            SecureDecimal check = result * 3m;
            decimal diff = (decimal)check - 1m;
            Assert.True(System.Math.Abs(diff) < 0.00000000000000000001m);
        }

        /// <summary>
        ///     Tests moderately high precision decimals round-trip correctly.
        ///     The obfuscation offset (±1024) limits round-trippable precision to ~25 digits.
        /// </summary>
        [Fact]
        public void ModeratePrecision_RoundTrips()
        {
            decimal precise = 1.0000000000000000001m;
            SecureDecimal secureDecimal = new SecureDecimal(precise);
            Assert.Equal(precise, (decimal)secureDecimal);
        }

        /// <summary>
        ///     Tests that a SecureDecimal with very small magnitude approximates zero
        ///     due to the magnitude of the random obfuscation offset (±1024).
        ///     This documents the precision limitation of the obfuscation scheme.
        /// </summary>
        [Fact]
        public void VerySmall_Magnitude_LostToObfuscation()
        {
            decimal small = 0.0000000000000000000000000001m;
            SecureDecimal secureDecimal = new SecureDecimal(small);
            decimal retrieved = (decimal)secureDecimal;
            Assert.True(System.Math.Abs(retrieved) < 1m);
        }

        /// <summary>
        ///     Tests zero with arithmetic.
        /// </summary>
        [Fact]
        public void Zero_Arithmetic_Correct()
        {
            SecureDecimal zero = new SecureDecimal(0m);
            SecureDecimal five = new SecureDecimal(5m);

            Assert.Equal(5m, (decimal)(zero + five));
            Assert.Equal(-5m, (decimal)(zero - five));
            Assert.Equal(0m, (decimal)(zero * five));
            Assert.Equal(0m, (decimal)(zero / five));
        }

        /// <summary>
        ///     Tests addition overflow throws OverflowException.
        ///     a = MaxValue - 1024 (safely fits with random offset)
        ///     b = 1025
        ///     a.Value + b.Value = MaxValue + 1  → overflow in decimal arithmetic.
        /// </summary>
        [Fact]
        public void Addition_Overflow_ThrowsOverflowException()
        {
            SecureDecimal a = new SecureDecimal(decimal.MaxValue - 1024m);
            SecureDecimal b = new SecureDecimal(1025m);
            Assert.Throws<System.OverflowException>(() => a + b);
        }

        /// <summary>
        ///     Tests multiplication overflow throws OverflowException.
        ///     a = MaxValue/2 + 1000
        ///     b = 2
        ///     a.Value * b.Value overflows decimal range.
        /// </summary>
        [Fact]
        public void Multiplication_Overflow_ThrowsOverflowException()
        {
            SecureDecimal a = new SecureDecimal(decimal.MaxValue / 2 + 1000m);
            SecureDecimal b = new SecureDecimal(2m);
            Assert.Throws<System.OverflowException>(() => a * b);
        }

        /// <summary>
        ///     Tests ToString with a decimal value.
        /// </summary>
        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            SecureDecimal secureDecimal = new SecureDecimal(123.456m);
            string result = secureDecimal.ToString();
            Assert.Contains("123.456", result);
        }

        /// <summary>
        ///     Tests ToString uses InvariantCulture (always '.' as decimal separator).
        /// </summary>
        [Fact]
        public void ToString_UsesInvariantCulture()
        {
            CultureInfo original = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                SecureDecimal secureDecimal = new SecureDecimal(123.456m);
                string result = secureDecimal.ToString();
                Assert.Contains(".456", result);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = original;
            }
        }
    }
}
