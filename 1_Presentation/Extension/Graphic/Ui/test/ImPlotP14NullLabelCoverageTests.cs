// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14NullLabelCoverageTests.cs
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
    public class ImPlotP14NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_0_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_1_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_2_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_3_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_4_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_5_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_6_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_7_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_8_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_9_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_10_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_11_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_12_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_13_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_14_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_15_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_16_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_17_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_18_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_19_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_20_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_21_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_22_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_23_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_24_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_25_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_26_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_27_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_28_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_29_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_30_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_31_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_32_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_33_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_34_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_35_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_36_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_37_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_38_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_39_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_40_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_41_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_42_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_43_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, values, 0, 0, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_44_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_45_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_46_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_47_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_48_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_49_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_50_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_51_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_52_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_53_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_54_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_55_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_56_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_57_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_58_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_59_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_60_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_61_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_62_NullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_63_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_64_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_65_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_66_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_67_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0, ImPlotStemsFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_68_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotstems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_69_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0)));
        }

    }
}
