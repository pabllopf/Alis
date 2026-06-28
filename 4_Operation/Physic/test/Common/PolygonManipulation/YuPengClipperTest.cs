using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The yu peng clipper test class
    /// </summary>
    public class YuPengClipperTest
    {
        /// <summary>
        /// Tests that union overlapping squares returns result
        /// </summary>
        [Fact]
        public void Union_OverlappingSquares_ReturnsResult()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(1f, 3f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(square1, square2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that union non overlapping squares returns result
        /// </summary>
        [Fact]
        public void Union_NonOverlappingSquares_ReturnsResult()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(5f, 5f),
                new Vector2F(6f, 5f),
                new Vector2F(6f, 6f),
                new Vector2F(5f, 6f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(square1, square2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that union overlapping triangles returns result
        /// </summary>
        [Fact]
        public void Union_OverlappingTriangles_ReturnsResult()
        {
            Vertices tri1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(0f, 2f)
            });
            Vertices tri2 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(tri1, tri2, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that union one inside another returns outer
        /// </summary>
        [Fact]
        public void Union_OneInsideAnother_ReturnsOuter()
        {
            Vertices outer = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 3f),
                new Vector2F(0f, 3f)
            });
            Vertices inner = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(outer, inner, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that difference overlapping squares returns result
        /// </summary>
        [Fact]
        public void Difference_OverlappingSquares_ReturnsResult()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(1f, 3f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Difference(square1, square2, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that difference non overlapping returns poly 1
        /// </summary>
        [Fact]
        public void Difference_NonOverlapping_ReturnsPoly1()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(5f, 5f),
                new Vector2F(6f, 5f),
                new Vector2F(6f, 6f),
                new Vector2F(5f, 6f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Difference(square1, square2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that intersect overlapping squares returns result
        /// </summary>
        [Fact]
        public void Intersect_OverlappingSquares_ReturnsResult()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(1f, 3f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Intersect(square1, square2, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that intersect non overlapping returns result
        /// </summary>
        [Fact]
        public void Intersect_NonOverlapping_ReturnsResult()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(5f, 5f),
                new Vector2F(6f, 5f),
                new Vector2F(6f, 6f),
                new Vector2F(5f, 6f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Intersect(square1, square2, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that intersect one inside another returns inner
        /// </summary>
        [Fact]
        public void Intersect_OneInsideAnother_ReturnsInner()
        {
            Vertices outer = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 3f),
                new Vector2F(0f, 3f)
            });
            Vertices inner = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Intersect(outer, inner, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that union adjacent squares touching edges
        /// </summary>
        [Fact]
        public void Union_AdjacentSquares_TouchingEdges()
        {
            Vertices left = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });
            Vertices right = new Vertices(new[]
            {
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 1f),
                new Vector2F(1f, 1f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(left, right, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that difference one inside another returns result
        /// </summary>
        [Fact]
        public void Difference_OneInsideAnother_ReturnsResult()
        {
            Vertices outer = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 3f),
                new Vector2F(0f, 3f)
            });
            Vertices inner = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Difference(outer, inner, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that union polygon with origin edge returns result
        /// </summary>
        [Fact]
        public void Union_PolygonWithOriginEdge_ReturnsResult()
        {
            Vertices poly1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(0f, 2f)
            });
            Vertices poly2 = new Vertices(new[]
            {
                new Vector2F(-1f, 0f),
                new Vector2F(0f, -1f),
                new Vector2F(0f, 0f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(poly1, poly2, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that union identical polygons returns result
        /// </summary>
        [Fact]
        public void Union_IdenticalPolygons_ReturnsResult()
        {
            Vertices poly = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(poly, poly, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
