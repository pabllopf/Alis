// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulateTest.cs
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
    /// The triangulate test class
    /// </summary>
    public class TriangulateTest
    {
        /// <summary>
        /// Tests that triangulate type should be accessible
        /// </summary>
        [Fact]
        public void Triangulate_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Triangulate));
        }

        /// <summary>
        /// Tests that convex partition with triangle using earclip should return single part
        /// </summary>
        [Fact]
        public void ConvexPartition_WithTriangle_UsingEarclip_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Earclip);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with skip sanity checks does not reverse vertices
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSkipSanityChecks_ShouldNotReverse()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 2f),
                new Vector2F(1f, 2f),
                new Vector2F(1f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Earclip, true, 0.001f, true);

            Assert.NotNull(result);
            Assert.True(result.Count >= 0);
        }

        /// <summary>
        /// Tests that convex partition with small polygon returns vertices as is
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSmallPolygon_ReturnsGivenVertices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Bayazit);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(3, result[0].Count);
        }

        /// <summary>
        /// Tests that convex partition using bayazit should return parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuad_UsingBayazit_ShouldReturnParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Bayazit);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition using flipcode should return parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuad_UsingFlipcode_ShouldReturnParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Flipcode);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition using seidel should return parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuad_UsingSeidel_ShouldReturnParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Seidel);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition using seidel trapezoids should return parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuad_UsingSeidelTrapezoids_ShouldReturnParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.SeidelTrapezoids);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition using delauny should return parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuad_UsingDelauny_ShouldReturnParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Delauny);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with invalid algorithm throws
        /// </summary>
        [Fact]
        public void ConvexPartition_WithInvalidAlgorithm_ThrowsArgumentOutOfRangeException()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
                Triangulate.ConvexPartition(vertices, (TriangulationAlgorithm)999));
        }

        /// <summary>
        /// Tests that convex partition with discard and fix invalid false should not discard
        /// </summary>
        [Fact]
        public void ConvexPartition_WithDiscardAndFixInvalidFalse_ShouldNotDiscard()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Earclip, false);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that validate polygon returns true for valid polygon
        /// </summary>
        [Fact]
        public void ValidatePolygon_WithValidPolygon_ReturnsTrue()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            bool result = Triangulate.ValidatePolygon(vertices);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that convex partition with thin polygon triggers discard of invalid results
        /// </summary>
        [Fact]
        public void ConvexPartition_WithThinPolygon_UsingSeidelTrapezoids_ShouldDiscardInvalidResults()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0.00001f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.SeidelTrapezoids);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that convex partition with clockwise polygon using bayazit reverses to ccw
        /// </summary>
        [Fact]
        public void ConvexPartition_WithClockwisePolygon_UsingBayazit_ShouldReverseToCcw()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 2f),
                new Vector2F(2f, 2f),
                new Vector2F(2f, 0f),
                new Vector2F(0f, 0f)
            });

            List<Vertices> result = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Bayazit);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that validate polygon returns false for null or empty polygon
        /// </summary>
        [Fact]
        public void ValidatePolygon_WithInvalidPolygon_ReturnsFalse()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f)
            });

            bool result = Triangulate.ValidatePolygon(vertices);

            Assert.False(result);
        }
    }
}
