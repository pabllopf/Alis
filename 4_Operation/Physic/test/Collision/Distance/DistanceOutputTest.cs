// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceOutputTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    /// The distance output test class
    /// </summary>
    public class DistanceOutputTest
    {
        /// <summary>
        /// Tests that distance property test
        /// </summary>
        [Fact]
        public void DistancePropertyTest()
        {
            // Arrange
            DistanceOutput distanceOutput = new DistanceOutput();
            float distance = 1.0f;
            
            // Act
            distanceOutput.Distance = distance;
            
            // Assert
            Assert.Equal(distance, distanceOutput.Distance);
        }
        
        /// <summary>
        /// Tests that iterations property test
        /// </summary>
        [Fact]
        public void IterationsPropertyTest()
        {
            // Arrange
            DistanceOutput distanceOutput = new DistanceOutput();
            int iterations = 1;
            
            // Act
            distanceOutput.Iterations = iterations;
            
            // Assert
            Assert.Equal(iterations, distanceOutput.Iterations);
        }
        
        /// <summary>
        /// Tests that point a property test
        /// </summary>
        [Fact]
        public void PointAPropertyTest()
        {
            // Arrange
            DistanceOutput distanceOutput = new DistanceOutput();
            Vector2 pointA = new Vector2(1, 1);
            
            // Act
            distanceOutput.PointA = pointA;
            
            // Assert
            Assert.Equal(pointA, distanceOutput.PointA);
        }
        
        /// <summary>
        /// Tests that point b property test
        /// </summary>
        [Fact]
        public void PointBPropertyTest()
        {
            // Arrange
            DistanceOutput distanceOutput = new DistanceOutput();
            Vector2 pointB = new Vector2(1, 1);
            
            // Act
            distanceOutput.PointB = pointB;
            
            // Assert
            Assert.Equal(pointB, distanceOutput.PointB);
        }
    }
}