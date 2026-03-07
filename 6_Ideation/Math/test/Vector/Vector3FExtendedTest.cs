// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3FExtendedTest.cs
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

using System;
using System.Globalization;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    /// Extended unit tests for Vector3F class covering all available methods
    /// </summary>
    public class Vector3FExtendedTest
    {
        

        /// <summary>
        /// Tests that constructor with three values initializes components correctly
        /// </summary>
        [Fact]
        public void Constructor_WithThreeValues_InitializesComponentsCorrectly()
        {
            Vector3F v = new Vector3F(1f, 2f, 3f);

            Assert.Equal(1f, v.X);
            Assert.Equal(2f, v.Y);
            Assert.Equal(3f, v.Z);
        }

        /// <summary>
        /// Tests that constructor with two values and vector 2 f initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithTwoValuesAndVector2F_InitializesCorrectly()
        {
            Vector2F v2 = new Vector2F(1f, 2f);
            Vector3F v = new Vector3F(v2, 3f);

            Assert.Equal(1f, v.X);
            Assert.Equal(2f, v.Y);
            Assert.Equal(3f, v.Z);
        }

        /// <summary>
        /// Tests that constructor with single value initializes all components
        /// </summary>
        

        

        [Fact]
        public void StaticProperty_Zero_ReturnsVectorWithZeroComponents()
        {
            Vector3F v = Vector3F.Zero;

            Assert.Equal(0f, v.X);
            Assert.Equal(0f, v.Y);
            Assert.Equal(0f, v.Z);
        }

        /// <summary>
        /// Tests that static property one returns vector with one components
        /// </summary>
        [Fact]
        public void StaticProperty_One_ReturnsVectorWithOneComponents()
        {
            Vector3F v = Vector3F.One;

            Assert.Equal(1f, v.X);
            Assert.Equal(1f, v.Y);
            Assert.Equal(1f, v.Z);
        }

        /// <summary>
        /// Tests that static property unit x returns vector one zero zero
        /// </summary>
        [Fact]
        public void StaticProperty_UnitX_ReturnsVectorOneZeroZero()
        {
            Vector3F v = Vector3F.UnitX;

            Assert.Equal(1f, v.X);
            Assert.Equal(0f, v.Y);
            Assert.Equal(0f, v.Z);
        }

        /// <summary>
        /// Tests that static property unit y returns vector zero one zero
        /// </summary>
        [Fact]
        public void StaticProperty_UnitY_ReturnsVectorZeroOneZero()
        {
            Vector3F v = Vector3F.UnitY;

            Assert.Equal(0f, v.X);
            Assert.Equal(1f, v.Y);
            Assert.Equal(0f, v.Z);
        }

        /// <summary>
        /// Tests that static property unit z returns vector zero zero one
        /// </summary>
        [Fact]
        public void StaticProperty_UnitZ_ReturnsVectorZeroZeroOne()
        {
            Vector3F v = Vector3F.UnitZ;

            Assert.Equal(0f, v.X);
            Assert.Equal(0f, v.Y);
            Assert.Equal(1f, v.Z);
        }

        

        

        /// <summary>
        /// Tests that operator addition adds two vectors
        /// </summary>
        [Fact]
        public void OperatorAddition_AddsTwoVectors()
        {
            Vector3F v1 = new Vector3F(1, 2, 3);
            Vector3F v2 = new Vector3F(4, 5, 6);

            Vector3F result = v1 + v2;

            Assert.Equal(5, result.X);
            Assert.Equal(7, result.Y);
            Assert.Equal(9, result.Z);
        }

        /// <summary>
        /// Tests that operator subtraction subtracts two vectors
        /// </summary>
        [Fact]
        public void OperatorSubtraction_SubtractsTwoVectors()
        {
            Vector3F v1 = new Vector3F(5, 6, 7);
            Vector3F v2 = new Vector3F(1, 2, 3);

            Vector3F result = v1 - v2;

            Assert.Equal(4, result.X);
            Assert.Equal(4, result.Y);
            Assert.Equal(4, result.Z);
        }

        /// <summary>
        /// Tests that operator negation negates vector
        /// </summary>
        [Fact]
        public void OperatorNegation_NegatesVector()
        {
            Vector3F v = new Vector3F(1, 2, 3);

            Vector3F result = -v;

            Assert.Equal(-1, result.X);
            Assert.Equal(-2, result.Y);
            Assert.Equal(-3, result.Z);
        }

        /// <summary>
        /// Tests that operator multiplication multiply vector by scalar
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyVectorByScalar()
        {
            Vector3F v = new Vector3F(2, 3, 4);
            float scalar = 2f;

            Vector3F result = v * scalar;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
            Assert.Equal(8, result.Z);
        }

        /// <summary>
        /// Tests that operator multiplication multiply scalar by vector
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyScalarByVector()
        {
            float scalar = 3f;
            Vector3F v = new Vector3F(1, 2, 3);

            Vector3F result = scalar * v;

            Assert.Equal(3, result.X);
            Assert.Equal(6, result.Y);
            Assert.Equal(9, result.Z);
        }

        /// <summary>
        /// Tests that operator multiplication multiply vector by vector
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyVectorByVector()
        {
            Vector3F v1 = new Vector3F(2, 3, 4);
            Vector3F v2 = new Vector3F(5, 6, 7);

            Vector3F result = v1 * v2;

            Assert.Equal(10, result.X);
            Assert.Equal(18, result.Y);
            Assert.Equal(28, result.Z);
        }

        /// <summary>
        /// Tests that operator division divide vector by scalar
        /// </summary>
        [Fact]
        public void OperatorDivision_DivideVectorByScalar()
        {
            Vector3F v = new Vector3F(6, 9, 12);
            float divisor = 3f;

            Vector3F result = v / divisor;

            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            Assert.Equal(4, result.Z);
        }

        /// <summary>
        /// Tests that operator division divide vector by vector
        /// </summary>
        [Fact]
        public void OperatorDivision_DivideVectorByVector()
        {
            Vector3F v1 = new Vector3F(8, 12, 16);
            Vector3F v2 = new Vector3F(2, 3, 4);

            Vector3F result = v1 / v2;

            Assert.Equal(4, result.X);
            Assert.Equal(4, result.Y);
            Assert.Equal(4, result.Z);
        }

        

        

        /// <summary>
        /// Tests that operator equality with equal vectors returns true
        /// </summary>
        [Fact]
        public void OperatorEquality_WithEqualVectors_ReturnsTrue()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(1f, 2f, 3f);

            Assert.True(v1 == v2);
        }

        /// <summary>
        /// Tests that operator equality with different vectors returns false
        /// </summary>
        [Fact]
        public void OperatorEquality_WithDifferentVectors_ReturnsFalse()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(4f, 5f, 6f);

            Assert.False(v1 == v2);
        }

        /// <summary>
        /// Tests that operator inequality with different vectors returns true
        /// </summary>
        [Fact]
        public void OperatorInequality_WithDifferentVectors_ReturnsTrue()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(4f, 5f, 6f);

            Assert.True(v1 != v2);
        }

        

        

        /// <summary>
        /// Tests that dot calculates dot product
        /// </summary>
        [Fact]
        public void Dot_CalculatesDotProduct()
        {
            Vector3F v1 = new Vector3F(1, 2, 3);
            Vector3F v2 = new Vector3F(4, 5, 6);

            float dot = Vector3F.Dot(v1, v2);

            Assert.Equal(32, dot);
        }

        /// <summary>
        /// Tests that cross calculates cross product
        /// </summary>
        [Fact]
        public void Cross_CalculatesCrossProduct()
        {
            Vector3F v1 = new Vector3F(1, 0, 0);
            Vector3F v2 = new Vector3F(0, 1, 0);

            Vector3F result = Vector3F.Cross(v1, v2);

            Assert.Equal(0, result.X);
            Assert.Equal(0, result.Y);
            Assert.Equal(1, result.Z);
        }

        /// <summary>
        /// Tests that cross with parallel vectors returns zero vector
        /// </summary>
        [Fact]
        public void Cross_WithParallelVectors_ReturnsZeroVector()
        {
            Vector3F v1 = new Vector3F(1, 0, 0);
            Vector3F v2 = new Vector3F(2, 0, 0);

            Vector3F result = Vector3F.Cross(v1, v2);

            Assert.Equal(0, result.X);
            Assert.Equal(0, result.Y);
            Assert.Equal(0, result.Z);
        }

        /// <summary>
        /// Tests that normalize normalizes vector
        /// </summary>
        [Fact]
        public void Normalize_NormalizesVector()
        {
            Vector3F v = new Vector3F(2, 3, 6);

            Vector3F result = Vector3F.Normalize(v);

            Assert.Equal(2f / 7f, result.X, 3);
            Assert.Equal(3f / 7f, result.Y, 3);
            Assert.Equal(6f / 7f, result.Z, 3);
        }

        

        

        /// <summary>
        /// Tests that length calculates vector length
        /// </summary>
        [Fact]
        public void Length_CalculatesVectorLength()
        {
            Vector3F v = new Vector3F(2, 3, 6);

            float length = v.Length();

            Assert.Equal(7, length);
        }

        /// <summary>
        /// Tests that length squared calculates squared length
        /// </summary>
        [Fact]
        public void LengthSquared_CalculatesSquaredLength()
        {
            Vector3F v = new Vector3F(2, 3, 6);

            float lengthSquared = v.LengthSquared();

            Assert.Equal(49, lengthSquared);
        }

        /// <summary>

        

        

        /// <summary>
        /// Tests that equals with same vector returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameVector_ReturnsTrue()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(1f, 2f, 3f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        /// Tests that equals with different vector returns false
        /// </summary>
        [Fact]
        public void Equals_WithDifferentVector_ReturnsFalse()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(4f, 5f, 6f);

            Assert.False(v1.Equals(v2));
        }

        /// <summary>
        /// Tests that equals object override with vector returns true
        /// </summary>
        [Fact]
        public void Equals_ObjectOverride_WithVector_ReturnsTrue()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            object v2 = new Vector3F(1f, 2f, 3f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        /// Tests that get hash code with same vector returns same hash
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameVector_ReturnsSameHash()
        {
            Vector3F v1 = new Vector3F(1f, 2f, 3f);
            Vector3F v2 = new Vector3F(1f, 2f, 3f);

            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }

        /// <summary>
        /// Tests that to string override returns formatted string
        /// </summary>
        [Fact]
        public void ToString_Override_ReturnsFormattedString()
        {
            Vector3F v = new Vector3F(1f, 2f, 3f);
            string str = v.ToString();

            Assert.Contains("2", str);
            Assert.Contains("1", str);
            Assert.Contains("3", str);
        }

        /// <summary>
        /// Tests that to string with format returns formatted string
        /// </summary>
        [Fact]
        public void ToString_WithFormat_ReturnsFormattedString()
        {
            Vector3F v = new Vector3F(1.234f, 2.567f, 3.891f);
            string str = v.ToString("F2", CultureInfo.InvariantCulture);

            Assert.Contains("1.23", str);
            Assert.Contains("2.57", str);
            Assert.Contains("3.89", str);
        }

        

        

        /// <summary>
        /// Tests that get object data serializes vector
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesVector()
        {
            Vector3F v = new Vector3F(1f, 2f, 3f);
            var serializationInfo = new System.Runtime.Serialization.SerializationInfo(typeof(Vector3F), new System.Runtime.Serialization.FormatterConverter());

            v.GetObjectData(serializationInfo, default);

            Assert.Equal(1f, serializationInfo.GetSingle("x"));
            Assert.Equal(2f, serializationInfo.GetSingle("y"));
            Assert.Equal(3f, serializationInfo.GetSingle("z"));
        }

        
    }
}

