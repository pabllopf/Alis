// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP16ExecutionTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the ImPlotP16 wrapper methods (all PlotBars overloads of the numeric
    ///     type spread) against the native cimgui library so that the managed bodies of
    ///     the wrappers in ImPlotP16.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP16ExecutionTests
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
        ///     Executes the uint array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U32_Array_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU32ArrayPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint[] values = new uint[] { 1, 2, 3 };
                    ImPlot.PlotBars("b0", values, 3, 0.67);
                    ImPlot.PlotBars("b1", values, 3, 0.67, 0.0);
                    ImPlot.PlotBars("b2", values, 3, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b3", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b4", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S64_Array_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS64ArrayPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long[] values = new long[] { 1, 2, 3 };
                    ImPlot.PlotBars("b5", values, 3);
                    ImPlot.PlotBars("b6", values, 3, 0.67);
                    ImPlot.PlotBars("b7", values, 3, 0.67, 0.0);
                    ImPlot.PlotBars("b8", values, 3, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b9", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b10", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U64_Array_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU64ArrayPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong[] values = new ulong[] { 1, 2, 3 };
                    ImPlot.PlotBars("b11", values, 3);
                    ImPlot.PlotBars("b12", values, 3, 0.67);
                    ImPlot.PlotBars("b13", values, 3, 0.67, 0.0);
                    ImPlot.PlotBars("b14", values, 3, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b15", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b16", values, 3, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_F32_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsF32RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float xs = default;
                    float ys = default;
                    ImPlot.PlotBars("b17", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b18", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b19", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b20", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_F64_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsF64RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double xs = default;
                    double ys = default;
                    ImPlot.PlotBars("b21", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b22", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b23", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b24", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S8_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS8RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte xs = default;
                    sbyte ys = default;
                    ImPlot.PlotBars("b25", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b26", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b27", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b28", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U8_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU8RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte xs = default;
                    byte ys = default;
                    ImPlot.PlotBars("b29", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b30", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b31", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b32", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S16_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS16RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short xs = default;
                    short ys = default;
                    ImPlot.PlotBars("b33", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b34", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b35", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b36", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U16_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU16RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort xs = default;
                    ushort ys = default;
                    ImPlot.PlotBars("b37", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b38", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b39", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b40", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S32_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS32RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int xs = default;
                    int ys = default;
                    ImPlot.PlotBars("b41", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b42", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b43", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b44", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint ref PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U32_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU32RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint xs = default;
                    uint ys = default;
                    ImPlot.PlotBars("b45", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b46", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b47", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b48", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long ref PlotBars wrapper overloads inside the active plot.
        ///     The full stride overload of this family lives in ImPlotP17, so this
        ///     partial file only exposes the bar size, flags and offset variants.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S64_Ref_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS64RefPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long xs = default;
                    long ys = default;
                    ImPlot.PlotBars("b49", ref xs, ref ys, 1, 0.67);
                    ImPlot.PlotBars("b50", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b51", ref xs, ref ys, 1, 0.67, ImPlotBarsFlags.None, 0);
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
