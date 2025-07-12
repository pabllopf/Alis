// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP16.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP16
    {
        /// <summary>
        ///     Tests that plot bars u int array no flags
        /// </summary>
        [Fact]
        public void PlotBars_UIntArray_NoFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new uint[] {1, 2, 3}, 3, 0.5, 0));
        }

        /// <summary>
        ///     Tests that plot bars u int array with flags
        /// </summary>
        [Fact]
        public void PlotBars_UIntArray_WithFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new uint[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars u int array with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_UIntArray_WithFlagsAndOffset()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new uint[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars u int array with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_UIntArray_WithFlagsOffsetAndStride()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new uint[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars long array no flags
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_NoFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot bars long array with bar size
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_WithBarSize()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars long array with bar size and shift
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_WithBarSizeAndShift()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3, 0.5, 0));
        }

        /// <summary>
        ///     Tests that plot bars long array with flags
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_WithFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars long array with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_WithFlagsAndOffset()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars long array with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_LongArray_WithFlagsOffsetAndStride()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new long[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars u long array no flags
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_NoFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot bars u long array with bar size
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_WithBarSize()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars u long array with bar size and shift
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_WithBarSizeAndShift()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3, 0.5, 0));
        }

        /// <summary>
        ///     Tests that plot bars u long array with flags
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_WithFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars u long array with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_WithFlagsAndOffset()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars u long array with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_ULongArray_WithFlagsOffsetAndStride()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", new ulong[] {1, 2, 3}, 3, 0.5, 0, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars float ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_NoFlags()
        {
            float xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars float ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithFlags()
        {
            float xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars float ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithFlagsAndOffset()
        {
            float xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars float ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithFlagsOffsetAndStride()
        {
            float xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars double ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_DoubleRef_NoFlags()
        {
            double xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars double ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_DoubleRef_WithFlags()
        {
            double xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars double ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_DoubleRef_WithFlagsAndOffset()
        {
            double xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars double ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_DoubleRef_WithFlagsOffsetAndStride()
        {
            double xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars s byte ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_SByteRef_NoFlags()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars s byte ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_SByteRef_WithFlags()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars s byte ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_SByteRef_WithFlagsAndOffset()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars s byte ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_SByteRef_WithFlagsOffsetAndStride()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars byte ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_ByteRef_NoFlags()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars byte ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_ByteRef_WithFlags()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars byte ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_ByteRef_WithFlagsAndOffset()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars byte ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_ByteRef_WithFlagsOffsetAndStride()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars short ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_ShortRef_NoFlags()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars short ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_ShortRef_WithFlags()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars short ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_ShortRef_WithFlagsAndOffset()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars short ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_ShortRef_WithFlagsOffsetAndStride()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars u short ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_UShortRef_NoFlags()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars u short ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_UShortRef_WithFlags()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars u short ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_UShortRef_WithFlagsAndOffset()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars u short ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_UShortRef_WithFlagsOffsetAndStride()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars int ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_IntRef_NoFlags()
        {
            int xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars int ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_IntRef_WithFlags()
        {
            int xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars int ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_IntRef_WithFlagsAndOffset()
        {
            int xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars int ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_IntRef_WithFlagsOffsetAndStride()
        {
            int xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars u int ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_UIntRef_NoFlags()
        {
            uint xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars u int ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_UIntRef_WithFlags()
        {
            uint xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars u int ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_UIntRef_WithFlagsAndOffset()
        {
            uint xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars u int ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_UIntRef_WithFlagsOffsetAndStride()
        {
            uint xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot bars long ref no flags
        /// </summary>
        [Fact]
        public void PlotBars_LongRef_NoFlags()
        {
            long xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars long ref with flags
        /// </summary>
        [Fact]
        public void PlotBars_LongRef_WithFlags()
        {
            long xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars long ref with flags and offset
        /// </summary>
        [Fact]
        public void PlotBars_LongRef_WithFlagsAndOffset()
        {
            long xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot bars long ref with flags offset and stride
        /// </summary>
        [Fact]
        public void PlotBars_LongRef_WithFlagsOffsetAndStride()
        {
            long xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 3, 0.5, ImPlotBarsFlags.None, 1, 2));
        }
    }
}