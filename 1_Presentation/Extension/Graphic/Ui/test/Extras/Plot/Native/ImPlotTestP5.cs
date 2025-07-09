// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP5.cs
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
    public class ImPlotTestP5
    {
        /// <summary>
        ///     Tests that plot error bars sbyte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Sbyte_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars sbyte offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Sbyte_Offset_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars sbyte offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Sbyte_Offset_Stride_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_ThrowsDllNotFoundException_v45()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars byte flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_Flags_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars byte offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_Offset_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars byte offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_Offset_Stride_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_ThrowsDllNotFoundException_v39()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars short flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_Flags_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars short offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_Offset_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars short offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_Offset_Stride_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_ThrowsDllNotFoundException_v40()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u short flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_Flags_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u short offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_Offset_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u short offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_Offset_Stride_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_ThrowsDllNotFoundException_v41()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_Flags_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars int offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_Offset_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars int offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_Offset_Stride_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_ThrowsDllNotFoundException_v42()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_Flags_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u int offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_Offset_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u int offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_Offset_Stride_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_ThrowsDllNotFoundException_v43()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars long flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_Flags_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars long offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_Offset_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars long offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_Offset_Stride_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_ThrowsDllNotFoundException_v44()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u long flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_Flags_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u long offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_Offset_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u long offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_Offset_Stride_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot heatmap float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ScaleMax_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min scale max label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ScaleMax_LabelFmt_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min scale max label fmt bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ScaleMax_LabelFmt_BoundsMin_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min scale max label fmt bounds min bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ScaleMax_LabelFmt_BoundsMin_BoundsMax_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin, boundsMax));
        }

        /// <summary>
        ///     Tests that plot heatmap float scale min scale max label fmt bounds min bounds max flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_ScaleMin_ScaleMax_LabelFmt_BoundsMin_BoundsMax_Flags_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = ImPlotHeatmapFlags.None;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin, boundsMax, flags));
        }

        /// <summary>
        ///     Tests that plot heatmap double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_ThrowsDllNotFoundException()
        {
            double[] values = new double[1];
            int rows = 1, cols = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap with scale min max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_WithScaleMinMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[0], 0, 0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars sbyte throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Sbyte_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars sbyte with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Sbyte_WithOffset_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars sbyte with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Sbyte_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_WithFlags_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars byte with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_WithOffset_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars byte with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars short with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_WithFlags_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars short with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_WithOffset_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars short with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u short with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_WithFlags_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u short with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_WithOffset_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u short with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars int with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_WithFlags_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars int with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_WithOffset_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars int with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u int with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_WithFlags_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u int with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_WithOffset_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u int with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_WithFlags_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars long with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_WithOffset_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars long with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot error bars u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count));
        }

        /// <summary>
        ///     Tests that plot error bars u long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_WithFlags_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags));
        }

        /// <summary>
        ///     Tests that plot error bars u long with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_WithOffset_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset));
        }

        /// <summary>
        ///     Tests that plot error bars u long with offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_WithOffsetAndStride_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, neg = 0, pos = 0;
            int count = 1, offset = 0, stride = 1;
            ImPlotErrorBarsFlags flags = ImPlotErrorBarsFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, count, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap float throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_Float_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols));
        }

        /// <summary>
        ///     Tests that plot heatmap float with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithScaleMin_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin));
        }

        /// <summary>
        ///     Tests that plot heatmap float with scale min and max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithScaleMinAndMax_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax));
        }

        /// <summary>
        ///     Tests that plot heatmap float with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithLabelFmt_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt));
        }

        /// <summary>
        ///     Tests that plot heatmap float with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithBoundsMin_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin));
        }

        /// <summary>
        ///     Tests that plot heatmap float with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithBoundsMax_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin, boundsMax));
        }

        /// <summary>
        ///     Tests that plot heatmap float with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithFlags_ThrowsDllNotFoundException()
        {
            float[] values = new float[1];
            int rows = 1, cols = 1;
            double scaleMin = 0, scaleMax = 1;
            string labelFmt = "%.1f";
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = ImPlotHeatmapFlags.None;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin, scaleMax, labelFmt, boundsMin, boundsMax, flags));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap double throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_Double_ThrowsDllNotFoundException()
        {
            double[] values = new double[1];
            int rows = 1, cols = 1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols));
        }

        /// <summary>
        ///     Tests that plot heatmap double with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_WithScaleMin_ThrowsDllNotFoundException()
        {
            double[] values = new double[1];
            int rows = 1, cols = 1;
            double scaleMin = 0;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", values, rows, cols, scaleMin));
        }
    }
}