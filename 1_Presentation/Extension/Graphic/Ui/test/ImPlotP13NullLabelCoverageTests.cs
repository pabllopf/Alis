// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13NullLabelCoverageTests.cs
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
    ///     The im plot p 13 null label coverage tests class
    /// </summary>
    public class ImPlotP13NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_byte_0_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_short_0_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ushort_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_int_0_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_uint_0_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_long_0_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairs_ulong_0_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairs((string)null, ref xs, ref ys, 0, ImPlotStairsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stairs g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairsG_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairsG((string)null, IntPtr.Zero, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     Tests the plot stairs g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStairsG_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStairsG((string)null, IntPtr.Zero, IntPtr.Zero, 0, ImPlotStairsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_4_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_5_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_float_6_NullLabel_ThrowsArgumentNullException()
        {
            float[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_4_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_5_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_double_6_NullLabel_ThrowsArgumentNullException()
        {
            double[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_4_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_5_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_sbyte_6_NullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0)));
        }

        /// <summary>
        ///     Tests the plot stems null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotStems_byte_4_NullLabel_ThrowsArgumentNullException()
        {
            byte[] values = null;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, values, 0, 0.0, 1.0, 0.0, ImPlotStemsFlags.None)));
        }
    }
}
