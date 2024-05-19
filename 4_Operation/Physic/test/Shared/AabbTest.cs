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
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Shared
{
    /// <summary>
    /// The aabb test class
    /// </summary>
    public class AabbTest
    {
        /// <summary>
        /// Tests that aabb with valid parameters does not throw exception
        /// </summary>
        [Fact]
        public void Aabb_WithValidParameters_DoesNotThrowException()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            
            var ex = Record.Exception(() => new Aabb(min, max));
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that width property set get returns correct value
        /// </summary>
        [Fact]
        public void Width_PropertySet_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(10.0f, aabb.Width);
        }
        
        /// <summary>
        /// Tests that height property set get returns correct value
        /// </summary>
        [Fact]
        public void Height_PropertySet_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(10.0f, aabb.Height);
        }
        
        /// <summary>
        /// Tests that center property set get returns correct value
        /// </summary>
        [Fact]
        public void Center_PropertySet_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(new Vector2(5, 5), aabb.Center);
        }
        
        /// <summary>
        /// Tests that extents property set get returns correct value
        /// </summary>
        [Fact]
        public void Extents_PropertySet_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(new Vector2(5, 5), aabb.Extents);
        }
        
        /// <summary>
        /// Tests that perimeter property set get returns correct value
        /// </summary>
        [Fact]
        public void Perimeter_PropertySet_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.Equal(40.0f, aabb.Perimeter);
        }
        
        /// <summary>
        /// Tests that is valid with valid aabb returns true
        /// </summary>
        [Fact]
        public void IsValid_WithValidAabb_ReturnsTrue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Assert.True(aabb.IsValid());
        }
        
        /// <summary>
        /// Tests that contains with contained aabb returns true
        /// </summary>
        [Fact]
        public void Contains_WithContainedAabb_ReturnsTrue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Vector2 minInner = new Vector2(2, 2);
            Vector2 maxInner = new Vector2(8, 8);
            Aabb innerAabb = new Aabb(minInner, maxInner);
            
            Assert.True(aabb.Contains(ref innerAabb));
        }
        
        /// <summary>
        /// Tests that contains with non contained aabb returns false
        /// </summary>
        [Fact]
        public void Contains_WithNonContainedAabb_ReturnsFalse()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Vector2 minOuter = new Vector2(-2, -2);
            Vector2 maxOuter = new Vector2(12, 12);
            Aabb outerAabb = new Aabb(minOuter, maxOuter);
            
            Assert.False(aabb.Contains(ref outerAabb));
        }
        
        /// <summary>
        /// Tests that test overlap with overlapping aabbs returns true
        /// </summary>
        [Fact]
        public void TestOverlap_WithOverlappingAabbs_ReturnsTrue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb1 = new Aabb(min, max);
            
            Vector2 minOverlap = new Vector2(5, 5);
            Vector2 maxOverlap = new Vector2(15, 15);
            Aabb aabb2 = new Aabb(minOverlap, maxOverlap);
            
            Assert.True(Aabb.TestOverlap(ref aabb1, ref aabb2));
        }
        
        /// <summary>
        /// Tests that test overlap with non overlapping aabbs returns false
        /// </summary>
        [Fact]
        public void TestOverlap_WithNonOverlappingAabbs_ReturnsFalse()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb1 = new Aabb(min, max);
            
            Vector2 minNoOverlap = new Vector2(15, 15);
            Vector2 maxNoOverlap = new Vector2(25, 25);
            Aabb aabb2 = new Aabb(minNoOverlap, maxNoOverlap);
            
            Assert.False(Aabb.TestOverlap(ref aabb1, ref aabb2));
        }
        
        /// <summary>
        /// Tests that q 1 property get returns correct value
        /// </summary>
        [Fact]
        public void Q1_Property_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Aabb expected = new Aabb(new Vector2(5, 5), new Vector2(10, 10));
            Assert.Equal(expected, aabb.Q1);
        }
        
        /// <summary>
        /// Tests that q 2 property get returns correct value
        /// </summary>
        [Fact]
        public void Q2_Property_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Aabb expected = new Aabb(new Vector2(0, 5), new Vector2(5, 10));
            Assert.Equal(expected, aabb.Q2);
        }
        
        /// <summary>
        /// Tests that q 3 property get returns correct value
        /// </summary>
        [Fact]
        public void Q3_Property_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Aabb expected = new Aabb(new Vector2(0, 0), new Vector2(5, 5));
            Assert.Equal(expected, aabb.Q3);
        }
        
        /// <summary>
        /// Tests that q 4 property get returns correct value
        /// </summary>
        [Fact]
        public void Q4_Property_GetReturnsCorrectValue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Aabb expected = new Aabb(new Vector2(5, 0), new Vector2(10, 5));
            Assert.Equal(expected, aabb.Q4);
        }
        
        /// <summary>
        /// Tests that aabb constructor with center width height creates correct aabb
        /// </summary>
        [Fact]
        public void Aabb_ConstructorWithCenterWidthHeight_CreatesCorrectAabb()
        {
            Vector2 center = new Vector2(5, 5);
            float width = 10;
            float height = 10;
            
            Aabb aabb = new Aabb(center, width, height);
            
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
            Assert.Equal(new Vector2(10, 10), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that aabb constructor with center width height creates aabb with correct width
        /// </summary>
        [Fact]
        public void Aabb_ConstructorWithCenterWidthHeight_CreatesAabbWithCorrectWidth()
        {
            Vector2 center = new Vector2(5, 5);
            float width = 10;
            float height = 10;
            
            Aabb aabb = new Aabb(center, width, height);
            
            Assert.Equal(width, aabb.Width);
        }
        
        /// <summary>
        /// Tests that aabb constructor with center width height creates aabb with correct height
        /// </summary>
        [Fact]
        public void Aabb_ConstructorWithCenterWidthHeight_CreatesAabbWithCorrectHeight()
        {
            Vector2 center = new Vector2(5, 5);
            float width = 10;
            float height = 10;
            
            Aabb aabb = new Aabb(center, width, height);
            
            Assert.Equal(height, aabb.Height);
        }
        
        /// <summary>
        /// Tests that aabb constructor with center width height creates aabb with correct center
        /// </summary>
        [Fact]
        public void Aabb_ConstructorWithCenterWidthHeight_CreatesAabbWithCorrectCenter()
        {
            Vector2 center = new Vector2(5, 5);
            float width = 10;
            float height = 10;
            
            Aabb aabb = new Aabb(center, width, height);
            
            Assert.Equal(center, aabb.Center);
        }
        
        /// <summary>
        /// Tests that combine with non overlapping aabbs creates correct aabb
        /// </summary>
        [Fact]
        public void Combine_WithNonOverlappingAabbs_CreatesCorrectAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb2 = new Aabb(new Vector2(20, 20), new Vector2(30, 30));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb1.LowerBound);
            Assert.Equal(new Vector2(30, 30), aabb1.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with overlapping aabbs creates correct aabb
        /// </summary>
        [Fact]
        public void Combine_WithOverlappingAabbs_CreatesCorrectAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb2 = new Aabb(new Vector2(5, 5), new Vector2(15, 15));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb1.LowerBound);
            Assert.Equal(new Vector2(15, 15), aabb1.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with contained aabb unchanged aabb
        /// </summary>
        [Fact]
        public void Combine_WithContainedAabb_UnchangedAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb2 = new Aabb(new Vector2(2, 2), new Vector2(8, 8));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb1.LowerBound);
            Assert.Equal(new Vector2(10, 10), aabb1.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with containing aabb updates aabb
        /// </summary>
        [Fact]
        public void Combine_WithContainingAabb_UpdatesAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(2, 2), new Vector2(8, 8));
            Aabb aabb2 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            
            aabb1.Combine(ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb1.LowerBound);
            Assert.Equal(new Vector2(10, 10), aabb1.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with two aabbs creates correct aabb
        /// </summary>
        [Fact]
        public void Combine_WithTwoAabbs_CreatesCorrectAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb2 = new Aabb(new Vector2(5, 5), new Vector2(15, 15));
            Aabb aabb = new Aabb(new Vector2(0, 0), new Vector2(0, 0));
            
            aabb.Combine(ref aabb1, ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
            Assert.Equal(new Vector2(15, 15), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with two aabbs one inside another creates correct aabb
        /// </summary>
        [Fact]
        public void Combine_WithTwoAabbsOneInsideAnother_CreatesCorrectAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb2 = new Aabb(new Vector2(2, 2), new Vector2(8, 8));
            Aabb aabb = new Aabb(new Vector2(0, 0), new Vector2(0, 0));
            
            aabb.Combine(ref aabb1, ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
            Assert.Equal(new Vector2(10, 10), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that combine with two aabbs one contains another creates correct aabb
        /// </summary>
        [Fact]
        public void Combine_WithTwoAabbsOneContainsAnother_CreatesCorrectAabb()
        {
            Aabb aabb1 = new Aabb(new Vector2(2, 2), new Vector2(8, 8));
            Aabb aabb2 = new Aabb(new Vector2(0, 0), new Vector2(10, 10));
            Aabb aabb = new Aabb(new Vector2(0, 0), new Vector2(0, 0));
            
            aabb.Combine(ref aabb1, ref aabb2);
            
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
            Assert.Equal(new Vector2(10, 10), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that contains with point inside aabb returns true
        /// </summary>
        [Fact]
        public void Contains_WithPointInsideAabb_ReturnsTrue()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Vector2 point = new Vector2(5, 5);
            
            Assert.True(aabb.Contains(ref point));
        }
        
        /// <summary>
        /// Tests that contains with point outside aabb returns false
        /// </summary>
        [Fact]
        public void Contains_WithPointOutsideAabb_ReturnsFalse()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Vector2 point = new Vector2(15, 15);
            
            Assert.False(aabb.Contains(ref point));
        }
        
        /// <summary>
        /// Tests that contains with point on aabb boundary returns false
        /// </summary>
        [Fact]
        public void Contains_WithPointOnAabbBoundary_ReturnsFalse()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(10, 10);
            Aabb aabb = new Aabb(min, max);
            
            Vector2 point = new Vector2(10, 10);
            
            Assert.False(aabb.Contains(ref point));
        }
    }
}