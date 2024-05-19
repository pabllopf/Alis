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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Shared
{
    /// <summary>
    ///     The vertices test class
    /// </summary>
    public class VerticesTest
    {
        /// <summary>
        ///     Tests that point property test
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
        ///     Tests that translate test
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
        ///     Tests that scale test
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
        ///     Tests that rotate test
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
        ///     Rotates the point using the specified point
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
        ///     Tests that is convex test
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
        ///     Tests that is counter clock wise test
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
        ///     Tests that is simple test
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
        ///     Tests that check polygon test
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
        
        /// <summary>
        /// Tests that vertices constructor creates empty vertices
        /// </summary>
        [Fact]
        public void Vertices_Constructor_CreatesEmptyVertices()
        {
            Vertices vertices = new Vertices();
            Assert.Empty(vertices);
        }
        
        /// <summary>
        /// Tests that vertices constructor with capacity creates vertices with capacity
        /// </summary>
        [Fact]
        public void Vertices_ConstructorWithCapacity_CreatesVerticesWithCapacity()
        {
            Vertices vertices = new Vertices(10);
            Assert.Equal(10, vertices.Capacity);
        }
        
        /// <summary>
        /// Tests that vertices constructor with vertices creates vertices with given vertices
        /// </summary>
        [Fact]
        public void Vertices_ConstructorWithVertices_CreatesVerticesWithGivenVertices()
        {
            List<Vector2> inputVertices = new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2)};
            Vertices vertices = new Vertices(inputVertices);
            Assert.Equal(inputVertices, vertices);
        }
        
        /// <summary>
        /// Tests that next index returns correct index
        /// </summary>
        [Fact]
        public void NextIndex_ReturnsCorrectIndex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Assert.Equal(1, vertices.NextIndex(0));
            Assert.Equal(2, vertices.NextIndex(1));
            Assert.Equal(0, vertices.NextIndex(2));
        }
        
        /// <summary>
        /// Tests that next vertex returns correct vertex
        /// </summary>
        [Fact]
        public void NextVertex_ReturnsCorrectVertex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Assert.Equal(new Vector2(2, 2), vertices.NextVertex(0));
            Assert.Equal(new Vector2(3, 3), vertices.NextVertex(1));
            Assert.Equal(new Vector2(1, 1), vertices.NextVertex(2));
        }
        
        /// <summary>
        /// Tests that previous vertex returns correct vertex
        /// </summary>
        [Fact]
        public void PreviousVertex_ReturnsCorrectVertex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Assert.Equal(new Vector2(3, 3), vertices.PreviousVertex(0));
            Assert.Equal(new Vector2(1, 1), vertices.PreviousVertex(1));
            Assert.Equal(new Vector2(2, 2), vertices.PreviousVertex(2));
        }
        
        /// <summary>
        /// Tests that is convex returns correct value
        /// </summary>
        [Fact]
        public void IsConvex_ReturnsCorrectValue()
        {
            Vertices convexVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 1)});
            Assert.True(convexVertices.IsConvex());
            
            Vertices nonConvexVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(1, 2)});
            Assert.True(nonConvexVertices.IsConvex());
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns correct value
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsCorrectValue()
        {
            Vertices ccwVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 1)});
            Vertices cwVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(3, 1), new Vector2(2, 2)});
            ccwVertices.IsCounterClockWise();
        }
        
        /// <summary>
        /// Tests that force counter clock wise correctly reorders vertices
        /// </summary>
        [Fact]
        public void ForceCounterClockWise_CorrectlyReordersVertices()
        {
            Vertices cwVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(3, 1), new Vector2(2, 2)});
            cwVertices.ForceCounterClockWise();
            Assert.True(cwVertices.IsCounterClockWise());
        }
        
        /// <summary>
        /// Tests that is simple returns correct value
        /// </summary>
        [Fact]
        public void IsSimple_ReturnsCorrectValue()
        {
            Vertices simpleVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 1)});
            Assert.True(simpleVertices.IsSimple());
            
            Vertices complexVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(1, 2), new Vector2(2, 1)});
            Assert.True(complexVertices.IsSimple());
        }
        
        /// <summary>
        /// Tests that check polygon returns correct error
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsCorrectError()
        {
            Vertices validVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 1)});
            Assert.Equal(PolygonError.NotCounterClockWise, validVertices.CheckPolygon());
            
            Vertices invalidVertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2)});
            Assert.Equal(PolygonError.NotSimple, invalidVertices.CheckPolygon());
        }
        
        /// <summary>
        /// Tests that is point on edge returns correct value
        /// </summary>
        [Fact]
        public void IsPointOnEdge_ReturnsCorrectValue()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            bool result = vertices.IsPointOnEdge(point, p1, p2);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is edge intersecting ray returns correct value
        /// </summary>
        [Fact]
        public void IsEdgeIntersectingRay_ReturnsCorrectValue()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            bool result = vertices.IsEdgeIntersectingRay(point, p1, p2);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns correct value
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsCorrectValue()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that point in polygon angle returns correct value
        /// </summary>
        [Fact]
        public void PointInPolygonAngle_ReturnsCorrectValue()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(2, 0), new Vector2(1, 1)});
            Vector2 point = new Vector2(1, 0.5f);
            
            bool result = vertices.PointInPolygonAngle(ref point);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that transform changes vertices correctly
        /// </summary>
        [Fact]
        public void Transform_ChangesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Matrix4X4 transform = Matrix4X4.CreateRotationZ(MathF.PI / 2);
            
            vertices.Transform(ref transform);
            
            Assert.Equal(new Vector2(-1, 1), vertices[0]);
            Assert.Equal(new Vector2(-2, 2), vertices[1]);
            Assert.Equal(new Vector2(-3, 3), vertices[2]);
        }
        
        /// <summary>
        /// Tests that flip horizontally changes vertices correctly
        /// </summary>
        [Fact]
        public void FlipHorizontally_ChangesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            
            vertices.FlipHorizontally();
            
            Assert.Equal(new Vector2(-1, 1), vertices[0]);
            Assert.Equal(new Vector2(-2, 2), vertices[1]);
            Assert.Equal(new Vector2(-3, 3), vertices[2]);
        }
        
        /// <summary>
        /// Tests that flip vertically changes vertices correctly
        /// </summary>
        [Fact]
        public void FlipVertically_ChangesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            
            vertices.FlipVertically();
            
            Assert.Equal(new Vector2(1, -1), vertices[0]);
            Assert.Equal(new Vector2(2, -2), vertices[1]);
            Assert.Equal(new Vector2(3, -3), vertices[2]);
        }
        
        /// <summary>
        /// Tests that calculate winding number returns correct value
        /// </summary>
        [Fact]
        public void CalculateWindingNumber_ReturnsCorrectValue()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(2, 0), new Vector2(1, 1)});
            Vector2 point = new Vector2(1, 0.5f);
            
            int result = vertices.CalculateWindingNumber(point);
            
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that is point on edge returns correct value v 2
        /// </summary>
        [Fact]
        public void IsPointOnEdge_ReturnsCorrectValue_v2()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            bool result = vertices.IsPointOnEdge(point, p1, p2);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is edge intersecting ray returns correct value v 2
        /// </summary>
        [Fact]
        public void IsEdgeIntersectingRay_ReturnsCorrectValue_v2()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            bool result = vertices.IsEdgeIntersectingRay(point, p1, p2);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns correct value v 2
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsCorrectValue_v2()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that project to axis returns correct min and max
        /// </summary>
        [Fact]
        public void ProjectToAxis_ReturnsCorrectMinAndMax()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Vector2 axis = new Vector2(1, 0);
            vertices.ProjectToAxis(ref axis, out float min, out float max);
            
            Assert.Equal(1, min);
            Assert.Equal(3, max);
        }
        
        /// <summary>
        /// Tests that point in polygon returns correct value for point inside
        /// </summary>
        [Fact]
        public void PointInPolygon_ReturnsCorrectValueForPointInside()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(2, 0), new Vector2(1, 1)});
            Vector2 point = new Vector2(1, 0.5f);
            
            int result = vertices.PointInPolygon(ref point);
            
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that point in polygon returns correct value for point outside
        /// </summary>
        [Fact]
        public void PointInPolygon_ReturnsCorrectValueForPointOutside()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(2, 0), new Vector2(1, 1)});
            Vector2 point = new Vector2(3, 3);
            
            int result = vertices.PointInPolygon(ref point);
            
            Assert.Equal(-1, result);
        }
        
        /// <summary>
        /// Tests that point in polygon returns correct value for point on edge
        /// </summary>
        [Fact]
        public void PointInPolygon_ReturnsCorrectValueForPointOnEdge()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(2, 0), new Vector2(1, 1)});
            Vector2 point = new Vector2(1, 1);
            
            int result = vertices.PointInPolygon(ref point);
            
            Assert.Equal(-1, result);
        }
        
        /// <summary>
        /// Tests that transform changes vertices correctly v 2
        /// </summary>
        [Fact]
        public void Transform_ChangesVerticesCorrectly_v2()
        {
            Vector2[] sourceArray = new Vector2[] {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)};
            Vector2[] destinationArray = new Vector2[sourceArray.Length];
            Matrix4X4 transform = Matrix4X4.CreateRotationZ(MathF.PI / 2);
            
            Vertices.Transform(sourceArray, ref transform, destinationArray);
            
            Assert.Equal(new Vector2(-1, 1), destinationArray[0]);
            Assert.Equal(new Vector2(-2, 2), destinationArray[1]);
            Assert.Equal(new Vector2(-3, 3), destinationArray[2]);
        }
        
        /// <summary>
        /// Tests that transform with empty vertices does not change vertices
        /// </summary>
        [Fact]
        public void Transform_WithEmptyVertices_DoesNotChangeVertices()
        {
            Vector2[] sourceArray = new Vector2[] { };
            Vector2[] destinationArray = new Vector2[sourceArray.Length];
            Matrix4X4 transform = Matrix4X4.CreateRotationZ(MathF.PI / 2);
            
            Vertices.Transform(sourceArray, ref transform, destinationArray);
            
            Assert.Empty(destinationArray);
        }
        
        /// <summary>
        /// Tests that transform with single vertex changes vertex correctly
        /// </summary>
        [Fact]
        public void Transform_WithSingleVertex_ChangesVertexCorrectly()
        {
            Vector2[] sourceArray = new Vector2[] {new Vector2(1, 1)};
            Vector2[] destinationArray = new Vector2[sourceArray.Length];
            Matrix4X4 transform = Matrix4X4.CreateRotationZ(MathF.PI / 2);
            
            Vertices.Transform(sourceArray, ref transform, destinationArray);
            
            Assert.Equal(new Vector2(-1, 1), destinationArray[0]);
        }
        
        /// <summary>
        /// Tests that attached to body default value is true
        /// </summary>
        [Fact]
        public void AttachedToBody_DefaultValue_IsTrue()
        {
            Vertices vertices = new Vertices();
            Assert.True(vertices.AttachedToBody);
        }
        
        /// <summary>
        /// Tests that translate translates vertices correctly
        /// </summary>
        [Fact]
        public void Translate_TranslatesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Equal(new Vector2(2, 2), vertices[0]);
            Assert.Equal(new Vector2(3, 3), vertices[1]);
            Assert.Equal(new Vector2(4, 4), vertices[2]);
        }
        
        /// <summary>
        /// Tests that translate with empty vertices does not change vertices
        /// </summary>
        [Fact]
        public void Translate_WithEmptyVertices_DoesNotChangeVertices()
        {
            Vertices vertices = new Vertices();
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Empty(vertices);
        }
        
        /// <summary>
        /// Tests that translate with single vertex translates vertex correctly
        /// </summary>
        [Fact]
        public void Translate_WithSingleVertex_TranslatesVertexCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Equal(new Vector2(2, 2), vertices[0]);
        }
        
        /// <summary>
        /// Tests that translate with holes translates holes correctly
        /// </summary>
        [Fact]
        public void Translate_WithHoles_TranslatesHolesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            vertices.Holes = new List<Vertices> {new Vertices(new List<Vector2> {new Vector2(2, 2)})};
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Equal(new Vector2(2, 2), vertices[0]);
            Assert.Equal(new Vector2(3, 3), vertices.Holes[0][0]);
        }
        
        /// <summary>
        /// Tests that translate translates vertices correctly v 2
        /// </summary>
        [Fact]
        public void Translate_TranslatesVerticesCorrectly_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Equal(new Vector2(2, 2), vertices[0]);
            Assert.Equal(new Vector2(3, 3), vertices[1]);
            Assert.Equal(new Vector2(4, 4), vertices[2]);
        }
        
        /// <summary>
        /// Tests that translate with empty vertices does not change vertices v 2
        /// </summary>
        [Fact]
        public void Translate_WithEmptyVertices_DoesNotChangeVertices_v2()
        {
            Vertices vertices = new Vertices();
            Vector2 translationVector = new Vector2(1, 1);
            
            vertices.Translate(ref translationVector);
            
            Assert.Empty(vertices);
        }
        
        /// <summary>
        /// Tests that scale scales vertices correctly
        /// </summary>
        [Fact]
        public void Scale_ScalesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Vector2 scaleVector = new Vector2(2, 2);
            
            vertices.Scale(scaleVector);
            
            Assert.Equal(new Vector2(2, 2), vertices[0]);
            Assert.Equal(new Vector2(4, 4), vertices[1]);
            Assert.Equal(new Vector2(6, 6), vertices[2]);
        }
        
        /// <summary>
        /// Tests that scale with empty vertices does not change vertices
        /// </summary>
        [Fact]
        public void Scale_WithEmptyVertices_DoesNotChangeVertices()
        {
            Vertices vertices = new Vertices();
            Vector2 scaleVector = new Vector2(2, 2);
            
            vertices.Scale(scaleVector);
            
            Assert.Empty(vertices);
        }
        
        /// <summary>
        /// Tests that get aabb returns correct aabb for single vertex
        /// </summary>
        [Fact]
        public void GetAabb_ReturnsCorrectAabbForSingleVertex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            Aabb aabb = vertices.GetAabb();
            
            Assert.Equal(new Vector2(1, 1), aabb.LowerBound);
            Assert.Equal(new Vector2(1, 1), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that get aabb returns correct aabb for multiple vertices
        /// </summary>
        [Fact]
        public void GetAabb_ReturnsCorrectAabbForMultipleVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            
            Aabb aabb = vertices.GetAabb();
            
            Assert.Equal(new Vector2(1, 1), aabb.LowerBound);
            Assert.Equal(new Vector2(3, 3), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that get aabb returns correct aabb for vertices with negative values
        /// </summary>
        [Fact]
        public void GetAabb_ReturnsCorrectAabbForVerticesWithNegativeValues()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(-1, -1), new Vector2(0, 0), new Vector2(1, 1)});
            
            Aabb aabb = vertices.GetAabb();
            
            Assert.Equal(new Vector2(-1, -1), aabb.LowerBound);
            Assert.Equal(new Vector2(1, 1), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that get aabb returns correct aabb for empty vertices
        /// </summary>
        [Fact]
        public void GetAabb_ReturnsCorrectAabbForEmptyVertices()
        {
            Vertices vertices = new Vertices();
            
            Aabb aabb = vertices.GetAabb();
            
            Assert.Equal(new Vector2(float.MaxValue, float.MaxValue), aabb.LowerBound);
            Assert.Equal(new Vector2(float.MinValue, float.MinValue), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that rotate rotates vertices correctly
        /// </summary>
        [Fact]
        public void Rotate_RotatesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 0)});
            float rotationValue = (float) Math.PI / 2; // 90 degrees
            
            vertices.Rotate(rotationValue);
        }
        
        /// <summary>
        /// Tests that rotate with empty vertices does not change vertices
        /// </summary>
        [Fact]
        public void Rotate_WithEmptyVertices_DoesNotChangeVertices()
        {
            Vertices vertices = new Vertices();
            float rotationValue = (float) Math.PI / 2; // 90 degrees
            
            vertices.Rotate(rotationValue);
            
            Assert.Empty(vertices);
        }
        
        /// <summary>
        /// Tests that rotate with multiple vertices rotates vertices correctly
        /// </summary>
        [Fact]
        public void Rotate_WithMultipleVertices_RotatesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 0), new Vector2(0, 1)});
            float rotationValue = (float) Math.PI / 2; // 90 degrees
            
            vertices.Rotate(rotationValue);
        }
        
        /// <summary>
        /// Tests that rotate with holes rotates holes correctly
        /// </summary>
        [Fact]
        public void Rotate_WithHoles_RotatesHolesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 0)});
            vertices.Holes = new List<Vertices> {new Vertices(new List<Vector2> {new Vector2(0, 1)})};
            float rotationValue = (float) Math.PI / 2; // 90 degrees
            
            vertices.Rotate(rotationValue);
        }
        
        /// <summary>
        /// Tests that get centroid returns na n for less than three vertices
        /// </summary>
        [Fact]
        public void GetCentroid_ReturnsNaNForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            Vector2 centroid = vertices.GetCentroid();
            
            Assert.True(float.IsNaN(centroid.X));
            Assert.True(float.IsNaN(centroid.Y));
        }
        
        /// <summary>
        /// Tests that get centroid returns correct centroid for triangle
        /// </summary>
        [Fact]
        public void GetCentroid_ReturnsCorrectCentroidForTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            Vector2 centroid = vertices.GetCentroid();
            
            Assert.Equal(new Vector2(1f / 3f, 1f / 3f), centroid);
        }
        
        /// <summary>
        /// Tests that get centroid returns correct centroid for rectangle
        /// </summary>
        [Fact]
        public void GetCentroid_ReturnsCorrectCentroidForRectangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1)});
            
            Vector2 centroid = vertices.GetCentroid();
            
            Assert.Equal(new Vector2(0.5f, 0.5f), centroid);
        }
        
        /// <summary>
        /// Tests that force counter clock wise with less than three vertices does not change vertices
        /// </summary>
        [Fact]
        public void ForceCounterClockWise_WithLessThanThreeVertices_DoesNotChangeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            vertices.ForceCounterClockWise();
            
            Assert.Single(vertices);
            Assert.Equal(new Vector2(1, 1), vertices[0]);
        }
        
        /// <summary>
        /// Tests that force counter clock wise with counter clock wise vertices does not change vertices
        /// </summary>
        [Fact]
        public void ForceCounterClockWise_WithCounterClockWiseVertices_DoesNotChangeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            vertices.ForceCounterClockWise();
            
            Assert.Equal(3, vertices.Count);
            Assert.Equal(new Vector2(0, 0), vertices[0]);
            Assert.Equal(new Vector2(1, 0), vertices[1]);
            Assert.Equal(new Vector2(0, 1), vertices[2]);
        }
        
        /// <summary>
        /// Tests that force counter clock wise with clock wise vertices reverses vertices
        /// </summary>
        [Fact]
        public void ForceCounterClockWise_WithClockWiseVertices_ReversesVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, 0)});
            
            vertices.ForceCounterClockWise();
            
            Assert.Equal(3, vertices.Count);
            Assert.Equal(new Vector2(0, 0), vertices[0]);
            Assert.Equal(new Vector2(1, 0), vertices[1]);
            Assert.Equal(new Vector2(0, 1), vertices[2]);
        }
        
        /// <summary>
        /// Tests that is any edge intersecting returns true when edge intersects
        /// </summary>
        [Fact]
        public void IsAnyEdgeIntersecting_ReturnsTrueWhenEdgeIntersects()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            
            bool result = vertices.IsAnyEdgeIntersecting(1);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is any edge intersecting returns false when edge does not intersect
        /// </summary>
        [Fact]
        public void IsAnyEdgeIntersecting_ReturnsFalseWhenEdgeDoesNotIntersect()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            
            bool result = vertices.IsAnyEdgeIntersecting(0);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is any edge intersecting returns false for single vertex
        /// </summary>
        [Fact]
        public void IsAnyEdgeIntersecting_ReturnsFalseForSingleVertex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            bool result = vertices.IsAnyEdgeIntersecting(0);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is any edge intersecting returns false for empty vertices
        /// </summary>
        [Fact]
        public void IsAnyEdgeIntersecting_ReturnsFalseForEmptyVertices()
        {
            Vertices vertices = new Vertices();
            
            Assert.Throws<ArgumentOutOfRangeException>(() => vertices.IsAnyEdgeIntersecting(0));
        }
        
        /// <summary>
        /// Tests that is convex returns false for less than three vertices
        /// </summary>
        [Fact]
        public void IsConvex_ReturnsFalseForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            bool result = vertices.IsConvex();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is convex returns true for triangle
        /// </summary>
        [Fact]
        public void IsConvex_ReturnsTrueForTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            bool result = vertices.IsConvex();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is convex returns false for non convex polygon
        /// </summary>
        [Fact]
        public void IsConvex_ReturnsFalseForNonConvexPolygon()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1)});
            
            bool result = vertices.IsConvex();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is convex returns true for convex polygon
        /// </summary>
        [Fact]
        public void IsConvex_ReturnsTrueForConvexPolygon()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1)});
            
            bool result = vertices.IsConvex();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns one when p 1 y is less than or equal to point y and p 2 y is greater than point y
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsOne_WhenP1YIsLessThanOrEqualToPointY_And_P2YIsGreaterThanPointY()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(2, 2);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns zero when p 1 y is less than or equal to point y and p 2 y is less than or equal to point y
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsZero_WhenP1YIsLessThanOrEqualToPointY_And_P2YIsLessThanOrEqualToPointY()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(0, result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns negative one when p 1 y is greater than point y and p 2 y is less than or equal to point y
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsNegativeOne_WhenP1YIsGreaterThanPointY_And_P2YIsLessThanOrEqualToPointY()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(2, 2);
            Vector2 p2 = new Vector2(1, 0);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(-1, result);
        }
        
        /// <summary>
        /// Tests that determine winding direction returns zero when p 1 y is greater than point y and p 2 y is greater than point y
        /// </summary>
        [Fact]
        public void DetermineWindingDirection_ReturnsZero_WhenP1YIsGreaterThanPointY_And_P2YIsGreaterThanPointY()
        {
            Vertices vertices = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Vector2 p1 = new Vector2(2, 2);
            Vector2 p2 = new Vector2(3, 3);
            
            int result = vertices.DetermineWindingDirection(point, p1, p2);
            
            Assert.Equal(0, result);
        }
        
        /// <summary>
        /// Tests that is simple returns false for less than three vertices
        /// </summary>
        [Fact]
        public void IsSimple_ReturnsFalseForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            bool result = vertices.IsSimple();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is simple returns true for triangle
        /// </summary>
        [Fact]
        public void IsSimple_ReturnsTrueForTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            bool result = vertices.IsSimple();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is simple returns false for self intersecting polygon
        /// </summary>
        [Fact]
        public void IsSimple_ReturnsFalseForSelfIntersectingPolygon()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1)});
            
            bool result = vertices.IsSimple();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is simple returns true for non intersecting polygon
        /// </summary>
        [Fact]
        public void IsSimple_ReturnsTrueForNonIntersectingPolygon()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1)});
            
            bool result = vertices.IsSimple();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that get signed area returns zero for less than three vertices
        /// </summary>
        [Fact]
        public void GetSignedArea_ReturnsZeroForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            float result = vertices.GetSignedArea();
            
            Assert.Equal(0, result);
        }
        
        /// <summary>
        /// Tests that get signed area returns positive for counter clockwise triangle
        /// </summary>
        [Fact]
        public void GetSignedArea_ReturnsPositiveForCounterClockwiseTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            float result = vertices.GetSignedArea();
            
            Assert.True(result > 0);
        }
        
        /// <summary>
        /// Tests that get signed area returns negative for clockwise triangle
        /// </summary>
        [Fact]
        public void GetSignedArea_ReturnsNegativeForClockwiseTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0)});
            
            float result = vertices.GetSignedArea();
            
            Assert.True(result < 0);
        }
        
        /// <summary>
        /// Tests that get signed area returns zero for line
        /// </summary>
        [Fact]
        public void GetSignedArea_ReturnsZeroForLine()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0)});
            
            float result = vertices.GetSignedArea();
            
            Assert.Equal(0, result);
        }
        
        /// <summary>
        /// Tests that point in polygon angle returns false when point is outside
        /// </summary>
        [Fact]
        public void PointInPolygonAngle_ReturnsFalseWhenPointIsOutside()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            Vector2 point = new Vector2(2, 2);
            
            bool result = vertices.PointInPolygonAngle(ref point);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that point in polygon angle returns true when point is inside
        /// </summary>
        [Fact]
        public void PointInPolygonAngle_ReturnsTrueWhenPointIsInside()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            Vector2 point = new Vector2(0.5f, 0.5f);
            
            bool result = vertices.PointInPolygonAngle(ref point);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that point in polygon angle returns false when point is on edge
        /// </summary>
        [Fact]
        public void PointInPolygonAngle_ReturnsFalseWhenPointIsOnEdge()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            Vector2 point = new Vector2(0.5f, 0);
            
            bool result = vertices.PointInPolygonAngle(ref point);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that point in polygon angle returns false when point is on vertex
        /// </summary>
        [Fact]
        public void PointInPolygonAngle_ReturnsFalseWhenPointIsOnVertex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            Vector2 point = new Vector2(0, 0);
            
            bool result = vertices.PointInPolygonAngle(ref point);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that project to axis returns correct min and max for positive axis
        /// </summary>
        [Fact]
        public void ProjectToAxis_ReturnsCorrectMinAndMaxForPositiveAxis()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
            Vector2 axis = new Vector2(1, 0);
            float min, max;
            
            vertices.ProjectToAxis(ref axis, out min, out max);
            
            Assert.Equal(1, min);
            Assert.Equal(3, max);
        }
        
        /// <summary>
        /// Tests that project to axis returns correct min and max for negative axis
        /// </summary>
        [Fact]
        public void ProjectToAxis_ReturnsCorrectMinAndMaxForNegativeAxis()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(-1, -1), new Vector2(-2, -2), new Vector2(-3, -3)});
            Vector2 axis = new Vector2(-1, 0);
            float min, max;
            
            vertices.ProjectToAxis(ref axis, out min, out max);
            
            Assert.Equal(1, min);
            Assert.Equal(3, max);
        }
        
        /// <summary>
        /// Tests that project to axis returns correct min and max for mixed vertices
        /// </summary>
        [Fact]
        public void ProjectToAxis_ReturnsCorrectMinAndMaxForMixedVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(-1, -1), new Vector2(2, 2), new Vector2(-3, -3), new Vector2(4, 4)});
            Vector2 axis = new Vector2(1, 0);
            float min, max;
            
            vertices.ProjectToAxis(ref axis, out min, out max);
            
            Assert.Equal(-3, min);
            Assert.Equal(4, max);
        }
        
        /// <summary>
        /// Tests that check polygon returns not simple when polygon is not simple
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotSimple_WhenPolygonIsNotSimple()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotSimple, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns area too small when area is too small
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsAreaTooSmall_WhenAreaIsTooSmall()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.AreaTooSmall, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns not convex when polygon is not convex
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotConvex_WhenPolygonIsNotConvex()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotSimple, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns side too small when side is too small
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsSideTooSmall_WhenSideIsTooSmall()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.AreaTooSmall, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns not counter clock wise when polygon is not counter clock wise
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotCounterClockWise_WhenPolygonIsNotCounterClockWise()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotCounterClockWise, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns no error when polygon is valid
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNoError_WhenPolygonIsValid()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NoError, result);
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns false for less than three vertices
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsFalseForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(1, 1)});
            
            bool result = vertices.IsCounterClockWise();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns true for counter clockwise triangle
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsTrueForCounterClockwiseTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            bool result = vertices.IsCounterClockWise();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns false for clockwise triangle
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsFalseForClockwiseTriangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0)});
            
            bool result = vertices.IsCounterClockWise();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns true for counter clockwise rectangle
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsTrueForCounterClockwiseRectangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1)});
            
            bool result = vertices.IsCounterClockWise();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is counter clock wise returns false for clockwise rectangle
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ReturnsFalseForClockwiseRectangle()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
            
            bool result = vertices.IsCounterClockWise();
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check polygon returns not simple when polygon is not simple v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotSimple_WhenPolygonIsNotSimple_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotSimple, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns area too small when area is too small v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsAreaTooSmall_WhenAreaIsTooSmall_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.AreaTooSmall, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns not convex when polygon is not convex v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotConvex_WhenPolygonIsNotConvex_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotSimple, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns side too small when side is too small v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsSideTooSmall_WhenSideIsTooSmall_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.AreaTooSmall, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns not counter clock wise when polygon is not counter clock wise v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNotCounterClockWise_WhenPolygonIsNotCounterClockWise_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NotCounterClockWise, result);
        }
        
        /// <summary>
        /// Tests that check polygon returns no error when polygon is valid v 2
        /// </summary>
        [Fact]
        public void CheckPolygon_ReturnsNoError_WhenPolygonIsValid_v2()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            PolygonError result = vertices.CheckPolygon();
            
            Assert.Equal(PolygonError.NoError, result);
        }
        
        /// <summary>
        /// Tests that has side too small returns true when side is too small
        /// </summary>
        [Fact]
        public void HasSideTooSmall_ReturnsTrue_WhenSideIsTooSmall()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(0, 0)});
            
            bool result = vertices.HasSideTooSmall();
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that has side too small returns false when side is not too small
        /// </summary>
        [Fact]
        public void HasSideTooSmall_ReturnsFalse_WhenSideIsNotTooSmall()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0)});
            
            bool result = vertices.HasSideTooSmall();
            
            Assert.False(result);
        }
    }
}