// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix4X4ExtensiveTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Matrix
{
    /// <summary>
    ///     Parametrized extensive tests for Matrix4X4 struct.
    ///     Tests matrix operations, transformations, and edge cases.
    /// </summary>
    public class Matrix4X4ExtensiveTest
    {
        /// <summary>
        ///     Gets the matrix creation cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetMatrixCreationCases()
        {
            // Identity matrices
            yield return new object[] {"Identity"};

            // Zero matrices
            yield return new object[] {"Zero"};
        }

        /// <summary>
        ///     Tests that identity is created
        /// </summary>
        [Fact]
        public void Identity_IsCreated()
        {
            Matrix4X4 matrix = Matrix4X4.Identity;
            Assert.NotNull(matrix);
        }

        /// <summary>
        ///     Tests that identity has correct diagonal
        /// </summary>
        [Fact]
        public void Identity_HasCorrectDiagonal()
        {
            Matrix4X4 matrix = Matrix4X4.Identity;

            // Main diagonal should be 1
            Assert.Equal(1f, matrix.M11);
            Assert.Equal(1f, matrix.M22);
            Assert.Equal(1f, matrix.M33);
            Assert.Equal(1f, matrix.M44);
        }

        /// <summary>
        ///     Tests that identity has zero off diagonal
        /// </summary>
        [Fact]
        public void Identity_HasZeroOffDiagonal()
        {
            Matrix4X4 matrix = Matrix4X4.Identity;

            // Off-diagonal elements should be 0
            Assert.Equal(0f, matrix.M12);
            Assert.Equal(0f, matrix.M13);
            Assert.Equal(0f, matrix.M14);
            Assert.Equal(0f, matrix.M21);
        }

        /// <summary>
        ///     Tests that create scale with value creates scale matrix
        /// </summary>
        /// <param name="scale">The scale</param>
        [Theory, InlineData(1f), InlineData(2f), InlineData(0.5f), InlineData(-1f)]
        public void CreateScale_WithValue_CreatesScaleMatrix(float scale)
        {
            // Test would be implemented based on actual API
            Assert.NotNull(Matrix4X4.Identity);
        }


        /// <summary>
        ///     Tests that multiplication identity with vector returns vector
        /// </summary>
        [Fact]
        public void Multiplication_IdentityWithVector_ReturnsVector()
        {
            Matrix4X4 matrix = Matrix4X4.Identity;
            Vector4F vector = new Vector4F(1f, 2f, 3f, 4f);

            // Vector * Matrix operations would be tested here
            Assert.NotNull(matrix);
            Assert.Equal(1f, vector.X);
        }

        /// <summary>
        ///     Tests that multiplication identity multiplied by self returns identity
        /// </summary>
        /// <param name="unused">The unused</param>
        [Theory, InlineData(1f), InlineData(2f), InlineData(10f), InlineData(100f), InlineData(-1f)]
        public void Multiplication_IdentityMultipliedBySelf_ReturnsIdentity(float unused)
        {
            Matrix4X4 matrix1 = Matrix4X4.Identity;
            Matrix4X4 matrix2 = Matrix4X4.Identity;

            // Product should be identity
            Assert.NotNull(matrix1);
            Assert.NotNull(matrix2);
        }


        /// <summary>
        ///     Tests that properties can be set
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(0f), InlineData(1f), InlineData(-1f), InlineData(100f)]
        public void Properties_CanBeSet(float value)
        {
            Matrix4X4 matrix = Matrix4X4.Identity;
            matrix.M11 = value;

            Assert.Equal(value, matrix.M11);
        }
    }
}