// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep test class
    /// </summary>
    public class DTSweepTest
    {
        /// <summary>
        /// Tests that dt sweep type should be accessible
        /// </summary>
        [Fact]
        public void DTSweep_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DtSweep));
        }

        /// <summary>
        /// Verifies that a simple rectangle triangulates into two non-degenerate triangles.
        /// </summary>
        [Fact]
        public void DTSweep_TriangulatesRectangleIntoTwoTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f),
                new Vector2F(2.0f, 1.0f),
                new Vector2F(0.0f, 1.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.Equal(vertices.Count - 2, triangles.Count);
            foreach (Vertices triangle in triangles)
            {
                Assert.Equal(3, triangle.Count);
                Assert.True(triangle.GetArea() > 0.0f);
            }
        }

        /// <summary>
        ///     Tests that Triangulate with a PointSet (Unconstrained mode) produces triangles via FinalizationConvexHull.
        /// </summary>
        [Fact]
        public void Triangulate_WithPointSet_ShouldProduceTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(1.0, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 1);
        }

        /// <summary>
        ///     Tests that Triangulate with a PointSet of 5 points produces a convex hull triangulation.
        /// </summary>
        [Fact]
        public void Triangulate_WithPointSet5Points_ShouldProduceConvexHullTriangulation()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 1.5),
                new TriangulationPoint(0.0, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 3);
        }

        /// <summary>
        ///     Tests that Triangulate with a ConstrainedPointSet produces triangles via the constrained edge path.
        /// </summary>
        [Fact]
        public void Triangulate_WithConstrainedPointSet_ShouldProduceTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(1.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 1);
        }

        /// <summary>
        ///     Tests that Triangulate with a 6-point constrained set hits edge event code.
        /// </summary>
        [Fact]
        public void Triangulate_WithConstrainedPointSet6Points_ShouldTriangulateWithEdgeEvents()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(0.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[3],
                points[1], points[4]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that Triangulate with an L-shaped polygon via CdtDecomposer produces multiple triangles.
        /// </summary>
        [Fact]
        public void DTSweep_TriangulatesLShape_ShouldProduceMultipleTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(3.0f, 0.0f),
                new Vector2F(3.0f, 1.0f),
                new Vector2F(1.0f, 1.0f),
                new Vector2F(1.0f, 2.0f),
                new Vector2F(0.0f, 2.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 2);
            foreach (Vertices triangle in triangles)
            {
                Assert.Equal(3, triangle.Count);
                Assert.True(triangle.GetArea() > 0.0f);
            }
        }
    }
}
