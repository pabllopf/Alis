// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnSortSpecsTest.cs
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
    ///     The im gui table column sort specs test class
    /// </summary>
    public class ImGuiTableColumnSortSpecsTest
    {
        /// <summary>
        ///     Tests that column user id should be initialized
        /// </summary>
        [Fact]
        public void ColumnUserId_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal(0u, specs.ColumnUserId);
        }

        /// <summary>
        ///     Tests that column index should be initialized
        /// </summary>
        [Fact]
        public void ColumnIndex_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal((short) 0, specs.ColumnIndex);
        }

        /// <summary>
        ///     Tests that sort order should be initialized
        /// </summary>
        [Fact]
        public void SortOrder_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal((short) 0, specs.SortOrder);
        }

        /// <summary>
        ///     Tests that sort direction should be initialized
        /// </summary>
        [Fact]
        public void SortDirection_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal(default(ImGuiSortDirection), specs.SortDirection);
        }

        /// <summary>
        ///     Tests that column user id should set and get correctly
        /// </summary>
        [Fact]
        public void ColumnUserId_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.ColumnUserId = 123u;
            Assert.Equal(123u, specs.ColumnUserId);
        }

        /// <summary>
        ///     Tests that column index should set and get correctly
        /// </summary>
        [Fact]
        public void ColumnIndex_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.ColumnIndex = 1;
            Assert.Equal((short) 1, specs.ColumnIndex);
        }

        /// <summary>
        ///     Tests that sort order should set and get correctly
        /// </summary>
        [Fact]
        public void SortOrder_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.SortOrder = 2;
            Assert.Equal((short) 2, specs.SortOrder);
        }

        /// <summary>
        ///     Tests that sort direction should set and get correctly
        /// </summary>
        [Fact]
        public void SortDirection_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.SortDirection = ImGuiSortDirection.Ascending;
            Assert.Equal(ImGuiSortDirection.Ascending, specs.SortDirection);
        }
    }
}