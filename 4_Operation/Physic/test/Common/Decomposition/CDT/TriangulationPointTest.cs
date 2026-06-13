// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationPointTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation point test class
    /// </summary>
    public class TriangulationPointTest
    {
        /// <summary>
        /// Tests that constructor should set x and y
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetXAndY()
        {
            TriangulationPoint point = new TriangulationPoint(1.5, 2.5);

            Assert.Equal(1.5, point.X);
            Assert.Equal(2.5, point.Y);
        }

        /// <summary>
        /// Tests that xf should convert to float
        /// </summary>
        [Fact]
        public void Xf_ShouldConvertToFloat()
        {
            TriangulationPoint point = new TriangulationPoint(3.14, 0.0);

            Assert.Equal(3.14f, point.Xf);
        }

        /// <summary>
        /// Tests that yf should convert to float
        /// </summary>
        [Fact]
        public void Yf_ShouldConvertToFloat()
        {
            TriangulationPoint point = new TriangulationPoint(0.0, 2.71);

            Assert.Equal(2.71f, point.Yf);
        }

        /// <summary>
        /// Tests that has edges should be false initially
        /// </summary>
        [Fact]
        public void HasEdges_ShouldBeFalseInitially()
        {
            TriangulationPoint point = new TriangulationPoint(0.0, 0.0);

            Assert.False(point.HasEdges);
        }

        /// <summary>
        /// Tests that add edge should initialize edges list
        /// </summary>
        [Fact]
        public void AddEdge_ShouldInitializeEdgesList()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            DtSweepConstraint edge = new DtSweepConstraint(p1, p2);

            p1.AddEdge(edge);

            Assert.True(p1.HasEdges);
        }

        /// <summary>
        /// Tests that to string should return formatted value
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnFormattedValue()
        {
            TriangulationPoint point = new TriangulationPoint(1.0, 2.0);

            Assert.Equal("[1,2]", point.ToString());
        }
    }
}
