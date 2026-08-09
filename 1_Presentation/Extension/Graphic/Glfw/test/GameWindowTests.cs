// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindowTests.cs
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
    /// The game window tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GameWindowTests : IDisposable
    {
        /// <summary>
        /// The window
        /// </summary>
        private GameWindow window;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }
        
        /// <summary>
        /// Tests that game window is public
        /// </summary>
        [Fact]
        public void GameWindow_IsPublicClass()
        {
            Type type = typeof(GameWindow);
            Assert.True(type.IsPublic);
        }

        /// <summary>
        /// Tests that game window inherits from native window reflection
        /// </summary>
        [Fact]
        public void GameWindow_InheritsFromNativeWindow_Reflection()
        {
            Type type = typeof(GameWindow);
            Assert.Equal(typeof(NativeWindow), type.BaseType);
        }

    }
}