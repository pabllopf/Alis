// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnSortSpecsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui table column sort specs remaining coverage tests class
    /// </summary>
    public class ImGuiTableColumnSortSpecsRemainingCoverageTests
    {
        /// <summary>
        /// Tests that default column user id is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ColumnUserId_IsZero()
        {
            ImGuiTableColumnSortSpecs specs = default;
            Assert.Equal(0u, specs.ColumnUserId);
        }

        /// <summary>
        /// Tests that default column index is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ColumnIndex_IsZero()
        {
            ImGuiTableColumnSortSpecs specs = default;
            Assert.Equal((short)0, specs.ColumnIndex);
        }

        /// <summary>
        /// Tests that default sort order is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_SortOrder_IsZero()
        {
            ImGuiTableColumnSortSpecs specs = default;
            Assert.Equal((short)0, specs.SortOrder);
        }

        /// <summary>
        /// Tests that default sort direction is none
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_SortDirection_IsNone()
        {
            ImGuiTableColumnSortSpecs specs = default;
            Assert.Equal(ImGuiSortDirection.None, specs.SortDirection);
        }

        /// <summary>
        /// Tests that column user id round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColumnUserId_RoundTrip()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.ColumnUserId = 42u;
            Assert.Equal(42u, specs.ColumnUserId);
        }

        /// <summary>
        /// Tests that column user id round trip max value
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColumnUserId_RoundTrip_MaxValue()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.ColumnUserId = uint.MaxValue;
            Assert.Equal(uint.MaxValue, specs.ColumnUserId);
        }

        /// <summary>
        /// Tests that column index round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColumnIndex_RoundTrip()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.ColumnIndex = 1;
            Assert.Equal((short)1, specs.ColumnIndex);
        }

        /// <summary>
        /// Tests that column index round trip negative
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColumnIndex_RoundTrip_Negative()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.ColumnIndex = -1;
            Assert.Equal((short)-1, specs.ColumnIndex);
        }

        /// <summary>
        /// Tests that sort order round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void SortOrder_RoundTrip()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.SortOrder = 2;
            Assert.Equal((short)2, specs.SortOrder);
        }

        /// <summary>
        /// Tests that sort order round trip max value
        /// </summary>
         [RequireCImguiSystemFact]
        public void SortOrder_RoundTrip_MaxValue()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.SortOrder = short.MaxValue;
            Assert.Equal(short.MaxValue, specs.SortOrder);
        }

        /// <summary>
        /// Tests that sort direction round trip ascending
        /// </summary>
         [RequireCImguiSystemFact]
        public void SortDirection_RoundTrip_Ascending()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.SortDirection = ImGuiSortDirection.Ascending;
            Assert.Equal(ImGuiSortDirection.Ascending, specs.SortDirection);
        }

        /// <summary>
        /// Tests that sort direction round trip descending
        /// </summary>
         [RequireCImguiSystemFact]
        public void SortDirection_RoundTrip_Descending()
        {
            ImGuiTableColumnSortSpecs specs = default;
            specs.SortDirection = ImGuiSortDirection.Descending;
            Assert.Equal(ImGuiSortDirection.Descending, specs.SortDirection);
        }
    }
}
