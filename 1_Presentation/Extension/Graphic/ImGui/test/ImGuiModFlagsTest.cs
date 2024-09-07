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

namespace Alis.Extension.Graphic.ImGui.Test
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
            // Arrange
            ImGuiModFlags flag = ImGuiModFlags.None;

            // Act & Assert
            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that ctrl should be initialized correctly
        /// </summary>
        [Fact]
        public void Ctrl_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiModFlags flag = ImGuiModFlags.Ctrl;

            // Act & Assert
            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that shift should be initialized correctly
        /// </summary>
        [Fact]
        public void Shift_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiModFlags flag = ImGuiModFlags.Shift;

            // Act & Assert
            Assert.Equal(2, (int) flag);
        }

        /// <summary>
        ///     Tests that alt should be initialized correctly
        /// </summary>
        [Fact]
        public void Alt_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiModFlags flag = ImGuiModFlags.Alt;

            // Act & Assert
            Assert.Equal(4, (int) flag);
        }

        /// <summary>
        ///     Tests that super should be initialized correctly
        /// </summary>
        [Fact]
        public void Super_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiModFlags flag = ImGuiModFlags.Super;

            // Act & Assert
            Assert.Equal(8, (int) flag);
        }
    }
}