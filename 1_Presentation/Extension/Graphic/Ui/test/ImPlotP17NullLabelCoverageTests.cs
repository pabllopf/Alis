// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP17NullLabelCoverageTests.cs
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
    ///     The im plot p 17 null label coverage tests class
    /// </summary>
    public class ImPlotP17NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_long_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBars_ulong_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBars((string)null, ref xs, ref ys, 0, 1.0, ImPlotBarsFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot bars g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarsG_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarsG((string)null, IntPtr.Zero, IntPtr.Zero, 0, 1.0)));
        }

        /// <summary>
        ///     Tests the plot bars g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarsG_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarsG((string)null, IntPtr.Zero, IntPtr.Zero, 0, 1.0, ImPlotBarsFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_float_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_float_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_float_2_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_float_3_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_double_0_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_double_1_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_double_2_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_double_3_NullLabel_ThrowsArgumentNullException()
        {
            double xs = 0;
            double ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_sbyte_0_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_sbyte_1_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_sbyte_2_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_sbyte_3_NullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 0;
            sbyte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_byte_0_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_byte_1_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_byte_2_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_byte_3_NullLabel_ThrowsArgumentNullException()
        {
            byte xs = 0;
            byte ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_short_0_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_short_1_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_short_2_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_short_3_NullLabel_ThrowsArgumentNullException()
        {
            short xs = 0;
            short ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ushort_0_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ushort_1_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ushort_2_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ushort_3_NullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_int_0_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_int_1_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_int_2_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_int_3_NullLabel_ThrowsArgumentNullException()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_uint_0_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_uint_1_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_uint_2_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_uint_3_NullLabel_ThrowsArgumentNullException()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_long_0_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_long_1_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_long_2_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_long_3_NullLabel_ThrowsArgumentNullException()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ulong_0_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ulong_1_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ulong_2_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0)));
        }

        /// <summary>
        ///     Tests the plot digital null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigital_ulong_3_NullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigital((string)null, ref xs, ref ys, 0, ImPlotDigitalFlags.None, 0, 1)));
        }

        /// <summary>
        ///     Tests the plot digital g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigitalG_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigitalG((string)null, IntPtr.Zero, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     Tests the plot digital g null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDigitalG_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDigitalG((string)null, IntPtr.Zero, IntPtr.Zero, 0, ImPlotDigitalFlags.None)));
        }

        /// <summary>
        ///     Tests the plot dummy null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDummy_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDummy((string)null)));
        }

        /// <summary>
        ///     Tests the plot dummy null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotDummy_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotDummy((string)null, ImPlotDummyFlags.None)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_0_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0)));
        }

        /// <summary>
        ///     Tests the plot error bars null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_1_NullLabel_ThrowsArgumentNullException()
        {
            float xs = 0;
            float ys = 0;
            float err = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotErrorBars((string)null, ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None)));
        }
    }
}
