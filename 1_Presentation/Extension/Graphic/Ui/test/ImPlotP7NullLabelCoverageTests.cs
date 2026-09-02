// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//  --------------------------------------------------------------------------
//  File:ImPlotP7NullLabelCoverageTests.cs
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
//  Copyright (c) 2021 GNU General Public License v3.0
//  --------------------------------------------------------------------------
using System;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;
namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im plot p 7 null label coverage tests class
    /// </summary>
    public class ImPlotP7NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_byte_0_5_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_0_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_1_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_2_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_3_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_4_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_0_5_NullLabel_ThrowsArgumentNullException()
        {
            short[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_4_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ushort_0_5_NullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_0_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_1_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_2_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_3_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_4_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_int_0_5_NullLabel_ThrowsArgumentNullException()
        {
            int[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_0_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_1_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_2_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_3_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_4_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_uint_0_5_NullLabel_ThrowsArgumentNullException()
        {
            uint[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_0_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_1_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_2_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_3_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_4_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_long_0_5_NullLabel_ThrowsArgumentNullException()
        {
            long[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_4_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_ulong_0_5_NullLabel_ThrowsArgumentNullException()
        {
            ulong[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, values, 0, 1, 0.0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_float_1_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_float_1_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_float_1_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_float_1_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_double_1_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_double_1_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_double_1_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_double_1_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_sbyte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_sbyte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_sbyte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_sbyte_1_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_byte_1_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_byte_1_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_byte_1_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_byte_1_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0, ImPlotScatterFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot scatter null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotScatter_short_1_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter((string)null, ref xs, ref ys, 0)));
        }
    }
}
