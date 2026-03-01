// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AabbTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The aabb test class
    /// </summary>
    public class AabbTest
    {
        /// <summary>
        ///     Tests that constructor with min max should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithMinMax_ShouldInitializeCorrectly()
        {
            Vector2F min = new Vector2F(1.0f, 2.0f);
            Vector2F max = new Vector2F(4.0f, 6.0f);
            
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(min, aabb.LowerBound);
            Assert.Equal(max, aabb.UpperBound);
        }

        /// <summary>
        ///     Tests that constructor with ref min max should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithRefMinMax_ShouldInitializeCorrectly()
        {
            Vector2F min = new Vector2F(1.0f, 2.0f);
            Vector2F max = new Vector2F(4.0f, 6.0f);
            
            Aabb aabb = new Aabb(ref min, ref max);
            
            Assert.Equal(min, aabb.LowerBound);
            Assert.Equal(max, aabb.UpperBound);
        }

        /// <summary>
        ///     Tests that constructor with center width height should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithCenterWidthHeight_ShouldInitializeCorrectly()
        {
            Vector2F center = new Vector2F(5.0f, 5.0f);
            float width = 4.0f;
            float height = 6.0f;
            
            Aabb aabb = new Aabb(center, width, height);
            
            Assert.Equal(new Vector2F(3.0f, 2.0f), aabb.LowerBound);
            Assert.Equal(new Vector2F(7.0f, 8.0f), aabb.UpperBound);
        }

        /// <summary>
        ///     Tests that width should return correct value
        /// </summary>
        [Fact]
        public void Width_ShouldReturnCorrectValue()
        {
            Aabb aabb = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 8.0f));
            
            Assert.Equal(4.0f, aabb.Width);
        }

        /// <summary>
        ///     Tests that height should return correct value
        /// </summary>
        [Fact]
        public void Height_ShouldReturnCorrectValue()
        {
            Aabb aabb = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 8.0f));
            
            Assert.Equal(6.0f, aabb.Height);
        }

        /// <summary>
        ///     Tests that center should return correct value
        /// </summary>
        [Fact]
        public void Center_ShouldReturnCorrectValue()
        {
            Aabb aabb = new Aabb(new Vector2F(2.0f, 4.0f), new Vector2F(6.0f, 10.0f));
            
            Assert.Equal(new Vector2F(4.0f, 7.0f), aabb.Center);
        }

        /// <summary>
        ///     Tests that extents should return correct value
        /// </summary>
        [Fact]
        public void Extents_ShouldReturnCorrectValue()
        {
            Aabb aabb = new Aabb(new Vector2F(2.0f, 4.0f), new Vector2F(6.0f, 10.0f));
            
            Assert.Equal(new Vector2F(2.0f, 3.0f), aabb.Extents);
        }

        /// <summary>
        ///     Tests that perimeter should return correct value
        /// </summary>
        [Fact]
        public void Perimeter_ShouldReturnCorrectValue()
        {
            Aabb aabb = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 8.0f));
            
            float expectedPerimeter = 2.0f * (4.0f + 6.0f);
            Assert.Equal(expectedPerimeter, aabb.Perimeter);
        }

        /// <summary>
        ///     Tests that vertices should return correct corners
        /// </summary>
        [Fact]
        public void Vertices_ShouldReturnCorrectCorners()
        {
            Aabb aabb = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 8.0f));
            
            var vertices = aabb.Vertices;
            
            Assert.Equal(4, vertices.Count);
            Assert.Equal(new Vector2F(5.0f, 8.0f), vertices[0]); // UpperBound
            Assert.Equal(new Vector2F(5.0f, 2.0f), vertices[1]);
            Assert.Equal(new Vector2F(1.0f, 2.0f), vertices[2]); // LowerBound
            Assert.Equal(new Vector2F(1.0f, 8.0f), vertices[3]);
        }

        /// <summary>
        ///     Tests that q 1 should return first quadrant
        /// </summary>
        [Fact]
        public void Q1_ShouldReturnFirstQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            
            Aabb q1 = aabb.Q1;
            
            Assert.Equal(new Vector2F(5.0f, 5.0f), q1.LowerBound);
            Assert.Equal(new Vector2F(10.0f, 10.0f), q1.UpperBound);
        }

        /// <summary>
        ///     Tests that q 2 should return second quadrant
        /// </summary>
        [Fact]
        public void Q2_ShouldReturnSecondQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            
            Aabb q2 = aabb.Q2;
            
            Assert.Equal(new Vector2F(0.0f, 5.0f), q2.LowerBound);
            Assert.Equal(new Vector2F(5.0f, 10.0f), q2.UpperBound);
        }

        /// <summary>
        ///     Tests that q 3 should return third quadrant
        /// </summary>
        [Fact]
        public void Q3_ShouldReturnThirdQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            
            Aabb q3 = aabb.Q3;
            
            Assert.Equal(new Vector2F(0.0f, 0.0f), q3.LowerBound);
            Assert.Equal(new Vector2F(5.0f, 5.0f), q3.UpperBound);
        }

        /// <summary>
        ///     Tests that q 4 should return fourth quadrant
        /// </summary>
        [Fact]
        public void Q4_ShouldReturnFourthQuadrant()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            
            Aabb q4 = aabb.Q4;
            
            Assert.Equal(new Vector2F(5.0f, 0.0f), q4.LowerBound);
            Assert.Equal(new Vector2F(10.0f, 5.0f), q4.UpperBound);
        }

        /// <summary>
        ///     Tests that is valid should return true for valid aabb
        /// </summary>
        [Fact]
        public void IsValid_ShouldReturnTrue_ForValidAabb()
        {
            Aabb aabb = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 8.0f));
            
            Assert.True(aabb.IsValid());
        }

        /// <summary>
        ///     Tests that is valid should return false when upper bound less than lower bound
        /// </summary>
        [Fact]
        public void IsValid_ShouldReturnFalse_WhenUpperBoundLessThanLowerBound()
        {
            Aabb aabb = new Aabb(new Vector2F(5.0f, 8.0f), new Vector2F(1.0f, 2.0f));
            
            Assert.False(aabb.IsValid());
        }

        /// <summary>
        ///     Tests that combine should merge two aabbs
        /// </summary>
        [Fact]
        public void Combine_ShouldMergeTwoAabbs()
        {
            Aabb aabb1 = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 6.0f));
            Aabb aabb2 = new Aabb(new Vector2F(3.0f, 4.0f), new Vector2F(7.0f, 8.0f));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2F(1.0f, 2.0f), aabb1.LowerBound);
            Assert.Equal(new Vector2F(7.0f, 8.0f), aabb1.UpperBound);
        }

        /// <summary>
        ///     Tests that combine with two parameters should merge correctly
        /// </summary>
        [Fact]
        public void Combine_WithTwoParameters_ShouldMergeCorrectly()
        {
            Aabb aabb = new Aabb();
            Aabb aabb1 = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 6.0f));
            Aabb aabb2 = new Aabb(new Vector2F(3.0f, 4.0f), new Vector2F(7.0f, 8.0f));
            
            aabb.Combine(ref aabb1, ref aabb2);
            
            Assert.Equal(new Vector2F(1.0f, 2.0f), aabb.LowerBound);
            Assert.Equal(new Vector2F(7.0f, 8.0f), aabb.UpperBound);
        }

        /// <summary>
        ///     Tests that contains aabb should return true when contained
        /// </summary>
        [Fact]
        public void Contains_Aabb_ShouldReturnTrue_WhenContained()
        {
            Aabb outerAabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            Aabb innerAabb = new Aabb(new Vector2F(2.0f, 2.0f), new Vector2F(8.0f, 8.0f));
            
            Assert.True(outerAabb.Contains(ref innerAabb));
        }

        /// <summary>
        ///     Tests that contains aabb should return false when not contained
        /// </summary>
        [Fact]
        public void Contains_Aabb_ShouldReturnFalse_WhenNotContained()
        {
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(5.0f, 5.0f));
            Aabb aabb2 = new Aabb(new Vector2F(4.0f, 4.0f), new Vector2F(10.0f, 10.0f));
            
            Assert.False(aabb1.Contains(ref aabb2));
        }

        /// <summary>
        ///     Tests that contains point should return true when inside
        /// </summary>
        [Fact]
        public void Contains_Point_ShouldReturnTrue_WhenInside()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            Vector2F point = new Vector2F(5.0f, 5.0f);
            
            Assert.True(aabb.Contains(ref point));
        }

        /// <summary>
        ///     Tests that contains point should return false when outside
        /// </summary>
        [Fact]
        public void Contains_Point_ShouldReturnFalse_WhenOutside()
        {
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
            Vector2F point = new Vector2F(15.0f, 15.0f);
            
            Assert.False(aabb.Contains(ref point));
        }

        /// <summary>
        ///     Tests that test overlap should return true when overlapping
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnTrue_WhenOverlapping()
        {
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(5.0f, 5.0f));
            Aabb aabb2 = new Aabb(new Vector2F(3.0f, 3.0f), new Vector2F(8.0f, 8.0f));
            
            Assert.True(Aabb.TestOverlap(ref aabb1, ref aabb2));
        }

        /// <summary>
        ///     Tests that test overlap should return false when not overlapping
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnFalse_WhenNotOverlapping()
        {
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(5.0f, 5.0f));
            Aabb aabb2 = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(15.0f, 15.0f));
            
            Assert.False(Aabb.TestOverlap(ref aabb1, ref aabb2));
        }

        /// <summary>
        ///     Tests that test overlap should return false when touching edge
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnFalse_WhenTouchingEdge()
        {
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(5.0f, 5.0f));
            Aabb aabb2 = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(10.0f, 10.0f));
            
            Assert.True(Aabb.TestOverlap(ref aabb1, ref aabb2));
        }

        /// <summary>
        ///     Tests that ray cast should return true when hit
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnTrue_WhenHit()
        {
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(10.0f, 10.0f));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 7.5f),
                Point2 = new Vector2F(15.0f, 7.5f),
                MaxFraction = 1.0f
            };
            
            bool hit = aabb.RayCast(out RayCastOutput output, ref input, true);
            
            Assert.True(hit);
        }

        /// <summary>
        ///     Tests that ray cast should return false when miss
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnFalse_WhenMiss()
        {
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(10.0f, 10.0f));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 0.0f),
                Point2 = new Vector2F(3.0f, 0.0f),
                MaxFraction = 1.0f
            };
            
            bool hit = aabb.RayCast(out RayCastOutput output, ref input, true);
            
            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that constructor with zero dimensions should work
        /// </summary>
        [Fact]
        public void Constructor_WithZeroDimensions_ShouldWork()
        {
            Aabb aabb = new Aabb(Vector2F.Zero, Vector2F.Zero);
            
            Assert.Equal(Vector2F.Zero, aabb.LowerBound);
            Assert.Equal(Vector2F.Zero, aabb.UpperBound);
            Assert.Equal(0.0f, aabb.Width);
            Assert.Equal(0.0f, aabb.Height);
        }

        /// <summary>
        ///     Tests that perimeter with zero dimensions should return zero
        /// </summary>
        [Fact]
        public void Perimeter_WithZeroDimensions_ShouldReturnZero()
        {
            Aabb aabb = new Aabb(Vector2F.Zero, Vector2F.Zero);
            
            Assert.Equal(0.0f, aabb.Perimeter);
        }

        /// <summary>
        ///     Tests that combine with same aabb should not change
        /// </summary>
        [Fact]
        public void Combine_WithSameAabb_ShouldNotChange()
        {
            Aabb aabb1 = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 6.0f));
            Aabb aabb2 = new Aabb(new Vector2F(1.0f, 2.0f), new Vector2F(5.0f, 6.0f));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2F(1.0f, 2.0f), aabb1.LowerBound);
            Assert.Equal(new Vector2F(5.0f, 6.0f), aabb1.UpperBound);
        }
    }
}

