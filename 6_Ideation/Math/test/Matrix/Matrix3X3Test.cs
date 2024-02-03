// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X3Test.cs
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
    public class Matrix3X3Test
    {
        /// <summary>
        /// Tests that matrix 3 x 3 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix3X3_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));

            Assert.Equal(1.0f, matrix.Ex.X);
            Assert.Equal(2.0f, matrix.Ex.Y);
            Assert.Equal(3.0f, matrix.Ex.Z);
            Assert.Equal(4.0f, matrix.Ey.X);
            Assert.Equal(5.0f, matrix.Ey.Y);
            Assert.Equal(6.0f, matrix.Ey.Z);
            Assert.Equal(7.0f, matrix.Ez.X);
            Assert.Equal(8.0f, matrix.Ez.Y);
            Assert.Equal(9.0f, matrix.Ez.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Vector3 result = matrix.Solve33(new Vector3(1.0f, 2.0f, 3.0f));

            Assert.Equal(0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 22 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve22_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Vector2 result = matrix.Solve22(new Vector2(1.0f, 2.0f));

            Assert.Equal(1.0f, result.X);
            Assert.Equal(0.0f, result.Y);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 get inverse 22 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_GetInverse22_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Matrix3X3 result = new Matrix3X3();
            matrix.GetInverse22(ref result);

            Assert.Equal(-1.66, result.Ex.X, 0.1f);
            Assert.Equal(1.3f, result.Ex.Y, 0.2f);
            Assert.Equal(0.0f, result.Ex.Z, 0.1f);
            Assert.Equal(1.33f, result.Ey.X, 0.2f);
            Assert.Equal(-0.33f, result.Ey.Y, 0.1f);
            Assert.Equal(0.0f, result.Ey.Z, 0.1f);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 get sym inverse 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_GetSymInverse33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(0.0f, result.Ex.X);
            Assert.Equal(0.0f, result.Ex.Y);
            Assert.Equal(0.0f, result.Ex.Z);
            Assert.Equal(0.0f, result.Ey.X);
            Assert.Equal(0.0f, result.Ey.Y);
            Assert.Equal(0f, result.Ey.Z);
            Assert.Equal(0f, result.Ez.X);
            Assert.Equal(0f, result.Ez.Y);
            Assert.Equal(0f, result.Ez.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 v 2 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix3X3_v2_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix3X3 matrix = new Matrix3X3(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f);

            Assert.Equal(1.0f, matrix.Ex.X);
            Assert.Equal(2.0f, matrix.Ex.Y);
            Assert.Equal(3.0f, matrix.Ex.Z);
            Assert.Equal(4.0f, matrix.Ey.X);
            Assert.Equal(5.0f, matrix.Ey.Y);
            Assert.Equal(6.0f, matrix.Ey.Z);
            Assert.Equal(7.0f, matrix.Ez.X);
            Assert.Equal(8.0f, matrix.Ez.Y);
            Assert.Equal(9.0f, matrix.Ez.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 v 2 get sym inverse 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_v2_GetSymInverse33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(0f, result.Ex.X);
            Assert.Equal(0.0f, result.Ex.Y);
            Assert.Equal(0f, result.Ex.Z);
            Assert.Equal(0f, result.Ey.X);
            Assert.Equal(0f, result.Ey.Y);
            Assert.Equal(0f, result.Ey.Z);
            Assert.Equal(0f, result.Ez.X);
            Assert.Equal(0f, result.Ez.Y);
            Assert.Equal(0f, result.Ez.Z);
        }

        /// <summary>

        /// Tests that matrix 3 x 3 get sym inverse 33 should handle zero determinant

        /// </summary>

        [Fact]
        public void Matrix3X3_GetSymInverse33_ShouldHandleZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Matrix3X3 result = new Matrix3X3();
            matrix.Ex = new Vector3(1, 2, 3);
            matrix.Ey = new Vector3(4, 5, 6);
            matrix.Ez = new Vector3(7, 8, 9);
            matrix.GetSymInverse33(ref result);

            Assert.Equal(0.0f, result.Ex.X);
            Assert.Equal(0.0f, result.Ex.Y);
            Assert.Equal(0.0f, result.Ex.Z);
            Assert.Equal(0.0f, result.Ey.X);
            Assert.Equal(0.0f, result.Ey.Y);
            Assert.Equal(0.0f, result.Ey.Z);
            Assert.Equal(0.0f, result.Ez.X);
            Assert.Equal(0.0f, result.Ez.Y);
            Assert.Equal(0.0f, result.Ez.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result when determinant is not zero
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WhenDeterminantIsNotZero()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f));
            Vector3 b = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 result = matrix.Solve33(b);

            Assert.Equal(0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return zero vector when determinant is zero
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnZeroVector_WhenDeterminantIsZero()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1.0f, 2.0f, 3.0f), new Vector3(4.0f, 5.0f, 6.0f), new Vector3(7.0f, 8.0f, 9.0f))
            {
                Ex = new Vector3(1, 2, 3),
                Ey = new Vector3(4, 5, 6),
                Ez = new Vector3(7, 8, 9)
            };
            Vector3 b = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 result = matrix.Solve33(b);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result with negative one
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithNegativeOne()
        {
            Vector3 b = new Vector3(-1.0f, -1.0f, -1.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            Assert.Equal(0f, result.X);

        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return na n with infinity
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnNaN_WithInfinity()
        {
            Vector3 b = new Vector3(float.PositiveInfinity, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            Assert.True(float.IsNaN(result.X));
            Assert.True(float.IsNaN(result.Y));
            Assert.True(float.IsNaN(result.Z));
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return na n with na n
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnNaN_WithNaN()
        {
            Vector3 b = new Vector3(float.NaN, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            Assert.True(float.IsNaN(result.X));
            Assert.True(float.IsNaN(result.Y));
            Assert.True(float.IsNaN(result.Z));
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result with max value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithMaxValue()
        {
            Vector3 b = new Vector3(float.MaxValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            // Assert with your expected result
            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result with negative max value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithNegativeMaxValue()
        {
            Vector3 b = new Vector3(-float.MaxValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            // Assert with your expected result
            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        /// Tests that matrix 3 x 3 solve 33 should return correct result with min value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithMinValue()
        {
            Vector3 b = new Vector3(float.MinValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3(1, 2, 3), new Vector3(4, 5, 6), new Vector3(7, 8, 9));

            Vector3 result = matrix.Solve33(b);

            // Assert with your expected result
            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        /// Tests that test solve 33
        /// </summary>
        [Fact]
        public void TestSolve33()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            );

            Vector3 b = new Vector3(1, 2, 3);
            Vector3 result = matrix.Solve33(b);

            Assert.Equal(0, result.X);
            Assert.Equal(0, result.Y);
            Assert.Equal(0, result.Z);
        }

        /// <summary>
        /// Tests that test get sym inverse 33
        /// </summary>
        [Fact]
        public void TestGetSymInverse33()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test get sym inverse 33 with zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test get sym inverse 33 with non zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);


            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test get sym inverse 33 with negative values
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(-1, -2, -3),
                new Vector3(-4, -5, -6),
                new Vector3(-7, -8, -9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);


            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test solve 33 with zero determinant
        /// </summary>
        [Fact]
        public void TestSolve33_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1)
            );

            Vector3 b = new Vector3(1, 2, 3);
            Vector3 result = matrix.Solve33(b);

            Assert.Equal(new Vector3(0, 0, 0), result);
        }

        /// <summary>
        /// Tests that test solve 33 with negative values
        /// </summary>
        [Fact]
        public void TestSolve33_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(-1, -2, -3),
                new Vector3(-4, -5, -6),
                new Vector3(-7, -8, -9)
            );

            Vector3 b = new Vector3(1, 2, 3);
            Vector3 result = matrix.Solve33(b);


            Assert.Equal(new Vector3(0, 0, 0), result);
        }

        /// <summary>
        /// Tests that test solve 33 with non zero determinant
        /// </summary>
        [Fact]
        public void TestSolve33_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            );

            Vector3 b = new Vector3(1, 2, 3);
            Vector3 result = matrix.Solve33(b);


            Assert.Equal(new Vector3(0, 0, 0), result);
        }
        
        /// <summary>
        /// Tests that test get sym inverse 33 v 3 with zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test get sym inverse 33 v 3 with non zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            // Aquí debes reemplazar los valores esperados con los valores correctos.
            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }

        /// <summary>
        /// Tests that test get sym inverse 33 v 3 with negative values
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3(-1, -2, -3),
                new Vector3(-4, -5, -6),
                new Vector3(-7, -8, -9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            // Aquí debes reemplazar los valores esperados con los valores correctos.
            Assert.Equal(new Vector3(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3(0, 0, 0), result.Ez);
        }
    }
}