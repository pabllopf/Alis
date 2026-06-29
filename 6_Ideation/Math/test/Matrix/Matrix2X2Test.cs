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

        /// <summary>
        ///     Tests that matrix 2 x 2 angle constructor and get angle are consistent
        /// </summary>
        [Fact]
        public void Matrix2X2_AngleConstructor_AndGetAngle_AreConsistent()
        {
            float angle = 0.5f;
            Matrix2X2 matrix = new Matrix2X2(angle);

            Assert.Equal(-angle, matrix.GetAngle(), 3);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 get inverse returns expected values
        /// </summary>
        [Fact]
        public void Matrix2X2_GetInverse_ReturnsExpectedValues()
        {
            Matrix2X2 matrix = new Matrix2X2(2f, 0f, 0f, 4f);

            Matrix2X2 inverse = matrix.GetInverse();

            Assert.Equal(0.5f, inverse.Ex.X, 4);
            Assert.Equal(0f, inverse.Ex.Y, 4);
            Assert.Equal(0f, inverse.Ey.X, 4);
            Assert.Equal(0.25f, inverse.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 inverse property returns expected values
        /// </summary>
        [Fact]
        public void Matrix2X2_InverseProperty_ReturnsExpectedValues()
        {
            Matrix2X2 matrix = new Matrix2X2(2f, 0f, 0f, 4f);

            Matrix2X2 inverse = matrix.Inverse;

            Assert.Equal(0.5f, inverse.Ex.X, 4);
            Assert.Equal(0f, inverse.Ex.Y, 4);
            Assert.Equal(0f, inverse.Ey.X, 4);
            Assert.Equal(0.25f, inverse.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that matrix 2 x 2 solve returns expected vector
        /// </summary>
        [Fact]
        public void Matrix2X2_Solve_ReturnsExpectedVector()
        {
            Matrix2X2 matrix = new Matrix2X2(2f, 0f, 0f, 4f);
            Vector2F b = new Vector2F(4f, 8f);

            Vector2F x = matrix.Solve(b);

            Assert.Equal(2f, x.X, 4);
            Assert.Equal(2f, x.Y, 4);
        }

        /// <summary>
        ///     Tests that inverse property with zero determinant returns default matrix
        /// </summary>
        [Fact]
        public void Inverse_WithZeroDeterminant_ReturnsDefaultMatrix()
        {
            Matrix2X2 matrix = new Matrix2X2(0f, 0f, 0f, 0f);

            Matrix2X2 inverse = matrix.Inverse;

            Assert.Equal(0f, inverse.Ex.X);
            Assert.Equal(0f, inverse.Ex.Y);
        }

        /// <summary>
        ///     Tests that angle = 0 produces identity rotation with GetAngle = 0
        /// </summary>
        [Fact]
        public void AngleConstructor_AngleZero_IsIdentityRotation()
        {
            Matrix2X2 matrix = new Matrix2X2(0f);

            Assert.Equal(1f, matrix.Ex.X);
            Assert.Equal(0f, matrix.Ex.Y);
            Assert.Equal(0f, matrix.Ey.X);
            Assert.Equal(1f, matrix.Ey.Y);
            Assert.Equal(0f, matrix.GetAngle(), 4);
        }

        /// <summary>
        ///     Tests that angle = Pi/2 produces Ex.Y = -1 and Ey.X = 1
        /// </summary>
        [Fact]
        public void AngleConstructor_HalfPi_ExYIsMinusOne()
        {
            Matrix2X2 matrix = new Matrix2X2((float)(System.Math.PI / 2.0));

            Assert.Equal(0f, matrix.Ex.X, 4);
            Assert.Equal(-1f, matrix.Ex.Y, 4);
            Assert.Equal(1f, matrix.Ey.X, 4);
            Assert.Equal(0f, matrix.Ey.Y, 4);
            Assert.Equal((float)(-System.Math.PI / 2.0), matrix.GetAngle(), 4);
        }

        /// <summary>
        ///     Tests that angle = 2 * Pi produces identity rotation
        /// </summary>
        [Fact]
        public void AngleConstructor_TwoPi_IsIdentityRotation()
        {
            Matrix2X2 matrix = new Matrix2X2((float)(System.Math.PI * 2.0));

            Assert.Equal(1f, matrix.Ex.X, 4);
            Assert.Equal(0f, matrix.Ex.Y, 4);
            Assert.Equal(0f, matrix.Ey.X, 4);
            Assert.Equal(1f, matrix.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that GetAngle returns zero after SetIdentity
        /// </summary>
        [Fact]
        public void GetAngle_AfterSetIdentity_ReturnsZero()
        {
            Matrix2X2 matrix = new Matrix2X2(1f, 2f, 3f, 4f);
            matrix.SetIdentity();

            Assert.Equal(0f, matrix.GetAngle(), 4);
        }

        /// <summary>
        ///     Tests that GetInverse of identity matrix returns identity
        /// </summary>
        [Fact]
        public void GetInverse_Identity_ReturnsIdentity()
        {
            Matrix2X2 identity = new Matrix2X2(1f, 0f, 0f, 1f);
            Matrix2X2 result = identity.GetInverse();

            Assert.Equal(1f, result.Ex.X, 4);
            Assert.Equal(0f, result.Ex.Y, 4);
            Assert.Equal(0f, result.Ey.X, 4);
            Assert.Equal(1f, result.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that GetInverse and Inverse produce the same result for a non-singular matrix
        /// </summary>
        [Fact]
        public void GetInverse_AndInverseProperty_ProduceSameResult()
        {
            Matrix2X2 matrix = new Matrix2X2(5f, 3f, 3f, 5f);

            Matrix2X2 fromMethod = matrix.GetInverse();
            Matrix2X2 fromProperty = matrix.Inverse;

            Assert.Equal(fromMethod.Ex.X, fromProperty.Ex.X, 4);
            Assert.Equal(fromMethod.Ex.Y, fromProperty.Ex.Y, 4);
            Assert.Equal(fromMethod.Ey.X, fromProperty.Ey.X, 4);
            Assert.Equal(fromMethod.Ey.Y, fromProperty.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that matrix times its GetInverse is identity
        /// </summary>
        [Fact]
        public void GetInverse_MultipliedByOriginal_ReturnsIdentity()
        {
            Matrix2X2 a = new Matrix2X2(3f, 1f, 1f, 2f);
            Matrix2X2 inv = a.GetInverse();

            Matrix2X2 product = default;
            product.Ex = a.Ex * inv.Ex.X + a.Ey * inv.Ex.Y;
            product.Ey = a.Ex * inv.Ey.X + a.Ey * inv.Ey.Y;

            Assert.Equal(1f, product.Ex.X, 4);
            Assert.Equal(0f, product.Ex.Y, 4);
            Assert.Equal(0f, product.Ey.X, 4);
            Assert.Equal(1f, product.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that matrix times its Inverse property is identity
        /// </summary>
        [Fact]
        public void InverseProperty_MultipliedByOriginal_ReturnsIdentity()
        {
            Matrix2X2 a = new Matrix2X2(3f, 1f, 1f, 2f);
            Matrix2X2 inv = a.Inverse;

            Matrix2X2 product = default;
            product.Ex = a.Ex * inv.Ex.X + a.Ey * inv.Ex.Y;
            product.Ey = a.Ex * inv.Ey.X + a.Ey * inv.Ey.Y;

            Assert.Equal(1f, product.Ex.X, 4);
            Assert.Equal(0f, product.Ex.Y, 4);
            Assert.Equal(0f, product.Ey.X, 4);
            Assert.Equal(1f, product.Ey.Y, 4);
        }

        /// <summary>
        ///     Tests that Solve with identity matrix returns the input vector
        /// </summary>
        [Fact]
        public void Solve_WithIdentityMatrix_ReturnsInputVector()
        {
            Matrix2X2 identity = new Matrix2X2(1f, 0f, 0f, 1f);
            Vector2F b = new Vector2F(5f, 7f);

            Vector2F x = identity.Solve(b);

            Assert.Equal(5f, x.X, 4);
            Assert.Equal(7f, x.Y, 4);
        }

        /// <summary>
        ///     Tests that Solve with a general matrix satisfies A * x = b
        /// </summary>
        [Fact]
        public void Solve_WithGeneralMatrix_SatisfiesOriginalSystem()
        {
            Matrix2X2 a = new Matrix2X2(3f, 1f, 1f, 2f);
            Vector2F b = new Vector2F(7f, 8f);

            Vector2F x = a.Solve(b);

            float resultX = a.Ex.X * x.X + a.Ey.X * x.Y;
            float resultY = a.Ex.Y * x.X + a.Ey.Y * x.Y;

            Assert.Equal(b.X, resultX, 4);
            Assert.Equal(b.Y, resultY, 4);
        }
    }
}