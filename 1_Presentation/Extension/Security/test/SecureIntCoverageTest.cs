// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureIntCoverageTest.cs
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
    ///     Targeted coverage tests for <see cref="SecureInt" />.
    ///     Covers int overflow (unchecked wrap), MaxValue/MinValue round-trip,
    ///     division by zero, negative arithmetic, and default constructor.
    /// </summary>
    public class SecureIntCoverageTest
    {
        /// <summary>
        ///     Tests default constructor initializes to zero.
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesToZero()
        {
            SecureInt secureInt = new SecureInt();
            Assert.Equal(0, (int)secureInt);
        }

        /// <summary>
        ///     Tests int.MaxValue round-trips correctly through obfuscation.
        ///     Unlike decimal, int unchecked modular arithmetic preserves all values.
        /// </summary>
        [Fact]
        public void MaxValue_RoundTrips()
        {
            SecureInt secureInt = new SecureInt(int.MaxValue);
            Assert.Equal(int.MaxValue, (int)secureInt);
        }

        /// <summary>
        ///     Tests int.MinValue round-trips correctly through obfuscation.
        /// </summary>
        [Fact]
        public void MinValue_RoundTrips()
        {
            SecureInt secureInt = new SecureInt(int.MinValue);
            Assert.Equal(int.MinValue, (int)secureInt);
        }

        /// <summary>
        ///     Tests arithmetic with negative values.
        /// </summary>
        [Fact]
        public void NegativeValues_Arithmetic_Correct()
        {
            SecureInt a = new SecureInt(-10);
            SecureInt b = new SecureInt(5);

            Assert.Equal(-5, (int)(a + b));
            Assert.Equal(-15, (int)(a - b));
            Assert.Equal(-50, (int)(a * b));
            Assert.Equal(-2, (int)(a / b));
        }

        /// <summary>
        ///     Tests both operands negative.
        /// </summary>
        [Fact]
        public void BothNegative_Arithmetic_Correct()
        {
            SecureInt a = new SecureInt(-10);
            SecureInt b = new SecureInt(-5);

            Assert.Equal(-15, (int)(a + b));
            Assert.Equal(-5, (int)(a - b));
            Assert.Equal(50, (int)(a * b));
            Assert.Equal(2, (int)(a / b));
        }

        /// <summary>
        ///     Tests addition overflow wraps correctly (unchecked).
        ///     int.MaxValue + 1 = int.MinValue.
        /// </summary>
        [Fact]
        public void Addition_Overflow_Wraps()
        {
            SecureInt a = new SecureInt(int.MaxValue);
            SecureInt b = new SecureInt(1);
            SecureInt result = a + b;

            Assert.Equal(int.MinValue, (int)result);
        }

        /// <summary>
        ///     Tests subtraction underflow wraps correctly (unchecked).
        ///     int.MinValue - 1 = int.MaxValue.
        /// </summary>
        [Fact]
        public void Subtraction_Underflow_Wraps()
        {
            SecureInt a = new SecureInt(int.MinValue);
            SecureInt b = new SecureInt(1);
            SecureInt result = a - b;

            Assert.Equal(int.MaxValue, (int)result);
        }

        /// <summary>
        ///     Tests multiplication overflow wraps correctly.
        /// </summary>
        [Fact]
        public void Multiplication_Overflow_Wraps()
        {
            SecureInt a = new SecureInt(int.MaxValue);
            SecureInt b = new SecureInt(2);
            SecureInt result = a * b;

            unchecked
            {
                Assert.Equal(int.MaxValue * 2, (int)result);
            }
        }

        /// <summary>
        ///     Tests division by zero throws.
        /// </summary>
        [Fact]
        public void DivisionByZero_Throws()
        {
            SecureInt a = new SecureInt(10);
            SecureInt b = new SecureInt(0);
            Assert.Throws<System.DivideByZeroException>(() => a / b);
        }

        /// <summary>
        ///     Tests increment overflow wraps.
        /// </summary>
        [Fact]
        public void Increment_MaxValue_WrapsToMinValue()
        {
            SecureInt secureInt = new SecureInt(int.MaxValue);
            secureInt++;
            Assert.Equal(int.MinValue, (int)secureInt);
        }

        /// <summary>
        ///     Tests decrement underflow wraps.
        /// </summary>
        [Fact]
        public void Decrement_MinValue_WrapsToMaxValue()
        {
            SecureInt secureInt = new SecureInt(int.MinValue);
            secureInt--;
            Assert.Equal(int.MaxValue, (int)secureInt);
        }

        /// <summary>
        ///     Tests zero arithmetic.
        /// </summary>
        [Fact]
        public void Zero_Arithmetic_Correct()
        {
            SecureInt zero = new SecureInt(0);
            SecureInt five = new SecureInt(5);

            Assert.Equal(5, (int)(zero + five));
            Assert.Equal(-5, (int)(zero - five));
            Assert.Equal(0, (int)(zero * five));
            Assert.Equal(0, (int)(zero / five));
        }
    }
}
