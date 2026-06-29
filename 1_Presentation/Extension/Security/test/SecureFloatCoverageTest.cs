// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureFloatCoverageTest.cs
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
    ///     Targeted coverage tests for <see cref="SecureFloat" />.
    ///     Covers IEEE 754 special values, epsilon boundary, null Equals,
    ///     division by zero, negative arithmetic, and overflow.
    /// </summary>
    public class SecureFloatCoverageTest
    {
        /// <summary>
        ///     Tests NaN round-trips through obfuscation.
        /// </summary>
        [Fact]
        public void NaN_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.NaN);
            Assert.True(float.IsNaN(secureFloat));
        }

        /// <summary>
        ///     Tests positive infinity round-trips.
        /// </summary>
        [Fact]
        public void PositiveInfinity_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.PositiveInfinity);
            Assert.True(float.IsInfinity(secureFloat));
            Assert.True(secureFloat > 0);
        }

        /// <summary>
        ///     Tests negative infinity round-trips.
        /// </summary>
        [Fact]
        public void NegativeInfinity_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.NegativeInfinity);
            Assert.True(float.IsInfinity(secureFloat));
            Assert.True(secureFloat < 0);
        }

        /// <summary>
        ///     Tests negative zero round-trips.
        /// </summary>
        [Fact]
        public void NegativeZero_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(-0f);
            Assert.Equal(0f, (float)secureFloat);
        }

        /// <summary>
        ///     Tests the smallest positive float (denormalized) round-trips.
        /// </summary>
        [Fact]
        public void Epsilon_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.Epsilon);
            Assert.True((float)secureFloat > 0);
        }

        /// <summary>
        ///     Tests values within epsilon threshold (0.009f apart) are considered equal.
        /// </summary>
        [Fact]
        public void EpsilonBoundary_WithinThreshold_AreEqual()
        {
            SecureFloat a = new SecureFloat(100.0f);
            SecureFloat b = new SecureFloat(100.009f);

            Assert.True(a == b);
        }

        /// <summary>
        ///     Tests values beyond epsilon threshold (0.011f apart) are not equal.
        /// </summary>
        [Fact]
        public void EpsilonBoundary_BeyondThreshold_AreNotEqual()
        {
            SecureFloat a = new SecureFloat(100.0f);
            SecureFloat b = new SecureFloat(100.011f);

            Assert.False(a == b);
            Assert.True(a != b);
        }

        /// <summary>
        ///     Tests values within epsilon for inequality operator (should NOT be !=).
        /// </summary>
        [Fact]
        public void EpsilonBoundary_WithinThreshold_AreNotInequal()
        {
            SecureFloat a = new SecureFloat(100.0f);
            SecureFloat b = new SecureFloat(100.009f);

            Assert.False(a != b);
        }

        /// <summary>
        ///     Tests division by zero returns infinity.
        /// </summary>
        [Fact]
        public void DivisionByZero_ReturnsInfinity()
        {
            SecureFloat a = new SecureFloat(1.0f);
            SecureFloat b = new SecureFloat(0.0f);
            SecureFloat result = a / b;

            Assert.True(float.IsInfinity(result));
        }

        /// <summary>
        ///     Tests arithmetic with negative values.
        /// </summary>
        [Fact]
        public void NegativeValues_Arithmetic_Correct()
        {
            SecureFloat a = new SecureFloat(-10.0f);
            SecureFloat b = new SecureFloat(5.0f);

            Assert.Equal(-5f, (float)(a + b));
            Assert.Equal(-15f, (float)(a - b));
            Assert.Equal(-50f, (float)(a * b));
            Assert.Equal(-2f, (float)(a / b));
        }

        /// <summary>
        ///     Tests arithmetic with both operands negative.
        /// </summary>
        [Fact]
        public void BothNegative_Arithmetic_Correct()
        {
            SecureFloat a = new SecureFloat(-10.0f);
            SecureFloat b = new SecureFloat(-5.0f);

            Assert.Equal(-15f, (float)(a + b));
            Assert.Equal(-5f, (float)(a - b));
            Assert.Equal(50f, (float)(a * b));
            Assert.Equal(2f, (float)(a / b));
        }

        /// <summary>
        ///     Tests default constructor initializes to zero.
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesToZero()
        {
            SecureFloat secureFloat = new SecureFloat();
            Assert.Equal(0f, (float)secureFloat);
        }

        /// <summary>
        ///     Tests float.MaxValue round-trips.
        /// </summary>
        [Fact]
        public void MaxValue_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.MaxValue);
            Assert.Equal(float.MaxValue, (float)secureFloat);
        }

        /// <summary>
        ///     Tests float.MinValue round-trips.
        /// </summary>
        [Fact]
        public void MinValue_RoundTrips()
        {
            SecureFloat secureFloat = new SecureFloat(float.MinValue);
            Assert.Equal(float.MinValue, (float)secureFloat);
        }

        /// <summary>
        ///     Tests incrementing from boundary values.
        /// </summary>
        [Fact]
        public void Increment_MaxValue_DoesNotThrow()
        {
            SecureFloat secureFloat = new SecureFloat(float.MaxValue);
            secureFloat++;
        }

        /// <summary>
        ///     Tests decrementing from boundary values.
        /// </summary>
        [Fact]
        public void Decrement_MinValue_DoesNotThrow()
        {
            SecureFloat secureFloat = new SecureFloat(float.MinValue);
            secureFloat--;
        }
    }
}
