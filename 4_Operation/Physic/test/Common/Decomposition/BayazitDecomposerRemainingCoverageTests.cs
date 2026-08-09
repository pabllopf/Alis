using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The bayazit decomposer remaining coverage tests class
    /// </summary>
    public class BayazitDecomposerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that triangulate polygon with convex polygon above max vertices should split via overflow
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithConvexPolygonAboveMaxVertices_ShouldSplitViaOverflow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(4f, 1f),
                new Vector2F(4f, 2f),
                new Vector2F(4f, 3f),
                new Vector2F(3f, 4f),
                new Vector2F(2f, 4f),
                new Vector2F(1f, 4f),
                new Vector2F(0f, 4f),
                new Vector2F(-1f, 3f),
                new Vector2F(-1f, 2f),
                new Vector2F(-1f, 1f),
                new Vector2F(-0.5f, 0.5f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3);
            }
        }

        /// <summary>
        /// Tests that convex partition with vertex count at max plus one should split
        /// </summary>
        [Fact]
        public void ConvexPartition_WithVertexCountAtMaxPlusOne_ShouldSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(2f, 4f),
                new Vector2F(0f, 4f),
                new Vector2F(-1f, 3f),
                new Vector2F(-1f, 1f),
                new Vector2F(-0.5f, 0.5f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        /// Tests that can see with reflex vertex and target outside wedge should return true
        /// </summary>
        [Fact]
        public void CanSee_WithReflexVertexAndTargetOutsideWedge_ShouldReturnTrue()
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

            bool canSee = BayazitDecomposer.CanSee(3, 1, vertices);

            Assert.True(canSee);
        }

        /// <summary>
        /// Tests that square dist with negative coordinates should return correct value
        /// </summary>
        [Fact]
        public void SquareDist_WithNegativeCoordinates_ShouldReturnCorrectValue()
        {
            Vector2F a = new Vector2F(-3f, -4f);
            Vector2F b = new Vector2F(0f, 0f);

            float dist = BayazitDecomposer.SquareDist(a, b);

            Assert.Equal(25f, dist, 5);
        }

        /// <summary>
        /// Tests that right with collinear points should return false
        /// </summary>
        [Fact]
        public void Right_WithCollinearPoints_ShouldReturnFalse()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 1f);
            Vector2F c = new Vector2F(2f, 2f);

            Assert.False(BayazitDecomposer.Right(a, b, c));
        }

        /// <summary>
        /// Tests that left with collinear points should return false
        /// </summary>
        [Fact]
        public void Left_WithCollinearPoints_ShouldReturnFalse()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(2f, 2f);
            Vector2F c = new Vector2F(4f, 4f);

            Assert.False(BayazitDecomposer.Left(a, b, c));
        }

        /// <summary>
        /// Tests that reflex with convex vertex at corner should return false
        /// </summary>
        [Fact]
        public void Reflex_WithConvexVertexAtCorner_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f)
            });

            Assert.False(BayazitDecomposer.Reflex(0, vertices));
            Assert.False(BayazitDecomposer.Reflex(1, vertices));
            Assert.False(BayazitDecomposer.Reflex(2, vertices));
            Assert.False(BayazitDecomposer.Reflex(3, vertices));
        }

        /// <summary>
        /// Tests that at with index zero should return first vertex
        /// </summary>
        [Fact]
        public void At_WithIndexZero_ShouldReturnFirstVertex()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(5f, 5f),
                new Vector2F(10f, 10f)
            });

            Vector2F result = BayazitDecomposer.At(0, vertices);

            Assert.Equal(new Vector2F(5f, 5f), result);
        }

        /// <summary>
        /// Tests that triangulate polygon with concave three vertex polygon should not throw
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithConcaveThreeVertexPolygon_ShouldNotThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 5f),
                new Vector2F(10f, 0f)
            });

            List<Vertices> result = BayazitDecomposer.TriangulatePolygon(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that triangulate polygon with large convex polygon should not loop
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithLargeConvexPolygon_ShouldNotLoop()
        {
            Vertices vertices = new Vertices(12);
            for (int i = 0; i < 12; i++)
            {
                double angle = i * (3.14159 * 2 / 12);
                vertices.Add(new Vector2F((float)(System.Math.Cos(angle) * 10), (float)(System.Math.Sin(angle) * 10)));
            }

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3);
            }
        }

        /// <summary>
        /// Tests that triangulate polygon with zigzag polygon should hit adjacent split branch
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithZigzagPolygon_ShouldNotThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(3f, 2f),
                new Vector2F(5f, 4f),
                new Vector2F(1f, 4f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that triangulate polygon with star shaped polygon should not throw
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithStarShapedPolygon_ShouldNotThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 1f),
                new Vector2F(6f, 6f),
                new Vector2F(1f, 5f),
                new Vector2F(2f, 3f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }
    }
}
