// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP13.cs
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
    public class ImPlotTestP13
    {
        /// <summary>
        ///     Tests that plot stems should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotStems_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new byte[] {1, 2, 3}, 3, 1.0, 1.0, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new byte[] {1, 2, 3}, 3, 1.0, 1.0, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotStems_ShouldThrowDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", new byte[] {1, 2, 3}, 3, 1.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line int array should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ShouldThrowDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ShouldThrowDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line long array should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ShouldThrowDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ShouldThrowDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ShouldThrowDllNotFoundException_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line float ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ShouldThrowDllNotFoundException_v2()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line float ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ShouldThrowDllNotFoundException_v3()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ShouldThrowDllNotFoundException_v4()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(float)));
        }

        /// <summary>
        ///     Tests that plot line double ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ShouldThrowDllNotFoundException_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line double ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ShouldThrowDllNotFoundException_v2()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line double ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ShouldThrowDllNotFoundException_v3()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line double ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ShouldThrowDllNotFoundException_v4()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(double)));
        }

        /// <summary>
        ///     Tests that plot line s byte ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ShouldThrowDllNotFoundException_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line s byte ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ShouldThrowDllNotFoundException_v2()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line s byte ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ShouldThrowDllNotFoundException_v3()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line s byte ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ShouldThrowDllNotFoundException_v4()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(sbyte)));
        }

        /// <summary>
        ///     Tests that plot line byte ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ShouldThrowDllNotFoundException_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line byte ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ShouldThrowDllNotFoundException_v2()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line byte ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ShouldThrowDllNotFoundException_v3()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line byte ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ShouldThrowDllNotFoundException_v4()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        ///     Tests that plot line short ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ShouldThrowDllNotFoundException_v1()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line short ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ShouldThrowDllNotFoundException_v2()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line short ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ShouldThrowDllNotFoundException_v3()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line short ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ShouldThrowDllNotFoundException_v4()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(short)));
        }

        /// <summary>
        ///     Tests that plot line u short ref should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ShouldThrowDllNotFoundException_v1()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot line u short ref should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ShouldThrowDllNotFoundException_v2()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line u short ref should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ShouldThrowDllNotFoundException_v3()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line u short ref should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ShouldThrowDllNotFoundException_v4()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(ushort)));
        }
    }
}