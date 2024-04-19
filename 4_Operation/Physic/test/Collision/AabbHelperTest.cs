// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AabbHelperTest.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The aabb helper test class
    /// </summary>
    public class AabbHelperTest
    {
        /// <summary>
        /// Tests that test compute edge aabb
        /// </summary>
        [Fact]
        public void TestComputeEdgeAabb()
        {
            // Arrange
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 1);
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            AabbHelper.ComputeEdgeAabb(ref start, ref end, ref transform, out aabb);
            
            // Assert
            Assert.Equal(new Vector2(-0.01F,-0.01F), aabb.LowerBound);
           Assert.Equal(new Vector2(0.01F,0.01F), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that test compute circle aabb
        /// </summary>
        [Fact]
        public void TestComputeCircleAabb()
        {
            // Arrange
            Vector2 pos = new Vector2(0, 0);
            float radius = 1.0f;
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            AabbHelper.ComputeCircleAabb(ref pos, radius, ref transform, out aabb);
            
            // Assert
            Assert.Equal(new Vector2(-1, -1), aabb.LowerBound);
            Assert.Equal(new Vector2(1, 1), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that test compute polygon aabb
        /// </summary>
        [Fact]
        public void TestComputePolygonAabb()
        {
            // Arrange
            Vertices vertices = new Vertices
            {
                new Vector2(0, 0),
                new Vector2(1, 1)
            };
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            AabbHelper.ComputePolygonAabb(vertices, ref transform, out aabb);
            
            // Assert
            Assert.Equal(new Vector2(-0.01F,-0.01F), aabb.LowerBound);
            Assert.Equal(new Vector2(0.01F,0.01F), aabb.UpperBound);
        }
    }
}