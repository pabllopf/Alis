// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP10.cs
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
    public class ImPlotTestP10
    {
        /// <summary>
        ///     Tests that plot shaded short array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_ShortArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded short array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_ShortArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded short array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_ShortArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded short array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_ShortArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded short array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_ShortArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_3Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_4Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded u short array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_UShortArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ushort[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded int array 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_3Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot shaded int array 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_4Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded int array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded int array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded int array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded int array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded int array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_IntArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_3Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_4Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded u int array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_UIntArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded long array 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_3Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot shaded long array 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_4Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded long array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded long array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded long array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded long array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded long array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_LongArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_3Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_4Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_5Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_6Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_7Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 8 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_8Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded u long array 9 params
        /// </summary>
        [Fact]
        public void PlotShaded_ULongArray_9Params()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded float ref 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_FloatRef_3Params()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot shaded float ref 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_FloatRef_4Params()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded float ref 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_FloatRef_5Params()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded float ref 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_FloatRef_6Params()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded float ref 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_FloatRef_7Params()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded double ref 3 params
        /// </summary>
        [Fact]
        public void PlotShaded_DoubleRef_3Params()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot shaded double ref 4 params
        /// </summary>
        [Fact]
        public void PlotShaded_DoubleRef_4Params()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded double ref 5 params
        /// </summary>
        [Fact]
        public void PlotShaded_DoubleRef_5Params()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded double ref 6 params
        /// </summary>
        [Fact]
        public void PlotShaded_DoubleRef_6Params()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded double ref 7 params
        /// </summary>
        [Fact]
        public void PlotShaded_DoubleRef_7Params()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", ref xs, ref ys, 3, 0.0, ImPlotShadedFlags.None, 0, 2));
        }

        /// <summary>
        ///     Tests that plot shaded byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new byte[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded byte with x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new byte[0], 0, 0.0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot shaded byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new byte[0], 0, 0.0, 0.0, 0.0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot shaded byte with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new byte[0], 0, 0.0, 0.0, 0.0, ImPlotShadedFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot shaded byte with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new byte[0], 0, 0.0, 0.0, 0.0, ImPlotShadedFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot shaded short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[0], 0));
        }

        /// <summary>
        ///     Tests that plot shaded short with y ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_WithYRef_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShaded("label", new short[0], 0, 0.0));
        }
    }
}