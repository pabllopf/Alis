// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PairTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The pair test class
    /// </summary>
    public class PairTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            Pair pair = new Pair();
            
            Assert.Equal(0, pair.ProxyIdA);
            Assert.Equal(0, pair.ProxyIdB);
        }

        /// <summary>
        ///     Tests that proxy id a property should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyIdAProperty_ShouldSetAndGetCorrectly()
        {
            Pair pair = new Pair
            {
                ProxyIdA = 100
            };
            
            Assert.Equal(100, pair.ProxyIdA);
        }

        /// <summary>
        ///     Tests that proxy id b property should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyIdBProperty_ShouldSetAndGetCorrectly()
        {
            Pair pair = new Pair
            {
                ProxyIdB = 200
            };
            
            Assert.Equal(200, pair.ProxyIdB);
        }

        /// <summary>
        ///     Tests that compare to should return negative when proxy id b is less
        /// </summary>
        [Fact]
        public void CompareTo_ShouldReturnNegative_WhenProxyIdBIsLess()
        {
            Pair pair1 = new Pair { ProxyIdA = 1, ProxyIdB = 5 };
            Pair pair2 = new Pair { ProxyIdA = 1, ProxyIdB = 10 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare to should return positive when proxy id b is greater
        /// </summary>
        [Fact]
        public void CompareTo_ShouldReturnPositive_WhenProxyIdBIsGreater()
        {
            Pair pair1 = new Pair { ProxyIdA = 1, ProxyIdB = 15 };
            Pair pair2 = new Pair { ProxyIdA = 1, ProxyIdB = 10 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.True(result > 0);
        }

        /// <summary>
        ///     Tests that compare to should return negative when proxy id a is less and proxy id b is equal
        /// </summary>
        [Fact]
        public void CompareTo_ShouldReturnNegative_WhenProxyIdAIsLessAndProxyIdBIsEqual()
        {
            Pair pair1 = new Pair { ProxyIdA = 5, ProxyIdB = 10 };
            Pair pair2 = new Pair { ProxyIdA = 8, ProxyIdB = 10 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare to should return zero when both pairs are equal
        /// </summary>
        [Fact]
        public void CompareTo_ShouldReturnZero_WhenBothPairsAreEqual()
        {
            Pair pair1 = new Pair { ProxyIdA = 5, ProxyIdB = 10 };
            Pair pair2 = new Pair { ProxyIdA = 5, ProxyIdB = 10 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that compare to should return positive when proxy id a is greater and proxy id b is equal
        /// </summary>
        [Fact]
        public void CompareTo_ShouldReturnPositive_WhenProxyIdAIsGreaterAndProxyIdBIsEqual()
        {
            Pair pair1 = new Pair { ProxyIdA = 15, ProxyIdB = 10 };
            Pair pair2 = new Pair { ProxyIdA = 8, ProxyIdB = 10 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.True(result > 0);
        }

        /// <summary>
        ///     Tests that pair should support negative proxy ids
        /// </summary>
        [Fact]
        public void Pair_ShouldSupportNegativeProxyIds()
        {
            Pair pair = new Pair
            {
                ProxyIdA = -5,
                ProxyIdB = -10
            };
            
            Assert.Equal(-5, pair.ProxyIdA);
            Assert.Equal(-10, pair.ProxyIdB);
        }

        /// <summary>
        ///     Tests that pair should be value type
        /// </summary>
        [Fact]
        public void Pair_ShouldBeValueType()
        {
            Pair pair1 = new Pair { ProxyIdA = 1, ProxyIdB = 2 };
            Pair pair2 = pair1;
            
            pair2.ProxyIdA = 10;
            
            Assert.NotEqual(pair1.ProxyIdA, pair2.ProxyIdA);
        }

        /// <summary>
        ///     Tests that compare to should handle zero values
        /// </summary>
        [Fact]
        public void CompareTo_ShouldHandleZeroValues()
        {
            Pair pair1 = new Pair { ProxyIdA = 0, ProxyIdB = 0 };
            Pair pair2 = new Pair { ProxyIdA = 0, ProxyIdB = 0 };
            
            int result = pair1.CompareTo(pair2);
            
            Assert.Equal(0, result);
        }
    }
}

