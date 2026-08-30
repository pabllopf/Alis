// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableSortSpecsCoverageTests.cs
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
    ///     The im gui table sort specs coverage tests class
    /// </summary>
    public class ImGuiTableSortSpecsCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiTableSortSpecs_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiTableSortSpecs specs = default(ImGuiTableSortSpecs);

            Assert.Equal(IntPtr.Zero, specs.Specs);
            Assert.Equal(0, specs.SpecsCount);
            Assert.Equal((byte)0, specs.SpecsDirty);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiTableSortSpecs_SetProperties_StoresValuesCorrectly()
        {
            ImGuiTableSortSpecs specs = new ImGuiTableSortSpecs
            {
                Specs = new IntPtr(1),
                SpecsCount = 2,
                SpecsDirty = 1
            };

            Assert.Equal(new IntPtr(1), specs.Specs);
            Assert.Equal(2, specs.SpecsCount);
            Assert.Equal((byte)1, specs.SpecsDirty);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiTableSortSpecs_IsValueType_CopyIsIndependent()
        {
            ImGuiTableSortSpecs original = new ImGuiTableSortSpecs { SpecsCount = 10 };
            ImGuiTableSortSpecs copy = original;

            copy.SpecsCount = 20;

            Assert.Equal(10, original.SpecsCount);
            Assert.Equal(20, copy.SpecsCount);
        }
    }
}