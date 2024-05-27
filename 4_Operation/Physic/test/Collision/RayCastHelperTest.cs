// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastHelperTest.cs
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
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    ///     The ray cast helper test class
    /// </summary>
    public class RayCastHelperTest
    {
        /// <summary>
        ///     Tests that ray cast edge test
        /// </summary>
        [Fact]
        public void RayCastEdgeTest()
        {
            // Initialize variables
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 1);
            bool oneSided = false;
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Call the method under test
            bool result = RayCastHelper.RayCastEdge(ref start, ref end, oneSided, ref input, ref transform, out output);
            
            // Assert the result
            Assert.False(result); // Adjust this based on the expected result
        }
        
        /// <summary>
        ///     Tests that ray cast circle test
        /// </summary>
        [Fact]
        public void RayCastCircleTest()
        {
            // Initialize variables
            Vector2 pos = new Vector2(0, 0);
            float radius = 1.0f;
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Call the method under test
            bool result = RayCastHelper.RayCastCircle(ref pos, radius, ref input, ref transform, out output);
            
            // Assert the result
            Assert.False(result); // Adjust this based on the expected result
        }
        
        /// <summary>
        ///     Tests that ray cast polygon test
        /// </summary>
        [Fact]
        public void RayCastPolygonTest()
        {
            // Initialize variables
            Vertices vertices = new Vertices();
            Vertices normals = new Vertices();
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Call the method under test
            bool result = RayCastHelper.RayCastPolygon(vertices, normals, ref input, ref transform, out output);
            
            // Assert the result
            Assert.False(result); // Adjust this based on the expected result
        }
        
        /// <summary>
        /// Tests that ray cast edge test v 2
        /// </summary>
        [Fact]
        public void RayCastEdgeTest_v2()
        {
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 1);
            bool oneSided = false;
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            bool result = RayCastHelper.RayCastEdge(ref start, ref end, oneSided, ref input, ref transform, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast circle test v 2
        /// </summary>
        [Fact]
        public void RayCastCircleTest_v2()
        {
            Vector2 pos = new Vector2(0, 0);
            float radius = 1.0f;
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            bool result = RayCastHelper.RayCastCircle(ref pos, radius, ref input, ref transform, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast polygon test v 2
        /// </summary>
        [Fact]
        public void RayCastPolygonTest_v2()
        {
            Vertices vertices = new Vertices();
            Vertices normals = new Vertices();
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            bool result = RayCastHelper.RayCastPolygon(vertices, normals, ref input, ref transform, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that transform point test
        /// </summary>
        [Fact]
        public void TransformPointTest()
        {
            Vector2 point = new Vector2(0, 0);
            Transform transform = new Transform();
            
            Vector2 result = RayCastHelper.TransformPoint(point, transform);
            
            Assert.Equal(point, result);
        }
        
        /// <summary>
        /// Tests that calculate numerator test
        /// </summary>
        [Fact]
        public void CalculateNumeratorTest()
        {
            int i = 0;
            Vertices vertices = new Vertices();
            Vertices normals = new Vertices();
            Vector2 p1 = new Vector2(1, 1);
            
           Assert.Throws<ArgumentOutOfRangeException>( () => RayCastHelper.CalculateNumerator(i, vertices, normals, p1));
        }
        
        /// <summary>
        /// Tests that calculate denominator test
        /// </summary>
        [Fact]
        public void CalculateDenominatorTest()
        {
            int i = 0;
            Vertices normals = new Vertices();
            Vector2 d = new Vector2(1, 1);
            
            Assert.Throws<ArgumentOutOfRangeException>( () => RayCastHelper.CalculateDenominator(i, normals, d));
        }
        
        /// <summary>
        /// Tests that process denominator test
        /// </summary>
        [Fact]
        public void ProcessDenominatorTest()
        {
            float lower = 0;
            float upper = 1;
            int index = 0;
            int i = 0;
            float numerator = 0;
            float denominator = 1;
            
            bool result = RayCastHelper.ProcessDenominator(ref lower, ref upper, ref index, i, numerator, denominator);
            
            Assert.True(result);
        }
    }
}