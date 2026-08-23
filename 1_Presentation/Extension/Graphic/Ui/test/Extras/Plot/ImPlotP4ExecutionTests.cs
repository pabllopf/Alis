// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP4ExecutionTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the real ImPlot PlotHeatmap wrapper overloads of ImPlotP4.cs against the
    ///     native cimgui library so that the managed bodies of the wrappers are exercised for
    ///     line coverage.
    /// </summary>
    public class ImPlotP4ExecutionTests
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
        /// <returns>The IntPtr</returns>
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
        ///     Creates the native ImGui and ImPlot contexts and makes them current.
        /// </summary>
        /// <returns>The imgui context pointer</returns>
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
        ///     Destroys the native ImPlot and ImGui contexts.
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
        ///     Executes the double PlotHeatmap overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_Double_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P4Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] values = { 1.0, 2.0, 3.0, 4.0 };
                    ImPlotPoint boundsMin = new ImPlotPoint { X = 0.0, Y = 0.0 };
                    ImPlotPoint boundsMax = new ImPlotPoint { X = 2.0, Y = 2.0 };
                    ImPlot.PlotHeatmap("f64 a", values, 2, 2, 0.0, 1.0, "%.2f", boundsMin);
                    ImPlot.PlotHeatmap("f64 b", values, 2, 2, 0.0, 1.0, "%.2f", boundsMin, boundsMax);
                    ImPlot.PlotHeatmap("f64 c", values, 2, 2, 0.0, 1.0, "%.2f", boundsMin, boundsMax, ImPlotHeatmapFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte and byte PlotHeatmap overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_SbyteAndByte_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P4S8U8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] sbytes = { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("s8 a", sbytes, 2, 2);
                    ImPlot.PlotHeatmap("s8 b", sbytes, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("s8 c", sbytes, 2, 2, 0.0, 1.0);
                    ImPlot.PlotHeatmap("s8 d", sbytes, 2, 2, 0.0, 1.0, "%.1f");
                    ImPlot.PlotHeatmap("s8 e", sbytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 });
                    ImPlot.PlotHeatmap("s8 f", sbytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 });
                    ImPlot.PlotHeatmap("s8 g", sbytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 }, ImPlotHeatmapFlags.None);
                    byte[] bytes = { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("u8 a", bytes, 2, 2);
                    ImPlot.PlotHeatmap("u8 b", bytes, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("u8 c", bytes, 2, 2, 0.0, 1.0);
                    ImPlot.PlotHeatmap("u8 d", bytes, 2, 2, 0.0, 1.0, "%.1f");
                    ImPlot.PlotHeatmap("u8 e", bytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 });
                    ImPlot.PlotHeatmap("u8 f", bytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 });
                    ImPlot.PlotHeatmap("u8 g", bytes, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 }, ImPlotHeatmapFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short and ushort PlotHeatmap overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_ShortAndUshort_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P4S16U16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short[] shorts = { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("s16 a", shorts, 2, 2);
                    ImPlot.PlotHeatmap("s16 b", shorts, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("s16 c", shorts, 2, 2, 0.0, 1.0);
                    ImPlot.PlotHeatmap("s16 d", shorts, 2, 2, 0.0, 1.0, "%.1f");
                    ImPlot.PlotHeatmap("s16 e", shorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 });
                    ImPlot.PlotHeatmap("s16 f", shorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 });
                    ImPlot.PlotHeatmap("s16 g", shorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 }, ImPlotHeatmapFlags.None);
                    ushort[] ushorts = { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("u16 a", ushorts, 2, 2);
                    ImPlot.PlotHeatmap("u16 b", ushorts, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("u16 c", ushorts, 2, 2, 0.0, 1.0);
                    ImPlot.PlotHeatmap("u16 d", ushorts, 2, 2, 0.0, 1.0, "%.1f");
                    ImPlot.PlotHeatmap("u16 e", ushorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 });
                    ImPlot.PlotHeatmap("u16 f", ushorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 });
                    ImPlot.PlotHeatmap("u16 g", ushorts, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 }, new ImPlotPoint { X = 2.0, Y = 2.0 }, ImPlotHeatmapFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int PlotHeatmap overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_Int_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P4S32", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int[] ints = { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("s32 a", ints, 2, 2);
                    ImPlot.PlotHeatmap("s32 b", ints, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("s32 c", ints, 2, 2, 0.0, 1.0);
                    ImPlot.PlotHeatmap("s32 d", ints, 2, 2, 0.0, 1.0, "%.1f");
                    ImPlot.PlotHeatmap("s32 e", ints, 2, 2, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0.0, Y = 0.0 });
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
