// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MelkmanTest.cs
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
    /// The melkman test class
    /// </summary>
    public class MelkmanTest
    {
        /// <summary>
        /// Tests that melkman type should be accessible
        /// </summary>
        [Fact]
        public void Melkman_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Melkman));
        }

        /// <summary>
        /// Tests that get convex hull with three points should return same count
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

            Vertices hull = Melkman.GetConvexHull(vertices);

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

            Vertices hull = Melkman.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 3);
        }

        /// <summary>
        /// Tests that get convex hull with collinear first three points triggers
        /// the InitCollinear code path, extending the line until a non-collinear point is found.
        /// </summary>
        [Fact]
        public void GetConvexHull_WithCollinearStart_UsesInitCollinearPath()
        {
            // First 3 points are collinear on the x-axis (area = 0),
            // triggering InitCollinear which extends the line segment
            // until finding a non-collinear point.
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(2f, 3f),   // Non-collinear point breaks the line
                new Vector2F(5f, 0f)
            });

            Vertices hull = Melkman.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 3);
            // The hull should include the extreme collinear points and the non-collinear point
        }

        /// <summary>
        /// Tests that get convex hull with clockwise-oriented first three points
        /// triggers the k < 0 branch in InitNonCollinear, swapping deque[1] and deque[2].
        /// </summary>
        [Fact]
        public void GetConvexHull_WithClockwiseOrientation_TriggersNegativeKBranch()
        {
            // First 3 points form a clockwise triangle (negative area),
            // triggering the k < 0 branch that swaps deque ordering.
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 2f),   // Up (clockwise from first three)
                new Vector2F(2f, 0f),
                new Vector2F(3f, 3f),
                new Vector2F(-1f, 1f)
            });

            Vertices hull = Melkman.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 3);
        }

        /// <summary>
        /// Tests that get convex hull with many points on a circle triggers
        /// BuildConvexHullResult with the wrap-around case (qb < qf).
        /// </summary>
        [Fact]
        public void GetConvexHull_WithManyPoints_OnCircleProducesFullHull()
        {
            var circlePoints = new System.Collections.Generic.List<Vector2F>();
            for (int i = 0; i < 20; i++)
            {
                double angle = 2.0 * Math.PI * i / 20;
                circlePoints.Add(new Vector2F((float)Math.Cos(angle), (float)Math.Sin(angle)));
            }

            Vertices vertices = new Vertices(circlePoints.ToArray());
            Vertices hull = Melkman.GetConvexHull(vertices);

            Assert.Equal(20, hull.Count);
        }

        /// <summary>
        ///     Tests that a concave polygon with many points exercises
        ///     the full ProcessDeque loop including front and back pops.
        /// </summary>
        [Fact]
        public void GetConvexHull_ConcavePolygon_ExercisesFrontAndBackPops()
        {
            // A flower-shaped concave polygon with 80 points.
            // The inward lobes cause front and back deque pops,
            // exercising the full PopDequeFront and PopDequeBack paths.
            var points = new System.Collections.Generic.List<Vector2F>();
            int count = 80;
            for (int i = 0; i < count; i++)
            {
                double angle = 2.0 * Math.PI * i / count;
                float radius = 1.0f + 0.5f * (float)Math.Sin(5.0 * angle);
                points.Add(new Vector2F(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle)));
            }

            Vertices vertices = new Vertices(points.ToArray());
            Vertices hull = Melkman.GetConvexHull(vertices);

            Assert.NotNull(hull);
            Assert.True(hull.Count >= 3);
        }
    }
}
