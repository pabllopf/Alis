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
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Sets
{
    /// <summary>
    /// The point set test class
    /// </summary>
    public class PointSetTest
    {
        /// <summary>
        /// Tests that point set type should be accessible
        /// </summary>
        [Fact]
        public void PointSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PointSet));
        }

        /// <summary>
        /// Tests that constructor with points should set points
        /// </summary>
        [Fact]
        public void Constructor_WithPoints_ShouldSetPoints()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.0, 1.0)
            };
            PointSet pointSet = new PointSet(points);

            Assert.Equal(3, pointSet.GetPoints.Count);
        }

        /// <summary>
        /// Tests that triangulation mode should be unconstrained
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldBeUnconstrained()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0)
            };
            PointSet pointSet = new PointSet(points);

            Assert.Equal(TriangulationMode.Unconstrained, pointSet.TriangulationMode);
        }

        /// <summary>
        /// Tests that add triangle should add to triangles list
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldAddToTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.0, 1.0)
            };
            PointSet pointSet = new PointSet(points);

            DelaunayTriangle triangle = new DelaunayTriangle(points[0], points[1], points[2]);
            pointSet.AddTriangle(triangle);

            Assert.Contains(triangle, pointSet.GetTriangles);
        }
    }
}
