// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP22.cs
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
    public class ImPlotTestP22
    {
        /// <summary>
        ///     Tests that plot line short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 45
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v45()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 34
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v34()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 22
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v22()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 23
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v23()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 12
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v12()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception v 11
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException_v11()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException_v2()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException_v3()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException_v4()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(float)));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception v 10
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException_v10()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException_v2()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException_v3()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException_v4()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(double)));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception v 9
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException_v9()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException_v2()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException_v3()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException_v4()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(sbyte)));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception v 8
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException_v8()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException_v2()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException_v3()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException_v4()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException_v5()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException_v2()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException_v3()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException_v4()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(short)));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException_v5()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException_v2()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException_v3()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException_v4()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(ushort)));
        }
    }
}