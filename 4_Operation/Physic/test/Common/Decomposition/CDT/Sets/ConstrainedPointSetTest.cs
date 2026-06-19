// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstrainedPointSetTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Sets
{
    /// <summary>
    /// The constrained point set test class
    /// </summary>
    public class ConstrainedPointSetTest
    {
        /// <summary>
        /// Tests that constrained point set type should be accessible
        /// </summary>
        [Fact]
        public void ConstrainedPointSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(ConstrainedPointSet));
        }

        /// <summary>
        /// Tests that constructor with points and indices should set edge index
        /// </summary>
        [Fact]
        public void Constructor_WithPointsAndIndices_ShouldSetEdgeIndex()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.0, 1.0)
            };
            int[] indices = { 0, 1 };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, indices);

            Assert.NotNull(cps.EdgeIndex);
            Assert.Equal(2, cps.EdgeIndex.Length);
        }

        /// <summary>
        /// Tests that triangulation mode should be constrained
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldBeConstrained()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0)
            };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, new int[0]);

            Assert.Equal(TriangulationMode.Constrained, cps.TriangulationMode);
        }

        /// <summary>
        /// Tests that constructor with constraints enumerable should set triangulation mode
        /// </summary>
        [Fact]
        public void Constructor_WithConstraintsEnumerable_ShouldSetTriangulationMode()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0)
            };
            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0],
                points[1],
                points[1],
                points[2]
            };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);

            Assert.Equal(TriangulationMode.Constrained, cps.TriangulationMode);
        }

        /// <summary>
        /// Tests that PrepareTriangulation with constraints enumerable adds points to context
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithConstraintsEnumerable_ShouldAddPointsToContext()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0)
            };
            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0],
                points[1],
                points[1],
                points[2]
            };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();

            cps.PrepareTriangulation(tcx);

            Assert.Equal(points.Count, tcx.Points.Count);
        }

        /// <summary>
        /// Tests that PrepareTriangulation with edge index adds points to context
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithEdgeIndex_ShouldAddPointsToContext()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0)
            };
            int[] indices = { 0, 1, 1, 2 };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, indices);
            DtSweepContext tcx = new DtSweepContext();

            cps.PrepareTriangulation(tcx);

            Assert.Equal(points.Count, tcx.Points.Count);
        }

        /// <summary>
        /// Tests that PrepareTriangulation with empty constraints list does not crash
        /// </summary>
        [Fact]
        public void PrepareTriangulation_EmptyConstraintsList_ShouldNotCrash()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0)
            };
            List<TriangulationPoint> constraints = new List<TriangulationPoint>();
            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();

            cps.PrepareTriangulation(tcx);

            Assert.Equal(points.Count, tcx.Points.Count);
        }

        /// <summary>
        /// Tests that PrepareTriangulation with null constraints list does not crash
        /// </summary>
        [Fact]
        public void PrepareTriangulation_NullConstraintsList_ShouldUseEdgeIndex()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0)
            };
            int[] indices = { 0, 1, 1, 2 };
            ConstrainedPointSet cps = new ConstrainedPointSet(points, indices);
            DtSweepContext tcx = new DtSweepContext();

            cps.PrepareTriangulation(tcx);

            Assert.Equal(points.Count, tcx.Points.Count);
        }
    }
}
