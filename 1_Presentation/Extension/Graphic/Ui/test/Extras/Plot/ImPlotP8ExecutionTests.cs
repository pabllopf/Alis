// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8ExecutionTests.cs
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
    ///     Executes the real ImPlot PlotShaded, PlotShadedG and PlotStairs wrapper overloads of
    ///     ImPlotP8.cs against the native cimgui library so that the managed bodies of the
    ///     wrappers are exercised for line coverage.
    /// </summary>
    public class ImPlotP8ExecutionTests
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
        ///     The cdecl getter callback used by PlotShadedG
        /// </summary>
        /// <param name="idx">The index</param>
        /// <param name="data">The data</param>
        /// <returns>The point</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ImPlotPoint GetterCallback(int idx, IntPtr data);

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
        ///     Executes the PlotShaded sbyte and byte ref overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_SbyteAndByteRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P8SbyteByte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte sx = 1;
                    sbyte sy1 = 2;
                    sbyte sy2 = 3;
                    ImPlot.PlotShaded("s8 a", ref sx, ref sy1, ref sy2, 1, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s8 b", ref sx, ref sy1, ref sy2, 1, ImPlotShadedFlags.None, 0, sizeof(sbyte));
                    byte bx = 1;
                    byte by1 = 2;
                    byte by2 = 3;
                    ImPlot.PlotShaded("u8 a", ref bx, ref by1, ref by2, 1);
                    ImPlot.PlotShaded("u8 b", ref bx, ref by1, ref by2, 1, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u8 c", ref bx, ref by1, ref by2, 1, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u8 d", ref bx, ref by1, ref by2, 1, ImPlotShadedFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        
        
        
        /// <summary>
        ///     Executes the PlotShadedG getter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShadedG_Getter_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P8ShadedG", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    GetterCallback callback = new GetterCallback((int index, IntPtr data) => new ImPlotPoint { X = index, Y = index });
                    IntPtr getter = Marshal.GetFunctionPointerForDelegate(callback);
                    ImPlot.PlotShadedG("g a", getter, IntPtr.Zero, getter, IntPtr.Zero, 3);
                    ImPlot.PlotShadedG("g b", getter, IntPtr.Zero, getter, IntPtr.Zero, 3, ImPlotShadedFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotStairs float and double array overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_FloatAndDoubleArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P8StairsF32F64", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] floats = { 1.0f, 2.0f, 3.0f };
                    ImPlot.PlotStairs("f32 a", floats, 3);
                    ImPlot.PlotStairs("f32 b", floats, 3, 1.0);
                    ImPlot.PlotStairs("f32 c", floats, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("f32 d", floats, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("f32 e", floats, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("f32 f", floats, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(float));
                    double[] doubles = { 1.0, 2.0, 3.0 };
                    ImPlot.PlotStairs("f64 a", doubles, 3);
                    ImPlot.PlotStairs("f64 b", doubles, 3, 1.0);
                    ImPlot.PlotStairs("f64 c", doubles, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("f64 d", doubles, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("f64 e", doubles, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("f64 f", doubles, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotStairs sbyte and byte array overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_SbyteAndByteArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P8StairsS8U8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] sbytes = { 1, 2, 3 };
                    ImPlot.PlotStairs("s8 a", sbytes, 3);
                    ImPlot.PlotStairs("s8 b", sbytes, 3, 1.0);
                    ImPlot.PlotStairs("s8 c", sbytes, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("s8 d", sbytes, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s8 e", sbytes, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s8 f", sbytes, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(sbyte));
                    byte[] bytes = { 1, 2, 3 };
                    ImPlot.PlotStairs("u8 a", bytes, 3);
                    ImPlot.PlotStairs("u8 b", bytes, 3, 1.0);
                    ImPlot.PlotStairs("u8 c", bytes, 3, 1.0, 0.0);
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
