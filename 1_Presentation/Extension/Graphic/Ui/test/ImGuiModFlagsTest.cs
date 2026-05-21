// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiModFlagsTest.cs
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


using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui mod flags test class
    /// </summary>
    public class ImGuiModFlagsTest
    {
        /// <summary>
        ///     Tests that none should be initialized correctly
        /// </summary>
        [Fact]
        public void None_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.None;

            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that ctrl should be initialized correctly
        /// </summary>
        [Fact]
        public void Ctrl_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Ctrl;

            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that shift should be initialized correctly
        /// </summary>
        [Fact]
        public void Shift_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Shift;

            Assert.Equal(2, (int) flag);
        }

        /// <summary>
        ///     Tests that alt should be initialized correctly
        /// </summary>
        [Fact]
        public void Alt_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Alt;

            Assert.Equal(4, (int) flag);
        }

        /// <summary>
        ///     Tests that super should be initialized correctly
        /// </summary>
        [Fact]
        public void Super_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Super;

            Assert.Equal(8, (int) flag);
        }
    }
}