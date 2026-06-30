// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointSetTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Sets
{
    /// <summary>
    ///     The point set test class
    /// </summary>
    public class PointSetTest
    {
        /// <summary>
        ///     Tests that constructor copies the points list
        /// </summary>
        [Fact]
        public void Constructor_ShouldCopyPointsList()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            Assert.Equal(3, pointSet.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that GetPoints returns an immutable list
        /// </summary>
        [Fact]
        public void GetPoints_ShouldReturnPoints()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0)
            };

            PointSet pointSet = new PointSet(points);

            Assert.NotNull(pointSet.GetPoints);
            Assert.Equal(2, pointSet.GetPoints.Count);
        }

        /// <summary>
        ///     Tests that TriangulationMode returns Unconstrained
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldReturnUnconstrained()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            Assert.Equal(TriangulationMode.Unconstrained, pointSet.TriangulationMode);
        }

        /// <summary>
        ///     Tests that AddTriangle creates the triangles list when null
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldCreateTrianglesListWhenNull()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            Assert.Null(pointSet.GetTriangles);

            DelaunayTriangle triangle = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            pointSet.AddTriangle(triangle);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.Single(pointSet.GetTriangles);
        }

        /// <summary>
        ///     Tests that AddTriangle adds to existing triangles list
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldAddToExistingTrianglesList()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);
            DelaunayTriangle triangle1 = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            pointSet.AddTriangle(triangle1);
            DelaunayTriangle triangle2 = new DelaunayTriangle(
                new TriangulationPoint(1, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(0, 1));

            pointSet.AddTriangle(triangle2);

            Assert.Equal(2, pointSet.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that AddTriangles creates the triangles list when null
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldCreateTrianglesListWhenNull()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(
                    new TriangulationPoint(0, 0),
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(0, 1))
            };

            pointSet.AddTriangles(triangles);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.Single(pointSet.GetTriangles);
        }

        /// <summary>
        ///     Tests that AddTriangles adds multiple triangles
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldAddMultipleTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(
                    new TriangulationPoint(0, 0),
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(0, 1)),
                new DelaunayTriangle(
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(1, 1),
                    new TriangulationPoint(0, 1)),
                new DelaunayTriangle(
                    new TriangulationPoint(0, 0),
                    new TriangulationPoint(1, 1),
                    new TriangulationPoint(0, 1))
            };

            pointSet.AddTriangles(triangles);

            Assert.Equal(3, pointSet.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that AddTriangles adds to existing triangles list
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldAddToExistingTrianglesList()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            DelaunayTriangle triangle1 = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            pointSet.AddTriangle(triangle1);

            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(
                    new TriangulationPoint(1, 0),
                    new TriangulationPoint(1, 1),
                    new TriangulationPoint(0, 1))
            };

            pointSet.AddTriangles(triangles);

            Assert.Equal(2, pointSet.GetTriangles.Count);
        }

        /// <summary>
        /// Tests that prepare triangulation initializes triangles when null
        /// </summary>
        [Fact]
        public void PrepareTriangulation_ShouldInitializeTrianglesWhenNull()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();

            pointSet.PrepareTriangulation(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.Empty(pointSet.GetTriangles);
            Assert.Contains(points[0], tcx.Points);
        }

        /// <summary>
        /// Tests that prepare triangulation clears existing triangles
        /// </summary>
        [Fact]
        public void PrepareTriangulation_ShouldClearExistingTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx1 = new DtSweepContext();
            pointSet.PrepareTriangulation(tcx1);

            DtSweepContext tcx2 = new DtSweepContext();
            pointSet.PrepareTriangulation(tcx2);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.Empty(pointSet.GetTriangles);
        }

        /// <summary>
        /// Tests that ClearTriangles clears the triangles list
        /// </summary>
        [Fact]
        public void ClearTriangles_ShouldClearTrianglesList()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1)
            };

            PointSet pointSet = new PointSet(points);

            DelaunayTriangle triangle1 = new DelaunayTriangle(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(0, 1));

            DelaunayTriangle triangle2 = new DelaunayTriangle(
                new TriangulationPoint(1, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(0, 1));

            pointSet.AddTriangle(triangle1);
            pointSet.AddTriangle(triangle2);
            pointSet.ClearTriangles();

            Assert.Equal(0, pointSet.GetTriangles.Count);
        }
    }
}
