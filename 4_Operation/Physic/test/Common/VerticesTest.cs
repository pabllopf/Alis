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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The vertices test class
    /// </summary>
    public class VerticesTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize empty list
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeEmptyList()
        {
            Vertices vertices = new Vertices();
            
            Assert.NotNull(vertices);
            Assert.Empty(vertices);
        }

        /// <summary>
        ///     Tests that constructor with capacity should initialize with capacity
        /// </summary>
        [Fact]
        public void ConstructorWithCapacity_ShouldInitializeWithCapacity()
        {
            Vertices vertices = new Vertices(10);
            
            Assert.NotNull(vertices);
            Assert.Empty(vertices);
            Assert.True(vertices.Capacity >= 10);
        }

        /// <summary>
        ///     Tests that constructor with enumerable should initialize with vertices
        /// </summary>
        [Fact]
        public void ConstructorWithEnumerable_ShouldInitializeWithVertices()
        {
            List<Vector2F> points = new List<Vector2F>
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1),
                new Vector2F(2, 0)
            };
            
            Vertices vertices = new Vertices(points);
            
            Assert.Equal(3, vertices.Count);
            Assert.Equal(points[0], vertices[0]);
        }

        /// <summary>
        ///     Tests that next index should return next index
        /// </summary>
        [Fact]
        public void NextIndex_ShouldReturnNextIndex()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 0) };
            
            int next = vertices.NextIndex(0);
            
            Assert.Equal(1, next);
        }

        /// <summary>
        ///     Tests that next index should wrap around
        /// </summary>
        [Fact]
        public void NextIndex_ShouldWrapAround()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 0) };
            
            int next = vertices.NextIndex(2);
            
            Assert.Equal(0, next);
        }

        /// <summary>
        ///     Tests that next vertex should return next vertex
        /// </summary>
        [Fact]
        public void NextVertex_ShouldReturnNextVertex()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 1), 
                new Vector2F(2, 0) 
            };
            
            Vector2F next = vertices.NextVertex(0);
            
            Assert.Equal(new Vector2F(1, 1), next);
        }

        /// <summary>
        ///     Tests that previous index should return previous index
        /// </summary>
        [Fact]
        public void PreviousIndex_ShouldReturnPreviousIndex()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 0) };
            
            int prev = vertices.PreviousIndex(1);
            
            Assert.Equal(0, prev);
        }

        /// <summary>
        ///     Tests that previous index should wrap around
        /// </summary>
        [Fact]
        public void PreviousIndex_ShouldWrapAround()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 0) };
            
            int prev = vertices.PreviousIndex(0);
            
            Assert.Equal(2, prev);
        }

        /// <summary>
        ///     Tests that previous vertex should return previous vertex
        /// </summary>
        [Fact]
        public void PreviousVertex_ShouldReturnPreviousVertex()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 1), 
                new Vector2F(2, 0) 
            };
            
            Vector2F prev = vertices.PreviousVertex(1);
            
            Assert.Equal(new Vector2F(0, 0), prev);
        }

        /// <summary>
        ///     Tests that get signed area should return positive for ccw polygon
        /// </summary>
        [Fact]
        public void GetSignedArea_ShouldReturnPositive_ForCcwPolygon()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 0), 
                new Vector2F(0.5f, 1) 
            };
            
            float area = vertices.GetSignedArea();
            
            Assert.True(area > 0);
        }

        /// <summary>
        ///     Tests that get signed area should return zero for less than three vertices
        /// </summary>
        [Fact]
        public void GetSignedArea_ShouldReturnZero_ForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 1) };
            
            float area = vertices.GetSignedArea();
            
            Assert.Equal(0, area);
        }

        /// <summary>
        ///     Tests that get area should return absolute value
        /// </summary>
        [Fact]
        public void GetArea_ShouldReturnAbsoluteValue()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(0, 1), 
                new Vector2F(1, 0) 
            };
            
            float area = vertices.GetArea();
            
            Assert.True(area >= 0);
        }

        /// <summary>
        ///     Tests that get centroid should return centroid of triangle
        /// </summary>
        [Fact]
        public void GetCentroid_ShouldReturnCentroidOfTriangle()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(3, 0), 
                new Vector2F(0, 3) 
            };
            
            Vector2F centroid = vertices.GetCentroid();
            
            Assert.True(centroid.X > 0 && centroid.Y > 0);
        }

        /// <summary>
        ///     Tests that get centroid should return nan for less than three vertices
        /// </summary>
        [Fact]
        public void GetCentroid_ShouldReturnNaN_ForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0) };
            
            Vector2F centroid = vertices.GetCentroid();
            
            Assert.True(float.IsNaN(centroid.X));
            Assert.True(float.IsNaN(centroid.Y));
        }

        /// <summary>
        ///     Tests that translate should move all vertices
        /// </summary>
        [Fact]
        public void Translate_ShouldMoveAllVertices()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 1) 
            };
            
            vertices.Translate(new Vector2F(5, 5));
            
            Assert.Equal(new Vector2F(5, 5), vertices[0]);
            Assert.Equal(new Vector2F(6, 6), vertices[1]);
        }

        /// <summary>
        ///     Tests that scale should scale all vertices
        /// </summary>
        [Fact]
        public void Scale_ShouldScaleAllVertices()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(1, 1), 
                new Vector2F(2, 2) 
            };
            
            vertices.Scale(new Vector2F(2, 2));
            
            Assert.Equal(new Vector2F(2, 2), vertices[0]);
            Assert.Equal(new Vector2F(4, 4), vertices[1]);
        }

        /// <summary>
        ///     Tests that rotate should rotate all vertices
        /// </summary>
        [Fact]
        public void Rotate_ShouldRotateAllVertices()
        {
            Vertices vertices = new Vertices { new Vector2F(1, 0) };
            
            vertices.Rotate((float)System.Math.PI / 2);
            
            Assert.True(System.Math.Abs(vertices[0].X) < 0.001f);
        }

        /// <summary>
        ///     Tests that is convex should return false for less than three vertices
        /// </summary>
        [Fact]
        public void IsConvex_ShouldReturnFalse_ForLessThanThreeVertices()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0) };
            
            bool isConvex = vertices.IsConvex();
            
            Assert.False(isConvex);
        }

        /// <summary>
        ///     Tests that is convex should return true for triangle
        /// </summary>
        [Fact]
        public void IsConvex_ShouldReturnTrue_ForTriangle()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 0), 
                new Vector2F(0, 1) 
            };
            
            bool isConvex = vertices.IsConvex();
            
            Assert.True(isConvex);
        }

        /// <summary>
        ///     Tests that is counter clock wise should return true for ccw polygon
        /// </summary>
        [Fact]
        public void IsCounterClockWise_ShouldReturnTrue_ForCcwPolygon()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(1, 0), 
                new Vector2F(0.5f, 1) 
            };
            
            bool isCcw = vertices.IsCounterClockWise();
            
            Assert.True(isCcw);
        }

        /// <summary>
        ///     Tests that force counter clock wise should reverse clockwise polygon
        /// </summary>
        [Fact]
        public void ForceCounterClockWise_ShouldReverseClockwisePolygon()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(0, 1), 
                new Vector2F(1, 0) 
            };
            
            vertices.ForceCounterClockWise();
            
            Assert.True(vertices.IsCounterClockWise());
        }

        /// <summary>
        ///     Tests that get aabb should return valid aabb
        /// </summary>
        [Fact]
        public void GetAabb_ShouldReturnValidAabb()
        {
            Vertices vertices = new Vertices 
            { 
                new Vector2F(0, 0), 
                new Vector2F(10, 5), 
                new Vector2F(5, 10) 
            };
            
            
            Aabb aabb = vertices.GetAabb();
            
            Assert.True(aabb.LowerBound.X <= 0);
            Assert.True(aabb.UpperBound.X >= 10);
        }

        /// <summary>
        ///     Tests that holes property should set and get correctly
        /// </summary>
        [Fact]
        public void HolesProperty_ShouldSetAndGetCorrectly()
        {
            Vertices vertices = new Vertices();
            List<Vertices> holes = new List<Vertices>();
            
            vertices.Holes = holes;
            
            Assert.NotNull(vertices.Holes);
        }
    }
}

