// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainHullTest.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.ConvexHull;
using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    /// The chain hull test class
    /// </summary>
    public class ChainHullTest
    {
        /// <summary>
        /// Tests that chain hull type should be accessible
        /// </summary>
        [Fact]
        public void ChainHull_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(ChainHull));
        }

        /// <summary>
        /// Tests that get convex hull with three points should return same vertices
        /// </summary>
        [Fact]
        public void GetConvexHull_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with two points should return same count
        /// </summary>
        [Fact]
        public void GetConvexHull_WithTwoPoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(2, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with collinear points on edges returns all collinear points
        /// </summary>
        [Fact]
        public void GetConvexHull_WithCollinearPointsOnEdges_ShouldReturnAllCollinearPoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(5, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with collinear points along the entire shape returns minimal endpoints
        /// </summary>
        [Fact]
        public void GetConvexHull_WithAllCollinearPoints_ShouldReturnMinimalEndpoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(3f, 3f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with points on a vertical line returns the correct hull
        /// </summary>
        [Fact]
        public void GetConvexHull_WithVerticalLinePoints_ShouldReturnVerticalHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(1f, 2f),
                new Vector2F(1f, 3f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with triangle returns the same triangle
        /// </summary>
        [Fact]
        public void GetConvexHull_WithTriangle_ShouldReturnSameTriangle()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 0f),
                new Vector2F(2f, 4f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with square returns four corners
        /// </summary>
        [Fact]
        public void GetConvexHull_WithSquare_ShouldReturnFourCorners()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(5, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with pentagon returns five points
        /// </summary>
        [Fact]
        public void GetConvexHull_WithPentagon_ShouldReturnFivePoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(5f, 3f),
                new Vector2F(2f, 5f),
                new Vector2F(-1f, 3f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(6, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with concave shape returns correct convex hull
        /// </summary>
        [Fact]
        public void GetConvexHull_WithConcaveShape_ShouldReturnConvexHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 4f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(5, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with points on vertical line with same y should return two points
        /// </summary>
        [Fact]
        public void GetConvexHull_WithVerticalLineSameY_ShouldReturnTwoPoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(1f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 0f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(2, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with random points returns valid hull
        /// </summary>
        [Fact]
        public void GetConvexHull_WithRandomPoints_ShouldReturnValidHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(1f, 3f),
                new Vector2F(8f, 1f),
                new Vector2F(3f, 5f),
                new Vector2F(6f, 7f),
                new Vector2F(2f, 2f),
                new Vector2F(5f, 4f),
                new Vector2F(4f, 6f),
                new Vector2F(7f, 3f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.True(hull.Count >= 3);
        }

        /// <summary>
        /// Tests that get convex hull with complex concave shape pops interior vertices
        /// </summary>
        [Fact]
        public void GetConvexHull_WithInteriorPoints_ShouldReturnOuterHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(5f, 1f),
                new Vector2F(4f, 2f),
                new Vector2F(0f, 10f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(5, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with single point returns single point
        /// </summary>
        [Fact]
        public void GetConvexHull_WithSinglePoint_ShouldReturnSinglePoint()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(3f, 3f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(1, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with horizontal line points returns minimal hull
        /// </summary>
        [Fact]
        public void GetConvexHull_WithHorizontalLinePoints_ShouldReturnMinimalHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(4f, 0f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with duplicate points handles gracefully
        /// </summary>
        [Fact]
        public void GetConvexHull_WithDuplicatePoints_ShouldNotThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(1f, 1f),
                new Vector2F(2f, 2f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 2);
        }

        /// <summary>
        /// Tests that get convex hull with four collinear points returns minimal endpoints
        /// </summary>
        [Fact]
        public void GetConvexHull_WithFourCollinearPoints_ShouldReturnMinimalEndpoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 2f),
                new Vector2F(2f, 4f),
                new Vector2F(3f, 6f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with points forming L shape returns correct hull
        /// </summary>
        [Fact]
        public void GetConvexHull_WithLShape_ShouldReturnCorrectHull()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 0f),
                new Vector2F(5f, 1f),
                new Vector2F(1f, 1f),
                new Vector2F(1f, 5f),
                new Vector2F(0f, 5f)
            });

            Vertices hull = ChainHull.GetConvexHull(vertices);

            Assert.Equal(6, hull.Count);
        }
    }
}
