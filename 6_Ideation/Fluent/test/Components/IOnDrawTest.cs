// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnDrawTest.cs
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

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnDraw interface.
    ///     Tests the OnDraw lifecycle method for rendering.
    /// </summary>
    public class IOnDrawTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnDraw.
        /// </summary>
        private class DrawHandler : IOnDraw
        {
            public int DrawCallCount { get; private set; }

            public void OnDraw(IGameObject self)
            {
                DrawCallCount++;
            }
        }

        /// <summary>
        ///     Tests that IOnDraw can be implemented.
        /// </summary>
        [Fact]
        public void IOnDraw_CanBeImplemented()
        {
            var handler = new DrawHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnDraw>(handler);
        }

        /// <summary>
        ///     Tests that OnDraw method can be called.
        /// </summary>
        [Fact]
        public void OnDraw_CanBeCalled()
        {
            var handler = new DrawHandler();
            var gameObject = new MockGameObject();
            handler.OnDraw(gameObject);
            Assert.Equal(1, handler.DrawCallCount);
        }

        /// <summary>
        ///     Tests that OnDraw counts rendering frames.
        /// </summary>
        [Fact]
        public void OnDraw_CountsRenderingFrames()
        {
            var handler = new DrawHandler();
            var gameObject = new MockGameObject();
            for (int i = 0; i < 120; i++)
            {
                handler.OnDraw(gameObject);
            }
            Assert.Equal(120, handler.DrawCallCount);
        }
    }
}

