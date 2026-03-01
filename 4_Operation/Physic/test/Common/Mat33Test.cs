// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mat33Test.cs
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
    ///     The mat 33 test class
    /// </summary>
    public class Mat33Test
    {
        /// <summary>
        ///     Tests that constructor with vectors should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithVectors_ShouldInitializeCorrectly()
        {
            Vector3F c1 = new Vector3F(1.0f, 2.0f, 3.0f);
            Vector3F c2 = new Vector3F(4.0f, 5.0f, 6.0f);
            Vector3F c3 = new Vector3F(7.0f, 8.0f, 9.0f);
            
            Mat33 mat = new Mat33(c1, c2, c3);
            
            Assert.Equal(c1, mat.Ex);
            Assert.Equal(c2, mat.Ey);
            Assert.Equal(c3, mat.Ez);
        }

        /// <summary>
        ///     Tests that set zero should create zero matrix
        /// </summary>
        [Fact]
        public void SetZero_ShouldCreateZeroMatrix()
        {
            Mat33 mat = new Mat33(
                new Vector3F(1.0f, 2.0f, 3.0f),
                new Vector3F(4.0f, 5.0f, 6.0f),
                new Vector3F(7.0f, 8.0f, 9.0f)
            );
            
            mat.SetZero();
            
            Assert.Equal(Vector3F.Zero, mat.Ex);
            Assert.Equal(Vector3F.Zero, mat.Ey);
            Assert.Equal(Vector3F.Zero, mat.Ez);
        }

        /// <summary>
        ///     Tests that solve 33 should return correct solution
        /// </summary>
        [Fact]
        public void Solve33_ShouldReturnCorrectSolution()
        {
            Mat33 mat = new Mat33(
                new Vector3F(1.0f, 0.0f, 0.0f),
                new Vector3F(0.0f, 1.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Vector3F b = new Vector3F(2.0f, 3.0f, 4.0f);
            
            Vector3F x = mat.Solve33(b);
            
            Assert.Equal(2.0f, x.X, 5);
            Assert.Equal(3.0f, x.Y, 5);
            Assert.Equal(4.0f, x.Z, 5);
        }

        /// <summary>
        ///     Tests that solve 22 should return correct solution
        /// </summary>
        [Fact]
        public void Solve22_ShouldReturnCorrectSolution()
        {
            Mat33 mat = new Mat33(
                new Vector3F(2.0f, 1.0f, 0.0f),
                new Vector3F(1.0f, 2.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Vector2F b = new Vector2F(5.0f, 7.0f);
            
            Vector2F x = mat.Solve22(b);
            
            Assert.Equal(1.0f, x.X, 5);
            Assert.Equal(3.0f, x.Y, 5);
        }

        /// <summary>
        ///     Tests that get inverse 22 should compute correctly
        /// </summary>
        [Fact]
        public void GetInverse22_ShouldComputeCorrectly()
        {
            Mat33 mat = new Mat33(
                new Vector3F(4.0f, 2.0f, 0.0f),
                new Vector3F(3.0f, 1.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Mat33 inverse = new Mat33();
            
            mat.GetInverse22(ref inverse);
            
            Assert.Equal(-0.5f, inverse.Ex.X, 5);
            Assert.Equal(1.0f, inverse.Ex.Y, 5);
            Assert.Equal(1.5f, inverse.Ey.X, 5);
            Assert.Equal(-2.0f, inverse.Ey.Y, 5);
        }

        /// <summary>
        ///     Tests that get sym inverse 33 should compute correctly
        /// </summary>
        [Fact]
        public void GetSymInverse33_ShouldComputeCorrectly()
        {
            Mat33 mat = new Mat33(
                new Vector3F(1.0f, 0.0f, 0.0f),
                new Vector3F(0.0f, 1.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Mat33 inverse = new Mat33();
            
            mat.GetSymInverse33(ref inverse);
            
            Assert.Equal(1.0f, inverse.Ex.X, 5);
            Assert.Equal(0.0f, inverse.Ex.Y, 5);
            Assert.Equal(0.0f, inverse.Ex.Z, 5);
        }

        /// <summary>
        ///     Tests that constructor with zero vectors should work
        /// </summary>
        [Fact]
        public void Constructor_WithZeroVectors_ShouldWork()
        {
            Mat33 mat = new Mat33(Vector3F.Zero, Vector3F.Zero, Vector3F.Zero);
            
            Assert.Equal(Vector3F.Zero, mat.Ex);
            Assert.Equal(Vector3F.Zero, mat.Ey);
            Assert.Equal(Vector3F.Zero, mat.Ez);
        }

        /// <summary>
        ///     Tests that solve 33 with identity should return same vector
        /// </summary>
        [Fact]
        public void Solve33_WithIdentity_ShouldReturnSameVector()
        {
            Mat33 identity = new Mat33(
                new Vector3F(1.0f, 0.0f, 0.0f),
                new Vector3F(0.0f, 1.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Vector3F b = new Vector3F(5.0f, 6.0f, 7.0f);
            
            Vector3F x = identity.Solve33(b);
            
            Assert.Equal(b.X, x.X, 5);
            Assert.Equal(b.Y, x.Y, 5);
            Assert.Equal(b.Z, x.Z, 5);
        }

        /// <summary>
        ///     Tests that solve 22 with identity should return same vector
        /// </summary>
        [Fact]
        public void Solve22_WithIdentity_ShouldReturnSameVector()
        {
            Mat33 identity = new Mat33(
                new Vector3F(1.0f, 0.0f, 0.0f),
                new Vector3F(0.0f, 1.0f, 0.0f),
                new Vector3F(0.0f, 0.0f, 1.0f)
            );
            Vector2F b = new Vector2F(3.0f, 4.0f);
            
            Vector2F x = identity.Solve22(b);
            
            Assert.Equal(b.X, x.X, 5);
            Assert.Equal(b.Y, x.Y, 5);
        }

        /// <summary>
        ///     Tests that set zero multiple times should remain zero
        /// </summary>
        [Fact]
        public void SetZero_MultipleTimes_ShouldRemainZero()
        {
            Mat33 mat = new Mat33(
                new Vector3F(1.0f, 2.0f, 3.0f),
                new Vector3F(4.0f, 5.0f, 6.0f),
                new Vector3F(7.0f, 8.0f, 9.0f)
            );
            
            mat.SetZero();
            mat.SetZero();
            
            Assert.Equal(Vector3F.Zero, mat.Ex);
            Assert.Equal(Vector3F.Zero, mat.Ey);
            Assert.Equal(Vector3F.Zero, mat.Ez);
        }

        /// <summary>
        ///     Tests that constructor with negative values should work
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeValues_ShouldWork()
        {
            Vector3F c1 = new Vector3F(-1.0f, -2.0f, -3.0f);
            Vector3F c2 = new Vector3F(-4.0f, -5.0f, -6.0f);
            Vector3F c3 = new Vector3F(-7.0f, -8.0f, -9.0f);
            
            Mat33 mat = new Mat33(c1, c2, c3);
            
            Assert.Equal(c1, mat.Ex);
            Assert.Equal(c2, mat.Ey);
            Assert.Equal(c3, mat.Ez);
        }
    }
}

