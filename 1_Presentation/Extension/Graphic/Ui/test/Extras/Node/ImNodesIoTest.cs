// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesIOTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Contract tests for the <see cref="ImNodesIo" /> struct.
    /// </summary>
    public class ImNodesIOTest
    {
        /// <summary>
        ///     Verifies that ImNodesIo is a value type.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImNodesIo_ShouldBeValueType()
        {
            Assert.True(typeof(ImNodesIo).IsValueType);
        }

        /// <summary>
        ///     Verifies that default instance has default ThreeButtonMouse.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_ThreeButtonMouse_ShouldBeDefault()
        {
            ImNodesIo io = default;

            Assert.Equal(default(EmulateThreeButtonMouse), io.ThreeButtonMouse);
        }

        /// <summary>
        ///     Verifies that default instance has default DetachWithModifierClick.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_DetachWithModifierClick_ShouldBeDefault()
        {
            ImNodesIo io = default;

            Assert.Equal(default(LinkDetachWithModifierClick), io.DetachWithModifierClick);
        }

        /// <summary>
        ///     Verifies that default instance has default SelectModifier.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_SelectModifier_ShouldBeDefault()
        {
            ImNodesIo io = default;

            Assert.Equal(default(MultipleSelectModifier), io.SelectModifier);
        }

        /// <summary>
        ///     Verifies that AltMouseButton defaults to zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_AltMouseButton_ShouldBeZero()
        {
            ImNodesIo io = default;

            Assert.Equal(0, io.AltMouseButton);
        }

        /// <summary>
        ///     Verifies that AutoPanningSpeed defaults to zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_AutoPanningSpeed_ShouldBeZero()
        {
            ImNodesIo io = default;

            Assert.Equal(0f, io.AutoPanningSpeed, 5);
        }

        /// <summary>
        ///     Verifies that AltMouseButton can be set and read.
        /// </summary>
         [RequireCImguiSystemFact]
        public void AltMouseButton_ShouldBeSettable()
        {
            ImNodesIo io = default;

            io.AltMouseButton = 2;

            Assert.Equal(2, io.AltMouseButton);
        }

        /// <summary>
        ///     Verifies that AutoPanningSpeed can be set and read.
        /// </summary>
         [RequireCImguiSystemFact]
        public void AutoPanningSpeed_ShouldBeSettable()
        {
            ImNodesIo io = default;

            io.AutoPanningSpeed = 0.5f;

            Assert.Equal(0.5f, io.AutoPanningSpeed, 5);
        }
    }
}
