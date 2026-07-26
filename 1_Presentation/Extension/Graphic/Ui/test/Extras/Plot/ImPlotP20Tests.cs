// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP20Tests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    public class ImPlotP20Tests
    {
        [RequireCImguiSystemFact]
        public void PlotHeatmap_IntArray_AllOverloads_ShouldExecute()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HeatmapInt"));

            int[] values = { 1, 2, 3, 4 };
            ImPlotPoint boundsMin = new ImPlotPoint { X = 0, Y = 0 };
            ImPlotPoint boundsMax = new ImPlotPoint { X = 2, Y = 2 };

            ImPlot.PlotHeatmap("h1", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax);
            ImPlot.PlotHeatmap("h2", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax, ImPlotHeatmapFlags.None);
            ImPlot.PlotHeatmap("h3", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMin);
            ImPlot.PlotHeatmap("h4", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHeatmap_UIntArray_AllOverloads_ShouldExecute()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HeatmapUInt"));

            uint[] values = { 1, 2, 3, 4 };
            ImPlotPoint boundsMin = new ImPlotPoint { X = 0, Y = 0 };
            ImPlotPoint boundsMax = new ImPlotPoint { X = 2, Y = 2 };

            ImPlot.PlotHeatmap("h1", values, 2, 2);
            ImPlot.PlotHeatmap("h2", values, 2, 2, 0.0);
            ImPlot.PlotHeatmap("h3", values, 2, 2, 0.0, 1.0);
            ImPlot.PlotHeatmap("h4", values, 2, 2, 0.0, 1.0, "%.1f");
            ImPlot.PlotHeatmap("h5", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin);
            ImPlot.PlotHeatmap("h6", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax);
            ImPlot.PlotHeatmap("h7", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax, ImPlotHeatmapFlags.None);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHeatmap_LongArray_AllOverloads_ShouldExecute()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HeatmapLong"));

            long[] values = { 1, 2, 3, 4 };
            ImPlotPoint boundsMin = new ImPlotPoint { X = 0, Y = 0 };
            ImPlotPoint boundsMax = new ImPlotPoint { X = 2, Y = 2 };

            ImPlot.PlotHeatmap("h1", values, 2, 2);
            ImPlot.PlotHeatmap("h2", values, 2, 2, 0.0);
            ImPlot.PlotHeatmap("h3", values, 2, 2, 0.0, 1.0);
            ImPlot.PlotHeatmap("h4", values, 2, 2, 0.0, 1.0, "%.1f");
            ImPlot.PlotHeatmap("h5", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin);
            ImPlot.PlotHeatmap("h6", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax);
            ImPlot.PlotHeatmap("h7", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax, ImPlotHeatmapFlags.None);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHeatmap_ULongArray_AllOverloads_ShouldExecute()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HeatmapULong"));

            ulong[] values = { 1, 2, 3, 4 };
            ImPlotPoint boundsMin = new ImPlotPoint { X = 0, Y = 0 };
            ImPlotPoint boundsMax = new ImPlotPoint { X = 2, Y = 2 };

            ImPlot.PlotHeatmap("h1", values, 2, 2);
            ImPlot.PlotHeatmap("h2", values, 2, 2, 0.0);
            ImPlot.PlotHeatmap("h3", values, 2, 2, 0.0, 1.0);
            ImPlot.PlotHeatmap("h4", values, 2, 2, 0.0, 1.0, "%.1f");
            ImPlot.PlotHeatmap("h5", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin);
            ImPlot.PlotHeatmap("h6", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax);
            ImPlot.PlotHeatmap("h7", values, 2, 2, 0.0, 1.0, "%.1f", boundsMin, boundsMax, ImPlotHeatmapFlags.None);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_FloatArray_AllOverloads_ShouldReturnDouble()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HistogramFloat"));

            float[] values = { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };

            double r1 = ImPlot.PlotHistogram("h1", values, 5);
            double r2 = ImPlot.PlotHistogram("h2", values, 5, 3);
            double r3 = ImPlot.PlotHistogram("h3", values, 5, 3, 1.0);
            double r4 = ImPlot.PlotHistogram("h4", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 });
            double r5 = ImPlot.PlotHistogram("h5", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 }, ImPlotHistogramFlags.None);

            Assert.True(r1 >= 0);
            Assert.True(r2 >= 0);
            Assert.True(r3 >= 0);
            Assert.True(r4 >= 0);
            Assert.True(r5 >= 0);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_DoubleArray_AllOverloads_ShouldReturnDouble()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HistogramDouble"));

            double[] values = { 1.0, 2.0, 3.0, 4.0, 5.0 };

            double r1 = ImPlot.PlotHistogram("h1", values, 5);
            double r2 = ImPlot.PlotHistogram("h2", values, 5, 3);
            double r3 = ImPlot.PlotHistogram("h3", values, 5, 3, 1.0);
            double r4 = ImPlot.PlotHistogram("h4", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 });
            double r5 = ImPlot.PlotHistogram("h5", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 }, ImPlotHistogramFlags.None);

            Assert.True(r1 >= 0);
            Assert.True(r2 >= 0);
            Assert.True(r3 >= 0);
            Assert.True(r4 >= 0);
            Assert.True(r5 >= 0);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_SByteArray_AllOverloads_ShouldReturnDouble()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HistogramSByte"));

            sbyte[] values = { 1, 2, 3, 4, 5 };

            double r1 = ImPlot.PlotHistogram("h1", values, 5);
            double r2 = ImPlot.PlotHistogram("h2", values, 5, 3);
            double r3 = ImPlot.PlotHistogram("h3", values, 5, 3, 1.0);
            double r4 = ImPlot.PlotHistogram("h4", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 });
            double r5 = ImPlot.PlotHistogram("h5", values, 5, 3, 1.0, new ImPlotRange { Min = 0, Max = 5 }, ImPlotHistogramFlags.None);

            Assert.True(r1 >= 0);
            Assert.True(r2 >= 0);
            Assert.True(r3 >= 0);
            Assert.True(r4 >= 0);
            Assert.True(r5 >= 0);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_ByteArray_AllOverloads_ShouldReturnDouble()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);
            IntPtr plotCtx = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotCtx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Assert.True(ImPlot.BeginPlot("HistogramByte"));

            byte[] values = { 1, 2, 3, 4, 5 };

            double r1 = ImPlot.PlotHistogram("h1", values, 5);
            double r2 = ImPlot.PlotHistogram("h2", values, 5, 3);
            double r3 = ImPlot.PlotHistogram("h3", values, 5, 3, 1.0);

            Assert.True(r1 >= 0);
            Assert.True(r2 >= 0);
            Assert.True(r3 >= 0);

            ImPlot.EndPlot();
            ImGui.End();
            ImGui.Render();
            ImGuiNative.igDestroyContext(ctx);
        }
    }
}
