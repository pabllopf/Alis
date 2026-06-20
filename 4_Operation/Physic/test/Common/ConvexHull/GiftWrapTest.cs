// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GiftWrapTest.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.ConvexHull;
using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    /// The gift wrap test class
    /// </summary>
    public class GiftWrapTest
    {
        /// <summary>
        /// Tests that gift wrap type should be accessible
        /// </summary>
        [Fact]
        public void GiftWrap_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(GiftWrap));
        }

        /// <summary>
        /// Tests that get convex hull with three points should return same vertices
        /// </summary>
        [Fact]
        public void GetConvexHull_WithThreePoints_ShouldReturnSameVertices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            Vertices hull = GiftWrap.GetConvexHull(vertices);

            Assert.Equal(3, hull.Count);
        }

        /// <summary>
        /// Tests that get convex hull with four points should produce convex result
        /// </summary>
        [Fact]
        public void GetConvexHull_WithFourPoints_ShouldProduceConvexResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            Vertices hull = GiftWrap.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 3);
        }

        /// <summary>
        ///     Tests that get convex hull with collinear points eliminates interior points
        /// </summary>
        [Fact]
        public void GetConvexHull_WithCollinearPoints_EliminatesInteriorPoints()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(5f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f)
            });

            Vertices hull = GiftWrap.GetConvexHull(vertices);

            Assert.Equal(2, hull.Count);
            Assert.Contains(new Vector2F(5f, 0f), hull);
            Assert.Contains(new Vector2F(0f, 0f), hull);
        }
    }
}
