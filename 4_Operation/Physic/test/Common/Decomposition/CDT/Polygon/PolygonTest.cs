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
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using PolygonPolygon = Alis.Core.Physic.Common.Decomposition.CDT.Polygon.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    /// The polygon test class
    /// </summary>
    public class PolygonTest
    {
        /// <summary>
        /// Tests that polygon type should be accessible
        /// </summary>
        [Fact]
        public void Polygon_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PolygonPolygon));
        }

        /// <summary>
        /// Tests that constructor with points should set points
        /// </summary>
        [Fact]
        public void Constructor_WithPoints_ShouldSetPoints()
        {
            List<PolygonPoint> points = new List<PolygonPoint>
            {
                new PolygonPoint(0.0, 0.0),
                new PolygonPoint(1.0, 0.0),
                new PolygonPoint(0.0, 1.0)
            };
            PolygonPolygon polygon = new PolygonPolygon(points);

            Assert.Equal(3, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that triangulation mode should be polygon
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldBePolygon()
        {
            List<PolygonPoint> points = new List<PolygonPoint>
            {
                new PolygonPoint(0.0, 0.0),
                new PolygonPoint(1.0, 0.0),
                new PolygonPoint(0.0, 1.0)
            };
            PolygonPolygon polygon = new PolygonPolygon(points);

            Assert.Equal(TriangulationMode.Polygon, polygon.TriangulationMode);
        }

        /// <summary>
        /// Tests that add triangle should add to triangles list
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldAddToTriangles()
        {
            List<PolygonPoint> points = new List<PolygonPoint>
            {
                new PolygonPoint(0.0, 0.0),
                new PolygonPoint(1.0, 0.0),
                new PolygonPoint(0.0, 1.0)
            };
            PolygonPolygon polygon = new PolygonPolygon(points);

            TriangulationPoint tp1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint tp2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint tp3 = new TriangulationPoint(0.0, 1.0);
            DelaunayTriangle triangle = new DelaunayTriangle(tp1, tp2, tp3);

            polygon.AddTriangle(triangle);

            Assert.Contains(triangle, polygon.GetTriangles);
        }
    }
}
