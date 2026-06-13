// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationUtilTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation util test class
    /// </summary>
    public class TriangulationUtilTest
    {
        /// <summary>
        /// Tests that triangulation util type should be accessible
        /// </summary>
        [Fact]
        public void TriangulationUtil_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(TriangulationUtil));
        }

        /// <summary>
        /// Tests that orient 2d should return counter clockwise for ccw points
        /// </summary>
        [Fact]
        public void Orient2d_WithCounterClockwisePoints_ShouldReturnCounterClockwise()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 1.0);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Ccw, result);
        }

        /// <summary>
        /// Tests that orient 2d with collinear points should return collinear
        /// </summary>
        [Fact]
        public void Orient2d_WithCollinearPoints_ShouldReturnCollinear()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 1.0);
            TriangulationPoint pc = new TriangulationPoint(2.0, 2.0);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Collinear, result);
        }
    }
}
