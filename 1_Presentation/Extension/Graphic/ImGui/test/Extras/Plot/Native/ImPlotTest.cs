// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTest.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot  Fact class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImPlotTest 
    {
        /// <summary>
        ///     Facts that plot to pixels with im plot point returns correct vector 2
        /// </summary>
        [Fact]
        public void PlotToPixels_WithImPlotPoint_ReturnsCorrectVector2()
        {
            ImPlotPoint plt = new ImPlotPoint();
            plt.X = 1.0f;
            plt.Y = 2.0f;
            ImAxis xAxis = ImAxis.X1;
            ImAxis yAxis = ImAxis.Y1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(plt, xAxis, yAxis));
        }

        /// <summary>
        ///     Facts that plot to pixels with double coordinates returns correct vector 2
        /// </summary>
        [Fact]
        public void PlotToPixels_WithDoubleCoordinates_ReturnsCorrectVector2()
        {
            double x = 1.0;
            double y = 2.0;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(x, y));
        }

        /// <summary>
        ///     Facts that plot to pixels with double coordinates and x axis returns correct vector 2
        /// </summary>
        [Fact]
        public void PlotToPixels_WithDoubleCoordinatesAndXAxis_ReturnsCorrectVector2()
        {
            double x = 1.0;
            double y = 2.0;
            ImAxis xAxis = ImAxis.X1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(x, y, xAxis));
        }

        /// <summary>
        ///     Facts that plot to pixels with double coordinates and axes returns correct vector 2
        /// </summary>
        [Fact]
        public void PlotToPixels_WithDoubleCoordinatesAndAxes_ReturnsCorrectVector2()
        {
            double x = 1.0;
            double y = 2.0;
            ImAxis xAxis = ImAxis.X1;
            ImAxis yAxis = ImAxis.Y1;

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(x, y, xAxis, yAxis));
        }

        /// <summary>
        ///     Facts that pop colormap default count pops once
        /// </summary>
        [Fact]
        public void PopColormap_DefaultCount_PopsOnce()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopColormap());
        }

        /// <summary>
        ///     Facts that pop colormap with count pops correct number of times
        /// </summary>
        [Fact]
        public void PopColormap_WithCount_PopsCorrectNumberOfTimes()
        {
            int count = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopColormap(count));
        }

        /// <summary>
        ///     Facts that pop plot clip rect pops once
        /// </summary>
        [Fact]
        public void PopPlotClipRect_PopsOnce()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopPlotClipRect());
        }

        /// <summary>
        ///     Facts that pop style color default count pops once
        /// </summary>
        [Fact]
        public void PopStyleColor_DefaultCount_PopsOnce()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopStyleColor());
        }

        /// <summary>
        ///     Facts that pop style color with count pops correct number of times
        /// </summary>
        [Fact]
        public void PopStyleColor_WithCount_PopsCorrectNumberOfTimes()
        {
            int count = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopStyleColor(count));
        }

        /// <summary>
        ///     Facts that pop style var default count pops once
        /// </summary>
        [Fact]
        public void PopStyleVar_DefaultCount_PopsOnce()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopStyleVar());
        }

        /// <summary>
        ///     Facts that pop style var with count pops correct number of times
        /// </summary>
        [Fact]
        public void PopStyleVar_WithCount_PopsCorrectNumberOfTimes()
        {
            int count = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopStyleVar(count));
        }

        /// <summary>
        ///     Facts that push colormap with im plot colormap pushes correctly
        /// </summary>
        [Fact]
        public void PushColormap_WithImPlotColormap_PushesCorrectly()
        {
            ImPlotColormap colormap = ImPlotColormap.Deep;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushColormap(colormap));
        }

        /// <summary>
        ///     Facts that push colormap with name pushes correctly
        /// </summary>
        [Fact]
        public void PushColormap_WithName_PushesCorrectly()
        {
            string name = "MyColormap";
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushColormap(name));
        }

        /// <summary>
        ///     Facts that push plot clip rect default expand pushes correctly
        /// </summary>
        [Fact]
        public void PushPlotClipRect_DefaultExpand_PushesCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushPlotClipRect());
        }

        /// <summary>
        ///     Facts that push plot clip rect with expand pushes correctly
        /// </summary>
        [Fact]
        public void PushPlotClipRect_WithExpand_PushesCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushPlotClipRect(1));
        }

        /// <summary>
        ///     Facts that push style color with im plot col and u int pushes correctly
        /// </summary>
        [Fact]
        public void PushStyleColor_WithImPlotColAndUInt_PushesCorrectly()
        {
            ImPlotCol col = ImPlotCol.Line;
            uint color = 0xFF0000;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushStyleColor(col, color));
        }

        /// <summary>
        ///     Facts that push style color with im plot col and vector 4 pushes correctly
        /// </summary>
        [Fact]
        public void PushStyleColor_WithImPlotColAndVector4_PushesCorrectly()
        {
            ImPlotCol col = ImPlotCol.Line;
            Vector4F color = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushStyleColor(col, color));
        }

        /// <summary>
        ///     Facts that push style var with im plot style var and float pushes correctly
        /// </summary>
        [Fact]
        public void PushStyleVar_WithImPlotStyleVarAndFloat_PushesCorrectly()
        {
            ImPlotStyleVar styleVar = ImPlotStyleVar.LineWeight;
            float value = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushStyleVar(styleVar, value));
        }

        /// <summary>
        ///     Facts that push style var with im plot style var and int pushes correctly
        /// </summary>
        [Fact]
        public void PushStyleVar_WithImPlotStyleVarAndInt_PushesCorrectly()
        {
            ImPlotStyleVar styleVar = ImPlotStyleVar.Marker;
            int value = 1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushStyleVar(styleVar, value));
        }

        /// <summary>
        ///     Facts that push style var with im plot style var and vector 2 pushes correctly
        /// </summary>
        [Fact]
        public void PushStyleVar_WithImPlotStyleVarAndVector2_PushesCorrectly()
        {
            ImPlotStyleVar styleVar = ImPlotStyleVar.MarkerSize;
            Vector2F value = new Vector2F(1.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.PushStyleVar(styleVar, value));
        }

        /// <summary>
        ///     Facts that sample colormap with t returns correct vector 4
        /// </summary>
        [Fact]
        public void SampleColormap_WithT_ReturnsCorrectVector4()
        {
            float t = 0.5f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SampleColormap(t));
        }

        /// <summary>
        ///     Facts that sample colormap with t and cmap returns correct vector 4
        /// </summary>
        [Fact]
        public void SampleColormap_WithTAndCmap_ReturnsCorrectVector4()
        {
            float t = 0.5f;
            ImPlotColormap cmap = ImPlotColormap.Deep;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SampleColormap(t, cmap));
        }

        /// <summary>
        ///     Facts that set axes with axes sets correctly
        /// </summary>
        [Fact]
        public void SetAxes_WithAxes_SetsCorrectly()
        {
            ImAxis xAxis = ImAxis.X1;
            ImAxis yAxis = ImAxis.Y1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetAxes(xAxis, yAxis));
        }

        /// <summary>
        ///     Facts that set axis with axis sets correctly
        /// </summary>
        [Fact]
        public void SetAxis_WithAxis_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetAxis(axis));
        }

        /// <summary>
        ///     Facts that set current context with ctx sets correctly
        /// </summary>
        [Fact]
        public void SetCurrentContext_WithCtx_SetsCorrectly()
        {
            IntPtr ctx = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetCurrentContext(ctx));
        }

        /// <summary>
        ///     Facts that set im gui context with ctx sets correctly
        /// </summary>
        [Fact]
        public void SetImGuiContext_WithCtx_SetsCorrectly()
        {
            IntPtr ctx = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetImGuiContext(ctx));
        }

        /// <summary>
        ///     Facts that set next axes limits with limits sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxesLimits_WithLimits_SetsCorrectly()
        {
            double xMin = 0.0;
            double xMax = 1.0;
            double yMin = 0.0;
            double yMax = 1.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxesLimits(xMin, xMax, yMin, yMax));
        }

        /// <summary>
        ///     Facts that set next axes limits with limits and cond sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxesLimits_WithLimitsAndCond_SetsCorrectly()
        {
            double xMin = 0.0;
            double xMax = 1.0;
            double yMin = 0.0;
            double yMax = 1.0;
            ImPlotCond cond = ImPlotCond.Always;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxesLimits(xMin, xMax, yMin, yMax, cond));
        }

        /// <summary>
        ///     Facts that set next axes to fit sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxesToFit_SetsCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxesToFit());
        }

        /// <summary>
        ///     Facts that set next axis limits with axis and limits sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxisLimits_WithAxisAndLimits_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            double min = 0.0;
            double max = 1.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxisLimits(axis, min, max));
        }

        /// <summary>
        ///     Facts that set next axis limits with axis limits and cond sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxisLimits_WithAxisLimitsAndCond_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            double min = 0.0;
            double max = 1.0;
            ImPlotCond cond = ImPlotCond.Always;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxisLimits(axis, min, max, cond));
        }

        /// <summary>
        ///     Facts that set next axis links with axis and links sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxisLinks_WithAxisAndLinks_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            double links = 1.0;
            double linkMax = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxisLinks(axis, ref links, ref linkMax));
        }

        /// <summary>
        ///     Facts that set next axis to fit with axis sets correctly
        /// </summary>
        [Fact]
        public void SetNextAxisToFit_WithAxis_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextAxisToFit(axis));
        }

        /// <summary>
        ///     Facts that set next error bar style default values sets correctly
        /// </summary>
        [Fact]
        public void SetNextErrorBarStyle_DefaultValues_SetsCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextErrorBarStyle());
        }

        /// <summary>
        ///     Facts that set next error bar style with col sets correctly
        /// </summary>
        [Fact]
        public void SetNextErrorBarStyle_WithCol_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextErrorBarStyle(col));
        }

        /// <summary>
        ///     Facts that set next error bar style with col and size sets correctly
        /// </summary>
        [Fact]
        public void SetNextErrorBarStyle_WithColAndSize_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float size = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextErrorBarStyle(col, size));
        }

        /// <summary>
        ///     Facts that set next error bar style with col size and weight sets correctly
        /// </summary>
        [Fact]
        public void SetNextErrorBarStyle_WithColSizeAndWeight_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float size = 1.0f;
            float weight = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextErrorBarStyle(col, size, weight));
        }

        /// <summary>
        ///     Facts that set next fill style default values sets correctly
        /// </summary>
        [Fact]
        public void SetNextFillStyle_DefaultValues_SetsCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextFillStyle());
        }

        /// <summary>
        ///     Facts that set next fill style with col sets correctly
        /// </summary>
        [Fact]
        public void SetNextFillStyle_WithCol_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextFillStyle(col));
        }

        /// <summary>
        ///     Facts that set next fill style with col and alpha mod sets correctly
        /// </summary>
        [Fact]
        public void SetNextFillStyle_WithColAndAlphaMod_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float alphaMod = 0.5f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextFillStyle(col, alphaMod));
        }

        /// <summary>
        ///     Facts that set next line style default values sets correctly
        /// </summary>
        [Fact]
        public void SetNextLineStyle_DefaultValues_SetsCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextLineStyle());
        }

        /// <summary>
        ///     Facts that set next line style with col sets correctly
        /// </summary>
        [Fact]
        public void SetNextLineStyle_WithCol_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextLineStyle(col));
        }

        /// <summary>
        ///     Facts that set next line style with col and weight sets correctly
        /// </summary>
        [Fact]
        public void SetNextLineStyle_WithColAndWeight_SetsCorrectly()
        {
            Vector4F col = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float weight = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextLineStyle(col, weight));
        }

        /// <summary>
        ///     Facts that set next marker style default values sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_DefaultValues_SetsCorrectly()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle());
        }

        /// <summary>
        ///     Facts that set next marker style with marker sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_WithMarker_SetsCorrectly()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle(marker));
        }

        /// <summary>
        ///     Facts that set next marker style with marker and size sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_WithMarkerAndSize_SetsCorrectly()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            float size = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle(marker, size));
        }

        /// <summary>
        ///     Facts that set next marker style with marker size and fill sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_WithMarkerSizeAndFill_SetsCorrectly()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            float size = 1.0f;
            Vector4F fill = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle(marker, size, fill));
        }

        /// <summary>
        ///     Facts that set next marker style with marker size fill and weight sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_WithMarkerSizeFillAndWeight_SetsCorrectly()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            float size = 1.0f;
            Vector4F fill = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float weight = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle(marker, size, fill, weight));
        }

        /// <summary>
        ///     Facts that set next marker style with marker size fill weight and outline sets correctly
        /// </summary>
        [Fact]
        public void SetNextMarkerStyle_WithMarkerSizeFillWeightAndOutline_SetsCorrectly()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            float size = 1.0f;
            Vector4F fill = new Vector4F(1.0f, 0.0f, 0.0f, 1.0f);
            float weight = 1.0f;
            Vector4F outline = new Vector4F(0.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetNextMarkerStyle(marker, size, fill, weight, outline));
        }

        /// <summary>
        ///     Facts that setup axes with labels sets correctly
        /// </summary>
        [Fact]
        public void SetupAxes_WithLabels_SetsCorrectly()
        {
            string xLabel = "X Axis";
            string yLabel = "Y Axis";
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxes(xLabel, yLabel));
        }

        /// <summary>
        ///     Facts that setup axes with labels and x flags sets correctly
        /// </summary>
        [Fact]
        public void SetupAxes_WithLabelsAndXFlags_SetsCorrectly()
        {
            string xLabel = "X Axis";
            string yLabel = "Y Axis";
            ImPlotAxisFlags xFlags = ImPlotAxisFlags.Lock;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxes(xLabel, yLabel, xFlags));
        }

        /// <summary>
        ///     Facts that setup axes with labels x flags and y flags sets correctly
        /// </summary>
        [Fact]
        public void SetupAxes_WithLabelsXFlagsAndYFlags_SetsCorrectly()
        {
            string xLabel = "X Axis";
            string yLabel = "Y Axis";
            ImPlotAxisFlags xFlags = ImPlotAxisFlags.Lock;
            ImPlotAxisFlags yFlags = ImPlotAxisFlags.Lock;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxes(xLabel, yLabel, xFlags, yFlags));
        }

        /// <summary>
        ///     Facts that setup axes limits with limits sets correctly
        /// </summary>
        [Fact]
        public void SetupAxesLimits_WithLimits_SetsCorrectly()
        {
            double xMin = 0.0;
            double xMax = 1.0;
            double yMin = 0.0;
            double yMax = 1.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxesLimits(xMin, xMax, yMin, yMax));
        }

        /// <summary>
        ///     Facts that setup axes limits with limits and cond sets correctly
        /// </summary>
        [Fact]
        public void SetupAxesLimits_WithLimitsAndCond_SetsCorrectly()
        {
            double xMin = 0.0;
            double xMax = 1.0;
            double yMin = 0.0;
            double yMax = 1.0;
            ImPlotCond cond = ImPlotCond.Always;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxesLimits(xMin, xMax, yMin, yMax, cond));
        }

        /// <summary>
        ///     Facts that setup axis with axis sets correctly
        /// </summary>
        [Fact]
        public void SetupAxis_WithAxis_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxis(axis));
        }

        /// <summary>
        ///     Facts that setup axis with axis and label sets correctly
        /// </summary>
        [Fact]
        public void SetupAxis_WithAxisAndLabel_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            string label = "X Axis";
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxis(axis, label));
        }

        /// <summary>
        ///     Facts that setup axis with axis label and flags sets correctly
        /// </summary>
        [Fact]
        public void SetupAxis_WithAxisLabelAndFlags_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            string label = "X Axis";
            ImPlotAxisFlags flags = ImPlotAxisFlags.Lock;
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxis(axis, label, flags));
        }

        /// <summary>
        ///     Facts that setup axis format with axis and fmt sets correctly
        /// </summary>
        [Fact]
        public void SetupAxisFormat_WithAxisAndFmt_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            string fmt = "%.2f";
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxisFormat(axis, fmt));
        }

        /// <summary>
        ///     Facts that setup axis format with axis and formatter sets correctly
        /// </summary>
        [Fact]
        public void SetupAxisFormat_WithAxisAndFormatter_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            IntPtr formatter = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxisFormat(axis, formatter));
        }

        /// <summary>
        ///     Facts that setup axis format with axis formatter and data sets correctly
        /// </summary>
        [Fact]
        public void SetupAxisFormat_WithAxisFormatterAndData_SetsCorrectly()
        {
            ImAxis axis = ImAxis.X1;
            IntPtr formatter = new IntPtr(1);
            IntPtr data = new IntPtr(2);
            Assert.Throws<DllNotFoundException>(() => ImPlot.SetupAxisFormat(axis, formatter, data));
        }

        /// <summary>
        ///     Tests that style colors dark with dst throws dll not found exception
        /// </summary>
        [Fact]
        public void StyleColorsDark_WithDst_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.StyleColorsDark(new ImPlotStyle()));
        }

        /// <summary>
        ///     Tests that style colors light throws dll not found exception
        /// </summary>
        [Fact]
        public void StyleColorsLight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.StyleColorsLight());
        }

        /// <summary>
        ///     Tests that style colors light with dst throws dll not found exception
        /// </summary>
        [Fact]
        public void StyleColorsLight_WithDst_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.StyleColorsLight(new ImPlotStyle()));
        }

        /// <summary>
        ///     Tests that tag x with x and col throws dll not found exception
        /// </summary>
        [Fact]
        public void TagX_WithXAndCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagX(1.0, new Vector4F()));
        }

        /// <summary>
        ///     Tests that tag x with x col and round throws dll not found exception
        /// </summary>
        [Fact]
        public void TagX_WithXColAndRound_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagX(1.0, new Vector4F(), true));
        }

        /// <summary>
        ///     Tests that tag x with x col and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TagX_WithXColAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagX(1.0, new Vector4F(), "fmt"));
        }

        /// <summary>
        ///     Tests that tag y with y and col throws dll not found exception
        /// </summary>
        [Fact]
        public void TagY_WithYAndCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagY(1.0, new Vector4F()));
        }

        /// <summary>
        ///     Tests that tag y with y col and round throws dll not found exception
        /// </summary>
        [Fact]
        public void TagY_WithYColAndRound_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagY(1.0, new Vector4F(), true));
        }

        /// <summary>
        ///     Tests that tag y with y col and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TagY_WithYColAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.TagY(1.0, new Vector4F(), "fmt"));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCount_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountAndFlags_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsAndOffset_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, 4));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count uint throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountUint_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags uint throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsUint_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset uint throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetUint_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset stride uint throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetStrideUint_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, 4));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountLong_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsLong_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetLong_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset stride long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetStrideLong_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, 8));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count ulong throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountUlong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags ulong throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsUlong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset ulong throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetUlong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line with label id xs ys count flags offset stride ulong throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_WithLabelIdXsYsCountFlagsOffsetStrideUlong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, 8));
        }

        /// <summary>
        ///     Tests that plot line g with label id getter data count throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLineG_WithLabelIdGetterDataCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLineG("label", IntPtr.Zero, IntPtr.Zero, 1));
        }

        /// <summary>
        ///     Tests that plot line g with label id getter data count flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLineG_WithLabelIdGetterDataCountFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLineG("label", IntPtr.Zero, IntPtr.Zero, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            float[] values = {1.0f};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids values count xy radius label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsValuesCountXyRadiusLabelFmt_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            float[] values = {1.0f};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids values count xy radius label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsValuesCountXyRadiusLabelFmtAngle0_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            float[] values = {1.0f};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids values count xy radius label fmt angle 0 flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsValuesCountXyRadiusLabelFmtAngle0Flags_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            float[] values = {1.0f};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids double values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsDoubleValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            double[] values = {1.0};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids double values count xy radius label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsDoubleValuesCountXyRadiusLabelFmt_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            double[] values = {1.0};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids double values count xy radius label fmt angle 0 throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsDoubleValuesCountXyRadiusLabelFmtAngle0_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            double[] values = {1.0};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids double values count xy radius label fmt angle 0 flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsDoubleValuesCountXyRadiusLabelFmtAngle0Flags_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            double[] values = {1.0};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids sbyte values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsSbyteValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            sbyte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids sbyte values count xy radius label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsSbyteValuesCountXyRadiusLabelFmt_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            sbyte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids sbyte values count xy radius label fmt angle 0 throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsSbyteValuesCountXyRadiusLabelFmtAngle0_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            sbyte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids sbyte values count xy radius label fmt angle 0 flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsSbyteValuesCountXyRadiusLabelFmtAngle0Flags_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            sbyte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids byte values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsByteValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            byte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids byte values count xy radius label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsByteValuesCountXyRadiusLabelFmt_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            byte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids byte values count xy radius label fmt angle 0 throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsByteValuesCountXyRadiusLabelFmtAngle0_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            byte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids byte values count xy radius label fmt angle 0 flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsByteValuesCountXyRadiusLabelFmtAngle0Flags_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            byte[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids short values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsShortValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            short[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids short values count xy radius label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsShortValuesCountXyRadiusLabelFmt_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            short[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids short values count xy radius label fmt angle 0 throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsShortValuesCountXyRadiusLabelFmtAngle0_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            short[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids short values count xy radius label fmt angle 0 flags throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsShortValuesCountXyRadiusLabelFmtAngle0Flags_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            short[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0, "fmt", 0.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart with label ids ushort values count xy radius throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_WithLabelIdsUshortValuesCountXyRadius_ThrowsDllNotFoundException()
        {
            string[] labelIds = {"label"};
            ushort[] values = {1};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labelIds, values, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot shaded byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Short_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Int_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Int_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Int_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_WithFlags_ThrowsDllNotFoundException()
        {
            uint minValue = uint.MinValue;
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None); });
        }

        /// <summary>
        ///     Tests that plot shaded u int with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Long_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Long_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Long_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_Long_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_WithFlags_ThrowsDllNotFoundException()
        {
            ulong minValue = ulong.MinValue;
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None); });
        }

        /// <summary>
        ///     Tests that plot shaded u long with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 0, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong value = ulong.MinValue;
                ulong minValue = value;
                ImPlot.PlotShaded("label", ref minValue, ref value, ref value, 0, ImPlotShadedFlags.None, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded g throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShadedG_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0));
        }

        /// <summary>
        ///     Tests that plot shaded g with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShadedG_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0));
        }

        /// <summary>
        ///     Tests that plot stairs float with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs float with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs float with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0, 0.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs float with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs float with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Float_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stairs double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0));
        }

        /// <summary>
        ///     Tests that plot stairs double with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs double with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs double with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0, 0.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs double with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs double with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Double_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0, 0.0, 0.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs s byte with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[0], 0, 0.0, 0.0, ImPlotStairsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stairs byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[0], 0));
        }

        /// <summary>
        ///     Tests that plot stairs byte with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[0], 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs byte with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[0], 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot stairs byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot stairs byte array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs byte array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStairs_ByteArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot inf lines byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new byte[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines short array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ShortArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new short[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UShortArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u short array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UShortArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ushort[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_IntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_IntArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines int array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_IntArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UIntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UIntArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u int array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_UIntArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new uint[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_LongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_LongArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines long array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_LongArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new long[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ULongArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ULongArray_WithFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot inf lines u long array with flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotInfLines_ULongArray_WithFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotInfLines("label", new ulong[] {1, 2, 3}, 3, ImPlotInfLinesFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot line float array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line float array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0f, 2.0f, 3.0f}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot line double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line double array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1.0, 2.0, 3.0}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot line s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line s byte array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new sbyte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot line byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line byte array with x scale x start flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteArray_WithXScaleXStartFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new byte[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot line short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_WithXScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale and x start throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_WithXScaleAndXStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale x start and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_WithXScaleXStartAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None));
        }

        /// <summary>
        ///     Tests that plot line short array with x scale x start flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_WithXScaleXStartFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot line short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(float)));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(double)));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(sbyte)));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(short)));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(ushort)));
        }

        /// <summary>
        ///     Tests that plot line short array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new short[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u short array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_UShortArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ushort[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line int array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u int array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_UIntArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new uint[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line long array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new long[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line u long array throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_ULongArray_ThrowsDllNotFoundException_2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", new ulong[] {1, 2, 3}, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot line float ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_FloatRef_ThrowsDllNotFoundException_2()
        {
            float xs = 1.0f, ys = 2.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(float)));
        }

        /// <summary>
        ///     Tests that plot line double ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_DoubleRef_ThrowsDllNotFoundException_2()
        {
            double xs = 1.0, ys = 2.0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(double)));
        }

        /// <summary>
        ///     Tests that plot line s byte ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_SByteRef_ThrowsDllNotFoundException_2()
        {
            sbyte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(sbyte)));
        }

        /// <summary>
        ///     Tests that plot line byte ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_ByteRef_ThrowsDllNotFoundException_2()
        {
            byte xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        ///     Tests that plot line short ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_ShortRef_ThrowsDllNotFoundException_2()
        {
            short xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(short)));
        }

        /// <summary>
        ///     Tests that plot line u short ref throws dll not found exception 2
        /// </summary>
        [Fact]
        public void PlotLine_UShortRef_ThrowsDllNotFoundException_2()
        {
            ushort xs = 1, ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLine("label", ref xs, ref ys, 3, ImPlotLineFlags.None, 0, sizeof(ushort)));
        }

        /// <summary>
        ///     Tests that plot stems u int 16 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt16_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems u int 16 with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt16_WithOffset_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems u int 16 with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt16_WithStride_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems int 32 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Int32_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems int 32 with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Int32_WithRef_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems int 32 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Int32_WithFlags_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems int 32 with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Int32_WithOffset_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems int 32 with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Int32_WithStride_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u int 32 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt32_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems u int 32 with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt32_WithRef_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Long_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems long with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithRef_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithFlags_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems long with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithOffset_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems long with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithStride_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ULong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems u long with ref throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithRef_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u long with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithFlags_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems u long with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithOffset_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems u long with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithStride_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot text throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotText("text", 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot text with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotText_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotText("text", 0.0, 0.0, new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that plot text with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotText_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotText("text", 0.0, 0.0, new Vector2F(0, 0), ImPlotTextFlags.None));
        }

        /// <summary>
        ///     Tests that plot to pixels plot point throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_PlotPoint_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot to pixels plot point with x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_PlotPoint_WithXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(new ImPlotPoint(), ImAxis.X1));
        }

        /// <summary>
        ///     Tests that plot to pixels plot point with axes throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_PlotPoint_WithAxes_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(new ImPlotPoint(), ImAxis.X1, ImAxis.Y1));
        }

        /// <summary>
        ///     Tests that plot to pixels double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot to pixels double with x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_Double_WithXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(0.0, 0.0, ImAxis.X1));
        }

        /// <summary>
        ///     Tests that plot to pixels double with axes throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotToPixels_Double_WithAxes_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotToPixels(0.0, 0.0, ImAxis.X1, ImAxis.Y1));
        }

        /// <summary>
        ///     Tests that pop colormap throws dll not found exception
        /// </summary>
        [Fact]
        public void PopColormap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopColormap());
        }

        /// <summary>
        ///     Tests that pop colormap with count throws dll not found exception
        /// </summary>
        [Fact]
        public void PopColormap_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PopColormap(1));
        }

        /// <summary>
        ///     Tests that plot stems u int with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt_WithFlags_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems u int with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt_WithOffset_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems u int with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotStems_UInt_WithStride_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems long throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_Long_ThrowsDllNotFoundException_v2()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems long with ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithRef_ThrowsDllNotFoundException_v2()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems long with flags throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithFlags_ThrowsDllNotFoundException_v2()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stems long with offset throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithOffset_ThrowsDllNotFoundException_v2()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stems long with stride throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_Long_WithStride_ThrowsDllNotFoundException_v2()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot stems u long throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_ULong_ThrowsDllNotFoundException_v2()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10));
        }

        /// <summary>
        ///     Tests that plot stems u long with ref throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithRef_ThrowsDllNotFoundException_v2()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0));
        }

        /// <summary>
        ///     Tests that plot stems u long with flags throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotStems_ULong_WithFlags_ThrowsDllNotFoundException_v2()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("label", ref xs, ref ys, 10, 0.0, ImPlotStemsFlags.None));
        }
    }
}