// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP10NullLabelCoverageTests.cs
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
    public class ImPlotP10NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_0_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_1_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_2_NullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_3_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_4_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_5_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_6_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_7_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_8_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_9_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_10_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_11_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_12_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_13_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_14_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_15_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_16_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_17_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_18_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_19_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_20_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_21_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotscatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_22_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotscatterg null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatterG_23_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatterG(null, IntPtr.Zero, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     tests the plotscatterg null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatterG_24_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatterG(null, IntPtr.Zero, IntPtr.Zero, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_25_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_26_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_27_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_28_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_29_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_30_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_31_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = Array.Empty<float>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_32_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_33_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_34_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_35_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_36_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_37_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_38_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = Array.Empty<double>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_39_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_40_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_41_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_42_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_43_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_44_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_45_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = Array.Empty<sbyte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_46_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_47_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_48_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_49_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_50_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_51_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_52_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = Array.Empty<byte>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_53_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_54_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_55_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_56_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_57_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_58_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_59_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = Array.Empty<short>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_60_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_61_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_62_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_63_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_64_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_65_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_66_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = Array.Empty<ushort>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_67_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_68_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_69_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_70_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_71_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_72_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_73_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = Array.Empty<int>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_74_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_75_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_76_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_77_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_78_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_79_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_80_NullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = Array.Empty<uint>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_81_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_82_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_83_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_84_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_85_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_86_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_87_NullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = Array.Empty<long>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_88_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_89_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_90_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_91_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_92_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_93_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_94_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = Array.Empty<ulong>();
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 0, 0, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_95_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_96_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_97_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_98_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_99_NullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_100_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_101_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_102_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_103_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     tests the plotshaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_104_NullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 0, 0, ImPlotShadedFlags.None, 0, 0)));
        }

    }
}
