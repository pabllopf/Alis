// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexVertexTest.cs
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
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The simplex vertex test class
    /// </summary>
    public class SimplexVertexTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            SimplexVertex vertex = new SimplexVertex();
            
            Assert.Equal(0.0f, vertex.A);
            Assert.Equal(0, vertex.IndexA);
            Assert.Equal(0, vertex.IndexB);
            Assert.Equal(Vector2F.Zero, vertex.W);
            Assert.Equal(Vector2F.Zero, vertex.Wa);
            Assert.Equal(Vector2F.Zero, vertex.Wb);
        }

        /// <summary>
        ///     Tests that a property should set and get correctly
        /// </summary>
        [Fact]
        public void AProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                A = 0.75f
            };
            
            Assert.Equal(0.75f, vertex.A);
        }

        /// <summary>
        ///     Tests that index a property should set and get correctly
        /// </summary>
        [Fact]
        public void IndexAProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                IndexA = 5
            };
            
            Assert.Equal(5, vertex.IndexA);
        }

        /// <summary>
        ///     Tests that index b property should set and get correctly
        /// </summary>
        [Fact]
        public void IndexBProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                IndexB = 10
            };
            
            Assert.Equal(10, vertex.IndexB);
        }

        /// <summary>
        ///     Tests that w property should set and get correctly
        /// </summary>
        [Fact]
        public void WProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                W = new Vector2F(1.5f, 2.5f)
            };
            
            Assert.Equal(1.5f, vertex.W.X);
            Assert.Equal(2.5f, vertex.W.Y);
        }

        /// <summary>
        ///     Tests that wa property should set and get correctly
        /// </summary>
        [Fact]
        public void WaProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                Wa = new Vector2F(3.0f, 4.0f)
            };
            
            Assert.Equal(3.0f, vertex.Wa.X);
            Assert.Equal(4.0f, vertex.Wa.Y);
        }

        /// <summary>
        ///     Tests that wb property should set and get correctly
        /// </summary>
        [Fact]
        public void WbProperty_ShouldSetAndGetCorrectly()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                Wb = new Vector2F(5.0f, 6.0f)
            };
            
            Assert.Equal(5.0f, vertex.Wb.X);
            Assert.Equal(6.0f, vertex.Wb.Y);
        }

        /// <summary>
        ///     Tests that simplex vertex should support negative indices
        /// </summary>
        [Fact]
        public void SimplexVertex_ShouldSupportNegativeIndices()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                IndexA = -1,
                IndexB = -5
            };
            
            Assert.Equal(-1, vertex.IndexA);
            Assert.Equal(-5, vertex.IndexB);
        }

        /// <summary>
        ///     Tests that simplex vertex should support barycentric coordinate range
        /// </summary>
        [Fact]
        public void SimplexVertex_ShouldSupportBarycentricCoordinateRange()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                A = 1.0f
            };
            
            Assert.Equal(1.0f, vertex.A);
            Assert.True(vertex.A >= 0.0f && vertex.A <= 1.0f);
        }

        /// <summary>
        ///     Tests that simplex vertex should be value type
        /// </summary>
        [Fact]
        public void SimplexVertex_ShouldBeValueType()
        {
            SimplexVertex vertex1 = new SimplexVertex { A = 0.5f };
            SimplexVertex vertex2 = vertex1;
            
            vertex2.A = 0.75f;
            
            Assert.NotEqual(vertex1.A, vertex2.A);
        }

        /// <summary>
        ///     Tests that simplex vertex should calculate w from wa and wb
        /// </summary>
        [Fact]
        public void SimplexVertex_ShouldCalculateWFromWaAndWb()
        {
            SimplexVertex vertex = new SimplexVertex
            {
                Wa = new Vector2F(10.0f, 20.0f),
                Wb = new Vector2F(5.0f, 8.0f)
            };
            
            Vector2F expectedW = vertex.Wb - vertex.Wa;
            vertex.W = expectedW;
            
            Assert.Equal(expectedW, vertex.W);
            Assert.Equal(-5.0f, vertex.W.X);
            Assert.Equal(-12.0f, vertex.W.Y);
        }
    }
}

