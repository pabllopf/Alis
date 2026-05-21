// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The dynamic tree test class
    /// </summary>
    public class DynamicTreeTest
    {
        /// <summary>
        /// Tests that add proxy set user data get user data should round trip
        /// </summary>
        [Fact]
        public void AddProxy_SetUserData_GetUserData_ShouldRoundTrip()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 123);

            Assert.Equal(123, tree.GetUserData(proxyId));
            Assert.True(tree.Height >= 0);
        }

        /// <summary>
        /// Tests that query should return inserted proxy
        /// </summary>
        [Fact]
        public void Query_ShouldReturnInsertedProxy()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 7);

            List<int> hits = new List<int>();
            tree.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref aabb);

            Assert.Contains(proxyId, hits);
        }

        /// <summary>
        /// Tests that move proxy should return false when new aabb is inside fat aabb
        /// </summary>
        [Fact]
        public void MoveProxy_ShouldReturnFalse_WhenNewAabbIsInsideFatAabb()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            bool moved = tree.MoveProxy(proxyId, ref aabb, Vector2F.Zero);

            Assert.False(moved);
        }

        /// <summary>
        /// Tests that remove proxy should keep tree operational
        /// </summary>
        [Fact]
        public void RemoveProxy_ShouldKeepTreeOperational()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            tree.RemoveProxy(proxyId);

            Assert.Equal(0, tree.Height);
        }
    }
}

