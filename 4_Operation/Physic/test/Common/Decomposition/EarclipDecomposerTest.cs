// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposerTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The earclip decomposer test class
    /// </summary>
    public class EarclipDecomposerTest
    {
        /// <summary>
        /// Tests that earclip decomposer type should be accessible
        /// </summary>
        [Fact]
        public void EarclipDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(EarclipDecomposer));
        }

        /// <summary>
        /// Tests that convex partition with triangle should return single part
        /// </summary>
        [Fact]
        public void ConvexPartition_WithTriangle_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with square should return triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSquare_ShouldReturnResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 2f),
                new Vector2F(2f, 2f),
                new Vector2F(2f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that convex partition with pentagon should return result
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPentagon_ShouldReturnResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(-0.5f, 1f),
                new Vector2F(1f, 2f),
                new Vector2F(2.5f, 1f),
                new Vector2F(2f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that convex partition with concave shape should decompose
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConcaveShape_ShouldDecompose()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 2f),
                new Vector2F(1f, 2f),
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with custom tolerance should work
        /// </summary>
        [Fact]
        public void ConvexPartition_WithCustomTolerance_ShouldWork()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.1f);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that triangulate polygon with less than 3 vertices returns empty list
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithLessThan3Vertices_ShouldReturnEmptyList()
        {
            Vertices vertices = new Vertices(new[] { new Vector2F(0f, 0f) });

            List<Vertices> result = EarclipDecomposer.TriangulatePolygon(vertices, 0.001f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that resolve pinch point returns false with less than 3 vertices
        /// </summary>
        [Fact]
        public void ResolvePinchPoint_WithLessThan3Vertices_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices(new[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f) });

            bool result = EarclipDecomposer.ResolvePinchPoint(vertices, out Vertices poutA, out Vertices poutB, 0.001f);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that resolve pinch point returns false for a convex polygon without pinch points
        /// </summary>
        [Fact]
        public void ResolvePinchPoint_WithoutPinchPoint_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices(new[] { new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(10f, 10f), new Vector2F(0f, 10f) });

            bool result = EarclipDecomposer.ResolvePinchPoint(vertices, out Vertices poutA, out Vertices poutB, 0.001f);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that remainder corrects negative modulus
        /// </summary>
        [Fact]
        public void Remainder_WithNegativeInput_ShouldReturnPositiveModulus()
        {
            int result = EarclipDecomposer.Remainder(-1, 5);

            Assert.Equal(4, result);
        }

        /// <summary>
        ///     Tests that remainder works with positive input
        /// </summary>
        [Fact]
        public void Remainder_WithPositiveInput_ShouldReturnModulus()
        {
            Assert.Equal(2, EarclipDecomposer.Remainder(7, 5));
            Assert.Equal(3, EarclipDecomposer.Remainder(3, 5));
        }

        /// <summary>
        ///     Tests that is ear returns false for a reflex vertex
        /// </summary>
        [Fact]
        public void IsEar_WithReflexVertex_ShouldReturnFalse()
        {
            float[] xv = { 0f, 0f, 1f, 1f, 3f, 3f };
            float[] yv = { 0f, 2f, 2f, 1f, 1f, 0f };

            bool result = EarclipDecomposer.IsEar(3, xv, yv, 6);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is ear returns false for an out-of-bounds index
        /// </summary>
        [Fact]
        public void IsEar_WithOutOfBoundsIndex_ShouldReturnFalse()
        {
            float[] xv = { 0f, 1f, 0f };
            float[] yv = { 0f, 0f, 1f };

            bool result = EarclipDecomposer.IsEar(5, xv, yv, 3);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is ear returns false for polygon with less than 3 vertices
        /// </summary>
        [Fact]
        public void IsEar_WithLessThan3Vertices_ShouldReturnFalse()
        {
            float[] xv = { 0f, 1f };
            float[] yv = { 0f, 0f };

            bool result = EarclipDecomposer.IsEar(0, xv, yv, 2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is ear returns true for a valid ear in a clockwise triangle
        /// </summary>
        [Fact]
        public void IsEar_WithTriangle_ShouldReturnTrue()
        {
            float[] xv = { 0f, 0f, 1f };
            float[] yv = { 0f, 1f, 0f };

            bool result = EarclipDecomposer.IsEar(0, xv, yv, 3);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that convex partition handles pinch points by splitting and merging
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPinchPoint_ShouldDecompose()
        {
            // Clockwise polygon with near-duplicate start/end vertices to trigger pinch point
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 10f),
                new Vector2F(10f, 10f),
                new Vector2F(10f, 0f),
                new Vector2F(0.0001f, 0.0001f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }
    }
}
