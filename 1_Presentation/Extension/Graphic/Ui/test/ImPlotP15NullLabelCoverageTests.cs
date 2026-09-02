// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP15NullLabelCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im plot p 15 null label coverage tests class
    /// </summary>
    public class ImPlotP15NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_4_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_5_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_4_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_5_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_4_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_5_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_4_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_5_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_0_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_1_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_2_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_3_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_4_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_5_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_4_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_5_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_0_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_1_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_2_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_3_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_4_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_5_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 0.5, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }
    }
}
