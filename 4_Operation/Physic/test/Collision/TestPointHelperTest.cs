// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestPointHelperTest.cs
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
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    ///     The test point helper test class
    /// </summary>
    public class TestPointHelperTest
    {
        /// <summary>
        ///     Tests that test point circle test
        /// </summary>
        [Fact]
        public void TestPointCircleTest()
        {
            // Initialize variables
            Vector2 pos = new Vector2(0, 0);
            float radius = 1.0f;
            Vector2 point = new Vector2(1, 1);
            Transform transform = new Transform();
            
            // Call the method under test
            bool result = TestPointHelper.TestPointCircle(ref pos, radius, ref point, ref transform);
            
            // Assert the result
            Assert.False(result); // Adjust this based on the expected result
        }
        
        /// <summary>
        ///     Tests that test point polygon test
        /// </summary>
        [Fact]
        public void TestPointPolygonTest()
        {
            // Initialize variables
            Vertices vertices = new Vertices();
            Vertices normals = new Vertices();
            Vector2 point = new Vector2(1, 1);
            Transform transform = new Transform();
            
            // Call the method under test
            bool result = TestPointHelper.TestPointPolygon(vertices, normals, ref point, ref transform);
            
            // Assert the result
            Assert.True(result); // Adjust this based on the expected result
        }
    }
}