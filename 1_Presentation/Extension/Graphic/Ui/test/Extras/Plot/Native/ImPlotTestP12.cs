// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP12.cs
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
    public class ImPlotTestP12
    {
        /// <summary>
        ///     Tests that plot histogram byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new byte[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram byte array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ByteArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new byte[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram short array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ShortArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new short[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram short array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ShortArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new short[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram short array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ShortArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new short[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new short[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram u short array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UShortArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ushort[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram u short array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UShortArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ushort[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram u short array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UShortArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ushort[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram u short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ushort[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram int array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_IntArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram int array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_IntArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram int array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_IntArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_IntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram u int array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UIntArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new uint[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram u int array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UIntArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new uint[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram u int array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UIntArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new uint[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram u int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_UIntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new uint[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram long array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_LongArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new long[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram long array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_LongArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new long[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram long array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_LongArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new long[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_LongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new long[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot histogram u long array with bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ULongArray_WithBins_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ulong[] {1, 2, 3}, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram u long array with bar scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ULongArray_WithBarScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ulong[] {1, 2, 3}, 3, 10, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram u long array with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ULongArray_WithRange_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ulong[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange()));
        }

        /// <summary>
        ///     Tests that plot histogram u long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_ULongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("label", new ulong[] {1, 2, 3}, 3, 10, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Float_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d float with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Float_WithXBins_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d float with xy bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Float_WithXYBins_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d float with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Float_WithRange_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d float with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Float_WithFlags_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Double_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d double with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Double_WithXBins_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d double with xy bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Double_WithXYBins_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d double with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Double_WithRange_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d double with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Double_WithFlags_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_SByte_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d s byte with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_SByte_WithXBins_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d s byte with xy bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_SByte_WithXYBins_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d s byte with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_SByte_WithRange_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d s byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_SByte_WithFlags_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Byte_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d byte with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Byte_WithXBins_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d byte with xy bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Byte_WithXYBins_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d byte with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Byte_WithRange_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Byte_WithFlags_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 3, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }
    }
}