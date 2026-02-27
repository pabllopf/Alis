// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnAfterDrawTest.cs
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
    ///     Unit tests for the IOnAfterDraw interface.
    ///     Tests the OnAfterDraw lifecycle method for post-render cleanup.
    /// </summary>
    public class IOnAfterDrawTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnAfterDraw.
        /// </summary>
        private class AfterDrawHandler : IOnAfterDraw
        {
            public int CallCount { get; private set; }

            public void OnAfterDraw(IGameObject self)
            {
                CallCount++;
            }
        }

        /// <summary>
        ///     Tests that IOnAfterDraw can be implemented.
        /// </summary>
        [Fact]
        public void IOnAfterDraw_CanBeImplemented()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAfterDraw>(handler);
        }

        /// <summary>
        ///     Tests that OnAfterDraw method can be called.
        /// </summary>
        [Fact]
        public void OnAfterDraw_CanBeCalled()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAfterDraw(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnAfterDraw counts frames.
        /// </summary>
        [Fact]
        public void OnAfterDraw_CountsFrames()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 120; i++)
            {
                handler.OnAfterDraw(gameObject);
            }
            Assert.Equal(120, handler.CallCount);
        }
        
    }
}

