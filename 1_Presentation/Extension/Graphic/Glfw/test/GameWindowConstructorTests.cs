// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindowConstructorTests.cs
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

using System;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     The game window constructor tests class
    /// </summary>
    public class GameWindowConstructorTests
    {
        /// <summary>
        ///     Tests that the default constructor throws when no GLFW context is available
        /// </summary>
        [Fact]
        public void DefaultConstructor_WhenGlfwUnavailable_Throws()
        {
            Assert.ThrowsAny<Exception>(() => new GameWindow());
        }

        /// <summary>
        ///     Tests that the sized constructor throws when no GLFW context is available
        /// </summary>
        [Fact]
        public void SizedConstructor_WhenGlfwUnavailable_Throws()
        {
            Assert.ThrowsAny<Exception>(() => new GameWindow(320, 200, "alis-test"));
        }

        /// <summary>
        ///     Tests that the full constructor throws when no GLFW context is available
        /// </summary>
        [Fact]
        public void FullConstructor_WhenGlfwUnavailable_Throws()
        {
            Assert.ThrowsAny<Exception>(() => new GameWindow(320, 200, "alis-test", Monitor.None, Window.None));
        }
    }
}