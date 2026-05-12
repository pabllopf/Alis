// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnBeforeFixedUpdateTest.cs
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
    ///     Unit tests for the IOnBeforeFixedUpdate lifecycle contract.
    /// </summary>
    public class IOnBeforeFixedUpdateTest
    {
        /// <summary>
        ///     Tests that IOnBeforeFixedUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnBeforeFixedUpdate_CanBeImplemented()
        {
            BeforeFixedUpdateHandler handler = new BeforeFixedUpdateHandler();

            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnBeforeFixedUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnBeforeFixedUpdate can be called multiple times.
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_CountsCalls()
        {
            BeforeFixedUpdateHandler handler = new BeforeFixedUpdateHandler();
            MockGameObject gameObject = new MockGameObject();

            handler.OnBeforeFixedUpdate(gameObject);
            handler.OnBeforeFixedUpdate(gameObject);
            handler.OnBeforeFixedUpdate(gameObject);

            Assert.Equal(3, handler.CallCount);
        }

        /// <summary>
        ///     Test implementation for IOnBeforeFixedUpdate.
        /// </summary>
        private sealed class BeforeFixedUpdateHandler : IOnBeforeFixedUpdate
        {
            /// <summary>
            ///     Gets the number of times this lifecycle hook was called.
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Invokes pre-fixed-update behavior.
            /// </summary>
            /// <param name="self">The owning game object.</param>
            public void OnBeforeFixedUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}
