// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSortDirectionTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiSortDirection" /> enum values.
    /// </summary>
    public class ImGuiSortDirectionTest
    {
        /// <summary>
        ///     Verifies that sort direction values are defined.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldBeZero()
        {
            ImGuiSortDirection direction = ImGuiSortDirection.None;
            Assert.Equal(0, (int) direction);
        }

        /// <summary>
        ///     Verifies that different sort directions have distinct values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiSortDirection ascending = ImGuiSortDirection.Ascending;
            ImGuiSortDirection descending = ImGuiSortDirection.Descending;

            Assert.NotEqual((int) ascending, (int) descending);
        }
    }
}