// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AABBTest.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The aabb test class
    /// </summary>
    public class AabbTest
    {
        /// <summary>
        /// Tests that constructor with min and max should set lower and upper bounds
        /// </summary>
        [Fact]
        public void Constructor_WithMinAndMax_ShouldSetLowerAndUpperBounds()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(1, aabb.LowerBound.X);
            Assert.Equal(2, aabb.LowerBound.Y);
            Assert.Equal(5, aabb.UpperBound.X);
            Assert.Equal(8, aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that constructor with ref min and max should set lower and upper bounds
        /// </summary>
        [Fact]
        public void Constructor_WithRefMinAndMax_ShouldSetLowerAndUpperBounds()
        {
            Vector2F min = new Vector2F(1, 2);
            Vector2F max = new Vector2F(5, 8);
            Aabb aabb = new Aabb(ref min, ref max);

            Assert.Equal(1, aabb.LowerBound.X);
            Assert.Equal(2, aabb.LowerBound.Y);
            Assert.Equal(5, aabb.UpperBound.X);
            Assert.Equal(8, aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that constructor with center and dimensions should set bounds correctly
        /// </summary>
        [Fact]
        public void Constructor_WithCenterAndDimensions_ShouldSetBoundsCorrectly()
        {
            Aabb aabb = new Aabb(new Vector2F(5, 5), 10, 6);

            Assert.Equal(0, aabb.LowerBound.X);
            Assert.Equal(2, aabb.LowerBound.Y);
            Assert.Equal(10, aabb.UpperBound.X);
            Assert.Equal(8, aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that width should return difference between upper and lower x
        /// </summary>
        [Fact]
        public void Width_ShouldReturnDifferenceBetweenUpperAndLowerX()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(4, aabb.Width);
        }

        /// <summary>
        /// Tests that height should return difference between upper and lower y
        /// </summary>
        [Fact]
        public void Height_ShouldReturnDifferenceBetweenUpperAndLowerY()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(6, aabb.Height);
        }

        /// <summary>
        /// Tests that center should return midpoint between lower and upper
        /// </summary>
        [Fact]
        public void Center_ShouldReturnMidpoint()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(3, aabb.Center.X);
            Assert.Equal(5, aabb.Center.Y);
        }

        /// <summary>
        /// Tests that extents should return half the width and height
        /// </summary>
        [Fact]
        public void Extents_ShouldReturnHalfWidthAndHeight()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(2, aabb.Extents.X);
            Assert.Equal(3, aabb.Extents.Y);
        }

        /// <summary>
        /// Tests that perimeter should return twice width plus height
        /// </summary>
        [Fact]
        public void Perimeter_ShouldReturnTwiceWidthPlusHeight()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));

            Assert.Equal(20, aabb.Perimeter);
        }

        /// <summary>
        /// Tests that vertices should return four corners in correct order
        /// </summary>
        [Fact]
        public void Vertices_ShouldReturnFourCorners()
        {
            Aabb aabb = new Aabb(new Vector2F(1, 2), new Vector2F(5, 8));
            Vertices vertices = aabb.Vertices;

            Assert.Equal(4, vertices.Count);
            Assert.Equal(new Vector2F(5, 8), vertices[0]);
            Assert.Equal(new Vector2F(5, 2), vertices[1]);
            Assert.Equal(new Vector2F(1, 2), vertices[2]);
            Assert.Equal(new Vector2F(1, 8), vertices[3]);
        }

        /// <summary>
        /// Tests that q1 should return top right quadrant
        /// </summary>
        [Fact]
        public void Q1_ShouldReturnTopRightQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb q1 = aabb.Q1;

            Assert.Equal(5, q1.LowerBound.X);
            Assert.Equal(5, q1.LowerBound.Y);
            Assert.Equal(10, q1.UpperBound.X);
            Assert.Equal(10, q1.UpperBound.Y);
        }

        /// <summary>
        /// Tests that q2 should return top left quadrant
        /// </summary>
        [Fact]
        public void Q2_ShouldReturnTopLeftQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb q2 = aabb.Q2;

            Assert.Equal(0, q2.LowerBound.X);
            Assert.Equal(5, q2.LowerBound.Y);
            Assert.Equal(5, q2.UpperBound.X);
            Assert.Equal(10, q2.UpperBound.Y);
        }

        /// <summary>
        /// Tests that q3 should return bottom left quadrant
        /// </summary>
        [Fact]
        public void Q3_ShouldReturnBottomLeftQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb q3 = aabb.Q3;

            Assert.Equal(0, q3.LowerBound.X);
            Assert.Equal(0, q3.LowerBound.Y);
            Assert.Equal(5, q3.UpperBound.X);
            Assert.Equal(5, q3.UpperBound.Y);
        }

        /// <summary>
        /// Tests that q4 should return bottom right quadrant
        /// </summary>
        [Fact]
        public void Q4_ShouldReturnBottomRightQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb q4 = aabb.Q4;

            Assert.Equal(5, q4.LowerBound.X);
            Assert.Equal(0, q4.LowerBound.Y);
            Assert.Equal(10, q4.UpperBound.X);
            Assert.Equal(5, q4.UpperBound.Y);
        }

        /// <summary>
        /// Tests that is valid should return true for valid aabb
        /// </summary>
        [Fact]
        public void IsValid_WithValidAabb_ShouldReturnTrue()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));

            Assert.True(aabb.IsValid());
        }

        /// <summary>
        /// Tests that is valid should return false when lower bound is greater than upper bound in x
        /// </summary>
        [Fact]
        public void IsValid_WhenLowerXGreaterThanUpperX_ShouldReturnFalse()
        {
            Aabb aabb = new Aabb(new Vector2F(10, 0), new Vector2F(5, 10));

            Assert.False(aabb.IsValid());
        }

        /// <summary>
        /// Tests that is valid should return false when lower bound is greater than upper bound in y
        /// </summary>
        [Fact]
        public void IsValid_WhenLowerYGreaterThanUpperY_ShouldReturnFalse()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 10), new Vector2F(10, 5));

            Assert.False(aabb.IsValid());
        }

        /// <summary>
        /// Tests that combine with another aabb should expand bounds
        /// </summary>
        [Fact]
        public void Combine_WithAnotherAabb_ShouldExpandBounds()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb other = new Aabb(new Vector2F(3, 3), new Vector2F(10, 10));

            aabb.Combine(ref other);

            Assert.Equal(0, aabb.LowerBound.X);
            Assert.Equal(0, aabb.LowerBound.Y);
            Assert.Equal(10, aabb.UpperBound.X);
            Assert.Equal(10, aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that combine with two aabbs should set bounds to union
        /// </summary>
        [Fact]
        public void Combine_WithTwoAabbs_ShouldSetBoundsToUnion()
        {
            Aabb aabb = new Aabb();
            Aabb aabb1 = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb aabb2 = new Aabb(new Vector2F(3, 3), new Vector2F(10, 10));

            aabb.Combine(ref aabb1, ref aabb2);

            Assert.Equal(0, aabb.LowerBound.X);
            Assert.Equal(0, aabb.LowerBound.Y);
            Assert.Equal(10, aabb.UpperBound.X);
            Assert.Equal(10, aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that contains with smaller aabb should return true
        /// </summary>
        [Fact]
        public void Contains_WithSmallerAabb_ShouldReturnTrue()
        {
            Aabb outer = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb inner = new Aabb(new Vector2F(2, 2), new Vector2F(8, 8));

            Assert.True(outer.Contains(ref inner));
        }

        /// <summary>
        /// Tests that contains with larger aabb should return false
        /// </summary>
        [Fact]
        public void Contains_WithLargerAabb_ShouldReturnFalse()
        {
            Aabb outer = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb larger = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));

            Assert.False(outer.Contains(ref larger));
        }

        /// <summary>
        /// Tests that contains with partially overlapping aabb should return false
        /// </summary>
        [Fact]
        public void Contains_WithPartiallyOverlappingAabb_ShouldReturnFalse()
        {
            Aabb outer = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb overlapping = new Aabb(new Vector2F(5, 5), new Vector2F(15, 15));

            Assert.False(outer.Contains(ref overlapping));
        }

        /// <summary>
        /// Tests that contains point inside should return true
        /// </summary>
        [Fact]
        public void Contains_PointInside_ShouldReturnTrue()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Vector2F point = new Vector2F(5, 5);

            Assert.True(aabb.Contains(ref point));
        }

        /// <summary>
        /// Tests that contains point outside should return false
        /// </summary>
        [Fact]
        public void Contains_PointOutside_ShouldReturnFalse()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Vector2F point = new Vector2F(15, 5);

            Assert.False(aabb.Contains(ref point));
        }

        /// <summary>
        /// Tests that contains point on lower bound edge should return false (exclusive)
        /// </summary>
        [Fact]
        public void Contains_PointOnLowerBoundEdge_ShouldReturnFalse()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Vector2F point = new Vector2F(0, 5);

            Assert.False(aabb.Contains(ref point));
        }

        /// <summary>
        /// Tests that contains point on upper bound edge should return false (exclusive)
        /// </summary>
        [Fact]
        public void Contains_PointOnUpperBoundEdge_ShouldReturnFalse()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Vector2F point = new Vector2F(10, 5);

            Assert.False(aabb.Contains(ref point));
        }

        /// <summary>
        /// Tests that test overlap with overlapping aabbs should return true
        /// </summary>
        [Fact]
        public void TestOverlap_WithOverlappingAabbs_ShouldReturnTrue()
        {
            Aabb a = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb b = new Aabb(new Vector2F(3, 3), new Vector2F(8, 8));

            Assert.True(Aabb.TestOverlap(ref a, ref b));
        }

        /// <summary>
        /// Tests that test overlap with non overlapping aabbs should return false
        /// </summary>
        [Fact]
        public void TestOverlap_WithNonOverlappingAabbs_ShouldReturnFalse()
        {
            Aabb a = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb b = new Aabb(new Vector2F(10, 10), new Vector2F(15, 15));

            Assert.False(Aabb.TestOverlap(ref a, ref b));
        }

        /// <summary>
        /// Tests that test overlap with aabbs touching at edge should return true (contact convention)
        /// </summary>
        [Fact]
        public void TestOverlap_WithTouchingAabbs_ShouldReturnTrue()
        {
            Aabb a = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb b = new Aabb(new Vector2F(5, 0), new Vector2F(10, 5));

            Assert.True(Aabb.TestOverlap(ref a, ref b));
        }

        /// <summary>
        /// Tests that test overlap with identical aabbs should return true
        /// </summary>
        [Fact]
        public void TestOverlap_WithIdenticalAabbs_ShouldReturnTrue()
        {
            Aabb a = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));
            Aabb b = new Aabb(new Vector2F(0, 0), new Vector2F(5, 5));

            Assert.True(Aabb.TestOverlap(ref a, ref b));
        }

        /// <summary>
        /// Tests that test overlap with one inside the other should return true
        /// </summary>
        [Fact]
        public void TestOverlap_WithOneInsideOther_ShouldReturnTrue()
        {
            Aabb outer = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            Aabb inner = new Aabb(new Vector2F(2, 2), new Vector2F(8, 8));

            Assert.True(Aabb.TestOverlap(ref outer, ref inner));
        }

        /// <summary>
        /// Tests that ray cast with ray through center should hit
        /// </summary>
        [Fact]
        public void RayCast_WithRayThroughCenter_ShouldHit()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5, 5),
                Point2 = new Vector2F(15, 5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.True(hit);
            Assert.True(output.Fraction >= 0);
        }

        /// <summary>
        /// Tests that ray cast with ray completely to the left should miss
        /// </summary>
        [Fact]
        public void RayCast_WithRayCompletelyToLeft_ShouldMiss()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-15, -5),
                Point2 = new Vector2F(-5, -5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.False(hit);
        }

        /// <summary>
        /// Tests that ray cast with ray starting inside should miss by default (interior check)
        /// </summary>
        [Fact]
        public void RayCast_WithRayStartingInside_ShouldMiss()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 5),
                Point2 = new Vector2F(15, 5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.False(hit);
        }

        /// <summary>
        /// Tests that ray cast with ray hitting from above should hit
        /// </summary>
        [Fact]
        public void RayCast_WithRayHittingFromAbove_ShouldHit()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 15),
                Point2 = new Vector2F(5, -5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.True(hit);
        }

        /// <summary>
        /// Tests that ray cast with zero length ray inside should miss (do interior check)
        /// </summary>
        [Fact]
        public void RayCast_WithZeroLengthRayInside_ShouldMiss()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 5),
                Point2 = new Vector2F(5, 5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.False(hit);
        }

        /// <summary>
        /// Tests that ray cast with do interior check false and starting inside should hit
        /// </summary>
        [Fact]
        public void RayCast_WithDoInteriorCheckFalse_ShouldHitWhenStartingInside()
        {
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 5),
                Point2 = new Vector2F(15, 5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input, false);

            Assert.True(hit);
        }

        /// <summary>
        /// Tests that ray cast with ray parallel to x axis through the box should hit
        /// </summary>
        [Fact]
        public void RayCast_WithRayParallelToXAxis_ShouldHit()
        {
            Aabb aabb = new Aabb(new Vector2F(2, 2), new Vector2F(8, 8));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0, 5),
                Point2 = new Vector2F(10, 5),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.True(hit);
        }

        /// <summary>
        /// Tests that ray cast with ray parallel to y axis through the box should hit
        /// </summary>
        [Fact]
        public void RayCast_WithRayParallelToYAxis_ShouldHit()
        {
            Aabb aabb = new Aabb(new Vector2F(2, 2), new Vector2F(8, 8));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 0),
                Point2 = new Vector2F(5, 10),
                MaxFraction = 1.0f
            };

            bool hit = aabb.RayCast(out RayCastOutput output, ref input);

            Assert.True(hit);
        }
    }
}
