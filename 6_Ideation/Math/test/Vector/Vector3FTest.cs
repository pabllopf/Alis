// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3FTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     The vector test class
    /// </summary>
    public class Vector3FTest
    {
        /// <summary>
        ///     Tests that constructor should set values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetValues()
        {
            // Arrange
            float x = 1;
            float y = 2;
            float z = 3;

            // Act
            Vector3F vector = new Vector3F(x, y, z);

            // Assert
            Assert.Equal(x, vector.X);
            Assert.Equal(y, vector.Y);
            Assert.Equal(z, vector.Z);
        }


        /// <summary>
        ///     Tests that dot product should calculate correctly
        /// </summary>
        [Fact]
        public void DotProduct_ShouldCalculateCorrectly()
        {
            // Arrange
            Vector3F vector1 = new Vector3F(1, 2, 3);
            Vector3F vector2 = new Vector3F(4, 5, 6);

            // Act
            float dotProduct = Vector3F.Dot(vector1, vector2);

            // Assert
            Assert.Equal(32, dotProduct); // 1*4 + 2*5 + 3*6 = 32
        }

        /// <summary>
        ///     Tests that constructor v 2 should set values
        /// </summary>
        [Fact]
        public void Constructor_v2_ShouldSetValues()
        {
            float x = 1.0f;
            float y = 2.0f;
            float z = 3.0f;

            Vector3F vector = new Vector3F(x, y, z);

            Assert.Equal(x, vector.X);
            Assert.Equal(y, vector.Y);
            Assert.Equal(z, vector.Z);
        }

        /// <summary>
        ///     Tests that dot product 3 should calculate correctly
        /// </summary>
        [Fact]
        public void DotProduct_3_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1, 2, 3);
            Vector3F vector2 = new Vector3F(4, 5, 6);

            float expectedDotProduct = 1 * 4 + 2 * 5 + 3 * 6;
            float actualDotProduct = Vector3F.Dot(vector1, vector2);

            Assert.Equal(expectedDotProduct, actualDotProduct);
        }

        /// <summary>
        ///     Tests that sqrt should calculate correctly
        /// </summary>
        [Fact]
        public void Sqrt_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = 4;

            // Act
            float result = (float)System.Math.Sqrt(x);

            // Assert
            Assert.Equal(2, result);
        }

        /// <summary>
        ///     Tests that abs should return absolute value
        /// </summary>
        [Fact]
        public void Abs_ShouldReturnAbsoluteValue()
        {
            // Arrange
            float value = -5;

            // Act
            float result = System.Math.Abs(value);

            // Assert
            Assert.Equal(5, result);
        }

        /// <summary>
        ///     Tests that cos should calculate correctly
        /// </summary>
        [Fact]
        public void Cos_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = (float)(System.Math.PI / 2);

            // Act
            float result = (float)System.Math.Cos(x);

            // Assert
            Assert.Equal(0, result, 5);
        }

        /// <summary>
        ///     Tests that sin should calculate correctly
        /// </summary>
        [Fact]
        public void Sin_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = (float)(System.Math.PI / 2);

            // Act
            float result = (float)System.Math.Sin(x);

            // Assert
            Assert.Equal(1, result, 5);
        }
        
        /// <summary>
        ///     Tests that max should return maximum value
        /// </summary>
        [Fact]
        public void Max_ShouldReturnMaximumValue()
        {
            // Arrange
            int val1 = 5;
            int val2 = 10;

            // Act
            int result = System.Math.Max(val1, val2);

            // Assert
            Assert.Equal(val2, result);
        }

        /// <summary>
        ///     Tests that vector 3 addition operator should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Addition_Operator_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = vector1 + vector2;

            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
            Assert.Equal(9.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 subtraction operator should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Subtraction_Operator_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = vector1 - vector2;

            Assert.Equal(-3.0f, result.X);
            Assert.Equal(-3.0f, result.Y);
            Assert.Equal(-3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 multiplication operator should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Multiplication_Operator_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = vector1 * 2.0f;

            Assert.Equal(2.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(6.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 division operator should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Division_Operator_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(2.0f, 4.0f, 6.0f);
            Vector3F result = vector1 / 2.0f;

            Assert.Equal(1.0f, result.X);
            Assert.Equal(2.0f, result.Y);
            Assert.Equal(3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 dot should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Dot_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            float result = Vector3F.Dot(vector1, vector2);

            Assert.Equal(32.0f, result);
        }

        /// <summary>
        ///     Tests that vector 3 cross should calculate correctly
        /// </summary>
        [Fact]
        public void Vector3_Cross_ShouldCalculateCorrectly()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = Vector3F.Cross(vector1, vector2);

            Assert.Equal(-3.0f, result.X);
            Assert.Equal(6.0f, result.Y);
            Assert.Equal(-3.0f, result.Z);
        }


        /// <summary>
        ///     Tests that vector 3 zero should return zero vector
        /// </summary>
        [Fact]
        public void Vector3_Zero_ShouldReturnZeroVector()
        {
            Vector3F result = Vector3F.Zero;
            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 one should return one vector
        /// </summary>
        [Fact]
        public void Vector3_One_ShouldReturnOneVector()
        {
            Vector3F result = Vector3F.One;
            Assert.Equal(1.0f, result.X);
            Assert.Equal(1.0f, result.Y);
            Assert.Equal(1.0f, result.Z);
        }


        /// <summary>
        ///     Tests that vector 3 addition operator should return correct result
        /// </summary>
        [Fact]
        public void Vector3_AdditionOperator_ShouldReturnCorrectResult()
        {
            Vector3F left = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F right = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = left + right;

            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
            Assert.Equal(9.0f, result.Z);
        }


        /// <summary>
        ///     Tests that vector 3 equals should return true when vectors are equal
        /// </summary>
        [Fact]
        public void Vector3_Equals_ShouldReturnTrue_WhenVectorsAreEqual()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(1.0f, 2.0f, 3.0f);

            Assert.True(vector1.Equals(vector2));
        }

        /// <summary>
        ///     Tests that vector 3 equals should return false when vectors are not equal
        /// </summary>
        [Fact]
        public void Vector3_Equals_ShouldReturnFalse_WhenVectorsAreNotEqual()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);

            Assert.False(vector1.Equals(vector2));
        }

        /// <summary>
        ///     Tests that vector 3 equals should return false when compared with null
        /// </summary>
        [Fact]
        public void Vector3_Equals_ShouldReturnFalse_WhenComparedWithNull()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);

            Assert.False(vector1.Equals(null));
        }

        /// <summary>
        ///     Tests that vector 3 get hash code should return same hash code when vectors are equal
        /// </summary>
        [Fact]
        public void Vector3_GetHashCode_ShouldReturnSameHashCode_WhenVectorsAreEqual()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(1.0f, 2.0f, 3.0f);

            Assert.Equal(vector1.GetHashCode(), vector2.GetHashCode());
        }

        /// <summary>
        ///     Tests that vector 3 get hash code should return different hash code when vectors are not equal
        /// </summary>
        [Fact]
        public void Vector3_GetHashCode_ShouldReturnDifferentHashCode_WhenVectorsAreNotEqual()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);

            Assert.NotEqual(vector1.GetHashCode(), vector2.GetHashCode());
        }

        /// <summary>
        ///     Tests that vector 3 dot should return correct result
        /// </summary>
        [Fact]
        public void Vector3_Dot_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            float result = Vector3F.Dot(vector1, vector2);

            Assert.Equal(32.0f, result);
        }

        /// <summary>
        ///     Tests that vector 3 cross should return correct result
        /// </summary>
        [Fact]
        public void Vector3_Cross_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = Vector3F.Cross(vector1, vector2);

            Assert.Equal(-3.0f, result.X);
            Assert.Equal(6.0f, result.Y);
            Assert.Equal(-3.0f, result.Z);
        }


        /// <summary>
        ///     Tests that vector 3 operator addition should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorAddition_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = vector1 + vector2;

            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
            Assert.Equal(9.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator subtraction should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorSubtraction_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F vector2 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = vector1 - vector2;

            Assert.Equal(3.0f, result.X);
            Assert.Equal(3.0f, result.Y);
            Assert.Equal(3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator multiplication should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorMultiplication_ShouldReturnCorrectResult()
        {
            Vector3F vector = new Vector3F(1.0f, 2.0f, 3.0f);
            float scalar = 2.0f;
            Vector3F result = vector * scalar;

            Assert.Equal(2.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(6.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator division should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorDivision_ShouldReturnCorrectResult()
        {
            Vector3F vector = new Vector3F(2.0f, 4.0f, 6.0f);
            float scalar = 2.0f;
            Vector3F result = vector / scalar;

            Assert.Equal(1.0f, result.X);
            Assert.Equal(2.0f, result.Y);
            Assert.Equal(3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator unary negation should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorUnaryNegation_ShouldReturnCorrectResult()
        {
            Vector3F vector = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = -vector;

            Assert.Equal(-1.0f, result.X);
            Assert.Equal(-2.0f, result.Y);
            Assert.Equal(-3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator equality should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorEquality_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(1.0f, 2.0f, 3.0f);
            bool areEqual = vector1 == vector2;

            Assert.True(areEqual);
        }

        /// <summary>
        ///     Tests that vector 3 operator inequality should return correct result
        /// </summary>
        [Fact]
        public void Vector3_OperatorInequality_ShouldReturnCorrectResult()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            bool areNotEqual = vector1 != vector2;

            Assert.True(areNotEqual);
        }

        /// <summary>
        ///     Tests that vector 3 operator multiply should return correct result with two vectors
        /// </summary>
        [Fact]
        public void Vector3_OperatorMultiply_ShouldReturnCorrectResult_WithTwoVectors()
        {
            Vector3F vector1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F vector2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = vector1 * vector2;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(10.0f, result.Y);
            Assert.Equal(18.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator multiply should return correct result with vector and scalar
        /// </summary>
        [Fact]
        public void Vector3_OperatorMultiply_ShouldReturnCorrectResult_WithVectorAndScalar()
        {
            Vector3F vector = new Vector3F(1.0f, 2.0f, 3.0f);
            float scalar = 2.0f;
            Vector3F result = vector * scalar;

            Assert.Equal(2.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(6.0f, result.Z);
        }

        /// <summary>
        ///     Tests that vector 3 operator multiply should return correct result with scalar and vector
        /// </summary>
        [Fact]
        public void Vector3_OperatorMultiply_ShouldReturnCorrectResult_WithScalarAndVector()
        {
            float scalar = 2.0f;
            Vector3F vector = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = scalar * vector;

            Assert.Equal(2.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(6.0f, result.Z);
        }
    }
}