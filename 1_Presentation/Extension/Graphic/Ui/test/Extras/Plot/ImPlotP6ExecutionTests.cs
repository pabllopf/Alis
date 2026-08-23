// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6ExecutionTests.cs
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
    ///     Executes the ImPlotP6 wrapper methods (PlotInfLines and PlotLine array overloads
    ///     for byte, sbyte, ushort, short, int, uint, long and ulong plus float and double)
    ///     against the native cimgui library so that the managed bodies of the wrappers in
    ///     ImPlotP6.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP6ExecutionTests
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
        ///     Executes the byte array PlotInfLines wrapper overload inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_ByteArray_Overload_Executes_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte[] values = new byte[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines U8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("u8 a", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_ShortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = new short[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines S16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("s16 a", values, 3);
                    ImPlot.PlotInfLines("s16 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("s16 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("s16 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_UshortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort[] values = new ushort[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines U16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("u16 a", values, 3);
                    ImPlot.PlotInfLines("u16 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("u16 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("u16 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_IntArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                int[] values = new int[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines S32", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("s32 a", values, 3);
                    ImPlot.PlotInfLines("s32 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("s32 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("s32 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_UintArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                uint[] values = new uint[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines U32", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("u32 a", values, 3);
                    ImPlot.PlotInfLines("u32 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("u32 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("u32 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_LongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                long[] values = new long[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines S64", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("s64 a", values, 3);
                    ImPlot.PlotInfLines("s64 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("s64 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("s64 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotInfLines wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotInfLines_UlongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ulong[] values = new ulong[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 InfLines U64", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotInfLines("u64 a", values, 3);
                    ImPlot.PlotInfLines("u64 b", values, 3, ImPlotInfLinesFlags.None);
                    ImPlot.PlotInfLines("u64 c", values, 3, ImPlotInfLinesFlags.None, 0);
                    ImPlot.PlotInfLines("u64 d", values, 3, ImPlotInfLinesFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_FloatArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                float[] values = new float[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 Line Float", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("f a", values, 3);
                    ImPlot.PlotLine("f b", values, 3, 1.0);
                    ImPlot.PlotLine("f c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("f d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("f e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("f f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_DoubleArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double[] values = new double[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 Line Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("d a", values, 3);
                    ImPlot.PlotLine("d b", values, 3, 1.0);
                    ImPlot.PlotLine("d c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("d d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("d e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("d f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_SbyteArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                sbyte[] values = new sbyte[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 Line S8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s8 a", values, 3);
                    ImPlot.PlotLine("s8 b", values, 3, 1.0);
                    ImPlot.PlotLine("s8 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("s8 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s8 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("s8 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_ByteArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte[] values = new byte[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 Line U8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u8 a", values, 3);
                    ImPlot.PlotLine("u8 b", values, 3, 1.0);
                    ImPlot.PlotLine("u8 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("u8 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u8 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u8 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_ShortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = new short[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P6 Line S16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s16 a", values, 3);
                    ImPlot.PlotLine("s16 b", values, 3, 1.0);
                    ImPlot.PlotLine("s16 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("s16 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s16 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
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
