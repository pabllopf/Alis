// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnBeforeDrawTest.cs
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
    ///     Unit tests for the IOnBeforeDraw interface.
    ///     Tests the OnBeforeDraw lifecycle method for pre-render setup.
    /// </summary>
    public class IOnBeforeDrawTest
    {
        /// <summary>
        ///     Tests that IOnBeforeDraw can be implemented.
        /// </summary>
        [Fact]
        public void IOnBeforeDraw_CanBeImplemented()
        {
            BeforeDrawHandler handler = new BeforeDrawHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnBeforeDraw>(handler);
        }

        /// <summary>
        ///     Tests that OnBeforeDraw method can be called.
        /// </summary>
        [Fact]
        public void OnBeforeDraw_CanBeCalled()
        {
            BeforeDrawHandler handler = new BeforeDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnBeforeDraw(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnBeforeDraw counts calls.
        /// </summary>
        [Fact]
        public void OnBeforeDraw_CountsCalls()
        {
            BeforeDrawHandler handler = new BeforeDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 60; i++)
            {
                handler.OnBeforeDraw(gameObject);
            }

            Assert.Equal(60, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnBeforeDraw.
        /// </summary>
        private class BeforeDrawHandler : IOnBeforeDraw
        {
            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Ons the before draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnBeforeDraw(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}