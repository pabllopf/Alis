// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DtSweepConstraintTest.cs
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

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep constraint test class
    /// </summary>
    public class DtSweepConstraintTest
    {
        /// <summary>
        ///     Tests that constructor should order points by y coordinate
        /// </summary>
        [Fact]
        public void Constructor_ShouldOrderPointsByYCoordinate()
        {
            TriangulationPoint p1 = new TriangulationPoint(5, 10);
            TriangulationPoint p2 = new TriangulationPoint(5, 5);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.Equal(p2, constraint.P);
            Assert.Equal(p1, constraint.Q);
        }

        /// <summary>
        ///     Tests that constructor should order points by x when y equal
        /// </summary>
        [Fact]
        public void Constructor_ShouldOrderPointsByX_WhenYEqual()
        {
            TriangulationPoint p1 = new TriangulationPoint(10, 5);
            TriangulationPoint p2 = new TriangulationPoint(5, 5);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.Equal(p2, constraint.P);
            Assert.Equal(p1, constraint.Q);
        }

        /// <summary>
        ///     Tests that constructor should keep order when p1 y less than p2 y
        /// </summary>
        [Fact]
        public void Constructor_ShouldKeepOrder_WhenP1YLessThanP2Y()
        {
            TriangulationPoint p1 = new TriangulationPoint(5, 5);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.Equal(p1, constraint.P);
            Assert.Equal(p2, constraint.Q);
        }

        /// <summary>
        ///     Tests that dt sweep constraint should inherit from triangulation constraint
        /// </summary>
        [Fact]
        public void DtSweepConstraint_ShouldInheritFromTriangulationConstraint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.IsAssignableFrom<TriangulationConstraint>(constraint);
        }

        /// <summary>
        ///     Tests that constructor should handle points with same coordinates
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandlePointsWithSameCoordinates()
        {
            TriangulationPoint p1 = new TriangulationPoint(5, 5);
            TriangulationPoint p2 = new TriangulationPoint(5, 5);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.NotNull(constraint);
        }

        /// <summary>
        ///     Tests that constructor should handle vertical line
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleVerticalLine()
        {
            TriangulationPoint p1 = new TriangulationPoint(5, 0);
            TriangulationPoint p2 = new TriangulationPoint(5, 10);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.Equal(0, constraint.P.Y);
            Assert.Equal(10, constraint.Q.Y);
        }

        /// <summary>
        ///     Tests that constructor should handle horizontal line
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleHorizontalLine()
        {
            TriangulationPoint p1 = new TriangulationPoint(0, 5);
            TriangulationPoint p2 = new TriangulationPoint(10, 5);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.Equal(0, constraint.P.X);
            Assert.Equal(10, constraint.Q.X);
        }

        /// <summary>
        ///     Tests that constructor should handle negative coordinates
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleNegativeCoordinates()
        {
            TriangulationPoint p1 = new TriangulationPoint(-10, -5);
            TriangulationPoint p2 = new TriangulationPoint(-5, -10);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.NotNull(constraint);
        }

        /// <summary>
        ///     Tests that constructor should add edge to q point
        /// </summary>
        [Fact]
        public void Constructor_ShouldAddEdgeToQPoint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);
            
            Assert.NotNull(constraint.Q);
        }

        /// <summary>
        ///     Tests that dt sweep constraint should be reference type
        /// </summary>
        [Fact]
        public void DtSweepConstraint_ShouldBeReferenceType()
        {
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            DtSweepConstraint constraint1 = new DtSweepConstraint(p1, p2);
            DtSweepConstraint constraint2 = constraint1;
            
            Assert.Same(constraint1, constraint2);
        }
    }
}

