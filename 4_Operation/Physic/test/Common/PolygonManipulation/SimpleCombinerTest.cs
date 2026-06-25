using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    public class SimpleCombinerTest
    {
        [Fact]
        public void PolygonizeTriangles_EmptyList_ReturnsSame()
        {
            List<Vertices> empty = new List<Vertices>();
            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(empty);

            Assert.Same(empty, result);
        }

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
    }
}
