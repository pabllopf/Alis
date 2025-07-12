// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP19.cs
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
    public class ImPlotTestP19
    {
        /// <summary>
        ///     Tests that plot stairs byte array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs byte array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs byte array with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs short array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs short array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs short array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs short array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs short array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ShortArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs u short array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs u short array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs u short array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs u short array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs u short array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UShortArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs int array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs int array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs int array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs int array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs int array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_IntArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs u int array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs u int array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs u int array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs u int array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs u int array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_UIntArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs long array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs long array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs long array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs long array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs long array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_LongArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs u long array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs u long array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs u long array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs u long array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs u long array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ULongArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs float ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_FloatRef_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stairs float ref with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_FloatRef_WithFlags_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs float ref with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_FloatRef_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs float ref with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_FloatRef_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs double ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_DoubleRef_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stairs double ref with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_DoubleRef_WithFlags_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs double ref with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_DoubleRef_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs double ref with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_DoubleRef_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs s byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByteRef_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stairs s byte ref with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByteRef_WithFlags_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs s byte ref with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByteRef_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1));
        }

        /// <summary>
        ///     Tests that plot stairs s byte ref with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByteRef_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1, 2));
        }

        /// <summary>
        ///     Tests that plot stairs byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteRef_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stairs byte ref with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteRef_WithFlags_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs byte ref with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteRef_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", ref xs, ref ys, 3, ImPlotStairsFlags.None, 1));
        }
    }
}