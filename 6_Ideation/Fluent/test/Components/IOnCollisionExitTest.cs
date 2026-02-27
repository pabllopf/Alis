// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnCollisionExitTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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
    ///     Unit tests for the IOnCollisionExit interface.
    ///     Tests the OnCollisionExit lifecycle method for collision end detection.
    /// </summary>
    public class IOnCollisionExitTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnCollisionExit.
        /// </summary>
        private class CollisionExitHandler : IOnCollisionExit
        {
            public int ExitCount { get; private set; }

            public void OnCollisionExit(IGameObject self, IGameObject collision)
            {
                ExitCount++;
            }

            public void OnCollisionExit(IGameObject other)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Tests that IOnCollisionExit can be implemented.
        /// </summary>
        [Fact]
        public void IOnCollisionExit_CanBeImplemented()
        {
            var handler = new CollisionExitHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnCollisionExit>(handler);
        }

        /// <summary>
        ///     Tests that OnCollisionExit method can be called.
        /// </summary>
        [Fact]
        public void OnCollisionExit_CanBeCalled()
        {
            var handler = new CollisionExitHandler();
            var self = new MockGameObject();
            var collision = new MockGameObject();
            handler.OnCollisionExit(self, collision);
            Assert.Equal(1, handler.ExitCount);
        }

        /// <summary>
        ///     Tests that OnCollisionExit counts exits.
        /// </summary>
        [Fact]
        public void OnCollisionExit_CountsExits()
        {
            var handler = new CollisionExitHandler();
            var self = new MockGameObject();
            var collision = new MockGameObject();
            handler.OnCollisionExit(self, collision);
            handler.OnCollisionExit(self, collision);
            Assert.Equal(2, handler.ExitCount);
        }
    }
}

