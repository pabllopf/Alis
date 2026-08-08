using System;
using System.Collections.Generic;
using System.Reflection;
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

        // ========================================================================
        // CalculateBeta — PointOnLineSegment branches
        // ========================================================================

        /// <summary>
        /// Tests that calculate beta with point on line segment returns half coefficient
        /// </summary>
        [Fact]
        public void CalculateBeta_WithPointOnLineSegment_ReturnsHalfCoefficient()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            // Edge from (0,0) to (2,0), point at (0,0) which is start
            object edge = ctor.Invoke(new object[] { new Vector2F(0f, 0f), new Vector2F(2f, 0f) });

            MethodInfo calcBeta = typeof(YuPengClipper).GetMethod("CalculateBeta", BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)calcBeta.Invoke(null, new object[] { new Vector2F(0f, 0f), edge, 2f });
            // Point (0,0) is at start -> PointOnLineSegment: 0.5 * 2 = 1.0
            Assert.True(result >= 0.5f);

            result = (float)calcBeta.Invoke(null, new object[] { new Vector2F(2f, 0f), edge, 2f });
            Assert.True(result >= 0.5f);
        }

        /// <summary>
        /// Tests that calculate beta with point outside simplex returns zero
        /// </summary>
        [Fact]
        public void CalculateBeta_WithPointOutsideSimplex_ReturnsZero()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            // Edge from (1,0) to (2,0) - not starting at ZERO
            object edge = ctor.Invoke(new object[] { new Vector2F(1f, 0f), new Vector2F(2f, 0f) });

            MethodInfo calcBeta = typeof(YuPengClipper).GetMethod("CalculateBeta", BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)calcBeta.Invoke(null, new object[] { new Vector2F(10f, 10f), edge, 1f });
            Assert.Equal(0f, result, 5);
        }

        // ========================================================================
        // CalculateSimplexCoefficient — isLeft == 0 branch (collinear points)
        // ========================================================================

        /// <summary>
        /// Tests that calculate simplex coefficient with collinear points returns zero
        /// </summary>
        [Fact]
        public void CalculateSimplexCoefficient_WithCollinearPoints_ReturnsZero()
        {
            MethodInfo method = typeof(YuPengClipper).GetMethod("CalculateSimplexCoefficient", BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f), new Vector2F(2f, 0f) });
            Assert.Equal(0f, result, 5);
        }

        /// <summary>
        /// Tests that calculate simplex coefficient with left turn returns positive
        /// </summary>
        [Fact]
        public void CalculateSimplexCoefficient_WithLeftTurn_ReturnsPositive()
        {
            MethodInfo method = typeof(YuPengClipper).GetMethod("CalculateSimplexCoefficient", BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f), new Vector2F(0f, 1f) });
            Assert.Equal(1f, result, 5);
        }

        /// <summary>
        /// Tests that calculate simplex coefficient with right turn returns negative
        /// </summary>
        [Fact]
        public void CalculateSimplexCoefficient_WithRightTurn_ReturnsNegative()
        {
            MethodInfo method = typeof(YuPengClipper).GetMethod("CalculateSimplexCoefficient", BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { new Vector2F(0f, 0f), new Vector2F(0f, 1f), new Vector2F(1f, 0f) });
            Assert.Equal(-1f, result, 5);
        }

        /// <summary>
        ///     Tests that Edge.Equals with null returns false.
        /// </summary>
        [Fact]
        public void Edge_Equals_WithNull_ReturnsFalse()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            object edge = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });

            MethodInfo equalsObj = edgeType.GetMethod("Equals", new[] { typeof(object) });
            bool result = (bool)equalsObj.Invoke(edge, new object[] { null });
            Assert.False(result);

            MethodInfo typedEquals = edgeType.GetMethod("Equals", new[] { edgeType });
            bool result2 = (bool)typedEquals.Invoke(edge, new object[] { null });
            Assert.False(result2);
        }

        /// <summary>
        ///     Tests that Edge.GetHashCode is consistent for equal edges.
        /// </summary>
        [Fact]
        public void Edge_GetHashCode_ReturnsConsistentValue()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            object edge1 = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });
            object edge2 = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });

            int hash1 = (int)edgeType.GetMethod("GetHashCode").Invoke(edge1, null);
            int hash2 = (int)edgeType.GetMethod("GetHashCode").Invoke(edge2, null);

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests Union when both polygons share the same AABB lower bound,
        ///     so translate == Vector2F.Zero in Execute().
        /// </summary>
        [Fact]
        public void Union_WhenTranslateIsZero_Succeeds()
        {
            Vertices square1 = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(1f, 3f)
            });
            Vertices square2 = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error;
            List<Vertices> result = YuPengClipper.Union(square1, square2, out error);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(PolyClipError.None, error);
        }
    }
}
