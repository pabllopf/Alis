

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The triangulator test class
    /// </summary>
    public class TriangulatorTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with polyline
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithPolyline()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotNull(triangulator);
            Assert.NotNull(triangulator.Triangles);
            Assert.NotNull(triangulator.Trapezoids);
        }

        /// <summary>
        ///     Tests that triangulator should generate triangles for square
        /// </summary>
        [Fact]
        public void Triangulator_ShouldGenerateTriangles_ForSquare()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should generate trapezoids
        /// </summary>
        [Fact]
        public void Triangulator_ShouldGenerateTrapezoids()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotNull(triangulator.Trapezoids);
        }

        /// <summary>
        ///     Tests that triangulator should handle triangle polygon
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleTrianglePolygon()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(5, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotNull(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should handle pentagon
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandlePentagon()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(12, 5),
                new Point(5, 12),
                new Point(-2, 5)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should accept custom sheer value
        /// </summary>
        [Fact]
        public void Triangulator_ShouldAcceptCustomSheerValue()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.01f);

            Assert.NotNull(triangulator);
        }

        /// <summary>
        ///     Tests that triangulator should handle zero sheer value
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleZeroSheerValue()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.0f);

            Assert.NotNull(triangulator);
        }

        /// <summary>
        ///     Tests that triangulator should handle negative coordinates
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleNegativeCoordinates()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(-10, -10),
                new Point(10, -10),
                new Point(10, 10),
                new Point(-10, 10)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangles property should be accessible
        /// </summary>
        [Fact]
        public void TrianglesProperty_ShouldBeAccessible()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(5, 0),
                new Point(5, 5)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            List<List<Point>> triangles = triangulator.Triangles;

            Assert.NotNull(triangles);
        }

        /// <summary>
        ///     Tests that trapezoids property should be accessible
        /// </summary>
        [Fact]
        public void TrapezoidsProperty_ShouldBeAccessible()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(5, 0),
                new Point(5, 5)
            };

            Triangulator triangulator = new Triangulator(polyLine, 0.001f);

            List<Trapezoid> trapezoids = triangulator.Trapezoids;

            Assert.NotNull(trapezoids);
        }
    }
}