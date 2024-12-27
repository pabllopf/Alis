// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmulateThreeButtonMouseTest.cs
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
    ///     The emulate three button mouse test class
    /// </summary>
    	  
	 public class EmulateThreeButtonMouseTest 
    {
        /// <summary>
        ///     Tests that modifier should be initialized
        /// </summary>
        [Fact]
        public void Modifier_ShouldBeInitialized()
        {
            EmulateThreeButtonMouse emulateThreeButtonMouse = new EmulateThreeButtonMouse();
            Assert.Null(emulateThreeButtonMouse.Modifier);
        }

        /// <summary>
        ///     Tests that modifier should set and get correctly
        /// </summary>
        [Fact]
        public void Modifier_Should_SetAndGetCorrectly()
        {
            EmulateThreeButtonMouse emulateThreeButtonMouse = new EmulateThreeButtonMouse();
            byte[] value = {1, 2, 3};
            emulateThreeButtonMouse.Modifier = value;
            Assert.Equal(value, emulateThreeButtonMouse.Modifier);
        }
    }
}