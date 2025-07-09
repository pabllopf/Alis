// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP7.cs
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
    public class ImPlotTestP7
    {
        /// <summary>
        ///     Tests that plot scatter byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot scatter short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter short array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_ShortArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new short[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_ShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new short[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_ShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter u short array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_UShortArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ushort[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter u short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_UShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter u short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_UShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter int array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_IntArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_IntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_IntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter u int array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_UIntArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new uint[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter u int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_UIntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter u int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_UIntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter long array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_LongArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new long[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_LongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new long[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_LongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot scatter u long array throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_ULongArray_ThrowsDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ulong[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter u long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_ULongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter u long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_ULongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter float ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_FloatRef_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot scatter float ref throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_FloatRef_ThrowsDllNotFoundException_v1()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter double ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_DoubleRef_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot scatter double ref throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_DoubleRef_ThrowsDllNotFoundException_v1()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter s byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_SByteRef_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot scatter s byte ref throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_SByteRef_ThrowsDllNotFoundException_v1()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_ByteRef_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot scatter byte ref throws dll not found exception v 1
        /// </summary>
        [Fact]
        public void PlotScatter_ByteRef_ThrowsDllNotFoundException_v1()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3, ImPlotScatterFlags.None));
        }

        /// <summary>
        ///     Tests that plot scatter short ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_ShortRef_ThrowsDllNotFoundException()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("label", ref xs, ref ys, 3));
        }
    }
}