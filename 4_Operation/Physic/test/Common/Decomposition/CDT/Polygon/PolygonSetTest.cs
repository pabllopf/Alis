// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonSetTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using PolygonPolygon = Alis.Core.Physic.Common.Decomposition.CDT.Polygon.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    /// The polygon set test class
    /// </summary>
    public class PolygonSetTest
    {
        /// <summary>
        /// Tests that polygon set type should be accessible
        /// </summary>
        [Fact]
        public void PolygonSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PolygonSet));
        }

        /// <summary>
        /// Tests that default constructor should create empty set
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateEmptySet()
        {
            PolygonSet polySet = new PolygonSet();

            Assert.NotNull(polySet);
        }

        /// <summary>
        /// Tests that constructor with polygon should add it
        /// </summary>
        [Fact]
        public void Constructor_WithPolygon_ShouldAddIt()
        {
            List<PolygonPoint> points = new List<PolygonPoint>
            {
                new PolygonPoint(0.0, 0.0),
                new PolygonPoint(1.0, 0.0),
                new PolygonPoint(0.0, 1.0)
            };
            PolygonPolygon polygon = new PolygonPolygon(points);
            PolygonSet polySet = new PolygonSet(polygon);

            Assert.Contains(polygon, polySet.GetPolygons);
        }

        /// <summary>
        /// Tests that add should add polygon to set
        /// </summary>
        [Fact]
        public void Add_ShouldAddPolygonToSet()
        {
            List<PolygonPoint> points = new List<PolygonPoint>
            {
                new PolygonPoint(0.0, 0.0),
                new PolygonPoint(1.0, 0.0),
                new PolygonPoint(0.0, 1.0)
            };
            PolygonPolygon polygon = new PolygonPolygon(points);
            PolygonSet polySet = new PolygonSet();
            polySet.Add(polygon);

            Assert.Contains(polygon, polySet.GetPolygons);
        }
    }
}
