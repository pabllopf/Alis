// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnAfterUpdateTest.cs
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
    ///     Unit tests for the IOnAfterUpdate interface.
    ///     Tests the OnAfterUpdate lifecycle method for post-update logic.
    /// </summary>
    public class IOnAfterUpdateTest
    {
        /// <summary>
        ///     Tests that IOnAfterUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnAfterUpdate_CanBeImplemented()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAfterUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnAfterUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CanBeCalled()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAfterUpdate(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnAfterUpdate counts calls.
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CountsCalls()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 10; i++)
            {
                handler.OnAfterUpdate(gameObject);
            }

            Assert.Equal(10, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnAfterUpdate.
        /// </summary>
        private class AfterUpdateHandler : IOnAfterUpdate
        {
            public int CallCount { get; private set; }

            public void OnAfterUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}