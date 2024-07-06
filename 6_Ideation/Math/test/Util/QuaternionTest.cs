// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QuaternionTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The quaternion test class
    /// </summary>
    public class QuaternionTest
    {
        /// <summary>
        ///     Tests that quaternion operator addition should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorAddition_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);
            Quaternion result = quaternion1 + quaternion2;

            Assert.Equal(6.0f, result.X);
            Assert.Equal(8.0f, result.Y);
            Assert.Equal(10.0f, result.Z);
            Assert.Equal(12.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion operator subtraction should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorSubtraction_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);
            Quaternion quaternion2 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion result = quaternion1 - quaternion2;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(4.0f, result.Z);
            Assert.Equal(4.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion operator multiplication should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorMultiplication_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);
            Quaternion result = quaternion1 * quaternion2;

            Assert.Equal(24.0f, result.X);
            Assert.Equal(48.0f, result.Y);
            Assert.Equal(48.0f, result.Z);
            Assert.Equal(-6.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion operator division should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorDivision_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, -2.0f, 3.0f, -4.0f);
            Quaternion quaternion2 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion result = quaternion1 / quaternion2;

            Assert.Equal(0.6f, result.X, 0.1f);
            Assert.Equal(0.0f, result.Y, 0.1f);
            Assert.Equal(0.6f, result.Z, 0.1f);
            Assert.Equal(-0.3f, result.W, 0.1f);
        }

        /// <summary>
        ///     Tests that quaternion operator unary negation should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorUnaryNegation_ShouldReturnCorrectResult()
        {
            Quaternion quaternion = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion result = -quaternion;

            Assert.Equal(-1.0f, result.X);
            Assert.Equal(-2.0f, result.Y);
            Assert.Equal(-3.0f, result.Z);
            Assert.Equal(-4.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion operator equality should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorEquality_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            bool areEqual = quaternion1 == quaternion2;

            Assert.True(areEqual);
        }

        /// <summary>
        ///     Tests that quaternion operator inequality should return correct result
        /// </summary>
        [Fact]
        public void Quaternion_OperatorInequality_ShouldReturnCorrectResult()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);
            bool areNotEqual = quaternion1 != quaternion2;

            Assert.True(areNotEqual);
        }

        /// <summary>
        ///     Tests that quaternion operator multiply should return correct result with two quaternions
        /// </summary>
        [Fact]
        public void Quaternion_OperatorMultiply_ShouldReturnCorrectResult_WithTwoQuaternions()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);
            Quaternion result = quaternion1 * quaternion2;

            Assert.Equal(24.0f, result.X);
            Assert.Equal(48.0f, result.Y);
            Assert.Equal(48.0f, result.Z);
            Assert.Equal(-6.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion operator multiply should return correct result with quaternion and scalar
        /// </summary>
        [Fact]
        public void Quaternion_OperatorMultiply_ShouldReturnCorrectResult_WithQuaternionAndScalar()
        {
            Quaternion quaternion = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            float scalar = 2.0f;
            Quaternion result = quaternion * scalar;

            Assert.Equal(2.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(6.0f, result.Z);
            Assert.Equal(8.0f, result.W);
        }

        /// <summary>
        ///     Tests that quaternion equals should return true when quaternions are equal
        /// </summary>
        [Fact]
        public void Quaternion_Equals_ShouldReturnTrue_WhenQuaternionsAreEqual()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.True(quaternion1.Equals(quaternion2));
        }

        /// <summary>
        ///     Tests that quaternion equals should return false when quaternions are not equal
        /// </summary>
        [Fact]
        public void Quaternion_Equals_ShouldReturnFalse_WhenQuaternionsAreNotEqual()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);

            Assert.False(quaternion1.Equals(quaternion2));
        }

        /// <summary>
        ///     Tests that quaternion equals should return false when compared with null
        /// </summary>
        [Fact]
        public void Quaternion_Equals_ShouldReturnFalse_WhenComparedWithNull()
        {
            Quaternion quaternion = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.False(quaternion.Equals(null));
        }

        /// <summary>
        ///     Tests that quaternion equals should return false when compared with different type
        /// </summary>
        [Fact]
        public void Quaternion_Equals_ShouldReturnFalse_WhenComparedWithDifferentType()
        {
            Quaternion quaternion = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f);

            Assert.False(quaternion.Equals(vector));
        }

        /// <summary>
        ///     Tests that quaternion get hash code should return same value for equal quaternions
        /// </summary>
        [Fact]
        public void Quaternion_GetHashCode_ShouldReturnSameValueForEqualQuaternions()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.Equal(quaternion1.GetHashCode(), quaternion2.GetHashCode());
        }

        /// <summary>
        ///     Tests that quaternion get hash code should return different values for different quaternions
        /// </summary>
        [Fact]
        public void Quaternion_GetHashCode_ShouldReturnDifferentValuesForDifferentQuaternions()
        {
            Quaternion quaternion1 = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            Quaternion quaternion2 = new Quaternion(5.0f, 6.0f, 7.0f, 8.0f);

            Assert.NotEqual(quaternion1.GetHashCode(), quaternion2.GetHashCode());
        }

        /// <summary>
        ///     Tests that quaternion to string should return correct format
        /// </summary>
        [Fact]
        public void Quaternion_ToString_ShouldReturnCorrectFormat()
        {
            Quaternion quaternion = new Quaternion(1.0f, 2.0f, 3.0f, 4.0f);
            string expectedString = "{X:1 Y:2 Z:3 W:4}";

            Assert.Equal(expectedString, quaternion.ToString());
        }
    }
}