// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotExecutionTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the real ImPlot wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlot.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotExecutionTests
    {
        /// <summary>
        ///     The image offset of the native GImGui context slot
        /// </summary>
        private const int GImGuiSlot = 0x4597e0;

        /// <summary>
        ///     The image offset of the native GImPlot context slot
        /// </summary>
        private const int GImPlotSlot = 0x459808;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     The dyld get image header
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_header")]
        private static extern IntPtr DyldGetImageHeader(int index);

        /// <summary>
        ///     Creates an ImGui context, binds an ImPlot context to it and starts a new frame.
        ///     The native cimgui library is loaded twice by the runtime, so the context slots
        ///     of every loaded image are synchronized to keep all native calls consistent.
        /// </summary>
        /// <returns>The imgui context</returns>
        private static IntPtr CreateContexts()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(imgui);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            IntPtr implot = ImPlot.CreateContext();
            ImPlot.SetImGuiContext(imgui);
            ImPlot.SetCurrentContext(implot);
            SyncContextSlots(imgui, implot);
            ImGuiNative.igNewFrame();
            return imgui;
        }

        /// <summary>
        ///     Ends the active frame, destroys the ImPlot context and the ImGui context.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void DestroyContexts(IntPtr imgui)
        {
            ImGuiNative.igEndFrame();
            ImPlot.DestroyContext();
            ImGuiNative.igDestroyContext(imgui);
        }

        /// <summary>
        ///     Synchronizes the ImGui and ImPlot context pointers of every loaded cimgui image.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        /// <param name="implot">The implot context</param>
        private static void SyncContextSlots(IntPtr imgui, IntPtr implot)
        {
            int count = DyldImageCount();

            for (int i = 0; i < count; i++)
            {
                string name = Marshal.PtrToStringAnsi(DyldGetImageName(i));

                if (name != null && name.Contains("cimgui"))
                {
                    IntPtr imageBase = DyldGetImageHeader(i);
                    Marshal.WriteInt64(imageBase + GImGuiSlot, imgui.ToInt64());
                    Marshal.WriteInt64(imageBase + GImPlotSlot, implot.ToInt64());
                }
            }
        }

        /// <summary>
        ///     Executes the style color, style var, colormap and next style wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Style_And_NextStyle_Functions_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ImPlot.StyleColorsAuto();
                ImPlot.StyleColorsAuto(new ImPlotStyle());
                ImPlot.StyleColorsLight();
                ImPlot.StyleColorsLight(new ImPlotStyle());
                ImPlot.StyleColorsDark();
                ImPlot.StyleColorsDark(new ImPlotStyle());
                ImPlot.StyleColorsClassic();
                ImPlot.StyleColorsClassic(new ImPlotStyle());
                ImPlot.PushStyleColor(ImPlotCol.Line, 0xFF0000FF);
                ImPlot.PopStyleColor();
                ImPlot.PushStyleColor(ImPlotCol.Line, new Vector4F(1, 0, 0, 1));
                ImPlot.PopStyleColor(1);
                ImPlot.PushStyleVar(ImPlotStyleVar.LineWeight, 2.0f);
                ImPlot.PushStyleVar(ImPlotStyleVar.LineWeight, 2);
                ImPlot.PushStyleVar(ImPlotStyleVar.PlotPadding, new Vector2F(4, 4));
                ImPlot.PopStyleVar();
                ImPlot.PopStyleVar(2);
                ImPlot.PushColormap(ImPlotColormap.Deep);
                ImPlot.PopColormap();
                ImPlot.PushColormap("Deep");
                ImPlot.PopColormap(1);
                Vector4F sample = ImPlot.SampleColormap(0.5f);
                Assert.True(sample.W > 0.0f);
                _ = ImPlot.SampleColormap(0.5f, ImPlotColormap.Deep);
                ImPlot.SetNextLineStyle();
                ImPlot.SetNextLineStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextLineStyle(new Vector4F(1, 0, 0, 1), 2.0f);
                ImPlot.SetNextFillStyle();
                ImPlot.SetNextFillStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextFillStyle(new Vector4F(1, 0, 0, 1), 0.5f);
                ImPlot.SetNextMarkerStyle();
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1), 1.0f);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1), 1.0f, new Vector4F(0, 0, 0, 1));
                ImPlot.SetNextErrorBarStyle();
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1), 2.0f);
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1), 2.0f, 1.0f);
                ImPlot.ShowUserGuide();
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ImPlot window and selector wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Show_Windows_And_Selectors_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShowPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.ShowStyleEditor();
                    ImPlot.ShowStyleEditor(new ImPlotStyle());
                    _ = ImPlot.ShowStyleSelector("Style Selector");
                    ImPlot.ShowMetricsWindow();
                    bool metricsOpen = true;
                    ImPlot.ShowMetricsWindow(ref metricsOpen);
                    _ = ImPlot.ShowInputMapSelector("Input Map");
                    _ = ImPlot.ShowColormapSelector("Colormap");
                    ImPlot.ShowDemoWindow();
                    bool demoOpen = true;
                    ImPlot.ShowDemoWindow(ref demoOpen);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the axis setup, axis selection and drawing wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Setup_And_Draw_Functions_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ImPlot.SetNextAxesToFit();
                ImPlot.SetNextAxisToFit(ImAxis.X1);
                double linkMin = 0.0;
                double linkMax = 1.0;
                bool opened = ImPlot.BeginPlot("ExecutionPlot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("X Axis", "Y Axis");
                    ImPlot.SetupAxes("X Axis", "Y Axis", ImPlotAxisFlags.None);
                    ImPlot.SetupAxes("X Axis", "Y Axis", ImPlotAxisFlags.None, ImPlotAxisFlags.None);
                    ImPlot.SetupAxesLimits(0, 1, 0, 1);
                    ImPlot.SetupAxesLimits(0, 1, 0, 1, ImPlotCond.Always);
                    ImPlot.SetupAxis(ImAxis.X1);
                    ImPlot.SetupAxis(ImAxis.Y1, "Y");
                    ImPlot.SetupAxis(ImAxis.Y1, "Y", ImPlotAxisFlags.None);
                    ImPlot.SetupAxisLimits(ImAxis.X1, 0, 1);
                    ImPlot.SetupAxisLimits(ImAxis.X1, 0, 1, ImPlotCond.Always);
                    ImPlot.SetupAxisLimitsConstraints(ImAxis.X1, -10, 10);
                    ImPlot.SetupAxisFormat(ImAxis.X1, "%.2f");
                    ImPlot.SetupAxisScale(ImAxis.X1, ImPlotScale.Linear);
                    ImPlot.SetupAxisZoomConstraints(ImAxis.X1, 0.01, 100.0);
                    ImPlot.SetupLegend(ImPlotLocation.NorthWest);
                    ImPlot.SetupLegend(ImPlotLocation.NorthWest, ImPlotLegendFlags.None);
                    ImPlot.SetupMouseText(ImPlotLocation.SouthEast);
                    ImPlot.SetupMouseText(ImPlotLocation.SouthEast, ImPlotMouseTextFlags.None);
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the axis selection, tag and draw wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Draw_Functions_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ImPlot.SetNextAxesLimits(0, 1, 0, 1);
                ImPlot.SetNextAxesLimits(0, 1, 0, 1, ImPlotCond.Always);
                ImPlot.SetNextAxesToFit();
                ImPlot.SetNextAxisLimits(ImAxis.X1, 0, 1);
                ImPlot.SetNextAxisLimits(ImAxis.X1, 0, 1, ImPlotCond.Always);
                ImPlot.SetNextAxisToFit(ImAxis.X1);
                bool opened = ImPlot.BeginPlot("DrawPlot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("X Axis", "Y Axis");
                    ImPlot.SetupFinish();
                    ImPlot.SetAxes(ImAxis.X1, ImAxis.Y1);
                    ImPlot.SetAxis(ImAxis.X1);
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1));
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1), true);
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1), "%.2f");
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1));
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1), true);
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1), "%.2f");
                    ImPlot.PlotText("Text", 0.5, 0.5);
                    ImPlot.PlotText("Text", 0.5, 0.5, new Vector2F(4, 4));
                    ImPlot.PlotText("Text", 0.5, 0.5, new Vector2F(4, 4), ImPlotTextFlags.None);
                    PlotStemsU16();
                    PlotStemsS64();
                    PlotStemsU64();
                    ImPlot.PushPlotClipRect();
                    ImPlot.PopPlotClipRect();
                    ImPlot.PushPlotClipRect(2.0f);
                    ImPlot.PopPlotClipRect();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort PlotStems wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotStemsU16()
        {
            ushort xs = 1;
            ushort ys = 2;
            ImPlot.PlotStems("u16 a", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("u16 b", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("u16 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Executes the long PlotStems wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotStemsS64()
        {
            long xs = 1;
            long ys = 2;
            ImPlot.PlotStems("s64 a", ref xs, ref ys, 1);
            ImPlot.PlotStems("s64 b", ref xs, ref ys, 1, 0.0);
            ImPlot.PlotStems("s64 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("s64 d", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("s64 e", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Executes the ulong PlotStems wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotStemsU64()
        {
            ulong xs = 1;
            ulong ys = 2;
            ImPlot.PlotStems("u64 a", ref xs, ref ys, 1);
            ImPlot.PlotStems("u64 b", ref xs, ref ys, 1, 0.0);
            ImPlot.PlotStems("u64 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("u64 d", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("u64 e", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Verifies the PlotToPixels overloads return finite pixel coordinates inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_Returns_Finite_Vector()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PixelPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    Vector2F point = ImPlot.PlotToPixels(new ImPlotPoint { X = 0.5, Y = 0.5 });
                    Assert.True(float.IsFinite(point.X) && float.IsFinite(point.Y));
                    _ = ImPlot.PlotToPixels(new ImPlotPoint { X = 0.5, Y = 0.5 }, ImAxis.X1);
                    _ = ImPlot.PlotToPixels(new ImPlotPoint { X = 0.5, Y = 0.5 }, ImAxis.X1, ImAxis.Y1);
                    Vector2F value = ImPlot.PlotToPixels(0.5, 0.5);
                    Assert.True(float.IsFinite(value.X) && float.IsFinite(value.Y));
                    _ = ImPlot.PlotToPixels(0.5, 0.5, ImAxis.X1);
                    _ = ImPlot.PlotToPixels(0.5, 0.5, ImAxis.X1, ImAxis.Y1);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the SetupAxisFormat callback overloads with a null formatter inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisFormat_With_Null_Formatter_Executes()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("FormatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupAxisFormat(ImAxis.X1, IntPtr.Zero);
                    ImPlot.SetupAxisFormat(ImAxis.X1, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the SetupAxisScale callback overloads with null transforms inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisScale_With_Null_Transform_Executes()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScalePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupAxisScale(ImAxis.X1, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupAxisScale(ImAxis.X1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }
    }
}
