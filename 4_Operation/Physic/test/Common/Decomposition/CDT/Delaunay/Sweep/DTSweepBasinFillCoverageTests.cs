// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:DTSweepBasinFillCoverageTests.cs
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
    ///     The dt sweep basin fill coverage tests class
    /// </summary>
    public class DTSweepBasinFillCoverageTests
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
            Assert.True(pointSet.GetTriangles.Count >= 3);
            return pointSet.GetTriangles.Count;
        }

        /// <summary>
        ///     Tests that a steep V valley with the new point at the top left triggers the recursive basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_SteepVBasin_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.1, 1.0),
                new TriangulationPoint(0.1, 0.9),
                new TriangulationPoint(1.5, -3.0),
                new TriangulationPoint(1.8, -4.0),
                new TriangulationPoint(2.1, -5.0),
                new TriangulationPoint(2.4, -6.0),
                new TriangulationPoint(2.8, -4.0),
                new TriangulationPoint(3.2, -2.0),
                new TriangulationPoint(3.6, -0.5),
                new TriangulationPoint(4.0, 0.8),
                new TriangulationPoint(4.5, 0.9)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a deeper asymmetric basin triggers the recursive basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_DeepAsymmetricBasin_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.2, 1.0),
                new TriangulationPoint(0.2, 0.8),
                new TriangulationPoint(1.6, -3.0),
                new TriangulationPoint(1.9, -4.5),
                new TriangulationPoint(2.2, -6.0),
                new TriangulationPoint(2.5, -7.0),
                new TriangulationPoint(2.9, -5.0),
                new TriangulationPoint(3.3, -3.0),
                new TriangulationPoint(3.8, -1.0),
                new TriangulationPoint(4.3, 0.8)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a basin with a long ascending right arm triggers the recursive basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_BasinWithLongRightArm_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.1, 1.0),
                new TriangulationPoint(0.1, 0.7),
                new TriangulationPoint(1.5, -3.0),
                new TriangulationPoint(1.8, -4.5),
                new TriangulationPoint(2.1, -6.0),
                new TriangulationPoint(2.4, -6.5),
                new TriangulationPoint(2.7, -5.0),
                new TriangulationPoint(3.0, -3.5),
                new TriangulationPoint(3.3, -2.0),
                new TriangulationPoint(3.6, -0.5),
                new TriangulationPoint(3.9, 0.5),
                new TriangulationPoint(4.2, 0.9),
                new TriangulationPoint(4.6, 0.9)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 10);
        }
    }
}