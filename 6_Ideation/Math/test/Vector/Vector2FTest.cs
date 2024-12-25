// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2FTest.cs
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
    public class Vector2FTest
    {
        /// <summary>
        ///     Tests that vector 2 addition
        /// </summary>
        [Fact]
        public void Vector2_Addition()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F result = v1 + v2;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 subtraction
        /// </summary>
        [Fact]
        public void Vector2_Subtraction()
        {
            Vector2F v1 = new Vector2F(3, 4);
            Vector2F v2 = new Vector2F(1, 2);

            Vector2F result = v1 - v2;

            Assert.Equal(2, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 division
        /// </summary>
        [Fact]
        public void Vector2_Division()
        {
            Vector2F v1 = new Vector2F(6, 8);
            float scalar = 2;

            Vector2F result = v1 / scalar;

            Assert.Equal(3, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that vector 2 distance
        /// </summary>
        [Fact]
        public void Vector2_Distance()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(4, 6);

            float distance = Vector2F.Distance(v1, v2);

            Assert.Equal(5, distance);
        }

        /// <summary>
        ///     Tests that vector 2 length
        /// </summary>
        [Fact]
        public void Vector2_Length()
        {
            Vector2F vector = new Vector2F(3, 4);

            float length = vector.Length();

            Assert.Equal(5, length);
        }

        /// <summary>
        ///     Tests that vector 2 normalize
        /// </summary>
        [Fact]
        public void Vector2_Normalize()
        {
            Vector2F vector = new Vector2F(3, 4);

            Vector2F normalized = Vector2F.Normalize(vector);

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
            Vector2F vectorA = new Vector2F(1.0f, 2.0f);
            Vector2F vectorB = new Vector2F(1.0f, 2.0f);
            Vector2F vectorC = new Vector2F(2.0f, 3.0f);

            // Act & Assert
            Assert.True(vectorA.Equals(vectorB)); // Vector A should be equal to Vector B
            Assert.False(vectorA.Equals(vectorC)); // Vector A should not be equal to Vector C
        }


        /// <summary>
        ///     Tests that test static addition method
        /// </summary>
        [Fact]
        public void TestStaticAdditionMethod()
        {
            // Arrange
            Vector2F vectorA = new Vector2F(1.0f, 2.0f);
            Vector2F vectorB = new Vector2F(3.0f, 4.0f);

            // Act
            Vector2F result = Vector2F.Add(vectorA, vectorB);

            // Assert
            Assert.Equal(new Vector2F(4.0f, 6.0f), result);
        }

        /// <summary>
        ///     Tests that test dot product method
        /// </summary>
        [Fact]
        public void TestDotProductMethod()
        {
            // Arrange
            Vector2F vectorA = new Vector2F(2.0f, 3.0f);
            Vector2F vectorB = new Vector2F(4.0f, 1.0f);

            // Act
            float dotProduct = Vector2F.Dot(vectorA, vectorB);

            // Assert
            Assert.Equal(11.0f, dotProduct); // (2 * 4) + (3 * 1) = 11
        }

        /// <summary>
        ///     Tests that test equals method
        /// </summary>
        [Fact]
        public void TestEqualsWithObjectMethod()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(10.0f, 20.0f);
            Vector2F vector2F = new Vector2F(10.0f, 20.0f);
            Vector2F vector3 = new Vector2F(5.0f, 10.0f);

            // Act & Assert
            Assert.True(vector1.Equals(vector2F));
            Assert.False(vector1.Equals(vector3));
        }

        /// <summary>
        ///     Tests that test get hash code method
        /// </summary>
        [Fact]
        public void TestGetHashCodeMethod()
        {
            // Arrange
            Vector2F vector = new Vector2F(10.0f, 20.0f);

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
            Vector2F vector = new Vector2F(3.0f, 4.0f); // A 3-4-5 right triangle

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
            Vector2F vector1 = new Vector2F(5.0f, 10.0f);
            Vector2F vector2F = new Vector2F(8.0f, 7.0f);

            // Act
            Vector2F result = Vector2F.Min(vector1, vector2F);

            // Assert
            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
        }


        /// <summary>
        ///     Tests that test distance method
        /// </summary>
        [Fact]
        public void TestDistanceMethod()
        {
            // Arrange
            Vector2F point1 = new Vector2F(1.0f, 2.0f);
            Vector2F point2 = new Vector2F(4.0f, 6.0f);

            // Act
            float distance = Vector2F.Distance(point1, point2);

            // Assert
            Assert.Equal(5.0f, distance); // Distance between (1,2) and (4,6) is 5
        }

        /// <summary>
        ///     Tests that test equals same instance returns true
        /// </summary>
        [Fact]
        public void TestEquals_SameInstance_ReturnsTrue()
        {
            // Arrange
            Vector2F vector = new Vector2F(2.0f, 3.0f);

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
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector1.Equals(vector2F);

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
            Vector2F vector = new Vector2F(2.0f, 3.0f);

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
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(4.0f, 5.0f);

            // Act
            bool result = vector1.Equals(vector2F);

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
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector1 != vector2F;

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
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(4.0f, 5.0f);

            // Act
            bool result = vector1 != vector2F;

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
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.1f + float.Epsilon, 3.1f + float.Epsilon);

            // Act
            bool result = vector1 != vector2F;

            // Assert
            Assert.True(result);
        }
    }
}