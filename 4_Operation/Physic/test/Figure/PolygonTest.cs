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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Figure
{
    /// <summary>
    ///     The polygon test class
    /// </summary>
    public class PolygonTest
    {
        /// <summary>
        ///     Tests that create rectangle test
        /// </summary>
        [Fact]
        public void CreateRectangleTest()
        {
            // Arrange
            float hx = 1.0f;
            float hy = 2.0f;
            
            // Act
            Vertices result = Polygon.CreateRectangle(hx, hy);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create rounded rectangle test
        /// </summary>
        [Fact]
        public void CreateRoundedRectangleTest()
        {
            // Arrange
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 1.0f;
            float yRadius = 1.0f;
            int segments = 4;
            
            // Act
            Vertices result = Polygon.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);
            
            // Assert
            Assert.Equal(24, result.Count);
        }
        
        /// <summary>
        ///     Tests that create line test
        /// </summary>
        [Fact]
        public void CreateLineTest()
        {
            // Arrange
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 1);
            
            // Act
            Vertices result = Polygon.CreateLine(start, end);
            
            // Assert
            Assert.Equal(2, result.Count);
        }
        
        /// <summary>
        ///     Tests that create circle test
        /// </summary>
        [Fact]
        public void CreateCircleTest()
        {
            // Arrange
            float radius = 1.0f;
            int numberOfEdges = 4;
            
            // Act
            Vertices result = Polygon.CreateCircle(radius, numberOfEdges);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create ellipse test
        /// </summary>
        [Fact]
        public void CreateEllipseTest()
        {
            // Arrange
            float xRadius = 1.0f;
            float yRadius = 2.0f;
            int numberOfEdges = 4;
            
            // Act
            Vertices result = Polygon.CreateEllipse(xRadius, yRadius, numberOfEdges);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create arc test
        /// </summary>
        [Fact]
        public void CreateArcTest()
        {
            // Arrange
            float radians = (float) Math.PI / 2; // 90 degrees
            int sides = 4;
            float radius = 1.0f;
            
            // Act
            Vertices result = Polygon.CreateArc(radians, sides, radius);
            
            // Assert
            Assert.Equal(3, result.Count);
        }
        
        /// <summary>
        ///     Tests that create capsule test
        /// </summary>
        [Fact]
        public void CreateCapsuleTest()
        {
            // Arrange
            float height = 2.0f;
            float endRadius = 0.5f;
            int edges = 4;
            
            // Act
            Vertices result = Polygon.CreateCapsule(height, endRadius, edges);
            
            // Assert
            Assert.Equal(10, result.Count);
        }
        
        /// <summary>
        ///     Tests that create gear test
        /// </summary>
        [Fact]
        public void CreateGearTest()
        {
            // Arrange
            float radius = 1.0f;
            int numberOfTeeth = 4;
            float tipPercentage = 25.0f;
            float toothHeight = 0.1f;
            
            // Act
            Vertices result = Polygon.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight);
            
            // Assert
            Assert.Equal(16, result.Count);
        }
    }
}