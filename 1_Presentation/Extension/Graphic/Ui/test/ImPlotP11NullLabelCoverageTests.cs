// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11NullLabelCoverageTests.cs
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
    ///     The im plot p11 null label coverage tests class
    /// </summary>
    public class ImPlotP11NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_0_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_1_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_2_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_3_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_4_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_5_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_6_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_7_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_8_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_9_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_10_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_11_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_12_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_13_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_14_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_15_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_16_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_17_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0)));
        }

        /// <summary>
        ///     tests the plotpiechart null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_18_NullLabel_ShouldThrowArgumentNullException()
        {
            string[] labelIds = new string[] { "A", null };
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labelIds, values, 0, 0, 0, 0, (string)null, 0, ImPlotPieChartFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_19_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_20_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_21_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_22_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_23_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_24_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_25_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_26_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_27_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_28_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_29_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_30_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_31_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_32_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_33_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_34_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_35_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_36_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_37_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_38_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_39_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_40_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_41_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 0, 0, ImPlotScatterFlags.None, 0)));
        }

    }
}
