// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP14.cs
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
    public class ImPlotTestP14
    {
        /// <summary>
        ///     Tests that plot stems int array 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_IntArray_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stems int array 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_IntArray_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems int array 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_IntArray_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems int array 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_IntArray_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems int array 9 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_IntArray_9Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u int array 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stems u int array 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u int array 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stems u int array 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u int array 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems u int array 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems u int array 9 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UIntArray_9Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new uint[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems long array 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stems long array 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems long array 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stems long array 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems long array 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems long array 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems long array 9 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_LongArray_9Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new long[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u long array 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stems u long array 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u long array 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stems u long array 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u long array 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems u long array 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems u long array 9 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ULongArray_9Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ulong[] {1, 2, 3}, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems float ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_5Params_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems float ref 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_6Params_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems float ref 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_7Params_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems float ref 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_8Params_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems double ref 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_4Params_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stems double ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_5Params_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems double ref 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_6Params_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems double ref 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_7Params_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems double ref 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_8Params_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems s byte ref 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_SByteRef_4Params_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stems s byte ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_SByteRef_5Params_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems s byte ref 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_SByteRef_6Params_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems s byte ref 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_SByteRef_7Params_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems s byte ref 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_SByteRef_8Params_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems byte ref 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ByteRef_4Params_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stems byte ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ByteRef_5Params_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems byte ref 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ByteRef_6Params_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems byte ref 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ByteRef_7Params_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems byte ref 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ByteRef_8Params_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems short ref 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShortRef_4Params_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stems short ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShortRef_5Params_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems short ref 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShortRef_6Params_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems short ref 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShortRef_7Params_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems short ref 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShortRef_8Params_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u short ref 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UShortRef_4Params_v1()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot stems u short ref 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStems_UShortRef_5Params_v1()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 3, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new byte[0], 0, 0.0, 0.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems byte array with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ByteArray_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new byte[0], 0, 0.0, 0.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0));
        }

        /// <summary>
        ///     Tests that plot stems short array with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithRef_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems short array with scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems short array with start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0, 0.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems short array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0, 0.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems short array with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ShortArray_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new short[0], 0, 0.0, 0.0, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ushort[0], 0));
        }

        /// <summary>
        ///     Tests that plot stems u short array with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UShortArray_WithRef_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new ushort[0], 0, 0.0));
        }
    }
}