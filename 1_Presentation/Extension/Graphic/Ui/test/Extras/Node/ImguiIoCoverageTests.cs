// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImguiIoCoverageTests.cs
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

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The imgui io coverage tests class
    /// </summary>
    public class ImguiIoCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImguiIo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImguiIo io = default(ImguiIo);

            Assert.Null(io.EmulateThreeButtonMouse.Modifier);
            Assert.Null(io.LinkDetachWithModifierClick.Modifier);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImguiIo_SetProperties_StoresValuesCorrectly()
        {
            byte[] emulate = { 1, 2, 3 };
            byte[] detach = { 4, 5, 6 };
            ImguiIo io = new ImguiIo
            {
                EmulateThreeButtonMouse = new EmulateThreeButtonMouse { Modifier = emulate },
                LinkDetachWithModifierClick = new LinkDetachWithModifierClick { Modifier = detach }
            };

            Assert.Same(emulate, io.EmulateThreeButtonMouse.Modifier);
            Assert.Same(detach, io.LinkDetachWithModifierClick.Modifier);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies share the reference
        /// </summary>
        [Fact]
        public void ImguiIo_IsValueType_CopySharesReference()
        {
            byte[] emulate = { 1 };
            ImguiIo original = new ImguiIo { EmulateThreeButtonMouse = new EmulateThreeButtonMouse { Modifier = emulate } };
            ImguiIo copy = original;

            Assert.Same(original.EmulateThreeButtonMouse.Modifier, copy.EmulateThreeButtonMouse.Modifier);
        }
    }
}