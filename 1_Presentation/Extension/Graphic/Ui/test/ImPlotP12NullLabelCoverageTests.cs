// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12NullLabelCoverageTests.cs
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
    ///     The im plot p10 null label coverage tests class
    /// </summary>
    public class ImPlotP12NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_0_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_1_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_2_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_3_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_4_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_5_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_6_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_7_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_8_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_9_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_10_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_11_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_12_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_13_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_14_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_15_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_16_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_17_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_18_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_19_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_20_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_21_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_22_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_23_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_24_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_25_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_26_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_27_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_28_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_29_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_30_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange))));
        }

        /// <summary>
        ///     tests the plothistogram null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram_31_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram(null, values, 0, 0, 0, default(ImPlotRange), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_32_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_33_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_34_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_35_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect))));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_36_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_37_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_38_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_39_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_40_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect))));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_41_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_42_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_43_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_44_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_45_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect))));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_46_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0, default(ImPlotRect), ImPlotHistogramFlags.None)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_47_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_48_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plothistogram2d null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_49_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHistogram2D(null, ref xs, ref ys, 0, 0, 0)));
        }

    }
}
