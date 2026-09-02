// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP16NullLabelCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------
using System;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;
namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im plot p 16 null label coverage tests class
    /// </summary>
    public class ImPlotP16NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_0_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_1_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_2_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_3_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_4_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_0_5_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_4_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_5_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_1_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_2_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_3_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_4_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_0_5_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, values, 0, 1.0, 0.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_1_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_1_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_1_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_float_1_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_1_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_1_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_1_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_double_1_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_sbyte_1_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_byte_1_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_1_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_1_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_1_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_short_1_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_1_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_1_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_1_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ushort_1_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_1_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_1_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_1_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_int_1_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_1_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_1_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_1_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_uint_1_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_1_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_1_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_1_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }
    }
}
