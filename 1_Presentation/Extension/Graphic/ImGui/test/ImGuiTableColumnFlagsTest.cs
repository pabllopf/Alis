// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnFlagsTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui table column flags test class
    /// </summary>
    	  
	 public class ImGuiTableColumnFlagsTest 
    {
        /// <summary>
        ///     Tests that is visible should be initialized correctly
        /// </summary>
        [Fact]
        public void IsVisible_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsVisible;

            // Act & Assert
            Assert.Equal(33554432, (int) flag);
        }

        /// <summary>
        ///     Tests that is sorted should be initialized correctly
        /// </summary>
        [Fact]
        public void IsSorted_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsSorted;

            // Act & Assert
            Assert.Equal(67108864, (int) flag);
        }

        /// <summary>
        ///     Tests that is hovered should be initialized correctly
        /// </summary>
        [Fact]
        public void IsHovered_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsHovered;

            // Act & Assert
            Assert.Equal(134217728, (int) flag);
        }

        /// <summary>
        ///     Tests that width mask should be initialized correctly
        /// </summary>
        [Fact]
        public void WidthMask_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.WidthMask;

            // Act & Assert
            Assert.Equal(24, (int) flag);
        }

        /// <summary>
        ///     Tests that indent mask should be initialized correctly
        /// </summary>
        [Fact]
        public void IndentMask_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IndentMask;

            // Act & Assert
            Assert.Equal(196608, (int) flag);
        }

        /// <summary>
        ///     Tests that status mask should be initialized correctly
        /// </summary>
        [Fact]
        public void StatusMask_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.StatusMask;

            // Act & Assert
            Assert.Equal(251658240, (int) flag);
        }

        /// <summary>
        ///     Tests that no direct resize should be initialized correctly
        /// </summary>
        [Fact]
        public void NoDirectResize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.NoDirectResize;

            // Act & Assert
            Assert.Equal(1073741824, (int) flag);
        }
    }
}