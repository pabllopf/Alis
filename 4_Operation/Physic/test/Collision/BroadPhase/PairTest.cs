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

using Alis.Core.Physic.Collision.BroadPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.BroadPhase
{
    /// <summary>
    ///     The pair test class
    /// </summary>
    public class PairTest
    {
        /// <summary>
        ///     Tests that test proxy id a
        /// </summary>
        [Fact]
        public void TestProxyIdA()
        {
            Pair pair = new Pair
            {
                ProxyIdA = 1
            };
            Assert.Equal(1, pair.ProxyIdA);
        }
        
        /// <summary>
        ///     Tests that test proxy id b
        /// </summary>
        [Fact]
        public void TestProxyIdB()
        {
            Pair pair = new Pair
            {
                ProxyIdB = 2
            };
            Assert.Equal(2, pair.ProxyIdB);
        }
    }
}