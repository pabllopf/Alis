// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesIOCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes io coverage tests class
    /// </summary>
    public class ImNodesIOCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImNodesIo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImNodesIo io = default(ImNodesIo);

            Assert.Null(io.ThreeButtonMouse.Modifier);
            Assert.Null(io.DetachWithModifierClick.Modifier);
            Assert.Null(io.SelectModifier.Modifier);
            Assert.Equal(0, io.AltMouseButton);
            Assert.Equal(0f, io.AutoPanningSpeed, 5);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImNodesIo_SetProperties_StoresValuesCorrectly()
        {
            EmulateThreeButtonMouse threeButtonMouse = new EmulateThreeButtonMouse { Modifier = new byte[] { 1 } };
            LinkDetachWithModifierClick detachWithModifierClick = new LinkDetachWithModifierClick { Modifier = new byte[] { 2 } };
            MultipleSelectModifier selectModifier = new MultipleSelectModifier { Modifier = new byte[] { 3 } };

            ImNodesIo io = new ImNodesIo
            {
                ThreeButtonMouse = threeButtonMouse,
                DetachWithModifierClick = detachWithModifierClick,
                SelectModifier = selectModifier,
                AltMouseButton = 2,
                AutoPanningSpeed = 0.5f
            };

            Assert.Same(threeButtonMouse.Modifier, io.ThreeButtonMouse.Modifier);
            Assert.Same(detachWithModifierClick.Modifier, io.DetachWithModifierClick.Modifier);
            Assert.Same(selectModifier.Modifier, io.SelectModifier.Modifier);
            Assert.Equal(2, io.AltMouseButton);
            Assert.Equal(0.5f, io.AutoPanningSpeed, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImNodesIo_IsValueType_CopyIsIndependent()
        {
            ImNodesIo original = new ImNodesIo { AltMouseButton = 1 };
            ImNodesIo copy = original;

            copy.AltMouseButton = 2;

            Assert.Equal(1, original.AltMouseButton);
            Assert.Equal(2, copy.AltMouseButton);
        }
    }
}