// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9NullLabelCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;

namespace Alis.Extension.Graphic.Ui.Extras.Plot.Test
{
    /// <summary>
    ///     The im plot p9 null label coverage tests class
    /// </summary>
    public class ImPlotP9NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_3_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_4_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_5_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_6_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_7_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_8_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_9_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_10_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_11_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_12_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_13_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_14_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotline null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_15_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine((string)null, ref xs, ref ys, 0, ImPlotLineFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotlineg null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLineG_16_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLineG((string)null, IntPtr.Zero, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     tests the plotlineg null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotLineG_17_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLineG((string)null, IntPtr.Zero, IntPtr.Zero, 0, ImPlotLineFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_18_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_19_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_20_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_21_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_22_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_23_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_24_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_25_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_26_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_27_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_28_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_29_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_30_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_31_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_32_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_33_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_34_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_35_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_36_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_37_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null element should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_38_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

    }
}
