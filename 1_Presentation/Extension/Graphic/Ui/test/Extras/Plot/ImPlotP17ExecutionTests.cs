// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP17ExecutionTests.cs
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
    ///     Executes the ImPlotP17 wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlotP17.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP17ExecutionTests
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
        ///     Executes the PlotBars, PlotBarsG, PlotDummy and PlotErrorBars wrapper overloads.
        ///     The PlotErrorBars overloads pass a zero count because the native binding takes the
        ///     error array by value, which cannot be dereferenced safely.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBars_BarsG_Dummy_ErrorBars_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarsPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotBarsS64();
                    PlotBarsU64();
                    PlotBarsG();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("MiscPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotDummy();
                    PlotErrorBars();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotDigital and PlotDigitalG wrapper overloads across all numeric types.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotDigital_And_PlotDigitalG_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("DigitalPlotA", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotDigitalFloat();
                    PlotDigitalDouble();
                    PlotDigitalS8();
                    PlotDigitalU8();
                    PlotDigitalS16();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("DigitalPlotB", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotDigitalU16();
                    PlotDigitalS32();
                    PlotDigitalU32();
                    PlotDigitalS64();
                    PlotDigitalU64();
                    PlotDigitalG();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long PlotBars wrapper overload inside the active plot.
        /// </summary>
        private static void PlotBarsS64()
        {
            long xs = 1;
            long ys = 2;
            ImPlot.PlotBars("bars s64", ref xs, ref ys, 1, 0.5, ImPlotBarsFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Executes the ulong PlotBars wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotBarsU64()
        {
            ulong xs = 1;
            ulong ys = 2;
            ImPlot.PlotBars("bars u64 a", ref xs, ref ys, 1, 0.5);
            ImPlot.PlotBars("bars u64 b", ref xs, ref ys, 1, 0.5, ImPlotBarsFlags.None);
            ImPlot.PlotBars("bars u64 c", ref xs, ref ys, 1, 0.5, ImPlotBarsFlags.None, 0);
            ImPlot.PlotBars("bars u64 d", ref xs, ref ys, 1, 0.5, ImPlotBarsFlags.None, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Executes the PlotBarsG wrapper overloads with a null getter and zero count.
        /// </summary>
        private static void PlotBarsG()
        {
            ImPlot.PlotBarsG("bars g a", IntPtr.Zero, IntPtr.Zero, 0, 0.5);
            ImPlot.PlotBarsG("bars g b", IntPtr.Zero, IntPtr.Zero, 0, 0.5, ImPlotBarsFlags.None);
        }

        /// <summary>
        ///     Executes the PlotDummy wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDummy()
        {
            ImPlot.PlotDummy("dummy a");
            ImPlot.PlotDummy("dummy b", ImPlotDummyFlags.None);
        }

        /// <summary>
        ///     Executes the PlotErrorBars wrapper overloads with a zero count so that the
        ///     by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBars()
        {
            float xs = 0.5f;
            float ys = 0.5f;
            float err = 0.1f;
            ImPlot.PlotErrorBars("err a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
        }

        /// <summary>
        ///     Executes the float PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalFloat()
        {
            float[] xs = { 0.0f, 1.0f, 2.0f };
            float[] ys = { 1.0f, 0.0f };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital f32 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital f32 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital f32 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital f32 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(float));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the double PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalDouble()
        {
            double[] xs = { 0.0, 1.0, 2.0 };
            double[] ys = { 1.0, 0.0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital f64 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital f64 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital f64 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital f64 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(double));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the sbyte PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalS8()
        {
            sbyte[] xs = { 0, 1, 2 };
            sbyte[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital s8 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital s8 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital s8 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital s8 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(sbyte));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the byte PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalU8()
        {
            byte[] xs = { 0, 1, 2 };
            byte[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital u8 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital u8 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital u8 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital u8 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(byte));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the short PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalS16()
        {
            short[] xs = { 0, 1, 2 };
            short[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital s16 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital s16 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital s16 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital s16 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(short));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the ushort PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalU16()
        {
            ushort[] xs = { 0, 1, 2 };
            ushort[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital u16 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital u16 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital u16 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital u16 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(ushort));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the int PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalS32()
        {
            int[] xs = { 0, 1, 2 };
            int[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital s32 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital s32 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital s32 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital s32 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(int));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the uint PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalU32()
        {
            uint[] xs = { 0, 1, 2 };
            uint[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital u32 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital u32 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital u32 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital u32 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(uint));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the long PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalS64()
        {
            long[] xs = { 0, 1, 2 };
            long[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital s64 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital s64 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital s64 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital s64 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(long));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the ulong PlotDigital wrapper overloads inside the active plot.
        /// </summary>
        private static void PlotDigitalU64()
        {
            ulong[] xs = { 0, 1, 2 };
            ulong[] ys = { 1, 0 };
            GCHandle xsPin = GCHandle.Alloc(xs, GCHandleType.Pinned);
            GCHandle ysPin = GCHandle.Alloc(ys, GCHandleType.Pinned);
            try
            {
                ImPlot.PlotDigital("digital u64 a", ref xs[0], ref ys[0], 1);
                ImPlot.PlotDigital("digital u64 b", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None);
                ImPlot.PlotDigital("digital u64 c", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0);
                ImPlot.PlotDigital("digital u64 d", ref xs[0], ref ys[0], 1, ImPlotDigitalFlags.None, 0, sizeof(ulong));
            }
            finally
            {
                xsPin.Free();
                ysPin.Free();
            }
        }

        /// <summary>
        ///     Executes the PlotDigitalG wrapper overloads with a null getter and zero count.
        /// </summary>
        private static void PlotDigitalG()
        {
            ImPlot.PlotDigitalG("digital g a", IntPtr.Zero, IntPtr.Zero, 0);
            ImPlot.PlotDigitalG("digital g b", IntPtr.Zero, IntPtr.Zero, 0, ImPlotDigitalFlags.None);
        }
    }
}
