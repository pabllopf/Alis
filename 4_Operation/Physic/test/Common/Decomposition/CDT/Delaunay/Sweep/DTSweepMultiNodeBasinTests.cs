// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:DTSweepMultiNodeBasinTests.cs
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

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep multi node basin tests class
    /// </summary>
    public class DTSweepMultiNodeBasinTests
    {
        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        private static void RunPointSet(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that a valley with a steep right side triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_SteepRightSideValley_ProducesTriangles()
        {
            RunPointSet(new List<TriangulationPoint>
            {
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(2.2, 1.0),
                new TriangulationPoint(2.45, -1.0),
                new TriangulationPoint(2.6, -3.5),
                new TriangulationPoint(2.7, -6.0),
                new TriangulationPoint(2.9, -7.0),
                new TriangulationPoint(3.1, -6.0),
                new TriangulationPoint(3.4, -3.5),
                new TriangulationPoint(3.8, -1.0),
                new TriangulationPoint(4.3, 1.0),
                new TriangulationPoint(5.5, 2.0)
            });
        }

        /// <summary>
        ///     Tests that a valley with steep sides on both arms triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_SteepBothSidesValley_ProducesTriangles()
        {
            RunPointSet(new List<TriangulationPoint>
            {
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(2.3, 1.0),
                new TriangulationPoint(2.5, -1.0),
                new TriangulationPoint(2.6, -3.0),
                new TriangulationPoint(2.7, -5.0),
                new TriangulationPoint(3.0, -5.0),
                new TriangulationPoint(3.3, -3.0),
                new TriangulationPoint(3.6, -1.0),
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(5.0, 2.0)
            });
        }

        /// <summary>
        ///     Tests that a flat bottom valley with steep sides triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_FlatBottomValley_ProducesTriangles()
        {
            RunPointSet(new List<TriangulationPoint>
            {
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(2.3, 1.0),
                new TriangulationPoint(2.5, -1.0),
                new TriangulationPoint(2.7, -3.0),
                new TriangulationPoint(3.0, -4.0),
                new TriangulationPoint(3.4, -4.0),
                new TriangulationPoint(3.8, -3.0),
                new TriangulationPoint(4.1, -1.0),
                new TriangulationPoint(4.5, 1.0),
                new TriangulationPoint(5.5, 2.0)
            });
        }

        /// <summary>
        ///     Tests that a valley with an intermediate right flank triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_IntermediateRightFlankValley_ProducesTriangles()
        {
            RunPointSet(new List<TriangulationPoint>
            {
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(2.2, 1.0),
                new TriangulationPoint(2.45, -1.0),
                new TriangulationPoint(2.6, -3.5),
                new TriangulationPoint(2.7, -6.0),
                new TriangulationPoint(2.9, -7.0),
                new TriangulationPoint(3.1, -6.0),
                new TriangulationPoint(3.4, -3.5),
                new TriangulationPoint(3.8, -1.0),
                new TriangulationPoint(4.3, 1.0),
                new TriangulationPoint(5.0, 1.5),
                new TriangulationPoint(5.8, 2.5)
            });
        }

        /// <summary>
        ///     Tests that a convex descent valley triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_ConvexDescentValley_ProducesTriangles()
        {
            RunPointSet(new List<TriangulationPoint>
            {
                new TriangulationPoint(1.5, 3.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(2.2, 1.0),
                new TriangulationPoint(2.45, -1.0),
                new TriangulationPoint(2.6, -3.5),
                new TriangulationPoint(2.7, -6.0),
                new TriangulationPoint(2.9, -7.0),
                new TriangulationPoint(3.6, -6.8),
                new TriangulationPoint(4.4, -6.0),
                new TriangulationPoint(5.2, -4.8),
                new TriangulationPoint(6.0, -3.0),
                new TriangulationPoint(8.0, 0.0)
            });
        }
    }
}