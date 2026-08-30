// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextFilterCoverageTests.cs
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

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui text filter coverage tests class
    /// </summary>
    public class ImGuiTextFilterCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiTextFilter_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiTextFilter filter = default(ImGuiTextFilter);

            Assert.Null(filter.InputBuf);
            Assert.Equal(0, filter.Filters.Size);
            Assert.Equal(0, filter.CountGrep);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiTextFilter_SetProperties_StoresValuesCorrectly()
        {
            byte[] inputBuf = { 1, 2, 3 };
            ImGuiTextFilter filter = new ImGuiTextFilter
            {
                InputBuf = inputBuf,
                Filters = new ImVector { Size = 2, Capacity = 4, Data = new IntPtr(8) },
                CountGrep = 5
            };

            Assert.Same(inputBuf, filter.InputBuf);
            Assert.Equal(2, filter.Filters.Size);
            Assert.Equal(4, filter.Filters.Capacity);
            Assert.Equal(new IntPtr(8), filter.Filters.Data);
            Assert.Equal(5, filter.CountGrep);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiTextFilter_IsValueType_CopyIsIndependent()
        {
            ImGuiTextFilter original = new ImGuiTextFilter { CountGrep = 10 };
            ImGuiTextFilter copy = original;

            copy.CountGrep = 20;

            Assert.Equal(10, original.CountGrep);
            Assert.Equal(20, copy.CountGrep);
        }
    }
}