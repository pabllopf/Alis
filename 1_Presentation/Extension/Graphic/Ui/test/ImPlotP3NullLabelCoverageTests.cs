// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP3NullLabelCoverageTests.cs
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
    ///     The im plot p 3 null label coverage tests class
    /// </summary>
    public class ImPlotP3NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_3_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_3_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_3_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_3_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_3_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_3_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_3_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_3_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_3_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_3_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_3_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_3_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_3_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_byte_3_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            byte err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_3_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_3_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_3_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_short_3_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            short err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_3_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_3_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_3_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ushort_3_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            ushort err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_3_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_3_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_3_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_int_3_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            int err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_3_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_3_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_3_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_uint_3_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            uint err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_3_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_3_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_3_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_long_3_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            long err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_3_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_3_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_3_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ulong_3_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            ulong err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_4_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float neg = 0;
            float pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_4_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float neg = 0;
            float pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_4_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float neg = 0;
            float pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_float_4_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float neg = 0;
            float pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_4_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double neg = 0;
            double pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_4_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double neg = 0;
            double pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_4_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double neg = 0;
            double pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_double_4_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            double neg = 0;
            double pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_sbyte_4_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            sbyte neg = 0;
            sbyte pos = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref neg, ref pos, 0)));
        }
    }
}
