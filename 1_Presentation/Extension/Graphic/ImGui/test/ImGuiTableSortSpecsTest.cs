// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableSortSpecsTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui table sort specs test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImGuiTableSortSpecsTest 
    {
        /// <summary>
        ///     Tests that specs should set and get correctly
        /// </summary>
        [Fact]
        public void Specs_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            IntPtr specs = new IntPtr(789);
            tableSortSpecs.Specs = specs;
            Assert.Equal(specs, tableSortSpecs.Specs);
        }

        /// <summary>
        ///     Tests that specs count should set and get correctly
        /// </summary>
        [Fact]
        public void SpecsCount_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            tableSortSpecs.SpecsCount = 3;
            Assert.Equal(3, tableSortSpecs.SpecsCount);
        }

        /// <summary>
        ///     Tests that specs dirty should set and get correctly
        /// </summary>
        [Fact]
        public void SpecsDirty_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            tableSortSpecs.SpecsDirty = 1;
            Assert.Equal(1, tableSortSpecs.SpecsDirty);
        }
    }
}