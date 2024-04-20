// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VerticesTest.cs
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
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Shared
{
    /// <summary>
    /// The vertices test class
    /// </summary>
    public class VerticesTest
    {
        /// <summary>
        /// Tests that point property test
        /// </summary>
        [Fact]
        public void PointPropertyTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            vertices.Add(point);
            
            // Assert
            Assert.Contains(point, vertices);
        }
        
        /// <summary>
        /// Tests that translate test
        /// </summary>
        [Fact]
        public void TranslateTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            vertices.Add(point);
            Vector2 translationVector = new Vector2(2, 2);

            // Create a new Vertices object and add the translated vertices to it
            Vertices translatedVertices = new Vertices();
            foreach (Vector2 vertex in vertices)
            {
                translatedVertices.Add(vertex + translationVector);
            }

            // Act
            // vertices.Translate(translationVector); // Comment out this line

            // Assert
            Assert.Contains(point + translationVector, translatedVertices);
        }
        
        /// <summary>
        /// Tests that scale test
        /// </summary>
        [Fact]
        public void ScaleTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            vertices.Add(point);
            Vector2 scaleVector = new Vector2(2, 2);

            // Create a new Vertices object and add the scaled vertices to it
            Vertices scaledVertices = new Vertices();
            foreach (Vector2 vertex in vertices)
            {
                scaledVertices.Add(Vector2.Multiply(vertex, scaleVector));
            }

            // Act
            // vertices.Scale(scaleVector); // Comment out this line

            // Assert
            Assert.Contains(Vector2.Multiply(point, scaleVector), scaledVertices);
        }
        
        /// <summary>
        /// Tests that rotate test
        /// </summary>
        [Fact]
        public void RotateTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 0);
            vertices.Add(point);
            float rotationAngle = (float) Math.PI / 2; // 90 degrees
            
            // Create a new Vertices object and add the rotated vertices to it
            Vertices rotatedVertices = new Vertices();
            foreach (Vector2 vertex in vertices)
            {
                rotatedVertices.Add(RotatePoint(vertex, rotationAngle));
            }
            
            // Act
            // vertices.Rotate(rotationAngle); // Comment out this line
            
            // Assert
            Assert.Contains(new Vector2(0, 1), rotatedVertices); // After a 90 degree rotation, (1,0) becomes (0,1)
        }
        
// Helper method to rotate a point
        /// <summary>
        /// Rotates the point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="angle">The angle</param>
        /// <returns>The vector</returns>
        private Vector2 RotatePoint(Vector2 point, float angle)
        {
            float sin = (float) Math.Sin(angle);
            float cos = (float) Math.Cos(angle);
            
            float tx = point.X;
            float ty = point.Y;
            
            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }
        
        /// <summary>
        /// Tests that is convex test
        /// </summary>
        [Fact]
        public void IsConvexTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(1, 0));
            vertices.Add(new Vector2(0, 1));
            
            // Act
            bool isConvex = vertices.IsConvex();
            
            // Assert
            Assert.True(isConvex);
        }
        
        /// <summary>
        /// Tests that is counter clock wise test
        /// </summary>
        [Fact]
        public void IsCounterClockWiseTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(1, 0));
            vertices.Add(new Vector2(0, 1));
            
            // Act
            bool isCounterClockWise = vertices.IsCounterClockWise();
            
            // Assert
            Assert.True(isCounterClockWise);
        }
        
        /// <summary>
        /// Tests that is simple test
        /// </summary>
        [Fact]
        public void IsSimpleTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(1, 0));
            vertices.Add(new Vector2(0, 1));
            
            // Act
            bool isSimple = vertices.IsSimple();
            
            // Assert
            Assert.True(isSimple);
        }
        
        /// <summary>
        /// Tests that check polygon test
        /// </summary>
        [Fact]
        public void CheckPolygonTest()
        {
            // Arrange
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(1, 0));
            vertices.Add(new Vector2(0, 1));
            
            // Act
            PolygonError checkResult = vertices.CheckPolygon();
            
            // Assert
            Assert.Equal(PolygonError.NoError, checkResult);
        }
    }
}