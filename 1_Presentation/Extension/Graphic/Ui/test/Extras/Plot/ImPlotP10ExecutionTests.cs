// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP10ExecutionTests.cs
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
    ///     Executes the ImPlotP10 wrapper methods (PlotScatter, PlotScatterG and PlotShaded overloads)
    ///     against the native cimgui library so that the managed bodies of the wrappers in ImPlotP10.cs
    ///     are exercised for line coverage.
    /// </summary>
    public class ImPlotP10ExecutionTests
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
        ///     Executes the short PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_S16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterS16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short xs = 1;
                    short ys = 2;
                    ImPlot.PlotScatter("s16 a", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s16 b", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s16 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_U16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterU16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort xs = 1;
                    ushort ys = 2;
                    ImPlot.PlotScatter("u16 a", ref xs, ref ys, 1);
                    ImPlot.PlotScatter("u16 b", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u16 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u16 d", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_S32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int xs = 1;
                    int ys = 2;
                    ImPlot.PlotScatter("s32 a", ref xs, ref ys, 1);
                    ImPlot.PlotScatter("s32 b", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s32 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s32 d", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_U32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint xs = 1;
                    uint ys = 2;
                    ImPlot.PlotScatter("u32 a", ref xs, ref ys, 1);
                    ImPlot.PlotScatter("u32 b", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u32 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u32 d", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_S64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long xs = 1;
                    long ys = 2;
                    ImPlot.PlotScatter("s64 a", ref xs, ref ys, 1);
                    ImPlot.PlotScatter("s64 b", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s64 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s64 d", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong PlotScatter wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_U64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterU64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong xs = 1;
                    ulong ys = 2;
                    ImPlot.PlotScatter("u64 a", ref xs, ref ys, 1);
                    ImPlot.PlotScatter("u64 b", ref xs, ref ys, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u64 c", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u64 d", ref xs, ref ys, 1, ImPlotScatterFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotScatterG wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatterG_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ScatterGPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatterG("g a", IntPtr.Zero, IntPtr.Zero, 0);
                    ImPlot.PlotScatterG("g b", IntPtr.Zero, IntPtr.Zero, 0, ImPlotScatterFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_FloatArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedFloatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] values = new float[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("f a", values, 4);
                    ImPlot.PlotShaded("f b", values, 4, 0.0);
                    ImPlot.PlotShaded("f c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("f d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("f e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("f f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("f g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_DoubleArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedDoublePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] values = new double[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("d a", values, 4);
                    ImPlot.PlotShaded("d b", values, 4, 0.0);
                    ImPlot.PlotShaded("d c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("d d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("d e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("d f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("d g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedS8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] values = new sbyte[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("s8 a", values, 4);
                    ImPlot.PlotShaded("s8 b", values, 4, 0.0);
                    ImPlot.PlotShaded("s8 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("s8 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("s8 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s8 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s8 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedU8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte[] values = new byte[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("u8 a", values, 4);
                    ImPlot.PlotShaded("u8 b", values, 4, 0.0);
                    ImPlot.PlotShaded("u8 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("u8 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("u8 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u8 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u8 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedS16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short[] values = new short[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("s16 a", values, 4);
                    ImPlot.PlotShaded("s16 b", values, 4, 0.0);
                    ImPlot.PlotShaded("s16 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("s16 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("s16 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s16 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s16 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedU16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort[] values = new ushort[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("u16 a", values, 4);
                    ImPlot.PlotShaded("u16 b", values, 4, 0.0);
                    ImPlot.PlotShaded("u16 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("u16 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("u16 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u16 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u16 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int[] values = new int[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("s32 a", values, 4);
                    ImPlot.PlotShaded("s32 b", values, 4, 0.0);
                    ImPlot.PlotShaded("s32 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("s32 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("s32 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s32 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s32 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint[] values = new uint[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("u32 a", values, 4);
                    ImPlot.PlotShaded("u32 b", values, 4, 0.0);
                    ImPlot.PlotShaded("u32 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("u32 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("u32 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u32 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u32 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long[] values = new long[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("s64 a", values, 4);
                    ImPlot.PlotShaded("s64 b", values, 4, 0.0);
                    ImPlot.PlotShaded("s64 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("s64 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("s64 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s64 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s64 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedU64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong[] values = new ulong[] { 1, 2, 3, 4 };
                    ImPlot.PlotShaded("u64 a", values, 4);
                    ImPlot.PlotShaded("u64 b", values, 4, 0.0);
                    ImPlot.PlotShaded("u64 c", values, 4, 0.0, 1.0);
                    ImPlot.PlotShaded("u64 d", values, 4, 0.0, 1.0, 0.0);
                    ImPlot.PlotShaded("u64 e", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u64 f", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u64 g", values, 4, 0.0, 1.0, 0.0, ImPlotShadedFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float ref PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_FloatRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedFloatRefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float xs = 1;
                    float ys = 2;
                    ImPlot.PlotShaded("fr a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("fr b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("fr c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("fr d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("fr e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double ref PlotShaded wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_DoubleRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ShadedDoubleRefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double xs = 1;
                    double ys = 2;
                    ImPlot.PlotShaded("dr a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("dr b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("dr c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("dr d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("dr e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(double));
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
