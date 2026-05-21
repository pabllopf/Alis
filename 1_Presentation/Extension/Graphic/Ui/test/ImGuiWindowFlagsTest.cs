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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
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
            ImGuiWindowFlags flag = ImGuiWindowFlags.None;

            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that no title bar should be initialized correctly
        /// </summary>
        [Fact]
        public void NoTitleBar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoTitleBar;

            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that no resize should be initialized correctly
        /// </summary>
        [Fact]
        public void NoResize_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoResize;

            Assert.Equal(2, (int) flag);
        }

        /// <summary>
        ///     Tests that no move should be initialized correctly
        /// </summary>
        [Fact]
        public void NoMove_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoMove;

            Assert.Equal(4, (int) flag);
        }

        /// <summary>
        ///     Tests that no scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void NoScrollbar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoScrollbar;

            Assert.Equal(8, (int) flag);
        }

        /// <summary>
        ///     Tests that no scroll with mouse should be initialized correctly
        /// </summary>
        [Fact]
        public void NoScrollWithMouse_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoScrollWithMouse;

            Assert.Equal(16, (int) flag);
        }

        /// <summary>
        ///     Tests that no collapse should be initialized correctly
        /// </summary>
        [Fact]
        public void NoCollapse_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoCollapse;

            Assert.Equal(32, (int) flag);
        }

        /// <summary>
        ///     Tests that always auto resize should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysAutoResize_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysAutoResize;

            Assert.Equal(64, (int) flag);
        }

        /// <summary>
        ///     Tests that no background should be initialized correctly
        /// </summary>
        [Fact]
        public void NoBackground_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoBackground;

            Assert.Equal(128, (int) flag);
        }

        /// <summary>
        ///     Tests that no saved settings should be initialized correctly
        /// </summary>
        [Fact]
        public void NoSavedSettings_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoSavedSettings;

            Assert.Equal(256, (int) flag);
        }

        /// <summary>
        ///     Tests that no mouse inputs should be initialized correctly
        /// </summary>
        [Fact]
        public void NoMouseInputs_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoMouseInputs;

            Assert.Equal(512, (int) flag);
        }

        /// <summary>
        ///     Tests that menu bar should be initialized correctly
        /// </summary>
        [Fact]
        public void MenuBar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.MenuBar;

            Assert.Equal(1024, (int) flag);
        }

        /// <summary>
        ///     Tests that horizontal scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void HorizontalScrollbar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.HorizontalScrollbar;

            Assert.Equal(2048, (int) flag);
        }

        /// <summary>
        ///     Tests that no focus on appearing should be initialized correctly
        /// </summary>
        [Fact]
        public void NoFocusOnAppearing_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoFocusOnAppearing;

            Assert.Equal(4096, (int) flag);
        }

        /// <summary>
        ///     Tests that no bring to front on focus should be initialized correctly
        /// </summary>
        [Fact]
        public void NoBringToFrontOnFocus_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.NoBringToFrontOnFocus;

            Assert.Equal(8192, (int) flag);
        }

        /// <summary>
        ///     Tests that always vertical scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysVerticalScrollbar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysVerticalScrollbar;

            Assert.Equal(16384, (int) flag);
        }

        /// <summary>
        ///     Tests that always horizontal scrollbar should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysHorizontalScrollbar_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysHorizontalScrollbar;

            Assert.Equal(32768, (int) flag);
        }

        /// <summary>
        ///     Tests that always use window padding should be initialized correctly
        /// </summary>
        [Fact]
        public void AlwaysUseWindowPadding_ShouldBeInitializedCorrectly()
        {
            ImGuiWindowFlags flag = ImGuiWindowFlags.AlwaysUseWindowPadding;

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