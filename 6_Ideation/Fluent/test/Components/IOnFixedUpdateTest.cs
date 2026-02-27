// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnFixedUpdateTest.cs
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
    ///     Unit tests for the IOnFixedUpdate interface.
    ///     Tests the OnFixedUpdate lifecycle method for physics updates.
    /// </summary>
    public class IOnFixedUpdateTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnFixedUpdate.
        /// </summary>
        private class FixedUpdateHandler : IOnFixedUpdate
        {
            public int CallCount { get; private set; }

            public void OnFixedUpdate(IGameObject self)
            {
                CallCount++;
            }
        }

        /// <summary>
        ///     Tests that IOnFixedUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnFixedUpdate_CanBeImplemented()
        {
            var handler = new FixedUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnFixedUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnFixedUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CanBeCalled()
        {
            var handler = new FixedUpdateHandler();
            var gameObject = new MockGameObject();
            handler.OnFixedUpdate(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnFixedUpdate counts physics frames correctly.
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CountsPhysicsFrames()
        {
            var handler = new FixedUpdateHandler();
            var gameObject = new MockGameObject();
            for (int i = 0; i < 60; i++)
            {
                handler.OnFixedUpdate(gameObject);
            }
            Assert.Equal(60, handler.CallCount);
        }
    }
}

