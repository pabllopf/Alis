// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextFilterTest.cs
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
    ///     The im gui text filter test class
    /// </summary>
    public class ImGuiTextFilterTest
    {
        /// <summary>
        ///     Tests that input buf should set and get correctly
        /// </summary>
        [Fact]
        public void InputBuf_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            byte[] inputBuf = new byte[256];
            textFilter.InputBuf = inputBuf;
            Assert.Equal(inputBuf, textFilter.InputBuf);
        }

        /// <summary>
        ///     Tests that filters should set and get correctly
        /// </summary>
        [Fact]
        public void Filters_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            ImVector filters = new ImVector();
            textFilter.Filters = filters;
            Assert.Equal(filters, textFilter.Filters);
        }

        /// <summary>
        ///     Tests that count grep should set and get correctly
        /// </summary>
        [Fact]
        public void CountGrep_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            textFilter.CountGrep = 5;
            Assert.Equal(5, textFilter.CountGrep);
        }
    }
}