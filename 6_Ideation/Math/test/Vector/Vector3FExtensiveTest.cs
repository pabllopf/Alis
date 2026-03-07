// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3FExtensiveTest.cs
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
    ///     Extensive unit tests for Vector3F struct.
    ///     Tests all operators, methods, properties, and edge cases.
    /// </summary>
    public class Vector3FExtensiveTest
    {
        /// <summary>
        ///     Tests that zero returns vector with zero components
        /// </summary>
        [Fact]
        public void Zero_ReturnsVectorWithZeroComponents()
        {
            Vector3F zero = Vector3F.Zero;
            Assert.Equal(0.0f, zero.X);
            Assert.Equal(0.0f, zero.Y);
            Assert.Equal(0.0f, zero.Z);
        }

        /// <summary>
        ///     Tests that one returns vector with one components
        /// </summary>
        [Fact]
        public void One_ReturnsVectorWithOneComponents()
        {
            Vector3F one = Vector3F.One;
            Assert.Equal(1.0f, one.X);
            Assert.Equal(1.0f, one.Y);
            Assert.Equal(1.0f, one.Z);
        }

        /// <summary>
        ///     Tests that unit x returns vector with x one
        /// </summary>
        [Fact]
        public void UnitX_ReturnsVectorWithXOne()
        {
            Vector3F unitX = Vector3F.UnitX;
            Assert.Equal(1.0f, unitX.X);
            Assert.Equal(0.0f, unitX.Y);
            Assert.Equal(0.0f, unitX.Z);
        }

        /// <summary>
        ///     Tests that unit y returns vector with y one
        /// </summary>
        [Fact]
        public void UnitY_ReturnsVectorWithYOne()
        {
            Vector3F unitY = Vector3F.UnitY;
            Assert.Equal(0.0f, unitY.X);
            Assert.Equal(1.0f, unitY.Y);
            Assert.Equal(0.0f, unitY.Z);
        }

        /// <summary>
        ///     Tests that unit z returns vector with z one
        /// </summary>
        [Fact]
        public void UnitZ_ReturnsVectorWithZOne()
        {
            Vector3F unitZ = Vector3F.UnitZ;
            Assert.Equal(0.0f, unitZ.X);
            Assert.Equal(0.0f, unitZ.Y);
            Assert.Equal(1.0f, unitZ.Z);
        }


        /// <summary>
        ///     Tests that addition two vectors returns correct sum
        /// </summary>
        [Fact]
        public void Addition_TwoVectors_ReturnsCorrectSum()
        {
            Vector3F left = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F right = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F result = left + right;

            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
            Assert.Equal(9.0f, result.Z);
        }

        /// <summary>
        ///     Tests that addition with zero vector returns original vector
        /// </summary>
        [Fact]
        public void Addition_WithZeroVector_ReturnsOriginalVector()
        {
            Vector3F vector = new Vector3F(5.0f, 6.0f, 7.0f);
            Vector3F result = vector + Vector3F.Zero;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
            Assert.Equal(vector.Z, result.Z);
        }

        /// <summary>
        ///     Tests that addition negative vectors returns correct sum
        /// </summary>
        [Fact]
        public void Addition_NegativeVectors_ReturnsCorrectSum()
        {
            Vector3F left = new Vector3F(-1.0f, -2.0f, -3.0f);
            Vector3F right = new Vector3F(-4.0f, -5.0f, -6.0f);
            Vector3F result = left + right;

            Assert.Equal(-5.0f, result.X);
            Assert.Equal(-7.0f, result.Y);
            Assert.Equal(-9.0f, result.Z);
        }

        /// <summary>
        ///     Tests that addition is commutative
        /// </summary>
        [Fact]
        public void Addition_IsCommutative()
        {
            Vector3F left = new Vector3F(1.5f, 2.5f, 3.5f);
            Vector3F right = new Vector3F(4.5f, 5.5f, 6.5f);

            Vector3F result1 = left + right;
            Vector3F result2 = right + left;

            Assert.Equal(result1.X, result2.X);
            Assert.Equal(result1.Y, result2.Y);
            Assert.Equal(result1.Z, result2.Z);
        }


        /// <summary>
        ///     Tests that subtraction two vectors returns correct difference
        /// </summary>
        [Fact]
        public void Subtraction_TwoVectors_ReturnsCorrectDifference()
        {
            Vector3F left = new Vector3F(5.0f, 6.0f, 7.0f);
            Vector3F right = new Vector3F(2.0f, 3.0f, 4.0f);
            Vector3F result = left - right;

            Assert.Equal(3.0f, result.X);
            Assert.Equal(3.0f, result.Y);
            Assert.Equal(3.0f, result.Z);
        }

        /// <summary>
        ///     Tests that subtraction vector from itself returns zero
        /// </summary>
        [Fact]
        public void Subtraction_VectorFromItself_ReturnsZero()
        {
            Vector3F vector = new Vector3F(3.5f, 7.2f, 9.1f);
            Vector3F result = vector - vector;

            Assert.Equal(0.0f, result.X, 5);
            Assert.Equal(0.0f, result.Y, 5);
            Assert.Equal(0.0f, result.Z, 5);
        }


        /// <summary>
        ///     Tests that multiplication vector two vectors returns element wise product
        /// </summary>
        [Fact]
        public void MultiplicationVector_TwoVectors_ReturnsElementWiseProduct()
        {
            Vector3F left = new Vector3F(2.0f, 3.0f, 4.0f);
            Vector3F right = new Vector3F(5.0f, 6.0f, 7.0f);
            Vector3F result = left * right;

            Assert.Equal(10.0f, result.X);
            Assert.Equal(18.0f, result.Y);
            Assert.Equal(28.0f, result.Z);
        }

        /// <summary>
        ///     Tests that multiplication scalar vector by scalar returns scaled vector
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByScalar_ReturnsScaledVector()
        {
            Vector3F vector = new Vector3F(2.0f, 3.0f, 4.0f);
            float scalar = 2.0f;
            Vector3F result = vector * scalar;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(6.0f, result.Y);
            Assert.Equal(8.0f, result.Z);
        }

        /// <summary>
        ///     Tests that multiplication scalar vector by zero returns zero vector
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByZero_ReturnsZeroVector()
        {
            Vector3F vector = new Vector3F(5.0f, 7.0f, 9.0f);
            Vector3F result = vector * 0.0f;

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }


        /// <summary>
        ///     Tests that division vector two vectors returns element wise division
        /// </summary>
        [Fact]
        public void DivisionVector_TwoVectors_ReturnsElementWiseDivision()
        {
            Vector3F left = new Vector3F(8.0f, 12.0f, 16.0f);
            Vector3F right = new Vector3F(2.0f, 3.0f, 4.0f);
            Vector3F result = left / right;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(4.0f, result.Z);
        }

        /// <summary>
        ///     Tests that division scalar vector by scalar returns scaled vector
        /// </summary>
        [Fact]
        public void DivisionScalar_VectorByScalar_ReturnsScaledVector()
        {
            Vector3F vector = new Vector3F(8.0f, 6.0f, 4.0f);
            float scalar = 2.0f;
            Vector3F result = vector / scalar;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(3.0f, result.Y);
            Assert.Equal(2.0f, result.Z);
        }


        /// <summary>
        ///     Tests that negation positive vector returns negative vector
        /// </summary>
        [Fact]
        public void Negation_PositiveVector_ReturnsNegativeVector()
        {
            Vector3F vector = new Vector3F(3.0f, 4.0f, 5.0f);
            Vector3F result = -vector;

            Assert.Equal(-3.0f, result.X);
            Assert.Equal(-4.0f, result.Y);
            Assert.Equal(-5.0f, result.Z);
        }

        /// <summary>
        ///     Tests that negation negative vector returns positive vector
        /// </summary>
        [Fact]
        public void Negation_NegativeVector_ReturnsPositiveVector()
        {
            Vector3F vector = new Vector3F(-3.0f, -4.0f, -5.0f);
            Vector3F result = -vector;

            Assert.Equal(3.0f, result.X);
            Assert.Equal(4.0f, result.Y);
            Assert.Equal(5.0f, result.Z);
        }


        /// <summary>
        ///     Tests that equality identical vectors returns true
        /// </summary>
        [Fact]
        public void Equality_IdenticalVectors_ReturnsTrue()
        {
            Vector3F left = new Vector3F(3.0f, 4.0f, 5.0f);
            Vector3F right = new Vector3F(3.0f, 4.0f, 5.0f);

            Assert.True(left == right);
        }

        /// <summary>
        ///     Tests that equality different vectors returns false
        /// </summary>
        [Fact]
        public void Equality_DifferentVectors_ReturnsFalse()
        {
            Vector3F left = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F right = new Vector3F(4.0f, 5.0f, 6.0f);

            Assert.False(left == right);
        }


        /// <summary>
        ///     Tests that inequality different vectors returns true
        /// </summary>
        [Fact]
        public void Inequality_DifferentVectors_ReturnsTrue()
        {
            Vector3F left = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F right = new Vector3F(4.0f, 5.0f, 6.0f);

            Assert.True(left != right);
        }

        /// <summary>
        ///     Tests that inequality identical vectors returns false
        /// </summary>
        [Fact]
        public void Inequality_IdenticalVectors_ReturnsFalse()
        {
            Vector3F left = new Vector3F(3.0f, 4.0f, 5.0f);
            Vector3F right = new Vector3F(3.0f, 4.0f, 5.0f);

            Assert.False(left != right);
        }
    }
}