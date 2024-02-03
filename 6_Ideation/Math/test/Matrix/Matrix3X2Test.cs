// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X2Test.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Matrix
{
    /// <summary>
    /// The matrix test class
    /// </summary>
    public class Matrix3X2Test
    {
        /// <summary>
        /// Tests that matrix 3 x 2 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix3X2_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);

            Assert.Equal(1.0f, matrix.M11);
            Assert.Equal(2.0f, matrix.M12);
            Assert.Equal(3.0f, matrix.M21);
            Assert.Equal(4.0f, matrix.M22);
            Assert.Equal(5.0f, matrix.M31);
            Assert.Equal(6.0f, matrix.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 operator add should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_OperatorAdd_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 + matrix2;

            Assert.Equal(7.0f, result.M11);
            Assert.Equal(7.0f, result.M12);
            Assert.Equal(7.0f, result.M21);
            Assert.Equal(7.0f, result.M22);
            Assert.Equal(7.0f, result.M31);
            Assert.Equal(7.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 operator subtract should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_OperatorSubtract_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 - matrix2;

            Assert.Equal(-5.0f, result.M11);
            Assert.Equal(-3.0f, result.M12);
            Assert.Equal(-1.0f, result.M21);
            Assert.Equal(1.0f, result.M22);
            Assert.Equal(3.0f, result.M31);
            Assert.Equal(5.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 operator multiply should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_OperatorMultiply_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 * matrix2;

            Assert.Equal(14.0f, result.M11);
            Assert.Equal(11.0f, result.M12);
            Assert.Equal(34.0f, result.M21);
            Assert.Equal(27.0f, result.M22);
            Assert.Equal(56.0f, result.M31);
            Assert.Equal(44.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 operator negate should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_OperatorNegate_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 result = -matrix;

            Assert.Equal(-1.0f, result.M11);
            Assert.Equal(-2.0f, result.M12);
            Assert.Equal(-3.0f, result.M21);
            Assert.Equal(-4.0f, result.M22);
            Assert.Equal(-5.0f, result.M31);
            Assert.Equal(-6.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 get determinant should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_GetDeterminant_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            float result = matrix.GetDeterminant();

            Assert.Equal(-2.0f, result);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);

            Assert.Equal(1.0f, matrix.M11);
            Assert.Equal(2.0f, matrix.M12);
            Assert.Equal(3.0f, matrix.M21);
            Assert.Equal(4.0f, matrix.M22);
            Assert.Equal(5.0f, matrix.M31);
            Assert.Equal(6.0f, matrix.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 operator add should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_OperatorAdd_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 + matrix2;

            Assert.Equal(7.0f, result.M11);
            Assert.Equal(7.0f, result.M12);
            Assert.Equal(7.0f, result.M21);
            Assert.Equal(7.0f, result.M22);
            Assert.Equal(7.0f, result.M31);
            Assert.Equal(7.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 operator subtract should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_OperatorSubtract_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 - matrix2;

            Assert.Equal(-5.0f, result.M11);
            Assert.Equal(-3.0f, result.M12);
            Assert.Equal(-1.0f, result.M21);
            Assert.Equal(1.0f, result.M22);
            Assert.Equal(3.0f, result.M31);
            Assert.Equal(5.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 operator multiply should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_OperatorMultiply_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 matrix2 = new Matrix3X2(6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
            Matrix3X2 result = matrix1 * matrix2;

            Assert.Equal(14.0f, result.M11);
            Assert.Equal(11.0f, result.M12);
            Assert.Equal(34.0f, result.M21);
            Assert.Equal(27.0f, result.M22);
            Assert.Equal(56.0f, result.M31);
            Assert.Equal(44.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 operator negate should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_OperatorNegate_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            Matrix3X2 result = -matrix;

            Assert.Equal(-1.0f, result.M11);
            Assert.Equal(-2.0f, result.M12);
            Assert.Equal(-3.0f, result.M21);
            Assert.Equal(-4.0f, result.M22);
            Assert.Equal(-5.0f, result.M31);
            Assert.Equal(-6.0f, result.M32);
        }

        /// <summary>
        /// Tests that matrix 3 x 2 v 2 get determinant should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X2_v2_GetDeterminant_ShouldReturnCorrectResult()
        {
            Matrix3X2 matrix = new Matrix3X2(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f);
            float result = matrix.GetDeterminant();

            Assert.Equal(-2.0f, result);
        }


        /// <summary>
        /// Tests that test matrix creation
        /// </summary>
        [Fact]
        public void TestMatrixCreation()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.Equal(1, matrix.M11);
            Assert.Equal(2, matrix.M12);
            Assert.Equal(3, matrix.M21);
            Assert.Equal(4, matrix.M22);
            Assert.Equal(5, matrix.M31);
            Assert.Equal(6, matrix.M32);
        }

        /// <summary>
        /// Tests that test matrix addition
        /// </summary>
        [Fact]
        public void TestMatrixAddition()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Matrix3X2 result = matrix1 + matrix2;

            Assert.Equal(7, result.M11);
            Assert.Equal(7, result.M12);
            Assert.Equal(7, result.M21);
            Assert.Equal(7, result.M22);
            Assert.Equal(7, result.M31);
            Assert.Equal(7, result.M32);
        }
        
        /// <summary>
        /// Tests that test matrix scale
        /// </summary>
        [Fact]
        public void TestMatrixScale()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 result = matrix * 2;

            Assert.Equal(2, result.M11);
            Assert.Equal(4, result.M12);
            Assert.Equal(6, result.M21);
            Assert.Equal(8, result.M22);
            Assert.Equal(10, result.M31);
            Assert.Equal(12, result.M32);
        }

        /// <summary>
        /// Tests that test matrix subtraction
        /// </summary>
        [Fact]
        public void TestMatrixSubtraction()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Matrix3X2 result = matrix1 - matrix2;

            Assert.Equal(-5, result.M11);
            Assert.Equal(-3, result.M12);
            Assert.Equal(-1, result.M21);
            Assert.Equal(1, result.M22);
            Assert.Equal(3, result.M31);
            Assert.Equal(5, result.M32);
        }

        /// <summary>
        /// Tests that test matrix negation
        /// </summary>
        [Fact]
        public void TestMatrixNegation()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 result = -matrix;

            Assert.Equal(-1, result.M11);
            Assert.Equal(-2, result.M12);
            Assert.Equal(-3, result.M21);
            Assert.Equal(-4, result.M22);
            Assert.Equal(-5, result.M31);
            Assert.Equal(-6, result.M32);
        }

        /// <summary>
        /// Tests that test matrix translation
        /// </summary>
        [Fact]
        public void TestMatrixTranslation()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Vector2 translation = new Vector2(7, 8);
            matrix.Translation = translation;

            Assert.Equal(7, matrix.M31);
            Assert.Equal(8, matrix.M32);
        }

        /// <summary>
        /// Tests that test matrix determinant
        /// </summary>
        [Fact]
        public void TestMatrixDeterminant()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            float determinant = matrix.GetDeterminant();
            Assert.Equal(-2, determinant);
        }
        
        /// <summary>
        /// Tests that test create scale with vector
        /// </summary>
        [Fact]
        public void TestCreateScaleWithVector()
        {
            Vector2 scales = new Vector2(2, 3);
            Matrix3X2 matrix = Matrix3X2.CreateScale(scales);

            Assert.Equal(2, matrix.M11);
            Assert.Equal(3, matrix.M22);
        }

        /// <summary>
        /// Tests that test create scale with xy
        /// </summary>
        [Fact]
        public void TestCreateScaleWithXY()
        {
            Matrix3X2 matrix = Matrix3X2.CreateScale(2, 3);

            Assert.Equal(2, matrix.M11);
            Assert.Equal(3, matrix.M22);
        }

        /// <summary>
        /// Tests that test get determinant
        /// </summary>
        [Fact]
        public void TestGetDeterminant()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            float determinant = matrix.GetDeterminant();

            Assert.Equal(-2, determinant);
        }

        /// <summary>
        /// Tests that test to string
        /// </summary>
        [Fact]
        public void TestToString()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            string matrixString = matrix.ToString();

            Assert.Equal("{ {M11:1 M12:2} {M21:3 M22:4} {M31:5 M32:6} }", matrixString);
        }
        
        /// <summary>
        /// Tests that test matrix subtraction v 2
        /// </summary>
        [Fact]
        public void TestMatrixSubtraction_v2()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Matrix3X2 result = matrix1 - matrix2;

            Assert.Equal(-5, result.M11);
            Assert.Equal(-3, result.M12);
            Assert.Equal(-1, result.M21);
            Assert.Equal(1, result.M22);
            Assert.Equal(3, result.M31);
            Assert.Equal(5, result.M32);
        }

        /// <summary>
        /// Tests that test matrix negation v 2
        /// </summary>
        [Fact]
        public void TestMatrixNegation_v2()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 result = -matrix;

            Assert.Equal(-1, result.M11);
            Assert.Equal(-2, result.M12);
            Assert.Equal(-3, result.M21);
            Assert.Equal(-4, result.M22);
            Assert.Equal(-5, result.M31);
            Assert.Equal(-6, result.M32);
        }

        /// <summary>
        /// Tests that test matrix addition v 2
        /// </summary>
        [Fact]
        public void TestMatrixAddition_v2()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Matrix3X2 result = Matrix3X2.Add(matrix1, matrix2);

            Assert.Equal(7, result.M11);
            Assert.Equal(7, result.M12);
            Assert.Equal(7, result.M21);
            Assert.Equal(7, result.M22);
            Assert.Equal(7, result.M31);
            Assert.Equal(7, result.M32);
        }
        
        /// <summary>
        /// Tests that test get hash code
        /// </summary>
        [Fact]
        public void TestGetHashCode()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.Equal(matrix1.GetHashCode(), matrix2.GetHashCode());
        }

        /// <summary>
        /// Tests that test equals
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.True(matrix1.Equals(matrix2));
        }

        /// <summary>
        /// Tests that test not equals
        /// </summary>
        [Fact]
        public void TestNotEquals()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Assert.False(matrix1.Equals(matrix2));
        }
        
        /// <summary>
        /// Tests that test matrix equality
        /// </summary>
        [Fact]
        public void TestMatrixEquality()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.True(matrix1 == matrix2);
        }

        /// <summary>
        /// Tests that test matrix inequality
        /// </summary>
        [Fact]
        public void TestMatrixInequality()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Assert.True(matrix1 != matrix2);
        }
        
        /// <summary>
        /// Tests that test equals with null object
        /// </summary>
        [Fact]
        public void TestEqualsWithNullObject()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.False(matrix.Equals(null));
        }

        /// <summary>
        /// Tests that test equals with itself
        /// </summary>
        [Fact]
        public void TestEqualsWithItself()
        {
            Matrix3X2 matrix = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.True(matrix.Equals(matrix));
        }

        /// <summary>
        /// Tests that test equals with same values
        /// </summary>
        [Fact]
        public void TestEqualsWithSameValues()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Assert.True(matrix1.Equals(matrix2));
        }

        /// <summary>
        /// Tests that test equals with different values
        /// </summary>
        [Fact]
        public void TestEqualsWithDifferentValues()
        {
            Matrix3X2 matrix1 = new Matrix3X2(1, 2, 3, 4, 5, 6);
            Matrix3X2 matrix2 = new Matrix3X2(6, 5, 4, 3, 2, 1);
            Assert.False(matrix1.Equals(matrix2));
        }
    }
}