// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepBasinCoverageTests.cs
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

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep basin coverage tests class
    /// </summary>
    public class DTSweepBasinCoverageTests
    {
        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>The resulting triangle count</returns>
        private static int RunPointSet(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            return pointSet.GetTriangles.Count;
        }

        /// <summary>
        ///     Tests that a deep valley in the point set triggers the basin filling.
        /// </summary>
        [Fact]
        public void Triangulate_DeepValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(3.0, -1.0),
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(0.0, 3.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a wide valley in the point set triggers the recursive basin filling.
        /// </summary>
        [Fact]
        public void Triangulate_WideValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(4.0, -1.0),
                new TriangulationPoint(5.0, 1.0),
                new TriangulationPoint(6.0, 3.0),
                new TriangulationPoint(0.0, 3.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a shallow valley still completes triangulation.
        /// </summary>
        [Fact]
        public void Triangulate_ShallowValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(3.0, 0.5),
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(0.0, 1.5)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a staircase descending point set still completes triangulation.
        /// </summary>
        [Fact]
        public void Triangulate_DescendingStaircasePointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, -1.0),
                new TriangulationPoint(2.0, -2.0),
                new TriangulationPoint(3.0, -1.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(5.0, 2.0),
                new TriangulationPoint(0.0, 2.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a valley with a long descending run triggers the basin recursion.
        /// </summary>
        [Fact]
        public void Triangulate_LongDescendingRunPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, -1.0),
                new TriangulationPoint(2.0, -1.5),
                new TriangulationPoint(3.0, -2.0),
                new TriangulationPoint(4.0, -0.5),
                new TriangulationPoint(5.0, 1.0),
                new TriangulationPoint(6.0, 2.5),
                new TriangulationPoint(0.0, 3.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a symmetric valley point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_SymmetricValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, -2.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(4.0, 3.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a valley with a plateau at the bottom triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_PlateauValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, -1.0),
                new TriangulationPoint(3.0, -1.0),
                new TriangulationPoint(4.0, -0.5),
                new TriangulationPoint(5.0, 0.5),
                new TriangulationPoint(6.0, 2.0),
                new TriangulationPoint(0.0, 2.5)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 6);
        }
    }
}
