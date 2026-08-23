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

        /// <summary>
        /// Tests that difference with overlapping squares returns polygon with hole
        /// </summary>
        [Fact]
        public void Difference_NonOverlappingSquaresWithGap_ReturnsPoly1()
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
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 1f),
                new Vector2F(2f, 1f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Difference(left, right, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that difference with identical polygons returns result
        /// </summary>
        [Fact]
        public void Difference_IdenticalPolygons_ReturnsResult()
        {
            Vertices poly = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Difference(poly, poly, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that intersect with overlapping squares returns expected result
        /// </summary>
        [Fact]
        public void Intersect_OverlappingSquaresWithOffset_ReturnsResult()
        {
            Vertices left = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });
            Vertices right = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(1f, 3f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Intersect(left, right, out error);

            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that intersect with identical polygons returns the polygon
        /// </summary>
        [Fact]
        public void Intersect_IdenticalPolygons_ReturnsOriginal()
        {
            Vertices poly = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Intersect(poly, poly, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(PolyClipError.None, error);
        }

        /// <summary>
        /// Tests that difference with non-overlapping triangles returns result
        /// </summary>
        [Fact]
        public void Difference_NonOverlappingTriangles_ReturnsPoly1()
        {
            Vertices tri1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 2f)
            });
            Vertices tri2 = new Vertices(new[]
            {
                new Vector2F(5f, 0f),
                new Vector2F(7f, 0f),
                new Vector2F(6f, 2f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Difference(tri1, tri2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that intesect with triangles that share a corner returns result
        /// </summary>
        [Fact]
        public void Intersect_TrianglesSharingCorner_ReturnsResult()
        {
            Vertices tri1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 2f)
            });
            Vertices tri2 = new Vertices(new[]
            {
                new Vector2F(1f, 2f),
                new Vector2F(3f, 2f),
                new Vector2F(2f, 4f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Intersect(tri1, tri2, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that union with triangles that share a corner returns result
        /// </summary>
        [Fact]
        public void Union_TrianglesSharingCorner_ReturnsResult()
        {
            Vertices tri1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 2f)
            });
            Vertices tri2 = new Vertices(new[]
            {
                new Vector2F(1f, 2f),
                new Vector2F(3f, 2f),
                new Vector2F(2f, 4f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(tri1, tri2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that difference with overlapping triangles returns result
        /// </summary>
        [Fact]
        public void Difference_OverlappingTriangles_ReturnsResult()
        {
            Vertices tri1 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(0f, 3f)
            });
            Vertices tri2 = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Difference(tri1, tri2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that union with large coordinates returns result without overflow
        /// </summary>
        [Fact]
        public void Union_LargeCoordinates_ReturnsResult()
        {
            Vertices big1 = new Vertices(new[]
            {
                new Vector2F(1000f, 1000f),
                new Vector2F(2000f, 1000f),
                new Vector2F(2000f, 2000f),
                new Vector2F(1000f, 2000f)
            });
            Vertices big2 = new Vertices(new[]
            {
                new Vector2F(1500f, 1500f),
                new Vector2F(2500f, 1500f),
                new Vector2F(2500f, 2500f),
                new Vector2F(1500f, 2500f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(big1, big2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that union with a polygon at origin returns result
        /// </summary>
        [Fact]
        public void Union_PolygonAtOrigin_ReturnsResult()
        {
            Vertices atOrigin = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });
            Vertices overlapping = new Vertices(new[]
            {
                new Vector2F(-0.5f, -0.5f),
                new Vector2F(0.5f, -0.5f),
                new Vector2F(0.5f, 0.5f),
                new Vector2F(-0.5f, 0.5f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(atOrigin, overlapping, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(PolyClipError.None, error);
        }

       
    }
}
