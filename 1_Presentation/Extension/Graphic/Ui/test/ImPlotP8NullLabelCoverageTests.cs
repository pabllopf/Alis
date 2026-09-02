// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8NullLabelCoverageTests.cs
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
    ///     The im plot p 8 null label coverage tests class
    /// </summary>
    public class ImPlotP8NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys1 = 0;
            sbyte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys1 = 0;
            sbyte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys1 = 0;
            byte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys1 = 0;
            byte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys1 = 0;
            byte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys1 = 0;
            byte ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys1 = 0;
            short ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys1 = 0;
            short ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys1 = 0;
            short ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_short_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys1 = 0;
            short ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys1 = 0;
            ushort ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys1 = 0;
            ushort ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys1 = 0;
            ushort ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ushort_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys1 = 0;
            ushort ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys1 = 0;
            int ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys1 = 0;
            int ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys1 = 0;
            int ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_int_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys1 = 0;
            int ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys1 = 0;
            uint ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys1 = 0;
            uint ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys1 = 0;
            uint ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_uint_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys1 = 0;
            uint ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys1 = 0;
            long ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys1 = 0;
            long ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys1 = 0;
            long ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_long_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys1 = 0;
            long ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys1 = 0;
            ulong ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys1 = 0;
            ulong ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys1 = 0;
            ulong ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShaded_ulong_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys1 = 0;
            ulong ys2 = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded((string)null, ref xs, ref ys1, ref ys2, 0, ImPlotShadedFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot shaded g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShadedG_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShadedG((string)null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     Tests the plot shaded g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotShadedG_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShadedG((string)null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ImPlotShadedFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_4_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_float_5_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_4_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_double_5_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_4_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_sbyte_5_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, values, 0, 1, 0.0)));
        }
    }
}
