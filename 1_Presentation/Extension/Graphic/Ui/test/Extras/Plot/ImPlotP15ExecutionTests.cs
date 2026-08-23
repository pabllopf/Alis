// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP15ExecutionTests.cs
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
    ///     Executes the ImPlotP15 wrapper methods (PlotBarGroups and PlotBars overloads)
    ///     against the native cimgui library so that the managed bodies of the wrappers
    ///     in ImPlotP15.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP15ExecutionTests
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
        ///     Executes the uint PlotBarGroups wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g0\0" };
                    uint[] values = new uint[] { 1 };

                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long PlotBarGroups wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_S64_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g1\0" };
                    long[] values = new long[] { 1 };

                    ImPlot.PlotBarGroups(labels, values, 1, 1);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong PlotBarGroups wrapper overloads with explicit group sizes inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U64_Full_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU64FullPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g2\0" };
                    ulong[] values = new ulong[] { 1 };

                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong PlotBarGroups wrapper overload with default group size inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U64_Default_Overload_Executes_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g3\0" };
                    ulong[] values = new ulong[] { 1 };

                    ImPlot.PlotBarGroups(labels, values, 1, 1);

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_Float_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsFloatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] values = new float[] { 1 };
                    ImPlot.PlotBars("b0", ref values, 1);
                    ImPlot.PlotBars("b1", ref values, 1, 0.67);
                    ImPlot.PlotBars("b2", ref values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b3", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b4", ref values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b5", ref values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_Double_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsDoublePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] values = new double[] { 1 };
                    ImPlot.PlotBars("b6", values, 1);
                    ImPlot.PlotBars("b7", values, 1, 0.67);
                    ImPlot.PlotBars("b8", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b9", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b10", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b11", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] values = new sbyte[] { 1 };
                    ImPlot.PlotBars("b12", values, 1);
                    ImPlot.PlotBars("b13", values, 1, 0.67);
                    ImPlot.PlotBars("b14", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b15", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b16", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b17", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte[] values = new byte[] { 1 };
                    ImPlot.PlotBars("b18", values, 1);
                    ImPlot.PlotBars("b19", values, 1, 0.67);
                    ImPlot.PlotBars("b20", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b21", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b22", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b23", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short[] values = new short[] { 1 };
                    ImPlot.PlotBars("b24", values, 1);
                    ImPlot.PlotBars("b25", values, 1, 0.67);
                    ImPlot.PlotBars("b26", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b27", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b28", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b29", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort[] values = new ushort[] { 1 };
                    ImPlot.PlotBars("b30", values, 1);
                    ImPlot.PlotBars("b31", values, 1, 0.67);
                    ImPlot.PlotBars("b32", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b33", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b34", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b35", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotBars wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_S32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int[] values = new int[] { 1 };
                    ImPlot.PlotBars("b36", values, 1);
                    ImPlot.PlotBars("b37", values, 1, 0.67);
                    ImPlot.PlotBars("b38", values, 1, 0.67, 0.0);
                    ImPlot.PlotBars("b39", values, 1, 0.67, 0.0, ImPlotBarsFlags.None);
                    ImPlot.PlotBars("b40", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0);
                    ImPlot.PlotBars("b41", values, 1, 0.67, 0.0, ImPlotBarsFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotBars wrapper overload inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Bars_U32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint[] values = new uint[] { 1 };
                    ImPlot.PlotBars("b42", values, 1);
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
