// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRangeTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot range test class
    /// </summary>
    	  
	 public class ImPlotRangeTest 
    {
        /// <summary>
        ///     Tests that min should be initialized
        /// </summary>
        [Fact]
        public void Min_ShouldBeInitialized()
        {
            ImPlotRange range = new ImPlotRange();
            Assert.Equal(default(double), range.Min);
        }

        /// <summary>
        ///     Tests that max should be initialized
        /// </summary>
        [Fact]
        public void Max_ShouldBeInitialized()
        {
            ImPlotRange range = new ImPlotRange();
            Assert.Equal(default(double), range.Max);
        }

        /// <summary>
        ///     Tests that min should set and get correctly
        /// </summary>
        [Fact]
        public void Min_Should_SetAndGetCorrectly()
        {
            ImPlotRange range = new ImPlotRange();
            double value = 10.0;
            range.Min = value;
            Assert.Equal(value, range.Min);
        }

        /// <summary>
        ///     Tests that max should set and get correctly
        /// </summary>
        [Fact]
        public void Max_Should_SetAndGetCorrectly()
        {
            ImPlotRange range = new ImPlotRange();
            double value = 20.0;
            range.Max = value;
            Assert.Equal(value, range.Max);
        }
    }
}