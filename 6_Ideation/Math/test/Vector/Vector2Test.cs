// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Vector2Test.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System;
using System.Globalization;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     The vector test class
    /// </summary>
    public class Vector2Test
    {
        /// <summary>
        ///     Tests that vector 2 addition
        /// </summary>
        [Fact]
        public void Vector2_Addition()
        {
            Vector2 v1 = new Vector2(1, 2);
            Vector2 v2 = new Vector2(3, 4);

            Vector2 result = v1 + v2;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 subtraction
        /// </summary>
        [Fact]
        public void Vector2_Subtraction()
        {
            Vector2 v1 = new Vector2(3, 4);
            Vector2 v2 = new Vector2(1, 2);

            Vector2 result = v1 - v2;

            Assert.Equal(2, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 division
        /// </summary>
        [Fact]
        public void Vector2_Division()
        {
            Vector2 v1 = new Vector2(6, 8);
            float scalar = 2;

            Vector2 result = v1 / scalar;

            Assert.Equal(3, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 distance
        /// </summary>
        [Fact]
        public void Vector2_Distance()
        {
            Vector2 v1 = new Vector2(1, 2);
            Vector2 v2 = new Vector2(4, 6);

            float distance = Vector2.Distance(v1, v2);

            Assert.Equal(5, distance);
        }

        /// <summary>
        ///     Tests that vector 2 length
        /// </summary>
        [Fact]
        public void Vector2_Length()
        {
            Vector2 vector = new Vector2(3, 4);

            float length = vector.Length();

            Assert.Equal(5, length);
        }

        /// <summary>
        ///     Tests that vector 2 normalize
        /// </summary>
        [Fact]
        public void Vector2_Normalize()
        {
            Vector2 vector = new Vector2(3, 4);

            Vector2 normalized = Vector2.Normalize(vector);

            Assert.Equal(0.6f, normalized.X, 2);
            Assert.Equal(0.8f, normalized.Y, 2);
        }

        /// <summary>
        ///     Tests that test equals method
        /// </summary>
        [Fact]
        public void TestEqualsMethod()
        {
            // Arrange
            Vector2 vectorA = new Vector2(1.0f, 2.0f);
            Vector2 vectorB = new Vector2(1.0f, 2.0f);
            Vector2 vectorC = new Vector2(2.0f, 3.0f);

            // Act & Assert
            Assert.True(vectorA.Equals(vectorB)); // Vector A should be equal to Vector B
            Assert.False(vectorA.Equals(vectorC)); // Vector A should not be equal to Vector C
        }

        /// <summary>
        ///     Tests that test copy to method
        /// </summary>
        [Fact]
        public void TestCopyToMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(3.0f, 4.0f);
            float[] array = new float[2];

            // Act
            vector.CopyTo(array);

            // Assert
            Assert.Equal(3.0f, array[0]);
            Assert.Equal(4.0f, array[1]);
        }

        /// <summary>
        ///     Tests that test copy to method with index
        /// </summary>
        [Fact]
        public void TestCopyToMethodWithIndex()
        {
            // Arrange
            Vector2 vector = new Vector2(5.0f, 6.0f);
            float[] array = new float[4];

            // Act
            vector.CopyTo(array, 2);

            // Assert
            Assert.Equal(0.0f, array[0]); // First two elements should be untouched
            Assert.Equal(0.0f, array[1]);
            Assert.Equal(5.0f, array[2]); // Vector elements should be copied
            Assert.Equal(6.0f, array[3]);
        }

        /// <summary>
        ///     Tests that test to string method with format and provider
        /// </summary>
        [Fact]
        public void TestToStringMethodWithFormatAndProvider()
        {
            // Arrange
            Vector2 vector = new Vector2(11.0f, 12.0f);

            // Act
            string result = vector.ToString("F2", CultureInfo.InvariantCulture);

            // Assert
            Assert.Equal("<11.00, 12.00>", result);
        }

        /// <summary>
        ///     Tests that test static addition method
        /// </summary>
        [Fact]
        public void TestStaticAdditionMethod()
        {
            // Arrange
            Vector2 vectorA = new Vector2(1.0f, 2.0f);
            Vector2 vectorB = new Vector2(3.0f, 4.0f);

            // Act
            Vector2 result = Vector2.Add(vectorA, vectorB);

            // Assert
            Assert.Equal(new Vector2(4.0f, 6.0f), result);
        }

        /// <summary>
        ///     Tests that test static subtraction method
        /// </summary>
        [Fact]
        public void TestStaticSubtractionMethod()
        {
            // Arrange
            Vector2 vectorA = new Vector2(5.0f, 7.0f);
            Vector2 vectorB = new Vector2(2.0f, 3.0f);

            // Act
            Vector2 result = Vector2.Subtract(vectorA, vectorB);

            // Assert
            Assert.Equal(new Vector2(3.0f, 4.0f), result);
        }

        /// <summary>
        ///     Tests that test static multiply method
        /// </summary>
        [Fact]
        public void TestStaticMultiplyMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);
            float scalar = 1.5f;

            // Act
            Vector2 result = Vector2.Multiply(vector, scalar);

            // Assert
            Assert.Equal(new Vector2(3.0f, 4.5f), result);
        }

        /// <summary>
        ///     Tests that test static divide method
        /// </summary>
        [Fact]
        public void TestStaticDivideMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(6.0f, 9.0f);
            float divisor = 3.0f;

            // Act
            Vector2 result = Vector2.Divide(vector, divisor);

            // Assert
            Assert.Equal(new Vector2(2.0f, 3.0f), result);
        }

        /// <summary>
        ///     Tests that test dot product method
        /// </summary>
        [Fact]
        public void TestDotProductMethod()
        {
            // Arrange
            Vector2 vectorA = new Vector2(2.0f, 3.0f);
            Vector2 vectorB = new Vector2(4.0f, 1.0f);

            // Act
            float dotProduct = Vector2.Dot(vectorA, vectorB);

            // Assert
            Assert.Equal(11.0f, dotProduct); // (2 * 4) + (3 * 1) = 11
        }

        /// <summary>
        ///     Tests that test lerp method
        /// </summary>
        [Fact]
        public void TestLerpMethod()
        {
            // Arrange
            Vector2 start = new Vector2(1.0f, 2.0f);
            Vector2 end = new Vector2(5.0f, 6.0f);
            float t = 0.75f;

            // Act
            Vector2 result = Vector2.Lerp(start, end, t);

            // Assert
            Assert.Equal(new Vector2(4.0f, 5.0f), result); // Lerp(1, 5, 0.75) = 4, Lerp(2, 6, 0.75) = 5
        }

        /// <summary>
        ///     Tests that test transform normal method
        /// </summary>
        [Fact]
        public void TestTransformNormalMethod()
        {
            // Arrange
            Vector2 normal = new Vector2(2.0f, 3.0f);
            Matrix4X4 matrix = new Matrix4X4(
                1.0f, 2.0f, 0.0f, 0.0f,
                3.0f, 4.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 1.0f
            );

            // Act
            Vector2 transformed = Vector2.TransformNormal(normal, matrix);

            // Assert
            Assert.Equal(11.0f, transformed.X); // (2 * 1) + (3 * 3) = 11
            Assert.Equal(16.0f, transformed.Y); // (2 * 2) + (3 * 4) = 18
        }

        /// <summary>
        ///     Tests that test square root method
        /// </summary>
        [Fact]
        public void TestSquareRootMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(9.0f, 16.0f);

            // Act
            Vector2 result = Vector2.SquareRoot(vector);

            // Assert
            Assert.Equal(3.0f, result.X); // Sqrt(9) = 3
            Assert.Equal(4.0f, result.Y); // Sqrt(16) = 4
        }

        /// <summary>
        ///     Tests that test divide method
        /// </summary>
        [Fact]
        public void TestDivideMethod()
        {
            // Arrange
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector2 = new Vector2(2.0f, 4.0f);

            // Act
            Vector2 result = Vector2.Divide(vector1, vector2);

            // Assert
            Assert.Equal(5.0f, result.X); // 10 / 2 = 5
            Assert.Equal(5.0f, result.Y); // 20 / 4 = 5
        }

        /// <summary>
        ///     Tests that test equals method
        /// </summary>
        [Fact]
        public void TestEqualsWithObjectMethod()
        {
            // Arrange
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector2 = new Vector2(10.0f, 20.0f);
            Vector2 vector3 = new Vector2(5.0f, 10.0f);

            // Act & Assert
            Assert.True(vector1.Equals(vector2));
            Assert.False(vector1.Equals(vector3));
        }

        /// <summary>
        ///     Tests that test get hash code method
        /// </summary>
        [Fact]
        public void TestGetHashCodeMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(10.0f, 20.0f);

            // Act
            int hashCode = vector.GetHashCode();

            // Assert
            // You can add specific assertions based on your implementation
            Assert.NotEqual(0, hashCode);
        }

        /// <summary>
        ///     Tests that test length method
        /// </summary>
        [Fact]
        public void TestLengthMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(3.0f, 4.0f); // A 3-4-5 right triangle

            // Act
            float length = vector.Length();

            // Assert
            Assert.Equal(5.0f, length);
        }

        /// <summary>
        ///     Tests that test min method
        /// </summary>
        [Fact]
        public void TestMinMethod()
        {
            // Arrange
            Vector2 vector1 = new Vector2(5.0f, 10.0f);
            Vector2 vector2 = new Vector2(8.0f, 7.0f);

            // Act
            Vector2 result = Vector2.Min(vector1, vector2);

            // Assert
            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
        }

        /// <summary>
        ///     Tests that test multiply method
        /// </summary>
        [Fact]
        public void TestMultiplyMethod()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(4.0f, 5.0f);

            // Act
            Vector2 result = Vector2.Multiply(vector1, vector2);

            // Assert
            Assert.Equal(8.0f, result.X); // 2 * 4 = 8
            Assert.Equal(15.0f, result.Y); // 3 * 5 = 15
        }

        /// <summary>
        ///     Tests that test clamp method
        /// </summary>
        [Fact]
        public void TestClampMethod()
        {
            // Arrange
            Vector2 vectorToClamp = new Vector2(3.0f, 5.0f);
            Vector2 min = new Vector2(1.0f, 2.0f);
            Vector2 max = new Vector2(4.0f, 6.0f);

            // Act
            Vector2 result = Vector2.Clamp(vectorToClamp, min, max);

            // Assert
            Assert.Equal(3.0f, result.X); // Within the range
            Assert.Equal(5.0f, result.Y); // Within the range

            // Arrange for testing the case where the vector is outside the range
            vectorToClamp = new Vector2(0.5f, 7.0f);

            // Act
            result = Vector2.Clamp(vectorToClamp, min, max);

            // Assert
            Assert.Equal(1.0f, result.X); // Clamped to the minimum
            Assert.Equal(6.0f, result.Y); // Clamped to the maximum
        }

        /// <summary>
        ///     Tests that test distance method
        /// </summary>
        [Fact]
        public void TestDistanceMethod()
        {
            // Arrange
            Vector2 point1 = new Vector2(1.0f, 2.0f);
            Vector2 point2 = new Vector2(4.0f, 6.0f);

            // Act
            float distance = Vector2.Distance(point1, point2);

            // Assert
            Assert.Equal(5.0f, distance); // Distance between (1,2) and (4,6) is 5
        }

        /// <summary>
        ///     Tests that test multiply method
        /// </summary>
        [Fact]
        public void TestMultiplyWithScalarMethod()
        {
            // Arrange
            float scalar = 2.0f;
            Vector2 vector = new Vector2(3.0f, 4.0f);

            // Act
            Vector2 result = Vector2.Multiply(scalar, vector);

            // Assert
            Assert.Equal(6.0f, result.X); // 2 * 3 = 6
            Assert.Equal(8.0f, result.Y); // 2 * 4 = 8
        }

        /// <summary>
        ///     Tests that test negate method
        /// </summary>
        [Fact]
        public void TestNegateMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(3.0f, -4.0f);

            // Act
            Vector2 result = Vector2.Negate(vector);

            // Assert
            Assert.Equal(-3.0f, result.X); // Negate the X component
            Assert.Equal(4.0f, result.Y); // Negate the Y component
        }

        /// <summary>
        ///     Tests that test abs method
        /// </summary>
        [Fact]
        public void TestAbsMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(-2.5f, 3.8f);

            // Act
            Vector2 result = Vector2.Abs(vector);

            // Assert
            Assert.Equal(2.5f, result.X); // Abs value of -2.5 is 2.5
            Assert.Equal(3.8f, result.Y); // Abs value of 3.8 is 3.8
        }

        /// <summary>
        ///     Tests that test reflect method
        /// </summary>
        [Fact]
        public void TestReflectMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);
            Vector2 normal = new Vector2(1.0f, 0.0f); // Assuming a surface with a normal along the x-axis

            // Act
            Vector2 result = Vector2.Reflect(vector, normal);

            // Assert
            Assert.Equal(-2.0f, result.X); // Reflection of (2, 3) across x-axis should be (-2, 3)
            Assert.Equal(3.0f, result.Y);
        }

        /// <summary>
        ///     Tests that test transform method
        /// </summary>
        [Fact]
        public void TestTransformMethod()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);
            Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f); // No rotation, identity quaternion

            // Act
            Vector2 result = Vector2.Transform(vector, rotation);

            // Assert
            Assert.Equal(2.0f, result.X); // No rotation, X component remains unchanged
            Assert.Equal(3.0f, result.Y); // No rotation, Y component remains unchanged
        }

        /// <summary>
        ///     Tests that test transform normal method with matrix 3 x 2
        /// </summary>
        [Fact]
        public void TestTransformNormalMethodWithMatrix3X2()
        {
            // Arrange
            Vector2 normal = new Vector2(2.0f, 3.0f);
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f); // Ejemplo de matriz 3x2

            // Act
            Vector2 result = Vector2.TransformNormal(normal, matrix);

            // Assert
            Assert.Equal(11.0f, result.X); // Realiza la multiplicación según la lógica de la transformación
            Assert.Equal(16.0f, result.Y);
        }

        /// <summary>
        ///     Tests that test transform normal method with matrix 4 x 4
        /// </summary>
        [Fact]
        public void TestTransformNormalMethodWithMatrix4X4()
        {
            // Arrange
            Vector2 normal = new Vector2(2.0f, 3.0f);
            Matrix4X4 matrix = new Matrix4X4(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f, 11.0f, 12.0f, 13.0f, 14.0f, 15.0f, 16.0f); // Ejemplo de matriz 4x4

            // Act
            Vector2 result = Vector2.TransformNormal(normal, matrix);

            // Assert
            Assert.Equal(17.0f, result.X); // Realiza la multiplicación según la lógica de la transformación
            Assert.Equal(22.0f, result.Y);
        }

        /// <summary>
        ///     Tests that test zero property
        /// </summary>
        [Fact]
        public void TestZeroProperty()
        {
            // Act
            Vector2 zero = Vector2.Zero;

            // Assert
            Assert.Equal(0.0f, zero.X);
            Assert.Equal(0.0f, zero.Y);
        }

        /// <summary>
        ///     Tests that test one property
        /// </summary>
        [Fact]
        public void TestOneProperty()
        {
            // Act
            Vector2 one = Vector2.One;

            // Assert
            Assert.Equal(1.0f, one.X);
            Assert.Equal(1.0f, one.Y);
        }

        /// <summary>
        ///     Tests that test unit x property
        /// </summary>
        [Fact]
        public void TestUnitXProperty()
        {
            // Act
            Vector2 unitX = Vector2.UnitX;

            // Assert
            Assert.Equal(1.0f, unitX.X);
            Assert.Equal(0.0f, unitX.Y);
        }

        /// <summary>
        ///     Tests that test unit y property
        /// </summary>
        [Fact]
        public void TestUnitYProperty()
        {
            // Act
            Vector2 unitY = Vector2.UnitY;

            // Assert
            Assert.Equal(0.0f, unitY.X);
            Assert.Equal(1.0f, unitY.Y);
        }

        /// <summary>
        ///     Tests that test copy to valid array and index copies elements
        /// </summary>
        [Fact]
        public void TestCopyTo_ValidArrayAndIndex_CopiesElements()
        {
            // Arrange
            Vector2 vector = new Vector2(3.0f, 4.0f);
            float[] array = new float[5];
            int index = 2;

            // Act
            vector.CopyTo(array, index);

            // Assert
            Assert.Equal(0.0f, array[0]);
            Assert.Equal(0.0f, array[1]);
            Assert.Equal(3.0f, array[2]); // Copied X
            Assert.Equal(4.0f, array[3]); // Copied Y
            Assert.Equal(0.0f, array[4]);
        }

        /// <summary>
        ///     Tests that test copy to invalid array throws exception
        /// </summary>
        [Fact]
        public void TestCopyTo_InvalidArray_ThrowsException()
        {
            // Arrange
            Vector2 vector = new Vector2(1.0f, 2.0f);
            int index = 0;

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => vector.CopyTo(null, index));
        }

        /// <summary>
        ///     Tests that test copy to index out of range throws exception
        /// </summary>
        [Fact]
        public void TestCopyTo_IndexOutOfRange_ThrowsException()
        {
            // Arrange
            Vector2 vector = new Vector2(1.0f, 2.0f);
            float[] array = new float[2];
            int index = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => vector.CopyTo(array, index));
        }

        /// <summary>
        ///     Tests that test copy to not enough space in array throws exception
        /// </summary>
        [Fact]
        public void TestCopyTo_NotEnoughSpaceInArray_ThrowsException()
        {
            // Arrange
            Vector2 vector = new Vector2(1.0f, 2.0f);
            float[] array = new float[1];
            int index = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => vector.CopyTo(array, index));
        }

        /// <summary>
        ///     Tests that test transform matrix 3 x 2 transforms vector
        /// </summary>
        [Fact]
        public void TestTransform_Matrix3X2_TransformsVector()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);

            // Act
            Vector2 transformed = Vector2.Transform(vector, matrix);

            // Assert
            Assert.Equal(16.0f, transformed.X);
            Assert.Equal(22.0f, transformed.Y);
        }

        /// <summary>
        ///     Tests that test transform matrix 4 x 4 transforms vector
        /// </summary>
        [Fact]
        public void TestTransform_Matrix4X4_TransformsVector()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);
            Matrix4X4 matrix = new Matrix4X4(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f, 11.0f, 12.0f, 13.0f, 14.0f, 15.0f, 16.0f);

            // Act
            Vector2 transformed = Vector2.Transform(vector, matrix);

            // Assert
            Assert.Equal(30.0f, transformed.X);
            Assert.Equal(36.0f, transformed.Y);
        }

        /// <summary>
        ///     Tests that test equals same instance returns true
        /// </summary>
        [Fact]
        public void TestEquals_SameInstance_ReturnsTrue()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);

            // Act
            bool result = vector.Equals(vector);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test equals equal vectors returns true
        /// </summary>
        [Fact]
        public void TestEquals_EqualVectors_ReturnsTrue()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(2.0f, 3.0f);

            // Act
            bool result = vector1.Equals(vector2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test equals null object returns false
        /// </summary>
        [Fact]
        public void TestEquals_NullObject_ReturnsFalse()
        {
            // Arrange
            Vector2 vector = new Vector2(2.0f, 3.0f);

            // Act
            bool result = vector.Equals(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test equals different vectors returns false
        /// </summary>
        [Fact]
        public void TestEquals_DifferentVectors_ReturnsFalse()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(4.0f, 5.0f);

            // Act
            bool result = vector1.Equals(vector2);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test inequality equal vectors returns false
        /// </summary>
        [Fact]
        public void TestInequality_EqualVectors_ReturnsFalse()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(2.0f, 3.0f);

            // Act
            bool result = vector1 != vector2;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test inequality different vectors returns true
        /// </summary>
        [Fact]
        public void TestInequality_DifferentVectors_ReturnsTrue()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(4.0f, 5.0f);

            // Act
            bool result = vector1 != vector2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test inequality different precision vectors returns true
        /// </summary>
        [Fact]
        public void TestInequality_DifferentPrecisionVectors_ReturnsTrue()
        {
            // Arrange
            Vector2 vector1 = new Vector2(2.0f, 3.0f);
            Vector2 vector2 = new Vector2(2.000001f, 3.000001f);

            // Act
            bool result = vector1 != vector2;

            // Assert
            Assert.True(result);
        }
    }
}