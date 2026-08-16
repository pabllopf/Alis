// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP18ExecutionTests.cs
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
    ///     Executes the real ImPlotP18 wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlotP18.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP18ExecutionTests
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
        ///     Builds a default histogram range from zero to two on both axes.
        /// </summary>
        /// <returns>The im plot rect</returns>
        private static ImPlotRect CreateRange()
        {
            ImPlotRange rangeX = new ImPlotRange { Min = 0.0, Max = 2.0 };
            ImPlotRange rangeY = new ImPlotRange { Min = 0.0, Max = 2.0 };
            return new ImPlotRect { X = rangeX, Y = rangeY };
        }

        /// <summary>
        ///     Executes the byte, short and ushort ref PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("Histogram2D Plot A", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotHistogram2DByte();
                    PlotHistogram2DShort();
                    PlotHistogram2DUshort();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int, uint, long and ulong ref PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_Ref_Overloads_Execute_Inside_Plot_Second()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("Histogram2D Plot B", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotHistogram2DInt();
                    PlotHistogram2DUint();
                    PlotHistogram2DLong();
                    PlotHistogram2DUlong();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes all PlotImage wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotImage_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("Image Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    IntPtr textureId = new IntPtr(1);
                    ImPlotPoint boundsMin = new ImPlotPoint { X = 0.0, Y = 0.0 };
                    ImPlotPoint boundsMax = new ImPlotPoint { X = 1.0, Y = 1.0 };
                    Vector2F uv0 = new Vector2F(0.0f, 0.0f);
                    Vector2F uv1 = new Vector2F(1.0f, 1.0f);
                    Vector4F tint = new Vector4F(1.0f, 1.0f, 1.0f, 1.0f);
                    ImPlot.PlotImage("img a", textureId, boundsMin, boundsMax);
                    ImPlot.PlotImage("img b", textureId, boundsMin, boundsMax, uv0);
                    ImPlot.PlotImage("img c", textureId, boundsMin, boundsMax, uv0, uv1);
                    ImPlot.PlotImage("img d", textureId, boundsMin, boundsMax, uv0, uv1, tint);
                    ImPlot.PlotImage("img e", textureId, boundsMin, boundsMax, uv0, uv1, tint, ImPlotImageFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes all PlotInfLines wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("InfLines Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("ifl a", new float[] { 1, 2, 3 }, 3);
                    ImPlot.PlotInfLines("ifl b", new float[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("ifl c", new float[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("ifl d", new float[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0, sizeof(float));
                    ImPlot.PlotInfLines("ifd a", new double[] { 1, 2, 3 }, 3);
                    ImPlot.PlotInfLines("ifd b", new double[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("ifd c", new double[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("ifd d", new double[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0, sizeof(double));
                    ImPlot.PlotInfLines("ifs a", new sbyte[] { 1, 2, 3 }, 3);
                    ImPlot.PlotInfLines("ifs b", new sbyte[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("ifs c", new sbyte[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("ifs d", new sbyte[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0, sizeof(sbyte));
                    ImPlot.PlotInfLines("ifu a", new byte[] { 1, 2, 3 }, 3);
                    ImPlot.PlotInfLines("ifu b", new byte[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("ifu c", new byte[] { 1, 2, 3 }, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DByte()
        {
            byte xs = 1;
            byte ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 u8 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 u8 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the short PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DShort()
        {
            short xs = 1;
            short ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 s16 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 s16 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s16 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s16 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 s16 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the ushort PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DUshort()
        {
            ushort xs = 1;
            ushort ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 u16 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 u16 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u16 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u16 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 u16 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the int PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DInt()
        {
            int xs = 1;
            int ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 s32 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 s32 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s32 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s32 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 s32 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the uint PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DUint()
        {
            uint xs = 1;
            uint ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 u32 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 u32 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u32 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u32 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 u32 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the long PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DLong()
        {
            long xs = 1;
            long ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 s64 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 s64 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s64 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 s64 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 s64 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }

        /// <summary>
        ///     Executes the ulong PlotHistogram2D wrapper overloads.
        /// </summary>
        private static void PlotHistogram2DUlong()
        {
            ulong xs = 1;
            ulong ys = 1;
            ImPlotRect range = CreateRange();
            _ = ImPlot.PlotHistogram2D("p18 u64 c", ref xs, ref ys, 1);
            _ = ImPlot.PlotHistogram2D("p18 u64 x", ref xs, ref ys, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u64 xy", ref xs, ref ys, 1, 1, 1);
            _ = ImPlot.PlotHistogram2D("p18 u64 r", ref xs, ref ys, 1, 1, 1, range);
            _ = ImPlot.PlotHistogram2D("p18 u64 rf", ref xs, ref ys, 1, 1, 1, range, ImPlotHistogramFlags.None);
        }
    }
}
