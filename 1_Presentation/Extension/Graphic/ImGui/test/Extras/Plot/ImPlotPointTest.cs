// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotPointTest.cs
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
    ///     The im plot point test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImPlotPointTest 
    {
        /// <summary>
        ///     Tests that x should be initialized
        /// </summary>
        [Fact]
        public void X_ShouldBeInitialized()
        {
            ImPlotPoint point = new ImPlotPoint();
            Assert.Equal(default(double), point.X);
        }

        /// <summary>
        ///     Tests that y should be initialized
        /// </summary>
        [Fact]
        public void Y_ShouldBeInitialized()
        {
            ImPlotPoint point = new ImPlotPoint();
            Assert.Equal(default(double), point.Y);
        }

        /// <summary>
        ///     Tests that x should set and get correctly
        /// </summary>
        [Fact]
        public void X_Should_SetAndGetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint();
            double value = 10.0;
            point.X = value;
            Assert.Equal(value, point.X);
        }

        /// <summary>
        ///     Tests that y should set and get correctly
        /// </summary>
        [Fact]
        public void Y_Should_SetAndGetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint();
            double value = 20.0;
            point.Y = value;
            Assert.Equal(value, point.Y);
        }
    }
}