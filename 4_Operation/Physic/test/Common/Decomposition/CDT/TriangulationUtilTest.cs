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

        /// <summary>
        /// Tests that Orient2d with clockwise points should return clockwise.
        /// </summary>
        [Fact]
        public void Orient2d_WithClockwisePoints_ShouldReturnClockwise()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, 0.0);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Cw, result);
        }

        /// <summary>
        /// Tests that SmartIncircle returns true when point is inside the circle.
        /// </summary>
        [Fact]
        public void SmartIncircle_WithPointInsideCircle_ReturnsTrue()
        {
            TriangulationPoint pa = new TriangulationPoint(-1.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, 1.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that SmartIncircle returns false when point is on the circle edge.
        /// </summary>
        [Fact]
        public void SmartIncircle_WithPointOnEdge_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(-1.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pd = new TriangulationPoint(0.5, 0.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that SmartIncircle returns false when oabd <= 0.
        /// </summary>
        [Fact]
        public void SmartIncircle_WhenOabdNonPositive_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pd = new TriangulationPoint(2.0, 2.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that SmartIncircle returns false when ocad <= 0.
        /// </summary>
        [Fact]
        public void SmartIncircle_WhenOcadNonPositive_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -0.5);
            TriangulationPoint pd = new TriangulationPoint(1.0, 1.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that InScanArea returns true when point is in scan area.
        /// </summary>
        [Fact]
        public void InScanArea_WithPointInside_ReturnsTrue()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(0.5, 0.5);

            bool result = TriangulationUtil.InScanArea(pa, pb, pc, pd);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that InScanArea returns false when point is outside.
        /// </summary>
        [Fact]
        public void InScanArea_WithPointOutside_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(-1.0, -1.0);

            bool result = TriangulationUtil.InScanArea(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that InScanArea returns false when the second check (oadc) fails.
        /// </summary>
        [Fact]
        public void InScanArea_WhenOadcFails_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(4.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 4.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, 2.0);

            bool result = TriangulationUtil.InScanArea(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that SmartIncircle returns true when det > 0 (inside circumcircle).
        /// </summary>
        [Fact]
        public void SmartIncircle_DetGreaterThanZero_ReturnsTrue()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(1.0, 0.5);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that SmartIncircle returns false when det <= 0 (on/outside circumcircle).
        /// </summary>
        [Fact]
        public void SmartIncircle_DetNonPositive_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(1.0, 3.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }
    }
}
