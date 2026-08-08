// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonRemainingCoverageTests.cs
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
using System.Linq;
using Alis.Core.Physic.Common.Decomposition.CDT;
using CDP = Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    /// The polygon remaining coverage tests class
    /// </summary>
    public class PolygonRemainingCoverageTests
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
        /// Tests that constructor with non i list i enumerable should create polygon
        /// </summary>
        [Fact]
        public void Constructor_WithNonIListIEnumerable_ShouldCreatePolygon()
        {
            IEnumerable<CDP.PolygonPoint> points = CreateTrianglePoints().Where(p => true);

            CDP.Polygon polygon = new CDP.Polygon(points);

            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that add steiner point when already initialized should add second point
        /// </summary>
        [Fact]
        public void AddSteinerPoint_WhenAlreadyInitialized_ShouldAddSecondPoint()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            TriangulationPoint first = new TriangulationPoint(0.5, 0.5);
            TriangulationPoint second = new TriangulationPoint(0.7, 0.7);

            polygon.AddSteinerPoint(first);
            polygon.AddSteinerPoint(second);

            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);
            Assert.Equal(5, tcx.Points.Count);
        }

        /// <summary>
        /// Tests that add steiner points when already initialized should add more points
        /// </summary>
        [Fact]
        public void AddSteinerPoints_WhenAlreadyInitialized_ShouldAddMorePoints()
        {
            List<CDP.PolygonPoint> pts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(pts);
            TriangulationPoint first = new TriangulationPoint(0.5, 0.5);
            polygon.AddSteinerPoint(first);

            List<TriangulationPoint> more = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.2, 0.2),
                new TriangulationPoint(0.8, 0.8)
            };
            polygon.AddSteinerPoints(more);

            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);
            Assert.Equal(6, tcx.Points.Count);
        }

        /// <summary>
        /// Tests that add hole multiple holes should add all holes
        /// </summary>
        [Fact]
        public void AddHole_MultipleHoles_ShouldAddAllHoles()
        {
            List<CDP.PolygonPoint> outerPts = CreateTrianglePoints();
            CDP.Polygon polygon = new CDP.Polygon(outerPts);

            List<CDP.PolygonPoint> holePts1 = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0.2, 0.2),
                new CDP.PolygonPoint(0.4, 0.2),
                new CDP.PolygonPoint(0.3, 0.4)
            };
            CDP.Polygon hole1 = new CDP.Polygon(holePts1);
            polygon.AddHole(hole1);

            List<CDP.PolygonPoint> holePts2 = new List<CDP.PolygonPoint>
            {
                new CDP.PolygonPoint(0.6, 0.6),
                new CDP.PolygonPoint(0.8, 0.6),
                new CDP.PolygonPoint(0.7, 0.8)
            };
            CDP.Polygon hole2 = new CDP.Polygon(holePts2);
            polygon.AddHole(hole2);

            Assert.NotNull(polygon.GetHoles);
            Assert.Equal(2, polygon.GetHoles.Count);
        }

        /// <summary>
        /// Tests that prepare triangulation with holes and steiner points should process both
        /// </summary>
        [Fact]
        public void PrepareTriangulation_WithHolesAndSteinerPoints_ShouldProcessBoth()
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

            TriangulationPoint steiner = new TriangulationPoint(0.5, 0.5);
            polygon.AddSteinerPoint(steiner);

            TestTriangulationContext tcx = new TestTriangulationContext();
            polygon.PrepareTriangulation(tcx);

            Assert.Equal(7, tcx.Points.Count);
            Assert.Equal(6, tcx.Constraints.Count);
        }
    }
}
