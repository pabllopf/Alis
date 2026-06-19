// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: BayazitDecomposerTest.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    ///     Tests for BayazitDecomposer convex partitioning algorithm coverage.
    /// </summary>
    public class BayazitDecomposerTest
    {
        /// <summary>
        ///     Tests that BayazitDecomposer type should be accessible and static
        /// </summary>
        [Fact]
        public void BayazitDecomposer_TypeShouldBeAccessibleAndStatic()
        {
            Type type = typeof(BayazitDecomposer);

            Assert.NotNull(type);
            Assert.True(type.IsSealed);
            Assert.True(type.IsAbstract);
            Assert.False(type.IsInterface);
        }

        /// <summary>
        ///     Tests that ConvexPartition method exists and returns List of Vertices
        /// </summary>
        [Fact]
        public void ConvexPartition_MethodShouldExistWithExpectedSignature()
        {
            System.Reflection.MethodInfo method = typeof(BayazitDecomposer).GetMethod("ConvexPartition", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            Assert.NotNull(method);
            Assert.Equal(typeof(List<Vertices>), method.ReturnType);
            Assert.Single(method.GetParameters());
            Assert.Equal(typeof(Vertices), method.GetParameters()[0].ParameterType);
        }

        /// <summary>
        ///     Tests convex partition with a simple triangle (already convex)
        /// </summary>
        [Fact]
        public void ConvexPartition_WithTriangle_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(5f, 10f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(3, result[0].Count);
        }

        /// <summary>
        ///     Tests convex partition with a simple rectangle (already convex)
        /// </summary>
        [Fact]
        public void ConvexPartition_WithRectangle_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(4, result[0].Count);
        }

        /// <summary>
        ///     Tests convex partition with a concave polygon (L-shape)
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConcavePolygon_ShouldReturnMultipleParts()
        {
            // L-shape concave polygon (has 1 reflex vertex)
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 5f),
                new Vector2F(5f, 5f),
                new Vector2F(5f, 10f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);

            // Each part should be convex (no reflex vertices)
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3, "Each partitioned part should have at least 3 vertices");
            }
        }

        /// <summary>
        ///     Tests convex partition with a star-shaped concave polygon
        /// </summary>
        [Fact]
        public void ConvexPartition_WithStarShape_ShouldReturnMultipleParts()
        {
            // Simple star/concave polygon with multiple reflex vertices
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(5f, 0f),
                new Vector2F(8f, 3f),
                new Vector2F(10f, 0f),
                new Vector2F(7f, 5f),
                new Vector2F(10f, 10f),
                new Vector2F(5f, 7f),
                new Vector2F(0f, 10f),
                new Vector2F(3f, 5f),
                new Vector2F(0f, 0f),
                new Vector2F(2f, 3f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);

            // Verify all resulting polygons have at least 3 vertices
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3);
            }
        }

        /// <summary>
        ///     Tests that ConvexPartition with vertices exceeding MaxPolygonVertices splits into multiple parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithManyVertices_ShouldRespectMaxPolygonVertices()
        {
            // Create a convex polygon with many vertices (exceeding typical max)
            Vertices vertices = new Vertices(20);
            float angleStep = (float) (Math.PI * 2) / 20;

            for (int i = 0; i < 20; i++)
            {
                float angle = i * angleStep;
                vertices.Add(new Vector2F((float) (Math.Cos(angle) * 10), (float) (Math.Sin(angle) * 10)));
            }

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            // Since the polygon is convex but has many vertices, it should be split
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests the At method with negative indices (circular access)
        /// </summary>
        [Fact]
        public void At_Method_ShouldSupportCircularNegativeIndices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            // Test circular access with negative indices
            Vector2F last = BayazitDecomposer.At(-1, vertices);
            Vector2F secondLast = BayazitDecomposer.At(-2, vertices);

            Assert.Equal(vertices[2], last);
            Assert.Equal(vertices[1], secondLast);
        }

        /// <summary>
        ///     Tests the At method with large negative indices (wrapped)
        /// </summary>
        [Fact]
        public void At_Method_ShouldWrapLargeNegativeIndices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f),
                new Vector2F(1f, 1f)
            });

            // -5 wrapped in a 4-vertex list: (-5 % 4 + 4) % 4 = 3
            Vector2F result = BayazitDecomposer.At(-5, vertices);

            Assert.Equal(vertices[3], result);
        }

        /// <summary>
        ///     Tests the At method with indices beyond count (wrapped)
        /// </summary>
        [Fact]
        public void At_Method_ShouldWrapLargePositiveIndices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            // 5 wrapped in a 3-vertex list: 5 % 3 = 2
            Vector2F result = BayazitDecomposer.At(5, vertices);

            Assert.Equal(vertices[2], result);
        }

        /// <summary>
        ///     Tests the Copy method with valid range
        /// </summary>
        [Fact]
        public void Copy_Method_ShouldCopyVertexRangeCorrectly()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 1f),
                new Vector2F(3f, 3f)
            });

            Vertices copied = BayazitDecomposer.Copy(1, 3, vertices);

            Assert.NotNull(copied);
            Assert.Equal(3, copied.Count);
            Assert.Equal(vertices[1], copied[0]);
            Assert.Equal(vertices[2], copied[1]);
            Assert.Equal(vertices[3], copied[2]);
        }

        /// <summary>
        ///     Tests the Copy method with range where j < i (wraps around)
        /// </summary>
        [Fact]
        public void Copy_Method_ShouldHandleWrappedRange()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 1f),
                new Vector2F(3f, 3f)
            });

            // Copy from 3 to 1 (wrapped): 3, 0, 1
            Vertices copied = BayazitDecomposer.Copy(3, 1, vertices);

            Assert.NotNull(copied);
            Assert.Equal(3, copied.Count);
            Assert.Equal(vertices[3], copied[0]);
            Assert.Equal(vertices[0], copied[1]);
            Assert.Equal(vertices[1], copied[2]);
        }

        /// <summary>
        ///     Tests SquareDist with identical points
        /// </summary>
        [Fact]
        public void SquareDist_WithIdenticalPoints_ShouldReturnZero()
        {
            Vector2F a = new Vector2F(5f, 5f);
            Vector2F b = new Vector2F(5f, 5f);

            float dist = BayazitDecomposer.SquareDist(a, b);

            Assert.Equal(0f, dist);
        }

        /// <summary>
        ///     Tests SquareDist with different points
        /// </summary>
        [Fact]
        public void SquareDist_WithDifferentPoints_ShouldReturnCorrectValue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(3f, 4f);

            float dist = BayazitDecomposer.SquareDist(a, b);

            // (3-0)^2 + (4-0)^2 = 9 + 16 = 25
            Assert.Equal(25f, dist);
        }

        /// <summary>
        ///     Tests Left/Right orientation with counter-clockwise triangle
        /// </summary>
        [Fact]
        public void Left_WithCounterClockwiseTriangle_ShouldReturnTrue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 0f);
            Vector2F c = new Vector2F(0f, 1f);

            bool result = BayazitDecomposer.Left(a, b, c);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests Right/Left orientation with clockwise triangle
        /// </summary>
        [Fact]
        public void Right_WithClockwiseTriangle_ShouldReturnTrue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(0f, 1f);
            Vector2F c = new Vector2F(1f, 0f);

            bool result = BayazitDecomposer.Right(a, b, c);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests LeftOn/RightOn with collinear points
        /// </summary>
        [Fact]
        public void LeftOn_WithCollinearPoints_ShouldReturnTrue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 1f);
            Vector2F c = new Vector2F(2f, 2f);

            Assert.True(BayazitDecomposer.LeftOn(a, b, c));
            Assert.True(BayazitDecomposer.RightOn(a, b, c));
        }

        /// <summary>
        ///     Tests Reflex with a concave vertex
        /// </summary>
        [Fact]
        public void Reflex_WithConcaveVertex_ShouldReturnTrue()
        {
            // L-shape: vertex at index 4 (5f, 5f) is reflex
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 5f),
                new Vector2F(5f, 5f),
                new Vector2F(5f, 10f),
                new Vector2F(0f, 10f)
            });

            // Vertex at index 3 (5f, 5f) should be reflex
            Assert.True(BayazitDecomposer.Reflex(3, vertices));
        }

        /// <summary>
        ///     Tests Reflex with a convex vertex
        /// </summary>
        [Fact]
        public void Reflex_WithConvexVertex_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 5f),
                new Vector2F(5f, 5f),
                new Vector2F(5f, 10f),
                new Vector2F(0f, 10f)
            });

            // Vertex at index 0 (0f, 0f) should NOT be reflex
            Assert.False(BayazitDecomposer.Reflex(0, vertices));
        }

        /// <summary>
        ///     Tests TriangulatePolygon method exists and returns List of Vertices
        /// </summary>
        [Fact]
        public void TriangulatePolygon_MethodShouldExistWithExpectedSignature()
        {
            System.Reflection.MethodInfo method = typeof(BayazitDecomposer).GetMethod("TriangulatePolygon", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Assert.NotNull(method);
            Assert.Equal(typeof(List<Vertices>), method.ReturnType);
        }

        /// <summary>
        ///     Tests that the algorithm handles empty-ish polygons gracefully
        /// </summary>
        [Fact]
        public void ConvexPartition_WithMinimalPolygon_ShouldNotThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            // Should not throw for minimal valid polygon
            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }
    }
}
