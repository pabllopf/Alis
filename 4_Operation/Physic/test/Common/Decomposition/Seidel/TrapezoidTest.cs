// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TrapezoidTest.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The trapezoid test class
    /// </summary>
    public class TrapezoidTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with all parameters
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithAllParameters()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Point topP = new Point(0, 10);
            Point topQ = new Point(10, 10);
            Point bottomP = new Point(0, -10);
            Point bottomQ = new Point(10, -10);
            Edge top = new Edge(topP, topQ);
            Edge bottom = new Edge(bottomP, bottomQ);
            
            Trapezoid trapezoid = new Trapezoid(leftPoint, rightPoint, top, bottom);
            
            Assert.Equal(leftPoint, trapezoid.LeftPoint);
            Assert.Equal(rightPoint, trapezoid.RightPoint);
            Assert.Equal(top, trapezoid.Top);
            Assert.Equal(bottom, trapezoid.Bottom);
            Assert.True(trapezoid.Inside);
        }

        /// <summary>
        ///     Tests that constructor should initialize neighbors to null
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeNeighborsToNull()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            
            Trapezoid trapezoid = new Trapezoid(leftPoint, rightPoint, top, bottom);
            
            Assert.Null(trapezoid.UpperLeft);
            Assert.Null(trapezoid.UpperRight);
            Assert.Null(trapezoid.LowerLeft);
            Assert.Null(trapezoid.LowerRight);
            Assert.Null(trapezoid.Sink);
        }

        /// <summary>
        ///     Tests that update left should set left neighbors correctly
        /// </summary>
        [Fact]
        public void UpdateLeft_ShouldSetLeftNeighborsCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Trapezoid upperLeft = CreateTestTrapezoid();
            Trapezoid lowerLeft = CreateTestTrapezoid();
            
            trapezoid.UpdateLeft(upperLeft, lowerLeft);
            
            Assert.Equal(upperLeft, trapezoid.UpperLeft);
            Assert.Equal(lowerLeft, trapezoid.LowerLeft);
            Assert.Equal(trapezoid, upperLeft.UpperRight);
            Assert.Equal(trapezoid, lowerLeft.LowerRight);
        }

        /// <summary>
        ///     Tests that update right should set right neighbors correctly
        /// </summary>
        [Fact]
        public void UpdateRight_ShouldSetRightNeighborsCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Trapezoid upperRight = CreateTestTrapezoid();
            Trapezoid lowerRight = CreateTestTrapezoid();
            
            trapezoid.UpdateRight(upperRight, lowerRight);
            
            Assert.Equal(upperRight, trapezoid.UpperRight);
            Assert.Equal(lowerRight, trapezoid.LowerRight);
            Assert.Equal(trapezoid, upperRight.UpperLeft);
            Assert.Equal(trapezoid, lowerRight.LowerLeft);
        }

        /// <summary>
        ///     Tests that update left with null should not throw exception
        /// </summary>
        [Fact]
        public void UpdateLeft_WithNull_ShouldNotThrowException()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            trapezoid.UpdateLeft(null, null);
            
            Assert.Null(trapezoid.UpperLeft);
            Assert.Null(trapezoid.LowerLeft);
        }

        /// <summary>
        ///     Tests that update right with null should not throw exception
        /// </summary>
        [Fact]
        public void UpdateRight_WithNull_ShouldNotThrowException()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            trapezoid.UpdateRight(null, null);
            
            Assert.Null(trapezoid.UpperRight);
            Assert.Null(trapezoid.LowerRight);
        }

        /// <summary>
        ///     Tests that inside property should default to true
        /// </summary>
        [Fact]
        public void InsideProperty_ShouldDefaultToTrue()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            Assert.True(trapezoid.Inside);
        }

        /// <summary>
        ///     Tests that inside property should set and get correctly
        /// </summary>
        [Fact]
        public void InsideProperty_ShouldSetAndGetCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            trapezoid.Inside = false;
            
            Assert.False(trapezoid.Inside);
        }
        

        /// <summary>
        ///     Tests that right point property should set and get correctly
        /// </summary>
        [Fact]
        public void RightPointProperty_ShouldSetAndGetCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Point newRightPoint = new Point(20, 0);
            
            trapezoid.RightPoint = newRightPoint;
            
            Assert.Equal(newRightPoint, trapezoid.RightPoint);
        }

        /// <summary>
        ///     Creates the test trapezoid
        /// </summary>
        /// <returns>The trapezoid</returns>
        private Trapezoid CreateTestTrapezoid()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            return new Trapezoid(leftPoint, rightPoint, top, bottom);
        }
    }
}

