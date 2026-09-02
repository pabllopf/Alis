// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6NullLabelCoverageTests.cs
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
    ///     The im plot p 6 null label coverage tests class
    /// </summary>
    public class ImPlotP6NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_short_0_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_short_1_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_short_2_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_short_3_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ushort_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ushort_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ushort_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ushort_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_int_0_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_int_1_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_int_2_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_int_3_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_uint_0_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_uint_1_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_uint_2_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_uint_3_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_long_0_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_long_1_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_long_2_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_long_3_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ulong_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ulong_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ulong_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot inf lines null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ulong_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotInfLines((string)null, values, 0, ImPlotInfLinesFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_4_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_float_5_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_4_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_double_5_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_4_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_sbyte_5_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_4_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_byte_5_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_short_0_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_short_1_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_short_2_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_short_3_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     Tests the plot line null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_short_4_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, values, 0, 1, 0.0, ImPlotLineFlags.None, 0)));
        }
    }
}
