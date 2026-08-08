// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QuaternionRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The quaternion remaining coverage tests class
    /// </summary>
    public class QuaternionRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that internal equals returns true when quaternions are equal
        /// </summary>
        [Fact]
        public void Equals_Internal_ShouldReturnTrue_WhenQuaternionsAreEqual()
        {
            Quaternion left = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion right = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            bool result = left.Equals(right);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that internal equals returns false when quaternions are not equal
        /// </summary>
        [Fact]
        public void Equals_Internal_ShouldReturnFalse_WhenQuaternionsAreNotEqual()
        {
            Quaternion left = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion right = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);

            bool result = left.Equals(right);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that internal equals uses exact comparison (not tolerance-based)
        /// </summary>
        [Fact]
        public void Equals_Internal_ShouldUseExactComparison()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion slightlyDifferent = new Quaternion(1.05f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals(slightlyDifferent);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that division by a non-identity quaternion produces the correct result
        /// </summary>
        [Fact]
        public void Division_ByNonIdentityQuaternion_ShouldReturnCorrectResult()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion divisor = new Quaternion(2.0f, 3.0f, 4.0f, 5.0f);
            Quaternion result = value / divisor;

            Assert.Equal(-1.0f / 27.0f, result.X, 4);
            Assert.Equal(-2.0f / 27.0f, result.Y, 4);
            Assert.Equal(0.0f, result.Z, 4);
            Assert.Equal(20.0f / 27.0f, result.W, 4);
        }

        /// <summary>
        ///     Tests that dividing and then multiplying by the same divisor approximates the original value
        /// </summary>
        [Fact]
        public void Division_ResultMultipliedByDivisor_ShouldApproximateOriginal()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion divisor = new Quaternion(0.5f, 1.0f, 1.5f, 2.0f);
            Quaternion quotient = value / divisor;
            Quaternion roundTrip = quotient * divisor;

            Assert.Equal(value.X, roundTrip.X, 3);
            Assert.Equal(value.Y, roundTrip.Y, 3);
            Assert.Equal(value.Z, roundTrip.Z, 3);
            Assert.Equal(value.W, roundTrip.W, 3);
        }

        /// <summary>
        ///     Tests that the default quaternion has all components set to zero
        /// </summary>
        [Fact]
        public void Default_Quaternion_ShouldHaveAllComponentsZero()
        {
            Quaternion value = default;

            Assert.Equal(0.0f, value.X, 5);
            Assert.Equal(0.0f, value.Y, 5);
            Assert.Equal(0.0f, value.Z, 5);
            Assert.Equal(0.0f, value.W, 5);
        }

        /// <summary>
        ///     Tests that the constructor correctly stores negative values
        /// </summary>
        [Fact]
        public void Constructor_NegativeValues_ShouldStoreCorrectly()
        {
            Quaternion value = new Quaternion(-1.0f, -2.0f, -3.0f, -4.0f);

            Assert.Equal(-1.0f, value.X, 5);
            Assert.Equal(-2.0f, value.Y, 5);
            Assert.Equal(-3.0f, value.Z, 5);
            Assert.Equal(-4.0f, value.W, 5);
        }

        /// <summary>
        ///     Tests that the constructor correctly stores all zero values
        /// </summary>
        [Fact]
        public void Constructor_ZeroValues_ShouldStoreCorrectly()
        {
            Quaternion value = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            Assert.Equal(0.0f, value.X, 5);
            Assert.Equal(0.0f, value.Y, 5);
            Assert.Equal(0.0f, value.Z, 5);
            Assert.Equal(0.0f, value.W, 5);
        }

        /// <summary>
        ///     Tests that the constructor correctly stores mixed negative and positive values
        /// </summary>
        [Fact]
        public void Constructor_MixedNegativeAndPositive_ShouldStoreCorrectly()
        {
            Quaternion value = new Quaternion(-1.0f, 2.0f, -3.0f, 4.0f);

            Assert.Equal(-1.0f, value.X, 5);
            Assert.Equal(2.0f, value.Y, 5);
            Assert.Equal(-3.0f, value.Z, 5);
            Assert.Equal(4.0f, value.W, 5);
        }

        /// <summary>
        ///     Tests that the equality operator returns false when the difference exceeds the tolerance on X
        /// </summary>
        [Fact]
        public void OperatorEquality_WithSingleComponentBeyondTolerance_ShouldReturnFalse()
        {
            Quaternion left = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion right = new Quaternion(1.2f, 2.0f, 3.0f, 4.0f);

            bool areEqual = left == right;

            Assert.False(areEqual);
        }

        /// <summary>
        ///     Tests that the equality operator returns false when all components are beyond tolerance
        /// </summary>
        [Fact]
        public void OperatorEquality_WithAllComponentsBeyondTolerance_ShouldReturnFalse()
        {
            Quaternion left = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion right = new Quaternion(2.0f, 3.0f, 4.0f, 5.0f);

            bool areEqual = left == right;

            Assert.False(areEqual);
        }

        /// <summary>
        ///     Tests that equals object returns false when comparing with an int
        /// </summary>
        [Fact]
        public void Equals_Object_WithIntType_ShouldReturnFalse()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals(42);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equals object returns false when comparing with a float
        /// </summary>
        [Fact]
        public void Equals_Object_WithFloatType_ShouldReturnFalse()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals(1.0f);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equals object returns false when comparing with a string
        /// </summary>
        [Fact]
        public void Equals_Object_WithStringType_ShouldReturnFalse()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals("quaternion");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equals object returns true when comparing with a boxed quaternion
        /// </summary>
        [Fact]
        public void Equals_Object_WithSelf_WhenBoxed_ShouldReturnTrue()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            object boxed = value;

            bool result = value.Equals(boxed);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that the precomputed hash code field is non-zero for a non-default quaternion
        /// </summary>
        [Fact]
        public void HashCode_Field_ShouldBePrecomputedAndNonZeroForNonDefault()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.NotEqual(0, value.hashCode);
        }

        /// <summary>
        ///     Tests that the precomputed hash code field is the same for equal quaternions
        /// </summary>
        [Fact]
        public void HashCode_Field_ShouldBeSameForEqualQuaternions()
        {
            Quaternion first = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion second = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.Equal(first.hashCode, second.hashCode);
        }

        /// <summary>
        ///     Tests that the default quaternion has a zero hash code
        /// </summary>
        [Fact]
        public void Default_Quaternion_HashCode_ShouldBeZero()
        {
            Quaternion value = default;

            Assert.Equal(0, value.hashCode);
        }

        /// <summary>
        ///     Tests that equals object uses exact comparison when comparing with a boxed quaternion slightly different
        /// </summary>
        [Fact]
        public void Equals_Object_WithBoxedQuaternionSlightlyDifferent_ShouldReturnFalse()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            object slightlyDifferent = new Quaternion(1.05f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals(slightlyDifferent);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equals object with boxed quaternion exactly equal returns true
        /// </summary>
        [Fact]
        public void Equals_Object_WithBoxedQuaternionExactMatch_ShouldReturnTrue()
        {
            Quaternion value = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            object exact = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            bool result = value.Equals(exact);

            Assert.True(result);
        }
    }
}
