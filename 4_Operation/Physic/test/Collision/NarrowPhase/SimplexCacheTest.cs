// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexCacheTest.cs
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

using Alis.Core.Aspect.Math.Optimization;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The simplex cache test class
    /// </summary>
    public class SimplexCacheTest
    {
        /// <summary>
        ///     Tests that test count property
        /// </summary>
        [Fact]
        public void Test_CountProperty()
        {
            // Arrange
            SimplexCache simplexCache = new SimplexCache();
            ushort expectedValue = 3;
            
            // Act
            simplexCache.Count = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexCache.Count);
        }
        
        /// <summary>
        ///     Tests that test index a property
        /// </summary>
        [Fact]
        public void Test_IndexAProperty()
        {
            // Arrange
            SimplexCache simplexCache = new SimplexCache();
            FixedArray3<byte> expectedValue = new FixedArray3<byte>();
            
            // Act
            simplexCache.IndexA = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexCache.IndexA);
        }
        
        /// <summary>
        ///     Tests that test index b property
        /// </summary>
        [Fact]
        public void Test_IndexBProperty()
        {
            // Arrange
            SimplexCache simplexCache = new SimplexCache();
            FixedArray3<byte> expectedValue = new FixedArray3<byte>();
            
            
            // Act
            simplexCache.IndexB = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexCache.IndexB);
        }
        
        /// <summary>
        ///     Tests that test metric property
        /// </summary>
        [Fact]
        public void Test_MetricProperty()
        {
            // Arrange
            SimplexCache simplexCache = new SimplexCache();
            float expectedValue = 1.5f;
            
            // Act
            simplexCache.Metric = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexCache.Metric);
        }
    }
}