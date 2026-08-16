// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9ExecutionTests.cs
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
    ///     Executes the ImPlotP9 wrapper methods (long/ulong PlotLine and PlotLineG overloads)
    ///     against the native cimgui library so that the managed bodies of the wrappers in
    ///     ImPlotP9.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP9ExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

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
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
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
        ///     The plot line getter delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ImPlotPoint PlotLineGetter(int idx, IntPtr data);

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
        ///     The point getter implementation
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="data">The data</param>
        /// <returns>The point</returns>
        private static ImPlotPoint PointGetter(int idx, IntPtr data) => new ImPlotPoint { X = idx, Y = idx };

        /// <summary>
        ///     Executes the long PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_S64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("LineS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long xs = 1;
                    long ys = 2;
                    ImPlot.PlotLine("s64 a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("s64 b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s64 c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("s64 d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_U64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("LineU64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong xs = 1;
                    ulong ys = 2;
                    ImPlot.PlotLine("u64 a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("u64 b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u64 c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u64 d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotLineG wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLineG_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("LineGPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotLineGetter getter = PointGetter;
                    IntPtr getterPtr = Marshal.GetFunctionPointerForDelegate(getter);
                    ImPlot.PlotLineG("g a", getterPtr, IntPtr.Zero, 2);
                    ImPlot.PlotLineG("g b", getterPtr, IntPtr.Zero, 2, ImPlotLineFlags.None);
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
