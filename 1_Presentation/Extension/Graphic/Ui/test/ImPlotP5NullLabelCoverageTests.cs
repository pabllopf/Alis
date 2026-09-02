// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5NullLabelCoverageTests.cs
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
    ///     The im plot p 5 null label coverage tests class
    /// </summary>
    public class ImPlotP5NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_0_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte neg = 0;
            sbyte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_0_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte neg = 0;
            sbyte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_0_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte neg = 0;
            sbyte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_0_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte neg = 0;
            byte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_0_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte neg = 0;
            byte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_0_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte neg = 0;
            byte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_0_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte neg = 0;
            byte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_0_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short neg = 0;
            short pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_0_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short neg = 0;
            short pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_0_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short neg = 0;
            short pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_0_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short neg = 0;
            short pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort neg = 0;
            ushort pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort neg = 0;
            ushort pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort neg = 0;
            ushort pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort neg = 0;
            ushort pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_0_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int neg = 0;
            int pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_0_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int neg = 0;
            int pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_0_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int neg = 0;
            int pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_0_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int neg = 0;
            int pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_0_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint neg = 0;
            uint pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_0_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint neg = 0;
            uint pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_0_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint neg = 0;
            uint pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_0_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint neg = 0;
            uint pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_0_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long neg = 0;
            long pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_0_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long neg = 0;
            long pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_0_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long neg = 0;
            long pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_0_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long neg = 0;
            long pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong neg = 0;
            ulong pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong neg = 0;
            ulong pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong neg = 0;
            ulong pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong neg = 0;
            ulong pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0, (string)null)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_4_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0, (string)null, new ImPlotPoint())));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_5_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0, (string)null, new ImPlotPoint(), new ImPlotPoint())));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_float_6_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0, (string)null, new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot heatmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotHeatmap((string)null, values, 0, 0, 0.0, 1.0, (string)null)));
        }
    }
}
