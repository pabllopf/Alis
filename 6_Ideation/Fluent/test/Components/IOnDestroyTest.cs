// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnDestroyTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnDestroy interface.
    ///     Tests the OnDestroy lifecycle method for cleanup.
    /// </summary>
    public class IOnDestroyTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnDestroy.
        /// </summary>
        private class DestroyHandler : IOnDestroy
        {
            public bool WasDestroyCalled { get; private set; }
            public int DestroyCount { get; private set; }

            public void OnDestroy(IGameObject self)
            {
                WasDestroyCalled = true;
                DestroyCount++;
            }

            public void OnDestroy()
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        ///     Tests that IOnDestroy can be implemented.
        /// </summary>
        [Fact]
        public void IOnDestroy_CanBeImplemented()
        {
            var handler = new DestroyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnDestroy>(handler);
        }

        /// <summary>
        ///     Tests that OnDestroy method can be called.
        /// </summary>
        [Fact]
        public void OnDestroy_CanBeCalled()
        {
            var handler = new DestroyHandler();
            var gameObject = new MockGameObject();
            handler.OnDestroy(gameObject);
            Assert.True(handler.WasDestroyCalled);
        }

        /// <summary>
        ///     Tests that OnDestroy records call count.
        /// </summary>
        [Fact]
        public void OnDestroy_RecordsCallCount()
        {
            var handler = new DestroyHandler();
            var gameObject = new MockGameObject();
            handler.OnDestroy(gameObject);
            Assert.Equal(1, handler.DestroyCount);
        }

        /// <summary>
        ///     Tests that OnDestroy can be called multiple times.
        /// </summary>
        [Fact]
        public void OnDestroy_CanBeCalledMultipleTimes()
        {
            var handler = new DestroyHandler();
            var gameObject = new MockGameObject();
            for (int i = 0; i < 5; i++)
            {
                handler.OnDestroy(gameObject);
            }
            Assert.Equal(5, handler.DestroyCount);
        }
    }
}

