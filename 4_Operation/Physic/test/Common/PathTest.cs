// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PathTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The path test class
    /// </summary>
    public class PathTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize empty control points
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeEmptyControlPoints()
        {
            Path path = new Path();
            
            Assert.NotNull(path.ControlPoints);
            Assert.Empty(path.ControlPoints);
            Assert.False(path.Closed);
        }

        /// <summary>
        ///     Tests that constructor with array should initialize control points
        /// </summary>
        [Fact]
        public void ConstructorWithArray_ShouldInitializeControlPoints()
        {
            Vector2F[] vertices = new Vector2F[]
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1),
                new Vector2F(2, 0)
            };
            
            Path path = new Path(vertices);
            
            Assert.Equal(3, path.ControlPoints.Count);
            Assert.Equal(vertices[0], path.ControlPoints[0]);
        }

        /// <summary>
        ///     Tests that constructor with list should initialize control points
        /// </summary>
        [Fact]
        public void ConstructorWithList_ShouldInitializeControlPoints()
        {
            List<Vector2F> vertices = new List<Vector2F>
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1)
            };
            
            Path path = new Path(vertices);
            
            Assert.Equal(2, path.ControlPoints.Count);
        }

        /// <summary>
        ///     Tests that add should add control point
        /// </summary>
        [Fact]
        public void Add_ShouldAddControlPoint()
        {
            Path path = new Path();
            Vector2F point = new Vector2F(5, 10);
            
            path.Add(point);
            
            Assert.Single(path.ControlPoints);
            Assert.Equal(point, path.ControlPoints[0]);
        }

        /// <summary>
        ///     Tests that remove should remove control point
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveControlPoint()
        {
            Path path = new Path();
            Vector2F point = new Vector2F(5, 10);
            path.Add(point);
            
            path.Remove(point);
            
            Assert.Empty(path.ControlPoints);
        }

        /// <summary>
        ///     Tests that remove at should remove control point at index
        /// </summary>
        [Fact]
        public void RemoveAt_ShouldRemoveControlPointAtIndex()
        {
            Path path = new Path();
            path.Add(new Vector2F(1, 1));
            path.Add(new Vector2F(2, 2));
            
            path.RemoveAt(0);
            
            Assert.Single(path.ControlPoints);
            Assert.Equal(new Vector2F(2, 2), path.ControlPoints[0]);
        }

        /// <summary>
        ///     Tests that next index should return correct index
        /// </summary>
        [Fact]
        public void NextIndex_ShouldReturnCorrectIndex()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2) });
            
            int nextIndex = path.NextIndex(1);
            
            Assert.Equal(2, nextIndex);
        }

        /// <summary>
        ///     Tests that next index should wrap around to zero
        /// </summary>
        [Fact]
        public void NextIndex_ShouldWrapAroundToZero()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2) });
            
            int nextIndex = path.NextIndex(2);
            
            Assert.Equal(0, nextIndex);
        }

        /// <summary>
        ///     Tests that previous index should return correct index
        /// </summary>
        [Fact]
        public void PreviousIndex_ShouldReturnCorrectIndex()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2) });
            
            int prevIndex = path.PreviousIndex(1);
            
            Assert.Equal(0, prevIndex);
        }

        /// <summary>
        ///     Tests that previous index should wrap around to last
        /// </summary>
        [Fact]
        public void PreviousIndex_ShouldWrapAroundToLast()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2) });
            
            int prevIndex = path.PreviousIndex(0);
            
            Assert.Equal(2, prevIndex);
        }

        /// <summary>
        ///     Tests that translate should move all control points
        /// </summary>
        [Fact]
        public void Translate_ShouldMoveAllControlPoints()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(1, 1) });
            Vector2F translation = new Vector2F(5, 5);
            
            path.Translate(ref translation);
            
            Assert.Equal(new Vector2F(5, 5), path.ControlPoints[0]);
            Assert.Equal(new Vector2F(6, 6), path.ControlPoints[1]);
        }

        /// <summary>
        ///     Tests that scale should scale all control points
        /// </summary>
        [Fact]
        public void Scale_ShouldScaleAllControlPoints()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(1, 1), new Vector2F(2, 2) });
            Vector2F scale = new Vector2F(2, 2);
            
            path.Scale(ref scale);
            
            Assert.Equal(new Vector2F(2, 2), path.ControlPoints[0]);
            Assert.Equal(new Vector2F(4, 4), path.ControlPoints[1]);
        }

        /// <summary>
        ///     Tests that rotate should rotate all control points
        /// </summary>
        [Fact]
        public void Rotate_ShouldRotateAllControlPoints()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(1, 0) });
            float angle = (float)Math.PI / 2; // 90 degrees
            
            path.Rotate(angle);
            
            Assert.False(Math.Abs(path.ControlPoints[0].X) < 0.001f);
            Assert.False(Math.Abs(path.ControlPoints[0].Y - 1.0f) < 0.001f);
        }

        /// <summary>
        ///     Tests that closed property should set and get correctly
        /// </summary>
        [Fact]
        public void ClosedProperty_ShouldSetAndGetCorrectly()
        {
            Path path = new Path();
            
            path.Closed = true;
            
            Assert.True(path.Closed);
        }

        /// <summary>
        ///     Tests that get position should throw exception when less than two control points
        /// </summary>
        [Fact]
        public void GetPosition_ShouldThrowException_WhenLessThanTwoControlPoints()
        {
            Path path = new Path();
            path.Add(new Vector2F(0, 0));
            
            Assert.Throws<Exception>(() => path.GetPosition(0.5f));
        }

        /// <summary>
        ///     Tests that get position should return valid position with two control points
        /// </summary>
        [Fact]
        public void GetPosition_ShouldReturnValidPosition_WithTwoControlPoints()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(10, 10) });
            
            Vector2F position = path.GetPosition(0.5f);
            
            Assert.NotEqual(Vector2F.Zero, position);
        }

        /// <summary>
        ///     Tests that get vertices should return vertices with specified divisions
        /// </summary>
        [Fact]
        public void GetVertices_ShouldReturnVerticesWithSpecifiedDivisions()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(10, 10) });
            
            Vertices vertices = path.GetVertices(10);
            
            Assert.NotNull(vertices);
            Assert.NotEmpty(vertices);
        }

        /// <summary>
        ///     Tests that get position normal should return normalized vector
        /// </summary>
        [Fact]
        public void GetPositionNormal_ShouldReturnNormalizedVector()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10) });
            
            Vector2F normal = path.GetPositionNormal(0.5f);
            
            Assert.True(Math.Abs(normal.Length() - 1.0f) < 0.01f);
        }

        /// <summary>
        ///     Tests that subdivide evenly should return list of subdivisions
        /// </summary>
        [Fact]
        public void SubdivideEvenly_ShouldReturnListOfSubdivisions()
        {
            Path path = new Path(new Vector2F[] 
            { 
                new Vector2F(0, 0), 
                new Vector2F(5, 5), 
                new Vector2F(10, 0) 
            });
            
            List<Vector3F> subdivisions = path.SubdivideEvenly(5);
            
            Assert.NotNull(subdivisions);
        }

        /// <summary>
        ///     Tests that to string should return formatted string
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(1, 2), new Vector2F(3, 4) });
            
            string result = path.ToString();
            
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that get length should return positive value
        /// </summary>
        [Fact]
        public void GetLength_ShouldReturnPositiveValue()
        {
            Path path = new Path(new Vector2F[] { new Vector2F(0, 0), new Vector2F(10, 0) });
            
            float length = path.GetLength();
            
            Assert.True(length > 0);
        }

        /// <summary>
        ///     Tests that closed path should handle get position correctly
        /// </summary>
        [Fact]
        public void ClosedPath_ShouldHandleGetPositionCorrectly()
        {
            Path path = new Path(new Vector2F[] 
            { 
                new Vector2F(0, 0), 
                new Vector2F(10, 0), 
                new Vector2F(10, 10) 
            });
            path.Closed = true;
            
            Vector2F position = path.GetPosition(0.5f);
            
            Assert.NotEqual(Vector2F.Zero, position);
        }
    }
}

