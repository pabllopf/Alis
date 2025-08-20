// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP18.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test 18 class
    /// </summary>
    public class ImPlotTestP18
    {
        /// <summary>
        ///     Tests that plot histogram 2 d u int 32 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt32_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 32 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt32_WithFlags_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d int 64 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Int64_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d int 64 with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Int64_WithXBins_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d int 64 with x bins y bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Int64_WithXBinsYBins_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d int 64 with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Int64_WithRange_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d int 64 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_Int64_WithFlags_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 64 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt64_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 64 with x bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt64_WithXBins_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 64 with x bins y bins throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt64_WithXBinsYBins_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 64 with range throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt64_WithRange_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect()));
        }

        /// <summary>
        ///     Tests that plot histogram 2 d u int 64 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram2D_UInt64_WithFlags_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram2D("label", ref xs, ref ys, 10, 10, 10, new ImPlotRect(), ImPlotHistogramFlags.None));
        }

        /// <summary>
        ///     Tests that plot image throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotImage_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotImage("label", IntPtr.Zero, new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot image with uv 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotImage_WithUV0_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotImage("label", IntPtr.Zero, new ImPlotPoint(), new ImPlotPoint(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that plot image with uv 0 uv 1 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotImage_WithUV0UV1_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotImage("label", IntPtr.Zero, new ImPlotPoint(), new ImPlotPoint(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that plot image throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotImage_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotImage("label", IntPtr.Zero, new ImPlotPoint(), new ImPlotPoint(), new Vector2F(), new Vector2F(), new Vector4F()));
        }

        /// <summary>
        ///     Tests that plot image with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotImage_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotImage("label", IntPtr.Zero, new ImPlotPoint(), new ImPlotPoint(), new Vector2F(), new Vector2F(), new Vector4F(), ImPlotImageFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Float_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new float[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines float with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Float_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new float[0], 0, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines float with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Float_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new float[0], 0, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines float with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Float_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new float[0], 0, ImPlotInfLinesFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new double[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines double with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Double_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new double[0], 0, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines double with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Double_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new double[0], 0, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines double with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Double_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new double[0], 0, ImPlotInfLinesFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_SByte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new sbyte[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines s byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_SByte_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new sbyte[0], 0, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines s byte with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_SByte_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new sbyte[0], 0, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines s byte with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_SByte_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new sbyte[0], 0, ImPlotInfLinesFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[0], 0));
        }

        /// <summary>
        ///     Tests that plot inf lines byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Byte_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[0], 0, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines byte with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Byte_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[0], 0, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines byte with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_Byte_WithStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[0], 0, ImPlotInfLinesFlags.None, 0, 0));
        }
    }
}