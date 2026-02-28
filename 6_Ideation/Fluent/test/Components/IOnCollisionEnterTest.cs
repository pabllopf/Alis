// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnCollisionEnterTest.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnCollisionEnter interface.
    ///     Tests the OnCollisionEnter lifecycle method for collision detection.
    /// </summary>
    public class IOnCollisionEnterTest
    {
        /// <summary>
        ///     Tests that IOnCollisionEnter can be implemented.
        /// </summary>
        [Fact]
        public void IOnCollisionEnter_CanBeImplemented()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnCollisionEnter>(handler);
        }

        /// <summary>
        ///     Tests that OnCollisionEnter method can be called.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_CanBeCalled()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionEnter(self, collision);
            Assert.Equal(1, handler.CollisionCount);
        }

        /// <summary>
        ///     Tests that OnCollisionEnter records collider.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_RecordsCollider()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionEnter(self, collision);
            Assert.Same(collision, handler.LastCollider);
        }

        /// <summary>
        ///     Tests multiple collision events.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_HandlesMultipleCollisions()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision1 = new MockGameObject();
            MockGameObject collision2 = new MockGameObject();
            handler.OnCollisionEnter(self, collision1);
            handler.OnCollisionEnter(self, collision2);
            Assert.Equal(2, handler.CollisionCount);
            Assert.Same(collision2, handler.LastCollider);
        }


        /// <summary>
        ///     Helper implementation for testing IOnCollisionEnter.
        /// </summary>
        private class CollisionEnterHandler : IOnCollisionEnter
        {
            public int CollisionCount { get; private set; }
            public IGameObject LastCollider { get; private set; }

            public void OnCollisionEnter(IGameObject other)
            {
                throw new NotImplementedException();
            }

            public void OnCollisionEnter(IGameObject self, IGameObject collision)
            {
                CollisionCount++;
                LastCollider = collision;
            }
        }
    }
}