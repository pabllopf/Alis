// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotColTest.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotCol" /> enum values.
    /// </summary>
    public class ImPlotColTest
    {
        /// <summary>
        ///     Verifies that Line has the expected value of 0.
        /// </summary>
        [Fact]
        public void Line_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.Line;
            Assert.Equal(0, (int)color);
        }

        /// <summary>
        ///     Verifies that Fill has the expected value of 1.
        /// </summary>
        [Fact]
        public void Fill_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.Fill;
            Assert.Equal(1, (int)color);
        }

        /// <summary>
        ///     Verifies that MarkerOutline has the expected value of 2.
        /// </summary>
        [Fact]
        public void MarkerOutline_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.MarkerOutline;
            Assert.Equal(2, (int)color);
        }

        /// <summary>
        ///     Verifies that MarkerFill has the expected value of 3.
        /// </summary>
        [Fact]
        public void MarkerFill_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.MarkerFill;
            Assert.Equal(3, (int)color);
        }

        /// <summary>
        ///     Verifies that ErrorBar has the expected value of 4.
        /// </summary>
        [Fact]
        public void ErrorBar_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.ErrorBar;
            Assert.Equal(4, (int)color);
        }

        /// <summary>
        ///     Verifies that FrameBg has the expected value of 5.
        /// </summary>
        [Fact]
        public void FrameBg_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.FrameBg;
            Assert.Equal(5, (int)color);
        }

        /// <summary>
        ///     Verifies that PlotBg has the expected value of 6.
        /// </summary>
        [Fact]
        public void PlotBg_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.PlotBg;
            Assert.Equal(6, (int)color);
        }

        /// <summary>
        ///     Verifies that PlotBorder has the expected value of 7.
        /// </summary>
        [Fact]
        public void PlotBorder_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.PlotBorder;
            Assert.Equal(7, (int)color);
        }

        /// <summary>
        ///     Verifies that LegendBg has the expected value of 8.
        /// </summary>
        [Fact]
        public void LegendBg_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.LegendBg;
            Assert.Equal(8, (int)color);
        }

        /// <summary>
        ///     Verifies that LegendBorder has the expected value of 9.
        /// </summary>
        [Fact]
        public void LegendBorder_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.LegendBorder;
            Assert.Equal(9, (int)color);
        }

        /// <summary>
        ///     Verifies that LegendText has the expected value of 10.
        /// </summary>
        [Fact]
        public void LegendText_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.LegendText;
            Assert.Equal(10, (int)color);
        }

        /// <summary>
        ///     Verifies that TitleText has the expected value of 11.
        /// </summary>
        [Fact]
        public void TitleText_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.TitleText;
            Assert.Equal(11, (int)color);
        }

        /// <summary>
        ///     Verifies that InlayText has the expected value of 12.
        /// </summary>
        [Fact]
        public void InlayText_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.InlayText;
            Assert.Equal(12, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisText has the expected value of 13.
        /// </summary>
        [Fact]
        public void AxisText_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisText;
            Assert.Equal(13, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisGrid has the expected value of 14.
        /// </summary>
        [Fact]
        public void AxisGrid_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisGrid;
            Assert.Equal(14, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisTick has the expected value of 15.
        /// </summary>
        [Fact]
        public void AxisTick_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisTick;
            Assert.Equal(15, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisBg has the expected value of 16.
        /// </summary>
        [Fact]
        public void AxisBg_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisBg;
            Assert.Equal(16, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisBgHovered has the expected value of 17.
        /// </summary>
        [Fact]
        public void AxisBgHovered_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisBgHovered;
            Assert.Equal(17, (int)color);
        }

        /// <summary>
        ///     Verifies that AxisBgActive has the expected value of 18.
        /// </summary>
        [Fact]
        public void AxisBgActive_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.AxisBgActive;
            Assert.Equal(18, (int)color);
        }

        /// <summary>
        ///     Verifies that Selection has the expected value of 19.
        /// </summary>
        [Fact]
        public void Selection_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.Selection;
            Assert.Equal(19, (int)color);
        }

        /// <summary>
        ///     Verifies that Crosshairs has the expected value of 20.
        /// </summary>
        [Fact]
        public void Crosshairs_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.Crosshairs;
            Assert.Equal(20, (int)color);
        }

        /// <summary>
        ///     Verifies that Count has the expected value of 21.
        /// </summary>
        [Fact]
        public void Count_ShouldHaveCorrectValue()
        {
            ImPlotCol color = ImPlotCol.Count;
            Assert.Equal(21, (int)color);
        }

        /// <summary>
        ///     Verifies that all enum values are sequential from 0 to Count.
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            ImPlotCol[] values = (ImPlotCol[])Enum.GetValues(typeof(ImPlotCol));

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(i, (int)values[i]);
            }
        }
    }
}
