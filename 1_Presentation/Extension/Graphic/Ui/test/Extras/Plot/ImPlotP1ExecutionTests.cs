// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1ExecutionTests.cs
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
    ///     Executes the real ImPlot wrapper methods declared in ImPlotP1.cs against the native
    ///     cimgui library so that the managed bodies of the wrappers are exercised for line coverage.
    /// </summary>
    public class ImPlotP1ExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

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
        ///     Executes the context management wrappers.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Context_Functions_Execute()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                IntPtr implot = ImPlot.CreateContext();
                Assert.NotEqual(IntPtr.Zero, implot);
                ImPlot.SetImGuiContext(imgui);
                ImPlot.SetCurrentContext(implot);
                Assert.Equal(implot, ImPlot.GetCurrentContext());
                ImPlot.DestroyContext(implot);
                IntPtr second = ImPlot.CreateContext();
                ImPlot.SetCurrentContext(second);
                ImPlot.DestroyContext();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Executes the ColormapButton and ColormapIcon wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Colormap_Button_And_Icon_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("P1 Colormap Plot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    _ = ImPlot.ColormapButton("button 1");
                    _ = ImPlot.ColormapButton("button 2", new Vector2F(80, 20));
                    _ = ImPlot.ColormapButton("button 3", new Vector2F(80, 20), ImPlotColormap.Deep);
                    ImPlot.ColormapIcon(ImPlotColormap.Deep);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the title only and title with size BeginPlot overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Plot_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool first = ImPlot.BeginPlot("P1 Plot One");
                Assert.True(first);
                if (first)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
                bool second = ImPlot.BeginPlot("P1 Plot Two", new Vector2F(400, 300));
                Assert.True(second);
                if (second)
                {
                    ImPlot.SetupAxes("x", "y");
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
        ///     Executes the BeginPlot overload with title, size and flags.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Plot_Flags_Overload_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("P1 Plot Three", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
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
        ///     Executes the Annotation and misc wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Annotation_And_Misc_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("P1 Annotation Plot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.Annotation(0.5, 0.5, new Vector4F(1, 0, 0, 1), new Vector2F(4, 4), false);
                    ImPlot.Annotation(0.5, 0.5, new Vector4F(1, 0, 0, 1), new Vector2F(4, 4), true, true);
                    ImPlot.Annotation(0.5, 0.5, new Vector4F(1, 0, 0, 1), new Vector2F(4, 4), false, "%.2f");
                    ImPlot.CancelPlotSelection();
                    ImPlot.BustColorCache();
                    ImPlot.BustColorCache("P1 Annotation Plot");
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the drag drop source, target and legend popup wrappers inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragDrop_Sources_Targets_And_Legend_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("P1 DragDrop Plot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    _ = ImPlot.BeginDragDropSourceAxis(ImAxis.X1);
                    _ = ImPlot.BeginDragDropSourceAxis(ImAxis.Y1, Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags.None);
                    _ = ImPlot.BeginDragDropSourceItem("p1 item");
                    _ = ImPlot.BeginDragDropSourceItem("p1 item", Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags.None);
                    _ = ImPlot.BeginDragDropSourcePlot();
                    _ = ImPlot.BeginDragDropSourcePlot(Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags.None);
                    _ = ImPlot.BeginDragDropTargetAxis(ImAxis.X1);
                    _ = ImPlot.BeginDragDropTargetLegend();
                    _ = ImPlot.BeginDragDropTargetPlot();
                    _ = ImPlot.BeginLegendPopup("p1 legend");
                    _ = ImPlot.BeginLegendPopup("p1 legend", ImGuiMouseButton.Right);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the aligned plots wrappers with a plot group spanning two plots.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Aligned_Plots_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool groupA = ImPlot.BeginAlignedPlots("p1 group a");
                Assert.True(groupA);
                if (groupA)
                {
                    bool plotA = ImPlot.BeginPlot("P1 Aligned A", new Vector2F(300, 200), ImPlotFlags.None);
                    Assert.True(plotA);
                    if (plotA)
                    {
                        ImPlot.SetupAxes("x", "y");
                        ImPlot.SetupFinish();
                        ImPlot.EndPlot();
                    }
                    bool plotB = ImPlot.BeginPlot("P1 Aligned B", new Vector2F(300, 200), ImPlotFlags.None);
                    Assert.True(plotB);
                    if (plotB)
                    {
                        ImPlot.SetupAxes("x", "y");
                        ImPlot.SetupFinish();
                        ImPlot.EndPlot();
                    }
                    ImPlot.EndAlignedPlots();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the vertical aligned plots wrappers with a single plot inside the group.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Aligned_Plots_Vertical_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool groupB = ImPlot.BeginAlignedPlots("p1 group b", true);
                Assert.True(groupB);
                if (groupB)
                {
                    bool plotC = ImPlot.BeginPlot("P1 Aligned C", new Vector2F(300, 200), ImPlotFlags.None);
                    Assert.True(plotC);
                    if (plotC)
                    {
                        ImPlot.SetupAxes("x", "y");
                        ImPlot.SetupFinish();
                        ImPlot.EndPlot();
                    }
                    ImPlot.EndAlignedPlots();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }
    }
}
