// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP20.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP20
    {
        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 22
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v22()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 24
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v24()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new uint[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap u int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_UIntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new uint[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_UIntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new uint[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new long[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_LongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new long[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_LongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new long[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new ulong[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap u long array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_ULongArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new ulong[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u long array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_ULongArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("A", new ulong[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram float array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_FloatArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0f}, 1));
        }

        /// <summary>
        ///     Tests that plot histogram float array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHistogram_FloatArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0f}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot histogram float array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHistogram_FloatArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0f}, 1, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0}, 1));
        }

        /// <summary>
        ///     Tests that plot histogram double array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHistogram_DoubleArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot histogram double array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHistogram_DoubleArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new[] {1.0}, 1, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHistogram_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new sbyte[] {1}, 1));
        }

        /// <summary>
        ///     Tests that plot histogram s byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHistogram_SByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new sbyte[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot histogram s byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHistogram_SByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new sbyte[] {1}, 1, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot histogram byte array throws dll not found exception v 44
        /// </summary>
        [Fact]
        public void PlotHistogram_ByteArray_ThrowsDllNotFoundException_v44()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new byte[] {1}, 1));
        }

        /// <summary>
        ///     Tests that plot histogram byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHistogram_ByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new byte[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot histogram byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHistogram_ByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHistogram("A", new byte[] {1}, 1, 1, 1.0));
        }

        /// <summary>
        ///     Tests that calc circle auto segment count throws dll not found exception
        /// </summary>
        [Fact]
        public void _CalcCircleAutoSegmentCount_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr._CalcCircleAutoSegmentCount(0));
        }

        /// <summary>
        ///     Tests that clear free memory throws dll not found exception
        /// </summary>
        [Fact]
        public void _ClearFreeMemory_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ClearFreeMemory());
        }

        /// <summary>
        ///     Tests that on changed clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedClipRect());
        }

        /// <summary>
        ///     Tests that on changed texture id throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedTextureID_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedTextureID());
        }

        /// <summary>
        ///     Tests that on changed vtx offset throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedVtxOffset_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedVtxOffset());
        }

        /// <summary>
        ///     Tests that path arc to fast ex throws dll not found exception
        /// </summary>
        [Fact]
        public void _PathArcToFastEx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcToFastEx(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMaxLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max label fmt bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMaxLabelFmtBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max label fmt bounds min bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMaxLabelFmtBoundsMinBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max label fmt bounds min bounds max flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMaxLabelFmtBoundsMinBoundsMaxFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ulong[0], 0, 0, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
    }
}