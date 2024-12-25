// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowFlagsTest.cs
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
    ///     The im gui window flags test class
    /// </summary>
    	  
	 public class ImGuiWindowFlagsTest 
    {
        /// <summary>
        ///     Tests that none should be initialized correctly
        /// </summary>
        [Fact]
        public void None_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.None;

            // Act & Assert
            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that no title bar should be initialized correctly
        /// </summary>
        [Fact]
        public void NoTitleBar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoTitleBar;

            // Act & Assert
            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that no resize should be initialized correctly
        /// </summary>
        [Fact]
        public void NoResize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoResize;

            // Act & Assert
            Assert.Equal(2, (int) flag);
        }

        /// <summary>
        ///     Tests that no move should be initialized correctly
        /// </summary>
        [Fact]
        public void NoMove_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoMove;

            // Act & Assert
            Assert.Equal(4, (int) flag);
        }

        /// <summary>
        ///     Tests that no scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void NoScrollbar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoScrollbar;

            // Act & Assert
            Assert.Equal(8, (int) flag);
        }

        /// <summary>
        ///     Tests that no scroll with mouse should be initialized correctly
        /// </summary>
        [Fact]
        public void NoScrollWithMouse_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoScrollWithMouse;

            // Act & Assert
            Assert.Equal(16, (int) flag);
        }

        /// <summary>
        ///     Tests that no collapse should be initialized correctly
        /// </summary>
        [Fact]
        public void NoCollapse_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoCollapse;

            // Act & Assert
            Assert.Equal(32, (int) flag);
        }

        /// <summary>
        ///     Tests that always auto resize should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysAutoResize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysAutoResize;

            // Act & Assert
            Assert.Equal(64, (int) flag);
        }

        /// <summary>
        ///     Tests that no background should be initialized correctly
        /// </summary>
        [Fact]
        public void NoBackground_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoBackground;

            // Act & Assert
            Assert.Equal(128, (int) flag);
        }

        /// <summary>
        ///     Tests that no saved settings should be initialized correctly
        /// </summary>
        [Fact]
        public void NoSavedSettings_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoSavedSettings;

            // Act & Assert
            Assert.Equal(256, (int) flag);
        }

        /// <summary>
        ///     Tests that no mouse inputs should be initialized correctly
        /// </summary>
        [Fact]
        public void NoMouseInputs_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoMouseInputs;

            // Act & Assert
            Assert.Equal(512, (int) flag);
        }

        /// <summary>
        ///     Tests that menu bar should be initialized correctly
        /// </summary>
        [Fact]
        public void MenuBar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.MenuBar;

            // Act & Assert
            Assert.Equal(1024, (int) flag);
        }

        /// <summary>
        ///     Tests that horizontal scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void HorizontalScrollbar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.HorizontalScrollbar;

            // Act & Assert
            Assert.Equal(2048, (int) flag);
        }

        /// <summary>
        ///     Tests that no focus on appearing should be initialized correctly
        /// </summary>
        [Fact]
        public void NoFocusOnAppearing_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoFocusOnAppearing;

            // Act & Assert
            Assert.Equal(4096, (int) flag);
        }

        /// <summary>
        ///     Tests that no bring to front on focus should be initialized correctly
        /// </summary>
        [Fact]
        public void NoBringToFrontOnFocus_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoBringToFrontOnFocus;

            // Act & Assert
            Assert.Equal(8192, (int) flag);
        }

        /// <summary>
        ///     Tests that always vertical scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysVerticalScrollbar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysVerticalScrollbar;

            // Act & Assert
            Assert.Equal(16384, (int) flag);
        }

        /// <summary>
        ///     Tests that always horizontal scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysHorizontalScrollbar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysHorizontalScrollbar;

            // Act & Assert
            Assert.Equal(32768, (int) flag);
        }

        /// <summary>
        ///     Tests that always use window padding should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysUseWindowPadding_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysUseWindowPadding;

            // Act & Assert
            Assert.Equal(65536, (int) flag);
        }

        /// <summary>
        ///     Tests that no nav inputs should be initialized correctly
        /// </summary>
        [Fact]
        public void NoNavInputs_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoNavInputs;

            // Act & Assert
            Assert.Equal(262144, (int) flag);
        }

        /// <summary>
        ///     Tests that no nav focus should be initialized correctly
        /// </summary>
        [Fact]
        public void NoNavFocus_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoNavFocus;

            // Act & Assert
            Assert.Equal(524288, (int) flag);
        }

        /// <summary>
        ///     Tests that unsaved document should be initialized correctly
        /// </summary>
        [Fact]
        public void UnsavedDocument_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.UnsavedDocument;

            // Act & Assert
            Assert.Equal(1048576, (int) flag);
        }

        /// <summary>
        ///     Tests that no docking should be initialized correctly
        /// </summary>
        [Fact]
        public void NoDocking_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoDocking;

            // Act & Assert
            Assert.Equal(2097152, (int) flag);
        }

        /// <summary>
        ///     Tests that no nav should be initialized correctly
        /// </summary>
        [Fact]
        public void NoNav_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoNav;

            // Act & Assert
            Assert.Equal(786432, (int) flag);
        }

        /// <summary>
        ///     Tests that no decoration should be initialized correctly
        /// </summary>
        [Fact]
        public void NoDecoration_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoDecoration;

            // Act & Assert
            Assert.Equal(43, (int) flag);
        }

        /// <summary>
        ///     Tests that no inputs should be initialized correctly
        /// </summary>
        [Fact]
        public void NoInputs_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoInputs;

            // Act & Assert
            Assert.Equal(786944, (int) flag);
        }

        /// <summary>
        ///     Tests that nav flattened should be initialized correctly
        /// </summary>
        [Fact]
        public void NavFlattened_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.NavFlattened;

            // Act & Assert
            Assert.Equal(8388608, (int) flag);
        }

        /// <summary>
        ///     Tests that child window should be initialized correctly
        /// </summary>
        [Fact]
        public void ChildWindow_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.ChildWindow;

            // Act & Assert
            Assert.Equal(16777216, (int) flag);
        }

        /// <summary>
        ///     Tests that tooltip should be initialized correctly
        /// </summary>
        [Fact]
        public void Tooltip_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.Tooltip;

            // Act & Assert
            Assert.Equal(33554432, (int) flag);
        }

        /// <summary>
        ///     Tests that popup should be initialized correctly
        /// </summary>
        [Fact]
        public void Popup_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.Popup;

            // Act & Assert
            Assert.Equal(67108864, (int) flag);
        }

        /// <summary>
        ///     Tests that modal should be initialized correctly
        /// </summary>
        [Fact]
        public void Modal_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.Modal;

            // Act & Assert
            Assert.Equal(134217728, (int) flag);
        }

        /// <summary>
        ///     Tests that child menu should be initialized correctly
        /// </summary>
        [Fact]
        public void ChildMenu_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.ChildMenu;

            // Act & Assert
            Assert.Equal(268435456, (int) flag);
        }

        /// <summary>
        ///     Tests that dock node host should be initialized correctly
        /// </summary>
        [Fact]
        public void DockNodeHost_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiWindowFlags flag = ImGuiWindowFlags.DockNodeHost;

            // Act & Assert
            Assert.Equal(536870912, (int) flag);
        }
    }
}