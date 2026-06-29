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
    ///     The matrix test class
    /// </summary>
    public class Matrix3X3Test
    {
        /// <summary>
        ///     Tests that matrix 3 x 3 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix3X3_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));

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
        ///     Tests that matrix 3 x 3 solve 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
            Vector3F result = matrix.Solve33(new Vector3F(1.0f, 2.0f, 3.0f));

            Assert.Equal(0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 22 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve22_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
            Vector2F result = matrix.Solve22(new Vector2F(1.0f, 2.0f));

            Assert.Equal(1.0f, result.X);
            Assert.Equal(0.0f, result.Y);
        }


        /// <summary>
        ///     Tests that matrix 3 x 3 get sym inverse 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_GetSymInverse33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
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
        ///     Tests that matrix 3 x 3 v 2 constructor should set values correctly
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
        ///     Tests that matrix 3 x 3 v 2 get sym inverse 33 should return correct result
        /// </summary>
        [Fact]
        public void Matrix3X3_v2_GetSymInverse33_ShouldReturnCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
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
        ///     Tests that matrix 3 x 3 get sym inverse 33 should handle zero determinant
        /// </summary>
        [Fact]
        public void Matrix3X3_GetSymInverse33_ShouldHandleZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
            Matrix3X3 result = new Matrix3X3();
            matrix.Ex = new Vector3F(1, 2, 3);
            matrix.Ey = new Vector3F(4, 5, 6);
            matrix.Ez = new Vector3F(7, 8, 9);
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
        ///     Tests that matrix 3 x 3 solve 33 should return correct result when determinant is not zero
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WhenDeterminantIsNotZero()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f));
            Vector3F b = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = matrix.Solve33(b);

            Assert.Equal(0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return zero vector when determinant is zero
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnZeroVector_WhenDeterminantIsZero()
        {
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1.0f, 2.0f, 3.0f), new Vector3F(4.0f, 5.0f, 6.0f), new Vector3F(7.0f, 8.0f, 9.0f))
            {
                Ex = new Vector3F(1, 2, 3),
                Ey = new Vector3F(4, 5, 6),
                Ez = new Vector3F(7, 8, 9)
            };
            Vector3F b = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F result = matrix.Solve33(b);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(0.0f, result.Z);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return correct result with negative one
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithNegativeOne()
        {
            Vector3F b = new Vector3F(-1.0f, -1.0f, -1.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.Equal(0f, result.X);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return na n with infinity
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnNaN_WithInfinity()
        {
            Vector3F b = new Vector3F(float.PositiveInfinity, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.True(float.IsNaN(result.X));
            Assert.True(float.IsNaN(result.Y));
            Assert.True(float.IsNaN(result.Z));
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return na n with na n
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnNaN_WithNaN()
        {
            Vector3F b = new Vector3F(float.NaN, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.True(float.IsNaN(result.X));
            Assert.True(float.IsNaN(result.Y));
            Assert.True(float.IsNaN(result.Z));
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return correct result with max value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithMaxValue()
        {
            Vector3F b = new Vector3F(float.MaxValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return correct result with negative max value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithNegativeMaxValue()
        {
            Vector3F b = new Vector3F(-float.MaxValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        ///     Tests that matrix 3 x 3 solve 33 should return correct result with min value
        /// </summary>
        [Fact]
        public void Matrix3X3_Solve33_ShouldReturnCorrectResult_WithMinValue()
        {
            Vector3F b = new Vector3F(float.MinValue, 0.0f, 0.0f);
            Matrix3X3 matrix = new Matrix3X3(new Vector3F(1, 2, 3), new Vector3F(4, 5, 6), new Vector3F(7, 8, 9));

            Vector3F result = matrix.Solve33(b);

            Assert.Equal(float.NaN, result.X);
        }

        /// <summary>
        ///     Tests that test solve 33
        /// </summary>
        [Fact]
        public void TestSolve33()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 2, 3),
                new Vector3F(4, 5, 6),
                new Vector3F(7, 8, 9)
            );

            Vector3F b = new Vector3F(1, 2, 3);
            Vector3F result = matrix.Solve33(b);

            Assert.Equal(0, result.X);
            Assert.Equal(0, result.Y);
            Assert.Equal(0, result.Z);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33
        /// </summary>
        [Fact]
        public void TestGetSymInverse33()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 2, 3),
                new Vector3F(4, 5, 6),
                new Vector3F(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 with zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 0, 0),
                new Vector3F(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 with non zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 2, 3),
                new Vector3F(4, 5, 6),
                new Vector3F(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);


            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 with negative values
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(-1, -2, -3),
                new Vector3F(-4, -5, -6),
                new Vector3F(-7, -8, -9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);


            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test solve 33 with zero determinant
        /// </summary>
        [Fact]
        public void TestSolve33_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 0, 0),
                new Vector3F(0, 0, 1)
            );

            Vector3F b = new Vector3F(1, 2, 3);
            Vector3F result = matrix.Solve33(b);

            Assert.Equal(new Vector3F(0, 0, 0), result);
        }

        /// <summary>
        ///     Tests that test solve 33 with negative values
        /// </summary>
        [Fact]
        public void TestSolve33_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(-1, -2, -3),
                new Vector3F(-4, -5, -6),
                new Vector3F(-7, -8, -9)
            );

            Vector3F b = new Vector3F(1, 2, 3);
            Vector3F result = matrix.Solve33(b);


            Assert.Equal(new Vector3F(0, 0, 0), result);
        }

        /// <summary>
        ///     Tests that test solve 33 with non zero determinant
        /// </summary>
        [Fact]
        public void TestSolve33_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 2, 3),
                new Vector3F(4, 5, 6),
                new Vector3F(7, 8, 9)
            );

            Vector3F b = new Vector3F(1, 2, 3);
            Vector3F result = matrix.Solve33(b);


            Assert.Equal(new Vector3F(0, 0, 0), result);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 v 3 with zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 0, 0),
                new Vector3F(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 v 3 with non zero determinant
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithNonZeroDeterminant()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 2, 3),
                new Vector3F(4, 5, 6),
                new Vector3F(7, 8, 9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that test get sym inverse 33 v 3 with negative values
        /// </summary>
        [Fact]
        public void TestGetSymInverse33_V3_WithNegativeValues()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(-1, -2, -3),
                new Vector3F(-4, -5, -6),
                new Vector3F(-7, -8, -9)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that get inverse 22 with non zero determinant computes correctly
        /// </summary>
        [Fact]
        public void GetInverse22_WithNonZeroDeterminant_ComputesCorrectly()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 1, 0),
                new Vector3F(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetInverse22(ref result);

            Assert.Equal(new Vector3F(1, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 1, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 0), result.Ez);
        }

        /// <summary>
        ///     Tests that get inverse 22 with zero determinant does not divide
        /// </summary>
        [Fact]
        public void GetInverse22_WithZeroDeterminant_DoesNotDivide()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(0, 0, 0),
                new Vector3F(0, 0, 0),
                new Vector3F(0, 0, 0)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetInverse22(ref result);

            Assert.Equal(new Vector3F(0, 0, 0), result.Ex);
        }

        /// <summary>
        ///     Tests that solve 33 with non zero determinant returns correct result
        /// </summary>
        [Fact]
        public void Solve33_WithNonZeroDeterminant_ReturnsCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 1, 0),
                new Vector3F(0, 0, 1)
            );

            Vector3F result = matrix.Solve33(new Vector3F(1, 2, 3));

            Assert.Equal(1f, result.X);
            Assert.Equal(2f, result.Y);
            Assert.Equal(3f, result.Z);
        }

        /// <summary>
        ///     Tests that get sym inverse 33 with non zero determinant computes correctly
        /// </summary>
        [Fact]
        public void GetSymInverse33_WithNonZeroDeterminant_ComputesCorrectly()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(1, 0, 0),
                new Vector3F(0, 1, 0),
                new Vector3F(0, 0, 1)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetSymInverse33(ref result);

            Assert.Equal(new Vector3F(1, 0, 0), result.Ex);
            Assert.Equal(new Vector3F(0, 1, 0), result.Ey);
            Assert.Equal(new Vector3F(0, 0, 1), result.Ez);
        }

        /// <summary>
        ///     Tests that Solve33 with diagonal matrix returns correct result
        /// </summary>
        [Fact]
        public void Solve33_WithDiagonalMatrix_ReturnsCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(2f, 0f, 0f),
                new Vector3F(0f, 3f, 0f),
                new Vector3F(0f, 0f, 4f)
            );

            Vector3F x = matrix.Solve33(new Vector3F(6f, 12f, 20f));

            Assert.Equal(3f, x.X, 4);
            Assert.Equal(4f, x.Y, 4);
            Assert.Equal(5f, x.Z, 4);
        }

        /// <summary>
        ///     Tests that Solve33 with general non-singular matrix satisfies A * x = b
        /// </summary>
        [Fact]
        public void Solve33_WithGeneralMatrix_SatisfiesOriginalSystem()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(2f, 0f, 1f),
                new Vector3F(1f, 3f, 0f),
                new Vector3F(0f, 1f, 4f)
            );
            Vector3F b = new Vector3F(9f, 13f, 23f);
            Vector3F x = matrix.Solve33(b);

            float rx = matrix.Ex.X * x.X + matrix.Ey.X * x.Y + matrix.Ez.X * x.Z;
            float ry = matrix.Ex.Y * x.X + matrix.Ey.Y * x.Y + matrix.Ez.Y * x.Z;
            float rz = matrix.Ex.Z * x.X + matrix.Ey.Z * x.Y + matrix.Ez.Z * x.Z;

            Assert.Equal(b.X, rx, 4);
            Assert.Equal(b.Y, ry, 4);
            Assert.Equal(b.Z, rz, 4);
        }

        /// <summary>
        ///     Tests that Solve22 with diagonal 2x2 sub-matrix returns correct result
        /// </summary>
        [Fact]
        public void Solve22_WithDiagonalSubMatrix_ReturnsCorrectResult()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(2f, 0f, 0f),
                new Vector3F(0f, 3f, 0f),
                new Vector3F(0f, 0f, 1f)
            );

            Vector2F x = matrix.Solve22(new Vector2F(6f, 12f));

            Assert.Equal(3f, x.X, 4);
            Assert.Equal(4f, x.Y, 4);
        }

        /// <summary>
        ///     Tests that GetInverse22 with diagonal matrix returns correct inverse
        /// </summary>
        [Fact]
        public void GetInverse22_WithDiagonalMatrix_ReturnsCorrectInverse()
        {
            Matrix3X3 matrix = new Matrix3X3(
                new Vector3F(2f, 0f, 0f),
                new Vector3F(0f, 3f, 0f),
                new Vector3F(0f, 0f, 1f)
            );

            Matrix3X3 result = new Matrix3X3();
            matrix.GetInverse22(ref result);

            Assert.Equal(0.5f, result.Ex.X, 4);
            Assert.Equal(0f, result.Ex.Y, 4);
            Assert.Equal(0f, result.Ey.X, 4);
            Assert.Equal(1f / 3f, result.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that GetInverse22 with non-symmetric matrix satisfies A * inv(A) = I
        /// </summary>
        [Fact]
        public void GetInverse22_WithNonSymmetricMatrix_SatisfiesInverseProperty()
        {
            Matrix3X3 a = new Matrix3X3(
                new Vector3F(2f, 1f, 0f),
                new Vector3F(3f, 4f, 0f),
                new Vector3F(0f, 0f, 1f)
            );

            Matrix3X3 inv = new Matrix3X3();
            a.GetInverse22(ref inv);

            float p00 = a.Ex.X * inv.Ex.X + a.Ey.X * inv.Ex.Y;
            float p01 = a.Ex.X * inv.Ey.X + a.Ey.X * inv.Ey.Y;
            float p10 = a.Ex.Y * inv.Ex.X + a.Ey.Y * inv.Ex.Y;
            float p11 = a.Ex.Y * inv.Ey.X + a.Ey.Y * inv.Ey.Y;

            Assert.Equal(1f, p00, 4);
            Assert.Equal(0f, p01, 4);
            Assert.Equal(0f, p10, 4);
            Assert.Equal(1f, p11, 4);
        }

        /// <summary>
        ///     Tests that GetSymInverse33 with non-identity matrix satisfies A * inv(A) = I
        /// </summary>
        [Fact]
        public void GetSymInverse33_WithGeneralMatrix_SatisfiesInverseProperty()
        {
            Matrix3X3 a = new Matrix3X3(
                new Vector3F(2f, 0f, 1f),
                new Vector3F(0f, 3f, 0f),
                new Vector3F(1f, 0f, 4f)
            );

            Matrix3X3 inv = new Matrix3X3();
            a.GetSymInverse33(ref inv);

            float r00 = a.Ex.X * inv.Ex.X + a.Ey.X * inv.Ex.Y + a.Ez.X * inv.Ex.Z;
            float r01 = a.Ex.X * inv.Ey.X + a.Ey.X * inv.Ey.Y + a.Ez.X * inv.Ey.Z;
            float r02 = a.Ex.X * inv.Ez.X + a.Ey.X * inv.Ez.Y + a.Ez.X * inv.Ez.Z;
            float r10 = a.Ex.Y * inv.Ex.X + a.Ey.Y * inv.Ex.Y + a.Ez.Y * inv.Ex.Z;
            float r11 = a.Ex.Y * inv.Ey.X + a.Ey.Y * inv.Ey.Y + a.Ez.Y * inv.Ey.Z;
            float r12 = a.Ex.Y * inv.Ez.X + a.Ey.Y * inv.Ez.Y + a.Ez.Y * inv.Ez.Z;
            float r20 = a.Ex.Z * inv.Ex.X + a.Ey.Z * inv.Ex.Y + a.Ez.Z * inv.Ex.Z;
            float r21 = a.Ex.Z * inv.Ey.X + a.Ey.Z * inv.Ey.Y + a.Ez.Z * inv.Ey.Z;
            float r22 = a.Ex.Z * inv.Ez.X + a.Ey.Z * inv.Ez.Y + a.Ez.Z * inv.Ez.Z;

            Assert.Equal(1f, r00, 4);
            Assert.Equal(0f, r01, 4);
            Assert.Equal(0f, r02, 4);
            Assert.Equal(0f, r10, 4);
            Assert.Equal(1f, r11, 4);
            Assert.Equal(0f, r12, 4);
            Assert.Equal(0f, r20, 4);
            Assert.Equal(0f, r21, 4);
            Assert.Equal(1f, r22, 4);
        }
    }
}