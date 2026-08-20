// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextFilterTests.cs
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
    /// The im gui text filter tests class
    /// </summary>
    public class ImGuiTextFilterTests
    {
        /// <summary>
        /// Tests that input buf get when default returns null
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputBuf_Get_WhenDefault_ReturnsNull()
        {
            ImGuiTextFilter filter = default;
            Assert.Null(filter.InputBuf);
        }

        /// <summary>
        /// Tests that input buf set should store value
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputBuf_Set_ShouldStoreValue()
        {
            ImGuiTextFilter filter = default;
            byte[] expected = new byte[256];
            filter.InputBuf = expected;
            Assert.Same(expected, filter.InputBuf);
        }

        /// <summary>
        /// Tests that filters get when default returns default
        /// </summary>
         [RequireCImguiSystemFact]
        public void Filters_Get_WhenDefault_ReturnsDefault()
        {
            ImGuiTextFilter filter = default;
            Assert.Equal(default(ImVector), filter.Filters);
        }

        /// <summary>
        /// Tests that filters set should store value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Filters_Set_ShouldStoreValue()
        {
            ImGuiTextFilter filter = default;
            ImVector expected = new ImVector(1, 2, new System.IntPtr(3));
            filter.Filters = expected;
            Assert.Equal(expected, filter.Filters);
        }

        /// <summary>
        /// Tests that count grep get when default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void CountGrep_Get_WhenDefault_ReturnsZero()
        {
            ImGuiTextFilter filter = default;
            Assert.Equal(0, filter.CountGrep);
        }

        /// <summary>
        /// Tests that count grep set should store value
        /// </summary>
         [RequireCImguiSystemFact]
        public void CountGrep_Set_ShouldStoreValue()
        {
            ImGuiTextFilter filter = default;
            filter.CountGrep = 42;
            Assert.Equal(42, filter.CountGrep);
        }
    }
}
