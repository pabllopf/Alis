// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using CDP = Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    ///     The polygon test class
    /// </summary>
    public class PolygonTest
    {
        /// <summary>
        /// Creates the triangle points
        /// </summary>
        /// <returns>A list of cdp polygon point</returns>
        private static List<CDP.PolygonPoint> CreateTrianglePoints()
        {
            return new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0, 0),
                new CDP.PolygonPoint(1, 0),
                new CDP.PolygonPoint(0, 1)
            };
        }

        /// <summary>
        ///     Tests that constructor with 3 points creates a valid polygon
        /// </summary>
        [Fact]
        public void Constructor_WithThreePoints_ShouldCreatePolygon()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that constructor throws on fewer than 3 points
        /// </summary>
        [Fact]
        public void Constructor_WithFewerThanThreePoints_ShouldThrowArgumentException()
        {
            List<CDP.PolygonPoint> points = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0, 0),
                new CDP.PolygonPoint(1, 0)
            };

            Assert.Throws<System.ArgumentException>(() => new CDP.Polygon(points));
        }

        /// <summary>
        ///     Tests that constructor with duplicate first/last point removes last
        /// </summary>
        [Fact]
        public void Constructor_WithDuplicateFirstAndLastPoint_ShouldRemoveLast()
        {
            CDP.PolygonPoint first = new CDP.PolygonPoint(0, 0);
            List<CDP.PolygonPoint> points = new List<CDP.PolygonPoint>
            {
                first,
                new CDP.PolygonPoint(1, 0),
                new CDP.PolygonPoint(0, 1),
                first
            };

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that constructor with IEnumerable creates a valid polygon
        /// </summary>
        [Fact]
        public void Constructor_WithIEnumerable_ShouldCreatePolygon()
        {
            IEnumerable<CDP.PolygonPoint> points = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0, 0),
                new CDP.PolygonPoint(1, 0),
                new CDP.PolygonPoint(0, 1)
            };

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that default constructor creates an empty polygon
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateEmptyPolygon()
        {
            CDP.Polygon polygon = new CDP.Polygon();

            Assert.NotNull(polygon);
        }

        /// <summary>
        ///     Tests that TriangulationMode returns Polygon
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldReturnPolygon()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Equal(TriangulationMode.Polygon, polygon.TriangulationMode);
        }

        /// <summary>
        ///     Tests that AddTriangle creates the triangles list when null
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldCreateTrianglesListWhenNull()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Null(polygon.GetTriangles);

            DelaunayTriangle triangle = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle);

            Assert.NotNull(polygon.GetTriangles);
            Assert.Single(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that AddTriangle adds to existing triangles list
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldAddToExistingTrianglesList()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            DelaunayTriangle triangle1 = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle1);

            DelaunayTriangle triangle2 = new DelaunayTriangle(
                new TriangulationPoint(1, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle2);

            Assert.Equal(2, polygon.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that AddTriangles creates the triangles list when null
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldCreateTrianglesListWhenNull()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(
                    new TriangulationPoint(0, 0),
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(0, 1))
            };

            polygon.AddTriangles(triangles);

            Assert.NotNull(polygon.GetTriangles);
            Assert.Single(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that AddTriangles adds multiple triangles
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldAddMultipleTriangles()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(
                    new TriangulationPoint(0, 0),
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(0, 1)),
                new DelaunayTriangle(
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(1, 1),
                    new TriangulationPoint(0, 1))
            };

            polygon.AddTriangles(triangles);

            Assert.Equal(2, polygon.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that ClearTriangles clears the triangles list when not null
        /// </summary>
        [Fact]
        public void ClearTriangles_ShouldClearTrianglesList()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            DelaunayTriangle triangle1 = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle1);
            DelaunayTriangle triangle2 = new DelaunayTriangle(
                new TriangulationPoint(1, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle2);
            polygon.ClearTriangles();

            Assert.NotNull(polygon.GetTriangles);
            Assert.Equal(0, polygon.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that ClearTriangles does nothing when triangles is null
        /// </summary>
        [Fact]
        public void ClearTriangles_WhenNull_ShouldNotThrow()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            polygon.ClearTriangles();

            Assert.Null(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that GetHoles returns null by default
        /// </summary>
        [Fact]
        public void GetHoles_ShouldReturnNullByDefault()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Null(polygon.GetHoles);
        }

        /// <summary>
        ///     Tests that AddHole adds a hole to the polygon
        /// </summary>
        [Fact]
        public void AddHole_ShouldAddHoleToPolygon()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            List<CDP.PolygonPoint> holePoints = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0.2, 0.2),
                new CDP.PolygonPoint(0.4, 0.2),
                new CDP.PolygonPoint(0.3, 0.4)
            };

            CDP.Polygon hole = new CDP.Polygon(holePoints);
            polygon.AddHole(hole);

            Assert.NotNull(polygon.GetHoles);
            Assert.Single(polygon.GetHoles);
        }

        /// <summary>
        ///     Tests that AddSteinerPoint does not throw
        /// </summary>
        [Fact]
        public void AddSteinerPoint_ShouldNotThrow()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            TriangulationPoint steinerPoint = new TriangulationPoint(0.5, 0.5);

            // Should not throw
            polygon.AddSteinerPoint(steinerPoint);
        }

        /// <summary>
        ///     Tests that AddSteinerPoints does not throw
        /// </summary>
        [Fact]
        public void AddSteinerPoints_ShouldNotThrow()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            List<TriangulationPoint> steinerPoints = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.2, 0.2),
                new TriangulationPoint(0.5, 0.5),
                new TriangulationPoint(0.8, 0.8)
            };

            // Should not throw
            polygon.AddSteinerPoints(steinerPoints);
        }

        /// <summary>
        ///     Tests that ClearSteinerPoints does not throw
        /// </summary>
        [Fact]
        public void ClearSteinerPoints_ShouldNotThrow()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            // Should not throw
            polygon.ClearSteinerPoints();
        }

        /// <summary>
        ///     Tests that AddPoints adds points and sets up circular links
        /// </summary>
        [Fact]
        public void AddPoints_ShouldAddPointsAndSetCircularLinks()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            int initialCount = polygon.GetPoints.Count;

            List<CDP.PolygonPoint> newPoints = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(1, 1),
                new CDP.PolygonPoint(2, 2)
            };

            polygon.AddPoints(newPoints);

            Assert.Equal(initialCount + 2, polygon.GetPoints.Count);
        }


        /// <summary>
        ///     Tests that InsertPointAfter throws when point is not in polygon
        /// </summary>
        [Fact]
        public void InsertPointAfter_WhenPointNotInPolygon_ShouldThrowArgumentException()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            CDP.PolygonPoint externalPoint = new CDP.PolygonPoint(99, 99);
            CDP.PolygonPoint newPoint = new CDP.PolygonPoint(0.5, 0.5);

            Assert.Throws<System.ArgumentException>(() => polygon.InsertPointAfter(externalPoint, newPoint));
        }

        /// <summary>
        ///     Tests that AddPoints adds multiple points to the polygon
        /// </summary>
        [Fact]
        public void AddPoints_ShouldAddMultiplePoints()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            int initialCount = polygon.GetPoints.Count;

            List<CDP.PolygonPoint> newPoints = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(1, 1),
                new CDP.PolygonPoint(2, 2)
            };

            polygon.AddPoints(newPoints);

            Assert.Equal(initialCount + 2, polygon.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that GetPoints returns the points list
        /// </summary>
        [Fact]
        public void GetPoints_ShouldReturnPoints()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.NotNull(polygon.GetPoints);
            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that GetTriangles returns the triangles list after adding
        /// </summary>
        [Fact]
        public void GetTriangles_ShouldReturnTrianglesAfterAdding()
        {
            List<CDP.PolygonPoint> points = CreateTrianglePoints();

            CDP.Polygon polygon = new CDP.Polygon(points);
            DelaunayTriangle triangle = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            polygon.AddTriangle(triangle);

            Assert.NotNull(polygon.GetTriangles);
            Assert.Single(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that AddPoint adds a point after Last is set via AddPoints
        /// </summary>
        [Fact]
        public void AddPoint_ShouldAddPointAndUpdateCount()
        {
            CDP.Polygon polygon = new CDP.Polygon();
            List<CDP.PolygonPoint> initialPoints = CreateTrianglePoints();
            polygon.AddPoints(initialPoints);
            int initialCount = polygon.GetPoints.Count;
            CDP.PolygonPoint newPoint = new CDP.PolygonPoint(1, 1);

            polygon.AddPoint(newPoint);

            Assert.Equal(initialCount + 1, polygon.GetPoints.Count);
            Assert.Contains(newPoint, polygon.GetPoints);
        }

        /// <summary>
        ///     Tests that RemovePoint removes a point from polygon initialized via AddPoints
        /// </summary>
        [Fact]
        public void RemovePoint_ShouldRemovePointAndDecreaseCount()
        {
            CDP.Polygon polygon = new CDP.Polygon();
            List<CDP.PolygonPoint> pts = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0, 0),
                new CDP.PolygonPoint(1, 0),
                new CDP.PolygonPoint(0, 1)
            };
            polygon.AddPoints(pts);
            CDP.PolygonPoint pointToRemove = pts[1];

            polygon.RemovePoint(pointToRemove);

            Assert.Equal(2, polygon.GetPoints.Count);
            Assert.DoesNotContain(pointToRemove, polygon.GetPoints);
        }

        /// <summary>
        ///     Tests that InsertPointAfter inserts at correct position
        /// </summary>
        [Fact]
        public void InsertPointAfter_ShouldInsertAtCorrectPosition()
        {
            CDP.Polygon polygon = new CDP.Polygon();
            List<CDP.PolygonPoint> pts = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0, 0),
                new CDP.PolygonPoint(1, 0),
                new CDP.PolygonPoint(0, 1)
            };
            polygon.AddPoints(pts);
            CDP.PolygonPoint newPoint = new CDP.PolygonPoint(0.5, 0.5);

            polygon.InsertPointAfter(pts[0], newPoint);

            Assert.Equal(4, polygon.GetPoints.Count);
            Assert.Equal(1, polygon.GetPoints.IndexOf(newPoint));
        }

        /// <summary>
        ///     Tests that PrepareTriangulation creates constraints for polygon edges
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithSimplePolygon_ShouldCreateConstraints()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            TestTriangulationContext tcx = new TestTriangulationContext();

            polygon.PrepareTriangulation(tcx);

            Assert.Equal(3, tcx.Constraints.Count);
            Assert.Equal(3, tcx.Points.Count);
            Assert.NotNull(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that PrepareTriangulation processes holes
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithHoles_ShouldProcessHoles()
        {
            List<CDP.PolygonPoint> outerPts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(outerPts);
            List<CDP.PolygonPoint> holePts = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0.2, 0.2),
                new CDP.PolygonPoint(0.4, 0.2),
                new CDP.PolygonPoint(0.3, 0.4)
            };
            CDP.Polygon hole = new CDP.Polygon(holePts);
            polygon.AddHole(hole);
            TestTriangulationContext tcx = new TestTriangulationContext();

            polygon.PrepareTriangulation(tcx);

            Assert.Equal(6, tcx.Constraints.Count);
            Assert.Equal(6, tcx.Points.Count);
        }

        /// <summary>
        ///     Tests that PrepareTriangulation adds steiner points to context
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithSteinerPoints_ShouldAddSteinerPoints()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            TriangulationPoint steiner = new TriangulationPoint(0.5, 0.5);
            polygon.AddSteinerPoint(steiner);
            TestTriangulationContext tcx = new TestTriangulationContext();

            polygon.PrepareTriangulation(tcx);

            Assert.Equal(4, tcx.Points.Count);
        }

        /// <summary>
        ///     Tests that PrepareTriangulation clears existing triangles
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithExistingTriangles_ShouldClearTriangles()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            DelaunayTriangle triangle = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));
            polygon.AddTriangle(triangle);
            TestTriangulationContext tcx = new TestTriangulationContext();

            polygon.PrepareTriangulation(tcx);

            Assert.Empty(polygon.GetTriangles);
        }

        /// <summary>
        ///     Tests that ClearSteinerPoints clears when steiner points exist
        /// </summary>
        [Fact]
        public void ClearSteinerPoints_WithPoints_ShouldClear()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            polygon.AddSteinerPoint(new TriangulationPoint(0.5, 0.5));

            polygon.ClearSteinerPoints();
            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);

            Assert.Equal(3, tcx.Points.Count);
        }

        /// <summary>
        ///     Tests that AddSteinerPoint adds to internal list
        /// </summary>
        [Fact]
        public void AddSteinerPoint_ShouldAddToInternalList()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            TriangulationPoint steiner = new TriangulationPoint(0.5, 0.5);

            polygon.AddSteinerPoint(steiner);
            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);

            Assert.Equal(4, tcx.Points.Count);
        }

        /// <summary>
        ///     Tests that AddSteinerPoints adds multiple points to internal list
        /// </summary>
        [Fact]
        public void AddSteinerPoints_ShouldAddMultipleToInternalList()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            List<TriangulationPoint> steinerPoints = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.2, 0.2),
                new TriangulationPoint(0.5, 0.5)
            };

            polygon.AddSteinerPoints(steinerPoints);
            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);

            Assert.Equal(5, tcx.Points.Count);
        }

        /// <summary>
        ///     Tests that GetHoles returns holes after adding
        /// </summary>
        [Fact]
        public void GetHoles_AfterAddingHole_ShouldReturnHoles()
        {
            List<CDP.PolygonPoint> outerPts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(outerPts);
            List<CDP.PolygonPoint> holePts = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0.2, 0.2),
                new CDP.PolygonPoint(0.4, 0.2),
                new CDP.PolygonPoint(0.3, 0.4)
            };
            CDP.Polygon hole = new CDP.Polygon(holePts);
            polygon.AddHole(hole);

            Assert.NotNull(polygon.GetHoles);
            Assert.Single(polygon.GetHoles);
        }
    }

    /// <summary>
    ///     Test context for PrepareTriangulation
    /// </summary>
    internal class TestTriangulationContext : TriangulationContext
    {
        /// <summary>
        /// Gets the value of the constraints
        /// </summary>
        public List<TriangulationConstraint> Constraints { get; } = new List<TriangulationConstraint>();

        /// <summary>
        /// News the constraint using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The constraint</returns>
        public override TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b)
        {
            TriangulationConstraint constraint = new TriangulationConstraint { P = a, Q = b };
            Constraints.Add(constraint);
            return constraint;
        }
    }
}
