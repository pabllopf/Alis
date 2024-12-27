// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IoTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Node
{
    /// <summary>
    ///     The io test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class IoTest 
    {
        /// <summary>
        ///     Tests that emulate three button mouse should be initialized
        /// </summary>
        [Fact]
        public void EmulateThreeButtonMouse_ShouldBeInitialized()
        {
            Io io = new Io();
            Assert.Equal(default(EmulateThreeButtonMouse), io.EmulateThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that link detach with modifier click should be initialized
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_ShouldBeInitialized()
        {
            Io io = new Io();
            Assert.Equal(default(LinkDetachWithModifierClick), io.LinkDetachWithModifierClick);
        }

        /// <summary>
        ///     Tests that emulate three button mouse should set and get correctly
        /// </summary>
        [Fact]
        public void EmulateThreeButtonMouse_Should_SetAndGetCorrectly()
        {
            Io io = new Io();
            EmulateThreeButtonMouse value = new EmulateThreeButtonMouse();
            io.EmulateThreeButtonMouse = value;
            Assert.Equal(value, io.EmulateThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that link detach with modifier click should set and get correctly
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_Should_SetAndGetCorrectly()
        {
            Io io = new Io();
            LinkDetachWithModifierClick value = new LinkDetachWithModifierClick();
            io.LinkDetachWithModifierClick = value;
            Assert.Equal(value, io.LinkDetachWithModifierClick);
        }
    }
}