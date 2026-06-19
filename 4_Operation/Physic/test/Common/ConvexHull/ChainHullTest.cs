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
    }
}
