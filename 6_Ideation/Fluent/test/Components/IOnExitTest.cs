// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnExitTest.cs
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
    ///     Unit tests for the IOnExit interface.
    ///     Tests the OnExit lifecycle method for cleanup on scene exit.
    /// </summary>
    public class IOnExitTest
    {
        /// <summary>
        ///     Tests that IOnExit can be implemented.
        /// </summary>
        [Fact]
        public void IOnExit_CanBeImplemented()
        {
            ExitHandler handler = new ExitHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnExit>(handler);
        }

        /// <summary>
        ///     Tests that OnExit method can be called.
        /// </summary>
        [Fact]
        public void OnExit_CanBeCalled()
        {
            ExitHandler handler = new ExitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnExit(gameObject);
            Assert.True(handler.WasExitCalled);
        }

        /// <summary>
        ///     Tests that OnExit counts invocations.
        /// </summary>
        [Fact]
        public void OnExit_CountsInvocations()
        {
            ExitHandler handler = new ExitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnExit(gameObject);
            Assert.Equal(1, handler.ExitCount);
            handler.OnExit(gameObject);
            Assert.Equal(2, handler.ExitCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnExit.
        /// </summary>
        private class ExitHandler : IOnExit
        {
            public bool WasExitCalled { get; private set; }
            public int ExitCount { get; private set; }

            public void OnExit(IGameObject self)
            {
                WasExitCalled = true;
                ExitCount++;
            }
        }
    }
}