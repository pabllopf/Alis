// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnInitTest.cs
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
    ///     Unit tests for the IOnInit interface.
    ///     Tests the OnInit lifecycle method for initialization.
    /// </summary>
    public class IOnInitTest
    {
        /// <summary>
        ///     Tests that IOnInit can be implemented.
        /// </summary>
        [Fact]
        public void IOnInit_CanBeImplemented()
        {
            InitHandler handler = new InitHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnInit>(handler);
        }

        /// <summary>
        ///     Tests that OnInit method can be called.
        /// </summary>
        [Fact]
        public void OnInit_CanBeCalled()
        {
            InitHandler handler = new InitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnInit(gameObject);
            Assert.True(handler.WasInitialized);
        }

        /// <summary>
        ///     Tests that OnInit counts invocations.
        /// </summary>
        [Fact]
        public void OnInit_CountsInvocations()
        {
            InitHandler handler = new InitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnInit(gameObject);
            Assert.Equal(1, handler.InitCount);
            handler.OnInit(gameObject);
            Assert.Equal(2, handler.InitCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnInit.
        /// </summary>
        private class InitHandler : IOnInit
        {
            /// <summary>
            /// Gets or sets the value of the was initialized
            /// </summary>
            public bool WasInitialized { get; private set; }
            /// <summary>
            /// Gets or sets the value of the init count
            /// </summary>
            public int InitCount { get; private set; }

            /// <summary>
            /// Ons the init using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnInit(IGameObject self)
            {
                WasInitialized = true;
                InitCount++;
            }
        }
    }
}