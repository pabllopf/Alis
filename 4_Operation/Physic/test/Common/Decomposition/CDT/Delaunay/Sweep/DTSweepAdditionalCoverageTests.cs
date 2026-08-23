// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepAdditionalCoverageTests.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep additional coverage tests class
    /// </summary>
    public class DTSweepAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that triangulate with interior point set produces triangles
        /// </summary>
        [Fact]
        public void Triangulate_WithInteriorPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(2.0, 2.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that triangulate with concave point set produces triangles
        /// </summary>
        [Fact]
        public void Triangulate_WithConcavePointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 1.5),
                new TriangulationPoint(1.5, 1.5),
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.0, 3.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that triangulate with crossing constrained edges produces triangles
        /// </summary>
        [Fact]
        public void Triangulate_WithCrossingConstrainedEdges_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[0], points[4],
                points[4], points[5],
                points[5], points[1]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.True(constrainedPS.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that triangulate with star shaped point set produces triangles
        /// </summary>
        [Fact]
        public void Triangulate_WithStarShapedPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(2.5, 2.5),
                new TriangulationPoint(0.5, 2.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.5, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 4);
        }
    }
}
