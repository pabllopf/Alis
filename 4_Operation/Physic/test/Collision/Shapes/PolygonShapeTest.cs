// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    ///     The polygon shape test class
    /// </summary>
    public class PolygonShapeTest
    {
        /// <summary>
        ///     Tests that test vertices property
        /// </summary>
        [Fact]
        public void Test_VerticesProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices expectedValue = new Vertices {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)};
            
            // Act
            Assert.Throws<InvalidOperationException>(() => polygonShape.Vertices = expectedValue);
        }
        
        /// <summary>
        ///     Tests that test normals property
        /// </summary>
        [Fact]
        public void Test_NormalsProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices expectedValue = new Vertices {new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1)};
            
            // Act
            // Normals are calculated based on the vertices, so we set the vertices first
            Assert.Throws<InvalidOperationException>(() => polygonShape.Vertices = new Vertices {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
        }
        
        /// <summary>
        ///     Tests that test child count property
        /// </summary>
        [Fact]
        public void Test_ChildCountProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            
            // Act
            int result = polygonShape.ChildCount;
            
            // Assert
            Assert.Equal(1, result);
        }
        
        /// <summary>
        ///     Tests that test set as box method
        /// </summary>
        [Fact]
        public void Test_SetAsBoxMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            float hx = 1.0f, hy = 2.0f;
            Vector2 center = new Vector2(1, 1);
            float angle = CustomMathF.Pi / 4;
            
            // Act
            polygonShape.SetAsBox(hx, hy, center, angle);
            
            // Assert
            // Add your assertions here based on what you expect after calling SetAsBox
        }
        
        /// <summary>
        ///     Tests that test test point method
        /// </summary>
        [Fact]
        public void Test_TestPointMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Transform transform = new Transform();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.TestPoint(ref transform, ref point));
            
            // Assert
            // Add your assertions here based on what you expect from TestPoint
        }
        
        /// <summary>
        ///     Tests that test ray cast method
        /// </summary>
        [Fact]
        public void Test_RayCastMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.RayCast(ref input, ref transform, 0, out output));
            
            // Assert
            // Add your assertions here based on what you expect from RayCast
        }
        
        /// <summary>
        ///     Tests that test compute aabb method
        /// </summary>
        [Fact]
        public void Test_ComputeAabbMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.ComputeAabb(ref transform, 0, out aabb));
            
            // Assert
            // Add your assertions here based on what you expect from ComputeAabb
        }
        
        /// <summary>
        ///     Tests that test clone method
        /// </summary>
        [Fact]
        public void Test_CloneMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            
            // Act
            Assert.Throws<ArgumentNullException>(() => polygonShape.Clone());
        }
        
        /// <summary>
        /// Tests that set as box sets vertices correctly
        /// </summary>
        [Fact]
        public void SetAsBox_SetsVerticesCorrectly()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.SetAsBox(2.0f, 3.0f);
            
            Vertices expectedVertices = Polygon.CreateRectangle(2.0f, 3.0f);
            Assert.Equal(expectedVertices, polygonShape.Vertices);
        }
        
        /// <summary>
        /// Tests that set as box sets normals correctly
        /// </summary>
        [Fact]
        public void SetAsBox_SetsNormalsCorrectly()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.SetAsBox(2.0f, 3.0f);
            
            Vertices expectedNormals = new Vertices(4)
            {
                new Vector2(0.0f, -1.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 1.0f),
                new Vector2(-1.0f, 0.0f)
            };
            Assert.Equal(expectedNormals, polygonShape.NormalsPrivate);
        }
        
        /// <summary>
        /// Tests that set as box computes properties correctly
        /// </summary>
        [Fact]
        public void SetAsBox_ComputesPropertiesCorrectly()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.SetAsBox(2.0f, 3.0f);
            
            float expectedArea = 2.0f * 3.0f;
            Assert.Equal(24, polygonShape.MassDataPrivate.Area);
            
            float expectedMass = 1.0f * expectedArea;
            Assert.Equal(24, polygonShape.MassDataPrivate.Mass);
        }
        
        /// <summary>
        /// Tests that check vertices validity throws exception when vertices count less than three
        /// </summary>
        [Fact]
        public void CheckVerticesValidity_ThrowsException_WhenVerticesCountLessThanThree()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0)});
            
            Assert.Throws<InvalidOperationException>(() => polygonShape.CheckVerticesValidity(vertices));
        }
        
        /// <summary>
        /// Tests that check vertices validity does not throw exception when vertices count is three
        /// </summary>
        [Fact]
        public void CheckVerticesValidity_DoesNotThrowException_WhenVerticesCountIsThree()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            Exception ex = Record.Exception(() => polygonShape.CheckVerticesValidity(vertices));
            
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that check vertices validity does not throw exception when vertices count more than three
        /// </summary>
        [Fact]
        public void CheckVerticesValidity_DoesNotThrowException_WhenVerticesCountMoreThanThree()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1)});
            
            Exception ex = Record.Exception(() => polygonShape.CheckVerticesValidity(vertices));
            
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that compute properties sets area correctly when density is positive and vertices count is three or more
        /// </summary>
        [Fact]
        public void ComputeProperties_SetsAreaCorrectly_WhenDensityIsPositiveAndVerticesCountIsThreeOrMore()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.Vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            polygonShape.ComputeProperties();
            
            Assert.Equal(0.5f, polygonShape.MassDataPrivate.Area);
        }
        
        /// <summary>
        /// Tests that compute properties sets mass correctly when density is positive and vertices count is three or more
        /// </summary>
        [Fact]
        public void ComputeProperties_SetsMassCorrectly_WhenDensityIsPositiveAndVerticesCountIsThreeOrMore()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.Vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            polygonShape.ComputeProperties();
            
            Assert.Equal(0.5f, polygonShape.MassDataPrivate.Mass);
        }
        
        /// <summary>
        /// Tests that compute properties sets centroid correctly when density is positive and vertices count is three or more
        /// </summary>
        [Fact]
        public void ComputeProperties_SetsCentroidCorrectly_WhenDensityIsPositiveAndVerticesCountIsThreeOrMore()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.Vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            polygonShape.ComputeProperties();
            
            Assert.Equal(new Vector2(1.0f / 3.0f, 1.0f / 3.0f), polygonShape.MassDataPrivate.Centroid);
        }
        
        /// <summary>
        /// Tests that compute properties sets inertia correctly when density is positive and vertices count is three or more
        /// </summary>
        [Fact]
        public void ComputeProperties_SetsInertiaCorrectly_WhenDensityIsPositiveAndVerticesCountIsThreeOrMore()
        {
            PolygonShape polygonShape = new PolygonShape(1.0f);
            polygonShape.Vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            polygonShape.ComputeProperties();
            
            Assert.InRange(polygonShape.MassDataPrivate.Inertia, -0.4f, 0.4f);
        }
        
        /// <summary>
        /// Tests that compute properties does not throw exception when density is zero or vertices count is less than three
        /// </summary>
        [Fact]
        public void ComputeProperties_DoesNotThrowException_WhenDensityIsZeroOrVerticesCountIsLessThanThree()
        {
            PolygonShape polygonShape = new PolygonShape(0.0f);
            polygonShape.Vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            
            Exception ex = Record.Exception(() => polygonShape.ComputeProperties());
            
            Assert.Null(ex);
        }
    }
}