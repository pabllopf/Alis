// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix2X2Test.cs
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
    public class Matrix2X2Test
    {
        /// <summary>
        ///     Tests that matrix 2 x 2 constructor should set values correctly
        /// </summary>
        [Fact]
        public void Matrix2X2_Constructor_ShouldSetValuesCorrectly()
        {
            Matrix2X2 matrix = new Matrix2X2(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.Equal(1.0f, matrix.Ex.X);
            Assert.Equal(3.0f, matrix.Ex.Y);
            Assert.Equal(2.0f, matrix.Ey.X);
            Assert.Equal(4.0f, matrix.Ey.Y);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 set should set values correctly
        /// </summary>
        [Fact]
        public void Matrix2X2_Set_ShouldSetValuesCorrectly()
        {
            Matrix2X2 matrix = new Matrix2X2();
            matrix.Set(new Vector2F(1.0f, 2.0f), new Vector2F(3.0f, 4.0f));

            Assert.Equal(1.0f, matrix.Ex.X);
            Assert.Equal(2.0f, matrix.Ex.Y);
            Assert.Equal(3.0f, matrix.Ey.X);
            Assert.Equal(4.0f, matrix.Ey.Y);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 set identity should set identity matrix
        /// </summary>
        [Fact]
        public void Matrix2X2_SetIdentity_ShouldSetIdentityMatrix()
        {
            Matrix2X2 matrix = new Matrix2X2();
            matrix.SetIdentity();

            Assert.Equal(1.0f, matrix.Ex.X);
            Assert.Equal(0.0f, matrix.Ex.Y);
            Assert.Equal(0.0f, matrix.Ey.X);
            Assert.Equal(1.0f, matrix.Ey.Y);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 set zero should set zero matrix
        /// </summary>
        [Fact]
        public void Matrix2X2_SetZero_ShouldSetZeroMatrix()
        {
            Matrix2X2 matrix = new Matrix2X2();
            matrix.SetZero();

            Assert.Equal(0.0f, matrix.Ex.X);
            Assert.Equal(0.0f, matrix.Ex.Y);
            Assert.Equal(0.0f, matrix.Ey.X);
            Assert.Equal(0.0f, matrix.Ey.Y);
        }


        /// <summary>
        ///     Tests that matrix 2 x 2 operator add should return correct result
        /// </summary>
        [Fact]
        public void Matrix2X2_OperatorAdd_ShouldReturnCorrectResult()
        {
            Matrix2X2 matrix1 = new Matrix2X2(1.0f, 2.0f, 3.0f, 4.0f);
            Matrix2X2 matrix2 = new Matrix2X2(5.0f, 6.0f, 7.0f, 8.0f);
            Matrix2X2 result = matrix1 + matrix2;

            Assert.Equal(6.0f, result.Ex.X);
            Assert.Equal(10.0f, result.Ex.Y);
            Assert.Equal(8.0f, result.Ey.X);
            Assert.Equal(12.0f, result.Ey.Y);
        }
    }
}