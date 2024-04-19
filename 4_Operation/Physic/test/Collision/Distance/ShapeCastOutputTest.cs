// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeCastOutputTest.cs
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
    /// The shape cast output test class
    /// </summary>
    public class ShapeCastOutputTest
    {
        /// <summary>
        /// Tests that point property test
        /// </summary>
        [Fact]
        public void PointPropertyTest()
        {
            // Arrange
            ShapeCastOutput shapeCastOutput = new ShapeCastOutput();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            shapeCastOutput.Point = point;
            
            // Assert
            Assert.Equal(point, shapeCastOutput.Point);
        }
        
        /// <summary>
        /// Tests that normal property test
        /// </summary>
        [Fact]
        public void NormalPropertyTest()
        {
            // Arrange
            ShapeCastOutput shapeCastOutput = new ShapeCastOutput();
            Vector2 normal = new Vector2(1, 1);
            
            // Act
            shapeCastOutput.Normal = normal;
            
            // Assert
            Assert.Equal(normal, shapeCastOutput.Normal);
        }
        
        /// <summary>
        /// Tests that lambda property test
        /// </summary>
        [Fact]
        public void LambdaPropertyTest()
        {
            // Arrange
            ShapeCastOutput shapeCastOutput = new ShapeCastOutput();
            float lambda = 1.0f;
            
            // Act
            shapeCastOutput.Lambda = lambda;
            
            // Assert
            Assert.Equal(lambda, shapeCastOutput.Lambda);
        }
        
        /// <summary>
        /// Tests that iterations property test
        /// </summary>
        [Fact]
        public void IterationsPropertyTest()
        {
            // Arrange
            ShapeCastOutput shapeCastOutput = new ShapeCastOutput();
            int iterations = 1;
            
            // Act
            shapeCastOutput.Iterations = iterations;
            
            // Assert
            Assert.Equal(iterations, shapeCastOutput.Iterations);
        }
    }
}