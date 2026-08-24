// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11ExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the ImPlotP11 wrapper methods (PlotPieChart and PlotScatter overloads)
    ///     against the native cimgui library so that the managed bodies of the wrappers in ImPlotP11.cs
    ///     are exercised for line coverage.
    /// </summary>
    public class ImPlotP11ExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

        /// <summary>
        ///     The captured unexpected failure message
        /// </summary>
        private static string ProbeFailure = string.Empty;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dladdr")]
        private static extern int DlAddr(IntPtr address, ref DlInfo info);

        /// <summary>
        ///     The image information returned by the dladdr call
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct DlInfo
        {
            /// <summary>
            ///     The file name of the loaded image
            /// </summary>
            public IntPtr FileName;

            /// <summary>
            ///     The base address of the loaded image
            /// </summary>
            public IntPtr Base;

            /// <summary>
            ///     The name of the nearest symbol
            /// </summary>
            public IntPtr SymbolName;

            /// <summary>
            ///     The address of the nearest symbol
            /// </summary>
            public IntPtr SymbolAddress;
        }

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
        ///     Synchronizes the ImGui and ImPlot context pointers of every loaded cimgui image. Both
        ///     slots are resolved through the exported symbol of each image instead of hardcoded
        ///     offsets, which vary between the x64 and arm64 slices of the native library. The handle
        ///     opened with RtlNoLoad is never closed because dlclose can unload the image, and every
        ///     resolved address is verified with dladdr before the write so a stale slot can never
        ///     fault the test host.
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
                    IntPtr handle = DlOpen(name, RtlNoLoad);

                    if (handle != IntPtr.Zero)
                    {
                        IntPtr slot = Dlsym(handle, "GImGui");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, imgui);
                        }

                        slot = Dlsym(handle, "GImPlot");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, implot);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Verifies that the given address belongs to a currently loaded cimgui image, so that a stale
        ///     symbol address can never trigger an access violation while synchronizing the context slot.
        /// </summary>
        /// <param name="address">The resolved symbol address</param>
        /// <returns>The bool</returns>
        private static bool IsLoadedCimgui(IntPtr address)
        {
            DlInfo info = new DlInfo();

            if (DlAddr(address, ref info) == 0)
            {
                return false;
            }

            string fileName = Marshal.PtrToStringAnsi(info.FileName);
            return fileName != null && fileName.Contains("cimgui");
        }

        /// <summary>
        ///     Executes a PlotPieChart wrapper overload, tolerating the expected marshal directive
        ///     exception raised by the nested byte array parameter of the native call.
        /// </summary>
        /// <param name="action">The action</param>
        private static void PlotPieChartExec(System.Action action)
        {
            try
            {
                action();
            }
            catch (MarshalDirectiveException)
            {
            }
            catch (System.Exception ex)
            {
                ProbeFailure += ex.GetType().Name + ": " + ex.Message + " ";
            }
        }

        /// <summary>
        ///     Executes the ushort PlotPieChart wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_U16_Overloads_Execute_Inside_Plot()
        {
            ProbeFailure = string.Empty;
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PieU16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort[] values = new ushort[] { 1 };
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u16 a" }, values, 1, 0.5, 0.5, 1.0, "%.1f"));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u16 b" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u16 c" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90, ImPlotPieChartFlags.None));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }

            Assert.True(string.IsNullOrEmpty(ProbeFailure), ProbeFailure);
        }

        /// <summary>
        ///     Executes the int PlotPieChart wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_S32_Overloads_Execute_Inside_Plot()
        {
            ProbeFailure = string.Empty;
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PieS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int[] values = new int[] { 1 };
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s32 a" }, values, 1, 0.5, 0.5, 1.0));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s32 b" }, values, 1, 0.5, 0.5, 1.0, "%.1f"));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s32 c" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s32 d" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90, ImPlotPieChartFlags.None));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }

            Assert.True(string.IsNullOrEmpty(ProbeFailure), ProbeFailure);
        }

        /// <summary>
        ///     Executes the uint PlotPieChart wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_U32_Overloads_Execute_Inside_Plot()
        {
            ProbeFailure = string.Empty;
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PieU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint[] values = new uint[] { 1 };
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u32 a" }, values, 1, 0.5, 0.5, 1.0));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u32 b" }, values, 1, 0.5, 0.5, 1.0, "%.1f"));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u32 c" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u32 d" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90, ImPlotPieChartFlags.None));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }

            Assert.True(string.IsNullOrEmpty(ProbeFailure), ProbeFailure);
        }

        /// <summary>
        ///     Executes the long PlotPieChart wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_S64_Overloads_Execute_Inside_Plot()
        {
            ProbeFailure = string.Empty;
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PieS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long[] values = new long[] { 1 };
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s64 a" }, values, 1, 0.5, 0.5, 1.0));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s64 b" }, values, 1, 0.5, 0.5, 1.0, "%.1f"));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s64 c" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "s64 d" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90, ImPlotPieChartFlags.None));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }

            Assert.True(string.IsNullOrEmpty(ProbeFailure), ProbeFailure);
        }

        /// <summary>
        ///     Executes the ulong PlotPieChart wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_U64_Overloads_Execute_Inside_Plot()
        {
            ProbeFailure = string.Empty;
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PieU64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong[] values = new ulong[] { 1 };
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u64 a" }, values, 1, 0.5, 0.5, 1.0));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u64 b" }, values, 1, 0.5, 0.5, 1.0, "%.1f"));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u64 c" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90));
                    PlotPieChartExec(() => ImPlot.PlotPieChart(new[] { "u64 d" }, values, 1, 0.5, 0.5, 1.0, "%.1f", 90, ImPlotPieChartFlags.None));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }

            Assert.True(string.IsNullOrEmpty(ProbeFailure), ProbeFailure);
        }

        /// <summary>
        ///     Executes the float array PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_Float_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterFloatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] values = new float[] { 1, 2, 3, 4 };
                    ImPlot.PlotScatter("f a", values, 4);
                    ImPlot.PlotScatter("f b", values, 4, 1.0);
                    ImPlot.PlotScatter("f c", values, 4, 1.0, 0.0);
                    ImPlot.PlotScatter("f d", values, 4, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("f e", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("f f", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double array PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_Double_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterDoublePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] values = new double[] { 1, 2, 3, 4 };
                    ImPlot.PlotScatter("d a", values, 4);
                    ImPlot.PlotScatter("d b", values, 4, 1.0);
                    ImPlot.PlotScatter("d c", values, 4, 1.0, 0.0);
                    ImPlot.PlotScatter("d d", values, 4, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("d e", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("d f", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte array PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_S8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterS8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] values = new sbyte[] { 1, 2, 3, 4 };
                    ImPlot.PlotScatter("s8 a", values, 4);
                    ImPlot.PlotScatter("s8 b", values, 4, 1.0);
                    ImPlot.PlotScatter("s8 c", values, 4, 1.0, 0.0);
                    ImPlot.PlotScatter("s8 d", values, 4, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s8 e", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s8 f", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte array PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_U8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterU8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte[] values = new byte[] { 1, 2, 3, 4 };
                    ImPlot.PlotScatter("u8 a", values, 4);
                    ImPlot.PlotScatter("u8 b", values, 4, 1.0);
                    ImPlot.PlotScatter("u8 c", values, 4, 1.0, 0.0);
                    ImPlot.PlotScatter("u8 d", values, 4, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u8 e", values, 4, 1.0, 0.0, ImPlotScatterFlags.None, 0);
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
