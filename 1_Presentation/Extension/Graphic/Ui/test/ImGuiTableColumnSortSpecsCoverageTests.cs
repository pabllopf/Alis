// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnSortSpecsCoverageTests.cs
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
    ///     The im gui table column sort specs coverage tests class
    /// </summary>
    public class ImGuiTableColumnSortSpecsCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiTableColumnSortSpecs_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiTableColumnSortSpecs specs = default(ImGuiTableColumnSortSpecs);

            Assert.Equal(0u, specs.ColumnUserId);
            Assert.Equal((short)0, specs.ColumnIndex);
            Assert.Equal((short)0, specs.SortOrder);
            Assert.Equal(ImGuiSortDirection.None, specs.SortDirection);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiTableColumnSortSpecs_SetProperties_StoresValuesCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs
            {
                ColumnUserId = 42u,
                ColumnIndex = 1,
                SortOrder = 2,
                SortDirection = ImGuiSortDirection.Descending
            };

            Assert.Equal(42u, specs.ColumnUserId);
            Assert.Equal((short)1, specs.ColumnIndex);
            Assert.Equal((short)2, specs.SortOrder);
            Assert.Equal(ImGuiSortDirection.Descending, specs.SortDirection);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiTableColumnSortSpecs_IsValueType_CopyIsIndependent()
        {
            ImGuiTableColumnSortSpecs original = new ImGuiTableColumnSortSpecs { ColumnUserId = 100u };
            ImGuiTableColumnSortSpecs copy = original;

            copy.ColumnUserId = 200u;

            Assert.Equal(100u, original.ColumnUserId);
            Assert.Equal(200u, copy.ColumnUserId);
        }
    }
}