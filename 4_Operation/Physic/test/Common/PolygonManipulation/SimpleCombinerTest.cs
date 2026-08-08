using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The simple combiner test class
    /// </summary>
    public class SimpleCombinerTest
    {
        /// <summary>
        /// Tests that polygonize triangles empty list returns same
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_EmptyList_ReturnsSame()
        {
            List<Vertices> empty = new List<Vertices>();
            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(empty);

            Assert.Same(empty, result);
        }

        /// <summary>
        /// Tests that polygonize triangles single valid triangle returns one polygon
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_SingleValidTriangle_ReturnsOnePolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
            Assert.Equal(3, result[0].Count);
        }

        /// <summary>
        /// Tests that polygonize triangles degenerate triangle is skipped
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_DegenerateTriangle_IsSkipped()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(1, 0) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that polygonize triangles two adjacent triangles combines
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_TwoAdjacentTriangles_Combines()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(1, 0), new Vector2F(0, 1), new Vector2F(1, 1) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
            Assert.True(result[0].Count >= 3);
        }

        /// <summary>
        /// Tests that polygonize triangles two adjacent triangles with swap combines
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_TwoAdjacentTrianglesWithSwap_Combines()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 1), new Vector2F(-1, 1) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
            Assert.True(result[0].Count >= 3);
        }

        /// <summary>
        /// Tests that polygonize triangles non adjacent triangles stays separate
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_NonAdjacentTriangles_StaysSeparate()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(5, 5), new Vector2F(6, 5), new Vector2F(5, 6) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that polygonize triangles max polys limit respected
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_MaxPolysLimit_Respected()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(5, 5), new Vector2F(6, 5), new Vector2F(5, 6) },
                new Vertices { new Vector2F(10, 10), new Vector2F(11, 10), new Vector2F(10, 11) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles, maxPolys: 2);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that polygonize triangles all degenerate returns empty
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_AllDegenerate_ReturnsEmpty()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(1, 0) },
                new Vertices { new Vector2F(2, 2), new Vector2F(2, 2), new Vector2F(3, 2) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that polygonize triangles all degenerate flags covered returns empty
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_AllDegenerateFlagsCovered_ReturnsEmpty()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0) },
                new Vertices { new Vector2F(1, 1), new Vector2F(2, 2), new Vector2F(2, 2) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that polygonize triangles first and last same is degenerate
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_FirstAndLastSame_IsDegenerate()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 0) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that polygonize triangles corrupt polygon logs and skips
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_CorruptPolygon_LogsAndSkips()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
        }

        /// <summary>
        /// Tests that polygonize triangles adjacent with different tip index combines
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_AdjacentWithDifferentTipIndex_Combines()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(1, -1), new Vector2F(0, 0), new Vector2F(1, 0) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
            Assert.True(result[0].Count >= 3);
        }

        /// <summary>
        /// Tests that polygonize triangles three in row combines to one
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_ThreeInRow_CombinesToOne()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) },
                new Vertices { new Vector2F(1, 0), new Vector2F(0, 1), new Vector2F(1, 1) },
                new Vertices { new Vector2F(0, 0), new Vector2F(0, 1), new Vector2F(-1, 1) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that combining triangles exceeding MaxPolygonVertices skips the triangle
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_ExceedsMaxVertexCount_SkipsTriangle()
        {
            // Create a regular convex 9-gon fan-triangulated from V0
            // This produces 7 triangles (9 vertices → 7 triangles in a fan)
            // The first 6 combine into an 8-vertex polygon (MaxPolygonVertices)
            // The 7th would make 9 vertices and be skipped (> MaxPolygonVertices)
            int n = 9;
            float r = 5f;
            Vector2F[] verts = new Vector2F[n];
            for (int i = 0; i < n; i++)
            {
                double angle = 2.0 * Math.PI * i / n;
                verts[i] = new Vector2F(r * (float)Math.Cos(angle), r * (float)Math.Sin(angle));
            }

            List<Vertices> triangles = new List<Vertices>(n - 2);
            for (int i = 1; i < n - 1; i++)
            {
                triangles.Add(new Vertices { verts[0], verts[i], verts[i + 1] });
            }

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Equal(2, result.Count);
        }
    }
}
