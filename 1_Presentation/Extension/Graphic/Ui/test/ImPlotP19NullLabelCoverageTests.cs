// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19NullLabelCoverageTests.cs
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
    ///     The im plot p 19 null label coverage tests class
    /// </summary>
    public class ImPlotP19NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_0_3_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_0_4_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_0_5_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_0_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_1_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_2_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_3_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_4_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_5_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_4_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_5_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_0_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_1_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_2_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_3_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_4_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_5_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_0_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_1_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_2_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_3_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_4_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_5_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_0_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_1_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_2_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_3_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_4_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_5_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_4_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_5_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_1_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_1_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_1_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_1_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_1_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_1_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_1_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_1_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_1_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }
    }
}
