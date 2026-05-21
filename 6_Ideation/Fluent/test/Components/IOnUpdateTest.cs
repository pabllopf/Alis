// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdateTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnUpdate interface.
    ///     Tests the OnUpdate lifecycle method invocation.
    /// </summary>
    public class IOnUpdateTest
    {
        /// <summary>
        ///     Tests that IOnUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnUpdate_CanBeImplemented()
        {
            UpdateHandler handler = new UpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnUpdate_CanBeCalled()
        {
            UpdateHandler handler = new UpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnUpdate(gameObject);
            Assert.True(handler.WasUpdateCalled);
        }

        /// <summary>
        ///     Tests that OnUpdate increments correctly on multiple calls.
        /// </summary>
        [Fact]
        public void OnUpdate_CountsMultipleCalls()
        {
            UpdateHandler handler = new UpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 10; i++)
            {
                handler.OnUpdate(gameObject);
            }

            Assert.Equal(10, handler.UpdateCount);
        }

        /// <summary>
        ///     Tests repeated update calls.
        /// </summary>
        [Theory, InlineData(1), InlineData(5), InlineData(100)]
        public void OnUpdate_HandlesRepeatedCalls(int callCount)
        {
            UpdateHandler handler = new UpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < callCount; i++)
            {
                handler.OnUpdate(gameObject);
            }

            Assert.Equal(callCount, handler.UpdateCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnUpdate.
        /// </summary>
        private class UpdateHandler : IOnUpdate
        {
            /// <summary>
            ///     Gets or sets the value of the was update called
            /// </summary>
            public bool WasUpdateCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the update count
            /// </summary>
            public int UpdateCount { get; private set; }

            /// <summary>
            ///     Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
                WasUpdateCalled = true;
                UpdateCount++;
            }
        }
    }
}