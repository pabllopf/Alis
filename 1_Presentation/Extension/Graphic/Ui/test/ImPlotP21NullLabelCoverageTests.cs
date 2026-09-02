// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP21NullLabelCoverageTests.cs
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
    ///     The im plot p 21 null label coverage tests class
    /// </summary>
    public class ImPlotP21NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_4_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_4_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_4_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_4_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_4_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_4_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_4_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_4_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys, 0, 0.0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_float_3_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys1 = 0;
            float ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_float_3_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys1 = 0;
            float ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_float_3_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys1 = 0;
            float ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_float_3_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys1 = 0;
            float ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_double_3_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys1 = 0;
            double ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_double_3_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys1 = 0;
            double ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_double_3_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys1 = 0;
            double ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_double_3_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys1 = 0;
            double ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_3_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys1 = 0;
            sbyte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_3_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys1 = 0;
            sbyte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }
    }
}
