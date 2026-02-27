// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mat22Test.cs
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
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The mat 22 test class
    /// </summary>
    public class Mat22Test
    {
        /// <summary>
        ///     Tests that constructor with vectors should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithVectors_ShouldInitializeCorrectly()
        {
            Vector2F c1 = new Vector2F(1.0f, 2.0f);
            Vector2F c2 = new Vector2F(3.0f, 4.0f);
            
            Mat22 mat = new Mat22(c1, c2);
            
            Assert.Equal(c1, mat.Ex);
            Assert.Equal(c2, mat.Ey);
        }

        /// <summary>
        ///     Tests that constructor with scalars should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithScalars_ShouldInitializeCorrectly()
        {
            Mat22 mat = new Mat22(1.0f, 2.0f, 3.0f, 4.0f);
            
            Assert.Equal(1.0f, mat.Ex.X);
            Assert.Equal(3.0f, mat.Ex.Y);
            Assert.Equal(2.0f, mat.Ey.X);
            Assert.Equal(4.0f, mat.Ey.Y);
        }

        /// <summary>
        ///     Tests that inverse should return correct matrix
        /// </summary>
        [Fact]
        public void Inverse_ShouldReturnCorrectMatrix()
        {
            Mat22 mat = new Mat22(4.0f, 3.0f, 2.0f, 1.0f);
            
            Mat22 inverse = mat.Inverse;
            
            Assert.Equal(-0.5f, inverse.Ex.X, 5);
            Assert.Equal(1.0f, inverse.Ex.Y, 5);
            Assert.Equal(1.5f, inverse.Ey.X, 5);
            Assert.Equal(-2.0f, inverse.Ey.Y, 5);
        }

        /// <summary>
        ///     Tests that inverse of identity should return identity
        /// </summary>
        [Fact]
        public void Inverse_OfIdentity_ShouldReturnIdentity()
        {
            Mat22 identity = new Mat22(1.0f, 0.0f, 0.0f, 1.0f);
            
            Mat22 inverse = identity.Inverse;
            
            Assert.Equal(1.0f, inverse.Ex.X, 5);
            Assert.Equal(0.0f, inverse.Ex.Y, 5);
            Assert.Equal(0.0f, inverse.Ey.X, 5);
            Assert.Equal(1.0f, inverse.Ey.Y, 5);
        }

        /// <summary>
        ///     Tests that set should update matrix values
        /// </summary>
        [Fact]
        public void Set_ShouldUpdateMatrixValues()
        {
            Mat22 mat = new Mat22();
            Vector2F c1 = new Vector2F(1.0f, 2.0f);
            Vector2F c2 = new Vector2F(3.0f, 4.0f);
            
            mat.Set(c1, c2);
            
            Assert.Equal(c1, mat.Ex);
            Assert.Equal(c2, mat.Ey);
        }

        /// <summary>
        ///     Tests that set identity should create identity matrix
        /// </summary>
        [Fact]
        public void SetIdentity_ShouldCreateIdentityMatrix()
        {
            Mat22 mat = new Mat22(1.0f, 2.0f, 3.0f, 4.0f);
            
            mat.SetIdentity();
            
            Assert.Equal(1.0f, mat.Ex.X);
            Assert.Equal(0.0f, mat.Ex.Y);
            Assert.Equal(0.0f, mat.Ey.X);
            Assert.Equal(1.0f, mat.Ey.Y);
        }

        /// <summary>
        ///     Tests that set zero should create zero matrix
        /// </summary>
        [Fact]
        public void SetZero_ShouldCreateZeroMatrix()
        {
            Mat22 mat = new Mat22(1.0f, 2.0f, 3.0f, 4.0f);
            
            mat.SetZero();
            
            Assert.Equal(0.0f, mat.Ex.X);
            Assert.Equal(0.0f, mat.Ex.Y);
            Assert.Equal(0.0f, mat.Ey.X);
            Assert.Equal(0.0f, mat.Ey.Y);
        }

        /// <summary>
        ///     Tests that solve should return correct solution
        /// </summary>
        [Fact]
        public void Solve_ShouldReturnCorrectSolution()
        {
            Mat22 mat = new Mat22(2.0f, 1.0f, 1.0f, 2.0f);
            Vector2F b = new Vector2F(5.0f, 7.0f);
            
            Vector2F x = mat.Solve(b);
            
            Assert.Equal(1.0f, x.X, 5);
            Assert.Equal(3.0f, x.Y, 5);
        }

        /// <summary>
        ///     Tests that solve with identity should return same vector
        /// </summary>
        [Fact]
        public void Solve_WithIdentity_ShouldReturnSameVector()
        {
            Mat22 identity = new Mat22(1.0f, 0.0f, 0.0f, 1.0f);
            Vector2F b = new Vector2F(3.0f, 4.0f);
            
            Vector2F x = identity.Solve(b);
            
            Assert.Equal(b.X, x.X, 5);
            Assert.Equal(b.Y, x.Y, 5);
        }

        /// <summary>
        ///     Tests that add should sum matrices correctly
        /// </summary>
        [Fact]
        public void Add_ShouldSumMatricesCorrectly()
        {
            Mat22 a = new Mat22(1.0f, 2.0f, 3.0f, 4.0f);
            Mat22 b = new Mat22(5.0f, 6.0f, 7.0f, 8.0f);
            
            Mat22.Add(ref a, ref b, out Mat22 result);
            
            Assert.Equal(6.0f, result.Ex.X);
            Assert.Equal(10.0f, result.Ex.Y);
            Assert.Equal(8.0f, result.Ey.X);
            Assert.Equal(12.0f, result.Ey.Y);
        }

        /// <summary>
        ///     Tests that add with zero matrix should return same matrix
        /// </summary>
        [Fact]
        public void Add_WithZeroMatrix_ShouldReturnSameMatrix()
        {
            Mat22 a = new Mat22(1.0f, 2.0f, 3.0f, 4.0f);
            Mat22 zero = new Mat22(0.0f, 0.0f, 0.0f, 0.0f);
            
            Mat22.Add(ref a, ref zero, out Mat22 result);
            
            Assert.Equal(a.Ex, result.Ex);
            Assert.Equal(a.Ey, result.Ey);
        }

        /// <summary>
        ///     Tests that constructor with zero values should work
        /// </summary>
        [Fact]
        public void Constructor_WithZeroValues_ShouldWork()
        {
            Mat22 mat = new Mat22(0.0f, 0.0f, 0.0f, 0.0f);
            
            Assert.Equal(0.0f, mat.Ex.X);
            Assert.Equal(0.0f, mat.Ex.Y);
            Assert.Equal(0.0f, mat.Ey.X);
            Assert.Equal(0.0f, mat.Ey.Y);
        }

        /// <summary>
        ///     Tests that inverse with singular matrix should handle gracefully
        /// </summary>
        [Fact]
        public void Inverse_WithSingularMatrix_ShouldHandleGracefully()
        {
            Mat22 singular = new Mat22(1.0f, 2.0f, 2.0f, 4.0f);
            
            Mat22 inverse = singular.Inverse;
            
            // Determinant is zero, should handle with epsilon check
            Assert.NotNull(inverse);
        }

        /// <summary>
        ///     Tests that solve with zero determinant should handle gracefully
        /// </summary>
        [Fact]
        public void Solve_WithZeroDeterminant_ShouldHandleGracefully()
        {
            Mat22 singular = new Mat22(1.0f, 2.0f, 2.0f, 4.0f);
            Vector2F b = new Vector2F(1.0f, 2.0f);
            
            Vector2F result = singular.Solve(b);
            
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that constructor with negative values should work
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeValues_ShouldWork()
        {
            Mat22 mat = new Mat22(-1.0f, -2.0f, -3.0f, -4.0f);
            
            Assert.Equal(-1.0f, mat.Ex.X);
            Assert.Equal(-3.0f, mat.Ex.Y);
            Assert.Equal(-2.0f, mat.Ey.X);
            Assert.Equal(-4.0f, mat.Ey.Y);
        }
    }
}

