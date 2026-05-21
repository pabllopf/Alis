// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnAfterFixedUpdateTest.cs
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
    ///     Unit tests for the IOnAfterFixedUpdate lifecycle contract.
    /// </summary>
    public class IOnAfterFixedUpdateTest
    {
        /// <summary>
        ///     Tests that IOnAfterFixedUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnAfterFixedUpdate_CanBeImplemented()
        {
            AfterFixedUpdateHandler handler = new AfterFixedUpdateHandler();

            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAfterFixedUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnAfterFixedUpdate can be called repeatedly.
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_CountsCalls()
        {
            AfterFixedUpdateHandler handler = new AfterFixedUpdateHandler();
            MockGameObject gameObject = new MockGameObject();

            for (int i = 0; i < 5; i++)
            {
                handler.OnAfterFixedUpdate(gameObject);
            }

            Assert.Equal(5, handler.CallCount);
        }

        /// <summary>
        ///     Test implementation for IOnAfterFixedUpdate.
        /// </summary>
        private sealed class AfterFixedUpdateHandler : IOnAfterFixedUpdate
        {
            /// <summary>
            ///     Gets the number of times this lifecycle hook was called.
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Invokes post-fixed-update behavior.
            /// </summary>
            /// <param name="self">The owning game object.</param>
            public void OnAfterFixedUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}
