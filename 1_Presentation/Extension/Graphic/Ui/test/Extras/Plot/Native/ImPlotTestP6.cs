// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP6.cs
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
    public class ImPlotTestP6
    {
        /// <summary>
        ///     Tests that plot inf lines byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ByteArray_ThrowsDllNotFoundException_v33()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_ThrowsDllNotFoundException_v33()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ShortArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ShortArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UShortArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UShortArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot inf lines int array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_IntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_IntArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_IntArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UIntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UIntArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_UIntArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot inf lines long array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_LongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_LongArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_LongArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ULongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ULongArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotInfLines_ULongArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot line float array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_FloatArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot line double array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_DoubleArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot line s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_SByteArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot line byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ByteArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot line short array throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ShortArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ShortArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ShortArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v33_PlotLine_ShortArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new int[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[0], 0));
        }

        /// <summary>
        ///     Tests that plot line float array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new float[0], 0));
        }

        /// <summary>
        ///     Tests that plot line double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new double[0], 0));
        }

        /// <summary>
        ///     Tests that plot line s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[0], 0));
        }

        /// <summary>
        ///     Tests that plot line byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[0], 0));
        }

        /// <summary>
        ///     Tests that plot line short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[0], 0));
        }
    }
}