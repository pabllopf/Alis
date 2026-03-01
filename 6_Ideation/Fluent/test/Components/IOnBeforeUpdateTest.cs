// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnBeforeUpdateTest.cs
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
    ///     Unit tests for the IOnBeforeUpdate interface.
    ///     Tests the OnBeforeUpdate lifecycle method for pre-update logic.
    /// </summary>
    public class IOnBeforeUpdateTest
    {
        /// <summary>
        ///     Tests that IOnBeforeUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnBeforeUpdate_CanBeImplemented()
        {
            BeforeUpdateHandler handler = new BeforeUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnBeforeUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnBeforeUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_CanBeCalled()
        {
            BeforeUpdateHandler handler = new BeforeUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnBeforeUpdate(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnBeforeUpdate counts calls.
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_CountsCalls()
        {
            BeforeUpdateHandler handler = new BeforeUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 5; i++)
            {
                handler.OnBeforeUpdate(gameObject);
            }

            Assert.Equal(5, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnBeforeUpdate.
        /// </summary>
        private class BeforeUpdateHandler : IOnBeforeUpdate
        {
            /// <summary>
            /// Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            /// Ons the before update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnBeforeUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}